CREATE TABLE [dbo].[UiPageStringType] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId] INT           NULL,
    [Value]            VARCHAR (200) NULL,
    [UiPageDataId]     INT           NULL,
    [RecordId]         INT           NULL,
    [SubRecordId]      INT           NULL,
    [IsDeleted] BIT CONSTRAINT [DF_UiPageStringType_IsDeleted] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RecordId]) REFERENCES [dbo].[Record] ([Id]),
    FOREIGN KEY ([UiPageDataId]) REFERENCES [dbo].[UiPageData] ([Id]),
    FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id])
);

