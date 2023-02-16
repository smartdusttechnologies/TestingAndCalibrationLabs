USE [master]
GO
/****** Object:  Database [WorkflowBranch]    Script Date: 2/16/2023 8:00:13 PM ******/
CREATE DATABASE [WorkflowBranch]
 CONTAINMENT = NONE
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
EXEC sys.sp_db_vardecimal_storage_format N'WorkflowBranch', N'ON'
GO
ALTER DATABASE [WorkflowBranch] SET QUERY_STORE = OFF
GO
USE [WorkflowBranch]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityMetadata]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginLog]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginToken]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginTokenLog]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupCategory]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetadataModuleBridge]    Script Date: 2/16/2023 8:00:13 PM ******/
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
	[MultiValueControl] [bit] NULL,
 CONSTRAINT [PK_MetadataModuleBridge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordLogin]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordPolicy]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionModuleType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Record]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SampleTable]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestReport]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiControlCategoryType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiControlType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiNavigationCategory]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageData]    Script Date: 2/16/2023 8:00:13 PM ******/
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
	[UiPageTypeId] [int] NULL,
	[SubRecordId] [int] NULL,
 CONSTRAINT [PK_UiPageData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadata]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageMetadataCharacteristics]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageNavigation]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageValidation]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageValidationType]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleClaim]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workflow]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkflowActivity]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkflowStage]    Script Date: 2/16/2023 8:00:13 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 
