CREATE TABLE [dbo].[LookupCategory]
(
	[Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    [IsDeleted]            BIT           CONSTRAINT [DF_LookupCategory_IsDeleted] DEFAULT ((0)) NOT NULL
    
    CONSTRAINT [PK_LookupCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
)
