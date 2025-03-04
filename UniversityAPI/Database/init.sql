create database StudentsDataBase

use StudentsDataBase

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL
);


INSERT INTO Students (Name, Surname) VALUES
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


