﻿CREATE TABLE [dbo].[GroupUser] (
    [Id]        INT    IDENTITY (1, 1) NOT NULL,
    [GroupId]   INT    NOT NULL,
    [UserId]    BIGINT NOT NULL,
    [IsDeleted] BIT    CONSTRAINT [DF_UserGroup_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_1_Group_Id] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    CONSTRAINT [FK_Table_1_User_Id] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

