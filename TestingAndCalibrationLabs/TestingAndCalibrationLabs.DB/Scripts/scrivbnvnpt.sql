USE [master]
GO
/****** Object:  Database [SeedTest]    Script Date: 11/18/2022 6:05:09 PM ******/
CREATE DATABASE [SeedTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SeedTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SeedTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SeedTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SeedTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SeedTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SeedTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SeedTest] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [SeedTest] SET ANSI_NULLS ON 
GO
ALTER DATABASE [SeedTest] SET ANSI_PADDING ON 
GO
ALTER DATABASE [SeedTest] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [SeedTest] SET ARITHABORT ON 
GO
ALTER DATABASE [SeedTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SeedTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SeedTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SeedTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SeedTest] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [SeedTest] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [SeedTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SeedTest] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [SeedTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SeedTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SeedTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SeedTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SeedTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SeedTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SeedTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SeedTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SeedTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SeedTest] SET RECOVERY FULL 
GO
ALTER DATABASE [SeedTest] SET  MULTI_USER 
GO
ALTER DATABASE [SeedTest] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [SeedTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SeedTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SeedTest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SeedTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SeedTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SeedTest', N'ON'
GO
ALTER DATABASE [SeedTest] SET QUERY_STORE = OFF
GO
USE [SeedTest]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Value] [varchar](250) NOT NULL,
 CONSTRAINT [PK_ClaimType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_DataType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginLog]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[LoginDate] [datetime] NOT NULL,
	[Status] [smallint] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](100) NOT NULL,
	[IPAddress] [nvarchar](50) NULL,
	[Browser] [nvarchar](50) NULL,
	[DeviceCode] [nvarchar](20) NULL,
	[DeviceName] [nvarchar](20) NULL,
 CONSTRAINT [PK_LoginLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginToken]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginToken](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[AccessToken] [nvarchar](1000) NOT NULL,
	[RefreshToken] [nvarchar](1000) NULL,
	[AccessTokenExpiry] [datetime] NOT NULL,
	[DeviceCode] [nvarchar](50) NULL,
	[DeviceName] [nvarchar](50) NULL,
	[RefreshTokenExpiry] [datetime] NULL,
 CONSTRAINT [PK_LoginToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginTokenLog]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTokenLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[AccessToken] [nvarchar](max) NOT NULL,
	[RefreshTokenExpiry] [datetime] NULL,
	[DeviceCode] [nvarchar](50) NULL,
	[DeviceName] [nvarchar](50) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[AccessTokenExpiry] [datetime] NOT NULL,
 CONSTRAINT [PK_LoginTokenLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LookupCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupCategory]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_LookupCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgCode] [nvarchar](10) NOT NULL,
	[OrgName] [nvarchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordLogin]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordLogin](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PasswordHash] [nvarchar](1000) NOT NULL,
	[PasswordSalt] [nvarchar](1000) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_PasswordLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordPolicy]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordPolicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinCaps] [smallint] NOT NULL,
	[MinSmallChars] [smallint] NOT NULL,
	[MinSpecialChars] [smallint] NOT NULL,
	[MinNumber] [smallint] NOT NULL,
	[MinLength] [smallint] NOT NULL,
	[AllowUserName] [bit] NOT NULL,
	[DisAllPastPassword] [smallint] NOT NULL,
	[DisAllowedChars] [nvarchar](50) NULL,
	[ChangeIntervalDays] [smallint] NOT NULL,
	[OrgId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PasswordPolicy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[PermissionModuleTypeId] [int] NOT NULL,
	[PermissionTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionModuleType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionModuleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PermissionModuleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Record]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Record](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Level] [smallint] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Sample] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SampleTable]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Mobile] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[TestingType] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[PinCode] [varchar](6) NOT NULL,
	[Comments] [varchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestReport]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestReport](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Client] [varchar](50) NOT NULL,
	[Filepath] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[JobId] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_TestReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiControlCategoryType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiControlCategoryType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Template] [varchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UiControlTypeId] [int] NULL,
 CONSTRAINT [PK_UiControlCategoryType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiControlType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiControlType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ControlCategoryId] [int] NULL,
 CONSTRAINT [PK_UiControlType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiNavigationCategory]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiNavigationCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Orders] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiNavigationCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageData]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[Value] [varchar](500) NOT NULL,
	[UiPageId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[RecordId] [int] NOT NULL,
 CONSTRAINT [PK_UiPageData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadata]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageTypeId] [int] NOT NULL,
	[UiControlTypeId] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[UiControlDisplayName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DataTypeId] [bigint] NOT NULL,
	[ParentId] [int] NULL,
	[UiControlCategoryTypeId] [int] NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadataCharacteristics]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageMetadataCharacteristics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[LookupId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageMetadataCharacteristics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Url] [varchar](100) NOT NULL,
	[UiNavigationCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageValidation]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageValidation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageTypeId] [int] NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[UiPageValidationTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageValidation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageValidationType]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageValidationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Message] [varchar](100) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageValidationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](100) NULL,
	[ISDCode] [nvarchar](50) NULL,
	[TwoFactor] [bit] NULL,
	[Locked] [bit] NULL,
	[IsActive] [bit] NULL,
	[EmailValidationStatus] [smallint] NULL,
	[MobileValidationStatus] [smallint] NULL,
	[OrgId] [int] NOT NULL,
	[AdminLevel] [smallint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ClaimTypeId] [int] NOT NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[IsDeleted] [smallint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleClaim]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[ClaimTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoleClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workflow]    Script Date: 11/18/2022 6:05:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workflow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DataType] ON 

