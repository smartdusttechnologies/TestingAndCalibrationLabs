CREATE TABLE [dbo].[UiPageMetadata] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [UiPageId]             INT           NOT NULL,
    [UiControlTypeId]      INT           NULL,
    [IsRequired]           BIT           NOT NULL,
    [UiControlDisplayName] VARCHAR (100) NOT NULL,
    [IsDeleted]            BIT           CONSTRAINT [DF_UiPageMetadata_IsDeleted] DEFAULT ((0)) NOT NULL,
    [DataType]             VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED ([Id] ASC)
);



