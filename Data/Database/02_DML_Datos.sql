-- =============================================================
-- SCRIPT DML: Carga de Datos Semilla Representativos (Catálogo y Ventas)
-- Sistema: Matiensos — Local Comercial de Artículos Materos
-- Motor: SQL Server (Transact-SQL)
-- =============================================================

USE [Matiensos_db];
GO

-- =============================================================
-- 0. REINICIO PREVENTIVO (Si ya existen datos, limpia y reinicia contadores)
-- =============================================================
IF EXISTS (SELECT 1 FROM dbo.person)
BEGIN
    DELETE FROM dbo.sale_detail;
    DELETE FROM dbo.sale;
    DELETE FROM dbo.product;
    DELETE FROM dbo.category;
    DELETE FROM dbo.payment_method;
    DELETE FROM dbo.customer;
    DELETE FROM dbo.[user];
    DELETE FROM dbo.person;
    DELETE FROM dbo.[role];

    DBCC CHECKIDENT ('dbo.person', RESEED, 0);
    DBCC CHECKIDENT ('dbo.[role]', RESEED, 0);
    DBCC CHECKIDENT ('dbo.category', RESEED, 0);
    DBCC CHECKIDENT ('dbo.product', RESEED, 0);
    DBCC CHECKIDENT ('dbo.payment_method', RESEED, 0);
    DBCC CHECKIDENT ('dbo.sale', RESEED, 0);
    DBCC CHECKIDENT ('dbo.sale_detail', RESEED, 0);
END;
GO

-- =============================================================
-- 1. ROLES DEL SISTEMA (IDs 1, 2, 3)
-- =============================================================
INSERT INTO dbo.[role] (name, description, is_active)
VALUES 
('SuperAdmin', 'Control total y auditoría global del sistema', 1),
('Admin', 'Administración comercial del negocio, catálogo y precios', 1),
('Vendedor', 'Módulo de facturación, caja, clientes y ventas', 1);
GO

-- =============================================================
-- 2. PERSONAS PARA USUARIOS / EMPLEADOS (IDs 1 al 5)
-- =============================================================
INSERT INTO dbo.person (first_name, last_name, dni, email, phone, is_active)
VALUES 
('Super', 'Admin', '10000001', 'superadmin@matiensos.com', '3794000001', 1),
('Admin', 'General', '10000002', 'admin@matiensos.com', '3794000002', 1),
('Lucas', 'González', '10000003', 'vendedor@matiensos.com', '3794000003', 1),
('Sofía', 'Martínez', '10000004', 'sofia.ventas@matiensos.com', '3794000004', 1),
('Mateo', 'Romero', '10000005', 'mateo.admin@matiensos.com', '3794000005', 1);
GO

-- =============================================================
-- 3. USUARIOS DEL SISTEMA (Vinculados a Personas 1 al 5)
-- =============================================================
INSERT INTO dbo.[user] (user_id, password, role_id)
VALUES 
(1, 'Super123!', 1), -- SuperAdmin
(2, 'Admin123!', 2), -- Admin General
(3, 'Venta123!', 3), -- Vendedor Lucas (Turno Mañana)
(4, 'Venta123!', 3), -- Vendedora Sofía (Turno Tarde)
(5, 'Admin123!', 2); -- Admin Mateo (Encargado)
GO

-- =============================================================
-- 4. PERSONAS PARA CLIENTES (IDs 6 al 18)
-- =============================================================
INSERT INTO dbo.person (first_name, last_name, dni, email, phone, is_active)
VALUES 
('Consumidor', 'Final', '99999999', 'cf@matiensos.com', '0000000000', 1),
('Carlos', 'Benítez', '34567890', 'carlos.benitez@gmail.com', '3794112233', 1),
('Mariana', 'Gómez', '38123456', 'mariana.gomez@hotmail.com', '3794223344', 1),
('Rodrigo', 'Valenzuela', '29876543', 'rvalenzuela@gmail.com', '3794334455', 1),
('Florencia', 'Romero', '41234567', 'flor.romero@yahoo.com', '3794445566', 1),
('Joaquín', 'Escalante', '36789123', 'joaquin.es@gmail.com', '3794556677', 1),
('Camila', 'Fernández', '40112233', 'camila.fer@gmail.com', '3794667788', 1),
('Esteban', 'Aguirre', '28456123', 'esteban.aguirre@outlook.com', '3624123456', 1),
('Valentina', 'Almirón', '42987112', 'valen.almiron@gmail.com', '3794778899', 1),
('Lucas', 'Maidana', '35123987', 'lucas.maidana@gmail.com', '3794889900', 1),
('Lucía', 'Cardozo', '39445566', 'lucia.cardozo@yahoo.com.ar', '3624890123', 1),
('Matías', 'Acosta', '33667788', 'matias.acosta@gmail.com', '3794990011', 1),
('Andrea', 'Duarte', '37889900', 'andrea.duarte@hotmail.com', '3794120033', 1);
GO

