create table companies
(
	id serial primary key,
	name varchar(255) not null,
	address text not null,
	phone varchar(50) not null,
	email varchar(255) not null,
	createdAt timestamp,
	updatedAt timestamp
)


create table menus
(
	id serial primary key,
	menuDate timestamp not null,
	isActive bool,
	createdAt timestamp,
	updatedAt timestamp
)

create table menu_items
(
	id serial primary key,
	menuId int references menus(id),
	name varchar(255) not null,
	description text,
	price numeric(10,2) not null,
	category varchar(50) not null,
	createdAt timestamp,
	updatedAt timestamp
)


create table subscriptions
(
	id serial primary key,
	companyId int references companies(id),
	planType varchar(50) not null,
	mealsPerDay int not null,
	price numeric(10,2) not null,
	startDate  	timestamp NOT NULL,
	endDate     timestamp NOT NULL,
	isActive    BOOl,      
	created_at	TIMESTAMP,    
	updated_at	TIMESTAMP    
)


create table orders
(
	id          SERIAL PRIMARY KEY,     
	companyId   INTEGER references companies(id),
	orderDate   timestamp NOT NULL,         
	status      VARCHAR(50) NOT NULL,  
	totalAmount DECIMAL(10,2) NOT NULL,
	createdAt   TIMESTAMP,             
	updatedAt   TIMESTAMP             
)


create table order_items
(
 	id          SERIAL PRIMARY KEY,    
 	orderId     INTEGER  references orders(id),
 	menuItemId  INTEGER  references menu_items(id),
 	quantity    INTEGER NOT NULL,      
 	price       DECIMAL(10,2) NOT NULL,
 	createdAt   TIMESTAMP,             
 	updatedAt   TIMESTAMP             
)



INSERT INTO companies (name, address, phone, email, createdAt, updatedAt) VALUES
('ООО Азия Фуд', 'Душанбе, Рудаки 45', '+992 900 123 456', 'asiafood@email.com', NOW(), NOW()),
('ИП Сайфулло', 'Худжанд, Ленина 12', '+992 927 555 777', 'saifullo@bk.ru', NOW(), NOW()),
('Smart Kitchen TJ', 'Душанбе, Шохмансур', '+992 917 888 999', 'smartkitchen@gmail.com', NOW(), NOW()),
('Delicious Food', 'Душанбе, Исмоили Сомони 67', '+992 919 111 222', 'delicious@mail.ru', NOW(), NOW()),
('Green Table', 'Бохтар, ул. Центральная 8', '+992 905 333 444', 'greentable@gmail.com', NOW(), NOW()),
('Royal Meal', 'Душанбе, Фирдавси', '+992 915 777 888', 'royalmeal@bk.ru', NOW(), NOW()),
('Family Kitchen', 'Курган-Тюбе', '+992 901 222 333', 'familykitchen@email.com', NOW(), NOW()),
('Fast & Tasty', 'Душанбе, Сино', '+992 928 444 555', 'fasttasty@gmail.com', NOW(), NOW()),
('Healthy Food TJ', 'Хорог', '+992 907 666 777', 'healthyfood@tj.com', NOW(), NOW()),
('Golden Spoon', 'Душанбе, 90-летия', '+992 918 999 000', 'goldenspoon@email.com', NOW(), NOW());




INSERT INTO menus (menuDate, isActive, createdAt, updatedAt) VALUES
('2026-05-08', true, NOW(), NOW()),
('2026-05-09', true, NOW(), NOW()),
('2026-05-10', true, NOW(), NOW()),
('2026-05-11', true, NOW(), NOW()),
('2026-05-12', true, NOW(), NOW()),
('2026-05-13', true, NOW(), NOW()),
('2026-05-14', false, NOW(), NOW()),
('2026-05-15', true, NOW(), NOW()),
('2026-05-16', true, NOW(), NOW()),
('2026-05-17', true, NOW(), NOW());




