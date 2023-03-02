CREATE TABLE [dbo].[WorkflowActivity] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (100) NOT NULL,
    [WorkflowStageId] INT           NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_WorkflowActivity_IsDeleted] DEFAULT ((0)) NOT NULL,
    [ActivityId]      INT           NULL,
    CONSTRAINT [PK_WorkflowActivity] PRIMARY KEY CLUSTERED ([Id] ASC)
);

