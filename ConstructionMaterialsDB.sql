CREATE DATABASE [ShopForConstructionMaterials]
CREATE TABLE [Categories]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(100) UNIQUE
)
CREATE TABLE [Products]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(100) UNIQUE,
[price]DECIMAL(10,2),
[categories_id] INT FOREIGN KEY REFERENCES Categories([id])
)

CREATE TABLE [Suppliers]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(100) UNIQUE,
[contact_info] VARCHAR(200)
)

CREATE TABLE [Customers]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(100) UNIQUE,
[phone] VARCHAR(20) UNIQUE
)

CREATE TABLE [Orders]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[customer_id] INT FOREIGN KEY REFERENCES Customers([id]),
[order_date] DATETIME,
[total_price] DECIMAL(10,2)
)

CREATE TABLE [OrderDetails]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[order_id] INT FOREIGN KEY REFERENCES Orders([id]),
[product_id] INT FOREIGN KEY REFERENCES Products([id]),
[quantity] INT NOT NULL
)

CREATE TABLE [SupplierProducts]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[supplier_id] INT FOREIGN KEY REFERENCES Suppliers([id]),
[product_id] INT FOREIGN KEY REFERENCES Products([id]),
[supply_price] DECIMAL(10,2)
)
CREATE TABLE [Employees]
(
[id] INT PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(100),
[position] VARCHAR(50)
)
INSERT INTO Categories (name) VALUES ('Бои и лакове'), ('Цимент и лепила'), ('Инструменти');

INSERT INTO Products (name, price, categories_id) VALUES ('Бяла боя', 12.50, 1), ('Цимент 25кг', 9.80, 2), ('Чук 500г', 15.00, 3);

INSERT INTO Suppliers (name, contact_info) VALUES ('Строител ООД', 'ул. Индустриална 5, София'), ('БГ Материали', 'бул. България 12, Пловдив');

INSERT INTO Customers (name, phone) VALUES ('Иван Петров', '0888123456'), ('Мария Иванова', '0899765432');

INSERT INTO Orders (customer_id, order_date, total_price) VALUES (1, '2025-03-16 10:30:00', 22.30), (2, '2025-03-16 11:45:00', 15.00);

INSERT INTO OrderDetails (order_id, product_id, quantity) VALUES (1, 1, 1), (1, 2, 1), (2, 3, 1);

INSERT INTO SupplierProducts (supplier_id, product_id, supply_price) VALUES (1, 1, 10.00), (2, 2, 8.50);

INSERT INTO Employees (name, position) VALUES ('Георги Димитров', 'Касиер'), ('Петър Николов', 'Управител');

