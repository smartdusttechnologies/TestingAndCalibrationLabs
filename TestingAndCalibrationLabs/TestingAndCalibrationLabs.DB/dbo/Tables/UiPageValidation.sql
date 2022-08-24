CREATE TABLE [dbo].[UiPageValidation] (
    [Id]                     INT IDENTITY (1, 1) NOT NULL,
    [UiPageTypeId]           INT NOT NULL,
    [UiPageMetadataId]       INT NOT NULL,
    [UiPageValidationTypeId] INT NOT NULL,
    [IsDeleted]              BIT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageValidation_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageValidation_UiPageMetadataId] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_UiPageValidation_UiPageTypeId] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id]),
    CONSTRAINT [FK_UiPageValidation_UiPageValidationTypeId] FOREIGN KEY ([UiPageValidationTypeId]) REFERENCES [dbo].[UiPageValidationType] ([Id])
);









