create database my_finance;
use my_finance

create table account_plans(
	id int identity(1,1) not null,
	description  varchar(50) not null,
	type  char(1) not null,
	primary key(id)
);

create table PAYMENT_METHOD(
	id int identity(1,1) not null,
	description varchar(50) not null,
	primary key(id)
);

create table transactions(
	id bigint identity(1,1) not null,
	date  datetime not null,
	value  decimal(18,2) not null,
	type  char(1) not null,
	history  text null,
	account_plan_id  int not null,
	PAYMENT_METHOD_ID int not null,
	primary key(id),
	foreign key(account_plan_id) references account_plans,
	foreign key(PAYMENT_METHOD_ID) references PAYMENT_METHOD
);

insert into account_plans(description, type) values('Salário','R');
insert into account_plans(description, type) values('Aluguel','D');
insert into account_plans(description, type) values('Alimentação','D');
insert into account_plans(description, type) values('Combustivel','D');
insert into account_plans(description, type) values('Viagens','D');
insert into account_plans(description, type) values('Luz','D');
insert into account_plans(description, type) values('Água','D');
insert into account_plans(description, type) values('Internet','D');

insert into PAYMENT_METHOD(description) values('Dinheiro');
insert into PAYMENT_METHOD(description) values('Débito');
insert into PAYMENT_METHOD(description) values('Crédito');
insert into PAYMENT_METHOD(description) values('Pix');
insert into PAYMENT_METHOD(description) values('Boleto');
insert into PAYMENT_METHOD(description) values('');