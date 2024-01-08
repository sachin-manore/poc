USE [master]
GO
/****** Object:  Database [footballmatch]    Script Date: 1/8/2024 11:35:32 AM ******/
CREATE DATABASE [footballmatch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'footballmatch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2017\MSSQL\DATA\footballmatch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'footballmatch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2017\MSSQL\DATA\footballmatch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [footballmatch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [footballmatch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [footballmatch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [footballmatch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [footballmatch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [footballmatch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [footballmatch] SET ARITHABORT OFF 
GO
ALTER DATABASE [footballmatch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [footballmatch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [footballmatch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [footballmatch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [footballmatch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [footballmatch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [footballmatch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [footballmatch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [footballmatch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [footballmatch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [footballmatch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [footballmatch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [footballmatch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [footballmatch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [footballmatch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [footballmatch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [footballmatch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [footballmatch] SET RECOVERY FULL 
GO
ALTER DATABASE [footballmatch] SET  MULTI_USER 
GO
ALTER DATABASE [footballmatch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [footballmatch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [footballmatch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [footballmatch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [footballmatch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'footballmatch', N'ON'
GO
ALTER DATABASE [footballmatch] SET QUERY_STORE = OFF
GO
USE [footballmatch]
GO
/****** Object:  Table [dbo].[fixture]    Script Date: 1/8/2024 11:35:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fixture](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[externalid] [int] NOT NULL,
	[referee] [nvarchar](50) NULL,
	[timezone] [nchar](10) NULL,
	[date] [datetime] NULL,
	[timestamp] [nvarchar](50) NULL,
 CONSTRAINT [PK_fixture] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[league]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[league](
	[leagueid] [int] IDENTITY(1,1) NOT NULL,
	[fixtureid] [int] NULL,
	[name] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[logo] [nvarchar](50) NULL,
	[flag] [nvarchar](50) NULL,
	[season] [nchar](10) NULL,
	[round] [nchar](10) NULL,
 CONSTRAINT [PK_league] PRIMARY KEY CLUSTERED 
(
	[leagueid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[periods]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periods](
	[periodsid] [int] IDENTITY(1,1) NOT NULL,
	[fixtureid] [int] NULL,
	[first] [nvarchar](50) NULL,
	[second] [nvarchar](50) NULL,
 CONSTRAINT [PK_periods] PRIMARY KEY CLUSTERED 
(
	[periodsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[score]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[score](
	[scoreid] [int] IDENTITY(1,1) NOT NULL,
	[teamid] [int] NULL,
	[halftime] [int] NULL,
	[fulltime] [int] NULL,
	[extratime] [int] NULL,
	[penalty] [int] NULL,
 CONSTRAINT [PK_score] PRIMARY KEY CLUSTERED 
(
	[scoreid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[statusid] [int] IDENTITY(1,1) NOT NULL,
	[fixtureid] [int] NULL,
	[long] [nvarchar](50) NULL,
	[short] [nvarchar](50) NULL,
	[elapsed] [nchar](10) NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[statusid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teams]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teams](
	[teamsid] [int] IDENTITY(1,1) NOT NULL,
	[fixtureid] [int] NULL,
	[teamlocation] [nvarchar](50) NULL,
	[externalid] [int] NULL,
	[name] [nvarchar](50) NULL,
	[logo] [nvarchar](50) NULL,
	[winner] [bit] NOT NULL,
	[goals] [int] NULL,
 CONSTRAINT [PK_teams] PRIMARY KEY CLUSTERED 
(
	[teamsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venue]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venue](
	[venueid] [int] IDENTITY(1,1) NOT NULL,
	[fixtureid] [int] NOT NULL,
	[externalvenueid] [int] NULL,
	[name] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
 CONSTRAINT [PK_venue] PRIMARY KEY CLUSTERED 
(
	[venueid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[league]  WITH CHECK ADD  CONSTRAINT [FK_league_fixture] FOREIGN KEY([fixtureid])
REFERENCES [dbo].[fixture] ([id])
GO
ALTER TABLE [dbo].[league] CHECK CONSTRAINT [FK_league_fixture]
GO
ALTER TABLE [dbo].[periods]  WITH CHECK ADD  CONSTRAINT [FK_periods_fixture] FOREIGN KEY([fixtureid])
REFERENCES [dbo].[fixture] ([id])
GO
ALTER TABLE [dbo].[periods] CHECK CONSTRAINT [FK_periods_fixture]
GO
ALTER TABLE [dbo].[score]  WITH CHECK ADD  CONSTRAINT [FK_score_score] FOREIGN KEY([teamid])
REFERENCES [dbo].[teams] ([teamsid])
GO
ALTER TABLE [dbo].[score] CHECK CONSTRAINT [FK_score_score]
GO
ALTER TABLE [dbo].[status]  WITH CHECK ADD  CONSTRAINT [FK_status_fixture] FOREIGN KEY([fixtureid])
REFERENCES [dbo].[fixture] ([id])
GO
ALTER TABLE [dbo].[status] CHECK CONSTRAINT [FK_status_fixture]
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD  CONSTRAINT [FK_teams_fixture] FOREIGN KEY([fixtureid])
REFERENCES [dbo].[fixture] ([id])
GO
ALTER TABLE [dbo].[teams] CHECK CONSTRAINT [FK_teams_fixture]
GO
ALTER TABLE [dbo].[venue]  WITH CHECK ADD  CONSTRAINT [FK_venue_fixture] FOREIGN KEY([fixtureid])
REFERENCES [dbo].[fixture] ([id])
GO
ALTER TABLE [dbo].[venue] CHECK CONSTRAINT [FK_venue_fixture]
GO
USE [master]
GO
ALTER DATABASE [footballmatch] SET  READ_WRITE 
GO
