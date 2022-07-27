USE [TestingAndCalibrationLabs]
GO
SET IDENTITY_INSERT [dbo].[UiControlType] ON 
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (1, N'text', N'User Name', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (2, N'password', N'Password', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (3, N'checkbox', N'Checkbox', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (4, N'radio', N'Radio', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (5, N'file', N'File', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (6, N'submit', N'Submit', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (7, N'button', N'Button', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (8, N'textarea', N'Textarea', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (9, N'date', N'Date', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (10, N'email', N'Email', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (11, N'image', N'Image', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (12, N'number', N'Number', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (13, N'tel', N'Telephone', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (14, N'time', N'Time', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (15, N'url', N'Url', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (16, N'reset', N'Reset', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (17, N'week', N'Week', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (18, N'search', N'Search', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (19, N'range', N'Range', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (20, N'month', N'Month', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (21, N'hidden', N'Hidden', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (22, N'datetime-local', N'Datetime-local', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (23, N'color', N'Color', 0)
GO
INSERT [dbo].[UiControlType] ([id], [Name], [DisplayName], [IsDeleted]) VALUES (24, N'card', N'Card', 0)
GO
SET IDENTITY_INSERT [dbo].[UiControlType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1, 1, 1, 1, N'Name', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (2, 1, 2, 1, N'Password', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (3, 1, 12, 0, N'Adhar card', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (4, 1, 12, 1, N'Mobile Number', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (5, 1, 12, 1, N'year', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (6, 1, 18, 0, N'Search', 1, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (7, 1, 3, 1, N'Clickme', 1, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageTypeId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (8, 1, 22, 0, N'Date', 1, N'string')
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageType] ON 
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (1, N'SamplePage', 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] ON 
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (1, N'MinPasswordLength', 0, N'8', N'Minimum Password length  is 8')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (2, N'Email', 0, N'3', N'Email should have a fromat')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (3, N'AdharLength', 0, N'12', N'AdharLength should be equal to 12')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (4, N'MobileNumberLength', 0, N'10', N'Mobile Number length is equal to 10')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (5, N'Year', 0, N'4', N'Year length is equal to 4')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (6, N'Name', 1, N'3', N'Name should have more than 3 letters')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (7, N'IsRequired', 0, N'', N'{0} Field is rquired')
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] ON 
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (1, 1, 1, 1, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (2, 1, 2, 3, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (3, 1, 3, 4, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (4, 1, 4, 5, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (5, 1, 5, 6, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (6, 1, 6, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (7, 1, 2, 7, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (8, 1, 3, 7, 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageValidation] OFF
GO
INSERT [dbo].[Sample] ([Id], [Name], [Description], [IsDeleted]) VALUES (1, N'Rishi', N'Asdfg', 0)
GO
SET IDENTITY_INSERT [dbo].[SampleTable] ON 
GO
INSERT [dbo].[SampleTable] ([Id], [Name], [Description], [IsDeleted]) VALUES (1, N'Rishi Kumar', N'qwert', 1)
GO
INSERT [dbo].[SampleTable] ([Id], [Name], [Description], [IsDeleted]) VALUES (2, N'rk', N'rkk', 0)
GO
SET IDENTITY_INSERT [dbo].[SampleTable] OFF
GO
