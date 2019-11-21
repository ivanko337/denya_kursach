USE Kursach;
GO

DROP TABLE IF EXISTS ProductsOrders;
DROP TABLE IF EXISTS IngridientsProducts;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Ingredients;
DROP TABLE IF EXISTS ProductsTypes;
DROP TABLE IF EXISTS IngredientsTypes;
GO

CREATE TABLE IngredientsTypes(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ingredient_type_name NVARCHAR(100) NOT NULL
);

CREATE TABLE ProductsTypes(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	product_type_name NVARCHAR(100) NOT NULL
);

CREATE TABLE Ingredients(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	i_name NVARCHAR(100) NOT NULL,
	i_group INT NOT NULL,
	i_weight DECIMAL(5, 2) NOT NULL,
	FOREIGN KEY (i_group) REFERENCES IngredientsTypes(id)
);

CREATE TABLE Products(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	p_name NVARCHAR(100) NOT NULL,
	p_price DECIMAL(10, 2) NOT NULL,
	product_type INT NOT NULL,
	product_image_path NVARCHAR(100) NOT NULL,
	FOREIGN KEY(product_type) REFERENCES ProductsTypes(id)
);

CREATE TABLE Orders(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	discount INT NOT NULL DEFAULT 0,
	isCompleted BIT NOT NULL DEFAULT 0,
	order_date DATETIME NOT NULL
);

CREATE TABLE IngridientsProducts(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	ingredient_id INT NOT NULL,
	product_id INT NOT NULL,
	FOREIGN KEY(ingredient_id) REFERENCES Ingredients(id),
	FOREIGN KEY(product_id) REFERENCES Products(id)
);

CREATE TABLE ProductsOrders(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	product_id INT NOT NULL,
	order_id INT NOT NULL,
	FOREIGN KEY(product_id) REFERENCES Products(id),
	FOREIGN KEY(order_id) REFERENCES Orders(id)
);

INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'мясо');  -- 1
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'рыба');  -- 2
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'овощ');  -- 3
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'фрукт'); -- 4
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'соус');  -- 5
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'хлебо-булочные изделия'); -- 6

INSERT INTO ProductsTypes(product_type_name) VALUES (N'шаурма');

INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (1, N'кебаб куриный', 300);
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (6, N'лаваш', 70);
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (3, N'огурец', 40);
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'кепчук', 20);
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'мазик', 20);

INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'шавуха стандарт', 6, 1, N'');
INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'шавуха нестандарт', 10, 1, N'');

INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 1);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 2);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 3);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 4);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 5);

INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 1);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 2);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 3);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 4);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 5);

INSERT INTO Orders(order_date) VALUES (GETDATE());

INSERT INTO ProductsOrders(order_id, product_id) VALUES(1, 1);
INSERT INTO ProductsOrders(order_id, product_id) VALUES(1, 2);
GO

SELECT po.order_id AS OrderID, p.p_name AS ProductName FROM ProductsOrders po
		JOIN Products p ON  (po.product_id = p.id);

SELECT p.p_name, i.i_name, i.i_weight FROM IngridientsProducts t
		JOIN Products p ON (t.product_id = p.id)
		JOIN Ingredients i ON (t.ingredient_id = i.id);

SELECT Products.p_name, Products.p_price, ProductsTypes.product_type_name FROM IngridientsProducts t
		JOIN Products ON (t.product_id = Products.id)
		JOIN Ingredients ON (t.ingredient_id = Ingredients.id)
		JOIN ProductsTypes ON (Products.product_type = ProductsTypes.id)
		WHERE Ingredients.i_group = 3;