CREATE TABLE [dbo].[DataType] (
    [Id]        BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [IsDeleted] BIT          CONSTRAINT [DF_DataType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_DataType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

