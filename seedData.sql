SET IDENTITY_INSERT Department ON
INSERT INTO Department (departmentId, [Name],	IsActive,	ClicksNumber)
VALUES                 (1, 'dentisy', 1, 0);
INSERT INTO Department (departmentId, [Name],	IsActive,	ClicksNumber)
VALUES                 (2, 'eye diseases', 1, 0);
INSERT INTO Department (departmentId,[Name],	IsActive,	ClicksNumber)
VALUES                 (3, 'medical genetics', 1, 0);
SET IDENTITY_INSERT Department OFF

select * from Department;

INSERT INTO [Language] ([Language],	Code)
VALUES                 ('English', 'EN');
INSERT INTO [Language] ([Language],	Code)
VALUES                 ('Arabic', 'AR');
INSERT INTO [Language] ([Language],	Code)
VALUES                 ('Turkish', 'TR');
select * from [Language];


SET IDENTITY_INSERT MedicalCenter ON
INSERT INTO MedicalCenter (MedicalCenterID, [Name],	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	[Address],	[Location],	[Description],	WebSiteLink,	WhatappNumber,	IsActive,	LanguageID,	ClicksNumber, Rate)
VALUES                 (1, 'ALMADINA', 'almadina@gmail.com', '02120023932', 'Istanbul', '10:00', '20:00', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'fatih/istanbul', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA','medical center in fatih', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA', '05317171172', 1, 1, 9, 2);
INSERT INTO MedicalCenter (MedicalCenterID, [Name],	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	[Address],	[Location],	[Description],	WebSiteLink,	WhatappNumber,	IsActive,	LanguageID,	ClicksNumber, Rate)
VALUES                 (2, N'المدينة', 'almadina@gmail.com', '02120023932', N'اسطنبول', '10:00', '20:00', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', N'الفاتح', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA', N'مركز المدينة في الفاتح','https://goo.gl/maps/q9SyktrwcfLZvKfQA', '05317171172', 0, 2, 1, 5);
INSERT INTO MedicalCenter (MedicalCenterID, [Name],	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	[Address],	[Location],	[Description],	WebSiteLink,	WhatappNumber,	IsActive,	LanguageID,	ClicksNumber, Rate)
VALUES                 (3, 'ELMEDİNA', 'elmedina@gmail.com', '111111111', 'İstanbul', '10:00', '20:00', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'fatih/istanbul', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA', 'medical center in fatih','https://goo.gl/maps/q9SyktrwcfLZvKfQA', '05317171172', 1, 3, 2, 1);

INSERT INTO MedicalCenter (MedicalCenterID, [Name],	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	[Address],	[Location],	[Description],	WebSiteLink,	WhatappNumber,	IsActive,	LanguageID,	ClicksNumber, Rate)
VALUES                 (4, 'ALNUR', 'alnur@gmail.com', '827283890283', 'Istanbul', '10:00', '20:00', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'fatih/istanbul', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA', 'medical center in fatih','https://goo.gl/maps/q9SyktrwcfLZvKfQA', '05317171172', 1, 1, 4, 5);
INSERT INTO MedicalCenter (MedicalCenterID, [Name],	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	[Address],	[Location],	[Description],	WebSiteLink,	WhatappNumber,	IsActive,	LanguageID,	ClicksNumber, Rate)
VALUES                 (5, N'النور', 'alnur@gmail.com', '827283890283', N'اسطنبول', '10:00', '20:00', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', N'الفاتح', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA', N'مركز النور في الفاتح','https://goo.gl/maps/q9SyktrwcfLZvKfQA', '05317171172', 0, 2, 1, 2);
INSERT INTO MedicalCenter (MedicalCenterID, [Name],	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	[Address],	[Location],	[Description],	WebSiteLink,	WhatappNumber,	IsActive,	LanguageID,	ClicksNumber, Rate)
VALUES                 (6, 'ELNUR', 'elnur@gmail.com', '827283890283', 'İstanbul', '10:00', '20:00', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'fatih/istanbul', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA', 'medical center in fatih','https://goo.gl/maps/q9SyktrwcfLZvKfQA', '05317171172', 1, 3, 5, 4);
SET IDENTITY_INSERT MedicalCenter OFF

select * from MedicalCenter;


INSERT INTO Doctor(FirstName,	LastName,	Email,	Phone,	Gender,	Birthday,	WorkingPlace,	WorkingTime,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	DepartmentID,	MedicalCenterID,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES                 ('AHMAD', 'SAMIR', 'ahmad@gmail.com', '6561279707', 'M', '1994', 'ALRAHMA MEDICAL CENTER', '12:00', 'Istanbul', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','68197077973', 'medical center in fatih','https://goo.gl/maps/q9SyktrwcfLZvKfQA',1, 1, 1, 1, 7, 4);
INSERT INTO Doctor(FirstName,	LastName,	Email,	Phone,	Gender,	Birthday,	WorkingPlace,	WorkingTime,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	DepartmentID,	MedicalCenterID,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES                 (N'احمد', N'سمير', 'ahmad@gmail.com', '6561279707', N'ذكر', '1994', N'مركز الرحمة الطبي', '12:00', N'اسطتبول', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','68197077973', N'الفاتح','https://goo.gl/maps/q9SyktrwcfLZvKfQA',1, 1, 1,2,  7, 4);
INSERT INTO Doctor(FirstName,	LastName,	Email,	Phone,	Gender,	Birthday,	WorkingPlace,	WorkingTime,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	DepartmentID,	MedicalCenterID,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES                 ('AHMET', 'SAMİR', 'ahmet@gmail.com', '6561279707', 'M', '1994', 'elrahm merkezi', '12:00', 'İSTANBUL', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','68197077973', 'FATİH','https://goo.gl/maps/q9SyktrwcfLZvKfQA',1, 1, 1, 3, 7, 4);
select * from Doctor;


INSERT INTO doctorlog(FirstName,	LastName,	Email,	Phone,	Gender,	Birthday,	WorkingPlace,	WorkingTime,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	DepartmentID,	MedicalCenterName)
VALUES                 ('tarek', 'alkasir', 'tarek@gmail.com', '6561279707', 'M', '1994', 'elrahm merkezi', '12:00', 'İSTANBUL', 'https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','68197077973', 'FATİH','https://goo.gl/maps/q9SyktrwcfLZvKfQA',1, 'almadina');
select * from doctorlog;


INSERT INTO PlaceToVisit(Name,	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	Type,	Description,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES                 ('zoo', 'zoo@gmail.com', '6561279707','ISTANBUL','12:00','20:00', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','park', 'jbjbsabcjsaldasdşaskjd',1,1, 98, 4);
INSERT INTO PlaceToVisit(Name,	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	Type,	Description,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES                 (N'حديقة حيوانات', '6561279707','zoo@gmail.com', N'اسطنبول','12:00','20:00', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/',N'حديقة', N'تنئءىؤنئءؤكستيمسش',1,2, 12, 4);
INSERT INTO PlaceToVisit(Name,	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	Type,	Description,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES                 ('zoo', 'zoo@gmail.com','6561279707', 'İSTANBUL','12:00','20:00', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','park', 'ÇÇÇÇÇÇÇÇÇÇÇÇÇÇ',1,3, 33, 1);
select * from PlaceToVisit;



INSERT INTO PlaceToVisitLOG(Name,	Email,	Phone,	City,	OpeningTime,	ClosingTime,	ImagePath,	WebSiteLink,	WhatappNumber,	Address,	Location,	Type,	DescriptioN)
VALUES                 ('zoo', 'zoo@gmail.com','6561279707', 'İSTANBUL','12:00','20:00', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'https://www.geeksforgeeks.org/sql-query-to-display-all-the-existing-constraints-on-a-table/','park', 'ÇÇÇÇÇÇÇÇÇÇÇÇÇÇ');
select * from PlaceToVisitLOG;



INSERT INTO HOTEL(Name,	Email,	Phone,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	LogoPath,	Address,	Location,	Description,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES            ('helton', 'helton@gmail.com','6561279707','ISTANBUL', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'the address of the hotel', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA','beautiful hotel', 1, 1, 7, 4);
INSERT INTO HOTEL(Name,	Email,	Phone,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	LogoPath,	Address,	Location,	Description,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES            (N'هيلتون', 'helton@gmail.com','6561279707', N'اسطنبول', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', N'الفاتح في اسطنبول', 'https://goo.gl/maps/q9SyktrwcfLZvKfQA',N'فندق جميل', 1, 2, 99,1);
INSERT INTO HOTEL(Name,	Email,	Phone,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	LogoPath,	Address,	Location,	Description,	IsActive,	LanguageID,	ClicksNumber,	Rate)
VALUES            ('helton', 'helton@gmail.com','6561279707', 'İSTANBUL', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'İstanbulun hotellerinden biridir','https://goo.gl/maps/q9SyktrwcfLZvKfQA','güzel hotel', 1, 3, 6, 5);
select * from HOTEL;



INSERT INTO HOTELLOG(Name,	Email,	Phone,	City,	ImagePath,	WebSiteLink,	WhatappNumber,	LogoPath,	Address,	Location,	Description)
VALUES            ('helton', 'helton@gmail.com','6561279707', 'İSTANBUL', 'https://th.bing.com/th/id/OIP.Lb5r5dptKjaCWyZRhQORMAHaE8?w=278&h=185&c=7&r=0&o=5&dpr=1.25&pid=1.7','https://www.facebook.com/zooworldclassic/app/203351739677351/','6561279707','https://th.bing.com/th/id/OIP.avxhtQqr5FoubGjq4sIXugHaEo?w=282&h=180&c=7&r=0&o=5&dpr=1.25&pid=1.7', 'İstanbulun hotellerinden biridir','https://goo.gl/maps/q9SyktrwcfLZvKfQA','güzel hotel');
select * from HOTELLOG;
