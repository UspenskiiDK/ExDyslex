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
go

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
go

create table Tasks(
Id int not null identity constraint PK_Tasks primary key,
TaskCategory int not null,
TaskQuestion nvarchar(max) not null,
AnswerOption1 nvarchar(max),
AnswerOption2 nvarchar(max),
AnswerOption3 nvarchar(max),
AnswerOption4 nvarchar(max)
)
go

create table Tests(
Id int not null identity constraint PK_Tests primary key,
[Name] nvarchar(max) not null,
ImagePath nvarchar(max),
)
go

create table TasksToTests(
Id int not null identity constraint PK_TasksToTests primary key,
TaskId int not null constraint FK_TasksToTests_Tasks foreign key references Tasks(Id),
TestId int not null constraint FK_TasksToTests_Tests foreign key references Tests(Id),
)
go

create table TestsToClients(
Id int not null identity constraint PK_TestsToClients primary key,
TestId int not null constraint FK_TestsToClients_Tests foreign key references Tests(Id),
ClientId int not null constraint FK_TestsToClients_Clients foreign key references Clients(Id),
TaskId int not null constraint FK_TestsToClients_Tasks foreign key references Tasks(Id),
Answer nvarchar(max),
Grade int
)
go