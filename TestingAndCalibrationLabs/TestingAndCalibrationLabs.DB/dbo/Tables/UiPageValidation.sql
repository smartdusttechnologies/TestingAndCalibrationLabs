CREATE TABLE [dbo].[UiPageValidation] (
    [Id]                     INT NOT NULL,
    [UiPageTypeId]           INT NOT NULL,
    [UiPageMetadataId]       INT NOT NULL,
    [UiPageValidationTypeId] INT NOT NULL,
    [IsDeleted]              BIT CONSTRAINT [DF_UiPageValidation_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageValidation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageValidation_UiPageMetadata_Id] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_UiPageValidation_UiPageType_Id] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id]),
    CONSTRAINT [FK_UiPageValidation_UiPageValidationType_Id] FOREIGN KEY ([UiPageValidationTypeId]) REFERENCES [dbo].[UiPageValidationType] ([Id])
);







