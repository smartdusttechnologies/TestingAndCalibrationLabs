CREATE TABLE [dbo].[PasswordPolicy] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [MinCaps]            SMALLINT      NOT NULL,
    [MinSmallChars]      SMALLINT      NOT NULL,
    [MinSpecialChars]    SMALLINT      NOT NULL,
    [MinNumber]          SMALLINT      NOT NULL,
    [MinLength]          SMALLINT      NOT NULL,
    [AllowUserName]      BIT           NOT NULL,
    [DisAllPastPassword] SMALLINT      NOT NULL,
    [DisAllowedChars]    NVARCHAR (50) NULL,
    [ChangeIntervalDays] SMALLINT      NOT NULL,
    [OrgId]              INT           NOT NULL,
    [IsDeleted]          BIT           CONSTRAINT [D_PasswordPolicy_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PasswordPolicy] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PasswordPolicy_Organization] FOREIGN KEY ([OrgId]) REFERENCES [dbo].[Organization] ([Id])
);