-- =============================================================
-- 5. CLIENTES (Vinculados a Personas 6 al 18)
-- =============================================================
INSERT INTO dbo.customer (customer_id, address)
VALUES 
(6, 'Venta en mostrador'),
(7, 'Av. 3 de Abril 1240, Corrientes'),
(8, 'Junín 850, Corrientes'),
(9, 'Pellegrini 420, Corrientes'),
(10, 'San Martín 1560, Corrientes'),
(11, 'Av. Ferré 2150, Corrientes'),
(12, 'Hipólito Yrigoyen 930, Corrientes'),
(13, 'Av. Sarmiento 450, Resistencia'),
(14, 'Córdoba 1120, Corrientes'),
(15, '9 de Julio 780, Corrientes'),
(16, 'Av. Castelli 890, Resistencia'),
(17, 'Mendoza 640, Corrientes'),
(18, 'Catamarca 1420, Corrientes');
GO

-- =============================================================
-- 6. MÉTODOS DE PAGO (IDs 1 al 5)
-- =============================================================
INSERT INTO dbo.payment_method (name, description, created_by, is_active)
VALUES 
('Efectivo', 'Pago en efectivo de contado en caja', 2, 1),
('Transferencia', 'Transferencia bancaria / CBU / CVU / Billeteras virtuales', 2, 1),
('Débito', 'Tarjeta de débito (Visa / Mastercard Débito)', 2, 1),
('Crédito', 'Tarjeta de crédito en un pago o en cuotas', 2, 1),
('Mercado Pago', 'Cobro digital mediante QR y billetera Mercado Pago', 2, 1);
GO

-- =============================================================
-- 7. CATEGORÍAS (IDs 1 al 7 - Códigos CHAR(4))
-- =============================================================
INSERT INTO dbo.category (code, name, description, created_by, is_active)
VALUES 
('MATE', 'Mates', 'Mates imperiales, camioneros, torpedo, térmicos y algarrobo', 2, 1),
('TERM', 'Termos', 'Termos de acero inoxidable, media manija y repuestos térmicos', 2, 1),
('BOMB', 'Bombillas', 'Bombillas de alpaca cincelada, acero quirúrgico y resorte desarmable', 2, 1),
('YERB', 'Yerba Mate', 'Yerbas tradicionales con palo, sin palo, compuestas y barbacuá', 2, 1),
('ACCE', 'Accesorios', 'Despolvilladores, limpiadores, cepillos, tapones y yerberas', 2, 1),
('BOLS', 'Bolsos y Materas', 'Bolsos materos de cuero, canastas rígidas y mochilas materas', 2, 1);
GO

