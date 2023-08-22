CREATE TABLE [dbo].[UiControlCategoryType] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (100) NOT NULL,
    [Template]        VARCHAR (200) NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_UiControlCategoryType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [UiControlTypeId] INT           NULL,
    CONSTRAINT [PK_UiControlCategoryType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiControlCategoryType_UiControlType_Id] FOREIGN KEY ([UiControlTypeId]) REFERENCES [dbo].[UiControlType] ([id])
);

