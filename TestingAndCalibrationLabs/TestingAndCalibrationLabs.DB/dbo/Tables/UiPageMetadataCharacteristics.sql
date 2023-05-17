CREATE TABLE [dbo].[UiPageMetadataCharacteristics] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [UiPageMetadataId]                 INT NOT NULL,
    [LookupId]               INT           NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_UiPageMetadataCharacteristics_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageMetadataCharacteristics] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageMetadataCharacteristics_UiPageMetadata_Id] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_UiPageMetadataCharacteristics_Lookup_Id] FOREIGN KEY ([LookupId]) REFERENCES [dbo].[Lookup] ([Id])
);