-- =============================================================
-- 8. PRODUCTOS (Catálogo completo de 28 productos)
-- =============================================================
INSERT INTO dbo.product (code, name, description, price, stock, minimum_stock, created_by, category_id, is_active)
VALUES 
-- Mates (category_id = 1)
('M001', 'Mate Torpedo Uruguayo Cuero', 'Calabaza seleccionada forrada en cuero vacuno con costura artesanal', 16500.00, 18, 4, 2, 1, 1),
('M002', 'Mate Imperial Guarda Pampa Alpaca', 'Calabaza gruesa pulida con virola labrada en alpaca y fleje pampa', 24900.00, 12, 3, 2, 1, 1),
('M003', 'Mate Camionero Cuero Vaqueta', 'Base de 4 patas reforzadas, boca ancha, ideal para cebadas largas', 14200.00, 25, 5, 2, 1, 1),
('M004', 'Mate Pampa XL Térmico Negro', 'PVC térmico libre de BPA, no genera hongos ni necesita curado', 9800.00, 30, 5, 2, 1, 1),
('M005', 'Mate Imperial Cincelado Especial', 'Edición de lujo cincelada a mano con virola ancha de alpaca pura', 32000.00, 2, 4, 2, 1, 1), -- ALERTA STOCK
('M006', 'Mate de Algarrobo Torneado Clásico', 'Madera noble estacionada con terminación rústica encerada', 6800.00, 15, 3, 2, 1, 1),

-- Termos (category_id = 2)
('T001', 'Termo Stanley Classic 1.2L Verde', 'Acero inoxidable 18/8 doble pared con aislamiento al vacío', 82000.00, 10, 2, 2, 2, 1),
('T002', 'Termo Lumilagro Luminox 1L Acero', 'Acero de alta resistencia con pico vertedor Matero tradicional', 24500.00, 14, 3, 2, 2, 1),
('T003', 'Termo Stanley Adventure 1L Polar', 'Edición liviana y compacta para transporte diario en mochila', 74000.00, 1, 3, 2, 2, 1), -- ALERTA STOCK
('T004', 'Termo Coleman 1.2L Pico Cebador', 'Térmico de acero con manija lateral rebatible y pico 360 grados', 48500.00, 8, 2, 2, 2, 1),
('T005', 'Termo Termolar R-Evolution 1L Bomba', 'Termo a bomba en acero inoxidable de excelente precisión al servir', 36000.00, 9, 2, 2, 2, 1),

-- Bombillas (category_id = 3)
('B001', 'Bombilla Pico de Loro Alpaca Labrada', 'Alpaca maciza con ranuras milimétricas y caño curvo ergonómico', 5600.00, 35, 6, 2, 3, 1),
('B002', 'Bombilla Cuchara Acero Quirúrgico', 'Acero inoxidable 304 pulido espejo, fácil desmonte y lavado', 3900.00, 40, 5, 2, 3, 1),
('B003', 'Bombilla Resorte Desarmable Niquel', 'Filtro de resorte desmontable con varilla central de purga', 2600.00, 28, 4, 2, 3, 1),
('B004', 'Bombilla Chata Uruguaya Ranurada', 'Pico ancho tipo pala especial para yerba uruguaya tipo Canarias', 4800.00, 22, 4, 2, 3, 1),

-- Yerba Mate (category_id = 4)
('Y001', 'Yerba Canarias Tradicional 1kg', 'Yerba uruguaya pura hoja sin palo con molienda fina y sabor intenso', 5200.00, 65, 10, 2, 4, 1),
('Y002', 'Yerba Playadito Con Palo 1kg', 'Tradicional correntina elaborada en Colonia Liebig, suave y duradera', 3900.00, 90, 15, 2, 4, 1),
('Y003', 'Yerba Rosamonte Selección Especial 1kg', 'Estacionamiento natural de 24 meses, blend robusto para conocedores', 4600.00, 45, 8, 2, 4, 1),
('Y004', 'Yerba Baldo Despalada 1kg', 'Yerba de origen brasileño para consumo uruguayo con molienda pura', 5400.00, 38, 8, 2, 4, 1),
('Y005', 'Yerba Mañanita Suave 1kg', 'Elaboración con bajo porcentaje de polvillo para cebadas ligeras', 3600.00, 50, 10, 2, 4, 1),
('Y006', 'Yerba CBSé Hierbas Serranas 500g', 'Compuesta con menta, poleo y peperina cordobesa refrescante', 2400.00, 40, 6, 2, 4, 1),

-- Accesorios (category_id = 5)
('A001', 'Set Yerbero y Azucarero con Pico', 'Juego de dos latas forradas en eco-cuero con vertedor plástico dosificador', 6900.00, 26, 5, 2, 5, 1),
('A002', 'Despolvillador de Yerba Plástico', 'Tamizador centrífugo para separar polvillo y evitar acidez', 3400.00, 32, 5, 2, 5, 1),
('A003', 'Cepillo Limpiador de Bombillas', 'Cerdas de nylon resistentes con mango flexible de acero inoxidable', 1200.00, 45, 8, 2, 5, 1),

