CREATE TABLE [dbo].[SampleTable] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (256) NOT NULL,
    [Description] VARCHAR (256) NOT NULL,
    [IsDeleted]   BIT           CONSTRAINT [D_SampleTable_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED ([Id] ASC)
);


