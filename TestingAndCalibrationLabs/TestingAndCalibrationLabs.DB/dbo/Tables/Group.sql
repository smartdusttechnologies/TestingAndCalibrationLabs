CREATE TABLE [dbo].[Group] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [IsDeleted] BIT          CONSTRAINT [DF_Group_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED ([Id] ASC)
);

