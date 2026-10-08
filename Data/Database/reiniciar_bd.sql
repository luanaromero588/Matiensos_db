USE [master];
GO

-- 1. Cerrar conexiones activas y reiniciar la base de datos de cero
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Matiensos_db')
BEGIN
    ALTER DATABASE [Matiensos_db] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [Matiensos_db];
END;
GO