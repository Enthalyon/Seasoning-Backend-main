 -- >>>>>>>>> Creación de la DB <<<<<<<<<<< --

CREATE DATABASE SeasoningAndCandleDB;
GO
USE SeasoningAndCandleDB;
GO

-- >>>>>>>>> Creación de las tablas <<<<<<<<<<< --

-- USUARIOS --
CREATE TABLE Users (
	UserId INT IDENTITY(1000,1) NOT NULL,
	FirstName,  VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Phone VARCHAR(50),
	Email VARCHAR(100) NOT NULL,
	Address VARCHAR(200) NOT NULL,
	Password Text NOT NULL,
	IsActive BIT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	PRIMARY KEY(UserId)
);

-- Roles --
CREATE TABLE Roles (
	RoleId INT IDENTITY(1000, 1) NOT NULL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	AccessLevel INT NOT NULL
);

-- UserRoles --
CREATE TABLE UserRoles (
	UserCode INT NOT NULL,
	RoleCode INT NOT NULL,
	FOREIGN KEY(UserCode) REFERENCES Users(UserId),
	FOREIGN KEY(RoleCode) REFERENCES Roles(RoleId),
	PRIMARY KEY(UserCode, RoleCode),
);

-- Sales --
CREATE TABLE Sales (
	SaleId INT IDENTITY(1000, 1) NOT NULL,
	UserCode INT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	PRIMARY KEY(SaleId),
	FOREIGN KEY(UserCode) REFERENCES Users(UserId)
);

-- Products --
CREATE TABLE Products (
	ProductId INT IDENTITY(1000, 1) NOT NULL,
	Name VARCHAR(200) NOT NULL,
	Description TEXT,
	Stock INT NOT NULL,
	Price DECIMAL NOT NULL,
	CreatedAt DATETIME NOT NULL,
	PRIMARY KEY (ProductId),
);

-- Sale Products --
CREATE TABLE SaleProducts (
	SaleCode INT NOT NULL,
	ProductCode INT NOT NULL,
	Quantity DECIMAL NOT NULL,
	UnitPrice DECIMAL NOT NULL,
	FOREIGN KEY(SaleCode) REFERENCES Sales(SaleId),
	FOREIGN KEY(ProductCode) REFERENCES Products(ProductId),
	PRIMARY KEY(SaleCode, ProductCode)
);

-- Categories --
CREATE TABLE Categories (
	CategoryId INT IDENTITY(1000, 1) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Description TEXT,
	PRIMARY KEY(CategoryId)
);

-- ProductCategories --
CREATE TABLE ProductCategories (
	ProductCode INT NOT NULL,
	CategoryCode INT NOT NULL,
	FOREIGN KEY(ProductCode) REFERENCES Products(ProductId),
	FOREIGN KEY(CategoryCode) REFERENCES Categories(CategoryId),
	PRIMARY KEY(ProductCode, CategoryCode)
);
GO


-- >>>>>>>>> Inserciones <<<<<<<<<<< --

-- Tuplas de Users --
INSERT INTO USERS (FirstName, LastName, Phone, Email, Password, IsActive, CreatedAt)
	VALUES ('Pepito Alejandro', 'Perez de la cruz', '3021233345', 'pepitoperez@gmail.com', '123', 1, GETUTCDATE());
INSERT INTO USERS (FirstName, LastName, Phone, Email, Password, IsActive, CreatedAt)
	VALUES ('Juanito', 'Alimaña', '3121233341', 'juanitoalimana@gmail.com', '1234', 0, GETUTCDATE());
INSERT INTO USERS (FirstName, LastName, Phone, Email, Password, IsActive, CreatedAt)
	VALUES ('Rosario', 'Tijeras', '3322213345', 'rosariotijeras@gmail.com', '12345', 1, GETUTCDATE());

-- Tuplas de Roles --
INSERT INTO Roles (Name, AccessLevel) VALUES ('Super Administrador', 3);
INSERT INTO Roles (Name, AccessLevel) VALUES ('Administrador', 2);
INSERT INTO Roles (Name, AccessLevel) VALUES ('Cliente', 1);

-- Tuplas de UserRoles --
INSERT INTO UserRoles (UserCode, RoleCode) VALUES (1000, 1000);
INSERT INTO UserRoles (UserCode, RoleCode) VALUES (1001, 1001);
INSERT INTO UserRoles (UserCode, RoleCode) VALUES (1002, 1002);

