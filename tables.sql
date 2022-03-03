use GraduateProject;
CREATE TABLE Department
(  
    DepartmentID int IDENTITY(1,1),
    [Name] varchar(100) NOT NULL,  
    IsActive BIT not null,
    CONSTRAINT CHK_Department_IsActive CHECK (IsActive = 1 or IsActive = 0),
    CONSTRAINT PK_Department_DepartmentID PRIMARY KEY(DepartmentID)
);
CREATE TABLE ContactUs (
    Id int  IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(50) NOT NULL,
    LastName varchar(50) NOT NULL,
    Email varchar(50) NOT NULL,
	Question varchar(1000) NOT NULL
);
CREATE TABLE [Language]
(  
    LanguageID int IDENTITY(1,1),
    [Language] varchar(50) NOT NULL,  
    LanguageCode varchar(10) NOT NULL,   
    CONSTRAINT PK_Language_LanguageID PRIMARY KEY(LanguageID)
);

CREATE TABLE MedicalCenter
(  
    MedicalCenterID int IDENTITY(1,1),
    [Name] varchar(100) NOT NULL,   
    Email nvarchar(50) NOT NULL,  
    Phone varchar(14) NOT NULL,  
    City VARCHAR(25)NOT NULL,  
    OpeningTime VARCHAR(15) NOT NULL,  
    ClosingTime VARCHAR(15) NOT NULL,  
    ImagePath varchar(100) NOT NULL,  
    [Address] VARCHAR(100) NOT NULL,  
    [Location] VARCHAR(100) NOT NULL,  
    [Description] VARCHAR(1000) NOT NULL,  
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),  
    IsActive BIT not null,
	LanguageID int, 
	CONSTRAINT FK_MedicalCenter_Language_LanguageID foreign key (LanguageID) references [Language](LanguageID),
    CONSTRAINT CHK_MedicalCenter_IsActive CHECK (IsActive = 1 or IsActive = 0),
    CONSTRAINT PK_MedicalCenter_MedicalCenterID PRIMARY KEY(MedicalCenterID)
); 



CREATE TABLE MedicalCenterLog
(  
    MedicalCenterID int IDENTITY(1,1),
    MedicalCenterName varchar(100) NOT NULL,   
    Email nvarchar(50) NOT NULL,  
    Phone varchar(14) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    OpeningTime VARCHAR(15) NOT NULL,  
    ClosingTime VARCHAR(15) NOT NULL,  
    ImagePath varchar(100),
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),
    MedicalCenterAddress VARCHAR(100) NOT NULL,  
    MedicalCenterLocation VARCHAR(100), 
    MedicalCenterDescription VARCHAR(1000) NOT NULL,  
    CONSTRAINT PK_MedicalCenterLog_MedicalCenterID PRIMARY KEY(MedicalCenterID)
); 


CREATE TABLE Doctor
(  
    DoctorID int IDENTITY(1,1),
    FirstName varchar(50) NOT NULL,  
    LastName varchar(50) NOT NULL, 
    Email nvarchar(50) NOT NULL,  
    Phone varchar(14) NOT NULL, 
    Gender varchar(6) not null, 
    Birthday date,
    WorkingPlace VARCHAR(100) NOT NULL,  
    WorkingTime varchar(25) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    ImagePath varchar(100) NOT NULL,  
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),
    [Address] VARCHAR(100) NOT NULL,  
    [Location] VARCHAR(100) NOT NULL,   
    DepartmentID int NOT NULL,  
    MedicalCenterID int,
    IsActive BIT not null,
	LanguageID int, 
	CONSTRAINT FK_Doctor_Language_LanguageID foreign key (LanguageID) references [Language](LanguageID),
    CONSTRAINT CHK_Doctor_IsActive CHECK (IsActive = 1 or IsActive = 0),
    CONSTRAINT PK_Doctor_DoctorID PRIMARY KEY(DoctorID),
    CONSTRAINT FK_Doctor_Department_DepartmentID foreign key (DepartmentID) references Department(DepartmentID),
    CONSTRAINT FK_Doctor_MedicalCenter_MedicalCenterID foreign key (MedicalCenterID) references MedicalCenter(MedicalCenterID)
);


CREATE TABLE DoctorLog
(  
    DoctorID int IDENTITY(1,1),
    FirstName varchar(50) NOT NULL,  
    LastName varchar(50) NOT NULL, 
    Email nvarchar(50),
    Phone varchar(14) NOT NULL,  
    Birthday date,
    Gender varchar(6) not null,
    WorkingPlace VARCHAR(100) NOT NULL,  
    WorkingTime varchar(25) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    ImagePath varchar(100),
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),
    DoctorAddress VARCHAR(100) NOT NULL,  
    DoctorLocation VARCHAR(100), 
    DepartmentID int NOT NULL,  
    MedicalCenterName VARCHAR(100) NOT NULL,  
    CONSTRAINT PK_DoctorLog_DoctorID PRIMARY KEY(DoctorID),
    CONSTRAINT FK_DoctorLog_Department_DepartmentID foreign key (DepartmentID) references Department(DepartmentID)

);



