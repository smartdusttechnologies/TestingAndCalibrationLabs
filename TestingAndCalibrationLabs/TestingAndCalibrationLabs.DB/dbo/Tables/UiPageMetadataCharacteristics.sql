CREATE TABLE [dbo].[UiPageMetadataCharacteristics] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId] INT NOT NULL,
    [LookupCategoryId] INT NOT NULL,
    [IsDeleted]        BIT CONSTRAINT [DF_UiPageMetadataCharacteristics_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageMetadataCharacteristics] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageMetadataCharacteristics_LookupCategory_Id] FOREIGN KEY ([LookupCategoryId]) REFERENCES [dbo].[LookupCategory] ([Id]),
    CONSTRAINT [FK_UiPageMetadataCharacteristics_UiPageMetadata_Id] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id])
);




