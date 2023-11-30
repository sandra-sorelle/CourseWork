use master
go
create database [PC Club]
go
use [PC Club]
go

create table [EmployeeRole]
(
	[employeerole_id] int primary key identity,
	[employeerole_name] nvarchar (20) not null
)

create table [ProductType]
(
	[producttype_id] int primary key identity,
	[producttype_name] nvarchar (20) not null
)

create table [PaymentMethod]
(
	[paymentmethod_id] int primary key identity,
	[paymentmethod_name] nvarchar (20) not null
)

create table [User]
(
	[user_id] nvarchar (20) primary key,
	[user_money] money not null,
	[user_name] nvarchar (20),
	[user_surname] nvarchar (20),
	[user_phone] nvarchar (20),
	[user_birthday] date
)

create table Product
(
	[product_id] nvarchar (20) primary key,
	[product_name] nvarchar (50) not null,
	[product_quantityinstock] int not null,
	[product_price] money not null,
	[product_producttype] int references [ProductType]([producttype_id]),
	[product_photo] varbinary(max),
	[product_photopath] nvarchar (100),
	[product_sellthisworkshift] int not null
)

create table Employee
(
	[employee_id] nvarchar (20) primary key,
	[employee_name] nvarchar (20) not null,
	[employee_surname] nvarchar (20) not null,
	[employee_patronymic] nvarchar (30),
	[employee_phone] nvarchar (20) not null,
	[employee_login] nvarchar (20) not null,
	[employee_password] nvarchar (20) not null,
	[employee_authorization] bit,
	[employee_role] int references [EmployeeRole]([employeerole_id]),
)

create table [ComputerStandart]
(
	[computerstandart_id] nvarchar (20) primary key,
	[computerstandart_datetime] datetime
)

create table [ComputerVIP]
(
	[computervip_id] nvarchar (20) primary key,
	[computervip_datetime] datetime
)

create table [Order]
(
	[order_id] int primary key identity,
	[order_totalmoney] money not null,
	[order_paymentmethod] int references [PaymentMethod]([paymentmethod_id])
)

create table [OrderProduct]
(
	[orderproduct_id] int primary key identity,
	[orderproduct_order] int references [Order]([order_id]),
	[orderproduct_product] nvarchar (20) references [Product]([product_id]),
	[orderproduct_quantity] int not null,
	[orderproduct_totalmoney] money not null
)

create table [Report]
(
	[report_id] int primary key identity,
	[report_datetimeopening] datetime not null,
	[report_datetimeclosure] datetime,
	[report_workingtime] nvarchar(20),
	[report_employee] nvarchar (20) references [Employee]([employee_id]),
	[report_totalmoney] int
)

create table [Games]
(
	game_id int primary key identity,
	game_name nvarchar (100),
	game_photo varbinary(max),
	game_photopath nvarchar (100)
)