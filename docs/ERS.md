# Especificación de Requerimientos de Software (ERS)

> **Proyecto:** Sistema de Gestión de Ventas — Matiensos
> **Integrantes:** Romero Ingrid Luana, Torres Jemina Cesia

---

## 1. Introducción

### 1.1. Propósito
El presente documento define la **Especificación de Requerimientos de Software (ERS)** para el sistema **Matiensos**, 
una aplicación de escritorio diseñada bajo estándares de ingeniería y arquitectura en capas para optimizar y centralizar la 
operatoria comercial de un local físico especializado en la comercialización de articulos materos.

El sistema busca resolver de manera integral  la falta de control centralizado, optimizando los tiempos de atención en el mostrador 
mediante un registro ágil de ventas, asegurando la consistencia del inventario en tiempo real y garantizando la transparencia 
y trazabilidad operativa mediante un subsistema de auditoría.

### 1.2. Alcance del Sistema
El sistema **Matiensos** es una solución de escritorio concebida para centralizar, optimizar y transparentar la operatoria comercial y
administrativa del local físico en su punto de venta.

El alcance del proyecto abarca de manera integral la atención en mostrador mediante un registro ágil de ventas, la asociación de
clientes o consumidor final, el cálculo automático de importes y la emisión de comprobantes.
Asimismo, contempla el control en tiempo real del inventario con descuento automático de stock, la gestión del catálogo de productos,
categorías y métodos de pago, y la emisión de alertas preventivas ante existencias mínimas.

Para garantizar la seguridad y la transparencia operativa, el sistema incorpora autenticación con roles diferenciados (*Super Administrador*,
*Administrador* y *Vendedor*), un subsistema de auditoría de acciones críticas y herramientas de resguardo y copia de seguridad de
la base de datos.

### 1.3. Limitaciones del Sistema
Para mantener el foco en la atención en el local físico, el sistema no incluye:
- Ventas online ni integración con plataformas de comercio electrónico (*e-commerce*).
- Gestión de devoluciones o cambios de mercadería post-venta.
- Módulos de contabilidad avanzada (liquidación de impuestos / AFIP).
- Liquidación de sueldos ni gestión de recursos humanos.
- Envíos a domicilio o logística externa.

### 1.4. Glosario de Términos
- **ABM (Alta, Baja, Modificación):** Conjunto de operaciones básicas de persistencia de datos (CRUD).
- **Baja Lógica:** Inactivación de un registro mediante una bandera de estado (`is_active = 0` / `deleted_at`) preservando la 
integridad referencial histórica.
- **RBAC (Role-Based Access Control):** Mecanismo de seguridad que restringe el acceso a vistas y operaciones del sistema 
según el rol formal del usuario autenticado.
- **KPI (Key Performance Indicator):** Indicador clave de rendimiento presentado en tarjetas visuales de resumen.
- **Super Administrador:** Usuario con máxima jerarquía, responsable exclusivo de la administración de usuarios y configuración 
de accesos.
- **Administrador:** Perfil directivo/operativo encargado del inventario, catálogo, métodos de pago y supervisión analítica.
- **Vendedor:** Perfil de línea de caja enfocado en la atención directa, alta de clientes y cobro.

---

## 2. Descripción General

### 2.1. Funcionalidades Generales (Módulos del Sistema)
El sistema Matiensos centraliza la gestión del local a través de los siguientes módulos funcionales:

- **Módulo de Seguridad y Accesos:**  
  Gestiona la autenticación segura (inicio y cierre de sesión mediante credenciales) y la autorización mediante control de acceso por roles
  (RBAC). Habilita o bloquea de forma dinámica las vistas y funciones de la aplicación según el perfil del usuario autenticado.

- **Módulo de Gestión de Usuarios:**  
  Gestiona el ABM de los usuarios del sistema. Permite dar de alta nuevas cuentas, asociarlas a personas físicas con DNI y correo
  únicos, asignar o modificar roles y aplicar bajas lógicas para revocar accesos.

- **Módulo de Inventario y Catálogo:**  
  Actúa como el catálogo central del negocio. Permite registrar nuevos productos, agruparlos por categorías, parametrizar los métodos de pago
  aceptados en el local, actualizar precios y controlar el stock en tiempo real con alertas visuales ante existencias mínimas.

- **Módulo de Ventas (Punto de Venta):**  
  Constituye el motor operativo del mostrador. Facilita la carga rápida de productos en el carrito, la verificación y descuento automático de
  stock, la selección del método de pago, la asignación de clientes (o "Consumidor Final") y la emisión del comprobante o ticket.

- **Módulo de Auditoría y Trazabilidad:**  
  Registra cada acción crítica (creación, edición o baja lógica) indicando qué usuario la realizó, en qué fecha y qué datos
  afectó, permitiendo la consulta con filtros y la exportación de reportes.

- **Módulo de Respaldo y Continuidad (Backup & Restore):**  
  Permite al Administrador y Super Administrador generar copias de seguridad nativas de la base de datos (`.bak`) hacia rutas designadas y 
  ejecutar su restauración para salvaguardar la información ante contingencias.

