Toda vez que visualizar pedidos, estoque ou pegar o resumo geral, irá criar um JSON ou atualizar o anterior. O nome do arquivo e seu formato já estão definidos nos arquivos de resquest, mas o diretório precisa ser alterado. (Está na pasta JSON>JsonSerialize.cs)


==================================
Atividade realizada usando MySql.
==================================

CREATE TABLE STORES
	(
        store_id INT PRIMARY KEY,
        store_name VARCHAR(50)
    );
CREATE TABLE PRODUCTS
	(
        product_id INT PRIMARY KEY,
        product_name VARCHAR(50),
        product_price DOUBLE
    );
CREATE TABLE STOCK 
	(
        product_id INT,
        product_quantity INT,
        store_id INT
    );
ALTER TABLE STOCK
ADD FOREIGN KEY (product_id) REFERENCES Products(product_id),
ADD FOREIGN KEY (store_id) REFERENCES Stores(store_id);


INSERT INTO PRODUCTS VALUES (11, "Camisa X", 30.00), (12, "Camisa Y", 40.00), (13, "Camisa Z", 50.00),
                            (14, "Moletom X", 100.00), (15, "Moletom Y", 110.00), (16, "Moletom Z", 120.00);
INSERT INTO STORES VALUES (123, "CiA Vitória"), (456, "CiA Vila Velha"), (789, "CiA Cariacica");
INSERT INTO STOCK VALUES  (11, 40, 123), (11, 60, 456), (11, 10, 789),
						  (12, 10, 123),
                          (13, 40, 123), (13, 65, 789),
                          (14, 75, 123), (14, 72, 456),
                          (15, 20, 789),
                          (16, 45, 456);

CREATE TABLE Orders
(
   order_id INT PRIMARY KEY,
   customer_id INT,
   order_amount DOUBLE,
   order_status VARCHAR(30)
);
CREATE TABLE Customers
	(
        customer_id INT PRIMARY KEY,
        customer_name VARCHAR(80)
    );
CREATE TABLE Orderitem
(
    order_id INT,
    product_id INT,
    product_quantity INT,
    product_price DOUBLE
    
);

INSERT INTO Customers VALUES (4185418, "Marcio Arroba"), (541564156, "Juliano Banana"), (565414415, "Marcio do Pneu");
INSERT INTO Orders VALUES (111, 4185418, 150.00, "envio pendente"), (222, 541564156, 500, "envio pendente"), (333, 565414415, 35.00, "Despachado para entrega");
INSERT INTO OrderItem VALUES (111, 11, 2, 60.00), (111, 14, 1, 90.00), (222, 15, 2, 220.00), (222, 12, 4, 160.00), (222, 16, 1, 120.00), (333, 13, 1, 35.00);


