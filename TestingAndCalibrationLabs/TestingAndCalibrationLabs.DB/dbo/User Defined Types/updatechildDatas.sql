CREATE TYPE [dbo].[updatechildDatas] AS TABLE(
	[Id] [int] NULL,
	[UiPageMetadataId] [int] NULL,
	[ChildId] [int] NULL,
	[RecordId] [int] NULL,
	[UiPageTypeId] [int] NULL,
	[Value] [varchar](200) NULL,
	[SubRecordId] [int] NULL
)
