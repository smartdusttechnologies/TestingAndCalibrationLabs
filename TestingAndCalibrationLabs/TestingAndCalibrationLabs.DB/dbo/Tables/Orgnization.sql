CREATE TABLE [dbo].[Organization] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [OrgCode]   NVARCHAR (10)  NOT NULL,
    [OrgName]   NVARCHAR (250) NOT NULL,
    [IsDeleted] BIT            CONSTRAINT [D_Organization_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED ([Id] ASC)
);

