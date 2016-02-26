USE [master]
GO
/****** Object:  Database [AmitDB]    Script Date: 02/26/2016 10:02:20 ******/
CREATE DATABASE [AmitDB] ON  PRIMARY 
( NAME = N'AmitDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\AmitDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AmitDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\AmitDB_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AmitDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AmitDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AmitDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [AmitDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [AmitDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [AmitDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [AmitDB] SET ARITHABORT OFF
GO
ALTER DATABASE [AmitDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [AmitDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [AmitDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [AmitDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [AmitDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [AmitDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [AmitDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [AmitDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [AmitDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [AmitDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [AmitDB] SET  ENABLE_BROKER
GO
ALTER DATABASE [AmitDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [AmitDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [AmitDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [AmitDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [AmitDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [AmitDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [AmitDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [AmitDB] SET  READ_WRITE
GO
ALTER DATABASE [AmitDB] SET RECOVERY FULL
GO
ALTER DATABASE [AmitDB] SET  MULTI_USER
GO
ALTER DATABASE [AmitDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [AmitDB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'AmitDB', N'ON'
GO
USE [AmitDB]
GO
/****** Object:  User [sai]    Script Date: 02/26/2016 10:02:20 ******/
CREATE USER [sai] FOR LOGIN [sai] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 02/26/2016 10:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[productName] [varchar](50) NULL,
	[productPrice] [varchar](50) NULL,
	[productImagePath] [varchar](100) NULL,
	[productDescriptoin] [varchar](50) NULL,
	[categoryId] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N' Mobiles', N'24000', N'images/SamsungMobile.jpg', N'Best mobile to use', N'1')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'Television', N'29000', N'images/lg.jpg', N'Slim LED with HD', N'2')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'College Bags', N'750', N'images/bag.jpg', N'Extra ordinary bag for college', N'4')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'Spectables', N'1250', N'images/spec.jpg', N'Branded frames that make you look good!', N'3')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'Sony Ericson', N'14500', N'images/1.jpg', N'With 3g connection of airtel', N'1')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'Nokia 88000', N'18500', N'images/2.jpg', N'Get bluetooth headset free', N'1')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'Carbon E 20', N'5550', N'images/3.jpg', N'Dual sim mobile.', N'1')
INSERT [dbo].[tblProduct] ([productName], [productPrice], [productImagePath], [productDescriptoin], [categoryId]) VALUES (N'Samsung s3', N'22050', N'images/4.jpg', N'Best touchscreen mobile.', NULL)
/****** Object:  Table [dbo].[Student]    Script Date: 02/26/2016 10:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Roll] [varchar](50) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Student] ([Roll], [Name]) VALUES (N'1', N'Sai')
INSERT [dbo].[Student] ([Roll], [Name]) VALUES (N'2', N'Amit')
/****** Object:  Table [dbo].[Category]    Script Date: 02/26/2016 10:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[categoryId] [varchar](50) NULL,
	[categoryName] [varchar](50) NULL,
	[catImagePath] [varchar](50) NULL,
	[catDesc] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Category] ([categoryId], [categoryName], [catImagePath], [catDesc]) VALUES (N'1', N'Mobile', N'images/SamsungMobile.jpg', N'Get all company mobiles...!')
INSERT [dbo].[Category] ([categoryId], [categoryName], [catImagePath], [catDesc]) VALUES (N'2', N'Television', N'images/lg.jpg', N'New branded Television set with Tata sky FREE..')
INSERT [dbo].[Category] ([categoryId], [categoryName], [catImagePath], [catDesc]) VALUES (N'3', N'Spectacles', N'images/spec.jpg', N'High range spec in low rates...that suits your face')
INSERT [dbo].[Category] ([categoryId], [categoryName], [catImagePath], [catDesc]) VALUES (N'4', N'Bag', N'images/bag.jpg', N'Travelling bag')
