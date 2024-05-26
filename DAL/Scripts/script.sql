create database ExDyslex;
go

use ExDyslex;
go

create table Users
(
	Id int not null identity constraint PK_Users primary key,
	FirstName nvarchar(max) not null,
	LastName nvarchar(max) not null,
	PatronymicName nvarchar(max),
	Birthday datetime,
	[Password] nvarchar(max) not null,
	RoleId int not null
)

create table Clients
(
	Id int not null identity constraint PK_Clients primary key,
	FirstName nvarchar(max) not null,
	LastName nvarchar(max),
	PatronymicName nvarchar(max),
	Birthday datetime,
	Phone nvarchar(max),
	Email nvarchar(max) not null,
	[Password] nvarchar(max) not null,
	MainPhotoPath nvarchar(max)
)