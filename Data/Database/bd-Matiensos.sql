USE [master];
GO

-- 1. Cerrar conexiones activas y reiniciar la base de datos de cero
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Matiensos_db')
BEGIN
    ALTER DATABASE [Matiensos_db] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [Matiensos_db];
END;
GO

CREATE DATABASE [Matiensos_db];
GO

USE [Matiensos_db];
GO

-- =============================================================
-- 2. CREACIÓN DE TABLAS
-- =============================================================

CREATE TABLE dbo.person (
    id INT IDENTITY(1,1) NOT NULL,
    first_name VARCHAR(100) NULL,
    last_name VARCHAR(100) NULL,
    dni VARCHAR(8) NOT NULL,
    email VARCHAR(255) NULL,
    phone VARCHAR(15) NULL,
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_person PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_person_dni UNIQUE (dni),
    CONSTRAINT UQ_person_email UNIQUE (email),
    CONSTRAINT CK_person_dni CHECK (dni NOT LIKE '%-%' AND ISNUMERIC(dni) = 1)
);
GO

CREATE TABLE dbo.[role] (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(255) NULL,
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_role PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_role_name UNIQUE (name)
);
GO

CREATE TABLE dbo.[user] (
    user_id INT NOT NULL,
    password VARCHAR(255) NOT NULL,
    role_id INT NOT NULL,
    CONSTRAINT PK_user PRIMARY KEY CLUSTERED (user_id),
    CONSTRAINT FK_user_person FOREIGN KEY (user_id) REFERENCES dbo.person(id),
    CONSTRAINT FK_user_role FOREIGN KEY (role_id) REFERENCES dbo.[role](id)
);
GO

CREATE TABLE dbo.customer (
    customer_id INT NOT NULL,
    address VARCHAR(255) NULL,
    CONSTRAINT PK_customer PRIMARY KEY CLUSTERED (customer_id),
    CONSTRAINT FK_customer_person FOREIGN KEY (customer_id) REFERENCES dbo.person(id)
);
GO

CREATE TABLE dbo.category (
    id INT IDENTITY(1,1) NOT NULL,
    code CHAR(4) NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(255) NULL,
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NOT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_category PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_category_code UNIQUE (code),
    CONSTRAINT FK_category_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_category_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_category_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id)
);
GO

CREATE TABLE dbo.product (
    id INT IDENTITY(1,1) NOT NULL,
    code CHAR(4) NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(255) NULL,
    price DECIMAL(12,2) NOT NULL,
    stock INT NOT NULL,
    minimum_stock INT NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NOT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    category_id INT NOT NULL,
    CONSTRAINT PK_product PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_product_code UNIQUE (code),
    CONSTRAINT UQ_product_name UNIQUE (name),
    CONSTRAINT CK_product_price CHECK (price >= 0),
    CONSTRAINT CK_product_stock CHECK (stock >= 0),
    CONSTRAINT CK_product_minimum_stock CHECK (minimum_stock >= 0),
    CONSTRAINT FK_product_category FOREIGN KEY (category_id) REFERENCES dbo.category(id),
    CONSTRAINT FK_product_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_product_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_product_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id)
);
GO

CREATE TABLE dbo.payment_method (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(255) NULL,
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NOT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_payment_method PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_payment_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_payment_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_payment_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id)
);
GO

CREATE TABLE dbo.sale (
    id INT IDENTITY(1,1) NOT NULL,
    code VARCHAR(50) NOT NULL,
    total_amount DECIMAL(12,2) NOT NULL,
    delivery_date DATETIME2 NULL,
    status VARCHAR(20) NOT NULL DEFAULT 'Completada',
    voucher_type CHAR(1) NOT NULL DEFAULT 'B',
    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    user_id INT NOT NULL,
    customer_id INT NOT NULL,
    payment_method_id INT NOT NULL,
    CONSTRAINT PK_sale PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_sale_code UNIQUE (code),
    CONSTRAINT CK_sale_total CHECK (total_amount >= 0),
    CONSTRAINT CK_sale_voucher_type CHECK (voucher_type IN ('A', 'B', 'C')),
    CONSTRAINT FK_sale_user FOREIGN KEY (user_id) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_sale_customer FOREIGN KEY (customer_id) REFERENCES dbo.customer(customer_id),
    CONSTRAINT FK_sale_payment_method FOREIGN KEY (payment_method_id) REFERENCES dbo.payment_method(id),
    CONSTRAINT FK_sale_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_sale_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id)
);
GO