CREATE TABLE PlaceToVisit
(  
    PlaceID int IDENTITY(1,1),
    [Name] varchar(100) NOT NULL,   
    Email nvarchar(50) NOT NULL,  
    Phone varchar(14) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    OpeningTime VARCHAR(15) NOT NULL,  
    ClosingTime VARCHAR(15) NOT NULL,  
    ImagePath varchar(100) NOT NULL, 
	WebSiteLink varchar(100),
	WhatappNumber varchar(14), 
    [Address] VARCHAR(100) NOT NULL,  
    [Location] VARCHAR(100) NOT NULL,  
    [Type] VARchar(100) NOT NULL,  
    [Description] VARCHAR(1000) NOT NULL, 
    IsActive BIT not null,
	LanguageID int, 
	CONSTRAINT FK_PlaceToVisit_Language_LanguageID foreign key (LanguageID) references [Language](LanguageID),
    CONSTRAINT CHK_PlaceToVisit_IsActive CHECK (IsActive = 1 or IsActive = 0), 
    CONSTRAINT PK_Place_PlaceID PRIMARY KEY(PlaceID)
);



CREATE TABLE PlaceToVisitLog
(  
    PlaceID int IDENTITY(1,1),
    [Name] varchar(100) NOT NULL,   
    Email nvarchar(50),
    Phone varchar(14) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    OpeningTime VARCHAR(15) NOT NULL,  
    ClosingTime VARCHAR(15) NOT NULL,  
    ImagePath varchar(100),
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),
    [Address] VARCHAR(100) NOT NULL,  
    [Location] VARCHAR(100), 
    [Type] VARchar(100) NOT NULL,  
    [Description] VARCHAR(1000) NOT NULL,  
    CONSTRAINT PK_PlaceLog_PlaceID PRIMARY KEY(PlaceID)
);



CREATE TABLE Hotel
(  
    HotelID int IDENTITY(1,1),
    [Name] varchar(100) NOT NULL,   
    Email nvarchar(50) NOT NULL,  
    Phone varchar(14) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    ImagePath varchar(100) NOT NULL,  
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),
    LogoPath varchar(100) NOT NULL,  
    [Address] VARCHAR(100) NOT NULL,  
    [Location] VARCHAR(100) NOT NULL,  
    [Description] VARCHAR(1000) NOT NULL,  
    IsActive BIT not null,
	LanguageID int, 
	CONSTRAINT FK_Hotel_Language_LanguageID foreign key (LanguageID) references [Language](LanguageID),
    CONSTRAINT CHK_Hotel_IsActive CHECK (IsActive = 1 or IsActive = 0),
    CONSTRAINT PK_Hotel_HotelID PRIMARY KEY(HotelID)
);



CREATE TABLE HotelLog
(  
    HotelID int IDENTITY(1,1),
    [Name] varchar(100) NOT NULL,   
    Email nvarchar(50),
    Phone varchar(14) NOT NULL,  
    City VARCHAR(25) NOT NULL,  
    ImagePath varchar(100),
	WebSiteLink varchar(100),
	WhatappNumber varchar(14),
    LogoPath varchar(100),
    [Address] VARCHAR(100) NOT NULL,  
    [Location] VARCHAR(100), 
    [Description] VARCHAR(1000) NOT NULL,  
    CONSTRAINT PK_HotelLog_HotelID PRIMARY KEY(HotelID)
);


CREATE TABLE Comment
(  
    CommentID int IDENTITY(1,1),
    UserFirstName varchar(50) NOT NULL,  
    UserLastName varchar(50) NOT NULL,  
    [Description] VARCHAR(1000) NOT NULL,  
    DoctorID int,
    HotelID int,
    PlaceID int,
    MedicalCenterID int,
    WebSiteID int,
    IsActive BIT not null,
	LanguageID int, 
	CONSTRAINT FK_Comment_Language_LanguageID foreign key (LanguageID) references [Language](LanguageID),
    CONSTRAINT CHK_Comment_IsActive CHECK (IsActive = 1 or IsActive = 0),
    CONSTRAINT PK_Comments_CommentID PRIMARY KEY(CommentID),
    CONSTRAINT FK_Comments_Doctor_DoctorID foreign key (DoctorID) references Doctor(DoctorID),
    CONSTRAINT FK_Comments_Hotel_HotelID foreign key (HotelID) references Hotel(HotelID),
    CONSTRAINT FK_Comments_PlaceToVisit_PlaceID foreign key (PlaceID) references PlaceToVisit(PlaceID),
    CONSTRAINT FK_Comments_MedicalCenter_MedicalCenterID foreign key (MedicalCenterID) references MedicalCenter(MedicalCenterID)
);


CREATE TABLE Rating
(  
    RatingID int IDENTITY(1,1),
    UserFirstName varchar(50) NOT NULL,  
    UserLastName varchar(50) NOT NULL,  
    Rate int NOT NULL,  
    DoctorID int,
    HotelID int,
    PlaceID int,
    MedicalCenterID int,
    WebSiteID int,
    IsActive BIT not null,
    CONSTRAINT CHK_Rating_IsActive CHECK (IsActive = 1 or IsActive = 0),
    CONSTRAINT PK_Rating_RatingID PRIMARY KEY(RatingID),
    CONSTRAINT FK_Rating_Doctor_DoctorID foreign key (DoctorID) references Doctor(DoctorID),
    CONSTRAINT FK_Rating_Hotel_HotelID foreign key (HotelID) references Hotel(HotelID),
    CONSTRAINT FK_Rating_PlaceToVisit_PlaceID foreign key (PlaceID) references PlaceToVisit(PlaceID),
    CONSTRAINT FK_Rating_MedicalCenter_MedicalCenterID foreign key (MedicalCenterID) references MedicalCenter(MedicalCenterID)
);



