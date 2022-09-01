CREATE TABLE [dbo].[UiNavigationCategory] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [IsDeleted] BIT          CONSTRAINT [DF_UiNavigationCategory_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiNavigationCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

