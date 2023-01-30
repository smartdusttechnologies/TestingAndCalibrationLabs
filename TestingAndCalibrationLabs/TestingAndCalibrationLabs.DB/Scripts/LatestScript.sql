USE [master]
GO
/****** Object:  Database [WorkflowBranch]    Script Date: 1/30/2023 10:16:29 AM ******/
CREATE DATABASE [WorkflowBranch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkflowBranch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkflowBranch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkflowBranch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WorkflowBranch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WorkflowBranch] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkflowBranch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkflowBranch] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [WorkflowBranch] SET ANSI_NULLS ON 
GO
ALTER DATABASE [WorkflowBranch] SET ANSI_PADDING ON 
GO
ALTER DATABASE [WorkflowBranch] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [WorkflowBranch] SET ARITHABORT ON 
GO
ALTER DATABASE [WorkflowBranch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkflowBranch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkflowBranch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkflowBranch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkflowBranch] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [WorkflowBranch] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [WorkflowBranch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkflowBranch] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [WorkflowBranch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkflowBranch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkflowBranch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkflowBranch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkflowBranch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkflowBranch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkflowBranch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkflowBranch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkflowBranch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkflowBranch] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkflowBranch] SET  MULTI_USER 
GO
ALTER DATABASE [WorkflowBranch] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [WorkflowBranch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkflowBranch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkflowBranch] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WorkflowBranch] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorkflowBranch] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WorkflowBranch', N'ON'
GO
ALTER DATABASE [WorkflowBranch] SET QUERY_STORE = OFF
GO
USE [WorkflowBranch]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityMetadata]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Value] [varchar](300) NULL,
	[ActivityMetadataTypeId] [int] NULL,
	[WorkflowStageId] [int] NULL,
 CONSTRAINT [PK_ActivityMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[DataType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[LoginLog]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[LoginToken]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[LoginTokenLog]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Lookup]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[LookupCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupCategory]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[MetadataModuleBridge]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetadataModuleBridge](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[UiPageTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModuleId] [int] NULL,
	[ParentId] [int] NULL,
	[Orders] [int] NULL,
	[UiControlDisplayName] [varchar](50) NULL,
 CONSTRAINT [PK_MetadataModuleBridge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Organization]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[PasswordLogin]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[PasswordPolicy]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[PermissionModuleType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[PermissionType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Record]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Record](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModuleId] [int] NULL,
	[WorkflowStageId] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Sample]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[SampleTable]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Survey]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[TestReport]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UiControlCategoryType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UiControlType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UiNavigationCategory]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UiPageData]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[Value] [varchar](500) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[RecordId] [int] NOT NULL,
 CONSTRAINT [PK_UiPageData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadata]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiControlTypeId] [int] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[UiControlDisplayName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DataTypeId] [bigint] NOT NULL,
	[UiControlCategoryTypeId] [int] NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadataCharacteristics]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageMetadataCharacteristics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[LookupCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageMetadataCharacteristics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageNavigation]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageNavigation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](100) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[UiNavigationCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageNavigation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageType]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageValidation]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UiPageValidationType]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UserClaim]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[UserRoleClaim]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[Workflow]    Script Date: 1/30/2023 10:16:29 AM ******/
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
/****** Object:  Table [dbo].[WorkflowActivity]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkflowActivity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[WorkflowStageId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ActivityId] [int] NULL,
 CONSTRAINT [PK_WorkflowActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkflowStage]    Script Date: 1/30/2023 10:16:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkflowStage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[WorkflowId] [int] NOT NULL,
	[UiPageTypeId] [int] NULL,
	[Orders] [int] NULL,
 CONSTRAINT [PK_WorkflowStage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([Id], [Name], [IsDeleted]) VALUES (1, N'EmailServices', 0)
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
SET IDENTITY_INSERT [dbo].[ActivityMetadata] ON 

INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (1, N'**Email**', 1, 21, 0, NULL, 1016, 2)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (2, N'**Subject**', 1, 35, 0, N'Sample Recived Successfully ??', 1015, 2)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (3, N'HtmlMsg', 1, 36, 0, N'emailformat/SampleRecived.txt', 1015, 2)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (4, N'Name', 1, 3021, 0, NULL, 1016, 2)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (5, N'Email', 1, 21, 0, NULL, 1015, 4)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (7, N'HtmlMsg', 1, 36, 0, N'emailformat/LabAnalysis.txt', 1015, 4)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (9, N'Subject', 1, 35, 0, N'Report Is Ready For Your Review', 1015, 4)
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (12, N'**name**', 1, 3021, 0, N'Rishi Kumar', 1015, 4)
SET IDENTITY_INSERT [dbo].[ActivityMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[Application] ON 

INSERT [dbo].[Application] ([Id], [Name], [Description], [IsDeleted]) VALUES (1, N'Laboratory Management Application', N'Laboratory Management Application', 0)
SET IDENTITY_INSERT [dbo].[Application] OFF
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
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1008, N'Indea', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1009, N'Pakistan', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1010, N'England', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1011, N'USA', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1012, N'Bangladesh', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1013, N'New Zealand', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1014, N'Paris', 1005, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1015, N'Static', 1006, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1016, N'Dynamic', 1006, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1020, N'_testReport.html', 1007, 0)
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1021, N'_payment.html', 1008, 0)
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[LookupCategory] ON 

INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (4, N'UIControlCategory', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1004, N'Null', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1005, N'Country', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1006, N'ActitvityMetadataType', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1007, N'TestReport', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1008, N'Payment', 0)
SET IDENTITY_INSERT [dbo].[LookupCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[MetadataModuleBridge] ON 

INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3011, 3012, 14, 0, 3, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3012, 3013, 14, 0, 3, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3013, 3014, 14, 0, 3, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3014, 21, 14, 0, 3, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3015, 20, 14, 0, 3, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3016, 17, 14, 0, 3, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3017, 3016, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3018, 3017, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3019, 3018, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3020, 3019, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3021, 3020, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3022, 3021, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3023, 21, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3024, 20, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3025, 3024, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3026, 3025, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3029, 3026, 15, 0, 1, 4, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3030, 3027, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3031, 3028, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3032, 3029, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3033, 3030, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3034, 3031, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3035, 3032, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3037, 3034, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3038, 3035, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3039, 3036, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3040, 3019, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3041, 3037, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3042, 3038, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3043, 3039, 16, 0, 1, 5, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3044, 3008, 15, 0, 1, 4, 1, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3045, 3008, 16, 0, 1, 5, 2, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3046, 2002, 16, 0, 1, 0, 1, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3047, 3, 15, 0, 1, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3048, 4, 15, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3049, 5, 15, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3050, 6, 15, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3051, 7, 15, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3052, 8, 15, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3053, 3, 16, 0, 1, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3054, 4, 16, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3055, 5, 16, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3056, 6, 16, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3057, 7, 16, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3058, 8, 16, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3059, 3, 17, 0, 1, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3060, 4, 17, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3061, 5, 17, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3062, 6, 17, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3063, 7, 17, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3064, 8, 17, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3065, 3040, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3066, 3041, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3067, 3043, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3068, 3044, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3069, 3045, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3070, 3046, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3071, 3047, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3072, 3048, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3073, 3049, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3074, 3050, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3075, 3051, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3077, 3053, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3078, 3054, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3080, 3056, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3081, 3057, 17, 0, 1, 6, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3082, 3008, 17, 0, 1, 6, 1, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3083, 3, 18, 0, 1, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3084, 4, 18, 0, 1, 3, 0, N'Sample Reciving')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3085, 5, 18, 0, 1, 3, 0, N'Test Plan')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3086, 6, 18, 0, 1, 3, 0, N'Lab Analysis')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3087, 7, 18, 0, 1, 3, 0, N'Test Report')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3088, 8, 18, 0, 1, 3, 0, N'Payment & Billing')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3089, 3058, 18, 0, 1, 7, 122, N'Download')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3090, 3016, 18, 0, 1, 7, 1, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3091, 3017, 18, 0, 1, 7, 2, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3092, 3018, 18, 0, 1, 7, 3, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3093, 3019, 18, 0, 1, 7, 4, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3094, 3020, 18, 0, 1, 7, 5, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3095, 3021, 18, 0, 1, 7, 6, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3096, 21, 18, 0, 1, 7, 7, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3097, 20, 18, 0, 1, 7, 8, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3098, 3024, 18, 0, 1, 7, 9, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3099, 3025, 18, 0, 1, 7, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3100, 3, 19, 0, 1, 0, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3101, 4, 19, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3102, 5, 19, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3103, 6, 19, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3104, 7, 19, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3105, 8, 19, 0, 1, 3, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3106, 3059, 19, 0, 1, 8, 0, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3107, 3060, 19, 0, 1, 8, 1, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3108, 3061, 19, 0, 1, 8, 2, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3110, 3062, 19, 0, 1, 8, 3, N'Download Report')
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3111, 3008, 19, 0, 1, 8, 3, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3112, 3008, 18, 0, 1, 7, 150, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3113, 3040, 18, 0, 1, 7, 10, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3114, 3041, 18, 0, 1, 7, 11, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3116, 3043, 18, 0, 1, 7, 12, NULL)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3117, 3044, 18, 0, 1, 7, 13, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3118, 3045, 18, 0, 1, 7, 14, NULL)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName]) VALUES (3119, 3046, 18, 0, 1, 7, 15, NULL)
SET IDENTITY_INSERT [dbo].[MetadataModuleBridge] OFF
GO
SET IDENTITY_INSERT [dbo].[Module] ON 

INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (0, N'none', 1, 0)
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (1, N'Cube Testing', 1, 0)
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (2, N'Water Testing', 1, 0)
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (3, N'Customer', 1, 0)
SET IDENTITY_INSERT [dbo].[Module] OFF
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

INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10020, 1, 1, 2, CAST(N'2023-01-13T15:03:00.397' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10021, 1, 1, 2, CAST(N'2023-01-13T19:46:17.600' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10022, 1, 1, 2, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10023, 0, 3, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10024, 1, 1, 4, CAST(N'2023-01-16T12:42:47.643' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10025, 1, 1, 5, CAST(N'2023-01-23T20:28:32.743' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10026, 1, 1, 3, CAST(N'2023-01-16T20:14:24.413' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10027, 1, 1, 2, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10028, 1, 1, 2, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10029, 1, 1, 2, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10030, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10031, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10032, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10033, 1, 1, 3, CAST(N'2023-01-24T15:00:03.267' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10034, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10035, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10036, 1, 1, 2, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10037, 1, 1, 4, CAST(N'2023-01-24T15:24:03.267' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (10038, 1, 1, 5, CAST(N'2023-01-25T11:28:17.380' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11038, 1, 1, 9, CAST(N'2023-01-25T19:58:39.367' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11039, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11040, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11041, 1, 1, 3, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11042, 0, 1, 9, CAST(N'2023-01-25T22:19:29.350' AS DateTime))
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11043, 0, 1, 9, CAST(N'2023-01-30T10:06:01.953' AS DateTime))
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
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1012, N'Progress Bar', N'~/Views/Common/Components/ProgressStatus/_progressStatusWithWorklofw.cshtml', 0, 25)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1013, N'Tabs', N'~/Views/Common/Components/Tabs/_tabs.cshtml', 0, 28)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1014, N'Collapsable Section', N'~/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml', 0, 30)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1015, N'Dropdown', N'~/Views/Common/Components/Dropdown/_dropdown.cshtml', 0, 32)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1016, N'Pincode', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 34)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1017, N'Null', N'Null', 0, 29)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1020, N'Textarea', N'~/Views/Common/Components/Textarea/_textarea.cshtml', 0, 8)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2004, N'File', N'~/Views/Common/Components/File/_file.cshtml', 0, 5)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2006, N'Year', N'~/Views/Common/Components/DateTime/_year.cshtml', 0, 35)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2007, N'Checkbox', N'~/Views/Common/Components/Question/_checkbox.cshtml', 0, 36)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2008, N'WorkflowStage', N'~/Views/Common/Components/WorkflowStage/_workflowStage.cshtml', 0, 37)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2010, N'Download', N'~/Views/Common/Components/Download/_download.cshtml', 0, 38)
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
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (34, N'pincode', N'Pincode', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (35, N'year', N'Year', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (36, N'question', N'Question - Checkbox', 0, 9)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (37, N'workflowStage', N'Workflow Stage', 0, 8)
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (38, N'Download', N'ReportTemplate', 0, 9)
SET IDENTITY_INSERT [dbo].[UiControlType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiNavigationCategory] ON 

INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1, N'Survey', 2, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (2, N'Home', 1, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1002, N'Settings', 3, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1003, N'Profile', 4, 0)
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1004, N'Notifications', 5, 0)
SET IDENTITY_INSERT [dbo].[UiNavigationCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageData] ON 

INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10211, 3008, N'2', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10212, 3011, N'Raj Narayan Gupt', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10213, 3010, N'Raj Narayan Gupta', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10214, 1044, N'true', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10215, 1019, N'1008', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10216, 1040, N'', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10217, 21, N'rajkumar00999.rk@gmail.com', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10218, 35, N'Hey THis is email', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10219, 36, N'', 0, 10020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10220, 3008, N'2', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10221, 3011, N'Jai Hind', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10222, 3010, N'Raj', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10223, 1044, N'true', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10224, 21, N'rajkumar00999.rk@gmail.com', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10225, 35, N'sfsd', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10226, 36, N'dfgdf', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10227, 1019, N'1008', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10228, 1040, N'', 0, 10021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10229, 3008, N'2', 0, 10022)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10230, 3011, N'HE', 0, 10022)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10231, 3010, N'sfsd', 0, 10022)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10232, 3012, N'Raj', 0, 10023)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10233, 3013, N'Ritesh', 0, 10023)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10234, 3014, N'Raj Narayan Gupta', 0, 10023)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10235, 21, N'rajkumar00999.rk@gmail.com', 0, 10023)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10236, 20, N'9308337022', 0, 10023)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10237, 17, N'Khagaul Patna Bihar India 801105 ', 0, 10023)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10238, 3016, N'j', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10239, 3017, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10240, 3018, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10241, 3019, N'2002-12-28', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10242, 3020, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10243, 3021, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10244, 21, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10245, 20, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10246, 3024, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10247, 3025, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10248, 3026, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10249, 3008, N'4', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10250, 3027, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10251, 3028, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10252, 3029, N'2023-01-16', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10253, 3030, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10254, 3031, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10255, 3032, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10256, 3034, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10257, 3035, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10258, 3036, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10259, 3037, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10260, 3038, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10261, 3039, N'', 0, 10024)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10262, 3016, N'12345', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10263, 3017, N'Software Development', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10264, 3018, N'Rishi Kumar', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10265, 3019, N'2023-01-08', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10266, 3020, N'19', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10267, 3021, N'Saurav Kumar', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10268, 21, N'rajkumar00999.rk@gmail.com', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10269, 20, N'999xxx9999', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10270, 3024, N'2023-01-16', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10271, 3025, N'Nothing Required Now', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10272, 3026, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10273, 3008, N'5', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10274, 3016, N'123', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10275, 3017, N'DTP', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10276, 3018, N'ROhit', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10277, 3019, N'4421-12-05', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10278, 3020, N'123', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10279, 3021, N'Raj', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10280, 21, N'rajkumar00999.rk@gmail.com', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10281, 20, N'3085745896', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10282, 3024, N'5422-02-04', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10283, 3025, N'NIll', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10284, 3026, N'', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10285, 3008, N'3', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10286, 3027, N'Rawcdff', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10287, 3028, N'Edd', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10288, 3029, N'4522-04-05', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10289, 3030, N'123', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10290, 3031, N'1234dfg', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10291, 3032, N'1', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10292, 3034, N'Ui Test', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10293, 3035, N'Public', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10294, 3036, N'Raj Gupta', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10295, 3037, N'', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10296, 3038, N'', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10297, 3039, N'', 0, 10026)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10298, 3016, N'dfgdfgd', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10299, 3017, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10300, 3018, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10301, 3019, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10302, 3020, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10303, 3021, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10304, 21, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10305, 20, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10306, 3024, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10307, 3025, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10308, 3026, N'', 0, 10027)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10309, 3008, N'2', 0, 10027)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10310, 3016, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10311, 3017, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10312, 3018, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10313, 3019, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10314, 3020, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10315, 3021, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10316, 21, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10317, 20, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10318, 3024, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10319, 3025, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10320, 3026, N'', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10321, 3008, N'2', 0, 10028)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10322, 3016, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10323, 3017, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10324, 3018, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10325, 3019, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10326, 3020, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10327, 3021, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10328, 21, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10329, 20, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10330, 3024, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10331, 3025, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10332, 3026, N'', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10333, 3008, N'2', 0, 10029)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10334, 3027, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10335, 3028, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10336, 3029, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10337, 3030, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10338, 3031, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10339, 3032, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10340, 3034, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10341, 3035, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10342, 3036, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10343, 3037, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10344, 3038, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10345, 3039, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10346, 3040, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10347, 3041, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10348, 3043, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10349, 3044, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10350, 3045, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10351, 3046, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10352, 3047, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10353, 3048, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10354, 3049, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10355, 3050, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10356, 3051, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10357, 3053, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10358, 3054, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10359, 3056, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10360, 3057, N'', 0, 10025)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10361, 3016, N'1234', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10362, 3017, N'Software', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10363, 3018, N'Rishi', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10364, 3019, N'0004-12-05', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10365, 3020, N'19', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10366, 3021, N'saurav', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10367, 21, N'rajkumar00999.rk@gmail.com', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10368, 20, N'9587446028', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10369, 3024, N'2009-12-04', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10370, 3025, N'Nothing..', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10371, 3026, N'', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10372, 3008, N'3', 0, 10030)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10373, 3016, N'1234', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10374, 3017, N'Software', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10375, 3018, N'Rishi', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10376, 3019, N'2016-12-28', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10377, 3020, N'Patna', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10378, 3021, N'Saurav', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10379, 21, N'rajkumar00999.rk@gmail.com', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10380, 20, N'9308338766', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10381, 3024, N'5255-12-25', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10382, 3025, N'Nothing..', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10383, 3026, N'', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10384, 3008, N'3', 0, 10031)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10385, 3016, N'1234', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10386, 3017, N'Software', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10387, 3018, N'Rishi', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10388, 3019, N'2016-12-28', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10389, 3020, N'Patna', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10390, 3021, N'Saurav', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10391, 21, N'rajkumar00999.rk@gmail.com', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10392, 20, N'9308338766', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10393, 3024, N'5255-12-25', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10394, 3025, N'Nothing..', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10395, 3026, N'', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10396, 3008, N'3', 0, 10032)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10397, 3016, N'1234', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10398, 3017, N'Software', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10399, 3018, N'Rishi', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10400, 3019, N'2016-12-28', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10401, 3020, N'Patna', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10402, 3021, N'Saurav', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10403, 21, N'rajkumar00999.rk@gmail.com', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10404, 20, N'9308338766', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10405, 3024, N'5255-12-25', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10406, 3025, N'Nothing..', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10407, 3026, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10408, 3008, N'3', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10409, 3027, N'', 0, 10033)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10410, 3028, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10411, 3029, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10412, 3030, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10413, 3031, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10414, 3032, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10415, 3034, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10416, 3035, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10417, 3036, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10418, 3037, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10419, 3038, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10420, 3039, N'', 0, 10033)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10421, 3016, N'1234', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10422, 3017, N'Software', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10423, 3018, N'19', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10424, 3019, N'1085-02-08', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10425, 3020, N'19', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10426, 3021, N'Saurav Kumar', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10427, 21, N'rajkumar00999.rk@gmail.com', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10428, 20, N'8457458896', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10429, 3024, N'7515-12-14', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10430, 3025, N'Nothhing', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10431, 3026, N'', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10432, 3008, N'3', 0, 10034)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10433, 3016, N'134', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10434, 3017, N'Software', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10435, 3018, N'Rishi Kumar', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10436, 3019, N'1155-02-08', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10437, 3020, N'19', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10438, 3021, N'Saurav Jaiswal', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10439, 21, N'rajkumar00999.rk@gmail.com', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10440, 20, N'7895468459', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10441, 3024, N'45465-12-06', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10442, 3025, N'Nothing..', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10443, 3026, N'', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10444, 3008, N'3', 0, 10035)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10445, 3016, N'1234', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10446, 3017, N'Software', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10447, 3018, N'Rishi Kumar', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10448, 3019, N'1414-02-08', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10449, 3020, N'19', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10450, 3021, N'Saurav Jaiswal', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10451, 21, N'rajkumar00999.rk@gmail.com', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10452, 20, N'8597559812', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10453, 3024, N'0051-05-06', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10454, 3025, N'Nothing..', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10455, 3026, N'', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10456, 3008, N'2', 0, 10036)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10457, 3016, N'1234', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10458, 3017, N'Software', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10459, 3018, N'Rishi Kumar', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10460, 3019, N'4415-02-04', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10461, 3020, N'196', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10462, 3021, N'Saurav Jaiswal', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10463, 21, N'rajkumar00999.rk@gmail.com', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10464, 20, N'9308465465', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10465, 3024, N'5121-05-06', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10466, 3025, N'nothing...', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10467, 3026, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10468, 3008, N'4', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10469, 3027, N'Water test', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10470, 3028, N'UIDF', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10471, 3029, N'0044-04-04', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10472, 3030, N'12334', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10473, 3031, N'1234', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10474, 3032, N'13d', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10475, 3034, N'Wter', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10476, 3035, N'Uopen', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10477, 3036, N'Yes', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10478, 3037, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10479, 3038, N'0545-05-05', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10480, 3039, N'Nothing', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10481, 3040, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10482, 3041, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10483, 3043, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10484, 3044, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10485, 3045, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10486, 3046, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10487, 3047, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10488, 3048, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10489, 3049, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10490, 3050, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10491, 3051, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10492, 3053, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10493, 3054, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10494, 3056, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10495, 3057, N'', 0, 10037)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10496, 3016, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10497, 3017, N'546', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10498, 3018, N'fh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10499, 3019, N'0656-05-04', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10500, 3020, N'tgdgdfg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10501, 3021, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10502, 21, N'rajkumar00999.rk@gmail.com', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10503, 20, N'34534565', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10504, 3024, N'0566-03-04', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10505, 3025, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10506, 3026, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10507, 3008, N'5', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10508, 3027, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10509, 3028, N'fh', 0, 10038)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10510, 3029, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10511, 3030, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10512, 3031, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10513, 3032, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10514, 3034, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10515, 3035, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10516, 3036, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10517, 3037, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10518, 3038, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10519, 3039, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10520, 3040, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10521, 3041, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10522, 3043, N'fh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10523, 3044, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10524, 3045, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10525, 3046, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10526, 3047, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10527, 3048, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10528, 3049, N'fgh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10529, 3050, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10530, 3051, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10531, 3053, N'fg', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10532, 3054, N'fh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10533, 3056, N'', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (10534, 3057, N'fh', 0, 10038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11496, 3016, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11497, 3017, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11498, 3018, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11499, 3019, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11500, 3020, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11501, 3021, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11502, 21, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11503, 20, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11504, 3024, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11505, 3025, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11506, 3026, N'', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11507, 3008, N'9', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11508, 3059, N'250', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11509, 3060, N'250', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11510, 3061, N'500', 0, 11038)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11511, 3016, N'1234', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11512, 3017, N'Software', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11513, 3018, N'Rishi Kumar', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11514, 3019, N'5211-12-08', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11515, 3020, N'198', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11516, 3021, N'Saurav Kumar', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11517, 21, N'rajkumar00999.rk@gmail.com', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11518, 20, N'234892429', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11519, 3024, N'', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11520, 3025, N'Nothing..', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11521, 3026, N'', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11522, 3008, N'3', 0, 11039)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11523, 3016, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11524, 3017, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11525, 3018, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11526, 3019, N'5211-12-08', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11527, 3020, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11528, 3021, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11529, 21, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11530, 20, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11531, 3024, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11532, 3025, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11533, 3026, N'', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11534, 3008, N'3', 0, 11040)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11535, 3016, N'34535', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11536, 3017, N'sdfsdf', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11537, 3018, N'sfsdf', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11538, 3019, N'5211-12-08', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11539, 3020, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11540, 3021, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11541, 21, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11542, 20, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11543, 3024, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11544, 3025, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11545, 3026, N'', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11546, 3008, N'3', 0, 11041)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11547, 3016, N'1234', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11548, 3017, N'SoftwaEW', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11549, 3018, N'Rtesh kumar', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11550, 3019, N'5545-05-04', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11551, 3020, N'1265', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11552, 3021, N'Rishi kumar', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11553, 21, N'stmichelsindi@gmail.com', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11554, 20, N'543524553', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11555, 3024, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11556, 3025, N'nothing', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11557, 3026, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11558, 3008, N'9', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11559, 3027, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11560, 3028, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11561, 3029, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11562, 3030, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11563, 3031, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11564, 3032, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11565, 3034, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11566, 3035, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11567, 3036, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11568, 3037, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11569, 3038, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11570, 3039, N'', 0, 11042)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11571, 3040, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11572, 3041, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11573, 3043, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11574, 3044, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11575, 3045, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11576, 3046, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11577, 3047, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11578, 3048, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11579, 3049, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11580, 3050, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11581, 3051, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11582, 3053, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11583, 3054, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11584, 3056, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11585, 3057, N'', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11586, 3059, N'12', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11587, 3060, N'12', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11588, 3061, N'24', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11589, 3059, N'12', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11590, 3060, N'12', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11591, 3061, N'24', 0, 11042)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11592, 3016, N'234', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11593, 3017, N'ar', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11594, 3018, N'asf', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11595, 3019, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11596, 3020, N'sdalk`', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11597, 3021, N'fsalk', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11598, 21, N'rajkumar00999.rk@gmail.com', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11599, 20, N'23432423', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11600, 3024, N'0024-03-04', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11601, 3025, N'Raj Narayan ', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11602, 3026, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11603, 3008, N'9', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11604, 3027, N'dfgv', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11605, 3028, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11606, 3029, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11607, 3030, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11608, 3031, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11609, 3032, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11610, 3034, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11611, 3035, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11612, 3036, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11613, 3037, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11614, 3038, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11615, 3039, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11616, 3040, N'2002-11-28', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11617, 3041, N'245', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11618, 3043, N'https:://raj', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11619, 3044, N'2002-11-28', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11620, 3045, N'22', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11621, 3046, N'5length', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11622, 3047, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11623, 3048, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11624, 3049, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11625, 3050, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11626, 3051, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11627, 3053, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11628, 3054, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11629, 3056, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11630, 3057, N'', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11631, 3059, N'250', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11632, 3060, N'150', 0, 11043)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (11633, 3061, N'400', 0, 11043)
SET IDENTITY_INSERT [dbo].[UiPageData] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 

INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3, 25, 0, N'ProgressStatus', 0, 1, 1012, N'progress1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (4, 29, 0, N'Sample Recieving', 0, 1, 1017, N'lab1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (5, 29, 0, N'Test Plan', 0, 1, 1017, N'disc1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (6, 29, 0, N'Lab Analysis', 0, 1, 1017, N'disc2')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (7, 29, 0, N'Test Report', 0, 1, 1017, N'org1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (8, 29, 0, N'Billing & Payment', 0, 1, 1017, N'equi1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (9, 29, 0, N'Reference Materials', 0, 1, 1017, N'refer1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (10, 29, 0, N'Quality Control Activities', 0, 1, 1017, N'qcont1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (11, 29, 0, N'Enclosure List', 0, 1, 1017, N'enc1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (12, 1, 1, N'Name Of The Laboratory', 0, 2, 3, N'nothe1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (13, 1, 1, N'GSTIN', 0, 2, 3, N'gstin1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (14, 1, 1, N'Contry', 0, 2, 3, N'cont2')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (15, 1, 1, N'State/Provider', 0, 2, 3, N'sttt3')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (16, 1, 1, N'City', 0, 2, 3, N'ct3')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (17, 1, 1, N'Address', 0, 2, 3, N'adgag4')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (18, 1, 1, N'District', 0, 2, 3, N'discr4')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (19, 1032, 0, N'Pincode', 0, 2, 1016, N'pincd5')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (20, 12, 1, N'Mobile Number', 0, 2, 1007, N'mobi34')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (21, 10, 1, N'Email', 0, 2, 1006, N'emuil34')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (22, 1, 0, N'Discipline Of Testing', 0, 2, 3, N'discip6')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (23, 1, 0, N'Group', 0, 2, 3, N'grty5')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (24, 1, 1, N'Location', 0, 2, 3, N'dsg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (25, 1, 1, N'Discipline', 0, 2, 3, N'etr')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (26, 1, 0, N'Group', 0, 2, 3, N'ttyr')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (27, 1, 0, N'Sub-Group', 0, 2, 3, N'rteag')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (28, 8, 0, N'Products/Materials of Test', 0, 2, 1020, N'dgsdsert')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (29, 8, 0, N'Specific tests or types of tests perofmed', 0, 2, 1020, N'vstyers')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (30, 30, 0, N'Collapsable', 0, 1, 1014, N'dasterdsd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (31, 29, 0, N'Organization Structure', 0, 1, 1017, N'hyer')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (32, 29, 0, N'New Employee Details', 0, 1, 1017, N'gdfy')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (33, 1, 1, N'Organization Chart of Laboratory Link', 0, 2, 3, N'dfgd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (34, 1, 0, N'organization chart', 0, 2, 3, N'rtyery')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (35, 1, 0, N'Subject', 0, 2, 3, N'hrty')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (36, 1, 1, N'HtmlMsg', 0, 2, 3, N'wsrt')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1004, 5, 0, N'Image Input', 0, 1, 2004, N'sg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1005, 1, 1, N'Location', 0, 2, 3, N'sergs')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1006, 1, 1, N'Discipline', 0, 2, 3, N'tr5')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1007, 1, 1, N'Group', 0, 2, 3, N'sgsret')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1008, 1, 1, N'Type Of Test', 0, 2, 3, N'regs')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1009, 1, 1, N'UID of Equipment', 0, 2, 3, N'trse')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1010, 1, 1, N'Name Of Equipment', 0, 2, 3, N'gsdg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1011, 1, 0, N'Model', 0, 2, 3, N'uys')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1012, 1, 0, N'Serial No', 0, 2, 3, N'bew')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1013, 1, 1, N'Name Of Manufracturer', 0, 2, 3, N'ma')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1014, 2032, 0, N'Year Of Make', 0, 2, 2006, N'v')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1015, 1, 0, N'Range and Accurecy', 0, 2, 3, N'rtsd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1017, 22, 0, N'Last Calibration Date', 0, 2, 1011, N'uym')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1018, 22, 0, N'Calibration Due on', 0, 2, 1011, N'du v')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1019, 32, 0, N'Location', 0, 2, 1015, N'aser')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1023, 1, 1, N'Discipline', 0, 2, 3, N'bys')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1024, 1, 1, N'Group', 0, 2, 3, N'um')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1025, 1, 1, N'Name of Reference Material/Strain/Culture', 0, 2, 3, N'gbgsn ')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1026, 1, 1, N'Source', 0, 2, 3, N'shb sdfy')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1027, 22, 1, N'Date Of Expiry', 0, 2, 1011, N'dbsghv')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1028, 1, 1, N'Tracability', 0, 2, 3, N'vbs')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1029, 1, 1, N'Location', 0, 2, 3, N'gvtsn s')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1030, 1, 1, N'Type Of Partipatation', 0, 2, 3, N'm,s ij')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1031, 1, 1, N'Discipline', 0, 2, 3, N'v ')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1032, 1, 1, N'Group', 0, 2, 3, N'zym r')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1033, 1, 1, N'Product/Material', 0, 2, 3, N'mn')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1034, 1, 0, N'Details of Test', 0, 2, 3, N'burtm,')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1035, 22, 0, N'Date Of Testing', 0, 2, 1011, N'io')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1036, 1, 1, N'Nodal Laboratory/PT Provider (Accredification Body/Country)', 0, 2, 3, N'rb')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1037, 1, 1, N'Performance in Term of Z Score / Any Other Criteria', 0, 2, 3, N'ta')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1038, 1, 0, N'Corrective Action Taken (if any)', 0, 2, 3, N'byim')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1039, 5, 1, N'Upload Quality Manual', 0, 2, 2004, N'ng')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1040, 4, 1, N'Calibrated By', 0, 1, 1004, N'svbtyio')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1042, 29, 0, N'Inhouse', 0, 1, 1003, N'eryrt')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1043, 29, 0, N'External', 0, 1, 1003, N'ryrtuty')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1044, 3, 0, N'Checkbox-check', 0, 1, 1003, N'esbum')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1045, 29, 0, N'Patna', 1, 1, 1017, N'iduyaer')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1046, 29, 0, N'Lacknow', 1, 1, 1017, N'sgfdsgd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1047, 29, 0, N'Bareliy', 1, 1, 1017, N'sdgsdfg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1048, 29, 0, N'Karnataka', 1, 1, 1017, N'fgd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (2002, 33, 0, N'Grid', 0, 1, 2, N'lfy')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (2008, 1, 0, N'adfsafds', 0, 2, 3, N'afsdfa')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3006, 1, 0, N'Name', 0, 2, 3, N'UserName')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3007, 1, 0, N'fghfgh', 0, 2, 1010, N'hfhgh')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3008, 37, 0, N'Workflow', 0, 1, 2008, N'wrkff')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3009, 1, 0, N'User Table', 0, 2, 3, N'Raj')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3010, 1, 0, N'TableName', 0, 2, 3, N'uyhfg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3011, 1, 0, N'ThirdPageName', 0, 3, 3, N'jh')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3012, 1, 0, N'Customer Name', 0, 2, 3, N'cu')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3013, 1, 0, N'Contant Person', 0, 2, 3, N'cP')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3014, 1, 0, N'Name', 0, 2, 3, N'name')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3016, 1, 0, N'Job Serial No', 0, 2, 3, N'jsn')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3017, 1, 0, N'Department Name', 0, 2, 3, N'rd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3018, 1, 0, N'Issue To', 0, 2, 3, N'df')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3019, 22, 0, N'Recived On', 0, 3, 1011, N'jklg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3020, 1, 0, N'Job Order No / Ref No', 0, 2, 3, N'sdg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3021, 1, 0, N'Contact Person Name', 0, 2, 3, N'ds')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3024, 22, 0, N'TestReport Release Date', 0, 3, 1011, N'datee')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3025, 1, 0, N'Any Other Specific Requirment', 0, 2, 3, N'sdsf')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3026, 5, 0, N'Attachments', 0, 3, 2004, N'sfsd')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3027, 1, 0, N'Sample Type', 0, 3, 3, N'dfgf')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3028, 1, 0, N'Sample Details', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3029, 22, 0, N'Date of TP', 0, 2, 1011, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3030, 1, 0, N'Job Code No', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3031, 1, 0, N'Sample ID', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3032, 1, 0, N'Number Of Samples/Quantity', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3034, 1, 0, N'Test Name ', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3035, 1, 0, N'Test Method', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3036, 1, 0, N'Person Authorized', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3037, 22, 0, N'Targeted On', 0, 2, 1011, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3038, 22, 0, N'Completed on', 0, 2, 1011, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3039, 1, 0, N'Remarks', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3040, 22, 0, N'Date Of Report', 0, 3, 1011, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3041, 1, 0, N'Report No', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3043, 1, 0, N'ULR No', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3044, 22, 0, N'Date Of Casting', 0, 2, 1011, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3045, 1, 0, N'Age Of Specimens', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3046, 1, 0, N'Length', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3047, 1, 0, N'Width', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3048, 1, 0, N'Height', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3049, 1, 0, N'mm²', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3050, 1, 0, N'cm³', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3051, 1, 0, N'gm', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3053, 1, 0, N'gm/cm³', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3054, 1, 0, N'Load, KN', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3056, 1, 0, N'Compressive Strength, N/mm²', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3057, 1, 0, N'Average', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3058, 38, 0, N'TestReport', 0, 2, 2010, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3059, 1, 0, N'Price', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3060, 1, 0, N'Tax', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3061, 1, 0, N'Total', 0, 2, 3, N'0')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3062, 38, 0, N'Payment', 0, 2, 2010, N'0')
SET IDENTITY_INSERT [dbo].[UiPageMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics] ON 

INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (1, 1019, 1005, 0)
INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (3, 3058, 1007, 0)
INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (4, 3062, 1008, 0)
SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageNavigation] ON 

INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (1, N'/Common/Index/{0}', 1, 2, 0)
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (2, N'/Common/Index/{0}', 2, 2, 0)
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (3, N'/', 0, 1002, 0)
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (4, N'/', 0, 1003, 0)
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (5, N'/', 0, 1004, 0)
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (1002, N'/Common/Index/{0}', 3, 2, 0)
SET IDENTITY_INSERT [dbo].[UiPageNavigation] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageType] ON 

INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (1, N'Ui Page Type', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (2, N'Ui Control Type', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (3, N'Ui Page Metadata', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (4, N'Ui Page Validation', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (5, N'Home', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (6, N'My Activity', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (8, N'Nabl', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (10, N'Sample Recieving', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (11, N'Test Plan', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (12, N'Page1', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (13, N'Page2', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (14, N'Customer', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (15, N'Sample Recieving ', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (16, N'Test Plan', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (17, N'Lab Analysis', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (18, N'Test Reports', 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (19, N'Bill & Payment', 0)
SET IDENTITY_INSERT [dbo].[UiPageType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] ON 

INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (2, 8, 12, 4, 1)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (3, 10, 3008, 7, 1)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (4, 10, 3008, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (5, 10, 3010, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (6, 15, 3016, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (7, 15, 3017, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (8, 15, 3018, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (9, 15, 3019, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (10, 15, 3020, 7, 0)
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
SET IDENTITY_INSERT [dbo].[Workflow] ON 

INSERT [dbo].[Workflow] ([Id], [Name], [ModuleId], [IsDeleted]) VALUES (1, N'Cube Testing Flow', 1, 0)
INSERT [dbo].[Workflow] ([Id], [Name], [ModuleId], [IsDeleted]) VALUES (2, N'Water Testing Flow', 2, 0)
INSERT [dbo].[Workflow] ([Id], [Name], [ModuleId], [IsDeleted]) VALUES (3, N'Customer', 3, 0)
SET IDENTITY_INSERT [dbo].[Workflow] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkflowActivity] ON 

INSERT [dbo].[WorkflowActivity] ([Id], [Name], [WorkflowStageId], [IsDeleted], [ActivityId]) VALUES (1, N'EmailAc', 2, 0, 1)
INSERT [dbo].[WorkflowActivity] ([Id], [Name], [WorkflowStageId], [IsDeleted], [ActivityId]) VALUES (2, N'EmailFirst', 4, 0, 1)
SET IDENTITY_INSERT [dbo].[WorkflowActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkflowStage] ON 

INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (2, N'Sample Receiving', 0, 1, 15, 0)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (3, N'Test Plan', 0, 1, 16, 1)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (4, N'Lab Analysis', 0, 1, 17, 2)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (5, N'Test Report', 0, 1, 18, 3)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (9, N'Billing & Payments', 0, 1, 19, 4)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (10, N'Customer', 0, 3, 14, 0)
SET IDENTITY_INSERT [dbo].[WorkflowStage] OFF
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ActivityMetadata] ADD  CONSTRAINT [DF_ActivityMetadata_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
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
ALTER TABLE [dbo].[MetadataModuleBridge] ADD  CONSTRAINT [DF_MetadataModuleBridge_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
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
ALTER TABLE [dbo].[UiPageNavigation] ADD  CONSTRAINT [DF_UiPageNavigation_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
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
ALTER TABLE [dbo].[WorkflowActivity] ADD  CONSTRAINT [DF_WorkflowActivity_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[WorkflowStage] ADD  CONSTRAINT [DF_WorkflowStage_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ActivityMetadata]  WITH CHECK ADD  CONSTRAINT [FK_ActivityMetadata_Activity] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
GO
ALTER TABLE [dbo].[ActivityMetadata] CHECK CONSTRAINT [FK_ActivityMetadata_Activity]
GO
ALTER TABLE [dbo].[ActivityMetadata]  WITH CHECK ADD  CONSTRAINT [FK_ActivityMetadata_UiPageMetadata] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[ActivityMetadata] CHECK CONSTRAINT [FK_ActivityMetadata_UiPageMetadata]
GO
ALTER TABLE [dbo].[ActivityMetadata]  WITH CHECK ADD  CONSTRAINT [FK_ActivityMetadata_WorkflowStage] FOREIGN KEY([WorkflowStageId])
REFERENCES [dbo].[WorkflowStage] ([Id])
GO
ALTER TABLE [dbo].[ActivityMetadata] CHECK CONSTRAINT [FK_ActivityMetadata_WorkflowStage]
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
ALTER TABLE [dbo].[MetadataModuleBridge]  WITH CHECK ADD  CONSTRAINT [FK_MetadataModuleBridge_UiPageMetadata] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[MetadataModuleBridge] CHECK CONSTRAINT [FK_MetadataModuleBridge_UiPageMetadata]
GO
ALTER TABLE [dbo].[MetadataModuleBridge]  WITH CHECK ADD  CONSTRAINT [FK_MetadataModuleBridge_UiPageType_Id] FOREIGN KEY([UiPageTypeId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[MetadataModuleBridge] CHECK CONSTRAINT [FK_MetadataModuleBridge_UiPageType_Id]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_Module_Application_Id] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([Id])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_Module_Application_Id]
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
ALTER TABLE [dbo].[UiPageMetadataCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadataCharacteristics_LookupCategory_Id] FOREIGN KEY([LookupCategoryId])
REFERENCES [dbo].[LookupCategory] ([Id])
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics] CHECK CONSTRAINT [FK_UiPageMetadataCharacteristics_LookupCategory_Id]
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadataCharacteristics_UiPageMetadata_Id] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[UiPageMetadataCharacteristics] CHECK CONSTRAINT [FK_UiPageMetadataCharacteristics_UiPageMetadata_Id]
GO
ALTER TABLE [dbo].[UiPageNavigation]  WITH CHECK ADD  CONSTRAINT [FK_UiPageNavigation_Module_Id] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[UiPageNavigation] CHECK CONSTRAINT [FK_UiPageNavigation_Module_Id]
GO
ALTER TABLE [dbo].[UiPageNavigation]  WITH CHECK ADD  CONSTRAINT [FK_UiPageNavigation_UiNavigationCategory_Id] FOREIGN KEY([UiNavigationCategoryId])
REFERENCES [dbo].[UiNavigationCategory] ([Id])
GO
ALTER TABLE [dbo].[UiPageNavigation] CHECK CONSTRAINT [FK_UiPageNavigation_UiNavigationCategory_Id]
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
ALTER TABLE [dbo].[WorkflowStage]  WITH CHECK ADD  CONSTRAINT [FK_UiPageType_WorkflowStage_Id] FOREIGN KEY([UiPageTypeId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[WorkflowStage] CHECK CONSTRAINT [FK_UiPageType_WorkflowStage_Id]
GO
ALTER TABLE [dbo].[WorkflowStage]  WITH NOCHECK ADD  CONSTRAINT [FK_WorkflowStage_Workflow_Id] FOREIGN KEY([WorkflowId])
REFERENCES [dbo].[Workflow] ([Id])
GO
ALTER TABLE [dbo].[WorkflowStage] CHECK CONSTRAINT [FK_WorkflowStage_Workflow_Id]
GO
USE [master]
GO
ALTER DATABASE [WorkflowBranch] SET  READ_WRITE 
GO
