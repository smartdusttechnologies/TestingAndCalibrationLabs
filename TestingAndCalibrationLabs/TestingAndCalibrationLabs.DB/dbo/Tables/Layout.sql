CREATE TABLE [dbo].[Layout] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Layout_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Layout] PRIMARY KEY CLUSTERED ([Id] ASC)
);

