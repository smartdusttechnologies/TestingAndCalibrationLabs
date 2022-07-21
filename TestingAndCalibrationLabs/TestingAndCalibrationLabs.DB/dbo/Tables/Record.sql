CREATE TABLE [dbo].[Record] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [UiPageId]  INT NOT NULL,
    [IsDeleted] BIT CONSTRAINT [DF_Record_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Record_UiPageType_UiPageId] FOREIGN KEY ([UiPageId]) REFERENCES [dbo].[UiPageType] ([Id])
);

