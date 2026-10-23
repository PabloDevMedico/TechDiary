/* Execute este arquivo somente se o banco SistemaEscolar já foi criado. */
USE SistemaEscolar;
GO

IF COL_LENGTH('REGISTRATION', 'status') IS NULL
BEGIN
    ALTER TABLE REGISTRATION
    ADD status NVARCHAR(14) NOT NULL
        CONSTRAINT DF_REGISTRATION_STATUS DEFAULT 'Active'
        CHECK (status IN ('Active', 'Pending', 'Cancelled'));
END;
GO

IF OBJECT_ID('SYSTEM_SETTINGS', 'U') IS NULL
BEGIN
    CREATE TABLE SYSTEM_SETTINGS
    (
        id_setting INT IDENTITY(1,1) PRIMARY KEY,
        school_name NVARCHAR(155) NOT NULL,
        email NVARCHAR(155) NULL,
        phone NVARCHAR(30) NULL,
        address NVARCHAR(255) NULL,
        notifications_enabled BIT NOT NULL DEFAULT 1
    );
END;
GO
