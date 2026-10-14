USE Matiensos_db;
GO

-- =============================================
-- Description: Calcula las métricas del dashboard de ventas agrupando por fechas y método de pago (opcional).
-- =============================================
CREATE PROCEDURE dbo.sp_ObtenerMetricasDashboard
    @desde DATETIME2,
    @hasta DATETIME2,
    @payment_method_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. RESULT SET 1: Cantidad de Ventas y Total Recaudado
    SELECT 
        COUNT(*) AS Cantidad, 
        ISNULL(SUM(total_amount), 0) AS Total
    FROM dbo.sale s
    WHERE s.is_active = 1 
      AND s.created_at BETWEEN @desde AND @hasta
      AND (@payment_method_id IS NULL OR s.payment_method_id = @payment_method_id);

    -- 2. RESULT SET 2: Categoría Top (Más vendida en dinero)
    SELECT TOP 1 cat.name AS CategoriaTop
    FROM dbo.sale_detail sd
    INNER JOIN dbo.sale s ON sd.sale_id = s.id
    INNER JOIN dbo.product pr ON sd.product_id = pr.id
    INNER JOIN dbo.category cat ON pr.category_id = cat.id
    WHERE s.is_active = 1 
      AND s.created_at BETWEEN @desde AND @hasta 
      AND (@payment_method_id IS NULL OR s.payment_method_id = @payment_method_id)
    GROUP BY cat.name
    ORDER BY SUM(sd.quantity * sd.unit_price) DESC;

    -- 3. RESULT SET 3: Ventas agrupadas por Método de Pago (Para el gráfico de torta)
    SELECT 
        pm.name AS MetodoPago, 
        ISNULL(SUM(s.total_amount), 0) AS TotalMetodo
    FROM dbo.sale s
    INNER JOIN dbo.payment_method pm ON s.payment_method_id = pm.id
    WHERE s.is_active = 1 
      AND s.created_at BETWEEN @desde AND @hasta 
      AND (@payment_method_id IS NULL OR s.payment_method_id = @payment_method_id)
    GROUP BY pm.name;

END
GO

-- =============================================
-- Description: SP para Obtener el Historial Paginado de Ventas.
-- Devuelve dos Result Sets: Total de páginas (COUNT) y Datos de la página actual
-- =============================================
CREATE OR ALTER PROCEDURE dbo.sp_Ventas_ObtenerHistorial  
    @desde DATETIME2,  
    @hasta DATETIME2,  
    @payment_method_id INT = NULL,  
    @user_id INT = NULL,                 -- Filtro por rol (vendedor actual o null para admin)
    @texto_busqueda VARCHAR(100) = NULL, -- Filtro de texto para código o nombre
    @pagina INT = 1,  
    @filasPorPagina INT = 10  
AS  
BEGIN  
    SET NOCOUNT ON;  
    DECLARE @offset INT = (@pagina - 1) * @filasPorPagina;  
  
    -- 1. RESULT SET 1: Cantidad total de registros  
    SELECT COUNT(*) AS TotalRegistros  
    FROM dbo.sale s  
    INNER JOIN dbo.customer c ON s.customer_id = c.customer_id  
    INNER JOIN dbo.person pCliente ON c.customer_id = pCliente.id  
    WHERE s.is_active = 1  
      AND s.created_at BETWEEN @desde AND @hasta  
      AND (@payment_method_id IS NULL OR s.payment_method_id = @payment_method_id)
      AND (@user_id IS NULL OR s.user_id = @user_id)
      AND (
          @texto_busqueda IS NULL 
          OR s.code LIKE '%' + @texto_busqueda + '%' 
          OR pCliente.first_name LIKE '%' + @texto_busqueda + '%' 
          OR pCliente.last_name LIKE '%' + @texto_busqueda + '%'
      );  
  
    -- 2. RESULT SET 2: La página de datos específica
    SELECT   
        s.id, 
        s.code, 
        s.created_at, 
        s.total_amount,  
        pCliente.first_name, 
        pCliente.last_name,
        pCliente.first_name AS cliente_nombre, 
        pCliente.last_name AS cliente_apellido,
        pVendedor.first_name AS vendedor_nombre,
        pVendedor.last_name AS vendedor_apellido,  
        pm.name AS metodo_pago  
    FROM dbo.sale s  
    INNER JOIN dbo.customer c ON s.customer_id = c.customer_id  
    INNER JOIN dbo.person pCliente ON c.customer_id = pCliente.id  
    LEFT JOIN dbo.[user] u ON s.user_id = u.user_id  
    LEFT JOIN dbo.person pVendedor ON u.user_id = pVendedor.id  
    INNER JOIN dbo.payment_method pm ON s.payment_method_id = pm.id  
    WHERE s.is_active = 1  
      AND s.created_at BETWEEN @desde AND @hasta  
      AND (@payment_method_id IS NULL OR s.payment_method_id = @payment_method_id)
      AND (@user_id IS NULL OR s.user_id = @user_id)
      AND (
          @texto_busqueda IS NULL 
          OR s.code LIKE '%' + @texto_busqueda + '%' 
          OR pCliente.first_name LIKE '%' + @texto_busqueda + '%' 
          OR pCliente.last_name LIKE '%' + @texto_busqueda + '%'
      )  
    ORDER BY s.created_at DESC  
    OFFSET @offset ROWS FETCH NEXT @filasPorPagina ROWS ONLY;  
