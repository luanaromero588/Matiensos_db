# Modelado Funcional: Casos de Uso

> **Proyecto:** Sistema de Gestión de Ventas — Matiensos  
> **Documento:** Especificación Funcional de Casos de Uso  

---

## 1. Introducción y Actores del Sistema

El modelado de Casos de Uso describe las interacciones entre los actores (usuarios que interactúan con la aplicación) y el sistema Matiensos,
delimitando responsabilidades y alcances funcionales.

### Actores Identificados:
- **Usuario:**  
  Representa a cualquier persona con credenciales válidas en el sistema. Heredan de él los tres perfiles operativos para funciones comunes como
  inicio de sesión y cambio de credenciales personales.
- **Vendedor:**  
  Perfil operativo de mostrador enfocado en la atención al cliente, registro de ventas, selección de medios de pago, consulta de su propio
  historial diario y emisión de tickets.
- **Administrador:**  
  Perfil gerencial responsable del catálogo comercial (productos, categorías y métodos de pago), control de existencias, supervisión de
  auditoría y copias de seguridad.
- **Super Administrador:**  
  Perfil técnico y de máxima jerarquía con facultades exclusivas sobre la administración de cuentas de empleados, asignación de roles y control
  total del sistema.

---

## 2. Diagrama General de Casos de Uso

A continuación se presenta el diagrama general de Casos de Uso del sistema:

![Diagrama General de Casos de Uso](img/CASOS_DE_USO.png)

---

## 3. Matriz de Casos de Uso del Sistema

Alineación completa de todos los Casos de Uso del sistema con sus actores y los Requisitos Funcionales (RF) correspondientes:

| Caso de Uso | Denominación Funcional | Actores Participantes | Requisito Relacionado |
| :--- | :--- | :--- | :---: |
| **CU-01** | Iniciar Sesión | Vendedor, Admin, SuperAdmin | `RF-01`, `RF-02` |
| **CU-02** | Registrar Cliente | Vendedor | `RF-13` |
| **CU-03** | Registrar Venta | Vendedor | `RF-12`, `RF-13`, `RF-14` |
| **CU-04** | Emitir Comprobante (Ticket) | Vendedor (*include* de CU-03) | `RF-15` |
| **CU-05** | Consultar Historial de Ventas | Vendedor, Administrador, SuperAdmin |`RF-16`, `RF-17`, `RF-18` |
| **CU-06** | Gestionar Productos | Administrador, SuperAdmin | `RF-08`,`RF-10`, `RF-11` |
| **CU-07** | Gestionar Categorías | Administrador, SuperAdmin | `RF-09` |
| **CU-08** | Gestionar Métodos de Pago | Administrador, SuperAdmin | `RF-14` |
| **CU-09** | Consultar Auditoría | Administrador, SuperAdmin | `RF-16`, `RF-17` |
| **CU-10** | Registrar Cuenta | Super Administrador | `RF-05` |
| **CU-11** | Gestionar Usuarios (ABM) | Super Administrador |`RF-03`, `RF-06`, `RF-04` |
| **CU-12** | Gestionar Roles | Super Administrador | `RF-07` |
| **CU-13** | Gestionar Respaldo (Backup) | Administrador, SuperAdmin | `RF-19` |

---

## 4. Especificación Narrativa de Casos de Uso Críticos

A continuación se detallan las plantillas formales de los flujos de
trabajo del sistema, alineadas con la matriz de Casos de Uso:

---

### CU-01: Iniciar Sesión
- **Actores:** Vendedor, Administrador, Super Administrador.
- **Propósito:** Validar credenciales de acceso y configurar el entorno de trabajo según el rol.
- **Precondiciones:** El usuario debe estar registrado y con estado activo en la base de datos.
- **Flujo Principal:**
  1. El usuario abre la aplicación y visualiza la pantalla de login.
  2. El usuario ingresa su correo electrónico y su contraseña.
  3. El usuario presiona el botón "Iniciar Sesión".
  4. El sistema valida las credenciales contra la base de datos mediante hashing seguro.
  5. El sistema recupera el perfil del usuario, instancia la sesión activa y abre el panel correspondiente habilitando los menús autorizados.
