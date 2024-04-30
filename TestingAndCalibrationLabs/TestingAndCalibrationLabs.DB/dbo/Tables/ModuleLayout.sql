CREATE TABLE [dbo].[ModuleLayout] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [LayoutId]  INT           NOT NULL,
    [ModuleId]  INT           NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_ModuleLayout_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name]      VARCHAR (100) NULL,
    CONSTRAINT [PK_ModuleLayout] PRIMARY KEY CLUSTERED ([Id] ASC)
);

