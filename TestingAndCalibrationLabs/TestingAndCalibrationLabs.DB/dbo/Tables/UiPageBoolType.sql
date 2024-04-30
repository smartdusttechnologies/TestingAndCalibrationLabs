CREATE TABLE [dbo].[UiPageBoolType] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId] INT NULL,
    [Value]            BIT NULL,
    [UiPageDataId]     INT NULL,
    [RecordId]         INT NULL,
    [IsDeleted] BIT CONSTRAINT [DF_UiPageBoolType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [SubRecordId]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RecordId]) REFERENCES [dbo].[Record] ([Id]),
    FOREIGN KEY ([UiPageDataId]) REFERENCES [dbo].[UiPageData] ([Id]),
    FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id])
);

