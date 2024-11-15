USE [master]
GO
/****** Object:  Database [SistemaIoon]    Script Date: 14/11/2024 15:34:20 ******/
CREATE DATABASE [SistemaIoon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaIoon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SistemaIoon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaIoon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SistemaIoon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SistemaIoon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaIoon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaIoon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaIoon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaIoon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaIoon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaIoon] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaIoon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaIoon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaIoon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaIoon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaIoon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaIoon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaIoon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaIoon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaIoon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaIoon] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SistemaIoon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaIoon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaIoon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaIoon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaIoon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaIoon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaIoon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaIoon] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaIoon] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaIoon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaIoon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaIoon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaIoon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaIoon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaIoon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaIoon', N'ON'
GO
ALTER DATABASE [SistemaIoon] SET QUERY_STORE = OFF
GO
USE [SistemaIoon]
GO
/****** Object:  Table [dbo].[Commerce]    Script Date: 14/11/2024 15:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commerce](
	[CommerceId] [uniqueidentifier] NOT NULL,
	[CommerceName] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[RUC] [nvarchar](50) NULL,
	[State] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommerceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDetails]    Script Date: 14/11/2024 15:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetails](
	[DetailId] [uniqueidentifier] NOT NULL,
	[SaleId] [uniqueidentifier] NULL,
	[Product] [nvarchar](255) NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 14/11/2024 15:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SaleId] [uniqueidentifier] NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[CommerceId] [uniqueidentifier] NULL,
	[State] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 14/11/2024 15:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [uniqueidentifier] NOT NULL,
	[StateName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14/11/2024 15:34:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[CommerceId] [uniqueidentifier] NULL,
	[State] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Commerce] ([CommerceId], [CommerceName], [Address], [RUC], [State]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'por favor', N'señor', N'78', N'48bba54e-6cb0-4e80-803e-39d8e98fac83')
GO
INSERT [dbo].[SaleDetails] ([DetailId], [SaleId], [Product], [Quantity], [Price]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'gaseosa', 10, CAST(25.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Sales] ([SaleId], [SaleDate], [UserId], [CommerceId], [State]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', CAST(N'2024-11-14T21:08:37.927' AS DateTime), N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'48bba54e-6cb0-4e80-803e-39d8e98fac83')
GO
INSERT [dbo].[States] ([StateId], [StateName]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'CasiCompleto')
INSERT [dbo].[States] ([StateId], [StateName]) VALUES (N'48bba54e-6cb0-4e80-803e-39d8e98fac83', N'Completed')
INSERT [dbo].[States] ([StateId], [StateName]) VALUES (N'b2e0dcbf-0cb1-43c2-b86a-45dbcad372d3', N'Pending')
INSERT [dbo].[States] ([StateId], [StateName]) VALUES (N'6ae77aaa-2f3f-450e-a23c-4d33a1dbdb15', N'Canceled')
INSERT [dbo].[States] ([StateId], [StateName]) VALUES (N'bad80cc4-07df-446d-94fa-93445188bee3', N'Active')
INSERT [dbo].[States] ([StateId], [StateName]) VALUES (N'd4acc7ae-6bb7-472b-82a0-a119e261491b', N'Inactive')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [Role], [CommerceId], [State]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'ender', N'12355', N'admin', N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'48bba54e-6cb0-4e80-803e-39d8e98fac83')
GO
ALTER TABLE [dbo].[Commerce]  WITH CHECK ADD FOREIGN KEY([State])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sales] ([SaleId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([CommerceId])
REFERENCES [dbo].[Commerce] ([CommerceId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([State])
REFERENCES [dbo].[States] ([StateId])
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([CommerceId])
REFERENCES [dbo].[Commerce] ([CommerceId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([State])
REFERENCES [dbo].[States] ([StateId])
GO
USE [master]
GO
ALTER DATABASE [SistemaIoon] SET  READ_WRITE 
GO
