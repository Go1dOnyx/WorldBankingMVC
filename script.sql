USE [master]
GO
/****** Object:  Database [WorldBankDB]    Script Date: 5/18/2023 8:38:51 PM ******/
CREATE DATABASE [WorldBankDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorldBankDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WorldBankDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorldBankDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WorldBankDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WorldBankDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorldBankDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorldBankDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorldBankDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorldBankDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorldBankDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorldBankDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorldBankDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorldBankDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorldBankDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorldBankDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorldBankDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorldBankDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorldBankDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorldBankDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorldBankDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorldBankDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorldBankDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorldBankDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorldBankDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorldBankDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorldBankDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorldBankDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorldBankDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorldBankDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WorldBankDB] SET  MULTI_USER 
GO
ALTER DATABASE [WorldBankDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorldBankDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorldBankDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorldBankDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorldBankDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorldBankDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WorldBankDB] SET QUERY_STORE = OFF
GO
USE [WorldBankDB]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 5/18/2023 8:38:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(100000,1) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[EmailAddress] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CheckingBalance] [decimal](14, 2) NOT NULL,
	[SavingBalance] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100000, N'LunaD19', N'James231@gmail.com', N'HoneyComb21', N'James', N'Dan', N'Daves', CAST(14750.82 AS Decimal(14, 2)), CAST(50050.25 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100001, N'Bravo3Om', N'johnadder34@gmail.com', N'The247Stuff@', N'John', NULL, N'Adder', CAST(43020.43 AS Decimal(14, 2)), CAST(102355.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100002, N'23SupAver1', N'thisisluke23@gmail.com', N'Lu4523@!Here', N'Luke', NULL, N'Van', CAST(55230.12 AS Decimal(14, 2)), CAST(503025.43 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100003, N'DazJohn45', N'john431daz@gmail.com', N'MTIfun21!', N'John', NULL, N'Daz', CAST(34034.37 AS Decimal(14, 2)), CAST(50234.14 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100004, N'YuoHou9', N'Houyan11hou@gmail.com', N'Thou43Apple!@', N'Houyan', N'Tai', N'Hou', CAST(67346.50 AS Decimal(14, 2)), CAST(80234.56 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100006, N'LouisJohnson1', N'louis1epic23@gmail.com', N'@EpicG345', N'Louis', NULL, N'Johnson', CAST(67412.67 AS Decimal(14, 2)), CAST(70324.67 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100007, N'LastMan_1', N'lonewolfman@gmail.com', N'Edg2Nev#', N'Marco', N'Josey', N'Tapia', CAST(8234.56 AS Decimal(14, 2)), CAST(34678.90 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100009, N'Admin1', N'worldbank1admin@gmail.com', N'@dmin_Pass23', N'Daniel', N'Trev', N'Yohov', CAST(123456.81 AS Decimal(14, 2)), CAST(574578.97 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100010, N'HeMyBoi_3', N'lukemybro34@gmail.com', N'345Ap@trey', N'Joan', N'Trench', N'Davis', CAST(13403.00 AS Decimal(14, 2)), CAST(145230.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100011, N'Found_Agent1', N'thefoundingagent1@gmail.com', N'Ag3nt_Found23', N'Treev', N'Lin', N'Fund', CAST(245678.00 AS Decimal(14, 2)), CAST(2678902.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100012, N'Found_Agent2', N'thefound1@gmai.com', N'F@und12#2', N'Thomas', NULL, N'Lavis', CAST(345123.00 AS Decimal(14, 2)), CAST(4562345.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100013, N'JoseD_23', N'cust12foundation@gmai.com', N'12Crust@3_', N'Jose', N'', N'Dome', CAST(2345.00 AS Decimal(14, 2)), CAST(45678.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100014, N'Apple_1', N'appleproductions4@gmail.com', N'applePro@12#', N'Lucas', N'', N'River', CAST(578901.00 AS Decimal(14, 2)), CAST(1923789.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100016, N'MoonzFu23', N'famousperson1@gmail.com', N'Red23_!@E', N'Funte', N'', N'Donz', CAST(134546.00 AS Decimal(14, 2)), CAST(1234567.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100017, N'ApCorp1', N'applecorpagent1@gmail.com', N'corp1_age3nt', N'Jose', N'Fur', N'Daven', CAST(23456.00 AS Decimal(14, 2)), CAST(345671.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100018, N'Admin2', N'worldbank2admin@gmail.com', N'@dmin_Pass23', N'Jonathan', N'', N'Denver', CAST(123456.00 AS Decimal(14, 2)), CAST(2345768.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100019, N'AdCorp_2', N'advercorp19@yahoo.com', N'@_Erver!23', N'Juan', N'Tru', N'Londor', CAST(2345.00 AS Decimal(14, 2)), CAST(132456.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100020, N'Admin3', N'worldbank3admin@gmail.com', N'@dmin_Pass24', N'Losent', N'Fin', N'Dayer', CAST(2345.00 AS Decimal(14, 2)), CAST(45678.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100021, N'SonyVe1', N'playstation34@gmail.com', N'playSony24/7@', N'Yiou', N'Hang', N'Tai', CAST(345678.00 AS Decimal(14, 2)), CAST(23451345.00 AS Decimal(14, 2)))
INSERT [dbo].[Accounts] ([AccountID], [UserName], [EmailAddress], [Password], [FirstName], [MiddleName], [LastName], [CheckingBalance], [SavingBalance]) VALUES (100022, N'WarterLake23', N'warterschoollake@gmail.com', N'@district23', N'Jose', N'', N'Johnson', CAST(12345.00 AS Decimal(14, 2)), CAST(345671.00 AS Decimal(14, 2)))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
USE [master]
GO
ALTER DATABASE [WorldBankDB] SET  READ_WRITE 
GO
