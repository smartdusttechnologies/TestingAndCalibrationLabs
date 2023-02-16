CREATE TABLE [dbo].[Record] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [IsDeleted]       BIT      CONSTRAINT [DF_Record_IsDeleted] DEFAULT ((0)) NOT NULL,
    [ModuleId]        INT      NULL,
    [WorkflowStageId] INT      NULL,
    [UpdatedDate]     DATETIME NULL,
    CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED ([Id] ASC)
);





