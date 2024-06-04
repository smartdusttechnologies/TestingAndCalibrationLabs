CREATE TABLE [dbo].[Template]
(
	
	
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [TemplateName]      VARCHAR (100) NOT NULL,
    [FileId] [int] Not NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_Template_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED ([Id] ASC)
);

