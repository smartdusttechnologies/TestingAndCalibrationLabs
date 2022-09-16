CREATE TABLE [dbo].[ClaimType] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_ClaimType_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Value]     VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_ClaimType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

