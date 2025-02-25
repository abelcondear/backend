USE [products]
GO

----

DELETE FROM Clients
DELETE FROM Products
DELETE FROM Sales
DELETE FROM SaleItems

---

--SET IDENTITY_INSERT Clients OFF
INSERT INTO Clients(Id, [Name], Phone, Mail) 
VALUES(1, 'Coke', '+1 574 235 1154', 'coke.rrhh@coke.com')

INSERT INTO Clients (Id, [Name], Phone, Mail) 
VALUES(2, 'Pepsi', '+1 574 745 5547', 'pepsi.rrhh@pepsi.com')

-----

--SET IDENTITY_INSERT Products OFF
INSERT INTO Products(Id,[Name], Price, Category) 
values(1, 'Coke Zero', 1.95, 'Soda')

INSERT INTO Products(Id,[Name], Price, Category)
VALUES(2,'Coke Classic', 1.59, 'Soda')

INSERT INTO Products(Id,[Name], Price, Category)
VALUES(3,'Pepsi Zero', 1.85, 'Soda')

INSERT INTO Products(Id,[Name], Price, Category)
VALUES(4,'Pepsi Classic', 1.75, 'Soda')

---

--SET IDENTITY_INSERT Sales OFF
--SET IDENTITY_INSERT Sales ON
INSERT INTO Sales (Id, IdClient, [Date], Total)
VALUES(1, 1, '2024-11-29 17:00:00', 27.45)

INSERT INTO Sales (Id, IdClient, [Date], Total)
VALUES(2, 2, '2024-11-29 13:45:00', 40.5)

---

--SET IDENTITY_INSERT SaleItems OFF
--SET IDENTITY_INSERT SaleItems ON
INSERT INTO SaleItems 
(Id, IdSale, IdProduct, UnitPrice, Quantity, TotalPrice)
VALUES(1, 1, 1, 1.95, 10, 19.5)

INSERT INTO SaleItems 
(Id, IdSale, IdProduct, UnitPrice, Quantity, TotalPrice)
VALUES(2, 1, 2, 1.59, 5, 7.95)


INSERT INTO SaleItems 
(Id, IdSale, IdProduct, UnitPrice, Quantity, TotalPrice)
VALUES(3, 2, 3, 1.85, 20, 37.0)


INSERT INTO SaleItems 
(Id, IdSale, IdProduct, UnitPrice, Quantity, TotalPrice)
VALUES(4, 2, 4, 1.75, 2, 3.5)

---

/* ****************************

SELECT * FROM Sales
SELECT * FROM Products
SELECT * FROM SaleItems
SELECT * FROM Clients

***************************** */