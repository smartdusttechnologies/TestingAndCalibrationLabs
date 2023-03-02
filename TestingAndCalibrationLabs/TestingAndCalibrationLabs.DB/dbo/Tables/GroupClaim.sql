CREATE TABLE [dbo].[GroupClaim] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [GroupId]      INT NOT NULL,
    [ClaimTypeId]  INT NOT NULL,
    [PermissionId] INT NOT NULL,
    [IsDeleted]    BIT CONSTRAINT [DF_GroupClaim_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_GroupClaim] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GroupClaim_ClaimType] FOREIGN KEY ([ClaimTypeId]) REFERENCES [dbo].[ClaimType] ([Id]),
    CONSTRAINT [FK_GroupClaim_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    CONSTRAINT [FK_GroupClaim_Permission] FOREIGN KEY ([Id]) REFERENCES [dbo].[Permission] ([Id])
);