-- Tuplas de Sales --
INSERT INTO Sales (UserCode, CreatedAt) VALUES (1000, GETUTCDATE());
INSERT INTO Sales (UserCode, CreatedAt) VALUES (1001, GETUTCDATE());
INSERT INTO Sales (UserCode, CreatedAt) VALUES (1002, GETUTCDATE());

-- Tuplas de Products --
INSERT INTO Products (Name, Description, Stock, Price, CreatedAt) 
	VALUES ('Lechona', 'La lechona de mejor calidad', 3, 20000, GETUTCDATE());
INSERT INTO Products (Name, Description, Stock, Price, CreatedAt) 
	VALUES ('Bandeja Paisa', 'Bandeja con frijoles, huevo, chorizo, chicharron, aguacate y patacones', 2, 15000, GETUTCDATE());
INSERT INTO Products (Name, Description, Stock, Price, CreatedAt) 
	VALUES ('Empanadas', 'Empanadas rellenas de carne',10, 3000, GETUTCDATE());

-- Tuplas de SaleProducts --
INSERT INTO SaleProducts (SaleCode, ProductCode, Quantity, UnitPrice) 
	VALUES (1000, 1000, 1, 20000);
INSERT INTO SaleProducts (SaleCode, ProductCode, Quantity, UnitPrice) 
	VALUES (1001, 1001, 1, 15000);
INSERT INTO SaleProducts (SaleCode, ProductCode, Quantity, UnitPrice) 
	VALUES (1002, 1002, 3, 3000);

-- Tuplas de Categories --
INSERT INTO Categories (Name, Description) VALUES ('Carnes', '');
INSERT INTO Categories (Name, Description) VALUES ('Comida rapida', 'Comida rapida');
INSERT INTO Categories (Name, Description) VALUES ('Corrientazo', 'Corrientazo');

-- Tuplas de ProductCategories --
INSERT INTO ProductCategories (ProductCode, CategoryCode) VALUES (1000, 1000);
INSERT INTO ProductCategories (ProductCode, CategoryCode) VALUES (1001, 1001);
INSERT INTO ProductCategories (ProductCode, CategoryCode) VALUES (1002, 1002);

-- >>>>>>>>> Consultas <<<<<<<<<<<<< --

-- Queries USERS --
SELECT * FROM Users;
SELECT * FROM Users WHERE UserId = 1000;
SELECT * FROM Users WHERE IsActive = 1;

-- Queries ROLES --
SELECT * FROM Roles
SELECT * FROM Roles WHERE AccessLevel > 1

-- Queries UserRoles --
SELECT * FROM UserRoles;
SELECT 
	U.UserId,
	R.RoleId,
	U.FirstName,
	U.LastName,
	U.IsActive,
	R.Name,
	R.AccessLevel
FROM UserRoles AS UR
INNER JOIN Roles AS R ON UR.RoleCode = R.RoleId
INNER JOIN Users AS U ON UR.UserCode = U.UserId 

-- Queries SALES --
SELECT * FROM Sales
SELECT * FROM Sales WHERE CreatedAt < '2024-07-25 17:20:24.293';

-- Queries SALES --
SELECT * FROM Products ORDER BY Stock DESC
SELECT * FROM Products ORDER BY Stock ASC
SELECT * FROM Products WHERE Price <= 16000 AND Stock > 0 ORDER BY Stock DESC

-- Queries SaleProducts --
SELECT * FROM SaleProducts
SELECT 
	S.SaleId,
	P.ProductId,
	U.UserId,
	U.FirstName,
	P.Name, 
	(P.Stock-SP.Quantity) CurrentStock,
	SP.UnitPrice,
	(SP.Quantity*SP.UnitPrice) Total
FROM SaleProducts SP
INNER JOIN Products P ON SP.ProductCode = P.ProductId
INNER JOIN Sales S ON SP.SaleCode = S.SaleId
INNER JOIN Users U ON S.UserCode = U.UserId;

-- Queries SaleProducts --
SELECT * FROM Categories;

-- Queries ProductCategories --
SELECT 
	P.ProductId,
	C.CategoryId,
	P.Name ProductName,
	C.Name AS CategoryName,
	P.Stock
FROM ProductCategories AS PC
INNER JOIN Categories AS C ON PC.CategoryCode = C.CategoryId
INNER JOIN Products AS P ON PC.ProductCode = P.ProductId
GO
