CREATE TABLE [dbo].[PermissionType] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
    [Value]     VARCHAR (100) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_PermissionType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

