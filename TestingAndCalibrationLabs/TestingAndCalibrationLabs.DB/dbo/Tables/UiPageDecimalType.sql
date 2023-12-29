CREATE TABLE [dbo].[UiPageDecimalType] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Value]            DECIMAL (18) NULL,
    [UiPageMetadataId] INT          NULL,
    [RecordId]         INT          NULL,
    [IsDeleted] BIT CONSTRAINT [DF_UiPageDecimalType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [SubRecordId]      INT           NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RecordId]) REFERENCES [dbo].[UiPageData] ([Id]),
    FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageData] ([Id])
);

