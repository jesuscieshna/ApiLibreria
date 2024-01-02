create table autor(
id int not null auto_increment,
nombre varchar(40),
primary key(id));

DELIMITER $$
CREATE OR REPLACE PROCEDURE getAutores()
BEGIN
  SELECT * FROM Autor;
END $$
DELIMITER ;

create table edicion(
id int not null auto_increment,
nombre varchar(20),
primary key(id));

DELIMITER $$
CREATE OR REPLACE PROCEDURE getEdiciones()
BEGIN
  SELECT * FROM edicion;
END $$
DELIMITER ;

Delimiter $$
create or replace procedure postEdicion(in name varchar(20))
Begin
insert into edicion(nombre) values(name);
end $$
delimiter ;

create table Formato(
id int not null auto_increment,
nombre varchar(20) unique,
primary key(id));

DELIMITER $$
CREATE OR REPLACE PROCEDURE getFormatos()
BEGIN
  SELECT * FROM Formato;
END $$
DELIMITER ;