create database dbgestors;
go
use dbgestors;

go
create table gestors(
id int primary key identity,
name varchar(50) not null,
release date not null,
dev_company varchar(50) not null
)

go

insert into gestors values ('Mysql','1995','Oracle Corporation'), ('Sql Server','1985','Microsoft'),
('PostgreSql','1996','PosgreSql Corporation'), ('MongoDb','2009','MongoDb Inc.')