CREATE TABLE [dbo].[UiPageNavigation] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [Url]                    VARCHAR (100) NOT NULL,
    [UiPageTypeId]           INT           NOT NULL,
    [UiNavigationCategoryId] INT           NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_UiPageNavigation_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageNavigation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageNavigation_UiNavigationCategory_Id] FOREIGN KEY ([UiNavigationCategoryId]) REFERENCES [dbo].[UiNavigationCategory] ([Id]),
    CONSTRAINT [FK_UiPageNavigation_UiPageType_Id] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id])
);


