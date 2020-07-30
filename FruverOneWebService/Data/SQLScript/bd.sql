CREATE TABLE USUARIO(
	ID INT,
	NOMBRE CHAR(15),
	EMAIL CHAR(20)	
);
INSERT INTO usuario(id, nombre, email) VALUES ( 123, 'Leonardo', 'leo@gmail.com');
INSERT INTO usuario(id, nombre, email) VALUES ( 124, 'Esteban', 'Esteban@gmail.com');	
	
SELECT * FROM USUARIO;
	
CREATE TABLE PRODUCTOS(
	COD CHAR(7),
	NOMBRE CHAR(15),
	CANTIDAD NUMERIC(10),
	DESCRIPCION CHAR(30),
	COSTO NUMERIC(10,2)
);

/*DROP TABLE PRODUCTOS;*/
INSERT INTO PRODUCTOS VALUES('SA123', 'Ariel', 5,'Jabón en polvo 500 gr', 500.0 );
INSERT INTO PRODUCTOS VALUES('SA768', 'Coca-Cola', 24,'Gasesosa Lite 250ml', 2500.0 );
INSERT INTO PRODUCTOS VALUES('SA909', 'Frijoles', 37,'Pura sangre 500 gr', 1200.0 );
INSERT INTO PRODUCTOS VALUES('SA233', 'Panela', 20,'Caña azúcar 1000 gr', 3200.0 );

SELECT * FROM PRODUCTOS;
UPDATE PRODUCTOS SET NOMBRE='Ariel en Polvo' WHERE COD ='SA123';
DELETE FROM PRODUCTOS WHERE COD='SA123';