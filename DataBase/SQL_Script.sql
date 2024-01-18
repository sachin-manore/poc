USE [master]
GO
/****** Object:  Database [footballmatch]    Script Date: 1/8/2024 11:35:32 AM ******/
DROP DATABASE IF EXISTS [FootballMatch];
CREATE DATABASE [FootballMatch]
 GO
ALTER DATABASE [FootballMatch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FootballMatch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FootballMatch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FootballMatch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FootballMatch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FootballMatch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FootballMatch] SET ARITHABORT OFF 
GO
ALTER DATABASE [FootballMatch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FootballMatch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FootballMatch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FootballMatch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FootballMatch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FootballMatch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FootballMatch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FootballMatch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FootballMatch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FootballMatch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FootballMatch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FootballMatch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FootballMatch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FootballMatch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FootballMatch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FootballMatch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FootballMatch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FootballMatch] SET RECOVERY FULL 
GO
ALTER DATABASE [FootballMatch] SET  MULTI_USER 
GO
ALTER DATABASE [FootballMatch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FootballMatch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FootballMatch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FootballMatch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FootballMatch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FootballMatch', N'ON'
GO
ALTER DATABASE [footballmatch] SET QUERY_STORE = OFF
GO
USE [FootballMatch]
GO
/****** Object:  Table [dbo].[fixture]    Script Date: 1/8/2024 11:35:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fixture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExternalId] [int] NOT NULL,
	[Referee] [nvarchar](50) NULL,
	[Timezone] [nchar](10) NULL,
	[Date] [datetime] NULL,
	[Timestamp] [nvarchar](50) NULL,
 CONSTRAINT [PK_Fixture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[league]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[League](
	[LeagueId] [int] IDENTITY(1,1) NOT NULL,
	[FixtureId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Logo] [nvarchar](50) NULL,
	[Flag] [nvarchar](50) NULL,
	[Season] [nchar](10) NULL,
	[Round] [nchar](10) NULL,
 CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED 
(
	[LeagueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[periods]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerIods](
	[PeriodsId] [int] IDENTITY(1,1) NOT NULL,
	[FixtureId] [int] NULL,
	[First] [nvarchar](50) NULL,
	[Second] [nvarchar](50) NULL,
 CONSTRAINT [PK_Periods] PRIMARY KEY CLUSTERED 
(
	[PeriodsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[score]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[ScoreId] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NULL,
	[Halftime] [int] NULL,
	[Fulltime] [int] NULL,
	[Extratime] [int] NULL,
	[Penalty] [int] NULL,
 CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED 
(
	[ScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[FixtureId] [int] NULL,
	[Long] [nvarchar](50) NULL,
	[Short] [nvarchar](50) NULL,
	[Elapsed] [nchar](10) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teams]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamsId] [int] IDENTITY(1,1) NOT NULL,
	[FixtureId] [int] NULL,
	[TeamLocation] [nvarchar](50) NULL,
	[ExternalId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Logo] [nvarchar](50) NULL,
	[Winner] [bit] NOT NULL,
	[Goals] [int] NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venue]    Script Date: 1/8/2024 11:35:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venue](
	[VenueId] [int] IDENTITY(1,1) NOT NULL,
	[FixtureId] [int] NOT NULL,
	[ExternalVenueId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[VenueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[League]  WITH CHECK ADD  CONSTRAINT [FK_League_Fixture] FOREIGN KEY([FixtureId])
REFERENCES [dbo].[Fixture] ([Id])
GO
ALTER TABLE [dbo].[League] CHECK CONSTRAINT [FK_League_Fixture]
GO
ALTER TABLE [dbo].[Periods]  WITH CHECK ADD  CONSTRAINT [FK_Periods_Fixture] FOREIGN KEY([FixtureId])
REFERENCES [dbo].[Fixture] ([Id])
GO
ALTER TABLE [dbo].[Periods] CHECK CONSTRAINT [FK_Periods_Fixture]
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [FK_Score_Score] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamsId])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [FK_Score_Score]
GO
ALTER TABLE [dbo].[Status]  WITH CHECK ADD  CONSTRAINT [FK_Status_Fixture] FOREIGN KEY([FixtureId])
REFERENCES [dbo].[Fixture] ([Id])
GO
ALTER TABLE [dbo].[Status] CHECK CONSTRAINT [FK_Status_Fixture]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Fixture] FOREIGN KEY([FixtureId])
REFERENCES [dbo].[Fixture] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Fixture]
GO
ALTER TABLE [dbo].[Venue]  WITH CHECK ADD  CONSTRAINT [FK_Venue_Fixture] FOREIGN KEY([FixtureId])
REFERENCES [dbo].[Fixture] ([Id])
GO
ALTER TABLE [dbo].[Venue] CHECK CONSTRAINT [FK_Venue_Fixture]
GO
USE [master]
GO
ALTER DATABASE [FootballMatch] SET  READ_WRITE 
GO
