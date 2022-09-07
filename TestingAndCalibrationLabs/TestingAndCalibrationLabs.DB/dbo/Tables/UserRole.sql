CREATE TABLE [dbo].[UserRole] (
    [Id]        BIGINT   IDENTITY (1, 1) NOT NULL,
    [UserId]    BIGINT   NOT NULL,
    [RoleId]    BIGINT   NOT NULL,
    [IsDeleted] SMALLINT CONSTRAINT [DF_UserRole_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Role_UserRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [FK_User_UserRole] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



