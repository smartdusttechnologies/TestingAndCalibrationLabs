CREATE TABLE [dbo].[LoginLog] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]       BIGINT         NOT NULL,
    [LoginDate]    DATETIME       NOT NULL,
    [Status]       SMALLINT       NOT NULL,
    [UserName]     NVARCHAR (100) NOT NULL,
    [PasswordHash] NVARCHAR (100) NOT NULL,
    [IPAddress]    NVARCHAR (50)  NULL,
    [Browser]      NVARCHAR (50)  NULL,
    [DeviceCode]   NVARCHAR (20)  NULL,
    [DeviceName]   NVARCHAR (20)  NULL,
    CONSTRAINT [PK_LoginLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LoginLog_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



