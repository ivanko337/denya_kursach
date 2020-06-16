-- CREATE DATABASE Kursach;
-- GO
USE Kursach;
GO

DROP TABLE IF EXISTS ProductsOrders;
DROP TABLE IF EXISTS IngridientsProducts;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Ingredients;
DROP TABLE IF EXISTS ProductsTypes;
DROP TABLE IF EXISTS IngredientsTypes;
DROP TABLE IF EXISTS Users;
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
	product_image_path NVARCHAR(MAX) NOT NULL,
	FOREIGN KEY(product_type) REFERENCES ProductsTypes(id)
);

CREATE TABLE Orders(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	discount INT NOT NULL DEFAULT 0,
	isCompleted BIT NOT NULL DEFAULT 0,
	isGiven BIT NOT NULL DEFAULT 0, -- отдали ли заказ покупателю
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

CREATE TABLE Users(
	[hash] NVARCHAR(32) PRIMARY KEY
);

INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'мясо');  -- 1
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'рыба');  -- 2
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'овощ');  -- 3
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'фрукт'); -- 4
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'соус');  -- 5
INSERT INTO IngredientsTypes(ingredient_type_name) VALUES (N'хлебо-булочные изделия'); -- 6

INSERT INTO ProductsTypes(product_type_name) VALUES (N'шаурма');
INSERT INTO ProductsTypes(product_type_name) VALUES (N'бургер');
INSERT INTO ProductsTypes(product_type_name) VALUES (N'суп');

INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (1, N'кебаб куриный', 300); -- 1
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (6, N'лаваш', 70); -- 2
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (3, N'огурец', 40); -- 3
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'кетчуп', 20); -- 4
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'майонез', 20); -- 5
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'курица', 150); -- 6
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'яйцо', 100); -- 7
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'чипсы', 20); -- 8
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'чеснок', 20); -- 9
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (5, N'стейк', 400); -- 10

INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (1, N'котлета говяжья', 200); -- 6
INSERT INTO Ingredients(i_group, i_name, i_weight) VALUES (6, N'булка', 50); -- 7

INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'Шаурма Стандарт', 6, 1, N'/Kursach;component/Resources/sheurma_standart.jpg');
INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'Гамбургер Стандарт', 6, 2, N'/Kursach;component/Resources/hamburger_standart.jpg');
INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'Куриный суп', 12, 3, N'https://ms1.relax.by/images/5da23058500fe4a6857e31cd0906d449/resize/w=1200,h=800,q=80,watermark=true/place_gallery_photo/40/23/70/4023700d36949269770cfab919839bf5.jpg');
INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'Грибной суп', 12, 3, N'/Kursach;component/Resources/hamburger_standart.jpg');
INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'Завтрак Стандарт', 6, 2, N'https://ms1.relax.by/images/5da23058500fe4a6857e31cd0906d449/resize/w=1200,h=800,q=80,watermark=true/place_gallery_photo/4a/b2/77/4ab2774f6af0a6747fa19d7f01409df3.jpg');
INSERT INTO Products(p_name, p_price, product_type, product_image_path) VALUES(N'Стейк', 6, 2, N'https://ms1.relax.by/images/5da23058500fe4a6857e31cd0906d449/resize/w=1200,h=800,q=80,watermark=true/place_gallery_photo/c3/4d/c7/c34dc776cf377a129b9fc17464aec570.jpg');

INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 1);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 2);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 3);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 4);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (1, 5);

INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 6);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 7);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 4);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (2, 5);

INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (3, 6);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (3, 7);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (3, 8);

INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (4, 10);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (4, 9);
INSERT INTO IngridientsProducts(product_id, ingredient_id) VALUES (4, 8);

INSERT INTO Orders(order_date) VALUES (GETDATE());
INSERT INTO Orders(order_date) VALUES (GETDATE());
INSERT INTO Orders(order_date) VALUES (GETDATE());
INSERT INTO Orders(order_date) VALUES (GETDATE());

INSERT INTO ProductsOrders(order_id, product_id) VALUES(1, 1);

-- admin:admin
INSERT INTO Users([hash]) VALUES (N'D2ABAA37A7C3DB1137D385E1D8C15FD2');