CREATE TABLE dbo.sale_detail (
    id INT IDENTITY(1,1) NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(12,2) NOT NULL,
    product_id INT NOT NULL,
    sale_id INT NOT NULL,
    CONSTRAINT PK_sale_detail PRIMARY KEY CLUSTERED (id),
    CONSTRAINT CK_sale_detail_quantity CHECK (quantity > 0),
    CONSTRAINT CK_sale_detail_unit_price CHECK (unit_price >= 0),
    CONSTRAINT FK_sale_detail_product FOREIGN KEY (product_id) REFERENCES dbo.product(id),
    CONSTRAINT FK_sale_detail_sale FOREIGN KEY (sale_id) REFERENCES dbo.sale(id)
);
GO

-- Foreign keys de auditoría añadidas al final
ALTER TABLE dbo.person ADD CONSTRAINT FK_person_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id);
ALTER TABLE dbo.person ADD CONSTRAINT FK_person_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id);
ALTER TABLE dbo.person ADD CONSTRAINT FK_person_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id);

ALTER TABLE dbo.[role] ADD CONSTRAINT FK_role_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id);
ALTER TABLE dbo.[role] ADD CONSTRAINT FK_role_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id);
ALTER TABLE dbo.[role] ADD CONSTRAINT FK_role_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id);
GO

-- =============================================================
-- 3. PROCEDIMIENTO ALMACENADO
-- =============================================================
CREATE OR ALTER PROCEDURE dbo.sp_GenerarNumeroComprobante
    @VoucherType CHAR(1),
    @NuevoCodigo VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AnioActual INT = YEAR(GETDATE());
    DECLARE @UltimoNumero INT = 0;

    SELECT @UltimoNumero = ISNULL(MAX(CAST(RIGHT(code, 5) AS INT)), 0)
    FROM dbo.sale
    WHERE voucher_type = @VoucherType 
      AND YEAR(created_at) = @AnioActual;

    SET @UltimoNumero = @UltimoNumero + 1;
    SET @NuevoCodigo = @VoucherType + '-' + CAST(@AnioActual AS VARCHAR(4)) + '-' + RIGHT('00000' + CAST(@UltimoNumero AS VARCHAR(5)), 5);
END;
GO

-- =============================================================
-- 4. CARGA DE DATOS SEMILLA
-- =============================================================

-- Roles
INSERT INTO dbo.[role] (name, description, is_active)
VALUES 
('SuperAdmin', 'Control total y auditoría del sistema', 1),
('Admin', 'Administración general del negocio', 1),
('Vendedor', 'Módulo de facturación, caja y ventas', 1);

-- Personas para Usuarios (IDs 1, 2, 3)
INSERT INTO dbo.person (first_name, last_name, dni, email, phone, is_active)
VALUES 
('Super', 'Admin', '10000001', 'superadmin@matiensos.com', '3794000001', 1),
('Admin', 'General', '10000002', 'admin@matiensos.com', '3794000002', 1),
('Lucas', 'Vendedor', '10000003', 'vendedor@matiensos.com', '3794000003', 1);

-- Usuarios del Sistema
INSERT INTO dbo.[user] (user_id, password, role_id)
VALUES 
(1, 'Super123!', 1),
(2, 'Admin123!', 2),
(3, 'Venta123!', 3);