- **Flujos Alternativos:**
  - *4.a. Credenciales inválidas:* El sistema informa error de autenticación, borra el campo de contraseña y mantiene el foco.
  - *4.b. Usuario inactivo (baja lógica):* El sistema notifica que la cuenta está deshabilitada y bloquea el acceso.
  - *4.c. Falla de conexión a BD:* El sistema muestra aviso de error de enlace y bloquea la operación hasta reconectar.
- **Postcondiciones:** Sesión iniciada y entorno cargado con permisos acordes.

---

### CU-02: Registrar Cliente
- **Actores:** Vendedor.
- **Propósito:** Registrar un nuevo cliente en el sistema para asociarlo a las ventas.
- **Precondiciones:** Sesión iniciada con rol Vendedor.
- **Flujo Principal:**
  1. El Vendedor accede a la opción de registrar nuevo cliente.
  2. El Vendedor ingresa los datos personales: DNI, nombre, apellido, teléfono y correo electrónico.
  3. El sistema valida que el DNI sea numérico y no esté duplicado.
  4. El Vendedor presiona "Guardar".
  5. El sistema persiste el registro y lo deja disponible para la venta.
- **Flujos Alternativos:**
  - *3.a. DNI duplicado:* El sistema alerta que el cliente ya existe y bloquea el guardado.
- **Postcondiciones:** Cliente registrado en la base de datos.

---

### CU-03: Registrar Venta
- **Actores:** Vendedor.
- **Propósito:** Registrar una transacción de venta en mostrador, descontar stock y generar el comprobante.
- **Precondiciones:** Usuario autenticado como Vendedor; productos con stock disponible y métodos de pago activos.
- **Flujo Principal:**
  1. El Vendedor accede a la pantalla de Punto de Venta.
  2. El Vendedor busca y selecciona al cliente por DNI, o selecciona la opción predeterminada "Consumidor Final".
  3. El Vendedor busca productos disponibles por código o descripción.
  4. El Vendedor indica la cantidad requerida para cada producto y los agrega al carrito de venta.
  5. El sistema verifica que la cantidad no exceda el stock físico disponible y calcula el subtotal por línea.
  6. El Vendedor selecciona obligatoriamente el método de pago utilizado.
  7. El Vendedor confirma la operación haciendo clic en "Cobrar".
  8. El sistema descuenta el stock de manera atómica, registra la venta en estado `Completada`, congela los precios unitarios e invoca
     automáticamente el caso de uso `CU-04: Emitir Comprobante`.
- **Flujos Alternativos:**
  - *5.a. Stock insuficiente:* El sistema emite un aviso visual impidiendo superar las existencias reales.
  - *6.a. Carrito vacío:* El sistema desactiva el cobro e indica que debe cargar al menos un producto.
  - *6.b. Método de pago no seleccionado:* El sistema resalta el campo y solicita la selección obligatoria.
- **Postcondiciones:** Venta registrada, stock actualizado y comprobante emitido.

---

### CU-04: Emitir Comprobante (Ticket de Venta)
- **Actores:** Vendedor / Sistema (incluido por `CU-03: Registrar Venta`).
- **Propósito:** Generar una representación digital e imprimible del comprobante de pago.
- **Precondiciones:** Venta previamente confirmada y persistida en base de datos.
- **Flujo Principal:**
  1. El sistema recupera el código de venta, fecha, datos del cliente, vendedor, detalle de productos, método de pago y monto total.
  2. El sistema formatea la vista de ticket con el membrete oficial del comercio Matiensos.
  3. El sistema muestra la ventana modal del ticket con opciones de impresión directa o guardado digital.
- **Postcondiciones:** Comprobante puesto a disposición del cliente.

