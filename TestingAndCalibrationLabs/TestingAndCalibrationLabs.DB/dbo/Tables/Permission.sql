CREATE TABLE [dbo].[Permission] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [Name]                   VARCHAR (100) NOT NULL,
    [PermissionModuleTypeId] INT           NOT NULL,
    [PermissionTypeId]       INT           NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_Permission_isDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Permission_PermissionType_Id] FOREIGN KEY ([PermissionTypeId]) REFERENCES [dbo].[PermissionType] ([Id]),
    CONSTRAINT [FK_Permission_SubPermissionModuleId] FOREIGN KEY ([PermissionModuleTypeId]) REFERENCES [dbo].[SubPermissionModuleType] ([Id])
);



