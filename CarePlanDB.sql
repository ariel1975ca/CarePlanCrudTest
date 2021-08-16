USE [master]
GO
/****** Object:  Database [CarePlanDB]    Script Date: 08/16/2021 08:06:17 ******/
CREATE DATABASE [CarePlanDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarePlanDB', FILENAME = N'D:\SqlServerDbs\CarePlanDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarePlanDB_log', FILENAME = N'D:\SqlServerDbs\CarePlanDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarePlanDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarePlanDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarePlanDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarePlanDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarePlanDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarePlanDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarePlanDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarePlanDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarePlanDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarePlanDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarePlanDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarePlanDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarePlanDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarePlanDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarePlanDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarePlanDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarePlanDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarePlanDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarePlanDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarePlanDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarePlanDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarePlanDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarePlanDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarePlanDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarePlanDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarePlanDB] SET  MULTI_USER 
GO
ALTER DATABASE [CarePlanDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarePlanDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarePlanDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarePlanDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarePlanDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarePlanDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CarePlanDB] SET QUERY_STORE = OFF
GO
USE [CarePlanDB]
GO
/****** Object:  User [careplanuser]    Script Date: 08/16/2021 08:06:17 ******/
CREATE USER [careplanuser] FOR LOGIN [careplanuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [careplanuser]
GO
/****** Object:  Table [dbo].[TCarePlan]    Script Date: 08/16/2021 08:06:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCarePlan](
	[ID_CarePlan] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](450) NOT NULL,
	[PatientName] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](450) NOT NULL,
	[ActualStartDate] [datetime] NOT NULL,
	[TargetDate] [datetime] NOT NULL,
	[Reason] [nvarchar](1000) NOT NULL,
	[Action] [nvarchar](1000) NOT NULL,
	[Completed] [bit] NOT NULL,
	[EndDate] [datetime] NULL,
	[Outcome] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TCarePlan] PRIMARY KEY CLUSTERED 
(
	[ID_CarePlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TCarePlan] ADD  CONSTRAINT [DF_TCarePlan_Completed]  DEFAULT ((0)) FOR [Completed]
GO
USE [master]
GO
ALTER DATABASE [CarePlanDB] SET  READ_WRITE 
GO
