USE [master]
GO
/****** Object:  Database [GraduateProject]    Script Date: 07/04/2022 23:40:32 ******/
CREATE DATABASE [GraduateProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GraduateProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GraduateProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GraduateProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GraduateProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GraduateProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GraduateProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GraduateProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GraduateProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GraduateProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GraduateProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GraduateProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [GraduateProject] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GraduateProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GraduateProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GraduateProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GraduateProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GraduateProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GraduateProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GraduateProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GraduateProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GraduateProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GraduateProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GraduateProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GraduateProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GraduateProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GraduateProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GraduateProject] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GraduateProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GraduateProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GraduateProject] SET  MULTI_USER 
GO
ALTER DATABASE [GraduateProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GraduateProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GraduateProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GraduateProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GraduateProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GraduateProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GraduateProject] SET QUERY_STORE = OFF
GO
USE [GraduateProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserFirstName] [nvarchar](50) NOT NULL,
	[UserLastName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[DoctorID] [int] NULL,
	[HotelID] [int] NULL,
	[PlaceID] [int] NULL,
	[MedicalCenterID] [int] NULL,
	[WebSiteID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageID] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Question] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ClicksNumber] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](14) NOT NULL,
	[Gender] [nvarchar](6) NOT NULL,
	[Birthday] [date] NULL,
	[WorkingPlace] [nvarchar](100) NOT NULL,
	[WorkingTime] [nvarchar](25) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[ImagePath] [nvarchar](100) NOT NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[MedicalCenterID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageID] [int] NULL,
	[ClicksNumber] [int] NOT NULL,
	[Rate] [real] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorLog]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorLog](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](14) NOT NULL,
	[Birthday] [date] NULL,
	[Gender] [nvarchar](6) NOT NULL,
	[WorkingPlace] [nvarchar](100) NOT NULL,
	[WorkingTime] [nvarchar](25) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NULL,
	[DepartmentID] [int] NOT NULL,
	[MedicalCenterName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_DoctorLog] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](14) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[ImagePath] [nvarchar](100) NOT NULL,
	[WebSiteLink] [varchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[LogoPath] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageID] [int] NULL,
	[ClicksNumber] [int] NOT NULL,
	[Rate] [real] NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelLog]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelLog](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](14) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[LogoPath] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [varchar](100) NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_HotelLog] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalCenter]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalCenter](
	[MedicalCenterID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[OpeningTime] [nvarchar](15) NOT NULL,
	[ClosingTime] [nvarchar](15) NOT NULL,
	[ImagePath] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [nvarchar](14) NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageID] [int] NULL,
	[ClicksNumber] [int] NOT NULL,
	[Rate] [real] NOT NULL,
 CONSTRAINT [PK_MedicalCenter] PRIMARY KEY CLUSTERED 
(
	[MedicalCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalCenterLog]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalCenterLog](
	[MedicalCenterID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [varchar](14) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[OpeningTime] [nvarchar](15) NOT NULL,
	[ClosingTime] [nvarchar](15) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [varchar](100) NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_MedicalCenterLog] PRIMARY KEY CLUSTERED 
(
	[MedicalCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceToVisit]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceToVisit](
	[PlaceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [varchar](14) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[OpeningTime] [varchar](15) NOT NULL,
	[ClosingTime] [varchar](15) NOT NULL,
	[ImagePath] [nvarchar](100) NOT NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [varchar](100) NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LanguageID] [int] NULL,
	[ClicksNumber] [int] NOT NULL,
	[Rate] [real] NOT NULL,
 CONSTRAINT [PK_PlaceToVisit] PRIMARY KEY CLUSTERED 
(
	[PlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceToVisitLog]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceToVisitLog](
	[PlaceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](14) NOT NULL,
	[City] [nvarchar](25) NOT NULL,
	[OpeningTime] [varchar](15) NOT NULL,
	[ClosingTime] [varchar](15) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[WebSiteLink] [nvarchar](100) NULL,
	[WhatappNumber] [varchar](14) NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Location] [varchar](100) NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_PlaceToVisitLog] PRIMARY KEY CLUSTERED 
(
	[PlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 07/04/2022 23:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[UserFirstName] [nvarchar](50) NOT NULL,
	[UserLastName] [nvarchar](50) NOT NULL,
	[Rate] [real] NOT NULL,
	[DoctorID] [int] NULL,
	[HotelID] [int] NULL,
	[PlaceID] [int] NULL,
	[MedicalCenterID] [int] NULL,
	[WebSiteID] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 07/04/2022 23:40:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 07/04/2022 23:40:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_DoctorID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comment_DoctorID] ON [dbo].[Comment]
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_HotelID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comment_HotelID] ON [dbo].[Comment]
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_LanguageID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comment_LanguageID] ON [dbo].[Comment]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_MedicalCenterID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comment_MedicalCenterID] ON [dbo].[Comment]
(
	[MedicalCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_PlaceID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Comment_PlaceID] ON [dbo].[Comment]
(
	[PlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_DepartmentID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_DepartmentID] ON [dbo].[Doctor]
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_LanguageID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_LanguageID] ON [dbo].[Doctor]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_MedicalCenterID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_MedicalCenterID] ON [dbo].[Doctor]
(
	[MedicalCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DoctorLog_DepartmentID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_DoctorLog_DepartmentID] ON [dbo].[DoctorLog]
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hotel_LanguageID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Hotel_LanguageID] ON [dbo].[Hotel]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicalCenter_LanguageID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_MedicalCenter_LanguageID] ON [dbo].[MedicalCenter]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlaceToVisit_LanguageID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_PlaceToVisit_LanguageID] ON [dbo].[PlaceToVisit]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rating_DoctorID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Rating_DoctorID] ON [dbo].[Rating]
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rating_HotelID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Rating_HotelID] ON [dbo].[Rating]
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rating_MedicalCenterID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Rating_MedicalCenterID] ON [dbo].[Rating]
(
	[MedicalCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rating_PlaceID]    Script Date: 07/04/2022 23:40:32 ******/
CREATE NONCLUSTERED INDEX [IX_Rating_PlaceID] ON [dbo].[Rating]
(
	[PlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT ((0)) FOR [ClicksNumber]
GO
ALTER TABLE [dbo].[Doctor] ADD  DEFAULT ((0)) FOR [ClicksNumber]
GO
ALTER TABLE [dbo].[Doctor] ADD  DEFAULT (CONVERT([real],(0))) FOR [Rate]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((0)) FOR [ClicksNumber]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT (CONVERT([real],(0))) FOR [Rate]
GO
ALTER TABLE [dbo].[MedicalCenter] ADD  DEFAULT ((0)) FOR [ClicksNumber]
GO
ALTER TABLE [dbo].[MedicalCenter] ADD  DEFAULT (CONVERT([real],(0))) FOR [Rate]
GO
ALTER TABLE [dbo].[PlaceToVisit] ADD  DEFAULT ((0)) FOR [ClicksNumber]
GO
ALTER TABLE [dbo].[PlaceToVisit] ADD  DEFAULT (CONVERT([real],(0))) FOR [Rate]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Doctor_DoctorID] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Hotel_HotelID] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Hotel_HotelID]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Language_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Language_LanguageID]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_MedicalCenter_MedicalCenterID] FOREIGN KEY([MedicalCenterID])
REFERENCES [dbo].[MedicalCenter] ([MedicalCenterID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_MedicalCenter_MedicalCenterID]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_PlaceToVisit_PlaceID] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[PlaceToVisit] ([PlaceID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_PlaceToVisit_PlaceID]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Department_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Department_DepartmentID]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Language_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Language_LanguageID]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_MedicalCenter_MedicalCenterID] FOREIGN KEY([MedicalCenterID])
REFERENCES [dbo].[MedicalCenter] ([MedicalCenterID])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_MedicalCenter_MedicalCenterID]
GO
ALTER TABLE [dbo].[DoctorLog]  WITH CHECK ADD  CONSTRAINT [FK_DoctorLog_Department_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DoctorLog] CHECK CONSTRAINT [FK_DoctorLog_Department_DepartmentID]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Language_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_Language_LanguageID]
GO
ALTER TABLE [dbo].[MedicalCenter]  WITH CHECK ADD  CONSTRAINT [FK_MedicalCenter_Language_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[MedicalCenter] CHECK CONSTRAINT [FK_MedicalCenter_Language_LanguageID]
GO
ALTER TABLE [dbo].[PlaceToVisit]  WITH CHECK ADD  CONSTRAINT [FK_PlaceToVisit_Language_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
GO
ALTER TABLE [dbo].[PlaceToVisit] CHECK CONSTRAINT [FK_PlaceToVisit_Language_LanguageID]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Doctor_DoctorID] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Doctor_DoctorID]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Hotel_HotelID] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Hotel_HotelID]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_MedicalCenter_MedicalCenterID] FOREIGN KEY([MedicalCenterID])
REFERENCES [dbo].[MedicalCenter] ([MedicalCenterID])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_MedicalCenter_MedicalCenterID]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_PlaceToVisit_PlaceID] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[PlaceToVisit] ([PlaceID])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_PlaceToVisit_PlaceID]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [CH_DoctorRate] CHECK  (([Rate]>=(0) AND [Rate]<=(5)))
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [CH_DoctorRate]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [CH_HotelRate] CHECK  (([Rate]>=(0) AND [Rate]<=(5)))
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [CH_HotelRate]
GO
ALTER TABLE [dbo].[MedicalCenter]  WITH CHECK ADD  CONSTRAINT [CH_MedicalCenterRate] CHECK  (([Rate]>=(0) AND [Rate]<=(5)))
GO
ALTER TABLE [dbo].[MedicalCenter] CHECK CONSTRAINT [CH_MedicalCenterRate]
GO
ALTER TABLE [dbo].[PlaceToVisit]  WITH CHECK ADD  CONSTRAINT [CH_PlaceToVisitRate] CHECK  (([Rate]>=(0) AND [Rate]<=(5)))
GO
ALTER TABLE [dbo].[PlaceToVisit] CHECK CONSTRAINT [CH_PlaceToVisitRate]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [CH_RatingRate] CHECK  (([Rate]>=(0) AND [Rate]<=(5)))
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [CH_RatingRate]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [CheckRate] CHECK  (([Rate]>=(0) AND [Rate]<=(5)))
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [CheckRate]
GO
USE [master]
GO
ALTER DATABASE [GraduateProject] SET  READ_WRITE 
GO