---

### 2.2. Arquitectura del Sistema
El sistema se organiza en **4 capas desacopladas** con responsabilidades bien delimitadas:

- **1. Capa de Presentación (`Presentation`):**  
  Interfaces de usuario desarrolladas en Windows Forms, con validaciones reactivas en tiempo real y estilos visuales unificados.
- **2. Capa de Negocio (`Business`):**  
  Lógica del dominio, reglas de validación, auditoría transversal y orquestación de operaciones.
- **3. Capa de Acceso a Datos (`Data`):**  
  Acceso a base de datos mediante ADO.NET con sentencias Transact-SQL parametrizadas para máxima seguridad y rendimiento.
- **4. Entidades del Dominio (`Entities`):**  
  Modelos de datos fuertemente tipados compartidos transversalmente por todas las capas.

### 2.3. Perfiles de Usuario

#### Vendedor
- **Nivel Operativo:** Línea de caja y mostrador.
- **Formación:** Secundaria completa con conocimientos informáticos básicos.
- **Alcance en el Sistema:**  
  Atención al público, búsqueda y registro de clientes, confección del carrito de ventas, selección de medios de pago y 
  emisión de tickets. Posee acceso de solo lectura a su propio historial diario de ventas.

#### Administrador
- **Nivel Operativo:** Gerencial y control de stock.
- **Formación:** Secundaria completa con conocimientos informáticos avanzados.
- **Alcance en el Sistema:**  
  Gestión completa del catálogo (ABM de productos y categorías), administración de métodos de pago, control de precios, 
  alertas de reposición y consulta de la bitácora de auditoría.

#### Super Administrador
- **Nivel Operativo:** Técnico y máxima jerarquía.
- **Formación:** Técnica o administración de sistemas.
- **Alcance en el Sistema:**  
  Gestión exclusiva de cuentas de usuario y asignación de roles, supervisión global de auditoría y ejecución de respaldos de base de datos.

---

## 3. Requisitos Específicos

### 3.1. Requisitos Funcionales (RF)

#### Módulo de Seguridad y Accesos
- **RF-01:**  
  El sistema debe requerir que todos los usuarios ingresen mediante credenciales válidas (correo electrónico y contraseña) para acceder
  a la aplicación.
- **RF-02:**  
  El sistema debe habilitar o bloquear dinámicamente el acceso a los distintos módulos y botones de la interfaz dependiendo del rol
  asignado al usuario que inició sesión.
- **RF-03:**  
  El sistema debe permitir al superadministrador modificar los datos de vendedor y administrador, mediante un formulario seguro de actualización 
  de credenciales.
- **RF-04:**  
  El sistema debe impedir la baja lógica o la desactivación del Super Administrador en sesión en caso de que sea la única cuenta activa
  con dicho rol en el sistema.

#### Módulo de Usuarios
- **RF-05:**  
  El sistema debe permitir el registro inicial de una cuenta de usuario con rol de Super Administrador mediante el ingreso de nombre, apellido,
  correo electrónico y contraseña durante la primera configuración del sistema.
- **RF-06:**  
  El sistema debe permitir exclusivamente al Super Administrador registrar las cuentas de nuevos empleados (Vendedor, Administrador), 
  con sus datos personales, contraseña de acceso y rol. También, actualizar sus datos o aplicar una baja lógica para deshabilitarlos.
- **RF-07:**  
  El sistema debe permitir exclusivamente al Super Administrador asignar o modificar el rol (Vendedor, Admin) asociado a la cuenta de un usuario.

#### Módulo de Inventario
- **RF-08:**  
  El sistema debe permitir a los usuarios administradores gestionar el ABM de los productos del inventario.
- **RF-09:**  
  El sistema debe permitir a los usuarios administradores gestionar el ABM de las categorías del inventario.
- **RF-10:**  
  El sistema debe actualizar automáticamente el stock disponible de los productos al concretarse una venta o al procesarse una devolución.
- **RF-11:**  
  El sistema debe permitir configurar y modificar un nivel de stock mínimo personalizable por cada producto, emitiendo una alerta visual 
  cuando las existencias actuales sean iguales o inferiores a dicho valor.

#### Módulo de Ventas
- **RF-12:**  
  El sistema debe permitir al Vendedor generar una nueva venta, seleccionar productos, cantidad, seleccionar obligatoriamente el método de pago
  utilizado por el cliente y calcular el total.
- **RF-13:**  
  El sistema debe permitir al Vendedor registrar nuevos clientes o consultar clientes existentes por DNI, permitiendo también la venta rápida 
  bajo la figura de Consumidor Final de forma opcional.
- **RF-14:**  
  El sistema debe permitir a los usuarios administradores gestionar el ABM de los distintos métodos de pago aceptados en el local.
- **RF-15:**  
  El sistema debe permitir emitir un comprobante de pago digital o imprimible tras la confirmación exitosa de cada venta, 
  detallando el identificador de venta, fecha y hora, datos del cliente (o "Consumidor Final"), vendedor responsable, lista de productos 
  con precios unitarios, método de pago utilizado y monto total.

