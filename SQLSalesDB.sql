CREATE DATABASE SalesDB;
GO
USE SalesDB;
GO
CREATE TABLE [Buyers](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[First name] NVARCHAR(50) NOT NULL CHECK([First name] <> ''),
	[Last name] NVARCHAR(50) NOT NULL CHECK([Last name] <> '')
);
GO

CREATE TABLE [Sellers](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[First name] NVARCHAR(50) NOT NULL CHECK([First name] <> ''),
	[Last name] NVARCHAR(50) NOT NULL CHECK([Last name] <> '')
);
GO

CREATE TABLE [Sales](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[BuyerID] INT NULL,
	[SellerID] INT NULL,
	[Sales amount] MONEY NOT NULL,
	[Date amount] DATE NOT NULL,
	FOREIGN KEY ([BuyerID]) REFERENCES [Buyers](ID) On Delete Set Null,
	FOREIGN KEY ([SellerID]) REFERENCES [Sellers](ID) On Delete Set Null,
);
GO

USE SalesDB;
GO

INSERT INTO [Buyers] ([First name], [Last name])
VALUES ('John', 'Doe'),
('Jane', 'Smith'),
('Michael', 'Johnson'),
('Emily', 'Brown'),
('David', 'Taylor');
GO

INSERT INTO [Sellers] ([First name], [Last name])
VALUES ('Sarah', 'Davis'),
('Robert', 'Anderson'),
('Jennifer', 'Martinez'),
('William', 'Clark'),
('Jessica', 'Lee'),
('Daniel', 'Rodriguez'),
('Karen', 'Thomas'),
('Christopher', 'Garcia'),
('Amy', 'Wilson'),
('Kevin', 'Lopez');
GO

INSERT INTO [Sales] ([BuyerID], [SellerID], [Sales amount], [Date amount])
VALUES (1, 2, 1500.00, '2023-06-01'),
(3, 1, 2500.50, '2023-06-02'),
(2, 3, 1800.75, '2023-06-03'),
(4, 5, 1200.25, '2023-06-04'),
(1, 4, 900.50, '2023-06-05'),
(5, 2, 3000.00, '2023-06-06'),
(3, 5, 1750.25, '2023-06-07'),
(2, 1, 2200.75, '2023-06-08'),
(4, 3, 1400.50, '2023-06-09'),
(1, 5, 2800.00, '2023-06-10'),
(2, 4, 950.25, '2023-06-11'),
(3, 2, 1800.75, '2023-06-12'),
(5, 3, 2100.50, '2023-06-13'),
(4, 1, 1150.00, '2023-06-14'),
(1, 3, 3200.25, '2023-06-15'),
(2, 5, 1650.75, '2023-06-16'),
(3, 4, 1950.50, '2023-06-17'),
(5, 1, 2400.00, '2023-06-18'),
(4, 2, 850.25, '2023-06-19'),
(1, 5, 3100.75, '2023-06-20'),
(2, 3, 1750.50, '2023-06-21'),
(3, 1, 2000.00, '2023-06-22'),
(5, 4, 1325.25, '2023-06-23'),
(4, 5, 2750.75, '2023-06-24'),
(1, 2, 1400.50, '2023-06-25'),
(2, 1, 1900.00, '2023-06-26'),
(3, 5, 2250.25, '2023-06-27'),
(5, 3, 1100.75, '2023-06-28'),
(4, 2, 2950.50, '2023-06-29'),
(1, 4, 950.00, '2023-06-30');
