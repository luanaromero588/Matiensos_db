-- =============================================================
-- SCRIPT DDL: Definición de Tablas y Restricciones (Constraints)
-- Motor: SQL Server (Transact-SQL) / ANSI SQL
-- =============================================================

/**
CREATE DATABASE [Matiensos_db];
GO
**/

USE [Matiensos_db];
GO

-- 1. TABLA: PERSONA
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

    CONSTRAINT CK_person_dni CHECK (dni NOT LIKE '%[^0-9]%' AND LEN(dni) BETWEEN 7 AND 8),
    CONSTRAINT CK_person_email CHECK (email LIKE '%_@__%.__%')
);
GO

-- 2. TABLA: ROL
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
    CONSTRAINT UQ_role_name UNIQUE (name),
    CONSTRAINT CK_role_name_not_empty CHECK (LTRIM(RTRIM(name)) <> '')
);
GO

-- 3. TABLA: USUARIO (Vendedor/Admin)
CREATE TABLE dbo.[user] (
    user_id INT NOT NULL,
    password VARCHAR(255) NOT NULL,
    role_id INT NOT NULL,
    
    CONSTRAINT PK_user PRIMARY KEY CLUSTERED (user_id),
    CONSTRAINT FK_user_person FOREIGN KEY (user_id) REFERENCES dbo.person(id),
    CONSTRAINT FK_user_role FOREIGN KEY (role_id) REFERENCES dbo.[role](id),
    CONSTRAINT CK_user_pwd_length CHECK (LEN(password) >= 6)
);
GO

-- 4. TABLA: CLIENTE
CREATE TABLE dbo.customer (
    customer_id INT NOT NULL,
    address VARCHAR(255) NULL,
    
    CONSTRAINT PK_customer PRIMARY KEY CLUSTERED (customer_id),
    CONSTRAINT FK_customer_person FOREIGN KEY (customer_id) REFERENCES dbo.person(id)
);
GO

-- 5. TABLA: CATEGORIA
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
    CONSTRAINT UQ_category_name UNIQUE (name),
    CONSTRAINT FK_category_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_category_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_category_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id)
);
GO

-- 6. TABLA: PRODUCTO
CREATE TABLE dbo.product (
    id INT IDENTITY(1,1) NOT NULL,
    code CHAR(4) NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(255) NULL,
    price DECIMAL(12,2) NOT NULL,
    stock INT NOT NULL,
    minimum_stock INT NOT NULL,
    category_id INT NOT NULL,

    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NOT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,

    CONSTRAINT PK_product PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_product_code UNIQUE (code),
    CONSTRAINT UQ_product_name UNIQUE (name),
    CONSTRAINT FK_product_category FOREIGN KEY (category_id) REFERENCES dbo.category(id),
    CONSTRAINT FK_product_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_product_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_product_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id),

    CONSTRAINT CK_product_price CHECK (price > 0),
    CONSTRAINT CK_product_stock CHECK (stock >= 0),
    CONSTRAINT CK_product_min_stock CHECK (minimum_stock >= 0)
);
GO

-- 7. TABLA: METODO DE PAGO
CREATE TABLE dbo.payment_method (
    id INT IDENTITY(1,1) NOT NULL,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(255) NULL,

    created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
    updated_at DATETIME2 NULL,
    deleted_at DATETIME2 NULL,
    created_by INT NOT NULL,
    updated_by INT NULL,
    deleted_by INT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    
    CONSTRAINT PK_payment_method PRIMARY KEY CLUSTERED (id),
    CONSTRAINT UQ_payment_method_name UNIQUE (name),
    CONSTRAINT FK_payment_created_by FOREIGN KEY (created_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_payment_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_payment_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id)
);
GO

-- 8. TABLA: VENTA
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
    CONSTRAINT FK_sale_user FOREIGN KEY (user_id) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_sale_updated_by FOREIGN KEY (updated_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_sale_deleted_by FOREIGN KEY (deleted_by) REFERENCES dbo.[user](user_id),
    CONSTRAINT FK_sale_customer FOREIGN KEY (customer_id) REFERENCES dbo.customer(customer_id),
    CONSTRAINT FK_sale_payment FOREIGN KEY (payment_method_id) REFERENCES dbo.payment_method(id),
    
    CONSTRAINT CK_sale_total CHECK (total_amount >= 0),
    CONSTRAINT CK_sale_status CHECK (status IN ('Completada', 'Cancelada', 'Pendiente')),
    CONSTRAINT CK_sale_voucher CHECK (voucher_type IN ('A', 'B', 'C', 'X'))
);
GO

-- 9. TABLA: DETALLE DE VENTA
CREATE TABLE dbo.sale_detail (
    id INT IDENTITY(1,1) NOT NULL,
    sale_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(12,2) NOT NULL,

    CONSTRAINT PK_sale_detail PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_saledetail_sale FOREIGN KEY (sale_id) REFERENCES dbo.sale(id),
    CONSTRAINT FK_saledetail_product FOREIGN KEY (product_id) REFERENCES dbo.product(id),
    
    CONSTRAINT CK_saledetail_quantity CHECK (quantity > 0),
    CONSTRAINT CK_saledetail_price CHECK (unit_price >= 0)
);
GO
