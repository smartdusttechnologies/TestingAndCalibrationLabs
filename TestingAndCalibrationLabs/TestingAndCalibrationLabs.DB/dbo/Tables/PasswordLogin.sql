CREATE TABLE [dbo].[PasswordLogin] (
    [Id]           BIGINT          IDENTITY (1, 1) NOT NULL,
    [PasswordHash] NVARCHAR (1000) NOT NULL,
    [PasswordSalt] NVARCHAR (1000) NOT NULL,
    [UserId]       BIGINT          NOT NULL,
    [ChangeDate]   DATETIME        NULL,
    CONSTRAINT [PK_PasswordLogin] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PasswordLogin_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