---

### CU-05: Consultar Historial de Ventas
- **Actores:** Vendedor, Administrador, Super Administrador.
- **Propósito:** Visualizar el listado histórico de ventas realizadas.
- **Precondiciones:** Usuario autenticado en el sistema.
- **Flujo Principal:**
  1. El usuario accede a la pantalla de Historial de Ventas.
  2. El sistema presenta la grilla de ventas (para el Vendedor se limita
     a sus operaciones del día; para Administrador y SuperAdmin muestra todas las transacciones del local).
  3. El usuario puede filtrar por fechas o buscar por código de venta.
  4. El usuario selecciona una venta para visualizar el detalle completo.
- **Postcondiciones:** Información de ventas consultada sin modificaciones.

---

### CU-06: Gestionar Productos
- **Actores:** Administrador, Super Administrador.
- **Propósito:** Dar de alta, modificar datos, aplicar bajas lógicas y reactivar artículos del catálogo.
- **Precondiciones:** Sesión iniciada con rol gerencial.
- **Flujo Principal (Alta / Modificación):**
  1. El usuario accede al módulo de productos.
  2. El usuario selecciona "Nuevo Producto" o hace clic en el icono de edición de una fila existente.
  3. El usuario completa o edita: código (4 caracteres), nombre, descripción, precio unitario, stock inicial, stock mínimo y categoría asociada.
  4. El sistema valida en tiempo real la unicidad del código/nombre y que los valores numéricos sean válidos.
  5. El usuario presiona "Guardar".
  6. El sistema persiste el registro, genera el asiento en la bitácora de auditoría y actualiza la grilla y tarjetas KPI.
- **Flujos Alternativos:**
  - *4.a. Código o nombre duplicado:* El campo se resalta en tono rojizo indicando el mensaje de duplicidad y bloqueando el guardado.
  - *Baja Lógica / Reactivación:* Al presionar el icono de baja/reactivar, se solicita confirmación y se conmuta el estado `is_active`.
- **Postcondiciones:** Catálogo de productos actualizado y evento auditado.

---

### CU-07: Gestionar Categorías
- **Actores:** Administrador, Super Administrador.
- **Propósito:** Administrar la clasificación por categorías de los productos.
- **Precondiciones:** Sesión iniciada con rol gerencial.
- **Flujo Principal:**
  1. El usuario accede al módulo de Categorías.
  2. El usuario selecciona "Nueva Categoría" o edita una existente.
  3. El usuario ingresa código (4 caracteres) y nombre descriptivo.
  4. El sistema valida que el código y el nombre sean únicos.
  5. El usuario presiona "Guardar".
  6. El sistema guarda la categoría y actualiza los selectores del catálogo.
- **Postcondiciones:** Categoría registrada y disponible para asociar productos.

---

### CU-08: Gestionar Métodos de Pago
- **Actores:** Administrador, Super Administrador.
- **Propósito:** Administrar las formas de cobro aceptadas en el comercio.
- **Precondiciones:** Sesión iniciada con rol gerencial.
- **Flujo Principal:**
  1. El usuario accede a la pantalla de Métodos de Pago.
  2. El sistema visualiza la grilla de métodos registrados y los indicadores superiores (métodos activos, mayor y menor recaudación).
  3. El usuario selecciona "Nuevo Método".
  4. El usuario ingresa el nombre (hasta 50 caracteres) y descripción opcional.
  5. El sistema valida en tiempo real que el nombre no contenga caracteres inválidos ni coincida con uno existente.
  6. El usuario presiona "Guardar".
  7. El sistema guarda el registro, audita la acción y refresca los datos.
- **Flujos Alternativos:**
  - *Edición en grilla:* El usuario hace clic en el lápiz, modifica los campos directamente sobre la fila y presiona el icono de guardar.
  - *Baja Lógica / Reactivación:* Se conmuta el estado mediante el icono de acción tras confirmación.
- **Postcondiciones:** Método de pago habilitado para el Punto de Venta.

