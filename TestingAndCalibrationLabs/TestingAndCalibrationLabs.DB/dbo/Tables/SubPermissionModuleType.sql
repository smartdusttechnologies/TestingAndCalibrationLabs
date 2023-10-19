CREATE TABLE [dbo].[SubPermissionModuleType] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [Name]                   VARCHAR (50) NOT NULL,
    [PermissionModuleTypeId] INT          NOT NULL,
    [IsDeleted]              BIT          CONSTRAINT [DF_SubPermissionModuleTypeId_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SubPermissionModuleTypeId] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SubPermissionModuleTypeId_PermissionModuleType] FOREIGN KEY ([PermissionModuleTypeId]) REFERENCES [dbo].[PermissionModuleType] ([Id])
);