GO
INSERT [dbo].[Activity] ([Id], [Name], [IsDeleted]) VALUES (1, N'EmailServices', 0)
GO
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
SET IDENTITY_INSERT [dbo].[ActivityMetadata] ON 
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (1, N'**Email**', 1, 21, 0, NULL, 1016, 2)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (2, N'**Subject**', 1, 35, 0, N'Sample Recived Successfully ??', 1015, 2)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (3, N'HtmlMsg', 1, 36, 0, N'emailformat/SampleRecived.txt', 1015, 2)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (4, N'Name', 1, 3021, 0, NULL, 1016, 2)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (5, N'Email', 1, 21, 0, NULL, 1015, 4)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (7, N'HtmlMsg', 1, 36, 0, N'emailformat/LabAnalysis.txt', 1015, 4)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (9, N'Subject', 1, 35, 0, N'Report Is Ready For Your Review', 1015, 4)
GO
INSERT [dbo].[ActivityMetadata] ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId]) VALUES (12, N'**name**', 1, 3021, 0, N'Rishi Kumar', 1015, 4)
GO
SET IDENTITY_INSERT [dbo].[ActivityMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[Application] ON 
GO
INSERT [dbo].[Application] ([Id], [Name], [Description], [IsDeleted]) VALUES (1, N'Laboratory Management Application', N'Laboratory Management Application', 0)
GO
SET IDENTITY_INSERT [dbo].[Application] OFF
GO
SET IDENTITY_INSERT [dbo].[DataType] ON 
GO
INSERT [dbo].[DataType] ([Id], [Name], [IsDeleted]) VALUES (1, N'int', 0)
GO
INSERT [dbo].[DataType] ([Id], [Name], [IsDeleted]) VALUES (2, N'string', 0)
GO
INSERT [dbo].[DataType] ([Id], [Name], [IsDeleted]) VALUES (3, N'bit', 0)
GO
SET IDENTITY_INSERT [dbo].[DataType] OFF
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (8, N'DataControl', 4, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (9, N'NonDataControl', 4, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (10, N'SubLevel1Control', 4, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1008, N'Indea', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1009, N'Pakistan', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1010, N'England', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1011, N'USA', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1012, N'Bangladesh', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1013, N'New Zealand', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1014, N'Paris', 1005, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1015, N'Static', 1006, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1016, N'Dynamic', 1006, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1020, N'_testReport.html', 1007, 0)
GO
INSERT [dbo].[Lookup] ([Id], [Name], [LookupCategoryId], [IsDeleted]) VALUES (1021, N'_payment.html', 1008, 0)
GO
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[LookupCategory] ON 
GO
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (4, N'UIControlCategory', 0)
GO
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1004, N'Null', 0)
GO
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1005, N'Country', 0)
GO
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1006, N'ActitvityMetadataType', 0)
GO
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1007, N'TestReport', 0)
GO
INSERT [dbo].[LookupCategory] ([Id], [Name], [IsDeleted]) VALUES (1008, N'Payment', 0)
GO
SET IDENTITY_INSERT [dbo].[LookupCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[MetadataModuleBridge] ON 
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3011, 3012, 14, 0, 3, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3012, 3013, 14, 0, 3, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3013, 3014, 14, 0, 3, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3014, 21, 14, 0, 3, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3015, 20, 14, 0, 3, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3016, 17, 14, 0, 3, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3017, 3016, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3018, 3017, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3019, 3018, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3020, 3019, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3021, 3020, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3022, 3021, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3023, 21, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3024, 20, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3025, 3024, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3026, 3025, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3029, 3026, 15, 0, 1, 4, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3030, 3027, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3031, 3028, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3032, 3029, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3033, 3030, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3034, 3031, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3035, 3032, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3037, 3034, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3038, 3035, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3039, 3036, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3040, 3019, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3041, 3037, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3042, 3038, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3043, 3039, 16, 0, 1, 5, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3044, 3008, 15, 0, 1, 4, 1, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3045, 3008, 16, 0, 1, 5, 2, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3046, 2002, 17, 0, 1, 0, 1, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3047, 3, 15, 0, 1, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3048, 4, 15, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3049, 5, 15, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3050, 6, 15, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3051, 7, 15, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3052, 8, 15, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3053, 3, 16, 0, 1, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3054, 4, 16, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3055, 5, 16, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3056, 6, 16, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3057, 7, 16, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3058, 8, 16, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3059, 3, 17, 0, 1, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3060, 4, 17, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3061, 5, 17, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3062, 6, 17, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3063, 7, 17, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3064, 8, 17, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3065, 3040, 17, 0, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3066, 3041, 17, 0, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3067, 3043, 17, 0, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3068, 3044, 17, 0, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3069, 3045, 17, 1, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3070, 3046, 17, 1, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3071, 3047, 17, 0, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3072, 3048, 17, 0, 1, 6, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3073, 3049, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3074, 3050, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3075, 3051, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3077, 3053, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3078, 3054, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3080, 3056, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3081, 3057, 18, 0, 1, 6, 0, NULL, 1)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3082, 3008, 17, 0, 1, 6, 1, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3083, 3, 18, 0, 1, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3084, 4, 18, 0, 1, 3, 0, N'Sample Reciving', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3085, 5, 18, 0, 1, 3, 0, N'Test Plan', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3086, 6, 18, 0, 1, 3, 0, N'Lab Analysis', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3087, 7, 18, 0, 1, 3, 0, N'Test Report', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3088, 8, 18, 0, 1, 3, 0, N'Payment & Billing', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3089, 3058, 18, 0, 1, 7, 19, N'Download', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3090, 3016, 18, 0, 1, 7, 1, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3091, 3017, 18, 0, 1, 7, 2, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3092, 3018, 18, 0, 1, 7, 3, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3093, 3019, 18, 0, 1, 7, 4, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3094, 3020, 18, 0, 1, 7, 5, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3095, 3021, 18, 0, 1, 7, 6, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3096, 21, 18, 0, 1, 7, 7, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3097, 20, 18, 0, 1, 7, 8, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3098, 3024, 18, 0, 1, 7, 9, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3099, 3025, 18, 0, 1, 7, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3100, 3, 19, 0, 1, 0, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3101, 4, 19, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3102, 5, 19, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3103, 6, 19, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3104, 7, 19, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3105, 8, 19, 0, 1, 3, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3106, 3059, 19, 0, 1, 8, 0, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3107, 3060, 19, 0, 1, 8, 1, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3108, 3061, 19, 0, 1, 8, 2, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3110, 3062, 19, 0, 1, 8, 3, N'Download Report', 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3111, 3008, 19, 0, 1, 8, 3, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3112, 3008, 18, 0, 1, 7, 16, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3113, 3040, 18, 0, 1, 7, 10, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3114, 3041, 18, 0, 1, 7, 11, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3116, 3043, 18, 0, 1, 7, 12, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3117, 3044, 18, 0, 1, 7, 13, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3118, 3045, 18, 0, 1, 7, 14, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3119, 3046, 18, 0, 1, 7, 15, NULL, 0)
GO
INSERT [dbo].[MetadataModuleBridge] ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl]) VALUES (3120, 3063, 18, 0, 1, 7, 17, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[MetadataModuleBridge] OFF
GO
SET IDENTITY_INSERT [dbo].[Module] ON 
GO
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (0, N'none', 1, 0)
GO
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (1, N'Cube Testing', 1, 0)
GO
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (2, N'Water Testing', 1, 0)
GO
INSERT [dbo].[Module] ([Id], [Name], [ApplicationId], [IsDeleted]) VALUES (3, N'Customer', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Module] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 
GO
INSERT [dbo].[Organization] ([Id], [OrgCode], [OrgName], [IsDeleted]) VALUES (0, N'SYSORG', N'SYSORG', 0)
GO
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
SET IDENTITY_INSERT [dbo].[PasswordLogin] ON 
GO
INSERT [dbo].[PasswordLogin] ([Id], [PasswordHash], [PasswordSalt], [UserId], [ChangeDate]) VALUES (0, N'qnVDMZYlsGjs4chNs1/qPidI70eDUZ1fzUF5EdCqdl0=', N'NDlzcm0GY1GqMgn+urXX9Q==', 0, CAST(N'2022-11-12T14:25:35.763' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PasswordLogin] OFF
GO
SET IDENTITY_INSERT [dbo].[PasswordPolicy] ON 
GO
INSERT [dbo].[PasswordPolicy] ([Id], [MinCaps], [MinSmallChars], [MinSpecialChars], [MinNumber], [MinLength], [AllowUserName], [DisAllPastPassword], [DisAllowedChars], [ChangeIntervalDays], [OrgId], [IsDeleted]) VALUES (0, 1, 1, 1, 1, 8, 1, 0, NULL, 30, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[PasswordPolicy] OFF
GO
SET IDENTITY_INSERT [dbo].[Record] ON 
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11049, 1, 1, 5, CAST(N'2023-02-11T22:39:28.757' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11050, 0, 1, 5, CAST(N'2023-02-11T23:02:19.293' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11051, 1, 1, 4, CAST(N'2023-02-11T23:35:34.797' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11052, 0, 1, 5, CAST(N'2023-02-13T00:17:01.743' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11055, 1, 1, 2, CAST(N'2023-02-13T23:47:48.307' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11056, 1, 1, 0, NULL)
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11057, 1, 1, 5, CAST(N'2023-02-14T00:00:21.707' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11058, 1, 1, 0, NULL)
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11059, 1, 1, 0, NULL)
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11060, 1, 1, 0, NULL)
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11061, 1, 1, 0, NULL)
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11062, 1, 1, 5, CAST(N'2023-02-14T12:52:01.740' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (11063, 0, 1, 5, CAST(N'2023-02-16T15:32:20.410' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (12059, 1, 1, 4, CAST(N'2023-02-16T19:46:30.893' AS DateTime))
GO
INSERT [dbo].[Record] ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate]) VALUES (12060, 0, 1, 5, CAST(N'2023-02-16T19:47:15.720' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Record] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (0, N'Sysadmin', 0, 0)
GO
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (1, N'Admin', 1, 0)
GO
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (2, N'ApplicationAdmin', 2, 0)
GO
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (3, N'Manager', 3, 0)
GO
INSERT [dbo].[Role] ([Id], [Name], [Level], [IsDeleted]) VALUES (4, N'GeneralUser', 6, 0)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[TestReport] ON 
GO
INSERT [dbo].[TestReport] ([Id], [Client], [Filepath], [Email], [JobId], [Name], [DateTime], [IsDeleted]) VALUES (1, N'dfg', N'1VkPUk0WjPRj6rCulYq_9xU9FeCGFm1oa', N'jg@gh.hvbv', N'dgdfg', N'dfg', CAST(N'2022-11-14T00:00:00.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[TestReport] OFF
GO
SET IDENTITY_INSERT [dbo].[UiControlCategoryType] ON 
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1, N'Grid', N'~/Views/Common/Components/Grid/_gridTemplate1.cshtml', 0, 33)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2, N'Grid Classic', N'~/Views/Common/Components/Grid/_gridTemplate2.cshtml', 0, 33)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (3, N'Text', N'~/Views/Common/Components/Text/_text.cshtml', 0, 1)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (5, N'Text Large', N'~/Views/Common/Components/Text/_text1.cshtml', 0, 1)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1003, N'Checkbox', N'~/Views/Common/Components/Checkbox/_checkbox.cshtml', 0, 3)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1004, N'Radio', N'~/Views/Common/Components/Radio/_radio.cshtml', 0, 4)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1005, N'Submit', N'~/Views/Common/Components/Submit/_submit.cshtml', 0, 6)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1006, N'Email', N'~/Views/Common/Components/Email/_email.cshtml', 0, 10)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1007, N'Mobile Number', N'~/Views/Common/Components/Mobile/_mobileNumber.cshtml', 0, 12)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1009, N'Time', N'~/Views/Common/Components/Date/_time.cshtml', 0, 14)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1010, N'URL', N'~/Views/Common/Components/Url/_url.cshtml', 0, 15)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1011, N'Date Time', N'~/Views/Common/Components/DateTime/_datetime-local.cshtml', 0, 22)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1012, N'Progress Bar', N'~/Views/Common/Components/ProgressStatus/_progressStatusWithWorklofw.cshtml', 0, 25)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1013, N'Tabs', N'~/Views/Common/Components/Tabs/_tabs.cshtml', 0, 28)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1014, N'Collapsable Section', N'~/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml', 0, 30)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1015, N'Dropdown', N'~/Views/Common/Components/Dropdown/_dropdown.cshtml', 0, 32)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1016, N'Pincode', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 34)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1017, N'Null', N'Null', 0, 29)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (1020, N'Textarea', N'~/Views/Common/Components/Textarea/_textarea.cshtml', 0, 8)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2004, N'File', N'~/Views/Common/Components/File/_file.cshtml', 0, 5)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2006, N'Year', N'~/Views/Common/Components/DateTime/_year.cshtml', 0, 35)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2007, N'Checkbox', N'~/Views/Common/Components/Question/_checkbox.cshtml', 0, 36)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2008, N'WorkflowStage', N'~/Views/Common/Components/WorkflowStage/_workflowStage.cshtml', 0, 37)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2010, N'Download', N'~/Views/Common/Components/Download/_download.cshtml', 0, 38)
GO
INSERT [dbo].[UiControlCategoryType] ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId]) VALUES (2011, N'MultiControlGrid', N'~/Views/Common/Components/Grid/_gridMultiControl.cshtml', 0, 33)
GO
SET IDENTITY_INSERT [dbo].[UiControlCategoryType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiControlType] ON 
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (1, N'text', N'User Name', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (2, N'password', N'Password', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (3, N'checkbox', N'Checkbox', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (4, N'radio', N'Radio', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (5, N'file', N'File', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (6, N'submit', N'Submit', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (7, N'button', N'Button', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (8, N'textarea', N'Textarea', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (9, N'date', N'Date', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (10, N'email', N'Email', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (11, N'image', N'Image', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (12, N'number', N'Number', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (13, N'tel', N'Telephone', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (14, N'time', N'Time', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (15, N'url', N'Url', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (16, N'reset', N'Reset', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (17, N'week', N'Week', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (18, N'search', N'Search', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (19, N'range', N'Range', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (20, N'month', N'Month', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (21, N'hidden', N'Hidden', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (22, N'datetime-local', N'Datetime-local', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (23, N'color', N'Color', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (24, N'card', N'Card', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (25, N'processStatus', N'Default Process Status', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (26, N'subLevel1ProcessStatus', N'Sub Leve 1 Process status', 0, 10)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (28, N'tabs', N'Default Tabs', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (29, N'subLevel1Tabs', N'Sub Level 1 Tabs', 0, 10)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (30, N'collapsableSection', N'Default Collapsable Section', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (31, N'subLevel1CollapsableSection', N'Sub Level 1 Collapsable Section', 0, 10)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (32, N'dropdown', N'Dropdown', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (33, N'grid', N'Grid', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (34, N'pincode', N'Pincode', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (35, N'year', N'Year', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (36, N'question', N'Question - Checkbox', 0, 9)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (37, N'workflowStage', N'Workflow Stage', 0, 8)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId]) VALUES (38, N'Download', N'ReportTemplate', 0, 9)
GO
SET IDENTITY_INSERT [dbo].[UiControlType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiNavigationCategory] ON 
GO
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1, N'Survey', 2, 0)
GO
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (2, N'Home', 1, 0)
GO
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1002, N'Settings', 3, 0)
GO
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1003, N'Profile', 4, 0)
GO
INSERT [dbo].[UiNavigationCategory] ([Id], [Name], [Orders], [IsDeleted]) VALUES (1004, N'Notifications', 5, 0)
GO
SET IDENTITY_INSERT [dbo].[UiNavigationCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageData] ON 
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13054, 3016, N'sdf', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13055, 3017, N'gsdfg', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13056, 3018, N'sdfg', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13057, 3019, N'2023-02-16', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13058, 3020, N'sdg', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13059, 3021, N'sdg', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13060, 21, N'', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13061, 20, N'', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13062, 3024, N'', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13063, 3025, N'', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13064, 3026, N'', 0, 12059, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13065, 3008, N'4', 0, 12059, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13066, 3027, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13067, 3028, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13068, 3029, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13069, 3030, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13070, 3031, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13071, 3032, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13072, 3034, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13073, 3035, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13074, 3036, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13075, 3037, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13076, 3038, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13077, 3039, N'', 0, 12059, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13078, 3040, N'', 0, 12059, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13079, 3041, N'd', 0, 12059, 17, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13080, 3043, N'', 0, 12059, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13081, 3044, N'', 0, 12059, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13082, 3045, N'sd', 0, 12059, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13083, 3046, N'sdf', 0, 12059, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13084, 3049, N'22500', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13085, 3050, N'3375', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13086, 3051, N'7937', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13087, 3053, N'2.352', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13088, 3054, N'259.74', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13089, 3056, N'11.54', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13090, 3057, N'11.5', 0, 12059, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13091, 3047, N'', 0, 12059, 17, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13092, 3048, N'', 0, 12059, 17, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13093, 3049, N'225003', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13094, 3050, N'33755', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13095, 3051, N'79373', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13096, 3053, N'2.35242', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13097, 3054, N'259.744', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13098, 3056, N'11.546', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13099, 3057, N'11.5d', 0, 12059, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13100, 3016, N'jkg', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13101, 3017, N'ukjryr', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13102, 3018, N'yhgktu', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13103, 3019, N'2023-02-22', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13104, 3020, N'jhtk', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13105, 3021, N'', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13106, 21, N'', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13107, 20, N'', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13108, 3024, N'', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13109, 3025, N'', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13110, 3026, N'', 0, 12060, 15, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13111, 3008, N'5', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13112, 3059, N'123', 0, 12059, 19, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13113, 3060, N'123', 0, 12059, 19, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13114, 3061, N'246', 0, 12059, 19, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13115, 3049, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13116, 3050, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13117, 3051, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13118, 3053, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13119, 3054, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13120, 3056, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13121, 3057, N'', 1, 12059, 18, 3)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13122, 3027, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13123, 3028, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13124, 3029, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13125, 3030, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13126, 3031, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13127, 3032, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13128, 3034, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13129, 3035, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13130, 3036, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13131, 3037, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13132, 3038, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13133, 3039, N'', 0, 12060, 16, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13134, 3040, N'', 0, 12060, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13135, 3041, N'', 0, 12060, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13136, 3043, N'', 0, 12060, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13137, 3044, N'', 0, 12060, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13138, 3045, N'345', 0, 12060, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13139, 3046, N'34534', 0, 12060, 18, NULL)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13140, 3049, N'234', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13141, 3050, N'5324', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13142, 3051, N'534', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13143, 3053, N'5234', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13144, 3054, N'5234', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13145, 3056, N'5235', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13146, 3057, N'235', 0, 12060, 18, 1)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13147, 3049, N'23', 0, 12060, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13148, 3050, N'4523', 0, 12060, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13149, 3051, N'5432', 0, 12060, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13150, 3053, N'523', 0, 12060, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13151, 3054, N'53', 0, 12060, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13152, 3056, N'253', 0, 12060, 18, 2)
GO
INSERT [dbo].[UiPageData] ([Id], [UiPageMetadataId], [Value], [IsDeleted], [RecordId], [UiPageTypeId], [SubRecordId]) VALUES (13153, 3057, N'245325', 0, 12060, 18, 2)
GO
SET IDENTITY_INSERT [dbo].[UiPageData] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3, 25, 0, N'ProgressStatus', 0, 1, 1012, N'progress1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (4, 29, 0, N'Sample Recieving', 0, 1, 1017, N'lab1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (5, 29, 0, N'Test Plan', 0, 1, 1017, N'disc1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (6, 29, 0, N'Lab Analysis', 0, 1, 1017, N'disc2')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (7, 29, 0, N'Test Report', 0, 1, 1017, N'org1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (8, 29, 0, N'Billing & Payment', 0, 1, 1017, N'equi1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (9, 29, 0, N'Reference Materials', 0, 1, 1017, N'refer1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (10, 29, 0, N'Quality Control Activities', 0, 1, 1017, N'qcont1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (11, 29, 0, N'Enclosure List', 0, 1, 1017, N'enc1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (12, 1, 1, N'Name Of The Laboratory', 0, 2, 3, N'nothe1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (13, 1, 1, N'GSTIN', 0, 2, 3, N'gstin1')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (14, 1, 1, N'Contry', 0, 2, 3, N'cont2')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (15, 1, 1, N'State/Provider', 0, 2, 3, N'sttt3')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (16, 1, 1, N'City', 0, 2, 3, N'ct3')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (17, 1, 1, N'Address', 0, 2, 3, N'adgag4')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (18, 1, 1, N'District', 0, 2, 3, N'discr4')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (19, 1032, 0, N'Pincode', 0, 2, 1016, N'pincd5')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (20, 12, 1, N'Mobile Number', 0, 2, 1007, N'mobi34')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (21, 10, 1, N'Email', 0, 2, 1006, N'emuil34')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (22, 1, 0, N'Discipline Of Testing', 0, 2, 3, N'discip6')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (23, 1, 0, N'Group', 0, 2, 3, N'grty5')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (24, 1, 1, N'Location', 0, 2, 3, N'dsg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (25, 1, 1, N'Discipline', 0, 2, 3, N'etr')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (26, 1, 0, N'Group', 0, 2, 3, N'ttyr')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (27, 1, 0, N'Sub-Group', 0, 2, 3, N'rteag')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (28, 8, 0, N'Products/Materials of Test', 0, 2, 1020, N'dgsdsert')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (29, 8, 0, N'Specific tests or types of tests perofmed', 0, 2, 1020, N'vstyers')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (30, 30, 0, N'Collapsable', 0, 1, 1014, N'dasterdsd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (31, 29, 0, N'Organization Structure', 0, 1, 1017, N'hyer')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (32, 29, 0, N'New Employee Details', 0, 1, 1017, N'gdfy')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (33, 1, 1, N'Organization Chart of Laboratory Link', 0, 2, 3, N'dfgd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (34, 1, 0, N'organization chart', 0, 2, 3, N'rtyery')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (35, 1, 0, N'Subject', 0, 2, 3, N'hrty')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (36, 1, 1, N'HtmlMsg', 0, 2, 3, N'wsrt')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1004, 5, 0, N'Image Input', 0, 1, 2004, N'sg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1005, 1, 1, N'Location', 0, 2, 3, N'sergs')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1006, 1, 1, N'Discipline', 0, 2, 3, N'tr5')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1007, 1, 1, N'Group', 0, 2, 3, N'sgsret')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1008, 1, 1, N'Type Of Test', 0, 2, 3, N'regs')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1009, 1, 1, N'UID of Equipment', 0, 2, 3, N'trse')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1010, 1, 1, N'Name Of Equipment', 0, 2, 3, N'gsdg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1011, 1, 0, N'Model', 0, 2, 3, N'uys')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1012, 1, 0, N'Serial No', 0, 2, 3, N'bew')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1013, 1, 1, N'Name Of Manufracturer', 0, 2, 3, N'ma')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1014, 2032, 0, N'Year Of Make', 0, 2, 2006, N'v')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1015, 1, 0, N'Range and Accurecy', 0, 2, 3, N'rtsd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1017, 22, 0, N'Last Calibration Date', 0, 2, 1011, N'uym')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1018, 22, 0, N'Calibration Due on', 0, 2, 1011, N'du v')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1019, 32, 0, N'Location', 0, 2, 1015, N'aser')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1023, 1, 1, N'Discipline', 0, 2, 3, N'bys')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1024, 1, 1, N'Group', 0, 2, 3, N'um')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1025, 1, 1, N'Name of Reference Material/Strain/Culture', 0, 2, 3, N'gbgsn ')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1026, 1, 1, N'Source', 0, 2, 3, N'shb sdfy')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1027, 22, 1, N'Date Of Expiry', 0, 2, 1011, N'dbsghv')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1028, 1, 1, N'Tracability', 0, 2, 3, N'vbs')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1029, 1, 1, N'Location', 0, 2, 3, N'gvtsn s')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1030, 1, 1, N'Type Of Partipatation', 0, 2, 3, N'm,s ij')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1031, 1, 1, N'Discipline', 0, 2, 3, N'v ')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1032, 1, 1, N'Group', 0, 2, 3, N'zym r')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1033, 1, 1, N'Product/Material', 0, 2, 3, N'mn')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1034, 1, 0, N'Details of Test', 0, 2, 3, N'burtm,')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1035, 22, 0, N'Date Of Testing', 0, 2, 1011, N'io')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1036, 1, 1, N'Nodal Laboratory/PT Provider (Accredification Body/Country)', 0, 2, 3, N'rb')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1037, 1, 1, N'Performance in Term of Z Score / Any Other Criteria', 0, 2, 3, N'ta')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1038, 1, 0, N'Corrective Action Taken (if any)', 0, 2, 3, N'byim')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1039, 5, 1, N'Upload Quality Manual', 0, 2, 2004, N'ng')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1040, 4, 1, N'Calibrated By', 0, 1, 1004, N'svbtyio')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1042, 29, 0, N'Inhouse', 0, 1, 1003, N'eryrt')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1043, 29, 0, N'External', 0, 1, 1003, N'ryrtuty')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1044, 3, 0, N'Checkbox-check', 0, 1, 1003, N'esbum')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1045, 29, 0, N'Patna', 1, 1, 1017, N'iduyaer')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1046, 29, 0, N'Lacknow', 1, 1, 1017, N'sgfdsgd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1047, 29, 0, N'Bareliy', 1, 1, 1017, N'sdgsdfg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (1048, 29, 0, N'Karnataka', 1, 1, 1017, N'fgd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (2002, 33, 0, N'Grid', 0, 1, 2, N'lfy')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (2008, 1, 0, N'adfsafds', 0, 2, 3, N'afsdfa')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3006, 1, 0, N'Name', 0, 2, 3, N'UserName')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3007, 1, 0, N'fghfgh', 0, 2, 1010, N'hfhgh')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3008, 37, 0, N'Workflow', 0, 1, 2008, N'wrkff')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3009, 1, 0, N'User Table', 0, 2, 3, N'Raj')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3010, 1, 0, N'TableName', 0, 2, 3, N'uyhfg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3011, 1, 0, N'ThirdPageName', 0, 3, 3, N'jh')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3012, 1, 0, N'Customer Name', 0, 2, 3, N'cu')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3013, 1, 0, N'Contant Person', 0, 2, 3, N'cP')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3014, 1, 0, N'Name', 0, 2, 3, N'name')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3016, 1, 0, N'Job Serial No', 0, 2, 3, N'jsn')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3017, 1, 0, N'Department Name', 0, 2, 3, N'rd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3018, 1, 0, N'Issue To', 0, 2, 3, N'df')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3019, 22, 0, N'Recived On', 0, 3, 1011, N'jklg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3020, 1, 0, N'Job Order No / Ref No', 0, 2, 3, N'sdg')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3021, 1, 0, N'Contact Person Name', 0, 2, 3, N'ds')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3024, 22, 0, N'TestReport Release Date', 0, 3, 1011, N'datee')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3025, 1, 0, N'Any Other Specific Requirment', 0, 2, 3, N'sdsf')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3026, 5, 0, N'Attachments', 0, 3, 2004, N'sfsd')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3027, 1, 0, N'Sample Type', 0, 3, 3, N'dfgf')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3028, 1, 0, N'Sample Details', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3029, 22, 0, N'Date of TP', 0, 2, 1011, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3030, 1, 0, N'Job Code No', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3031, 1, 0, N'Sample ID', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3032, 1, 0, N'Number Of Samples/Quantity', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3034, 1, 0, N'Test Name ', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3035, 1, 0, N'Test Method', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3036, 1, 0, N'Person Authorized', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3037, 22, 0, N'Targeted On', 0, 2, 1011, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3038, 22, 0, N'Completed on', 0, 2, 1011, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3039, 1, 0, N'Remarks', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3040, 22, 0, N'Date Of Report', 0, 3, 1011, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3041, 1, 0, N'Report No', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3043, 1, 0, N'ULR No', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3044, 22, 0, N'Date Of Casting', 0, 2, 1011, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3045, 1, 0, N'Age Of Specimens', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3046, 1, 0, N'Length', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3047, 1, 0, N'Width', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3048, 1, 0, N'Height', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3049, 1, 0, N'mm²', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3050, 1, 0, N'cm³', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3051, 1, 0, N'gm', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3053, 1, 0, N'gm/cm³', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3054, 1, 0, N'Load, KN', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3056, 1, 0, N'Compressive Strength, N/mm²', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3057, 1, 0, N'Average', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3058, 38, 0, N'TestReport', 0, 2, 2010, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3059, 1, 0, N'Price', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3060, 1, 0, N'Tax', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3061, 1, 0, N'Total', 0, 2, 3, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3062, 38, 0, N'Payment', 0, 2, 2010, N'0')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name]) VALUES (3063, 33, 0, N'MultiControlGrid', 0, 2, 2011, N'0')
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics] ON 
GO
INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (1, 1019, 1005, 0)
GO
INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (3, 3058, 1007, 0)
GO
INSERT [dbo].[UiPageMetadataCharacteristics] ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted]) VALUES (4, 3062, 1008, 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageNavigation] ON 
GO
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (1, N'/Common/Index/{0}', 1, 2, 0)
GO
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (2, N'/Common/Index/{0}', 2, 2, 0)
GO
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (3, N'/', 0, 1002, 0)
GO
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (4, N'/', 0, 1003, 0)
GO
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (5, N'/', 0, 1004, 0)
GO
INSERT [dbo].[UiPageNavigation] ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted]) VALUES (1002, N'/Common/Index/{0}', 3, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageNavigation] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageType] ON 
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (1, N'Ui Page Type', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (2, N'Ui Control Type', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (3, N'Ui Page Metadata', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (4, N'Ui Page Validation', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (5, N'Home', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (6, N'My Activity', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (8, N'Nabl', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (10, N'Sample Recieving', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (11, N'Test Plan', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (12, N'Page1', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (13, N'Page2', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (14, N'Customer', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (15, N'Sample Recieving ', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (16, N'Test Plan', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (17, N'Lab Analysis', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (18, N'Test Reports', 0)
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (19, N'Bill & Payment', 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] ON 
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (2, 8, 12, 4, 1)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (3, 10, 3008, 7, 1)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (4, 10, 3008, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (5, 10, 3010, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (6, 15, 3016, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (7, 15, 3017, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (8, 15, 3018, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (9, 15, 3019, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (10, 15, 3020, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (11, 18, 3049, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (12, 18, 3050, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (13, 18, 3056, 7, 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] ON 
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (1, N'MinPasswordLength', N'Minimum Password length  is 8', N'8', 0)
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (2, N'Email', N'Email should have a fromat', N'3', 0)
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (3, N'AdharLength', N'AdharLength should be equal to 12', N'12', 0)
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (4, N'MobileNumberLength', N'Mobile Number length is equal to 10', N'10', 0)
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (5, N'Year', N'Year length is equal to 4', N'4', 0)
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (6, N'Name', N'Name should have more than 3 letters', N'3', 1)
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [Message], [Value], [IsDeleted]) VALUES (7, N'IsRequired', N'{0} Field is rquired', N'', 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserName], [FirstName], [LastName], [Email], [Mobile], [Country], [ISDCode], [TwoFactor], [Locked], [IsActive], [EmailValidationStatus], [MobileValidationStatus], [OrgId], [AdminLevel], [IsDeleted]) VALUES (0, N'sysadmin', N'sysadmin', N'sysadmin', N'sysadmin@gmail.com', N'1234567899', N'INDIA', N'91', 0, 0, 1, 0, 0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 
GO
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [IsDeleted]) VALUES (0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Workflow] ON 
GO
INSERT [dbo].[Workflow] ([Id], [Name], [ModuleId], [IsDeleted]) VALUES (1, N'Cube Testing Flow', 1, 0)
GO
INSERT [dbo].[Workflow] ([Id], [Name], [ModuleId], [IsDeleted]) VALUES (2, N'Water Testing Flow', 2, 0)
GO
INSERT [dbo].[Workflow] ([Id], [Name], [ModuleId], [IsDeleted]) VALUES (3, N'Customer', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Workflow] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkflowActivity] ON 
GO
INSERT [dbo].[WorkflowActivity] ([Id], [Name], [WorkflowStageId], [IsDeleted], [ActivityId]) VALUES (1, N'EmailAc', 2, 0, 1)
GO
INSERT [dbo].[WorkflowActivity] ([Id], [Name], [WorkflowStageId], [IsDeleted], [ActivityId]) VALUES (2, N'EmailFirst', 4, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[WorkflowActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkflowStage] ON 
GO
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (2, N'Sample Receiving', 0, 1, 15, 0)
GO
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (3, N'Test Plan', 0, 1, 16, 1)
GO
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (4, N'Lab Analysis', 0, 1, 17, 2)
GO
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (5, N'Test Report', 0, 1, 18, 3)
GO
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (9, N'Billing & Payments', 0, 1, 19, 4)
GO
INSERT [dbo].[WorkflowStage] ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders]) VALUES (10, N'Customer', 0, 3, 14, 0)
GO
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
ALTER TABLE [dbo].[MetadataModuleBridge] ADD  CONSTRAINT [DF_MetadataModuleBridge_MultiValueControl]  DEFAULT ((0)) FOR [MultiValueControl]
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
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_Record] FOREIGN KEY([RecordId])
REFERENCES [dbo].[Record] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_Record]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_UiPageMetadata_Id] FOREIGN KEY([UiPageMetadataId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_UiPageMetadata_Id]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_UiPageType] FOREIGN KEY([UiPageTypeId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_UiPageType]
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
