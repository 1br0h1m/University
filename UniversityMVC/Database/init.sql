create database UniversityDataBase

use UniversityDataBase

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL
);


CREATE TABLE Teachers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL
);


CREATE TABLE HttpLogs (
    RequestId NVARCHAR(100) PRIMARY KEY,
    Url NVARCHAR(MAX),
    RequestBody NVARCHAR(MAX),
    RequestHeaders NVARCHAR(MAX),
    MethodTypeId INT,
    ResponseBody NVARCHAR(MAX),
    ResponseHeaders NVARCHAR(MAX),
    StatusCode INT,
    CreationDateTime DATETIME,
    EndDateTime DATETIME,
    ClientIp NVARCHAR(100)
);


INSERT INTO Students ([Name], Surname) VALUES
('Test', 'Test'),
('Olivia', 'Williams'),
('Harper', 'Williams'),
('Sophia', 'Martin'),
('Daniel', 'Davis'),
('Bob', 'Garcia'),
('Andrew', 'Brown'),
('Bob', 'Hernandez'),
('Andrew', 'Thomas'),
('David', 'Smith'),
('Alice', 'Wilson'),
('Matthew', 'Martin'),
('Bob', 'Miller'),
('Alice', 'Williams'),
('Sophia', 'Gonzalez'),
('Sarah', 'Rodriguez'),
('Emma', 'Moore'),
('James', 'Jones'),
('Samuel', 'Johnson'),
('Joseph', 'Martin');


INSERT INTO Teachers ([Name], Surname) VALUES
('Olivia', 'Brown'),
('Noah', 'Davis'),
('Ava', 'Williams'),
('Elijah', 'Wilson'),
('Isabella', 'Anderson'),
('William', 'Taylor'),
('Mia', 'Thomas'),
('Benjamin', 'White'),
('Joseph', 'Martin');
