-- Crear base de datos
CREATE DATABASE ClinicaDB;
GO
USE ClinicaDB;
GO

-- Tabla de Roles
CREATE TABLE Roles (
    id_Rol INT PRIMARY KEY IDENTITY(1,1),
    nombre_Rol NVARCHAR(50) UNIQUE NOT NULL
);
GO
-- Tabla de Usuarios
CREATE TABLE Usuarios (
    id_Usuario INT PRIMARY KEY IDENTITY(1,1),
    nombre_Usuario NVARCHAR(50) UNIQUE NOT NULL,
    clave NVARCHAR(255) NOT NULL,  -- Clave encriptada con BCRYPT
    id_Rol INT NOT NULL,
    FOREIGN KEY (id_Rol) REFERENCES Roles(id_Rol)
);
GO

-- Tabla de Pacientes
CREATE TABLE Pacientes (
    id_Paciente INT PRIMARY KEY IDENTITY(1,1),
    nombre_Paciente NVARCHAR(100) NOT NULL,
    fechaNacimiento DATE,
    telefono NVARCHAR(20),
    direccion NVARCHAR(200),
	genero BIT,
	correo_Electronico nvarchar(100)
);
GO
-- Tabla de Especialidades
CREATE TABLE Especialidades (
    id_Especialidad INT PRIMARY KEY IDENTITY(1,1),
    nombre_Especialidad NVARCHAR(100) NOT NULL
);
GO
-- Tabla de Médicos
CREATE TABLE Medicos (
    id_Medico INT PRIMARY KEY IDENTITY(1,1),
    nombre_Medico NVARCHAR(100) NOT NULL,
    id_Especialidad INT NOT NULL,
    telefono NVARCHAR(20),
    FOREIGN KEY (id_Especialidad) REFERENCES Especialidades(id_Especialidad)
);
GO
-- Tabla de Citas
CREATE TABLE Citas (
    id_Cita INT PRIMARY KEY IDENTITY(1,1),
    id_Paciente INT NOT NULL,
    id_Medico INT NOT NULL,
    fechaHora DATETIME NOT NULL,
    estado NVARCHAR(50) DEFAULT 'Pendiente',
    motivo NVARCHAR(500),
    FOREIGN KEY (id_Paciente) REFERENCES Pacientes(id_Paciente),
    FOREIGN KEY (id_Medico) REFERENCES Medicos(id_Medico)
);
GO
-- Tabla de Historial Médico
CREATE TABLE Historiales (
    id_Historial INT PRIMARY KEY IDENTITY(1,1),
    id_Paciente INT NOT NULL,
    id_Medico INT NOT NULL,
    descripcion NVARCHAR(500),
    fecha DATE DEFAULT GETDATE(),
    FOREIGN KEY (id_Paciente) REFERENCES Pacientes(id_Paciente),
    FOREIGN KEY (id_Medico) REFERENCES Medicos(id_Medico)
);
GO
-- Insertar Roles básicos
INSERT INTO Roles (nombre_Rol) VALUES ('Administrador'), ('Médico'), ('Recepcionista');
GO
