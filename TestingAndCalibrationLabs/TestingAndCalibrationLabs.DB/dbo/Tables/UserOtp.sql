CREATE TABLE [dbo].[UserOtp] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      BIGINT        NULL,
    [Otp]         VARCHAR (200) NULL,
    [CreatedDate] DATETIME      NULL,
    [IsDeleted] BIT NULL DEFAULT 0, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

