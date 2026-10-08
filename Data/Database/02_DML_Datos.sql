-- =============================================================
-- SCRIPT DML: Carga de Datos Semilla (Catálogo y Ventas)
-- =============================================================

USE [Matiensos_db];
GO

-- 1. ROLES
INSERT INTO dbo.[role] (name, description, is_active)
VALUES 
('SuperAdmin', 'Control total y auditoría del sistema', 1),
('Admin', 'Administración general del negocio', 1),
('Vendedor', 'Módulo de facturación, caja y ventas', 1);
GO

-- 2. PERSONAS (Para Usuarios)
INSERT INTO dbo.person (first_name, last_name, dni, email, phone, is_active)
VALUES 
('Super', 'Admin', '10000001', 'superadmin@matiensos.com', '3794000001', 1),
('Admin', 'General', '10000002', 'admin@matiensos.com', '3794000002', 1),
('Lucas', 'Vendedor', '10000003', 'vendedor@matiensos.com', '3794000003', 1);
GO

-- 3. USUARIOS
INSERT INTO dbo.[user] (user_id, password, role_id)
VALUES 
(1, 'Super123!', 1),
(2, 'Admin123!', 2),
(3, 'Venta123!', 3);
GO

-- 4. PERSONAS (Para Clientes)
INSERT INTO dbo.person (first_name, last_name, dni, email, phone, is_active)
VALUES 
('Consumidor', 'Final', '99999999', 'cf@matiensos.com', '0000000000', 1),
('Carlos', 'Benítez', '34567890', 'carlos.benitez@gmail.com', '3794112233', 1),
('Mariana', 'Gómez', '38123456', 'mariana.gomez@hotmail.com', '3794223344', 1);
GO

-- 5. CLIENTES
INSERT INTO dbo.customer (customer_id, address)
VALUES 
(4, 'Venta en mostrador'), -- Consumidor final
(5, 'Av. 3 de Abril 1240, Corrientes'),
(6, 'Junín 850, Corrientes');
GO

-- 6. MÉTODOS DE PAGO
INSERT INTO dbo.payment_method (name, description, created_by, is_active)
VALUES 
('Efectivo', 'Pago de contado en caja', 2, 1),
('Transferencia', 'Transferencia bancaria / billetera virtual', 2, 1),
('Débito', 'Tarjeta de débito', 2, 1),
('Crédito', 'Tarjeta de crédito en un pago o cuotas', 2, 1);
GO

-- 7. CATEGORÍAS 
INSERT INTO dbo.category (code, name, description, created_by, is_active)
VALUES 
('MATE', 'Mates', 'Mates de calabaza, madera y cerámica', 2, 1),
('TERM', 'Termos', 'Termos de acero inoxidable y vidrio', 2, 1),
('BOMB', 'Bombillas', 'Bombillas de alpaca, acero inoxidable y resorte', 2, 1),
('YERB', 'Yerba Mate', 'Yerbas tradicionales, compuestas y barbacuá', 2, 1);
GO

-- 8. PRODUCTOS
INSERT INTO dbo.product (code, name, description, price, stock, minimum_stock, created_by, category_id, is_active)
VALUES 
('T001', 'Termo Stanley 1.2L', 'Termo de acero inoxidable alta retención', 8500.00, 15, 2, 2, 2, 1), -- Cat 2 (Termos)
('M001', 'Mate Torpedo Imperial', 'Calabaza forrada en cuero con virola de alpaca', 14500.00, 20, 3, 2, 1, 1), -- Cat 1 (Mates)
('B001', 'Bombilla Pico de Loro Alpaca', 'Alpaca maciza cincelada con filtro ranurado', 4500.00, 30, 5, 2, 3, 1), -- Cat 3 (Bombillas)
('Y001', 'Yerba Canarias Tradicional 1kg', 'Yerba uruguaya pura hoja sin palo', 4800.00, 50, 10, 2, 4, 1); -- Cat 4 (Yerbas)
GO

-- 9. VENTAS E HISTORIAL
DECLARE @Hoy DATETIME2 = GETDATE();

-- Venta 1 (Efectivo)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00001', 19000.00, 'Completada', 'B', DATEADD(HOUR, -68, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(1, 2, 1, 14500.00), -- Mate
(1, 3, 1, 4500.00);  -- Bombilla

-- Venta 2 (Transferencia)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00002', 9600.00, 'Completada', 'B', DATEADD(HOUR, -65, @Hoy), 3, 5, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (2, 4, 2, 4800.00); -- 2 Yerbas

-- Venta 3 (Tarjeta de Crédito)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00003', 8500.00, 'Completada', 'B', DATEADD(HOUR, -48, @Hoy), 3, 6, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (3, 1, 1, 8500.00); -- 1 Termo

-- Venta 4 (Débito)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00004', 14500.00, 'Completada', 'B', DATEADD(HOUR, -24, @Hoy), 3, 4, 3, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (4, 2, 1, 14500.00); -- 1 Mate

-- Venta 5 (Efectivo)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00005', 23000.00, 'Completada', 'B', DATEADD(HOUR, -12, @Hoy), 3, 5, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(5, 1, 1, 8500.00), -- 1 Termo
(5, 2, 1, 14500.00); -- 1 Mate

-- Venta 6 (Transferencia - Combo Mate Completo)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00006', 32300.00, 'Completada', 'B', DATEADD(HOUR, -5, @Hoy), 3, 6, 2, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES 
(6, 1, 1, 8500.00), -- Termo
(6, 2, 1, 14500.00), -- Mate
(6, 3, 1, 4500.00), -- Bombilla
(6, 4, 1, 4800.00); -- Yerba

-- Venta 7 (Efectivo)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00007', 9000.00, 'Completada', 'B', DATEADD(HOUR, -2, @Hoy), 3, 4, 1, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (7, 3, 2, 4500.00); -- 2 Bombillas

-- Venta 8 (Crédito - Cancelada)
INSERT INTO dbo.sale (code, total_amount, status, voucher_type, created_at, user_id, customer_id, payment_method_id, is_active)
VALUES ('B-2026-00008', 4800.00, 'Cancelada', 'B', DATEADD(HOUR, -1, @Hoy), 3, 4, 4, 1);
INSERT INTO dbo.sale_detail (sale_id, product_id, quantity, unit_price)
VALUES (8, 4, 1, 4800.00); -- 1 Yerba (Cancelada)

GO