#### Módulo de Auditoría
- **RF-16:**  
  El sistema debe generar un historial de actividades en formato texto cada vez que se realice una acción de ABM. Debe mostrar: nombre del
  usuario, rol, acción, registro modificado.
- **RF-17:**  
  El sistema debe permitir exclusivamente a los perfiles Administrador y Super Administrador visualizar el historial completo de las
  actividades del sistema.
- **RF-18:**  
  El sistema debe permitir al perfil Vendedor visualizar el historial completo de sus ventas.

#### Módulo de Respaldo (Backup)
- **RF-19:**  
  El sistema debe permitir a los usuarios Administrador y Super Administrador generar copias de seguridad de la base de datos y 
  restaurarlas ante contingencias operativas.

---

### 3.2. Requisitos No Funcionales (RNF)

#### Producto
- **RNF-01:**  
  El sistema no debe almacenar contraseñas en texto plano. Deben aplicarse algoritmos de hash seguros (como bcrypt) antes de guardarlas 
  en la base de datos.
- **RNF-02:**  
  Si el sistema pierde comunicación con la base de datos, debe notificar inmediatamente al usuario mediante un mensaje en pantalla y bloquear
  cualquier intento de nueva transacción hasta que se recupere la conexión.
- **RNF-03:**  
  El tiempo de procesamiento para registrar una nueva venta en la base de datos y actualizar el stock no debe exceder los 2 segundos 
  bajo condiciones normales de red local.

#### Organizacionales
- **RNF-04:**  
  El sistema se construirá utilizando el lenguaje C# sobre la plataforma .NET, empleando Windows Forms (WinForms) como framework para el 
  desarrollo de la interfaz gráfica de escritorio, y se apoyará en el motor de base de datos relacional MySQL.
- **RNF-05:**  
  El código fuente deberá organizarse respetando un patrón de diseño arquitectónico por Capas.

#### Externos
- **RNF-06:**  
  Los datos personales solicitados a los clientes (nombre, DNI, correo) estarán sujetos a normativas básicas de privacidad, garantizando que no
  sean expuestos ni exportados fuera del alcance administrativo del local comercial.

---

## 4. Reglas de Negocio (RN)

### Usuarios y Roles
- **RN01.** Todo usuario debe tener asociado un único rol (Vendedor, Administrador o Super Administrador).
- **RN02.** Un rol puede estar asignado a varios usuarios, pero un usuario solo puede tener un rol a la vez.
- **RN03.** Todo usuario corresponde a una única persona física (relación usuario–persona 1:1).
- **RN04.** Debe existir en todo momento al menos un usuario activo con rol Super Administrador (no puede quedar el sistema sin este rol).
- **RN05.** Solo el Super Administrador puede dar de alta, modificar el rol o dar de baja lógica a otros usuarios.

### Clientes
- **RN06.** Un cliente es una persona que además tiene una dirección registrada (relación persona–cliente 1:1).
- **RN07.** Un cliente puede realizar varias compras a lo largo del tiempo.
- **RN08.** Una venta puede o no tener un cliente asociado; si no lo tiene, se considera "Consumidor Final".

### Productos y Categorías
- **RN09.** Todo producto debe pertenecer obligatoriamente a una única categoría.
- **RN10.** Una categoría puede agrupar varios productos, pero puede existir sin tener productos asociados todavía.
- **RN11.** Solo los usuarios con rol Administrador o Super Administrador pueden gestionar (ABM) productos y categorías.

### Ventas
- **RN12.** Toda venta debe ser registrada por un único usuario (vendedor) responsable de la operación.
- **RN13.** Un usuario (vendedor) puede registrar múltiples ventas.
- **RN14.** Toda venta debe tener asociado un único medio de pago.
- **RN15.** Un medio de pago puede utilizarse en muchas ventas distintas.
- **RN16.** Toda venta debe estar compuesta por al menos un detalle de venta (no puede existir una venta vacía).
- **RN17.** Cada línea de detalle de venta hace referencia a un único producto dentro de una única venta (relación N:M entre producto y venta).
- **RN18.** El precio unitario registrado en el detalle de venta se "congela" al momento de la operación y es independiente de futuras modificaciones del precio del producto.
- **RN19.** El monto total de la venta debe ser consistente con la sumatoria de (cantidad × precio_unitario) de todos sus detalles.

### Inventario
- **RN20.** El stock de un producto se actualiza (descuenta) automáticamente al confirmarse cada venta (estado = PAGADO).
- **RN21.** No debe permitirse registrar una venta si la cantidad solicitada de un producto es mayor al stock disponible.
- **RN22.** Cada producto define un stock mínimo propio que determina cuándo se emite alerta de reposición.

### Auditoría
- **RN23.** Toda operación de ABM sobre cualquier entidad del sistema debe generar automáticamente un registro en formato texto en el historial de actividades.
- **RN24.** Todo registro del historial de actividades debe estar vinculado a un único usuario responsable de la acción.
- **RN25.** Solo los perfiles Administrador y Super Administrador pueden consultar el historial completo de actividades.
- **RN26.** El perfil Vendedor puede visualizar el historial de sus ventas.
