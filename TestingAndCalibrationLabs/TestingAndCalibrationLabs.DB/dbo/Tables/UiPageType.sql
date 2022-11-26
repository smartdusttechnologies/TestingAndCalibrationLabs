CREATE TABLE [dbo].[UiPageType] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [Name]                   VARCHAR (100) NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_UiPageType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



