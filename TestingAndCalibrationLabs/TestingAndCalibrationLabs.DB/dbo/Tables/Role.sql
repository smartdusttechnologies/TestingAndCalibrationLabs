CREATE TABLE [dbo].[Role] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Level]     SMALLINT       NULL,
    [IsDeleted] BIT            CONSTRAINT [D_Role_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC)
);
