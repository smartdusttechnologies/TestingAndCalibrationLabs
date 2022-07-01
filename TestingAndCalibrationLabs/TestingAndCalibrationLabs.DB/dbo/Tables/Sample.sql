CREATE TABLE [dbo].[Sample] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (250) NOT NULL,
    [IsDeleted]   BIT           CONSTRAINT [DF_Sample_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Sample] PRIMARY KEY CLUSTERED ([Id] ASC)
);



