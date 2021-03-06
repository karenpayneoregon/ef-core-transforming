/*
	Path to database needs attention
*/

USE [master]
GO
CREATE DATABASE [wines]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'wines', FILENAME = N'C:\Users\paynek\wines.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'wines_log', FILENAME = N'C:\Users\paynek\wines_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [wines] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [wines].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [wines] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [wines] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [wines] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [wines] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [wines] SET ARITHABORT OFF 
GO
ALTER DATABASE [wines] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [wines] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [wines] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [wines] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [wines] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [wines] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [wines] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [wines] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [wines] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [wines] SET  ENABLE_BROKER 
GO
ALTER DATABASE [wines] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [wines] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [wines] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [wines] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [wines] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [wines] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [wines] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [wines] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [wines] SET  MULTI_USER 
GO
ALTER DATABASE [wines] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [wines] SET DB_CHAINING OFF 
GO
ALTER DATABASE [wines] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [wines] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [wines] SET DELAYED_DURABILITY = DISABLED 
GO
USE [wines]
GO
/****** Object:  User [OED\paynek]    Script Date: 5/28/2022 10:54:43 AM ******/
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
/****** Object:  Table [dbo].[Wines]    Script Date: 5/28/2022 10:54:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wines](
	[WineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[WineVariantId] [int] NOT NULL,
 CONSTRAINT [PK_Wines] PRIMARY KEY CLUSTERED 
(
	[WineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WineVariants]    Script Date: 5/28/2022 10:54:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WineVariants](
	[WineVariantId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_WineVariants] PRIMARY KEY CLUSTERED 
(
	[WineVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Wines] ON 

INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (1, N'Gutturnio', 0)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (2, N'Ortrugo', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (3, N'Veuve Clicquot Rose', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (4, N'Whispering Angel Rose', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (5, N'Pinot Grigio', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (6, N'Clicquot Rose II', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (7, N'Angel Rose', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineVariantId]) VALUES (8, N'Pinot 2022', 1)
SET IDENTITY_INSERT [dbo].[Wines] OFF
INSERT [dbo].[WineVariants] ([WineVariantId], [Name]) VALUES (0, N'Red')
INSERT [dbo].[WineVariants] ([WineVariantId], [Name]) VALUES (1, N'White')
INSERT [dbo].[WineVariants] ([WineVariantId], [Name]) VALUES (2, N'Rose')
/****** Object:  Index [IX_Wines_WineVariantId]    Script Date: 5/28/2022 10:54:43 AM ******/
CREATE NONCLUSTERED INDEX [IX_Wines_WineVariantId] ON [dbo].[Wines]
(
	[WineVariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Wines]  WITH CHECK ADD  CONSTRAINT [FK_Wines_WineVariants_WineVariantId] FOREIGN KEY([WineVariantId])
REFERENCES [dbo].[WineVariants] ([WineVariantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wines] CHECK CONSTRAINT [FK_Wines_WineVariants_WineVariantId]
GO
USE [master]
GO
ALTER DATABASE [wines] SET  READ_WRITE 
GO
