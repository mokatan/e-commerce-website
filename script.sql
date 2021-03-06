USE [master]
GO
/****** Object:  Database [eTicaret]    Script Date: 29.8.2013 17:59:02 ******/
CREATE DATABASE [eTicaret]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eTicaret', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\eTicaret.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'eTicaret_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\eTicaret_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [eTicaret] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eTicaret].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eTicaret] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eTicaret] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eTicaret] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eTicaret] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eTicaret] SET ARITHABORT OFF 
GO
ALTER DATABASE [eTicaret] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eTicaret] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [eTicaret] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eTicaret] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eTicaret] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eTicaret] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eTicaret] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eTicaret] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eTicaret] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eTicaret] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eTicaret] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eTicaret] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eTicaret] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eTicaret] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eTicaret] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eTicaret] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eTicaret] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eTicaret] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eTicaret] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eTicaret] SET  MULTI_USER 
GO
ALTER DATABASE [eTicaret] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eTicaret] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eTicaret] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eTicaret] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [eTicaret]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[ParentCategoryID] [int] NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[ImageId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[City] [int] NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
	[Country] [int] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](16) NOT NULL,
	[ShoppingCartID] [int] NOT NULL,
	[IsAcountSuspended] [bit] NOT NULL,
	[DateEntered] [date] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[ExceptionLogID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ExceptionMessage] [nvarchar](max) NOT NULL,
	[Stacktrace] [nvarchar](max) NOT NULL,
	[ClientIP] [nvarchar](20) NULL,
	[ClientBrowserAgent] [nvarchar](max) NULL,
	[CreationDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[ExceptionLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductPrice] [money] NOT NULL,
	[OrderTime] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentAmount] [money] NOT NULL,
	[DateOrdered] [date] NOT NULL,
	[IsTransactionComplete] [int] NOT NULL,
	[ErrorLog] [nvarchar](50) NULL,
	[ErrorMessage] [nchar](10) NULL,
	[PaymentDate] [date] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[PaymentID] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[UniqueId] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductDescription] [nvarchar](100) NOT NULL,
	[Rating] [float] NOT NULL,
	[Price] [money] NOT NULL,
	[StockCount] [int] NOT NULL,
	[ImageId] [uniqueidentifier] NULL,
	[CreationTime] [datetime] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[ShoppingCartID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShoppingCartDetail]    Script Date: 29.8.2013 17:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartDetail](
	[ShoppingCartDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ShoppingCartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ItemCount] [int] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ShoppingCartDetail] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [ParentCategoryID], [CategoryName], [ImageId], [Description]) VALUES (1, NULL, N'Kıyafet', NULL, N'Giyecekler')
