CREATE TABLE [dbo].[ImageUpload] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100)   NULL,
    [FileType]  VARCHAR (100)   NULL,
    [DataFiles] VARBINARY (MAX) NULL,
    [CreatedOn] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

