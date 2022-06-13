USE [master]
GO
/****** Object:  Database [AdZooSalon]    Script Date: 11.05.2022 8:32:29 ******/
CREATE DATABASE [AdZooSalon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdZooSalon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AdZooSalon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AdZooSalon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AdZooSalon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AdZooSalon] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdZooSalon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdZooSalon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdZooSalon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdZooSalon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdZooSalon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdZooSalon] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdZooSalon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdZooSalon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdZooSalon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdZooSalon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdZooSalon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdZooSalon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdZooSalon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdZooSalon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdZooSalon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdZooSalon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdZooSalon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdZooSalon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdZooSalon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdZooSalon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdZooSalon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdZooSalon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdZooSalon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdZooSalon] SET RECOVERY FULL 
GO
ALTER DATABASE [AdZooSalon] SET  MULTI_USER 
GO
ALTER DATABASE [AdZooSalon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdZooSalon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdZooSalon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdZooSalon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AdZooSalon] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AdZooSalon', N'ON'
GO
ALTER DATABASE [AdZooSalon] SET QUERY_STORE = OFF
GO
USE [AdZooSalon]
GO
/****** Object:  Table [dbo].[AuthHistory]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthHistory](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_AuthHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[PhotoPath] [nchar](1000) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Birthday] [date] NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[GenderId] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientService]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientService](
	[Id] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_ClientService] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Post] [nvarchar](50) NOT NULL,
	[PhotoPath] [varbinary](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PhotoPath] [varchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Cost] [money] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsActual] [bit] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCategory]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategory](
	[Id] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ServiceCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11.05.2022 8:32:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Lastenter] [date] NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Role] ([Id], [Name], [PhotoPath]) VALUES (1, N'admin', NULL)
INSERT [dbo].[Role] ([Id], [Name], [PhotoPath]) VALUES (2, N'manager', NULL)
INSERT [dbo].[Role] ([Id], [Name], [PhotoPath]) VALUES (3, N'accountant', NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Login], [Password], [Lastenter], [RoleId]) VALUES (1, N'Umerova', N'Adelina', N'admin', N'admin', NULL, 1)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Login], [Password], [Lastenter], [RoleId]) VALUES (2, N'Умерова', N'Аделина', N'manager', N'manager', NULL, 2)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Login], [Password], [Lastenter], [RoleId]) VALUES (3, N'Умерова', N'Дарина', N'booker', N'booker', NULL, 3)
GO
ALTER TABLE [dbo].[AuthHistory]  WITH CHECK ADD  CONSTRAINT [FK_AuthHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AuthHistory] CHECK CONSTRAINT [FK_AuthHistory_User]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Gender]
GO
ALTER TABLE [dbo].[ClientService]  WITH CHECK ADD  CONSTRAINT [FK_ClientService_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ClientService] CHECK CONSTRAINT [FK_ClientService_Client]
GO
ALTER TABLE [dbo].[ClientService]  WITH CHECK ADD  CONSTRAINT [FK_ClientService_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ClientService] CHECK CONSTRAINT [FK_ClientService_Employee]
GO
ALTER TABLE [dbo].[ClientService]  WITH CHECK ADD  CONSTRAINT [FK_ClientService_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ClientService] CHECK CONSTRAINT [FK_ClientService_Service]
GO
ALTER TABLE [dbo].[ServiceCategory]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ServiceCategory] CHECK CONSTRAINT [FK_ServiceCategory_Category]
GO
ALTER TABLE [dbo].[ServiceCategory]  WITH CHECK ADD  CONSTRAINT [FK_ServiceCategory_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ServiceCategory] CHECK CONSTRAINT [FK_ServiceCategory_Service]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [AdZooSalon] SET  READ_WRITE 
GO
