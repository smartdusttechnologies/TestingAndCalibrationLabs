CREATE TABLE [dbo].[TestingCategoryLookup]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[ParentId]  BIGINT  NULL,
	[Position] [int] NOT NULL,
	[Descrpition] [varchar] (1000)  NULL,
	[Icon] [varchar] (1000)  NULL,
	[IsDeleted] [bit] CONSTRAINT [D_TestingCategoryLookup_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_TestingCategoryLookup] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_TestingCategoryLookup] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[TestingCategoryLookup] ([Id])
);