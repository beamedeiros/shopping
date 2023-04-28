drop database if exists shopping;
create database shopping;
use shopping;

create table loja (
id_loja int not null auto_increment,
nome_loja varchar(255) not null,
primary key(id_loja)
);

insert into loja values(0, 'Lojas Amarelinhas');
insert into loja values(0, 'Lojas xp');

create table funcionarios(
id_func int not null auto_increment,
id_loja int not null,
nome_func varchar(255) not null,
rg_func varchar(255) not null,
cpf_func varchar(255) not null,
foto_func varchar(255) not null,
classificacao varchar(255) not null,
codigo_barras varchar(255) not null,
data_nasc datetime not null,
primary key(id_func),
foreign key(id_loja) references loja(id_loja)
);


create table clientes(
id_cliente int not null auto_increment,
codigo_barras int not null,
primary key(id_cliente)
);