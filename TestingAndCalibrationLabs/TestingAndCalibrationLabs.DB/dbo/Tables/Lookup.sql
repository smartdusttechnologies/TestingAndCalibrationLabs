CREATE TABLE [dbo].[Lookup] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (100) NULL,
    [LookupCategoryId] INT           NOT NULL,
    [IsDeleted]        BIT           CONSTRAINT [DF_Lookup_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lookup_LookupCategory_Id] FOREIGN KEY ([LookupCategoryId]) REFERENCES [dbo].[LookupCategory] ([Id])
);

