use master
go
use [PC Club]
go

insert into [EmployeeRole] values
('Администратор'),
('Управляющий')

insert into [ComputerType] values
('Стандарт'),
('ВИП')

insert into [PaymentMethod] values
('Наличные'),
('Карта')

insert into [ProductType] values
('Напитки'),
('Еда')

insert into [User] values
('H1HJ2', 0, 'Андрей', 'Уфимцев', '89120113456', '01.01.2000'),
('K5LJ8', 10000, 'Екатерина', 'Смирнова', '89271234567', '15.03.1995'),
('R9MN6', 500, 'Иван', 'Петров', '89051234567', '30.11.1987'),
('G3FD1', 20000, 'Мария', 'Иванова', '89161234567', '20.07.1992'),
('T2KL5', 1000, 'Алексей', 'Кузнецов', '89301234567', '05.05.1984'),
('B7HN8', 300, 'Наталья', 'Соколова', '89011234567', '12.12.1998'),
('F6TR4', 5000, 'Дмитрий', 'Сидоров', '89281234567', '25.09.1990'),
('M8KL2', 7000, 'Анна', 'Козлова', '89141234567', '18.06.1988'),
('N4GB9', 1500, 'Сергей', 'Васильев', '89061234567', '08.02.1979'),
('P1KL9', 250, 'Ольга', 'Николаева', '89341234567', '07.09.1996')

insert into [ComputerStandart] values
('001', null),
('002', null),
('003', null),
('004', null),
('005', null),
('006', null),
('007', null),
('008', null),
('009', null),
('010', null)

insert into [ComputerVIP] values
('011', null),
('012', null),
('013', null),
('014', null),
('015', null)

insert into [Employee] values 
('JLFDS', 'Антон', 'Рожков', 'Денисович', '89765432534', 'Anton', '123456', 0, 1),
('FKDSP', 'Александр', 'Доника', 'Романович', '87548456723', 'Sanya', 'fsdffsd', 0, 1),
('HFYRN', 'Даниил', 'Ловжин', 'Андреевич', '89543453812', 'Daniil', '876542', 0, 1),
('HKKKH', 'Анатолий', 'Данилов', 'Алексеевич', '89097653910', 'Tolik666', 'qwerty123', 0, 2)

