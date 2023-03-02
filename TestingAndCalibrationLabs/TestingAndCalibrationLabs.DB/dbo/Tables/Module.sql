CREATE TABLE [dbo].[Module] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [ApplicationId] INT          NOT NULL,
    [IsDeleted]     BIT          CONSTRAINT [DF_Module_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Module_Application_Id] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[Application] ([Id])
);

