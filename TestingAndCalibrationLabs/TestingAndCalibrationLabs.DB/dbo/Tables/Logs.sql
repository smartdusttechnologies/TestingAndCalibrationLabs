CREATE TABLE [dbo].[Logs] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [MachineName] NVARCHAR (200) NULL,
    [Logged]      DATETIME       NOT NULL,
    [Level]       VARCHAR (5)    NOT NULL,
    [Message]     NVARCHAR (MAX) NOT NULL,
    [Logger]      NVARCHAR (300) NULL,
    [Callsite]    NVARCHAR (300) NULL,
    CONSTRAINT [PK_dbo.Logs] PRIMARY KEY CLUSTERED ([ID] ASC)
);

