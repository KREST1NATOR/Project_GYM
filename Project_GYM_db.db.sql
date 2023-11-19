BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Client" (
	"Client ID"	INTEGER NOT NULL UNIQUE,
	"Surname"	TEXT NOT NULL CHECK(LENGTH("Surname") < 50),
	"First name"	TEXT NOT NULL CHECK(LENGTH("First name") < 30),
	"Patronymic"	TEXT CHECK(LENGTH("Patronymic") < 50),
	"Gender"	TEXT NOT NULL CHECK(LENGTH("Gender") < 8),
	"Date of birth"	TEXT NOT NULL CHECK(LENGTH("Date of birth") < 30),
	"Discount ID"	INTEGER NOT NULL,
	"ID Gym"	INTEGER NOT NULL UNIQUE,
	FOREIGN KEY("Discount ID") REFERENCES "Discount"("Discount ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("ID Gym") REFERENCES "Gym"("ID gym") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("Client ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Discount" (
	"Discount ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 50) UNIQUE,
	"Value"	NUMERIC NOT NULL UNIQUE,
	PRIMARY KEY("Discount ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Employee" (
	"Employee ID"	INTEGER NOT NULL UNIQUE,
	"Surname"	TEXT NOT NULL CHECK(LENGTH("Surname") < 50),
	"First name"	TEXT NOT NULL CHECK(LENGTH("First name") < 30),
	"Patronymic"	TEXT CHECK(LENGTH("Patronymic") < 50),
	"Date of birth"	TEXT CHECK(LENGTH("Date of birth") < 30),
	"Gender"	TEXT NOT NULL CHECK(LENGTH("Gender") < 8),
	"Length of service"	NUMERIC NOT NULL,
	"Job_title_ID"	INTEGER NOT NULL,
	"ID Gym"	INTEGER NOT NULL,
	FOREIGN KEY("Job_title_ID") REFERENCES "Job title"("Job title ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("ID Gym") REFERENCES "Gym"("ID gym") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("Employee ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Gym" (
	"ID gym"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 50) UNIQUE,
	"Address"	TEXT NOT NULL CHECK(LENGTH("Address") < 50) UNIQUE,
	"Start time"	TEXT NOT NULL CHECK(LENGTH("Start time") < 30),
	"End time"	TEXT NOT NULL CHECK(LENGTH("End time") < 30),
	PRIMARY KEY("ID gym" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Job title" (
	"Job title ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 50) UNIQUE,
	"Salary"	NUMERIC NOT NULL,
	"Work schedule"	NUMERIC NOT NULL,
	PRIMARY KEY("Job title ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Product" (
	"Product ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 50) UNIQUE,
	"Price"	NUMERIC NOT NULL,
	"Quantity"	NUMERIC NOT NULL,
	"Expiration date"	TEXT NOT NULL CHECK(LENGTH("Expiration date") < 30),
	"Product category ID"	INTEGER NOT NULL UNIQUE,
	"ID Gym"	INTEGER NOT NULL UNIQUE,
	FOREIGN KEY("Product category ID") REFERENCES "Product category"("Category ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("ID Gym") REFERENCES "Gym"("ID gym") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("Product ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Product category" (
	"Category ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 50) UNIQUE,
	PRIMARY KEY("Category ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Status" (
	"Status ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 50) UNIQUE,
	PRIMARY KEY("Status ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Subscription type" (
	"Subscription type ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 50) UNIQUE,
	"Cost"	NUMERIC NOT NULL UNIQUE,
	"Term"	NUMERIC NOT NULL,
	PRIMARY KEY("Subscription type ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Trainer" (
	"Trainer ID"	INTEGER NOT NULL UNIQUE,
	"Surname"	TEXT NOT NULL CHECK(LENGTH("Surname") < 50),
	"First name"	TEXT NOT NULL CHECK(LENGTH("First name") < 30),
	"Patronymic"	TEXT CHECK(LENGTH("Patronymic") < 50),
	"Date of birth"	TEXT NOT NULL CHECK(LENGTH("Date of birth") < 30),
	"Length of service"	NUMERIC NOT NULL,
	"ID Gym"	INTEGER NOT NULL,
	FOREIGN KEY("ID Gym") REFERENCES "Gym"("ID gym") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("Trainer ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Subscription" (
	"Subscription ID"	INTEGER NOT NULL UNIQUE,
	"Start date"	TEXT NOT NULL CHECK(LENGTH("Start date") < 30),
	"End date"	TEXT NOT NULL CHECK(LENGTH("Expiration date") < 30),
	"Status ID"	INTEGER NOT NULL,
	"Subscription_type_ID"	INTEGER NOT NULL,
	"ID Gym"	INTEGER NOT NULL,
	"Client ID"	INTEGER NOT NULL,
	"Trainer ID"	INTEGER,
	FOREIGN KEY("Status ID") REFERENCES "Status"("Status ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Subscription_type_ID") REFERENCES "Subscription type"("Subscription type ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Trainer ID") REFERENCES "Trainer"("Trainer ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("ID Gym") REFERENCES "Gym"("ID gym") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Client ID") REFERENCES "Client"("Client ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("Subscription ID" AUTOINCREMENT)
);
INSERT INTO "Client" ("Client ID","Surname","First name","Patronymic","Gender","Date of birth","Discount ID","ID Gym") VALUES (1,'Калинин','Иван','Олегович','Мужской','12.04.2000',1,1),
 (2,'Дмитрий','Голубочкин',NULL,'Мужской','31.12.1896',1,3),
 (3,'Пупочкин','Роман','Владимирович','Мужской','04.03.1999',3,2),
 (4,'Лохницкая','Лилия',NULL,'Женский','13.07.1460',2,5),
 (5,'Мамаева','Виктория','Геогриевна','Женский','11.11.2003',3,4);
INSERT INTO "Discount" ("Discount ID","Name","Value") VALUES (1,'Отсутствует',0),
 (2,'Пенсионная',1000),
 (3,'Инвалидная',500);
INSERT INTO "Employee" ("Employee ID","Surname","First name","Patronymic","Date of birth","Gender","Length of service","Job_title_ID","ID Gym") VALUES (1,'Цыганов','Кирилл','Николаевич','23.12.2003','Мужской',2,5,1),
 (2,'Сафарян','Алла','Арамовна','05.07.2004','Женский',3,1,3),
 (3,'Салаев','Роман','Владимирович','05.06.2004','Мужской',1.5,2,1),
 (4,'Максим','Рудак','Сергеевич','31.01.2004','Мужской',3,6,3),
 (5,'Масаев','Кирилл','Николаевич','23.12.2003','Мужской',2,6,1);
INSERT INTO "Gym" ("ID gym","Name","Address","Start time","End time") VALUES (1,'Олимп','Ул. Ленина, 149','06:30','00:00'),
 (2,'Шуруповерт','Мкр-н. Давыдовский-1, 2А','06:30','00:00'),
 (3,'Крестьянский скворец','Ул. Советская, 114','06:30','00:00'),
 (4,'Не ФОР','Мкр-н. Венеция, 69','06:30','00:00'),
 (5,'Мет орех','Ул. Симановского, 33','06:30','00:00');
INSERT INTO "Job title" ("Job title ID","Title","Salary","Work schedule") VALUES (1,'Администратор-1(1 смена)',25000,'06:30-15:00'),
 (2,'Администратор-2(1 смена)',20000,'06:30-15:00'),
 (3,'Администратор-1(2 смена)',25000,'15:00-00:00'),
 (4,'Администратор-2(2 смена)',20000,'15:00-00:00'),
 (5,'Уборщик(1 смена)',15000,'06:30-15:00'),
 (6,'Уборщик(2 смена)',15000,'15:00-00:00');
INSERT INTO "Product" ("Product ID","Name","Price","Quantity","Expiration date","Product category ID","ID Gym") VALUES (1,'Промышц',1499,100,'3 года',1,1),
 (2,'МассаАП',399,500,'1 год',2,2),
 (3,'НетГрыж',5099,10,'Неограниченно',3,3),
 (4,'Зацеп+',499,200,'Неограниченно',4,4),
 (5,'Ген+',699,199,'1 месяца',5,5);
INSERT INTO "Product category" ("Category ID","Name") VALUES (1,'Креатин'),
 (2,'Протеиновый батончик'),
 (3,'Ремень'),
 (4,'Лямки'),
 (5,'Гейнер');
INSERT INTO "Status" ("Status ID","Name") VALUES (1,'Активный'),
 (2,'Не активный');
INSERT INTO "Subscription type" ("Subscription type ID","Name","Cost","Term") VALUES (1,'Хилый',2700,1),
 (2,'Бывалый',7200,3),
 (3,'Силач',11900,6),
 (4,'Викинг',18900,12),
 (5,'Студенческий',1900,1);
INSERT INTO "Trainer" ("Trainer ID","Surname","First name","Patronymic","Date of birth","Length of service","ID Gym") VALUES (1,'Масаев-Цыганов','Кирилл','Николаевич','23.12.2003',2,1),
 (2,'Смирнов','Роман','Владимирович','05.06.2004',0.5,3),
 (3,'Вульвович','Алексей','Семенович','02.02.0008',2000,2),
 (4,'Мамонтов','Олег',NULL,'01.01.1337',300,5),
 (5,'Волков','Иван','Сергеевич','19.06.1989',10,4);
INSERT INTO "Subscription" ("Subscription ID","Start date","End date","Status ID","Subscription_type_ID","ID Gym","Client ID","Trainer ID") VALUES (1,'12.05.2023','12.06.2023',2,5,1,1,3),
 (2,'09.11.2023','09.12.2023',1,1,3,2,NULL),
 (3,'11.09.2023','11.09.2024',1,4,2,3,4),
 (4,'05.05.2023','05.08.2023',2,2,5,4,1),
 (5,'01.09.2023','01.03.2024',1,3,4,5,2);
COMMIT;
