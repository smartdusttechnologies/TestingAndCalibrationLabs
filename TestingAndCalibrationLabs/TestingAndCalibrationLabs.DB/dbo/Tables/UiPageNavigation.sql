CREATE TABLE [dbo].[UiPageNavigation] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [Url]                    VARCHAR (100) NOT NULL,
    [ModuleId]               INT           NOT NULL,
    [UiNavigationCategoryId] INT           NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_UiPageNavigation_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IconName] VARCHAR(50) NULL, 
    CONSTRAINT [PK_UiPageNavigation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageNavigation_Module_Id] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Module] ([Id]),
    CONSTRAINT [FK_UiPageNavigation_UiNavigationCategory_Id] FOREIGN KEY ([UiNavigationCategoryId]) REFERENCES [dbo].[UiNavigationCategory] ([Id])
);