insert into [Product] values
('LOKUN', 'Adrenaline 0.25', 34, 95, 1, null, 'adrenaline 0.25.jpeg', 0),
('NYBYF', 'Adrenaline 0.5', 13, 145, 1, null, 'adrenaline 0.5.jpeg', 0),
('FSGHD', 'Adrenaline Game Fuel 0.5', 10, 145, 1, null, 'adrenaline game fuel 0.5.jpeg', 0),
('DHFRF', 'Adrenaline Game Fuel 0.25', 13, 95, 1, null, 'adrenaline game fuel 0.25.jpeg', 0),
('GDFJR', 'Adrenaline Mango', 18, 145, 1, null, 'adrenaline mango.jpeg', 0),
('YGIGH', 'Adrenaline Zero Sugar', 24, 145, 1, null, 'adrenaline zero sugar.jpeg', 0),
('JIDSA', 'Burn Gold Rush', 16, 150, 1, null, 'burn gold rush.jpeg', 0),
('JIKFY', 'Burn фиолетовый', 28, 150, 1, null, 'burn purple.jpeg', 0),
('KIJYH', 'Burn зеленый', 19, 150, 1, null, 'burn green.jpeg', 0),
('IFMYT', 'Coca-cola Zero', 22, 90, 1, null, 'cola zero.jpeg', 0),
('OMUNE', 'Coca-cola', 10, 90, 1, null, 'cola.jpeg', 0),
('SDFOF', 'Fanta', 13, 90, 1, null, 'fanta.jpeg', 0),
('ONEBR', 'Lipton Черный', 23, 85, 1, null, 'lipton black.jpeg', 0),
('INSTE', 'Lipton Зеленый', 30, 85, 1, null, 'lipton green.jpeg', 0),
('PMNRW', 'Lit Energy Черника', 60, 150, 1, null, 'lit energy blueberry.jpeg', 0),
('NYREB', 'Lit Energy Classic', 54, 150, 1, null, 'lit energy classic.jpeg', 0),
('NHYTR', 'Lit Energy Манго-кокос', 45, 150, 1, null, 'lit energy mangococonut.jpeg', 0),
('KOMUN', 'Lit Energy Без сахара', 27, 150, 1, null, 'lit energy zero.jpeg', 0),
('QTYRW', 'Monster Black', 26, 120, 1, null, 'monster black.jpeg', 0),
('KMYRE', 'Monster Mango', 25, 120, 1, null, 'monster mango.jpeg', 0),
('MNBGH', 'Monster Orange', 18, 120, 1, null, 'monster orange.jpeg', 0),
('PIRNE', 'Pepsi', 24, 85, 1, null, 'pepsi.jpeg', 0),
('NBDAT', 'Red Bull 0.5', 44, 180, 1, null, 'red bull 0.5.jpeg', 0),
('OKMTE', 'Red Bull 0.25', 48, 115, 1, null, 'red bull 0.25.jpeg', 0),
('FWORT', 'Sprite', 12, 90, 1, null, 'sprite.jpeg', 0),
('NBVFD', 'Tornado Active', 24, 85, 1, null, 'tornado active.jpeg', 0),
('TDBRE', 'Tornado Battle', 36, 85, 1, null, 'tornado battle.jpeg', 0),
('PQNFH', 'Tornado Bubble', 24, 85, 1, null, 'tornado bubble.jpeg', 0),
('MNDRE', 'Tornado Cactus', 24, 85, 1, null, 'tornado cactus.jpeg', 0),
('MSNEY', 'Tornado Coconut', 18, 85, 1, null, 'tornado coconut.jpeg', 0),
('WREBJ', 'Tornado Coffee', 0, 85, 1, null, 'tornado coffee.jpeg', 0),
('DFREB', 'Tornado Ice', 40, 85, 1, null, 'tornado ice.jpeg', 0),
('PQWBZ', 'Tornado Iceberry', 48, 85, 1, null, 'tornado iceberry.jpeg', 0),
('TGPQB', 'Tornado Lemon Cake', 13, 85, 1, null, 'tornado lemoncake.jpeg', 0),
('KFSDY', 'Tornado Mango', 34, 85, 1, null, 'tornado mango.jpeg', 0),
('JKDHG', 'Tornado Raspberry', 11, 85, 1, null, 'tornado raspberry.jpeg', 0),
('MDASY', 'Tornado Skill', 39, 85, 1, null, 'tornado skill.jpeg', 0),
('NEUTB', 'Tornado Storm', 15, 85, 1, null, 'tornado storm.jpeg', 0),
('OWMFF', 'Tornado Top Dog', 44, 85, 1, null, 'tornado topdog.jpeg', 0),
('GSEYR', 'Вода газированная', 15, 85, 1, null, 'вода газированная.jpeg', 0),
('IRWEN', 'Вода негазированная', 23, 85, 1, null, 'вода негазированная.jpeg', 0),
('IKUJY', 'Bounty', 37, 60, 2, null, 'Bounty.jpeg', 0),
('JIJUN', 'Bounty Большой', 26, 90, 2, null, 'Bounty Большой.jpeg', 0),
('KKDUT', 'Picnic', 23, 60, 2, null, 'Picnic.jpeg', 0),
('VDFDS', 'Picnic Большой', 30, 60, 2, null, 'Picnic Большой.jpeg', 0),
('IDYTN', 'Twix', 24, 60, 2, null, 'Twix.jpeg', 0),
('GDGWX', 'Twix Большой', 22, 90, 2, null, 'Twix Большой.jpeg', 0),
('VCXWX', 'Snickers', 36, 60, 2, null, 'Snickers.jpeg', 0),
('OPIXD', 'Snickers Большой', 7, 90, 2, null, 'Snickers Большой.jpeg', 0),
('UFHED', 'Mars', 39, 60, 2, null, 'Mars.jpeg', 0),
('DRSFA', 'Mars Большой', 22, 90, 2, null, 'Mars Большой.jpeg', 0),
('PMDTR', 'Хотстеры', 10, 180, 2, null, 'Хотстеры.jpeg', 0),
('OTRNT', 'Чебупицца Курица', 12, 180, 2, null, 'Чебупицца Курица.jpeg', 0),
('YUTYG', 'Чебупицца Пепперони', 18, 180, 2, null, 'Чебупицца Пепперони.jpeg', 0),
('GDFJH', 'Чебупели', 7, 180, 2, null, 'Чебупели.jpeg', 0)