-- Personas para Clientes (IDs 4, 5, 6, 7, 8)
INSERT INTO dbo.person (first_name, last_name, dni, email, phone, is_active)
VALUES 
('Consumidor', 'Final', '99999999', 'cf@matiensos.com', '0000000000', 1),
('Carlos', 'Benítez', '34567890', 'carlos.benitez@gmail.com', '3794112233', 1),
('Mariana', 'Gómez', '38123456', 'mariana.gomez@hotmail.com', '3794223344', 1),
('Rodrigo', 'Valenzuela', '29876543', 'rvalenzuela@gmail.com', '3794334455', 1),
('Florencia', 'Romero', '41234567', 'flor.romero@yahoo.com', '3794445566', 1);

-- Clientes
INSERT INTO dbo.customer (customer_id, address)
VALUES 
(4, 'Venta en mostrador'),
(5, 'Av. 3 de Abril 1240, Corrientes'),
(6, 'Junín 850, Corrientes'),
(7, 'Pellegrini 420, Corrientes'),
(8, 'San Martín 1560, Corrientes');

-- Métodos de Pago
INSERT INTO dbo.payment_method (name, description, created_by, is_active)
VALUES 
('Efectivo', 'Pago de contado en caja', 2, 1),
('Transferencia', 'Transferencia bancaria / billetera virtual', 2, 1),
('Débito', 'Tarjeta de débito', 2, 1),
('Crédito', 'Tarjeta de crédito en un pago o cuotas', 2, 1);

-- Categorías
INSERT INTO dbo.category (code, name, description, created_by, is_active)
VALUES 
('MATE', 'Mates y Termos', 'Mates de calabaza, térmicos y termos de acero', 2, 1),
('BOMB', 'Bombillas', 'Bombillas de alpaca, acero inoxidable y resorte', 2, 1),
('YERB', 'Yerba Mate', 'Yerbas tradicionales, compuestas y barbacuá', 2, 1),
('ACCE', 'Accesorios', 'Bolsos materos, yerberos, azucareros y despolvilladores', 2, 1);

-- Productos
INSERT INTO dbo.product (code, name, description, price, stock, minimum_stock, created_by, category_id, is_active)
VALUES 
('T001', 'Termo Stanley 1.2L', 'Termo de acero inoxidable alta retención', 8500.00, 15, 2, 2, 1, 1),
('M001', 'Mate Torpedo Imperial', 'Calabaza forrada en cuero con virola de alpaca', 14500.00, 20, 3, 2, 1, 1),
('M002', 'Mate Camionero Cuero', 'Calabaza gruesa con base de 4 patas reforzadas', 11200.00, 25, 4, 2, 1, 1),
('M003', 'Mate de Vidrio Térmico', 'Vidrio templado forrado en eco-cuero negro', 6800.00, 15, 2, 2, 1, 1),
('T002', 'Termo Lumilagro Luminox 1L', 'Termo de acero inoxidable con pico cebador', 18900.00, 12, 2, 2, 1, 1),
('B001', 'Bombilla Pico de Loro Alpaca', 'Alpaca maciza cincelada con filtro ranurado', 4500.00, 30, 5, 2, 2, 1),
('B002', 'Bombilla Cuchara de Acero', 'Acero quirúrgico desmontable fácil limpieza', 3200.00, 40, 5, 2, 2, 1),
('B003', 'Bombilla Resorte Desarmable', 'Caño niquelado con resorte extractor', 2100.00, 18, 3, 2, 2, 1),
('Y001', 'Yerba Canarias Tradicional 1kg', 'Yerba uruguaya pura hoja sin palo', 4800.00, 50, 10, 2, 3, 1),
('Y002', 'Yerba Playadito 1kg', 'Yerba tradicional suave bajo polvo', 3600.00, 60, 10, 2, 3, 1),
('Y003', 'Yerba Rei Verde Compuesta 500g', 'Compuesta con cedrón, manzanilla y poleo', 2900.00, 25, 5, 2, 3, 1),
('A001', 'Bolso Matero de Cuero', 'Matera tipo morral con división acolchada', 22000.00, 8, 2, 2, 4, 1),
('A002', 'Set Yerbero y Azucarero Lata', 'Juego de latas con pico vertedor plástico', 5400.00, 22, 4, 2, 4, 1),
('A003', 'Despolvillador de Yerba', 'Filtro plástico para tamizar polvo de yerba', 2800.00, 35, 5, 2, 4, 1);
GO

