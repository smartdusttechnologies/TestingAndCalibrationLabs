CREATE TABLE [dbo].[UiPageData] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId] INT           NOT NULL,
    [Value]            VARCHAR (500) NOT NULL,
    [UiPageId]         INT           NOT NULL,
    [IsDeleted]        BIT           CONSTRAINT [DF_UiPageData_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecordId]         INT           NOT NULL,
    CONSTRAINT [PK_UiPageData] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageData_Record_RecordId] FOREIGN KEY ([RecordId]) REFERENCES [dbo].[Record] ([Id]),
    CONSTRAINT [FK_UiPageData_UiPageMetadata_Id] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_UiPageData_UiPageType_UiPageId] FOREIGN KEY ([UiPageId]) REFERENCES [dbo].[UiPageType] ([Id])
);