END;
GO

-- =============================================
-- TYPE: Tipo de dato tabla para pasar una lista de detalles desde C# (TVP)
-- =============================================
CREATE TYPE dbo.Type_DetalleVenta AS TABLE (
    product_id INT,
    quantity INT,
    unit_price DECIMAL(12,2)
);
GO

-- =============================================
-- Description: SP Transaccional para Registrar una Venta Completa
-- Inserta la cabecera, descuenta stock y guarda el detalle en una sola Transacción.
-- =============================================
CREATE PROCEDURE dbo.sp_Venta_Registrar
    @total DECIMAL(12,2),
    @status VARCHAR(20),
    @voucher_type CHAR(1),
    @user_id INT,
    @customer_id INT,
    @payment_method_id INT,
    @detalles dbo.Type_DetalleVenta READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Descontar Stock y Validar
        UPDATE p
        SET p.stock = p.stock - d.quantity
        FROM dbo.product p
        INNER JOIN @detalles d ON p.id = d.product_id;

        -- 2. Generar Número de Comprobante Correlativo de forma Atómica
        DECLARE @AnioActual INT = YEAR(GETDATE());
        DECLARE @UltimoNumero INT = 0;
        DECLARE @nuevoCodigo VARCHAR(50);

        SELECT @UltimoNumero = ISNULL(MAX(CAST(RIGHT(code, 5) AS INT)), 0)
        FROM dbo.sale WITH (UPDLOCK, HOLDLOCK) -- Bloqueo preventivo anti-carrera
        WHERE voucher_type = @voucher_type 
          AND YEAR(created_at) = @AnioActual;

        SET @UltimoNumero = @UltimoNumero + 1;
        SET @nuevoCodigo = @voucher_type + '-' + CAST(@AnioActual AS VARCHAR(4)) + '-' + RIGHT('00000' + CAST(@UltimoNumero AS VARCHAR(5)), 5);

        -- 3. Insertar Cabecera de la Venta
        DECLARE @nuevaVentaId INT;
        INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, is_active, user_id, customer_id, payment_method_id)
        VALUES (@nuevoCodigo, @total, @status, @voucher_type, GETDATE(), 1, @user_id, @customer_id, @payment_method_id);
        
        SET @nuevaVentaId = SCOPE_IDENTITY();

        -- 4. Insertar Todos los Detalles de una vez
        INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
        SELECT @nuevaVentaId, d.product_id, d.quantity, d.unit_price
        FROM @detalles d;

        COMMIT TRANSACTION;
        
        -- Retornar el ID de la nueva venta Y el código autogenerado (Éxito)
        SELECT @nuevaVentaId AS NuevaVentaId, @nuevoCodigo AS CodigoGenerado;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        -- Relanzar el error para que el Try-Catch de C# lo atrape
        THROW;
    END CATCH
END
GO

-- =============================================
-- Description: Obtiene la cabecera y el detalle de una venta para el Ticket de Impresión
-- Devuelve dos Result Sets: Cabecera y Lista de Detalles (MARS)
-- =============================================
CREATE PROCEDURE dbo.sp_Venta_ObtenerTicket
    @sale_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. RESULT SET 1: Cabecera del Ticket
    SELECT 
        s.code, s.voucher_type, s.created_at, s.total_amount,
        pCliente.first_name AS cliente_nombre, pCliente.last_name AS cliente_apellido, pCliente.dni AS cliente_dni,
        pVendedor.first_name AS vendedor_nombre, pVendedor.last_name AS vendedor_apellido,
        pm.name AS metodo_pago
    FROM dbo.sale s
    INNER JOIN dbo.customer c ON s.customer_id = c.customer_id
    INNER JOIN dbo.person pCliente ON c.customer_id = pCliente.id
    INNER JOIN dbo.[user] u ON s.user_id = u.user_id
    INNER JOIN dbo.person pVendedor ON u.user_id = pVendedor.id
    INNER JOIN dbo.payment_method pm ON s.payment_method_id = pm.id
    WHERE s.id = @sale_id;

    -- 2. RESULT SET 2: Detalles de los productos de esa venta
    SELECT 
        sd.quantity, sd.unit_price, 
        pr.code, pr.name
    FROM dbo.sale_detail sd
    INNER JOIN dbo.product pr ON sd.product_id = pr.id
    WHERE sd.sale_id = @sale_id;

END
GO
