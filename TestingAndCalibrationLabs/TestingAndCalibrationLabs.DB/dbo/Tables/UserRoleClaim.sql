CREATE TABLE [dbo].[UserRoleClaim] (
    [Id]           INT    IDENTITY (1, 1) NOT NULL,
    [RoleId]       BIGINT NOT NULL,
    [PermissionId] INT    NOT NULL,
    [ClaimTypeId]  INT    NOT NULL,
    [IsDeleted]    BIT    CONSTRAINT [DF_UserRoleClaim_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserRoleClaim] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoleClaim_ClaimType_Id] FOREIGN KEY ([ClaimTypeId]) REFERENCES [dbo].[ClaimType] ([Id]),
    CONSTRAINT [FK_UserRoleClaim_Permission_Id] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([Id]),
    CONSTRAINT [FK_UserRoleClaim_Role_Id] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);

