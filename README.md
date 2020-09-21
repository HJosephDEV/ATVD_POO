Toda vez que visualizar pedidos, estoque ou pegar o resumo geral, irá criar um JSON ou atualizar o anterior. O nome do arquivo e seu formato já estão definidos nos arquivos de resquest, mas o diretório precisa ser alterado. (Está na pasta JSON>JsonSerialize.cs)<br>


==================================<br>
Atividade realizada usando MySql.<br>
==================================<br>

CREATE TABLE STORES<br>
	(<br>
        store_id INT PRIMARY KEY,<br>
        store_name VARCHAR(50)<br>
    );<br>
CREATE TABLE PRODUCTS<br>
	(<br>
        product_id INT PRIMARY KEY,<br>
        product_name VARCHAR(50),<br>
        product_price DOUBLE<br>
    );<br>
CREATE TABLE STOCK <br>
	(<br>
        product_id INT,<br>
        product_quantity INT,<br>
        store_id INT<br>
    );<br>
ALTER TABLE STOCK<br>
ADD FOREIGN KEY (product_id) REFERENCES Products(product_id),<br>
ADD FOREIGN KEY (store_id) REFERENCES Stores(store_id);<br>


INSERT INTO PRODUCTS VALUES (11, "Camisa X", 30.00), (12, "Camisa Y", 40.00), (13, "Camisa Z", 50.00),<br>
                            (14, "Moletom X", 100.00), (15, "Moletom Y", 110.00), (16, "Moletom Z", 120.00);<br>
INSERT INTO STORES VALUES (123, "CiA Vitoria"), (456, "CiA Vila Velha"), (789, "CiA Cariacica");<br>
INSERT INTO STOCK VALUES  (11, 40, 123), (11, 60, 456), (11, 10, 789),<br>
						  (12, 10, 123),<br>
                          (13, 40, 123), (13, 65, 789),<br>
                          (14, 75, 123), (14, 72, 456),<br>
                          (15, 20, 789),<br>
                          (16, 45, 456);<br>

CREATE TABLE Orders<br>
(<br>
   order_id INT PRIMARY KEY,<br>
   customer_id INT,<br>
   order_amount DOUBLE,<br>
   order_status VARCHAR(30)<br>
);<br>
CREATE TABLE Customers<br>
	(<br>
        customer_id INT PRIMARY KEY,<br>
        customer_name VARCHAR(80)<br>
    );<br>
CREATE TABLE Orderitem<br>
(<br>
    order_id INT,<br>
    product_id INT,<br>
    product_quantity INT,<br>
    product_price DOUBLE<br>
);<br>

INSERT INTO Customers VALUES (4185418, "Marcio Arroba"), (541564156, "Juliano Banana"), (565414415, "Marcio do Pneu");<br>
INSERT INTO Orders VALUES (111, 4185418, 150.00, "envio pendente"), (222, 541564156, 500, "envio pendente"), (333, 565414415, 35.00, "Despachado para entrega");<br>
INSERT INTO OrderItem VALUES (111, 11, 2, 60.00), (111, 14, 1, 90.00), (222, 15, 2, 220.00), (222, 12, 4, 160.00), (222, 16, 1, 120.00), (333, 13, 1, 35.00);


