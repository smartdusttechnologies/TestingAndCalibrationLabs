CREATE TABLE [dbo].[UiPageData] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId] INT           NOT NULL,
    [Value]            VARCHAR (500) NULL,
    [IsDeleted]        BIT           CONSTRAINT [DF_UiPageData_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RecordId]         INT           NOT NULL,
    [UiPageTypeId]     INT           NULL,
    [SubRecordId]      INT           NULL,
    CONSTRAINT [PK_UiPageData] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageData_Record] FOREIGN KEY ([RecordId]) REFERENCES [dbo].[Record] ([Id]),
    CONSTRAINT [FK_UiPageData_UiPageMetadata_Id] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_UiPageData_UiPageType] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id])
);









