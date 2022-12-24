USE [master]
GO
/****** Object:  Database [V2Workflow]    Script Date: 12/24/2022 10:18:49 AM ******/
CREATE DATABASE [V2Workflow]
 CONTAINMENT = NONE
 
GO
ALTER DATABASE [V2Workflow] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [V2Workflow].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [V2Workflow] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [V2Workflow] SET ANSI_NULLS ON 
GO
ALTER DATABASE [V2Workflow] SET ANSI_PADDING ON 
GO
ALTER DATABASE [V2Workflow] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [V2Workflow] SET ARITHABORT ON 
GO
ALTER DATABASE [V2Workflow] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [V2Workflow] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [V2Workflow] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [V2Workflow] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [V2Workflow] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [V2Workflow] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [V2Workflow] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [V2Workflow] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [V2Workflow] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [V2Workflow] SET  DISABLE_BROKER 
GO
ALTER DATABASE [V2Workflow] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [V2Workflow] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [V2Workflow] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [V2Workflow] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [V2Workflow] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [V2Workflow] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [V2Workflow] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [V2Workflow] SET RECOVERY FULL 
GO
ALTER DATABASE [V2Workflow] SET  MULTI_USER 
GO
ALTER DATABASE [V2Workflow] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [V2Workflow] SET DB_CHAINING OFF 
GO
ALTER DATABASE [V2Workflow] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [V2Workflow] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [V2Workflow] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [V2Workflow] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'V2Workflow', N'ON'
GO
ALTER DATABASE [V2Workflow] SET QUERY_STORE = OFF
GO
USE [V2Workflow]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[ClaimType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[DataType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[LoginLog]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[LoginToken]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[LoginTokenLog]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Lookup]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[LookupCategory]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[MetadataModuleBridge]    Script Date: 12/24/2022 10:18:49 AM ******/
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
 CONSTRAINT [PK_MetadataModuleBridge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Organization]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[PasswordLogin]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[PasswordPolicy]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Permission]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[PermissionModuleType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[PermissionType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Record]    Script Date: 12/24/2022 10:18:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Record](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModuleId] [int] NULL,
 CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Sample]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[SampleTable]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Survey]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[TestReport]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiControlCategoryType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiControlType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiNavigationCategory]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiPageData]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiPageMetadata]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiPageMetadataCharacteristics]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiPageType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiPageValidation]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UiPageValidationType]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UserClaim]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[UserRoleClaim]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[Workflow]    Script Date: 12/24/2022 10:18:49 AM ******/
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
/****** Object:  Table [dbo].[WorkflowActivity]    Script Date: 12/24/2022 10:18:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkflowActivity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[WorkflowStageId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_WorkflowActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkflowStage]    Script Date: 12/24/2022 10:18:49 AM ******/
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
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[LookupCategory] ON 

INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (4, N'UIControlCategory', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1004, N'Null', 0)
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1005, N'Country', 0)
SET IDENTITY_INSERT [dbo].[LookupCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[MetadataModuleBridge] ON 

INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (1, 3008, 12, 0, 1, 0, 0)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (2, 3008, 13, 0, 1, 0, 1)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (4, 3011, 12, 0, 1, 0, 1)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (1002, 3010, 10, 0, 1, 0, 0)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (1003, 3008, 10, 0, 1, 0, 2)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (1004, 3011, 10, 0, 1, 0, 1)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (1005, 3010, 12, 0, 1, 0, 2)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (2005, 1019, 10, 0, 1, 0, 3)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (2006, 1040, 10, 0, 1, 0, 4)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (2007, 1042, 10, 0, 1, 1040, 0)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (2008, 1043, 10, 0, 1, 1040, 0)
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders]) VALUES (3006, 1044, 10, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[MetadataModuleBridge] OFF
GO
SET IDENTITY_INSERT [dbo].[Module] ON 

INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (1, N'Cube Testing', 1, 0)
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (2, N'Water Testing', 1, 0)
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

INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (2, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (5, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (7, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (8, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (9, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1002, 0, NULL)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1003, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1004, 0, 0)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1005, 0, 0)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1006, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1007, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1008, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1009, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1010, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (1011, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (2004, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (2005, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (2006, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (2007, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (2008, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3004, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3005, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3006, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3007, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3008, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3009, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (3011, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4011, 0, 0)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4012, 0, 0)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4013, 0, 0)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4014, 0, 0)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4015, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (4016, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (5011, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (5012, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6011, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6012, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6013, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6014, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6015, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6016, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6017, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6018, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6019, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6020, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (6021, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (7011, 0, 1)
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId]) VALUES (7012, 0, 1)
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
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1016, N'Pincode', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 34)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1017, N'Null', N'Null', 0, 29)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1020, N'Textarea', N'~/Views/Common/Components/Textarea/_textarea.cshtml', 0, 8)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2004, N'File', N'~/Views/Common/Components/File/_file.cshtml', 0, 5)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2006, N'Year', N'~/Views/Common/Components/DateTime/_year.cshtml', 0, 35)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2007, N'Checkbox', N'~/Views/Common/Components/Question/_checkbox.cshtml', 0, 36)
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2008, N'WorkflowStage', N'~/Views/Common/Components/WorkflowStage/_workflowStage.cshtml', 0, 37)
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

INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3157, 3010, N'Tab', 0, 3009)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3158, 3008, N'10', 0, 3009)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3159, 3011, N'Raj', 0, 3009)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3160, 1019, N'1008', 0, 3009)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3161, 3010, N'TableName', 0, 3011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3162, 3008, N'11', 0, 3011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3163, 3011, N'ThirdPageName', 0, 3011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (3164, 1019, N'1009', 0, 3011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4161, 3010, N'', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4162, 3008, N'10', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4163, 3011, N'', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4164, 1019, N'1008', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4165, 1040, N'on', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4166, 1042, N'', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4167, 1043, N'', 0, 4011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4168, 3010, N'calibrated', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4169, 3008, N'12', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4170, 3011, N'sfsf', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4171, 1019, N'1009', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4172, 1040, N'on', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4173, 1042, N'', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4174, 1043, N'', 0, 4012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4175, 3010, N'vbnvb', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4176, 3008, N'10', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4177, 3011, N'nvvbn', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4178, 1019, N'1008', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4179, 1040, N'on', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4180, 1042, N'', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4181, 1043, N'', 0, 4013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4182, 3010, N'kjhkjhkh', 0, 4014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4183, 3008, N'10', 0, 4014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4184, 3011, N'jkjhkjh', 0, 4014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4185, 1019, N'1010', 0, 4014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4186, 1040, N'', 0, 4014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4187, 3010, N'tabNa', 0, 4015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4188, 3008, N'10', 0, 4015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4189, 3011, N'ThirdPP', 0, 4015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4190, 1019, N'1008', 0, 4015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4191, 1040, N'', 0, 4015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4192, 3010, N'raj', 0, 4016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4193, 3008, N'12', 0, 4016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4194, 3011, N'gupta', 0, 4016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4195, 1019, N'1008', 0, 4016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (4196, 1040, N'', 0, 4016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5161, 1040, N'', 0, 3009)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5162, 3010, N'gsdfgs', 0, 5011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5163, 3008, N'10', 0, 5011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5164, 3011, N'fsf', 0, 5011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5165, 1019, N'1008', 0, 5011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5166, 1040, N'', 0, 5011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5167, 3010, N'', 0, 5012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5168, 3008, N'', 0, 5012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5169, 3011, N'', 0, 5012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5170, 1019, N'', 0, 5012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (5171, 1040, N'', 0, 5012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6161, 3010, N'', 0, 6011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6162, 3008, N'10', 0, 6011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6163, 3011, N'', 0, 6011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6164, 1019, N'1008', 0, 6011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6165, 1040, N'', 0, 6011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6166, 3010, N'', 0, 6012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6167, 3008, N'', 0, 6012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6168, 3011, N'', 0, 6012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6169, 1019, N'', 0, 6012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6170, 1040, N'', 0, 6012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6171, 3010, N'', 0, 6013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6172, 3008, N'10', 0, 6013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6173, 3011, N'', 0, 6013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6174, 1019, N'1008', 0, 6013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6175, 1040, N'', 0, 6013)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6176, 3010, N'', 0, 6014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6177, 3008, N'', 0, 6014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6178, 3011, N'', 0, 6014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6179, 1019, N'', 0, 6014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6180, 1040, N'', 0, 6014)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6181, 3010, N'', 0, 6015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6182, 3008, N'', 0, 6015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6183, 3011, N'', 0, 6015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6184, 1019, N'', 0, 6015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6185, 1040, N'', 0, 6015)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6186, 3010, N'', 0, 6016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6187, 3008, N'', 0, 6016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6188, 3011, N'', 0, 6016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6189, 1019, N'', 0, 6016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6190, 1040, N'', 0, 6016)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6191, 3010, N'', 0, 6017)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6192, 3008, N'', 0, 6017)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6193, 3011, N'', 0, 6017)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6194, 1019, N'', 0, 6017)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6195, 1040, N'', 0, 6017)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6196, 3010, N'', 0, 6018)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6197, 3008, N'', 0, 6018)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6198, 3011, N'', 0, 6018)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6199, 1019, N'', 0, 6018)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6200, 1040, N'', 0, 6018)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6201, 3010, N'', 0, 6019)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6202, 3008, N'', 0, 6019)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6203, 3011, N'', 0, 6019)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6204, 1019, N'', 0, 6019)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6205, 1040, N'', 0, 6019)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6206, 3010, N'', 0, 6020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6207, 3008, N'', 0, 6020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6208, 3011, N'', 0, 6020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6209, 1019, N'', 0, 6020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6210, 1040, N'', 0, 6020)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6211, 3010, N'', 0, 6021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6212, 3008, N'10', 0, 6021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6213, 3011, N'', 0, 6021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6214, 1019, N'1008', 0, 6021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (6215, 1040, N'', 0, 6021)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7161, 3010, N'', 0, 7011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7162, 3008, N'10', 0, 7011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7163, 3011, N'', 0, 7011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7164, 1019, N'1008', 0, 7011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7165, 1040, N'', 0, 7011)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7166, 3010, N'8254545574', 0, 7012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7167, 3008, N'10', 0, 7012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7168, 3011, N'sfsddsf', 0, 7012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7169, 1019, N'1008', 0, 7012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7170, 1040, N'', 0, 7012)
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId]) VALUES (7171, 1044, N'false', 0, 7012)
SET IDENTITY_INSERT [dbo].[UiPageData] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 

INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3, 25, 0, N'ProgressStatus', 0, 1, 1012, N'progress1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (4, 29, 0, N'Laboratory Details', 0, 1, 1017, N'lab1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (5, 29, 0, N' Discipline Details', 0, 1, 1017, N'disc1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (6, 29, 0, N'Scope Of Accreditation', 0, 1, 1017, N'disc2')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (7, 29, 0, N'Organization', 0, 1, 1017, N'org1')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (8, 29, 0, N'Equipment', 0, 1, 1017, N'equi1')
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
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (20, 1, 1, N'Mobile Number', 0, 2, 3, N'mobi34')
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
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (35, 1, 0, N'Text Box', 0, 2, 3, N'hrty')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (36, 1, 1, N'Text Box 1', 0, 2, 3, N'wsrt')
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
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3008, 2034, 0, N'Workflow', 0, 1, 2008, N'wrkff')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3009, 1, 0, N'User Table', 0, 2, 3, N'Raj')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3010, 1, 0, N'TableName', 0, 2, 3, N'uyhfg')
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3011, 1, 0, N'ThirdPageName', 0, 3, 3, N'jh')
SET IDENTITY_INSERT [dbo].[UiPageMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics] ON 

INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (1, 1019, 1005, 0)
SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics] OFF
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
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (10, N'CubeTestingWorkflow', N'/Common/Create/1', 1003, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (11, N'WaterTestingWorkflow', N'/Common/Create/{0}', 1003, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (12, N'Page1', N'/Common/Index/1', 1003, 0)
INSERT [dbo].[UiPageType] ([Id], [Name], [Url], [UiNavigationCategoryId], [IsDeleted]) VALUES (13, N'Page2', N'/Common/Create/1', 1003, 0)
SET IDENTITY_INSERT [dbo].[UiPageType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] ON 

INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (2, 8, 12, 4, 1)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (3, 10, 3008, 7, 1)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (4, 10, 3008, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (5, 10, 3010, 7, 0)
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (6, 10, 3011, 7, 0)
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
SET IDENTITY_INSERT [dbo].[Workflow] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkflowStage] ON 

INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (2, N'Sample Receiving', 0, 1, 10, 1)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (3, N'Test Plan', 0, 1, 12, 2)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (4, N'Lab Analysis', 0, 1, 13, 4)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (5, N'Test Report', 0, 1, 10, 3)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (6, N'Sample Received', 0, 2, 11, 1)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (7, N'Test Jobs', 0, 2, 11, 2)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (8, N'Report Generation', 0, 2, 11, 3)
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (9, N'Billing & Payments', 0, 2, 11, 4)
SET IDENTITY_INSERT [dbo].[WorkflowStage] OFF
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
ALTER TABLE [dbo].[UiPageMetadata]  WITH CHECK ADD  CONSTRAINT [FK_UiPageMetadata_UiControlType_Id] FOREIGN KEY([UiControlTypeId])
REFERENCES [dbo].[UiControlType] ([id])
GO
ALTER TABLE [dbo].[UiPageMetadata] CHECK CONSTRAINT [FK_UiPageMetadata_UiControlType_Id]
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
ALTER DATABASE [V2Workflow] SET  READ_WRITE 
GO
