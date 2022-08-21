CREATE TABLE [dbo].[LoginToken] (
    [Id]                 BIGINT          IDENTITY (1, 1) NOT NULL,
    [UserId]             BIGINT          NOT NULL,
    [AccessToken]        NVARCHAR (1000) NOT NULL,
    [RefreshToken]       NVARCHAR (1000) NULL,
    [AccessTokenExpiry]  DATETIME        NOT NULL,
    [DeviceCode]         NVARCHAR (50)   NULL,
    [DeviceName]         NVARCHAR (50)   NULL,
    [RefreshTokenExpiry] DATETIME        NULL,
    CONSTRAINT [PK_LoginToken] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LoginToken_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



