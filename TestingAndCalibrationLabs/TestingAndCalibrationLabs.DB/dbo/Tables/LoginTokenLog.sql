CREATE TABLE [dbo].[LoginTokenLog] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]             BIGINT         NOT NULL,
    [AccessToken]        NVARCHAR (MAX) NOT NULL,
    [RefreshTokenExpiry] DATETIME       NULL,
    [DeviceCode]         NVARCHAR (50)  NULL,
    [DeviceName]         NVARCHAR (50)  NULL,
    [RefreshToken]       NVARCHAR (MAX) NULL,
    [AccessTokenExpiry]  DATETIME       NOT NULL,
    CONSTRAINT [PK_LoginTokenLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LoginTokenLog_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);





