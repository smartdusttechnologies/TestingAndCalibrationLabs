CREATE TABLE [dbo].[Activity] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [IsDeleted] BIT          CONSTRAINT [DF_Activity_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED ([Id] ASC)
);

