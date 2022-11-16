USE [master]
GO
/****** Object:  Database [SeedTest]    Script Date: 11/16/2022 9:09:30 PM ******/
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
/****** Object:  Table [dbo].[ClaimType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[DataType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[LoginLog]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[LoginToken]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[LoginTokenLog]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Lookup]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[LookupCategory]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Organization]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[PasswordLogin]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[PasswordPolicy]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[PermissionModuleType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[PermissionType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Record]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Sample]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[SampleTable]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[Survey]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[TestReport]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiControlCategoryType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiControlType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiNavigationCategory]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiPageData]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiPageMetadata]    Script Date: 11/16/2022 9:09:31 PM ******/
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
 CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadataCharacteristics]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiPageType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiPageValidation]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UiPageValidationType]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UserClaim]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/16/2022 9:09:31 PM ******/
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
/****** Object:  Table [dbo].[UserRoleClaim]    Script Date: 11/16/2022 9:09:31 PM ******/
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

INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1, N'Default', N'~/Views/Common/Components/Grid/_gridTemplate1.cshtml', 0, 33)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2, N'Test Detail Classic', N'~/Views/Common/Components/Grid/_gridTemplate2.cshtml', 0, 33)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (3, N'Default', N'~/Views/Common/Components/Text/_text.cshtml', 0, 1)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (5, N'Large', N'~/Views/Common/Components/Text/_text1.cshtml', 0, 1)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1003, N'Default', N'~/Views/Common/Components/Checkbox/_checkbox.cshtml', 0, 3)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1004, N'Default', N'~/Views/Common/Components/Radio/_radio.cshtml', 0, 4)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1005, N'Default', N'~/Views/Common/Components/Submit/_submit.cshtml', 0, 6)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1006, N'Default ', N'~/Views/Common/Components/Email/_email.cshtml', 0, 10)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1007, N'Default', N'~/Views/Common/Components/Mobile/_mobileNumber.cshtml', 0, 12)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1009, N'Default', N'~/Views/Common/Components/Date/_time.cshtml', 0, 14)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1010, N'Default', N'~/Views/Common/Components/Url/_url.cshtml', 0, 15)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1011, N'Default', N'~/Views/Common/Components/DateTime/_datetime-local.cshtml', 0, 22)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1012, N'Default', N'~/Views/Common/Components/ProgressStatus/_progressStatus.cshtml', 0, 25)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1013, N'Default', N'~/Views/Common/Components/Tabs/_tabs.cshtml', 0, 28)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1014, N'Default', N'~/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml', 0, 30)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1015, N'Default', N'~/Views/Common/Components/Dropdown/_dropdown.cshtml', 0, 32)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1016, N'Default', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 1032)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1017, N'Null', N'Null', 0, 29)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1020, N'Default', N'~/Views/Common/Components/Textarea/_textarea.cshtml', 0, 8)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2004, N'Default', N'~/Views/Common/Components/File/_file.cshtml', 0, 5)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2006, N'Default', N'~/Views/Common/Components/DateTime/_year.cshtml', 0, 2032)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2007, N'Default', N'~/Views/Common/Components/Question/_checkbox.cshtml', 0, 2033)
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
SET IDENTITY_INSERT [dbo].[UiPageData] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 

INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (3, 8, 25, 0, N'ProgressStatus', 0, 1, 0, 1012)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (4, 8, 29, 0, N'Laboratory Details', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (5, 8, 29, 0, N' Discipline Details', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (6, 8, 29, 0, N'Scope Of Accreditation', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (7, 8, 29, 0, N'Organization', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (8, 8, 29, 0, N'Equipment', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (9, 8, 29, 0, N'Reference Materials', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (10, 8, 29, 0, N'Quality Control Activities', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (11, 8, 29, 0, N'Enclosure List', 0, 1, 3, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (12, 8, 1, 1, N'Name Of The Laboratory', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (13, 8, 1, 1, N'GSTIN', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (14, 8, 1, 1, N'Contry', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (15, 8, 1, 1, N'State/Provider', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (16, 8, 1, 1, N'City', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (17, 8, 1, 1, N'Address', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (18, 8, 1, 1, N'District', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (19, 8, 1032, 0, N'Pincode', 0, 2, 4, 1016)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (20, 8, 1, 1, N'Mobile Number', 0, 2, 4, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (21, 8, 10, 1, N'Email', 0, 2, 4, 1006)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (22, 8, 1, 0, N'Discipline Of Testing', 0, 2, 5, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (23, 8, 1, 0, N'Group', 0, 2, 5, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (24, 8, 1, 1, N'Location', 0, 2, 6, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (25, 8, 1, 1, N'Discipline', 0, 2, 6, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (26, 8, 1, 0, N'Group', 0, 2, 6, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (27, 8, 1, 0, N'Sub-Group', 0, 2, 6, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (28, 8, 8, 0, N'Products/Materials of Test', 0, 2, 6, 1020)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (29, 8, 8, 0, N'Specific tests or types of tests perofmed', 0, 2, 6, 1020)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (30, 8, 30, 0, N'Collapsable', 0, 1, 7, 1014)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (31, 8, 29, 0, N'Organization Structure', 0, 1, 30, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (32, 8, 29, 0, N'New Employee Details', 0, 1, 30, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (33, 8, 1, 1, N'Organization Chart of Laboratory Link', 0, 2, 31, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (34, 8, 1, 0, N'organization chart', 0, 2, 31, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (35, 8, 1, 0, N'Text Box', 0, 2, 32, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (36, 8, 1, 1, N'Text Box 1', 0, 2, 32, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1004, 8, 5, 0, N'Image Input', 0, 1, 32, 2004)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1005, 8, 1, 1, N'Location', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1006, 8, 1, 1, N'Discipline', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1007, 8, 1, 1, N'Group', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1008, 8, 1, 1, N'Type Of Test', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1009, 8, 1, 1, N'UID of Equipment', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1010, 8, 1, 1, N'Name Of Equipment', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1011, 8, 1, 0, N'Model', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1012, 8, 1, 0, N'Serial No', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1013, 8, 1, 1, N'Name Of Manufracturer', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1014, 8, 2032, 0, N'Year Of Make', 0, 2, 8, 2006)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1015, 8, 1, 0, N'Range and Accurecy', 0, 2, 8, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1017, 8, 22, 0, N'Last Calibration Date', 0, 2, 8, 1011)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1018, 8, 22, 0, N'Calibration Due on', 0, 2, 8, 1011)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1019, 8, 32, 0, N'Location', 0, 2, 9, 1015)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1023, 8, 1, 1, N'Discipline', 0, 2, 9, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1024, 8, 1, 1, N'Group', 0, 2, 9, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1025, 8, 1, 1, N'Name of Reference Material/Strain/Culture', 0, 2, 9, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1026, 8, 1, 1, N'Source', 0, 2, 9, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1027, 8, 22, 1, N'Date Of Expiry', 0, 2, 9, 1011)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1028, 8, 1, 1, N'Tracability', 0, 2, 9, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1029, 8, 1, 1, N'Location', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1030, 8, 1, 1, N'Type Of Partipatation', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1031, 8, 1, 1, N'Discipline', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1032, 8, 1, 1, N'Group', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1033, 8, 1, 1, N'Product/Material', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1034, 8, 1, 0, N'Details of Test', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1035, 8, 22, 0, N'Date Of Testing', 0, 2, 10, 1011)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1036, 8, 1, 1, N'Nodal Laboratory/PT Provider (Accredification Body/Country)', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1037, 8, 1, 1, N'Performance in Term of Z Score / Any Other Criteria', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1038, 8, 1, 0, N'Corrective Action Taken (if any)', 0, 2, 10, 3)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1039, 8, 5, 1, N'Upload Quality Manual', 0, 2, 11, 2004)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1040, 8, 4, 1, N'Calibrated By', 0, 1, 11, 1004)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1042, 8, 3, 0, N'Inhouse', 0, 1, 1040, 1003)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1043, 8, 3, 0, N'External', 0, 1, 1040, 1003)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1044, 8, 3, 0, N'Checkbox-check', 0, 1, 11, 1003)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1045, 8, 29, 0, N'Patna', 0, 1, 1019, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1046, 8, 29, 0, N'Lacknow', 0, 1, 1019, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1047, 8, 29, 0, N'Bareliy', 0, 1, 1019, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (1048, 8, 29, 0, N'Karnataka', 0, 1, 1019, 1017)
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [ParentId], [UiControlCategoryTypeId]) VALUES (2002, 8, 33, 0, N'Grid', 0, 1, 5, 2)
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
ALTER TABLE [dbo].[ClaimType] ADD  CONSTRAINT [DF_ClaimType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DataType] ADD  CONSTRAINT [DF_DataType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Lookup] ADD  CONSTRAINT [DF_Lookup_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LookupCategory] ADD  CONSTRAINT [DF_LookupCategory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
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
USE [master]
GO
ALTER DATABASE [SeedTest] SET  READ_WRITE 
GO