-- Bolsos y Materas (category_id = 6)
('L001', 'Bolso Matero Morral de Cuero Genuino', 'Cuero curtido vegetal con compartimentos acolchados para termo y mate', 28500.00, 8, 2, 2, 6, 1),
('L002', 'Matera Canasta Rígida Eco-Cuero', 'Estructura reforzada con manija rebatible y base antideslizante', 19800.00, 12, 3, 2, 6, 1),

-- Sets Materos (category_id = 7)
('S001', 'Set Matero Río de la Plata Completo', 'Kit que incluye: Matera canasta + Termo acero + Mate torpedo + Bombilla', 46500.00, 6, 2, 2, 7, 1),
('S002', 'Set Matero Viajero Cuero Suela', 'Bolso cilíndrico en cuero suela con termo lumilagro y mate de calabaza', 38900.00, 1, 2, 2, 7, 1); -- ALERTA STOCK
GO

-- =============================================================
-- 9. HISTORIAL DE VENTAS Y DETALLES (28 Ventas)
-- =============================================================
DECLARE @Hoy DATETIME2 = GETDATE();

-- Venta 1 (Hace 38 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00001', 26000.00, 'Completada', 'B', DATEADD(DAY, -38, DATEADD(HOUR, -2, @Hoy)), 3, 7, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(1, 1, 1, 16500.00), -- Mate Torpedo
(1, 12, 1, 5600.00), -- Bombilla Alpaca
(1, 17, 1, 3900.00); -- Playadito 1kg

-- Venta 2 (Hace 35 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00002', 10400.00, 'Completada', 'B', DATEADD(DAY, -35, DATEADD(HOUR, -5, @Hoy)), 4, 6, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (2, 16, 2, 5200.00); -- 2 Canarias 1kg

-- Venta 3 (Hace 30 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00001', 82000.00, 'Completada', 'B', DATEADD(DAY, -30, DATEADD(HOUR, -3, @Hoy)), 3, 13, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (3, 7, 1, 82000.00); -- Termo Stanley 1.2L

-- Venta 4 (Hace 26 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00003', 13700.00, 'Completada', 'B', DATEADD(DAY, -26, DATEADD(HOUR, -4, @Hoy)), 3, 8, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(4, 4, 1, 9800.00), -- Mate Pampa XL
(4, 13, 1, 3900.00); -- Bombilla Cuchara

-- Venta 5 (Hace 22 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00004', 46500.00, 'Completada', 'B', DATEADD(DAY, -22, DATEADD(HOUR, -6, @Hoy)), 4, 9, 5, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(5, 8, 1, 24500.00), -- Termo Lumilagro
(5, 3, 1, 14200.00), -- Mate Camionero
(5, 17, 2, 3900.00);  -- 2 Playadito 1kg

-- Venta 6 (Hace 18 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00005', 10000.00, 'Completada', 'B', DATEADD(DAY, -18, DATEADD(HOUR, -1, @Hoy)), 3, 6, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(6, 14, 2, 2600.00), -- 2 Bombillas Resorte
(6, 21, 2, 2400.00); -- 2 CBSé Hierbas

-- Venta 7 (Hace 14 días - Octubre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00001', 14900.00, 'Completada', 'B', DATEADD(DAY, -14, DATEADD(HOUR, -3, @Hoy)), 4, 10, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(7, 22, 1, 6900.00), -- Set Yerbero/Azucarero
(7, 23, 1, 3400.00), -- Despolvillador
(7, 18, 1, 4600.00); -- Rosamonte Especial

-- Venta 8 (Hace 10 días - Octubre - Cancelada)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00006', 24900.00, 'Cancelada', 'B', DATEADD(DAY, -10, DATEADD(HOUR, -5, @Hoy)), 3, 11, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (8, 2, 1, 24900.00); -- Mate Imperial Guarda Pampa

-- Venta 9 (Hace 7 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00007', 14600.00, 'Completada', 'B', DATEADD(DAY, -7, DATEADD(HOUR, -2, @Hoy)), 3, 12, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(9, 6, 1, 6800.00),  -- Mate Algarrobo
(9, 13, 1, 3900.00), -- Bombilla Cuchara
(9, 17, 1, 3900.00); -- Playadito 1kg

-- Venta 10 (Hace 6 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00008', 36300.00, 'Completada', 'B', DATEADD(DAY, -6, DATEADD(HOUR, -4, @Hoy)), 4, 14, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(10, 26, 1, 19800.00), -- Matera Canasta Eco-Cuero
(10, 1, 1, 16500.00);  -- Mate Torpedo

-- Venta 11 (Hace 5 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00009', 10800.00, 'Completada', 'B', DATEADD(DAY, -5, DATEADD(HOUR, -1, @Hoy)), 3, 6, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (11, 20, 3, 3600.00); -- 3 Mañanita 1kg

-- Venta 12 (Hace 5 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00002', 46500.00, 'Completada', 'B', DATEADD(DAY, -5, DATEADD(HOUR, -6, @Hoy)), 2, 13, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (12, 27, 1, 46500.00); -- Set Río de la Plata Completo

-- Venta 13 (Hace 4 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00010', 58700.00, 'Completada', 'B', DATEADD(DAY, -4, DATEADD(HOUR, -3, @Hoy)), 4, 15, 5, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(13, 10, 1, 48500.00), -- Termo Coleman
(13, 15, 1, 4800.00),  -- Bombilla Chata
(13, 19, 1, 5400.00);  -- Baldo 1kg

-- Venta 14 (Hace 4 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00011', 10300.00, 'Completada', 'B', DATEADD(DAY, -4, DATEADD(HOUR, -7, @Hoy)), 3, 7, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(14, 16, 1, 5200.00), -- Canarias 1kg
(14, 17, 1, 3900.00), -- Playadito 1kg
(14, 24, 1, 1200.00); -- Cepillo Limpiador

-- Venta 15 (Hace 3 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00012', 30500.00, 'Completada', 'B', DATEADD(DAY, -3, DATEADD(HOUR, -2, @Hoy)), 4, 16, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(15, 2, 1, 24900.00), -- Mate Imperial Guarda Pampa
(15, 12, 1, 5600.00); -- Bombilla Alpaca

-- Venta 16 (Hace 3 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00013', 45800.00, 'Completada', 'B', DATEADD(DAY, -3, DATEADD(HOUR, -5, @Hoy)), 3, 17, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(16, 11, 1, 36000.00), -- Termo Termolar 1L
(16, 4, 1, 9800.00);   -- Mate Pampa XL

-- Venta 17 (Hace 2 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00014', 9200.00, 'Completada', 'B', DATEADD(DAY, -2, DATEADD(HOUR, -1, @Hoy)), 4, 6, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (17, 18, 2, 4600.00); -- 2 Rosamonte Especial

-- Venta 18 (Hace 2 días - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00015', 26700.00, 'Completada', 'B', DATEADD(DAY, -2, DATEADD(HOUR, -4, @Hoy)), 3, 18, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(18, 3, 1, 14200.00), -- Mate Camionero
(18, 12, 1, 5600.00), -- Bombilla Alpaca
(18, 22, 1, 6900.00); -- Set Yerbero/Azucarero

-- Venta 19 (Hace 2 días - Noviembre - Pendiente)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('A -2026-00002', 28500.00, 'Pendiente', 'B', DATEADD(DAY, -2, DATEADD(HOUR, -7, @Hoy)), 4, 8, 5, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (19, 25, 1, 28500.00); -- Bolso Matero Cuero Morral

-- Venta 20 (Ayer por la mañana - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00016', 6300.00, 'Completada', 'B', DATEADD(DAY, -1, DATEADD(HOUR, -2, @Hoy)), 3, 6, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(20, 13, 1, 3900.00), -- Bombilla Cuchara
(20, 24, 2, 1200.00); -- 2 Cepillos Limpiadores

-- Venta 21 (Ayer al mediodía - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00017', 46600.00, 'Completada', 'B', DATEADD(DAY, -1, DATEADD(HOUR, -5, @Hoy)), 3, 9, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(21, 8, 1, 24500.00), -- Termo Lumilagro
(21, 1, 1, 16500.00), -- Mate Torpedo
(21, 12, 1, 5600.00); -- Bombilla Alpaca

-- Venta 22 (Ayer por la tarde - Noviembre - Cancelada)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00018', 5200.00, 'Cancelada', 'B', DATEADD(DAY, -1, DATEADD(HOUR, -7, @Hoy)), 3, 6, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (22, 16, 1, 5200.00); -- Canarias 1kg

-- Venta 23 (Ayer por la tarde - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00019', 53400.00, 'Completada', 'B', DATEADD(DAY, -1, DATEADD(HOUR, -9, @Hoy)), 4, 10, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(23, 25, 1, 28500.00), -- Bolso Matero Cuero
(23, 2, 1, 24900.00);  -- Mate Imperial Alpaca

-- Venta 24 (Ayer al anochecer - Noviembre)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00020', 16000.00, 'Completada', 'B', DATEADD(DAY, -1, DATEADD(HOUR, -11, @Hoy)), 4, 11, 5, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(24, 4, 1, 9800.00),  -- Mate Pampa XL
(24, 14, 1, 2600.00), -- Bombilla Resorte
(24, 20, 1, 3600.00); -- Mañanita 1kg

-- Venta 25 (HOY - Hace 5 horas)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00021', 14600.00, 'Completada', 'B', DATEADD(MINUTE, -300, @Hoy), 3, 12, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(25, 6, 1, 6800.00),  -- Mate Algarrobo
(25, 13, 1, 3900.00), -- Bombilla Cuchara
(25, 17, 1, 3900.00); -- Playadito 1kg

-- Venta 26 (HOY - Hace 3 horas)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00022', 27900.00, 'Completada', 'B', DATEADD(MINUTE, -180, @Hoy), 3, 14, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(26, 8, 1, 24500.00), -- Termo Lumilagro
(26, 23, 1, 3400.00); -- Despolvillador

-- Venta 27 (HOY - Hace 1 hora)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00023', 11600.00, 'Completada', 'B', DATEADD(MINUTE, -60, @Hoy), 4, 6, 5, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(27, 16, 2, 5200.00), -- 2 Canarias 1kg
(27, 24, 1, 1200.00); -- 1 Cepillo Limpiador

-- Venta 28 (HOY - Hace 15 minutos)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00024', 22100.00, 'Completada', 'B', DATEADD(MINUTE, -15, @Hoy), 4, 15, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(28, 1, 1, 16500.00), -- Mate Torpedo
(28, 12, 1, 5600.00); -- Bombilla Alpaca
GO

-- =============================================================
-- 10. RESUMEN DE CONTROL DE MINADO DE DATOS
-- =============================================================
SELECT 'Roles de Usuario' AS Entidad, COUNT(*) AS Total FROM dbo.[role]
UNION ALL
SELECT 'Usuarios del Sistema', COUNT(*) FROM dbo.[user]
UNION ALL
SELECT 'Clientes Registrados', COUNT(*) FROM dbo.customer
UNION ALL
SELECT 'Métodos de Pago Habilitados', COUNT(*) FROM dbo.payment_method
UNION ALL
SELECT 'Categorías de Catálogo', COUNT(*) FROM dbo.category
UNION ALL
SELECT 'Productos en Inventario', COUNT(*) FROM dbo.product
UNION ALL
SELECT 'Productos con Alerta de Stock Mínimo', COUNT(*) FROM dbo.product WHERE stock <= minimum_stock
UNION ALL
SELECT 'Ventas Totales Registradas', COUNT(*) FROM dbo.sale
UNION ALL
SELECT 'Líneas de Detalle de Venta', COUNT(*) FROM dbo.sale_detail
UNION ALL
SELECT 'Ventas del Día de Hoy', COUNT(*) FROM dbo.sale WHERE CAST(created_at AS DATE) = CAST(GETDATE() AS DATE);
GO
