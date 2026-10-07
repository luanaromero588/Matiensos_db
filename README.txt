=============================================================
             PROYECTO: GESTIÓN DE VENTAS - MATIENSOS
=============================================================
INTEGRANTES:
Romero Ingrid Luana
Torres Jemina Cesia

REQUISITOS PREVIOS:
- Visual Studio 2022 o superior (.NET Framework 4.8)
- SQL Server (Local / Express)

PASOS PARA EJECUTAR EL PROYECTO:
1. BASE DE DATOS:
   a. Abrir y ejecutar el script ubicado en:
      /Data/Database/Matiensos_db_script.sql
   b. El script crea la base de datos 'Matiensos_db', su esquema relacional 
   completo y los datos semilla necesarios para pruebas

2. CADENA DE CONEXIÓN (Si fuera necesario):
   - La conexión se encuentra configurada en:
     Presentation/App.config -> connectionStrings -> 'MatiensosConnection'
   - Por defecto apunta a la instancia local estándar:
   "Data Source=.;Initial Catalog=Matiensos_db;Integrated Security=True;"

   * Si utiliza una instancia con nombre (ej. .\SQLEXPRESS), ajustar el 
   parámetro Data Source en dicho archivo.

3. USUARIOS DE PRUEBA PARA INICIO DE SESIÓN:

   - Rol SuperAdmin:
     Usuario: superadmin@matiensos.com 
     Clave: Matiensos123!
  
   - Rol Administrador
     Usuario: admin@matiensos.com
     Clave: Admin123!

   - Rol Vendedor:
     Usuario: vendedor@matiensos.com
     Clave: Venta123!

   * NOTA SOBRE CLIENTES:
     Existe registrado el cliente 'Consumidor Final' (DNI: 99999999), 
     destinado exclusivamente a ventas/facturación (no posee acceso al sistema).
=============================================================
