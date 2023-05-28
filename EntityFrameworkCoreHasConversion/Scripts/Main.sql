USE [master]
GO
/****** Object:  Database [EntityFrameworkCoreSamples]    Script Date: 7/27/2022 12:04:24 PM ******/
CREATE DATABASE [EntityFrameworkCoreSamples]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EntityFrameworkCoreSamples', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EntityFrameworkCoreSamples.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EntityFrameworkCoreSamples_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EntityFrameworkCoreSamples_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EntityFrameworkCoreSamples].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET ARITHABORT OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET  MULTI_USER 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET QUERY_STORE = OFF
GO
USE [EntityFrameworkCoreSamples]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/27/2022 12:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Active] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[Roles] [nvarchar](max) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 7/27/2022 12:04:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Addresses] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [UserName], [Email], [Active], [CreatedDate], [Roles]) VALUES (1, N'jamesadams', N'james@example.com', 1, CAST(N'2013-01-20T00:00:00.0000000' AS DateTime2), N'User,Admin')
INSERT [dbo].[Account] ([Id], [UserName], [Email], [Active], [CreatedDate], [Roles]) VALUES (2, N'karenpayne', N'payne@gmail.com', 1, CAST(N'2022-05-02T00:00:00.0000000' AS DateTime2), N'User,Admin,Owner')
INSERT [dbo].[Account] ([Id], [UserName], [Email], [Active], [CreatedDate], [Roles]) VALUES (3, N'billsmith', N'smith@gmail.com', 1, CAST(N'2021-01-12T00:00:00.0000000' AS DateTime2), N'User')
INSERT [dbo].[Account] ([Id], [UserName], [Email], [Active], [CreatedDate], [Roles]) VALUES (4, N'jackwilliams', N'will@comcast.com', 1, CAST(N'1999-07-22T00:00:00.0000000' AS DateTime2), N'User')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DateOfBirth], [Addresses]) VALUES (1, N'Karen', N'Payne', CAST(N'1956-09-24T00:00:00.0000000' AS DateTime2), N'[{"Type":"Business","Company":"ABC","Number":"1","Street":"111 Orange Way","City":"Salem"},{"Type":"Home","Company":"ABC","Number":"2","Street":"123 Green Ave","City":"Salem"}]')
SET IDENTITY_INSERT [dbo].[Person] OFF
USE [master]
GO
ALTER DATABASE [EntityFrameworkCoreSamples] SET  READ_WRITE 
GO
