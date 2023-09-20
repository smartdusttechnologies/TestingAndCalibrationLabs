CREATE TABLE [dbo].[UiPageMetadata] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [UiControlTypeId]         INT           NOT NULL,
    [IsRequired]              BIT           NOT NULL,
    [UiControlDisplayName]    VARCHAR (100) NOT NULL,
    [IsDeleted]               BIT           CONSTRAINT [DF_UiPageMetadata_IsDeleted] DEFAULT ((0)) NOT NULL,
    [DataTypeId]              BIGINT        NOT NULL,
    [UiControlCategoryTypeId] INT           NULL,
    [Name]                    VARCHAR (50)  NULL,
     [ModuleLayoutId]          INT           NULL,
    CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageMetadata_DataType_Id] FOREIGN KEY ([DataTypeId]) REFERENCES [dbo].[DataType] ([Id]),
    CONSTRAINT [FK_UiPageMetadata_UiControlCategoryType] FOREIGN KEY ([UiControlCategoryTypeId]) REFERENCES [dbo].[UiControlCategoryType] ([Id])
);









