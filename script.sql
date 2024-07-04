CREATE DATABASE ExamenFinalOptativoIII;

USE ExamenFinalOptativoIII;

CREATE TABLE Proveedor (
    id_proveedor INT PRIMARY KEY,
    razon_social VARCHAR(255),
    tipo_documento VARCHAR(50),
    numero_documento VARCHAR(50),
	direccion VARCHAR(255),
	mail VARCHAR(50), 
    celular VARCHAR(10),
	estado VARCHAR(10)
);

CREATE TABLE Sucursal (
    id_sucursal INT PRIMARY KEY,
    descripcion VARCHAR(255),
    direccion VARCHAR(255),
    telefono VARCHAR(50),
	whatsapp VARCHAR(50),
	mail VARCHAR(50), 
	estado VARCHAR(10)
);

CREATE TABLE Pedido_Compra (
    id_pedido INT PRIMARY KEY,
    id_proveedor INT,
	id_sucursal INT,
    fecha_hora VARCHAR(50),
    total DECIMAL(10, 2),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id_proveedor),
	FOREIGN KEY (id_sucursal) REFERENCES Sucursal(id_sucursal)
);

CREATE TABLE Producto (
    id_producto INT PRIMARY KEY,
    descripcion VARCHAR(255),
    cantidad_minima INT,
	cantidad_stock INT,
    precio_compra DECIMAL(10, 2),
    precio_venta DECIMAL(10, 2),
	categoria VARCHAR(50),
	marca VARCHAR(50),
	estado VARCHAR(10),
);

CREATE TABLE Detalle_Pedido (
    id_detalle_pedido INT PRIMARY KEY,
    id_pedido INT,
    id_producto INT,
    cantidad_pedido INT,
    subtotal DECIMAL(10, 2),
    FOREIGN KEY (id_pedido) REFERENCES Pedido_Compra(id_pedido),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);