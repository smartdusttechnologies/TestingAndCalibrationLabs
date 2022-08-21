﻿CREATE TABLE [dbo].[UiPageMetadata] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [UiPageTypeId]         INT           NOT NULL,
    [UiControlTypeId]      INT           NULL,
    [IsRequired]           BIT           NOT NULL,
    [UiControlDisplayName] VARCHAR (100) NOT NULL,
    [IsDeleted]            BIT           CONSTRAINT [DF_UiPageMetadata_IsDeleted] DEFAULT ((0)) NOT NULL,
    [DataTypeId]           BIGINT        NULL,
    CONSTRAINT [PK_UiPageMetadata] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageMetadata_DataType] FOREIGN KEY ([DataTypeId]) REFERENCES [dbo].[DataType] ([Id]),
    CONSTRAINT [FK_UiPageMetadata_UiControlType] FOREIGN KEY ([UiControlTypeId]) REFERENCES [dbo].[UiControlType] ([id]),
    CONSTRAINT [FK_UiPageMetadata_UiPageType] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id])
);




