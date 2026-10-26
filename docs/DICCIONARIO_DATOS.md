# Diccionario de Datos

> **Proyecto:** Sistema de Gestión de Ventas — Matiensos  
> **Base de Datos:** `Matiensos_db`  
> **Motor:** Microsoft SQL Server (Transact-SQL)  

---

## 1. Introducción

El presente documento constituye el **Diccionario de Datos** oficial
del sistema **Matiensos**. Describe en detalle la estructura física y
semántica de cada una de las 9 tablas que conforman la base de datos
relacional (`Matiensos_db`), especificando tipos de datos, nulabilidad,
claves, restricciones de integridad y su significado de negocio.

---

## 2. Índice de Tablas

1. [**`dbo.person`**](#1-tabla-dboperson): Datos generales de personas físicas.
2. [**`dbo.role`**](#2-tabla-dborole): Catálogo de roles de seguridad.
3. [**`dbo.user`**](#3-tabla-dbouser): Cuentas de acceso de empleados.
4. [**`dbo.customer`**](#4-tabla-dbocustomer): Información comercial de clientes.
5. [**`dbo.category`**](#5-tabla-dbocategory): Clasificación de productos.
6. [**`dbo.product`**](#6-tabla-dboproduct): Catálogo de artículos e inventario.
7. [**`dbo.payment_method`**](#7-tabla-dbopayment_method): Medios de cobro aceptados.
8. [**`dbo.sale`**](#8-tabla-dbosale): Cabecera de transacciones de venta.
9. [**`dbo.sale_detail`**](#9-tabla-dbosale_detail): Detalle de ítems por venta.

---

## 3. Especificación Detallada por Tabla

---

### 1. Tabla: `dbo.person`
Centraliza los datos de identidad de todas las personas físicas que
interactúan con el sistema (empleados y clientes).

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental de la persona. |
| `first_name` | `VARCHAR(100)` | Sí | — | Nombre(s) de la persona. |
| `last_name` | `VARCHAR(100)` | Sí | — | Apellido(s) de la persona. |
| `dni` | `VARCHAR(8)` | No | `UQ`, `CK_person_dni` | DNI numérico (7 u 8 dígitos). Único en el sistema. |
| `email` | `VARCHAR(255)` | Sí | `UQ`, `CK_person_email` | Correo electrónico de contacto con formato válido. |
| `phone` | `VARCHAR(15)` | Sí | — | Teléfono de contacto de la persona. |
| `created_at` | `DATETIME2` | No | `DEFAULT GETDATE()` | Fecha y hora de alta del registro. |
| `updated_at` | `DATETIME2` | Sí | — | Fecha y hora de la última modificación. |
| `deleted_at` | `DATETIME2` | Sí | — | Fecha y hora de baja lógica (*Soft Delete*). |
| `created_by` | `INT` | Sí | — | ID del usuario que registró a la persona. |
| `updated_by` | `INT` | Sí | — | ID del usuario que realizó la última edición. |
| `deleted_by` | `INT` | Sí | — | ID del usuario que aplicó la baja lógica. |
| `is_active` | `BIT` | No | `DEFAULT 1` | Estado de actividad (1: Activo, 0: Baja lógica). |

---

### 2. Tabla: `dbo.role`
Almacena los perfiles de seguridad jerárquicos (*SuperAdmin*, *Administrador*,
*Vendedor*) que regulan los permisos del sistema.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental del rol. |
| `name` | `VARCHAR(100)` | No | `UQ`, `CK_role_name_not_empty` | Denominación única del rol (no vacío). |
| `description` | `VARCHAR(255)` | Sí | — | Detalle de las responsabilidades del rol. |
| `created_at` | `DATETIME2` | No | `DEFAULT GETDATE()` | Fecha y hora de creación del rol. |
| `updated_at` | `DATETIME2` | Sí | — | Fecha y hora de última modificación. |
| `deleted_at` | `DATETIME2` | Sí | — | Fecha y hora de baja lógica. |
| `created_by` | `INT` | Sí | — | ID del usuario creador. |
| `updated_by` | `INT` | Sí | — | ID del usuario que modificó el rol. |
| `deleted_by` | `INT` | Sí | — | ID del usuario que desactivó el rol. |
| `is_active` | `BIT` | No | `DEFAULT 1` | Estado del rol (1: Habilitado, 0: Deshabilitado). |

---

### 3. Tabla: `dbo.user`
Especialización de `person` que almacena las credenciales de acceso
y el rol asignado a cada empleado.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `user_id` | `INT` | No | `PK`, `FK -> person(id)` | ID del usuario, vinculado 1:1 con `person`. |
| `password` | `VARCHAR(255)` | No | `CK_user_pwd_length` | Contraseña cifrada (longitud mínima 6 caracteres). |
| `role_id` | `INT` | No | `FK -> role(id)` | Identificador del rol asignado al usuario. |

---

### 4. Tabla: `dbo.customer`
Especialización de `person` que representa a los clientes comerciales,
almacenando su domicilio para facturación.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `customer_id` | `INT` | No | `PK`, `FK -> person(id)` | ID del cliente, vinculado 1:1 con `person`. |
| `address` | `VARCHAR(255)` | Sí | — | Domicilio de residencia o facturación del cliente. |

---

### 5. Tabla: `dbo.category`
Clasificación de productos que organiza el catálogo de artículos
materos y accesorios.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental de la categoría. |
| `code` | `CHAR(4)` | No | `UQ` | Código alfanumérico único e inmutable (4 caracteres). |
| `name` | `VARCHAR(100)` | No | `UQ` | Nombre descriptivo de la categoría (único). |
| `description` | `VARCHAR(255)` | Sí | — | Detalle adicional de los productos que agrupa. |
| `created_at` | `DATETIME2` | No | `DEFAULT GETDATE()` | Fecha y hora de alta de la categoría. |
| `updated_at` | `DATETIME2` | Sí | — | Fecha y hora de última modificación. |
| `deleted_at` | `DATETIME2` | Sí | — | Fecha y hora de baja lógica. |
| `created_by` | `INT` | No | `FK -> user(user_id)` | Usuario que dio de alta la categoría. |
| `updated_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que realizó la última edición. |
| `deleted_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que aplicó la baja lógica. |
| `is_active` | `BIT` | No | `DEFAULT 1` | Estado (1: Activa, 0: Inactiva para selección). |

---

### 6. Tabla: `dbo.product`
Catálogo maestro de artículos comerciales con control de precios
y umbrales de stock físico.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental del producto. |
| `code` | `CHAR(4)` | No | `UQ` | Código alfanumérico único de 4 caracteres. |
| `name` | `VARCHAR(100)` | No | `UQ` | Nombre descriptivo del producto (único). |
| `description` | `VARCHAR(255)` | Sí | — | Características y detalles del producto. |
| `price` | `DECIMAL(12,2)` | No | `CK_product_price` | Precio unitario de venta (estrictamente `> 0`). |
| `stock` | `INT` | No | `CK_product_stock` | Existencia física disponible (debe ser `>= 0`). |
| `minimum_stock` | `INT` | No | `CK_product_min_stock` | Umbral para alerta de reposición (`>= 0`). |
| `category_id` | `INT` | No | `FK -> category(id)` | Categoría a la que pertenece el producto. |
| `created_at` | `DATETIME2` | No | `DEFAULT GETDATE()` | Fecha y hora de alta del artículo. |
| `updated_at` | `DATETIME2` | Sí | — | Fecha y hora de última modificación. |
| `deleted_at` | `DATETIME2` | Sí | — | Fecha y hora de baja lógica. |
| `created_by` | `INT` | No | `FK -> user(user_id)` | Usuario responsable del alta del producto. |
| `updated_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que realizó la última modificación. |
| `deleted_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que dio de baja el producto. |
| `is_active` | `BIT` | No | `DEFAULT 1` | Estado (1: Activo en catálogo, 0: Baja lógica). |

---

### 7. Tabla: `dbo.payment_method`
Parametrización de las formas de cobro habilitadas en el local
comercial (Efectivo, Débito, Transferencia, etc.).

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental del método de pago. |
| `name` | `VARCHAR(50)` | No | `UQ` | Nombre único del método (hasta 50 caracteres). |
| `description` | `VARCHAR(255)` | Sí | — | Información adicional del canal de cobro. |
| `created_at` | `DATETIME2` | No | `DEFAULT GETDATE()` | Fecha y hora de registro. |
| `updated_at` | `DATETIME2` | Sí | — | Fecha y hora de última modificación. |
| `deleted_at` | `DATETIME2` | Sí | — | Fecha y hora de baja lógica. |
| `created_by` | `INT` | No | `FK -> user(user_id)` | Usuario que registró el método de pago. |
| `updated_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que realizó la última edición. |
| `deleted_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que aplicó la baja lógica. |
| `is_active` | `BIT` | No | `DEFAULT 1` | Estado (1: Habilitado para cobro, 0: Inactivo). |

---

### 8. Tabla: `dbo.sale`
Cabecera de las transacciones de venta concretadas en el mostrador.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental de la venta. |
| `code` | `VARCHAR(50)` | No | `UQ` | Código alfanumérico único del comprobante. |
| `total_amount` | `DECIMAL(12,2)` | No | `CK_sale_total` | Monto total de la venta (debe ser `>= 0`). |
| `delivery_date` | `DATETIME2` | Sí | — | Fecha y hora pactada o efectiva de entrega. |
| `status` | `VARCHAR(20)` | No | `CK_sale_status`, `DEFAULT 'Completada'` | Estado: `'Completada'`, `'Cancelada'`, `'Pendiente'`. |
| `voucher_type` | `CHAR(1)` | No | `CK_sale_voucher`, `DEFAULT 'B'` | Tipo de comprobante fiscal emitido (`'A'`,`'B'`,`'C'`,`'X'`). |
| `user_id` | `INT` | No | `FK -> user(user_id)` | Vendedor responsable que procesó la venta. |
| `customer_id` | `INT` | No | `FK -> customer(customer_id)` | Cliente asociado o Consumidor Final (`99999999`). |
| `payment_method_id` | `INT` | No | `FK -> payment_method(id)` | Medio de pago utilizado para cancelar la venta. |
| `created_at` | `DATETIME2` | No | `DEFAULT GETDATE()` | Fecha y hora exacta de registro de la venta. |
| `updated_at` | `DATETIME2` | Sí | — | Fecha y hora de actualización administrativa. |
| `deleted_at` | `DATETIME2` | Sí | — | Fecha y hora de anulación/baja de la venta. |
| `updated_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que modificó el registro de venta. |
| `deleted_by` | `INT` | Sí | `FK -> user(user_id)` | Usuario que anuló la venta. |
| `is_active` | `BIT` | No | `DEFAULT 1` | Estado de validez de la transacción (1: Válida). |

---

### 9. Tabla: `dbo.sale_detail`
Líneas de detalle que componen cada orden de venta, registrando las
unidades vendidas y congelando el precio unitario histórico.

| Campo | Tipo de Dato | Nulo | Clave / Restricción | Descripción |
| :--- | :--- | :---: | :--- | :--- |
| `id` | `INT IDENTITY(1,1)` | No | `PK` | Identificador único autoincremental del detalle. |
| `sale_id` | `INT` | No | `FK -> sale(id)` | Venta a la que pertenece esta línea de detalle. |
| `product_id` | `INT` | No | `FK -> product(id)` | Producto comercializado en la línea. |
| `quantity` | `INT` | No | `CK_saledetail_quantity` | Cantidad de unidades vendidas (estrictamente `> 0`). |
| `unit_price` | `DECIMAL(12,2)` | No | `CK_saledetail_price` | Precio unitario congelado al momento del cobro (`>= 0`). |
