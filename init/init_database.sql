USE permissionsDB;

IF (NOT EXISTS(SELECT *
               FROM INFORMATION_SCHEMA.TABLES
               WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'PermissionTypes'))
    BEGIN
        CREATE TABLE [PermissionTypes]
        (
            [Id] INT PRIMARY KEY IDENTITY (1, 1),
			[Description] VARCHAR(50) NOT NULL
        );
    END

IF (NOT EXISTS(SELECT *
               FROM INFORMATION_SCHEMA.TABLES
               WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'Permissions'))
    BEGIN
        CREATE TABLE [Permissions]
        (
            [Id] INT PRIMARY KEY IDENTITY (1, 1),
			[EmployeeForename] VARCHAR(100) NOT NULL,
			[EmployeeSurname] VARCHAR(100) NOT NULL,
			[PermissionType] INT NOT NULL,
			[PermissionDate] DATE NOT NULL,
			FOREIGN KEY (PermissionType) REFERENCES [dbo].[PermissionTypes] (Id)
        );
    END


IF ((SELECT COUNT(*) FROM [PermissionTypes]) <= 0)
    BEGIN
        INSERT INTO [dbo].[PermissionTypes] ([Description]) VALUES ('Admin'), ('Sales'), ('Workshop'), ('Finance');
    END