CREATE TABLE [dbo].[SampleTable]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_SampleTable_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED ([Id])
)
