/*
  Tech Diary - Banco de dados corrigido
  Execute este arquivo em uma base nova no SQL Server.
*/

IF DB_ID('SistemaEscolar') IS NULL
    CREATE DATABASE SistemaEscolar;
GO

USE SistemaEscolar;
GO

CREATE TABLE SUPERVISOR
(
    id_admin INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(155) NOT NULL,
    email NVARCHAR(155) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    status NVARCHAR(18) NOT NULL CHECK (status IN ('Active', 'Inactive', 'Away'))
);
GO

CREATE TABLE TEACHER
(
    id_teacher INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(155) NOT NULL,
    email NVARCHAR(155) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    status NVARCHAR(18) NOT NULL CHECK (status IN ('Active', 'Inactive', 'Away'))
);
GO

CREATE TABLE STUDENT
(
    id_student INT IDENTITY(1,1) PRIMARY KEY,
    id_admin INT NOT NULL,
    name NVARCHAR(155) NOT NULL,
    date_birthday DATE NULL,
    date_register DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    status NVARCHAR(18) NOT NULL CHECK (status IN ('Active', 'Inactive', 'Away')),
    CONSTRAINT FK_STUDENT_SUPERVISOR FOREIGN KEY (id_admin)
        REFERENCES SUPERVISOR(id_admin)
);
GO

CREATE TABLE COURSE
(
    id_course INT IDENTITY(1,1) PRIMARY KEY,
    id_admin INT NOT NULL,
    id_teacher INT NOT NULL UNIQUE,
    name NVARCHAR(155) NOT NULL,
    workload_hours INT NOT NULL CHECK (workload_hours > 0),
    status NVARCHAR(14) NOT NULL CHECK (status IN ('Active', 'Inactive')),
    price DECIMAL(10,2) NOT NULL CHECK (price >= 0),
    shift NVARCHAR(24) NOT NULL CHECK (shift IN ('Morning', 'Afternoon', 'Evening')),
    CONSTRAINT FK_COURSE_SUPERVISOR FOREIGN KEY (id_admin)
        REFERENCES SUPERVISOR(id_admin),
    CONSTRAINT FK_COURSE_TEACHER FOREIGN KEY (id_teacher)
        REFERENCES TEACHER(id_teacher)
);
GO

CREATE TABLE REGISTRATION
(
    id_registration INT IDENTITY(1,1) PRIMARY KEY,
    id_student INT NOT NULL,
    id_course INT NOT NULL,
    date_registration DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    status NVARCHAR(14) NOT NULL DEFAULT 'Active'
        CHECK (status IN ('Active', 'Pending', 'Cancelled')),
    CONSTRAINT UQ_REGISTRATION_STUDENT_COURSE UNIQUE (id_student, id_course),
    CONSTRAINT FK_REGISTRATION_STUDENT FOREIGN KEY (id_student)
        REFERENCES STUDENT(id_student),
    CONSTRAINT FK_REGISTRATION_COURSE FOREIGN KEY (id_course)
        REFERENCES COURSE(id_course)
);
GO

CREATE TABLE ASSESSMENT
(
    id_assessment INT IDENTITY(1,1) PRIMARY KEY,
    id_course INT NOT NULL,
    name NVARCHAR(155) NOT NULL,
    weight DECIMAL(5,2) NOT NULL CHECK (weight > 0),
    date_assessment DATE NULL,
    CONSTRAINT FK_ASSESSMENT_COURSE FOREIGN KEY (id_course)
        REFERENCES COURSE(id_course)
);
GO

CREATE TABLE PRESENCE
(
    id_presence INT IDENTITY(1,1) PRIMARY KEY,
    id_registration INT NOT NULL,
    date_presence DATE NOT NULL,
    status NVARCHAR(24) NOT NULL CHECK (status IN ('Present', 'Absent', 'Certificate')),
    CONSTRAINT UQ_PRESENCE_REGISTRATION_DATE UNIQUE (id_registration, date_presence),
    CONSTRAINT FK_PRESENCE_REGISTRATION FOREIGN KEY (id_registration)
        REFERENCES REGISTRATION(id_registration)
);
GO

CREATE TABLE GRADE
(
    id_grade INT IDENTITY(1,1) PRIMARY KEY,
    id_registration INT NOT NULL,
    id_assessment INT NOT NULL,
    value DECIMAL(5,2) NOT NULL CHECK (value >= 0 AND value <= 100),
    CONSTRAINT UQ_GRADE_REGISTRATION_ASSESSMENT UNIQUE (id_registration, id_assessment),
    CONSTRAINT FK_GRADE_REGISTRATION FOREIGN KEY (id_registration)
        REFERENCES REGISTRATION(id_registration),
    CONSTRAINT FK_GRADE_ASSESSMENT FOREIGN KEY (id_assessment)
        REFERENCES ASSESSMENT(id_assessment)
);
GO

CREATE TABLE SYSTEM_SETTINGS
(
    id_setting INT IDENTITY(1,1) PRIMARY KEY,
    school_name NVARCHAR(155) NOT NULL,
    email NVARCHAR(155) NULL,
    phone NVARCHAR(30) NULL,
    address NVARCHAR(255) NULL,
    notifications_enabled BIT NOT NULL DEFAULT 1
);
GO

/* Dados mínimos para testar o cadastro de cursos. */
INSERT INTO SUPERVISOR (name, email, password, status)
VALUES ('Administrador', 'admin@techdiary.com', 'admin123', 'Active');

INSERT INTO TEACHER (name, email, password, status)
VALUES ('Professor Demo', 'professor@techdiary.com', 'prof123', 'Active');
GO
