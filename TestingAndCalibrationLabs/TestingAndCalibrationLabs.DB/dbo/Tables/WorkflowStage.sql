CREATE TABLE [dbo].[WorkflowStage] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [IsDeleted]    BIT           CONSTRAINT [DF_WorkflowStage_IsDeleted] DEFAULT ((0)) NOT NULL,
    [WorkflowId]   INT           NOT NULL,
    [UiPageTypeId] INT           NULL,
    [Orders]       INT           NULL,
    CONSTRAINT [PK_WorkflowStage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UiPageType_WorkflowStage_Id] FOREIGN KEY ([UiPageTypeId]) REFERENCES [dbo].[UiPageType] ([Id]),
    CONSTRAINT [FK_WorkflowStage_Workflow_Id] FOREIGN KEY ([WorkflowId]) REFERENCES [dbo].[Workflow] ([Id])
);

