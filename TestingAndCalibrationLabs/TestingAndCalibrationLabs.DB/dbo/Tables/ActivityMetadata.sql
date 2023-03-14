CREATE TABLE [dbo].[ActivityMetadata] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [Name]                   VARCHAR (50)  NOT NULL,
    [ActivityId]             INT           NOT NULL,
    [UiPageMetadataId]       INT           NOT NULL,
    [IsDeleted]              BIT           CONSTRAINT [DF_ActivityMetadata_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Value]                  VARCHAR (300) NULL,
    [ActivityMetadataTypeId] INT           NULL,
    [WorkflowStageId]        INT           NULL,
    CONSTRAINT [PK_ActivityMetadata] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ActivityMetadata_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [dbo].[Activity] ([Id]),
    CONSTRAINT [FK_ActivityMetadata_UiPageMetadata] FOREIGN KEY ([UiPageMetadataId]) REFERENCES [dbo].[UiPageMetadata] ([Id]),
    CONSTRAINT [FK_ActivityMetadata_WorkflowStage] FOREIGN KEY ([WorkflowStageId]) REFERENCES [dbo].[WorkflowStage] ([Id])
);

