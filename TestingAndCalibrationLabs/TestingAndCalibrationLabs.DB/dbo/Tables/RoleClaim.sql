CREATE TABLE [dbo].[RoleClaim] (
    [Id]           INT    IDENTITY (1, 1) NOT NULL,
    [RoleId]       BIGINT NOT NULL,
    [PermissionId] INT    NOT NULL,
    [ClaimTypeId]  INT    NOT NULL,
    [IsDeleted]    BIT    CONSTRAINT [DF_UserRoleClaim_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RoleClaim] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleClaim_ClaimType_Id] FOREIGN KEY ([ClaimTypeId]) REFERENCES [dbo].[ClaimType] ([Id]),
    CONSTRAINT [FK_RoleClaim_Permission_Id] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([Id]),
    CONSTRAINT [FK_RoleClaim_Role_Id] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);

