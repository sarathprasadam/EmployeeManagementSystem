# Employee Management System

This Web based software help to maintain employee data.User with access can view,edit,delete,filter employee. By defualt admin user is created. Only admin user is capable of creating new user.

## Deployment

To deploy this project 


```bash
 1)This Project require MSSQL. First set connection string in appsettings
 2)In Database create the following tables.
 a)
    CREATE TABLE Login (
        id INT IDENTITY(1,1) PRIMARY KEY,
        username VARCHAR(50) UNIQUE NOT NULL,
        password VARCHAR(50) NOT NULL
    );

    INSERT INTO Login (username, password) VALUES ('admin',    'SyIRVR76WmZx7lFermoHLQ==');
 b)
 CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Gender NVARCHAR(MAX) NOT NULL,
    DOB DATETIME NOT NULL,
    Department NVARCHAR(MAX) NOT NULL,
    City NVARCHAR(MAX) NOT NULL,
    Qualifications NVARCHAR(MAX),
    ExperienceDetails NVARCHAR(MAX)
);
    

