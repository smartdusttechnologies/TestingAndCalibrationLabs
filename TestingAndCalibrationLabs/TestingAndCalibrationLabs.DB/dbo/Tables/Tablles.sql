USE [TestingAndCalibrationLabs]
GO
/****** Object:  Table [dbo].[Record]    Script Date: 20-07-2022 23:14:02 ******/
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
/****** Object:  Table [dbo].[Sample]    Script Date: 20-07-2022 23:14:02 ******/
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
/****** Object:  Table [dbo].[SampleTable]    Script Date: 20-07-2022 23:14:02 ******/
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
/****** Object:  Table [dbo].[UiControlType]    Script Date: 20-07-2022 23:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiControlType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiControlType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageData]    Script Date: 20-07-2022 23:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiControlId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[UiPageMetadata]    Script Date: 20-07-2022 23:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageId] [int] NOT NULL,
	[UiControlTypeId] [int] NULL,
	[IsRequired] [bit] NOT NULL,
	[UiControlDisplayName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DataType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageType]    Script Date: 20-07-2022 23:14:02 ******/
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
/****** Object:  Table [dbo].[UiPageValidation]    Script Date: 20-07-2022 23:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageValidation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UiPageId] [int] NOT NULL,
	[UiPageMetadataId] [int] NOT NULL,
	[UiPageValidationTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UiPageValidation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UiPageValidationType]    Script Date: 20-07-2022 23:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UiPageValidationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[Message] [varchar](50) NULL,
 CONSTRAINT [PK_UiPageValidationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Record] ADD  CONSTRAINT [DF_Record_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Sample] ADD  CONSTRAINT [DF_Sample_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SampleTable] ADD  CONSTRAINT [D_SampleTable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiControlType] ADD  CONSTRAINT [DF_UiControlType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageData] ADD  CONSTRAINT [DF_UiPageData_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageMetadata] ADD  CONSTRAINT [DF_UiPageMetadata_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageType] ADD  CONSTRAINT [DF_UiPageType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageValidation] ADD  CONSTRAINT [DF_UiPageValidation_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UiPageValidationType] ADD  CONSTRAINT [DF_UiPageValidationType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Record]  WITH CHECK ADD  CONSTRAINT [FK_Record_UiPageType_UiPageId] FOREIGN KEY([UiPageId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[Record] CHECK CONSTRAINT [FK_Record_UiPageType_UiPageId]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_Record_RecordId] FOREIGN KEY([RecordId])
REFERENCES [dbo].[Record] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_Record_RecordId]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_UiPageMetadata_UiControlId] FOREIGN KEY([UiControlId])
REFERENCES [dbo].[UiPageMetadata] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_UiPageMetadata_UiControlId]
GO
ALTER TABLE [dbo].[UiPageData]  WITH CHECK ADD  CONSTRAINT [FK_UiPageData_UiPageType_UiPageId] FOREIGN KEY([UiPageId])
REFERENCES [dbo].[UiPageType] ([Id])
GO
ALTER TABLE [dbo].[UiPageData] CHECK CONSTRAINT [FK_UiPageData_UiPageType_UiPageId]
GO
