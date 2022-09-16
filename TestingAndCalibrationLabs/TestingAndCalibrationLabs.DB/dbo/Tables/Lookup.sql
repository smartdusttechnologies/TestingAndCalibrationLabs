CREATE TABLE [dbo].[Lookup] (
    [Id]        INT       IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [Category] VARCHAR (50) NOT NULL,   
    [IsDeleted] BIT          CONSTRAINT [DF_Lookup_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED ([Id] ASC)
);