CREATE TABLE [dbo].[UserOtp] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      BIGINT        NULL,
    [Otp]         VARCHAR (200) NULL,
    [CreatedDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

