CREATE TABLE [dbo].[UiPageMetadata] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [UiPageTypeId]            INT           NOT NULL,
    [UiControlTypeId]         INT           NOT NULL,
    [IsRequired]              BIT           NOT NULL,
    [UiControlDisplayName]    VARCHAR (100) NOT NULL,
    [IsDeleted]               BIT           CONSTRAINT [DF_UiPageMetadata_IsDeleted] DEFAULT ((0)) NOT NULL,
    [DataTypeId]              BIGINT        NOT NULL,
    [ParentId]                INT           NULL,
    [UiControlCategoryTypeId] INT           NULL,
    CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageMetadata_DataType_Id] FOREIGN KEY ([DataTypeId]) REFERENCES [dbo].[DataType] ([Id]),
    CONSTRAINT [FK_UiPageMetadata_UiControlCategoryType] FOREIGN KEY ([UiControlCategoryTypeId]) REFERENCES [dbo].[UiControlCategoryType] ([Id]),
    CONSTRAINT [FK_UiPageMetadata_UiControlType_Id] FOREIGN KEY ([UiControlTypeId]) REFERENCES [dbo].[UiControlType] ([id])
);