-- =============================================================
-- 5. HISTORIAL DE 14 VENTAS CON DETALLES
-- =============================================================
DECLARE @Hoy DATETIME2 = GETDATE();

-- Venta 1
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00001', 19000.00, 'Completada', 'B', DATEADD(HOUR, -68, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (1, 2, 1, 14500.00), (1, 6, 1, 4500.00);

-- Venta 2
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00002', 8400.00, 'Completada', 'B', DATEADD(HOUR, -65, @Hoy), 3, 5, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (2, 9, 1, 4800.00), (2, 10, 1, 3600.00);

-- Venta 3
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00003', 22000.00, 'Completada', 'B', DATEADD(HOUR, -48, @Hoy), 3, 6, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (3, 12, 1, 22000.00);

-- Venta 4
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00004', 14400.00, 'Completada', 'B', DATEADD(HOUR, -45, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (4, 3, 1, 11200.00), (4, 7, 1, 3200.00);

-- Venta 5
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00005', 8200.00, 'Completada', 'B', DATEADD(HOUR, -42, @Hoy), 3, 7, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (5, 13, 1, 5400.00), (5, 14, 1, 2800.00);

-- Venta 6
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00006', 8500.00, 'Completada', 'B', DATEADD(HOUR, -26, @Hoy), 3, 8, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (6, 1, 1, 8500.00);

-- Venta 7
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00007', 5800.00, 'Completada', 'B', DATEADD(HOUR, -24, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (7, 11, 2, 2900.00);

-- Venta 8
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00008', 23400.00, 'Completada', 'B', DATEADD(HOUR, -22, @Hoy), 3, 5, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (8, 5, 1, 18900.00), (8, 6, 1, 4500.00);

-- Venta 9
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00009', 8900.00, 'Completada', 'B', DATEADD(HOUR, -20, @Hoy), 3, 6, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (9, 4, 1, 6800.00), (9, 8, 1, 2100.00);

-- Venta 10 (HOY)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00010', 14500.00, 'Completada', 'B', DATEADD(MINUTE, -260, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (10, 2, 1, 14500.00);

-- Venta 11 (HOY)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00011', 8000.00, 'Completada', 'B', DATEADD(MINUTE, -190, @Hoy), 3, 7, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (11, 7, 1, 3200.00), (11, 9, 1, 4800.00);

-- Venta 12 (HOY)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00012', 30100.00, 'Completada', 'B', DATEADD(MINUTE, -120, @Hoy), 3, 8, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (12, 12, 1, 22000.00), (12, 13, 1, 5400.00), (12, 10, 1, 3600.00);

-- Venta 13 (HOY)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00013', 18900.00, 'Completada', 'B', DATEADD(MINUTE, -60, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (13, 5, 1, 18900.00);

-- Venta 14 (HOY)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00014', 15700.00, 'Completada', 'B', DATEADD(MINUTE, -15, @Hoy), 3, 5, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (14, 3, 1, 11200.00), (14, 6, 1, 4500.00);
GO

-- =============================================================
-- 6. VERIFICACIÓN FINAL DE REGISTROS
-- =============================================================
SELECT 'Usuarios del Sistema' AS Entidad, COUNT(*) AS Cantidad FROM dbo.[user]
UNION ALL
SELECT 'Clientes', COUNT(*) FROM dbo.customer
UNION ALL
SELECT 'Métodos de Pago', COUNT(*) FROM dbo.payment_method
UNION ALL
SELECT 'Categorías', COUNT(*) FROM dbo.category
UNION ALL
SELECT 'Productos', COUNT(*) FROM dbo.product
UNION ALL
SELECT 'Ventas Totales', COUNT(*) FROM dbo.sale
UNION ALL
SELECT 'Detalles de Venta', COUNT(*) FROM dbo.sale_detail;
GO