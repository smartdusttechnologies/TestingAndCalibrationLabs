CREATE TABLE [dbo].[Workflow] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [ModuleId]  INT          NOT NULL,
    [IsDeleted] INT          CONSTRAINT [DF_Workflow_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED ([Id] ASC)
);

