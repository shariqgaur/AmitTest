USE [master]
GO
/****** Object:  Database [MDK_DB]    Script Date: 02/24/2016 20:56:39 ******/
CREATE DATABASE [MDK_DB] ON  PRIMARY 
( NAME = N'MDK_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\DATA\MDK_DB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MDK_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\DATA\MDK_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MDK_DB] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MDK_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MDK_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MDK_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MDK_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MDK_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MDK_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [MDK_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MDK_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MDK_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MDK_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MDK_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MDK_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MDK_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MDK_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MDK_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MDK_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MDK_DB] SET  DISABLE_BROKER
GO
ALTER DATABASE [MDK_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MDK_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MDK_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MDK_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MDK_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MDK_DB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MDK_DB] SET  READ_WRITE
GO
ALTER DATABASE [MDK_DB] SET RECOVERY FULL
GO
ALTER DATABASE [MDK_DB] SET  MULTI_USER
GO
ALTER DATABASE [MDK_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MDK_DB] SET DB_CHAINING OFF
GO
USE [MDK_DB]
GO
/****** Object:  User [iwebuser]    Script Date: 02/24/2016 20:56:40 ******/
CREATE USER [iwebuser] FOR LOGIN [iwebuser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ITDetails]    Script Date: 02/24/2016 20:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITDetails](
	[Pid] [int] NULL,
	[IncomeTax] [nvarchar](50) NULL,
	[PAN_NO] [nvarchar](50) NULL,
	[TAN_NO] [nvarchar](50) NULL,
	[SalesTax] [nvarchar](50) NULL,
	[VAT_NO] [nvarchar](50) NULL,
	[CST_NO] [nvarchar](50) NULL,
	[PTRC_NO] [nvarchar](50) NULL,
	[PTEC_NO] [nvarchar](50) NULL,
	[ServiceTaxNo] [nvarchar](50) NULL,
	[ExciseNo] [nvarchar](50) NULL,
	[PFESI_NO] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMangement]    Script Date: 02/24/2016 20:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMangement](
	[Uid] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](20) NULL,
	[LoginName] [nvarchar](200) NULL,
	[Password] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserMangement] PRIMARY KEY CLUSTERED 
(
	[Uid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserMangement] ON
INSERT [dbo].[UserMangement] ([Uid], [Role], [LoginName], [Password], [IsActive]) VALUES (1, N'Admin', N'amit', N'amit', 1)
INSERT [dbo].[UserMangement] ([Uid], [Role], [LoginName], [Password], [IsActive]) VALUES (2, N'Admin', N'mohan', N'mohan', 1)
INSERT [dbo].[UserMangement] ([Uid], [Role], [LoginName], [Password], [IsActive]) VALUES (3, N'Accountant', N'anand', N'anand', 0)
SET IDENTITY_INSERT [dbo].[UserMangement] OFF
/****** Object:  Table [dbo].[RoleMangemant]    Script Date: 02/24/2016 20:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMangemant](
	[Rid] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_RoleMangemant] PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoleMangemant] ON
INSERT [dbo].[RoleMangemant] ([Rid], [RoleName]) VALUES (1, N'SuperAdmin')
INSERT [dbo].[RoleMangemant] ([Rid], [RoleName]) VALUES (2, N'Admin')
INSERT [dbo].[RoleMangemant] ([Rid], [RoleName]) VALUES (3, N'Accountant')
SET IDENTITY_INSERT [dbo].[RoleMangemant] OFF
/****** Object:  Table [dbo].[PersonalInformation]    Script Date: 02/24/2016 20:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalInformation](
	[Pid] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Address] [nvarchar](1000) NULL,
	[ContactNo] [nvarchar](20) NULL,
	[AlternateNo] [nvarchar](20) NULL,
	[EmailID] [nvarchar](200) NULL,
	[DateOfBirth] [nvarchar](100) NULL,
	[BusinessName] [nvarchar](100) NULL,
	[BusinessType] [nvarchar](20) NULL,
	[BusinessGUID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Personal_Info] PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PersonalInformation] ON
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (1, N'sai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sai786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (2, N'sai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sai786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'786786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'786786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'786786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (7, N'tere naam', NULL, NULL, N'Pashan pune.', N'9096', NULL, N'a@a.com', N'2017-01-01T18:30:00.000Z', NULL, N'Propriotorship', N'786786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (8, N'tere naam', N'dsfs', N'fsdfs', N'Pashan pune.', N'9096', NULL, N'a@a.com', N'2017-01-01T18:30:00.000Z', NULL, N'Propriotorship', N'786786786')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (16, N'sai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'78678678699')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (17, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (18, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (19, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (20, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (21, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (22, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (23, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'777')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (24, N'amit', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'FMAG-2322cc9a')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (25, NULL, NULL, NULL, N'dsf', N'9960', NULL, NULL, N'2015-12-31T18:30:00.000Z', NULL, N'Propriotorship', N'TCSF-ee606c81')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (26, NULL, NULL, NULL, N'Shirdii.', N'9960', NULL, N'amitd@gmail.com', N'2015-12-31T18:30:00.000Z', NULL, N'Partnership', N'MNCJ-1931a135')
INSERT [dbo].[PersonalInformation] ([Pid], [FirstName], [MiddleName], [LastName], [Address], [ContactNo], [AlternateNo], [EmailID], [DateOfBirth], [BusinessName], [BusinessType], [BusinessGUID]) VALUES (27, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sgh', NULL, N'BWIC-00db9dfd')
SET IDENTITY_INSERT [dbo].[PersonalInformation] OFF
/****** Object:  Table [dbo].[BankInfo]    Script Date: 02/24/2016 20:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](200) NULL,
	[Branch] [nvarchar](200) NULL,
	[AccountNo] [nvarchar](50) NULL,
	[IFSC_CODE] [nvarchar](50) NULL,
	[MICR_CODE] [nvarchar](50) NULL,
	[BANK_ADDRESS] [nvarchar](500) NULL,
	[BANK_CONTACT_NO] [nvarchar](100) NULL,
	[PersonalInfoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__BankInfo__Person__0425A276]    Script Date: 02/24/2016 20:56:40 ******/
ALTER TABLE [dbo].[BankInfo]  WITH CHECK ADD FOREIGN KEY([PersonalInfoID])
REFERENCES [dbo].[PersonalInformation] ([Pid])
GO
