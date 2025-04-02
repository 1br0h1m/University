create database UniversityDataBase

use UniversityDataBase

create table Students (
    Id int primary key identity(1,1),
    Name nvarchar(255) not null,
    Surname nvarchar(255) not null,
    Grade int not null,
    Email nvarchar(255) not null
);

create table Teachers (
    Id int primary key identity(1,1),
    Name nvarchar(255) not null,
    Surname nvarchar(255) not null,
    Email nvarchar(255) not null
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



insert into Students (Name, Surname, Grade, Email) values
('Liam', 'Walker', 85, 'liam@gmail.com'),
('Olivia', 'Brown', 92, 'olivia@gmail.com'),
('Noah', 'Davis', 78, 'noah@gmail.com'),
('Emma', 'Wilson', 88, 'emma@gmail.com'),
('James', 'Anderson', 74, 'james@gmail.com'),
('Ava', 'Taylor', 90, 'ava@gmail.com'),
('Lucas', 'Thomas', 81, 'lucas@gmail.com'),
('Sophia', 'Jackson', 96, 'sophia@gmail.com'),
('Benjamin', 'White', 67, 'benjamin@gmail.com'),
('Isabella', 'Harris', 91, 'isabella@gmail.com'),
('Henry', 'Martin', 84, 'henry@gmail.com'),
('Mia', 'Thompson', 89, 'mia@gmail.com'),
('Alexander', 'Garcia', 77, 'alexander@gmail.com'),
('Charlotte', 'Martinez', 95, 'charlotte@gmail.com'),
('Michael', 'Robinson', 82, 'michael@gmail.com'),
('Amelia', 'Clark', 86, 'amelia@gmail.com'),
('Ethan', 'Lewis', 73, 'ethan@gmail.com'),
('Harper', 'Lee', 87, 'harper@gmail.com'),
('Daniel', 'Young', 80, 'daniel@gmail.com'),
('Abigail', 'Allen', 93, 'abigail@gmail.com'),
('Matthew', 'Scott', 76, 'matthew@gmail.com'),
('Emily', 'Green', 88, 'emily@gmail.com'),
('Jacob', 'Hall', 79, 'jacob@gmail.com'),
('Elizabeth', 'Adams', 91, 'elizabeth@gmail.com'),
('Logan', 'Nelson', 83, 'logan@gmail.com'),
('Avery', 'Hill', 85, 'avery@gmail.com'),
('Jack', 'Carter', 78, 'jack@gmail.com'),
('Ella', 'Mitchell', 90, 'ella@gmail.com'),
('William', 'Perez', 86, 'william@gmail.com'),
('Scarlett', 'Turner', 94, 'scarlett@gmail.com');


insert into Teachers (Name, Surname, Email) values
('Liam', 'Turner', 'liam1@gmail.com'),
('Olivia', 'Garcia', 'olivia2@gmail.com'),
('Noah', 'Bennett', 'noah3@gmail.com'),
('Emma', 'Wright', 'emma4@gmail.com'),
('James', 'Long', 'james5@gmail.com'),
('Ava', 'Morris', 'ava6@gmail.com'),
('Lucas', 'King', 'lucas7@gmail.com'),
('Sophia', 'Perry', 'sophia8@gmail.com'),
('Benjamin', 'Barnes', 'benjamin9@gmail.com'),
('Isabella', 'Ross', 'isabella10@gmail.com');