CREATE TABLE [dbo].[PermissionModuleType] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_PermissionModuleType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PermissionModuleType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