---

### CU-09: Consultar Auditoría
- **Actores:** Administrador, Super Administrador.
- **Propósito:** Supervisar las acciones críticas realizadas por los usuarios para garantizar transparencia operativa.
- **Precondiciones:** Rol administrativo activo.
- **Flujo Principal:**
  1. El usuario accede a la sección de Auditoría.
  2. El sistema lee el archivo de bitácora del período y presenta los eventos con fecha, usuario, módulo, acción ejecutada y detalle.
  3. El usuario aplica filtros por rango de fechas, usuario o tipo de acción.
  4. El sistema actualiza la lista paginada con los resultados coincidentes.
  5. El usuario puede exportar los resultados a un archivo de reporte.
- **Postcondiciones:** Información de trazabilidad consultada sin alteración.

---

### CU-10: Registrar Cuenta
- **Actores:** Super Administrador.
- **Propósito:** Registrar la cuenta inicial de Super Administrador o crear cuentas habilitadas en el sistema.
- **Precondiciones:** Acceso administrativo o configuración inicial.
- **Flujo Principal:**
  1. Se accede al formulario de registro de cuenta.
  2. Se completan los datos de nombre, apellido, correo y contraseña.
  3. El sistema valida la unicidad del correo y la longitud de la clave.
  4. Se confirma el registro y se inicializa el usuario en la base de datos.
- **Postcondiciones:** Cuenta creada con credenciales seguras.

---

### CU-11: Gestionar Usuarios (ABM)
- **Actores:** Super Administrador.
- **Propósito:** Administrar la nómina de usuarios habilitados, actualizar credenciales y aplicar bajas lógicas.
- **Precondiciones:** Sesión iniciada exclusivamente como Super Administrador.
- **Flujo Principal:**
  1. El Super Administrador accede a la pantalla de Gestión de Usuarios.
  2. El usuario selecciona registrar un nuevo empleado o editar uno existente.
  3. Se ingresan o modifican los datos personales (DNI, nombres, correo, teléfono), clave de acceso y el rol asignado.
  4. El sistema verifica la unicidad del DNI y correo electrónico.
  5. Al confirmar, se persiste la entidad persona y el usuario vinculado.
- **Flujos Alternativos:**
  - *Baja del último SuperAdmin:* El sistema impide la desactivación si es el único usuario activo con dicho rol para evitar bloqueos del sistema.
- **Postcondiciones:** Nómina de usuarios actualizada en base de datos.

---

### CU-12: Gestionar Roles
- **Actores:** Super Administrador.
- **Propósito:** Asignar o modificar el rol de un usuario existente.
- **Precondiciones:** Sesión iniciada como Super Administrador.
- **Flujo Principal:**
  1. El Super Administrador selecciona un usuario de la lista.
  2. Selecciona la opción de cambio de rol y elige el nuevo perfil (Vendedor, Administrador).
  3. El sistema valida que el cambio no viole la regla de mantener al menos un SuperAdmin activo.
  4. Se actualiza el `role_id` en la tabla `user`.
- **Postcondiciones:** Rol actualizado y permisos recalculados en el próximo
  inicio de sesión.

---

### CU-13: Gestionar Respaldo (Backup)
- **Actores:** Administrador, Super Administrador.
- **Propósito:** Generar copias de seguridad de la base de datos SQL Server y restaurarlas para resguardar la continuidad operativa.
- **Precondiciones:** Acceso al servidor de base de datos con permisos
  suficientes de backup.
- **Flujo Principal:**
  1. El usuario accede a la herramienta de Respaldo de Base de Datos.
  2. El usuario define la ruta de destino y presiona "Generar Backup".
  3. El sistema ejecuta el comando nativo de SQL Server y genera el archivo `.bak` con estampa temporal.
  4. El sistema notifica la finalización exitosa del respaldo.
- **Postcondiciones:** Copia de seguridad generada en almacenamiento seguro.
