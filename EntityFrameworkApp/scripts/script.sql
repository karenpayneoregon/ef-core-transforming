/*
	IMPORTANT: Change the database file path before executing script below
*/

USE [master]
GO
/****** Object:  Database [EF.SomeDatabase]    Script Date: 5/31/2022 12:44:38 PM ******/
CREATE DATABASE [EF.SomeDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EF.SomeDatabase', FILENAME = N'C:\Users\paynek\EF.SomeDatabase.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EF.SomeDatabase_log', FILENAME = N'C:\Users\paynek\EF.SomeDatabase_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EF.SomeDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EF.SomeDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EF.SomeDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EF.SomeDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EF.SomeDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EF.SomeDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EF.SomeDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EF.SomeDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EF.SomeDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EF.SomeDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [EF.SomeDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EF.SomeDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EF.SomeDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EF.SomeDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EF.SomeDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EF.SomeDatabase]
GO
/****** Object:  User [OED\paynek]    Script Date: 5/31/2022 12:44:39 PM ******/
CREATE USER [OED\paynek] FOR LOGIN [OED\paynek] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_datareader] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [OED\paynek]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [OED\paynek]
GO
/****** Object:  Table [dbo].[SomeEntities]    Script Date: 5/31/2022 12:44:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SomeEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SomeDateTime] [nvarchar](48) NOT NULL,
	[SomeGuid] [nvarchar](36) NOT NULL,
	[SomeInt] [nvarchar](64) NOT NULL,
	[SomeDouble] [nvarchar](64) NOT NULL,
	[SomeEnum] [nvarchar](max) NOT NULL,
	[SomeFlagsEnum] [nvarchar](max) NOT NULL,
	[SomeAddress] [nvarchar](45) NULL,
	[SomePrice] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_SomeEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SomeEntities] ON 

INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (1, N'2022-05-31 09:50:01.4366599', N'8b1d8a2a-675f-4ee3-816a-3d4712d53996', N'583802', N'8947.60296165366', N'Second', N'First, Second', N'29.152.52.187', CAST(5900.62 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (2, N'2022-05-31 09:50:01.6417001', N'edb0dbde-4776-4ad3-9fa2-3bf233d08957', N'721703', N'3522.104566694286', N'Third', N'First, Second', N'40.18.210.161', CAST(5290.31 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (3, N'2022-05-31 09:50:01.642036', N'5297dc22-55b2-4879-aa23-9197b4bfafe9', N'784067', N'8418.096699015283', N'Second', N'First, Second', N'34.47.116.73', CAST(6927.43 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (4, N'2022-05-31 09:50:01.6420908', N'af4d78eb-2dff-4dce-9e9b-3390ceae0869', N'555989', N'1399.3355824608989', N'First', N'First, Second', N'24.138.254.23', CAST(3370.99 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (5, N'2022-05-31 09:50:01.6421679', N'1d5e1389-c25a-4539-a079-bcc03d5f6244', N'182348', N'6295.132584075971', N'First', N'First, Second', N'139.188.87.33', CAST(4239.42 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (6, N'2022-05-31 09:50:01.6422051', N'7312d38f-f6a9-4dfa-bde7-a1d504ed0fd9', N'651101', N'5830.142216677844', N'Second', N'First, Second', N'145.228.95.252', CAST(93.80 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (7, N'2022-05-31 09:50:01.6422451', N'05fab66a-6de7-4c36-9248-387ef40c7cd7', N'846193', N'7262.438245705533', N'Second', N'First, Second', N'93.131.214.222', CAST(2681.74 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (8, N'2022-05-31 09:50:01.6422768', N'453a114e-b04a-4ae0-becb-f987a2b1b399', N'950675', N'2746.018177245752', N'Second', N'First, Second', N'60.177.35.94', CAST(6281.90 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (9, N'2022-05-31 09:50:01.6423208', N'67c469e5-dc6a-41b1-b50c-6711afb56a5f', N'818223', N'3106.2827739428185', N'Third', N'First, Second', N'201.0.89.247', CAST(319.56 AS Decimal(16, 2)))
INSERT [dbo].[SomeEntities] ([Id], [SomeDateTime], [SomeGuid], [SomeInt], [SomeDouble], [SomeEnum], [SomeFlagsEnum], [SomeAddress], [SomePrice]) VALUES (10, N'2022-05-31 09:50:01.6423531', N'c86b9f75-602c-46ae-a9ba-71c27c72875f', N'587632', N'9235.060675644809', N'First', N'First, Second', N'50.27.245.72', CAST(3264.95 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[SomeEntities] OFF
USE [master]
GO
ALTER DATABASE [EF.SomeDatabase] SET  READ_WRITE 
GO
