CREATE TABLE [dbo].[UserClaim] (
    [Id]           INT    IDENTITY (1, 1) NOT NULL,
    [UserId]       BIGINT NOT NULL,
    [PermissionId] INT    NOT NULL,
    [IsDeleted]    BIT    CONSTRAINT [DF_UserPermission_IsDeleted] DEFAULT ((0)) NOT NULL,
    [ClaimTypeId]  INT    NOT NULL,
    CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserClaim_ClaimType_Id] FOREIGN KEY ([ClaimTypeId]) REFERENCES [dbo].[ClaimType] ([Id]),
    CONSTRAINT [FK_UserClaim_Permission_Id] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([Id]),
    CONSTRAINT [FK_UserClaim_User_Id] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

