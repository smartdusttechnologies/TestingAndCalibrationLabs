CREATE TABLE [dbo].[UiControlType] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [DisplayName] VARCHAR (100) NOT NULL,
    [IsDeleted]   BIT           CONSTRAINT [DF_UiControlType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UiControlType] PRIMARY KEY CLUSTERED ([id] ASC)
);

