CREATE TABLE [dbo].[Application] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (100) NOT NULL,
    [IsDeleted]   BIT           CONSTRAINT [DF_Application_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED ([Id] ASC)
);

