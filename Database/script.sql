USE [master]
GO
/****** Object:  Database [Clothes]    Script Date: 20/04/2022 13:19:20 ******/
CREATE DATABASE [Clothes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Clothes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Clothes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Clothes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Clothes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Clothes] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Clothes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Clothes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Clothes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Clothes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Clothes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Clothes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Clothes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Clothes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Clothes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Clothes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Clothes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Clothes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Clothes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Clothes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Clothes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Clothes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Clothes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Clothes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Clothes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Clothes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Clothes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Clothes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Clothes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Clothes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Clothes] SET  MULTI_USER 
GO
ALTER DATABASE [Clothes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Clothes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Clothes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Clothes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Clothes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Clothes] SET QUERY_STORE = OFF
GO
USE [Clothes]
GO
/****** Object:  Table [dbo].[photos]    Script Date: 20/04/2022 13:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[photos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_clothe] [int] NULL,
	[routing] [nvarchar](max) NULL,
 CONSTRAINT [PK_photos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20/04/2022 13:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[UnitsInStock] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/04/2022 13:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [int] NULL,
	[Mail] [nvarchar](50) NULL,
	[phone] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Category], [Price], [UnitsInStock]) VALUES (1, N'שמלת פשתן', N'שמלות', 45, 23)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Category], [Price], [UnitsInStock]) VALUES (2, N'מכנס גינס', N'מכנסים', 100, 8)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Category], [Price], [UnitsInStock]) VALUES (3, N'חולצת פשתן', N'חולצות', 1000, 8)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Category], [Price], [UnitsInStock]) VALUES (4, N'פיגמה אריה', N'פיגמות', 34, 3456)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password], [Mail], [phone]) VALUES (1, N'ss', 12321232, N'shira1534@gmail.com', 23456789)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [Mail], [phone]) VALUES (2, N' שירה', 12321232, N'avra123@gmail.com', 585226103)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [Mail], [phone]) VALUES (3, N' שירה', 12321232, N'aa@gmail.com', 585226103)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[photos]  WITH CHECK ADD  CONSTRAINT [FK_photos_Products] FOREIGN KEY([id_clothe])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[photos] CHECK CONSTRAINT [FK_photos_Products]
GO
USE [master]
GO
ALTER DATABASE [Clothes] SET  READ_WRITE 
GO