INSERT [dbo].[DataType] ([Id], [Name], [IsDeleted]) VALUES (1, N'int', 0)
INSERT [dbo].[DataType] ([Id], [Name], [IsDeleted]) VALUES (2, N'string', 0)
INSERT [dbo].[DataType] ([Id], [Name], [IsDeleted]) VALUES (3, N'bit', 0)
SET IDENTITY_INSERT [dbo].[DataType] OFF
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (8, N'DataControl', 4, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (9, N'NonDataControl', 4, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (10, N'SubLevel1Control', 4, 0)
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[LookupCategory] ON 

INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (4, N'UIControlCategory', 0)
SET IDENTITY_INSERT [dbo].[LookupCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([Id], [OrgCode], [OrgName], [IsDeleted]) VALUES (0, N'SYSORG', N'SYSORG', 0)
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
SET IDENTITY_INSERT [dbo].[PasswordLogin] ON 

INSERT [dbo].[PasswordLogin] ([Id], [PasswordHash], [PasswordSalt], [UserId], [ChangeDate]) VALUES (0, N'qnVDMZYlsGjs4chNs1/qPidI70eDUZ1fzUF5EdCqdl0=', N'NDlzcm0GY1GqMgn+urXX9Q==', 0, CAST(N'2022-11-12T14:25:35.763' AS DateTime))
SET IDENTITY_INSERT [dbo].[PasswordLogin] OFF
GO
SET IDENTITY_INSERT [dbo].[PasswordPolicy] ON 

INSERT [dbo].[PasswordPolicy] ([Id], [MinCaps], [MinSmallChars], [MinSpecialChars], [MinNumber], [MinLength], [AllowUserName], [DisAllPastPassword], [DisAllowedChars], [ChangeIntervalDays], [OrgId], [IsDeleted]) VALUES (0, 1, 1, 1, 1, 8, 1, 0, NULL, 30, 0, 0)
SET IDENTITY_INSERT [dbo].[PasswordPolicy] OFF
GO
SET IDENTITY_INSERT [dbo].[Record] ON 

INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (4, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (5, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (6, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (7, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (8, 8, 0)
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (9, 8, 0)
SET IDENTITY_INSERT [dbo].[Record] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (0, N'Sysadmin', 0, 0)
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (1, N'Admin', 1, 0)
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (2, N'ApplicationAdmin', 2, 0)
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (3, N'Manager', 3, 0)
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (4, N'GeneralUser', 6, 0)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[TestReport] ON 

INSERT [dbo].[TestReport] ([Id], [Client], [Filepath], [Email], [JobId], [Name], [DateTime], [IsDeleted]) VALUES (1, N'dfg', N'1VkPUk0WjPRj6rCulYq_9xU9FeCGFm1oa', N'jg@gh.hvbv', N'dgdfg', N'dfg', CAST(N'2022-11-14T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[TestReport] OFF
GO
SET IDENTITY_INSERT [dbo].[UiControlCategoryType] ON 

INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1, N'Grid', N'~/Views/Common/Components/Grid/_gridTemplate1.cshtml', 0, 33)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2, N'Grid Classic', N'~/Views/Common/Components/Grid/_gridTemplate2.cshtml', 0, 33)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (3, N'Text', N'~/Views/Common/Components/Text/_text.cshtml', 0, 1)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (5, N'Text Large', N'~/Views/Common/Components/Text/_text1.cshtml', 0, 1)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1003, N'Checkbox', N'~/Views/Common/Components/Checkbox/_checkbox.cshtml', 0, 3)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1004, N'Radio', N'~/Views/Common/Components/Radio/_radio.cshtml', 0, 4)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1005, N'Submit', N'~/Views/Common/Components/Submit/_submit.cshtml', 0, 6)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1006, N'Email', N'~/Views/Common/Components/Email/_email.cshtml', 0, 10)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1007, N'Mobile Number', N'~/Views/Common/Components/Mobile/_mobileNumber.cshtml', 0, 12)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1009, N'Time', N'~/Views/Common/Components/Date/_time.cshtml', 0, 14)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1010, N'URL', N'~/Views/Common/Components/Url/_url.cshtml', 0, 15)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1011, N'Date Time', N'~/Views/Common/Components/DateTime/_datetime-local.cshtml', 0, 22)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1012, N'Progress Bar', N'~/Views/Common/Components/ProgressStatus/_progressStatus.cshtml', 0, 25)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1013, N'Tabs', N'~/Views/Common/Components/Tabs/_tabs.cshtml', 0, 28)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1014, N'Collapsable Section', N'~/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml', 0, 30)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1015, N'Dropdown', N'~/Views/Common/Components/Dropdown/_dropdown.cshtml', 0, 32)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1016, N'Pincode', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 1032)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1017, N'Null', N'Null', 0, 29)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1020, N'Textarea', N'~/Views/Common/Components/Textarea/_textarea.cshtml', 0, 8)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2004, N'File', N'~/Views/Common/Components/File/_file.cshtml', 0, 5)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2006, N'Year', N'~/Views/Common/Components/DateTime/_year.cshtml', 0, 2032)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2007, N'Checkbox', N'~/Views/Common/Components/Question/_checkbox.cshtml', 0, 2033)
SET IDENTITY_INSERT [dbo].[UiControlCategoryType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiControlType] ON 

INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (1, N'text', N'User Name', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (2, N'password', N'Password', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (3, N'checkbox', N'Checkbox', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (4, N'radio', N'Radio', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (5, N'file', N'File', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (6, N'submit', N'Submit', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (7, N'button', N'Button', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (8, N'textarea', N'Textarea', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (9, N'date', N'Date', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (10, N'email', N'Email', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (11, N'image', N'Image', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (12, N'number', N'Number', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (13, N'tel', N'Telephone', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (14, N'time', N'Time', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (15, N'url', N'Url', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (16, N'reset', N'Reset', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (17, N'week', N'Week', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (18, N'search', N'Search', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (19, N'range', N'Range', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (20, N'month', N'Month', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (21, N'hidden', N'Hidden', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (22, N'datetime-local', N'Datetime-local', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (23, N'color', N'Color', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (24, N'card', N'Card', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (25, N'processStatus', N'Default Process Status', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (26, N'subLevel1ProcessStatus', N'Sub Leve 1 Process status', 0, 10)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (28, N'tabs', N'Default Tabs', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (29, N'subLevel1Tabs', N'Sub Level 1 Tabs', 0, 10)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (30, N'collapsableSection', N'Default Collapsable Section', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (31, N'subLevel1CollapsableSection', N'Sub Level 1 Collapsable Section', 0, 10)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (32, N'dropdown', N'Dropdown', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (33, N'grid', N'Grid', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (1032, N'pincode', N'Pincode', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (2032, N'year', N'Year', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (2033, N'question', N'Question - Checkbox', 0, 9)
SET IDENTITY_INSERT [dbo].[UiControlType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiNavigationCategory] ON 

INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1, N'Survey', 2, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (2, N'Home', 1, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1002, N'Settings', 3, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1003, N'Profile', 4, 0)
SET IDENTITY_INSERT [dbo].[UiNavigationCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageData] ON 

INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (1, 12, N'Sdt', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (2, 13, N'DFS45454SFKL', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (3, 14, N'India', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4, 15, N'Bihar', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (5, 16, N'Patna', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (6, 17, N'Digha Ashiyana Road', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (7, 18, N'Patna', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (8, 19, N'801105', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (9, 20, N'9308337022', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (10, 21, N'rajkumar00999.rk@gmail.com', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (11, 22, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (12, 23, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (13, 24, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (14, 25, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (15, 26, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (16, 27, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (17, 28, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (18, 29, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (19, 33, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (20, 34, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (21, 35, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (22, 36, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (23, 1004, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (24, 1005, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (25, 1006, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (26, 1007, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (27, 1008, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (28, 1009, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (29, 1010, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (30, 1011, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (31, 1012, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (32, 1013, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (33, 1014, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (34, 1015, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (35, 1017, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (36, 1018, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (37, 1019, N'Patna', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (38, 1023, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (39, 1024, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (40, 1025, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (41, 1026, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (42, 1027, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (43, 1028, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (44, 1029, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (45, 1030, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (46, 1031, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (47, 1032, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (48, 1033, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (49, 1034, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (50, 1035, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (51, 1036, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (52, 1037, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (53, 1038, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (54, 1039, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (55, 1040, N'rad-1042', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (56, 1042, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (57, 1043, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (58, 1044, N'', 8, 0, 1)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (59, 12, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (60, 13, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (61, 14, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (62, 15, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (63, 16, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (64, 17, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (65, 18, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (66, 19, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (67, 20, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (68, 21, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (69, 22, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (70, 23, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (71, 24, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (72, 25, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (73, 26, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (74, 27, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (75, 28, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (76, 29, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (77, 33, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (78, 34, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (79, 35, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (80, 36, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (81, 1004, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (82, 1005, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (83, 1006, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (84, 1007, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (85, 1008, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (86, 1009, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (87, 1010, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (88, 1011, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (89, 1012, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (90, 1013, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (91, 1014, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (92, 1015, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (93, 1017, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (94, 1018, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (95, 1019, N'Patna', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (96, 1023, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (97, 1024, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (98, 1025, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (99, 1026, N'', 8, 0, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (100, 1027, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (101, 1028, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (102, 1029, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (103, 1030, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (104, 1031, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (105, 1032, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (106, 1033, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (107, 1034, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (108, 1035, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (109, 1036, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (110, 1037, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (111, 1038, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (112, 1039, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (113, 1040, N'rad-1042', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (114, 1042, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (115, 1043, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (116, 1044, N'', 8, 0, 2)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (117, 12, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (118, 13, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (119, 14, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (120, 15, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (121, 16, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (122, 17, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (123, 18, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (124, 19, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (125, 20, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (126, 21, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (127, 22, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (128, 23, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (129, 24, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (130, 25, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (131, 26, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (132, 27, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (133, 28, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (134, 29, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (135, 33, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (136, 34, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (137, 35, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (138, 36, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (139, 1004, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (140, 1005, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (141, 1006, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (142, 1007, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (143, 1008, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (144, 1009, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (145, 1010, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (146, 1011, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (147, 1012, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (148, 1013, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (149, 1014, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (150, 1015, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (151, 1017, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (152, 1018, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (153, 1019, N'Patna', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (154, 1023, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (155, 1024, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (156, 1025, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (157, 1026, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (158, 1027, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (159, 1028, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (160, 1029, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (161, 1030, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (162, 1031, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (163, 1032, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (164, 1033, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (165, 1034, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (166, 1035, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (167, 1036, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (168, 1037, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (169, 1038, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (170, 1039, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (171, 1040, N'rad-1042', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (172, 1042, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (173, 1043, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (174, 1044, N'', 8, 0, 3)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (175, 12, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (176, 13, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (177, 14, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (178, 15, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (179, 16, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (180, 17, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (181, 18, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (182, 19, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (183, 20, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (184, 21, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (185, 22, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (186, 23, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (187, 24, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (188, 25, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (189, 26, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (190, 27, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (191, 28, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (192, 29, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (193, 33, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (194, 34, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (195, 35, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (196, 36, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (197, 1004, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (198, 1005, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (199, 1006, N'', 8, 0, 4)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (200, 1007, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (201, 1008, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (202, 1009, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (203, 1010, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (204, 1011, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (205, 1012, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (206, 1013, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (207, 1014, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (208, 1015, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (209, 1017, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (210, 1018, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (211, 1019, N'Patna', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (212, 1023, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (213, 1024, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (214, 1025, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (215, 1026, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (216, 1027, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (217, 1028, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (218, 1029, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (219, 1030, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (220, 1031, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (221, 1032, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (222, 1033, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (223, 1034, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (224, 1035, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (225, 1036, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (226, 1037, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (227, 1038, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (228, 1039, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (229, 1040, N'rad-1042', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (230, 1042, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (231, 1043, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (232, 1044, N'', 8, 0, 4)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (233, 12, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (234, 13, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (235, 14, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (236, 15, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (237, 16, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (238, 17, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (239, 18, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (240, 19, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (241, 20, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (242, 21, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (243, 22, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (244, 23, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (245, 24, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (246, 25, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (247, 26, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (248, 27, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (249, 28, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (250, 29, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (251, 33, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (252, 34, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (253, 35, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (254, 36, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (255, 1004, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (256, 1005, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (257, 1006, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (258, 1007, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (259, 1008, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (260, 1009, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (261, 1010, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (262, 1011, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (263, 1012, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (264, 1013, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (265, 1014, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (266, 1015, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (267, 1017, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (268, 1018, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (269, 1019, N'Patna', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (270, 1023, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (271, 1024, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (272, 1025, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (273, 1026, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (274, 1027, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (275, 1028, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (276, 1029, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (277, 1030, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (278, 1031, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (279, 1032, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (280, 1033, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (281, 1034, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (282, 1035, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (283, 1036, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (284, 1037, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (285, 1038, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (286, 1039, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (287, 1040, N'rad-1042', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (288, 1042, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (289, 1043, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (290, 1044, N'', 8, 0, 5)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (291, 12, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (292, 13, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (293, 14, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (294, 15, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (295, 16, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (296, 17, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (297, 18, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (298, 19, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (299, 20, N'', 8, 0, 6)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (300, 21, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (301, 22, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (302, 23, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (303, 24, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (304, 25, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (305, 26, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (306, 27, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (307, 28, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (308, 29, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (309, 33, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (310, 34, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (311, 35, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (312, 36, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (313, 1004, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (314, 1005, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (315, 1006, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (316, 1007, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (317, 1008, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (318, 1009, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (319, 1010, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (320, 1011, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (321, 1012, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (322, 1013, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (323, 1014, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (324, 1015, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (325, 1017, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (326, 1018, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (327, 1019, N'Patna', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (328, 1023, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (329, 1024, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (330, 1025, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (331, 1026, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (332, 1027, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (333, 1028, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (334, 1029, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (335, 1030, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (336, 1031, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (337, 1032, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (338, 1033, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (339, 1034, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (340, 1035, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (341, 1036, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (342, 1037, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (343, 1038, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (344, 1039, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (345, 1040, N'rad-1042', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (346, 1042, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (347, 1043, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (348, 1044, N'', 8, 0, 6)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (349, 12, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (350, 13, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (351, 14, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (352, 15, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (353, 16, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (354, 17, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (355, 18, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (356, 19, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (357, 20, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (358, 21, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (359, 22, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (360, 23, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (361, 24, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (362, 25, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (363, 26, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (364, 27, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (365, 28, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (366, 29, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (367, 33, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (368, 34, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (369, 35, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (370, 36, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (371, 1004, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (372, 1005, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (373, 1006, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (374, 1007, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (375, 1008, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (376, 1009, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (377, 1010, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (378, 1011, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (379, 1012, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (380, 1013, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (381, 1014, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (382, 1015, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (383, 1017, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (384, 1018, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (385, 1019, N'Patna', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (386, 1023, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (387, 1024, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (388, 1025, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (389, 1026, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (390, 1027, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (391, 1028, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (392, 1029, N'dfs', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (393, 1030, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (394, 1031, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (395, 1032, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (396, 1033, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (397, 1034, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (398, 1035, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (399, 1036, N'', 8, 0, 7)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (400, 1037, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (401, 1038, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (402, 1039, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (403, 1040, N'rad-1042', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (404, 1042, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (405, 1043, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (406, 1044, N'', 8, 0, 7)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (407, 12, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (408, 13, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (409, 14, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (410, 15, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (411, 16, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (412, 17, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (413, 18, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (414, 19, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (415, 20, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (416, 21, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (417, 22, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (418, 23, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (419, 24, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (420, 25, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (421, 26, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (422, 27, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (423, 28, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (424, 29, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (425, 33, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (426, 34, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (427, 35, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (428, 36, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (429, 1004, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (430, 1005, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (431, 1006, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (432, 1007, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (433, 1008, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (434, 1009, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (435, 1010, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (436, 1011, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (437, 1012, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (438, 1013, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (439, 1014, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (440, 1015, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (441, 1017, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (442, 1018, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (443, 1019, N'Patna', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (444, 1023, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (445, 1024, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (446, 1025, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (447, 1026, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (448, 1027, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (449, 1028, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (450, 1029, N'dfs', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (451, 1030, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (452, 1031, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (453, 1032, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (454, 1033, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (455, 1034, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (456, 1035, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (457, 1036, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (458, 1037, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (459, 1038, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (460, 1039, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (461, 1040, N'rad-1042', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (462, 1042, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (463, 1043, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (464, 1044, N'', 8, 0, 8)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (465, 12, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (466, 13, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (467, 14, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (468, 15, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (469, 16, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (470, 17, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (471, 18, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (472, 19, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (473, 20, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (474, 21, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (475, 22, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (476, 23, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (477, 24, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (478, 25, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (479, 26, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (480, 27, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (481, 28, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (482, 29, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (483, 33, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (484, 34, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (485, 35, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (486, 36, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (487, 1004, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (488, 1005, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (489, 1006, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (490, 1007, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (491, 1008, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (492, 1009, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (493, 1010, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (494, 1011, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (495, 1012, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (496, 1013, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (497, 1014, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (498, 1015, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (499, 1017, N'', 8, 0, 9)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (500, 1018, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (501, 1019, N'Patna', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (502, 1023, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (503, 1024, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (504, 1025, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (505, 1026, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (506, 1027, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (507, 1028, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (508, 1029, N'dfs', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (509, 1030, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (510, 1031, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (511, 1032, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (512, 1033, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (513, 1034, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (514, 1035, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (515, 1036, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (516, 1037, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (517, 1038, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (518, 1039, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (519, 1040, N'rad-1042', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (520, 1042, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (521, 1043, N'', 8, 0, 9)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (522, 1044, N'', 8, 0, 9)
SET IDENTITY_INSERT [dbo].[UiPageData] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 

INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (3, 8, 25, 0, N'ProgressStatus', 0, 1, 0, 1012, N'progress1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (4, 8, 29, 0, N'Laboratory Details', 0, 1, 3, 1017, N'lab1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (5, 8, 29, 0, N' Discipline Details', 0, 1, 3, 1017, N'disc1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (6, 8, 29, 0, N'Scope Of Accreditation', 0, 1, 3, 1017, N'disc2')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (7, 8, 29, 0, N'Organization', 0, 1, 3, 1017, N'org1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (8, 8, 29, 0, N'Equipment', 0, 1, 3, 1017, N'equi1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (9, 8, 29, 0, N'Reference Materials', 0, 1, 3, 1017, N'refer1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (10, 8, 29, 0, N'Quality Control Activities', 0, 1, 3, 1017, N'qcont1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (11, 8, 29, 0, N'Enclosure List', 0, 1, 3, 1017, N'enc1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (12, 8, 1, 1, N'Name Of The Laboratory', 0, 2, 4, 3, N'nothe1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (13, 8, 1, 1, N'GSTIN', 0, 2, 4, 3, N'gstin1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (14, 8, 1, 1, N'Contry', 0, 2, 4, 3, N'cont2')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (15, 8, 1, 1, N'State/Provider', 0, 2, 4, 3, N'sttt3')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (16, 8, 1, 1, N'City', 0, 2, 4, 3, N'ct3')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (17, 8, 1, 1, N'Address', 0, 2, 4, 3, N'adgag4')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (18, 8, 1, 1, N'District', 0, 2, 4, 3, N'discr4')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (19, 8, 1032, 0, N'Pincode', 0, 2, 4, 1016, N'pincd5')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (20, 8, 1, 1, N'Mobile Number', 0, 2, 4, 3, N'mobi34')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (21, 8, 10, 1, N'Email', 0, 2, 4, 1006, N'emuil34')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (22, 8, 1, 0, N'Discipline Of Testing', 0, 2, 5, 3, N'discip6')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (23, 8, 1, 0, N'Group', 0, 2, 5, 3, N'grty5')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (24, 8, 1, 1, N'Location', 0, 2, 6, 3, N'dsg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (25, 8, 1, 1, N'Discipline', 0, 2, 6, 3, N'etr')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (26, 8, 1, 0, N'Group', 0, 2, 6, 3, N'ttyr')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (27, 8, 1, 0, N'Sub-Group', 0, 2, 6, 3, N'rteag')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (28, 8, 8, 0, N'Products/Materials of Test', 0, 2, 6, 1020, N'dgsdsert')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (29, 8, 8, 0, N'Specific tests or types of tests perofmed', 0, 2, 6, 1020, N'vstyers')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (30, 8, 30, 0, N'Collapsable', 0, 1, 7, 1014, N'dasterdsd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (31, 8, 29, 0, N'Organization Structure', 0, 1, 30, 1017, N'hyer')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (32, 8, 29, 0, N'New Employee Details', 0, 1, 30, 1017, N'gdfy')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (33, 8, 1, 1, N'Organization Chart of Laboratory Link', 0, 2, 31, 3, N'dfgd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (34, 8, 1, 0, N'organization chart', 0, 2, 31, 3, N'rtyery')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (35, 8, 1, 0, N'Text Box', 0, 2, 32, 3, N'hrty')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (36, 8, 1, 1, N'Text Box 1', 0, 2, 32, 3, N'wsrt')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1004, 8, 5, 0, N'Image Input', 0, 1, 32, 2004, N'sg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1005, 8, 1, 1, N'Location', 0, 2, 8, 3, N'sergs')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1006, 8, 1, 1, N'Discipline', 0, 2, 8, 3, N'tr5')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1007, 8, 1, 1, N'Group', 0, 2, 8, 3, N'sgsret')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1008, 8, 1, 1, N'Type Of Test', 0, 2, 8, 3, N'regs')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1009, 8, 1, 1, N'UID of Equipment', 0, 2, 8, 3, N'trse')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1010, 8, 1, 1, N'Name Of Equipment', 0, 2, 8, 3, N'gsdg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1011, 8, 1, 0, N'Model', 0, 2, 8, 3, N'uys')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1012, 8, 1, 0, N'Serial No', 0, 2, 8, 3, N'bew')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1013, 8, 1, 1, N'Name Of Manufracturer', 0, 2, 8, 3, N'ma')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1014, 8, 2032, 0, N'Year Of Make', 0, 2, 8, 2006, N'v')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1015, 8, 1, 0, N'Range and Accurecy', 0, 2, 8, 3, N'rtsd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1017, 8, 22, 0, N'Last Calibration Date', 0, 2, 8, 1011, N'uym')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1018, 8, 22, 0, N'Calibration Due on', 0, 2, 8, 1011, N'du v')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1019, 8, 32, 0, N'Location', 0, 2, 9, 1015, N'aser')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1023, 8, 1, 1, N'Discipline', 0, 2, 9, 3, N'bys')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1024, 8, 1, 1, N'Group', 0, 2, 9, 3, N'um')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1025, 8, 1, 1, N'Name of Reference Material/Strain/Culture', 0, 2, 9, 3, N'gbgsn ')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1026, 8, 1, 1, N'Source', 0, 2, 9, 3, N'shb sdfy')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1027, 8, 22, 1, N'Date Of Expiry', 0, 2, 9, 1011, N'dbsghv')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1028, 8, 1, 1, N'Tracability', 0, 2, 9, 3, N'vbs')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1029, 8, 1, 1, N'Location', 0, 2, 10, 3, N'gvtsn s')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1030, 8, 1, 1, N'Type Of Partipatation', 0, 2, 10, 3, N'm,s ij')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1031, 8, 1, 1, N'Discipline', 0, 2, 10, 3, N'v ')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1032, 8, 1, 1, N'Group', 0, 2, 10, 3, N'zym r')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1033, 8, 1, 1, N'Product/Material', 0, 2, 10, 3, N'mn')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1034, 8, 1, 0, N'Details of Test', 0, 2, 10, 3, N'burtm,')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1035, 8, 22, 0, N'Date Of Testing', 0, 2, 10, 1011, N'io')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1036, 8, 1, 1, N'Nodal Laboratory/PT Provider (Accredification Body/Country)', 0, 2, 10, 3, N'rb')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1037, 8, 1, 1, N'Performance in Term of Z Score / Any Other Criteria', 0, 2, 10, 3, N'ta')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1038, 8, 1, 0, N'Corrective Action Taken (if any)', 0, 2, 10, 3, N'byim')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1039, 8, 5, 1, N'Upload Quality Manual', 0, 2, 11, 2004, N'ng')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1040, 8, 4, 1, N'Calibrated By', 0, 1, 11, 1004, N'svbtyio')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1042, 8, 3, 0, N'Inhouse', 0, 1, 1040, 1003, N'eryrt')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1043, 8, 3, 0, N'External', 0, 1, 1040, 1003, N'ryrtuty')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1044, 8, 3, 0, N'Checkbox-check', 0, 1, 11, 1003, N'esbum')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1045, 8, 29, 0, N'Patna', 0, 1, 1019, 1017, N'iduyaer')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1046, 8, 29, 0, N'Lacknow', 0, 1, 1019, 1017, N'sgfdsgd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1047, 8, 29, 0, N'Bareliy', 0, 1, 1019, 1017, N'sdgsdfg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (1048, 8, 29, 0, N'Karnataka', 0, 1, 1019, 1017, N'fgd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (2002, 8, 33, 0, N'Grid', 0, 1, 5, 2, N'lfy')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (2008, 7, 1, 0, N'adfsafds', 0, 2, 0, 3, N'afsdfa')
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId], [Name]) VALUES (3006, 6, 1, 0, N'Name', 0, 2, 0, 3, N'UserName')
SET IDENTITY_INSERT [dbo].[UiPageMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageType] ON 

INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (1, N'Ui Page Type', N'/UiPageType/Index/', 1002, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (2, N'Ui Control Type', N'/UiControlType/Index/', 1002, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (3, N'Ui Page Metadata', N'/UiPageMetadata/Index/', 1002, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (4, N'Ui Page Validation', N'/UiPageValidation/Index/', 1002, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (5, N'Home', N'/', 2, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (6, N'My Activity', N'/Common/Index/{0}', 1003, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (7, N'My Account', N'/Common/Index/{0}', 1003, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (8, N'Nabl', N'/Common/Create/{0}', 1003, 0)
SET IDENTITY_INSERT [dbo].[UiPageType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] ON 

INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (2, 8, 12, 4, 1)
SET IDENTITY_INSERT [dbo].[UiPageValidation] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] ON 

INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (1, N'MinPasswordLength', N'Minimum Password length  is 8', N'8', 0)
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (2, N'Email', N'Email should have a fromat', N'3', 0)
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (3, N'AdharLength', N'AdharLength should be equal to 12', N'12', 0)
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (4, N'MobileNumberLength', N'Mobile Number length is equal to 10', N'10', 0)
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (5, N'Year', N'Year length is equal to 4', N'4', 0)
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (6, N'Name', N'Name should have more than 3 letters', N'3', 1)
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (7, N'IsRequired', N'{0} Field is rquired', N'', 0)
SET IDENTITY_INSERT [dbo].[UiPageValidationType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [FirstName], [LastName], [Email], [Mobile], [Country], [ISDCode], [TwoFactor], [Locked], [IsActive], [EmailValidationStatus], [MobileValidationStatus], [OrgId], [AdminLevel], [IsDeleted]) VALUES (0, N'sysadmin', N'sysadmin', N'sysadmin', N'sysadmin@gmail.com', N'1234567899', N'INDIA', N'91', 0, 0, 1, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [IsDeleted]) VALUES (0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ClaimType] ADD  CONSTRAINT [DF_ClaimType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Lookup] ADD  CONSTRAINT [DF_Lookup_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LookupCategory] ADD  CONSTRAINT [DF_LookupCategory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [D_Organization_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PasswordPolicy] ADD  CONSTRAINT [D_PasswordPolicy_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PermissionModuleType] ADD  CONSTRAINT [DF_PermissionModuleType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PermissionType] ADD  CONSTRAINT [DF_PermissionType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Record] ADD  CONSTRAINT [DF_Record_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [D_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Sample] ADD  CONSTRAINT [DF_Sample_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SampleTable] ADD  CONSTRAINT [D_SampleTable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Survey] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TestReport] ADD  CONSTRAINT [DF_TestReport_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiControlCategoryType] ADD  CONSTRAINT [DF_UiControlCategoryType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiControlType] ADD  CONSTRAINT [DF_UiControlType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiNavigationCategory] ADD  CONSTRAINT [DF_UiNavigationCategory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageData] ADD  CONSTRAINT [DF_UiPageData_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageMetadata] ADD  CONSTRAINT [DF_UiPageMetadata_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics] ADD  CONSTRAINT [DF_UiPageMetadataCharacteristics_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageType] ADD  CONSTRAINT [DF_UiPageType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageValidation] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageValidationType] ADD  CONSTRAINT [DF_UiPageValidationType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [D_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserClaim] ADD  CONSTRAINT [DF_UserPermission_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserRoleClaim] ADD  CONSTRAINT [DF_UserRoleClaim_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LoginLog]  WITH CHECK ADD  CONSTRAINT [FK_LoginLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LoginLog] CHECK CONSTRAINT [FK_LoginLog_User]
GO
ALTER TABLE [dbo].[LoginToken]  WITH CHECK ADD  CONSTRAINT [FK_LoginToken_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LoginToken] CHECK CONSTRAINT [FK_LoginToken_User]
GO
ALTER TABLE [dbo].[LoginTokenLog]  WITH CHECK ADD  CONSTRAINT [FK_LoginTokenLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LoginTokenLog] CHECK CONSTRAINT [FK_LoginTokenLog_User]
GO
ALTER TABLE [dbo].[Lookup]  WITH CHECK ADD  CONSTRAINT [FK_Lookup_LookupCategory_Id] FOREIGN KEY([LookupCategoryId])
REFERENCES [dbo].[LookupCategory] ([Id])
GO
ALTER TABLE [dbo].[Lookup] CHECK CONSTRAINT [FK_Lookup_LookupCategory_Id]
GO
ALTER TABLE [dbo].[PasswordLogin]  WITH CHECK ADD  CONSTRAINT [FK_PasswordLogin_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PasswordLogin] CHECK CONSTRAINT [FK_PasswordLogin_User]
GO
ALTER TABLE [dbo].[PasswordPolicy]  WITH CHECK ADD  CONSTRAINT [FK_PasswordPolicy_Organization] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[PasswordPolicy] CHECK CONSTRAINT [FK_PasswordPolicy_Organization]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_PermissionModuleType_Id] FOREIGN KEY([PermissionModuleTypeId])
REFERENCES [dbo].[PermissionModuleType] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_PermissionModuleType_Id]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_PermissionType_Id] FOREIGN KEY([PermissionTypeId])
REFERENCES [dbo].[PermissionType] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_PermissionType_Id]
GO
ALTER TABLE [dbo].[Record]  WITH CHECK ADD  CONSTRAINT [FK_Record_UiPageType_UiPageId] FOREIGN KEY([UiPageId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[Record] CHECK CONSTRAINT [FK_Record_UiPageType_UiPageId]
GO
ALTER TABLE [dbo].[UiControlCategoryType]  WITH CHECK ADD  CONSTRAINT [FK_UiControlCategoryType_UiControlType] FOREIGN KEY([UiControlTypeId])
REFERENCES [dbo].[UiControlType] ([id])
GO
ALTER TABLE [dbo].[UiControlCategoryType] CHECK CONSTRAINT [FK_UiControlCategoryType_UiControlType]
GO
ALTER TABLE [dbo].[UiControlType]  WITH CHECK ADD  CONSTRAINT [FK_UiControlType_Lookup_ControlCategoryId] FOREIGN KEY([ControlCategoryId])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[UiControlType] CHECK CONSTRAINT [FK_UiControlType_Lookup_ControlCategoryId]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_Record_RecordId] FOREIGN KEY([RecordId])
REFERENCES [dbo].[Record] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_Record_RecordId]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_UiPageMetadata_Id] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_UiPageMetadata_Id]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_UiPageType_UiPageId] FOREIGN KEY([UiPageId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_UiPageType_UiPageId]
GO
ALTER TABLE [dbo].[UiPageMetadata]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadata_DataType_Id] FOREIGN KEY([DataTypeId])
REFERENCES [dbo].[DataType] ([Id])
GO
ALTER TABLE [dbo].[UiPageMetadata] CHECK CONSTRAINT [FK_UiPageMetadata_DataType_Id]
GO
ALTER TABLE [dbo].[UiPageMetadata]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadata_UiControlCategoryType] FOREIGN KEY([UiControlCategoryTypeId])
REFERENCES [dbo].[UiControlCategoryType] ([Id])
GO
ALTER TABLE [dbo].[UiPageMetadata] CHECK CONSTRAINT [FK_UiPageMetadata_UiControlCategoryType]
GO
ALTER TABLE [dbo].[UiPageMetadata]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadata_UiControlType_Id] FOREIGN KEY([UiControlTypeId])
REFERENCES [dbo].[UiControlType] ([id])
GO
ALTER TABLE [dbo].[UiPageMetadata] CHECK CONSTRAINT [FK_UiPageMetadata_UiControlType_Id]
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadataCharacteristics_Lookup_Id] FOREIGN KEY([LookupId])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics] CHECK CONSTRAINT [FK_UiPageMetadataCharacteristics_Lookup_Id]
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadataCharacteristics_UiPageMetadata_Id] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics] CHECK CONSTRAINT [FK_UiPageMetadataCharacteristics_UiPageMetadata_Id]
GO
ALTER TABLE [dbo].[UiPageType]  WITH CHECK ADD  CONSTRAINT [FK_UiPageType_UiNavigationCategory_Id] FOREIGN KEY([UiNavigationCategoryId])
REFERENCES [dbo].[UiNavigationCategory] ([Id])
GO
ALTER TABLE [dbo].[UiPageType] CHECK CONSTRAINT [FK_UiPageType_UiNavigationCategory_Id]
GO
ALTER TABLE [dbo].[UiPageValidation]  WITH CHECK ADD  CONSTRAINT [FK_UiPageValidation_UiPageMetadata_Id] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[UiPageValidation] CHECK CONSTRAINT [FK_UiPageValidation_UiPageMetadata_Id]
GO
ALTER TABLE [dbo].[UiPageValidation]  WITH CHECK ADD  CONSTRAINT [FK_UiPageValidation_UiPageType_Id] FOREIGN KEY([UiPageTypeId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[UiPageValidation] CHECK CONSTRAINT [FK_UiPageValidation_UiPageType_Id]
GO
ALTER TABLE [dbo].[UiPageValidation]  WITH CHECK ADD  CONSTRAINT [FK_UiPageValidation_UiPageValidationType_Id] FOREIGN KEY([UiPageValidationTypeId])
REFERENCES [dbo].[UiPageValidationType] ([Id])
GO
ALTER TABLE [dbo].[UiPageValidation] CHECK CONSTRAINT [FK_UiPageValidation_UiPageValidationType_Id]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Organization] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Organization]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_ClaimType_Id] FOREIGN KEY([ClaimTypeId])
REFERENCES [dbo].[ClaimType] ([Id])
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_ClaimType_Id]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_Permission_Id] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_Permission_Id]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_User_Id] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_User_Id]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Role_UserRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_Role_UserRole]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_User_UserRole]
GO
ALTER TABLE [dbo].[UserRoleClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleClaim_ClaimType_Id] FOREIGN KEY([ClaimTypeId])
REFERENCES [dbo].[ClaimType] ([Id])
GO
ALTER TABLE [dbo].[UserRoleClaim] CHECK CONSTRAINT [FK_UserRoleClaim_ClaimType_Id]
GO
ALTER TABLE [dbo].[UserRoleClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleClaim_Permission_Id] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[UserRoleClaim] CHECK CONSTRAINT [FK_UserRoleClaim_Permission_Id]
GO
ALTER TABLE [dbo].[UserRoleClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserRoleClaim_Role_Id] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRoleClaim] CHECK CONSTRAINT [FK_UserRoleClaim_Role_Id]
GO
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Module]
GO
USE [master]
GO
ALTER DATABASE [SeedTest] SET  READ_WRITE 
GO
