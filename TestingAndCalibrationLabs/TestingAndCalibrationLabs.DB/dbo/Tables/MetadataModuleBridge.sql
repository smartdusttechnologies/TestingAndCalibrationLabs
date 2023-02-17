CREATE TABLE [dbo].[MetadataModuleBridge] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId]     INT          NOT NULL,
    [UiPageTypeId]         INT          NOT NULL,
    [IsDeleted]            BIT          CONSTRAINT [DF_MetadataModuleBridge_IsDeleted] DEFAULT ((0)) NOT NULL,
    [ModuleId]             INT          NULL,
    [ParentId]             INT          NULL,
    [Orders]               INT          NULL,
    [UiControlDisplayName] VARCHAR (50) NULL,
    [MultiValueControl]    BIT          CONSTRAINT [DF_MetadataModuleBridge_MultiValueControl] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_MetadataModuleBridge] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MetadataModuleBridge_UiPageMetadata] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_MetadataModuleBridge_UiPageType_Id] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id])
);