INSERT INTO menu_items (menuId, name, description, price, category, createdAt, updatedAt) VALUES
(1, 'Плов с бараниной', 'Классический таджикский плов', 35.00, 'Главное блюдо', NOW(), NOW()),
(1, 'Салат Оливье', 'С курицей и овощами', 18.00, 'Салаты', NOW(), NOW()),
(1, 'Чай зелёный', 'С мятой и сахаром', 5.00, 'Напитки', NOW(), NOW()),
(2, 'Шашлык куриный', 'Маринованный в специях', 28.00, 'Главное блюдо', NOW(), NOW()),
(2, 'Манты', 'С мясом и луком', 22.00, 'Главное блюдо', NOW(), NOW()),
(3, 'Лагман', 'Говяжий лагман', 25.00, 'Главное блюдо', NOW(), NOW()),
(3, 'Салат Цезарь', 'С курицей и соусом', 20.00, 'Салаты', NOW(), NOW()),
(4, 'Борщ', 'Украинский борщ со сметаной', 15.00, 'Супы', NOW(), NOW()),
(5, 'Котлета по-киевски', 'С картофелем фри', 30.00, 'Главное блюдо', NOW(), NOW()),
(6, 'Компот яблочный', 'Домашний компот', 6.00, 'Напитки', NOW(), NOW());



INSERT INTO subscriptions (companyId, planType, mealsPerDay, price, startDate, endDate, isActive, created_at, updated_at) VALUES
(1, 'Стандарт', 2, 1200.00, '2026-05-01', '2026-06-01', true, NOW(), NOW()),
(2, 'Премиум', 3, 2100.00, '2026-05-05', '2026-07-05', true, NOW(), NOW()),
(3, 'Базовый', 1, 800.00, '2026-04-20', '2026-05-20', true, NOW(), NOW()),
(4, 'Стандарт', 2, 1350.00, '2026-05-10', '2026-06-10', true, NOW(), NOW()),
(5, 'Премиум', 3, 1950.00, '2026-05-08', '2026-06-08', true, NOW(), NOW()),
(6, 'Базовый', 1, 750.00, '2026-05-12', '2026-06-12', true, NOW(), NOW()),
(7, 'Стандарт', 2, 1100.00, '2026-05-15', '2026-06-15', false, NOW(), NOW()),
(8, 'Премиум', 3, 2300.00, '2026-05-01', '2026-08-01', true, NOW(), NOW()),
(9, 'Базовый', 1, 900.00, '2026-05-20', '2026-06-20', true, NOW(), NOW()),
(10, 'Стандарт', 2, 1250.00, '2026-05-03', '2026-06-03', true, NOW(), NOW());



INSERT INTO orders (companyId, orderDate, status, totalAmount, createdAt, updatedAt) VALUES
(1, NOW(), 'Completed', 185.50, NOW(), NOW()),
(2, NOW(), 'Pending', 98.00, NOW(), NOW()),
(3, NOW() - INTERVAL '1 day', 'Completed', 245.00, NOW(), NOW()),
(4, NOW(), 'Completed', 156.75, NOW(), NOW()),
(5, NOW() - INTERVAL '2 day', 'Cancelled', 67.50, NOW(), NOW()),
(1, NOW(), 'Processing', 320.00, NOW(), NOW()),
(6, NOW(), 'Completed', 89.00, NOW(), NOW()),
(7, NOW() - INTERVAL '1 day', 'Completed', 134.25, NOW(), NOW()),
(8, NOW(), 'Pending', 210.00, NOW(), NOW()),
(9, NOW(), 'Completed', 175.80, NOW(), NOW());




INSERT INTO order_items (orderId, menuItemId, quantity, price, createdAt, updatedAt) VALUES
(1, 1, 2, 35.00, NOW(), NOW()),
(1, 2, 1, 18.00, NOW(), NOW()),
(1, 3, 3, 5.00,  NOW(), NOW()),
(2, 4, 3, 28.00, NOW(), NOW()),
(2, 5, 2, 22.00, NOW(), NOW()),
(3, 6, 1, 25.00, NOW(), NOW()),
(4, 7, 2, 20.00, NOW(), NOW()),
(5, 8, 4, 15.00, NOW(), NOW()),
(6, 1, 3, 35.00, NOW(), NOW()),
(7, 9, 1, 30.00, NOW(), NOW());
