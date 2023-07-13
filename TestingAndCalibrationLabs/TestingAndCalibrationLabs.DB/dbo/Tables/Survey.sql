CREATE TABLE [dbo].[Survey] (
    [Id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Mobile]      VARCHAR (10)  NOT NULL,
    [Email]       VARCHAR (50)  NOT NULL,
    [TestingType] VARCHAR (50)  NOT NULL,
    [Address]     VARCHAR (100) NOT NULL,
    [City]        VARCHAR (50)  NOT NULL,
    [State]       VARCHAR (50)  NOT NULL,
    [PinCode]     VARCHAR (6)   NOT NULL,
    [Comments]    VARCHAR (200) NOT NULL,
    [IsDeleted]   BIT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED ([Id] ASC)
);