INSERT [dbo].[Category] ([CategoryID], [ParentCategoryID], [CategoryName], [ImageId], [Description]) VALUES (2, NULL, N'Spor', NULL, N'Spor Malzemeleri')
INSERT [dbo].[Category] ([CategoryID], [ParentCategoryID], [CategoryName], [ImageId], [Description]) VALUES (3, NULL, N'Elektronik', NULL, N'Elektronik Aletler')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Address], [City], [PostalCode], [Country], [Phone], [Email], [Password], [ShoppingCartID], [IsAcountSuspended], [DateEntered]) VALUES (2, N'fff', N'fff', N'fff', 33, N'33', 22, N'22232332', N'fff', N'fff', 1, 0, CAST(0x7D370B00 AS Date))
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (1, N'a8ad427b-61a2-4259-bcd7-8cb2c269aa51', N'Kemer', N'Giyecek', 5, 15.0000, 44, N'6e91314f-3b2c-4988-b685-6e4a0e128d38', CAST(0x0000A2060113DF61 AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (2, N'ef713e14-f335-40f3-afa9-5d3391e63950', N'Pantolon', N'Giyecek', 3, 30.0000, 44, N'ce42a63a-15db-4829-add0-22cbbcf14017', CAST(0x0000A2060113F928 AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (3, N'5130da44-709b-43ee-8d5e-9308d16e0025', N'Ceket', N'Giyecek', 3, 33.0000, 45, N'029e27f8-de95-4435-aadc-8a90d3e7f986', CAST(0x0000A206011437BE AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (4, N'40943cc9-2890-4c0a-82f0-e99ba983b2d0', N'Kazak', N'Giyecek', 4, 50.0000, 10, N'eba3dad2-5356-40d2-ae27-1475282d3715', CAST(0x0000A20601144BAA AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (5, N'7e661fa5-eb29-4408-babe-17ccfcba7902', N'Ayakkabı', N'Ayak için', 5, 90.0000, 10, N'c088a23f-e5bf-4d66-b46a-dc3a01f0313e', CAST(0x0000A20601146297 AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (6, N'0e3c43e0-4049-4121-a2aa-44e560191b63', N'Şort', N'Ayak için', 3, 25.0000, 15, N'e224d5b6-63ba-43b1-8c4a-2a5857429602', CAST(0x0000A20D00BA02BE AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (7, N'8b7c4190-8020-4fd6-a586-a54b013920c8', N'Tayt', N'Giyecek', 2, 40.0000, 20, N'7939d851-d00b-4d1f-a356-022f577c8bdc', CAST(0x0000A20D00BA766E AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (8, N'a873f92b-1ab4-4df8-af0c-2ea9bee26ba4', N'Çorap', N'Ayak için', 4, 5.0000, 50, N'909ff9cd-5a31-4df4-ab1e-c4a2abdb0ecf', CAST(0x0000A20D00BA9327 AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (9, N'3ec34ba1-0500-48ee-bcdc-2face27082ca', N'Etek', N'Giyecek', 3, 55.0000, 5, N'132d760b-5a27-491f-b0f7-a1197167ac43', CAST(0x0000A20D00BAB358 AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (10, N'3e37067a-6fae-42ec-8f66-63b6fc60bbbf', N'Tişört', N'Giyecek', 3, 55.0000, 40, N'b1f4635e-a9ce-4725-8618-95a2f53a6095', CAST(0x0000A20D00BAD8BC AS DateTime), 1)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (11, N'd980340c-93f5-4787-97d3-8bf92311234c', N'Futbol Topu', N'Spor', 4, 15.0000, 10, N'6b02d7df-388c-4d3a-a2fa-e005f446937b', CAST(0x0000A20D00BAF590 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (12, N'b8ea4628-6521-4aef-b153-435d3918d963', N'Basketbol Topu', N'Spor', 4, 20.0000, 10, N'f7fa071b-878b-44d8-96b1-0471d61921fd', CAST(0x0000A20D00BB0EAE AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (13, N'9086bac8-c611-4166-99d4-b89e2b19ad45', N'Hentbol Topu', N'Spor', 3, 35.0000, 20, N'0efaaea0-3ab4-4657-9f5f-1cc73587a59c', CAST(0x0000A20D00BB2648 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (14, N'ee7ed986-1f4a-4910-af93-5d896c75fe17', N'Kaleci Eldiveni', N'Spor', 4, 20.0000, 20, N'95ebd63c-7de7-4002-a7a8-a16e201d57ce', CAST(0x0000A20D00BB3B33 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (15, N'cc7470a3-2ebf-4c65-8ccc-0aaa8dd79d8b', N'Krampon', N'Spor', 5, 120.0000, 30, N'a42f371c-22fd-413d-807c-b8e85d8d7595', CAST(0x0000A20D00BB71EA AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (16, N'a2f073b0-c5fc-4d13-a427-fbcf67f14e29', N'Basketbol Ayakkabısı', N'Spor', 4, 145.0000, 33, N'd1241b84-0d13-4613-bea7-120acbd14193', CAST(0x0000A20D00BB8BEB AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (17, N'5c16839f-c89e-4a67-a55d-064fa29f1e71', N'Dumbell Seti', N'Spor', 5, 80.0000, 10, N'f969a426-edba-4111-a2ad-8b87d63f1fde', CAST(0x0000A20D00BBCE82 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (18, N'2a893667-21ba-4e8b-a31f-2bbcab612874', N'Tenis Raketi', N'Spor', 4, 80.0000, 10, N'384eebd0-050e-4a23-b4ec-001dd808507a', CAST(0x0000A20D00BBEB89 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (19, N'9767eda2-fcae-4616-a496-4d716c2b324b', N'Tenis Topu', N'Spor', 3, 5.0000, 50, N'fd9ac773-cbba-467a-bc86-7146de3515f1', CAST(0x0000A20D00BBFE06 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (20, N'bd42c05d-c3bd-4d66-b69b-143b7d025062', N'Spor Çantası', N'Spor', 5, 75.0000, 20, N'5c323449-2449-4e2d-a1ab-b4dc1aa5e63a', CAST(0x0000A20D00BC14D1 AS DateTime), 2)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (21, N'd7b0b6fa-bf66-4b8c-b08e-e1122007873e', N'Cep Telefonu', N'Elektronik', 5, 350.0000, 100, N'b85d74ca-cd76-475e-9f43-4344462aee9b', CAST(0x0000A20D00BC3D25 AS DateTime), 3)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (22, N'ff707e48-c6e0-436b-9509-4857a35515e1', N'Şarj Aleti', N'Elektronik', 3, 15.0000, 100, N'509678ff-0f00-4686-b4d2-438862d84388', CAST(0x0000A20D00BC5332 AS DateTime), 3)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (23, N'2dc81eae-c26a-4cc3-956c-c8ef13015213', N'Laptop', N'Elektronik', 4, 800.0000, 50, N'9bd3b6d0-9358-4605-b946-6639dca783e1', CAST(0x0000A20D00BC6572 AS DateTime), 3)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (24, N'cc51cb53-3fba-426f-806f-31864fe05779', N'Hafıza Kartı', N'Elektronik', 4, 10.0000, 100, N'4da8a5cc-51e9-4d22-9cdc-dab3fbbf9baa', CAST(0x0000A20D00BC7604 AS DateTime), 3)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (25, N'0332786e-3ec6-4e8f-bccd-1e2f4e168b36', N'Klavye', N'Elektronik', 4, 20.0000, 40, N'f4d522cf-a352-4c1d-b9fe-f67a78e1c785', CAST(0x0000A20D00BC9007 AS DateTime), 3)
INSERT [dbo].[Product] ([ProductID], [UniqueId], [ProductName], [ProductDescription], [Rating], [Price], [StockCount], [ImageId], [CreationTime], [CategoryID]) VALUES (26, N'd5dfc1da-b13a-4b17-9f72-eee43fe31eba', N'Mouse', N'Elektronik', 5, 15.0000, 40, N'36a58173-1572-4aec-8b1c-a2e9ca9f2890', CAST(0x0000A20D00BCA97A AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ShoppingCart] ON 

INSERT [dbo].[ShoppingCart] ([ShoppingCartID]) VALUES (1)
SET IDENTITY_INSERT [dbo].[ShoppingCart] OFF
SET IDENTITY_INSERT [dbo].[ShoppingCartDetail] ON 

INSERT [dbo].[ShoppingCartDetail] ([ShoppingCartDetailId], [ShoppingCartId], [ProductId], [ItemCount], [CreationTime]) VALUES (6, 1, 1, 1, CAST(0x0000A22800B89481 AS DateTime))
INSERT [dbo].[ShoppingCartDetail] ([ShoppingCartDetailId], [ShoppingCartId], [ProductId], [ItemCount], [CreationTime]) VALUES (7, 1, 2, 1, CAST(0x0000A22900B4096C AS DateTime))
INSERT [dbo].[ShoppingCartDetail] ([ShoppingCartDetailId], [ShoppingCartId], [ProductId], [ItemCount], [CreationTime]) VALUES (8, 1, 3, 1, CAST(0x0000A22900B5E999 AS DateTime))
SET IDENTITY_INSERT [dbo].[ShoppingCartDetail] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Customer]    Script Date: 29.8.2013 17:59:02 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [IX_Customer] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Customer_1]    Script Date: 29.8.2013 17:59:02 ******/
CREATE NONCLUSTERED INDEX [IX_Customer_1] ON [dbo].[Customer]
(
	[Email] ASC,
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_1]    Script Date: 29.8.2013 17:59:02 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [IX_Product_1] UNIQUE NONCLUSTERED 
(
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product]    Script Date: 29.8.2013 17:59:02 ******/
CREATE NONCLUSTERED INDEX [IX_Product] ON [dbo].[Product]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCartDetail_1]    Script Date: 29.8.2013 17:59:02 ******/
ALTER TABLE [dbo].[ShoppingCartDetail] ADD  CONSTRAINT [IX_ShoppingCartDetail_1] UNIQUE NONCLUSTERED 
(
	[ShoppingCartId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCartDetail]    Script Date: 29.8.2013 17:59:02 ******/
CREATE NONCLUSTERED INDEX [IX_ShoppingCartDetail] ON [dbo].[ShoppingCartDetail]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_IsAcountSuspended]  DEFAULT ((0)) FOR [IsAcountSuspended]
GO
ALTER TABLE [dbo].[ExceptionLog] ADD  CONSTRAINT [DF_ExceptionLog_CreationDateTime]  DEFAULT (getdate()) FOR [CreationDateTime]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_OrderDetail_OrderDate]  DEFAULT (getdate()) FOR [OrderTime]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UniqueId]  DEFAULT (newid()) FOR [UniqueId]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_PictureId]  DEFAULT (newid()) FOR [ImageId]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreationDate]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [dbo].[ShoppingCartDetail] ADD  CONSTRAINT [DF_ShoppingCartDetail_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category1] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category1]
GO
ALTER TABLE [dbo].[ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionLog_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Orders]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ShoppingCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[ShoppingCartDetail] CHECK CONSTRAINT [FK_ShoppingCartDetail_Product]
GO
ALTER TABLE [dbo].[ShoppingCartDetail]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartDetail_ShoppingCart] FOREIGN KEY([ShoppingCartId])
REFERENCES [dbo].[ShoppingCart] ([ShoppingCartID])
GO
ALTER TABLE [dbo].[ShoppingCartDetail] CHECK CONSTRAINT [FK_ShoppingCartDetail_ShoppingCart]
GO
USE [master]
GO
ALTER DATABASE [eTicaret] SET  READ_WRITE 
GO
