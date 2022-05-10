CREATE TABLE [dbo].[TestingCategoryLookup]
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[Name] [varchar](256) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[IsDeleted] [bit] CONSTRAINT [D_TestingCategoryLookup_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_TestingCategoryLookup] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_TestingCategoryLookup] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[TestingCategoryLookup] ([Id])
);