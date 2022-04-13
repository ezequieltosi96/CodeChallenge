IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'permissionsDB')
BEGIN
    CREATE DATABASE permissionsDB;
END