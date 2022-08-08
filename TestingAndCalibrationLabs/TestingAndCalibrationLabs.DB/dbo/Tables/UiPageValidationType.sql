CREATE TABLE [dbo].[UiPageValidationType] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
	[Message] varchar(100) NOT NULL,
	[Value] varchar(100) NOT NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_UiPageValidationType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiPageValidationType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



