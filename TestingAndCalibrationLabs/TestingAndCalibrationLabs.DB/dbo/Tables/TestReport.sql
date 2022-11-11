CREATE TABLE [dbo].[TestReport] (
    [Id]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Client]    VARCHAR (50)  NOT NULL,
    [Filepath]  VARCHAR (100) NOT NULL,
    [Email]     VARCHAR (50)  NOT NULL,
    [JobId]     VARCHAR (50)  NOT NULL,
    [Name]      VARCHAR (50)  NOT NULL,
    [DateTime]  DATETIME      NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_TestReport_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TestReport] PRIMARY KEY CLUSTERED ([Id] ASC)
);

