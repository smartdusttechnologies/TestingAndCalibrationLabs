
IF NOT EXISTS (SELECT 1 FROM [Organization] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Organization]  ON

    INSERT INTO [dbo].[Organization]
               ([Id]
		       ,[OrgCode]
               ,[OrgName]
               ,[IsDeleted])
         VALUES
               (0,'SYSORG','SYSORG', 0)

    SET IDENTITY_INSERT [dbo].[Organization]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Lookup] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[LookupCategory]  ON

    INSERT INTO [dbo].[LookupCategory]
               ([Id]
		       ,[Name]
               ,[IsDeleted])
         VALUES
               (4, 'UIControlCategory', 0)
    SET IDENTITY_INSERT [dbo].[LookupCategory]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Lookup] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Lookup]  ON

    INSERT INTO [dbo].[Lookup]
               ([Id]
		       ,[Name]
               ,[LookupCategoryId]
               ,[IsDeleted])
         VALUES
               (8, 'DataControl', 4, 0),
		       (9, 'NonDataControl', 4, 0),
		       (10, 'SubLevel1Control', 4, 0)
    SET IDENTITY_INSERT [dbo].[Lookup]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Role] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Role]  ON

    INSERT INTO [dbo].[Role]
               ([Id]
		       ,[Name]
               ,[Level]
               ,[IsDeleted])
         VALUES
               (0, 'Sysadmin', 0 , 0),
		       (1, 'Admin', 1 , 0),
		       (2, 'ApplicationAdmin', 2 , 0),
		       (3, 'Manager', 3 , 0),
		       (4, 'GeneralUser', 6 , 0)
			   

    SET IDENTITY_INSERT [dbo].[Role]  OFF
END




GO
IF NOT EXISTS (SELECT 1 FROM [User] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[User]  ON

    INSERT INTO [dbo].[User]
               ([Id]
		       ,[UserName]
               ,[FirstName]
               ,[LastName]
               ,[Email]
               ,[Mobile]
               ,[Country]
               ,[ISDCode]
               ,[TwoFactor]
               ,[Locked]
               ,[IsActive]
               ,[EmailValidationStatus]
               ,[MobileValidationStatus]
               ,[OrgId]
               ,[AdminLevel]
               ,[IsDeleted])
         VALUES
               (0, 'sysadmin','sysadmin','sysadmin','sysadmin@gmail.com','1234567899','INDIA','91', 0, 0, 1, 0, 0, 0, 0, 0)

    SET IDENTITY_INSERT [dbo].[User]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [PasswordPolicy] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[PasswordPolicy]  ON

    INSERT INTO [dbo].[PasswordPolicy]
               ([Id]
		       ,[MinCaps]
               ,[MinSmallChars]
               ,[MinSpecialChars]
               ,[MinNumber]
               ,[MinLength]
               ,[AllowUserName]
               ,[DisAllPastPassword]
               ,[DisAllowedChars]
               ,[ChangeIntervalDays]
               ,[OrgId]
               ,[IsDeleted])
         VALUES
               (0, 1, 1, 1, 1, 8, 1, 0 , null, 30, 0, 0)

    SET IDENTITY_INSERT [dbo].[PasswordPolicy]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [PasswordLogin] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[PasswordLogin]  ON

    INSERT INTO [dbo].[PasswordLogin]
               ([Id]
		       ,[PasswordHash]
               ,[PasswordSalt]
               ,[UserId]
               ,[ChangeDate])
         VALUES
               --(0, 'Fz3VkUWQRP+QLYvmMilCjoz5FMRHQM8OEJxzvxwpycI=', '4XgQuK7k1tMBmh3X46N9qQ==', 0, GetDate())
			   (0, 'qnVDMZYlsGjs4chNs1/qPidI70eDUZ1fzUF5EdCqdl0=', 'NDlzcm0GY1GqMgn+urXX9Q==', 0, GetDate())

    SET IDENTITY_INSERT [dbo].[PasswordLogin]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UserRole] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UserRole]  ON

    INSERT INTO [dbo].[UserRole]
               ([Id]
		       ,[UserId]
               ,[RoleId]
               ,[IsDeleted])
         VALUES
               (0, 0, 0, 0)

    SET IDENTITY_INSERT [dbo].[UserRole]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiControlType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiControlType]  ON

    INSERT INTO [dbo].[UiControlType]
               ([Id]
		       ,[Name]
               ,[DisplayName]
               ,[IsDeleted]
			   ,[ControlCategoryId])
         VALUES
               (1, N'text', N'User Name', 0,8),
			   (2, N'password', N'Password', 0,8),
			   (3, N'checkbox', N'Checkbox', 0,8),
			   (4, N'radio', N'Radio', 0,8),
			   (5, N'file', N'File', 0,8),
			   (6, N'submit', N'Submit', 0,9),
			   (7, N'button', N'Button', 0,8),
			   (8, N'textarea', N'Textarea', 0,8),
			   (9, N'date', N'Date', 0,8),
			   (10, N'email', N'Email', 0,8),
			   (11, N'image', N'Image', 0,8),
			   (12, N'number', N'Number', 0,8),
			   (13, N'tel', N'Telephone', 0,8),
			   (14, N'time', N'Time', 0,8),
			   (15, N'url', N'Url', 0,8),
			   (16, N'reset', N'Reset', 0,9),
			   (17, N'week', N'Week', 0,8),
			   (18, N'search', N'Search', 0,8),
			   (19, N'range', N'Range', 0,8),
			   (20, N'month', N'Month', 0,8),
			   (21, N'hidden', N'Hidden', 0,8),
			   (22, N'datetime-local', N'Datetime-local', 0,8),
			   (23, N'color', N'Color', 0,8),
			   (24, N'card', N'Card', 0,9),
			   (25, N'processStatus', N'Default Process Status', 0, 9),
               (26, N'subLevel1ProcessStatus', N'Sub Leve 1 Process status', 0, 10),
               (28, N'tabs', N'Default Tabs', 0, 9),
               (29, N'subLevel1Tabs', N'Sub Level 1 Tabs', 0, 10),
               (30, N'collapsableSection', N'Default Collapsable Section', 0, 9),
               (31, N'subLevel1CollapsableSection', N'Sub Level 1 Collapsable Section', 0, 10),
               (32, N'dropdown', N'Dropdown', 0, 8),
               (33, N'grid', N'Grid', 0, 9),
               (1032, N'pincode', N'Pincode', 0, 8)

    SET IDENTITY_INSERT [dbo].[UiControlType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiControlCategoryType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiControlCategoryType]  ON

    INSERT INTO [dbo].[UiControlCategoryType]
               ([Id]
		       ,[Name]
               ,[Template]
			  ,[IsDeleted]
			   ,[UiControlTypeId])
         VALUES
               (1, N'Default', N'~/Views/Common/Components/Grid/_gridTemplate1.cshtml', 0, 33),
		       (2, N'Test Detail Classic', N'~/Views/Common/Components/Grid/_gridTemplate2.cshtml', 0, 33),
		       (3, N'Default', N'~/Views/Common/Components/Text/_text.cshtml', 0, 1),
		       (5, N'Large', N'~/Views/Common/Components/Text/_text1.cshtml', 0, 1),
		       (1003, N'Default', N'~/Views/Common/Components/Checkbox/_checkbox.cshtml', 0, 3),
			   (1004, N'Default', N'~/Views/Common/Components/Radio/_radio.cshtml', 0, 4),
               (1005, N'Default', N'~/Views/Common/Components/Submit/_submit.cshtml', 0, 6),
               (1006, N'Default ', N'~/Views/Common/Components/Email/_email.cshtml', 0, 10),
               (1007, N'Default', N'~/Views/Common/Components/Mobile/_mobileNumber.cshtml', 0, 12),
               (1009, N'Default', N'~/Views/Common/Components/Date/_time.cshtml', 0, 14),
               (1010, N'Default', N'~/Views/Common/Components/Url/_url.cshtml', 0, 15),
               (1011, N'Default', N'~/Views/Common/Components/DateTime/_datetime-local.cshtml', 0, 22),
               (1012, N'Default', N'~/Views/Common/Components/ProgressStatus/_progressStatus.cshtml', 0, 25),
               (1013, N'Default', N'~/Views/Common/Components/Tabs/_tabs.cshtml', 0, 28),
               (1014, N'Default', N'~/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml', 0, 30),
               (1015, N'Default', N'~/Views/Common/Components/Dropdown/_dropdown.cshtml', 0, 32),
               (1016, N'Default', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 1032)

    SET IDENTITY_INSERT [dbo].[UiControlCategoryType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageValidationType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageValidationType]  ON

    INSERT INTO [dbo].[UiPageValidationType]
                ([Id], 
				[Name], 
				[IsDeleted],
				[Value], 
				[Message])
         VALUES
               (1, N'MinPasswordLength', 0, N'8', N'Minimum Password length  is 8'),
			   (2, N'Email', 0, N'3', N'Email should have a fromat'),
			   (3, N'AdharLength', 0, N'12', N'AdharLength should be equal to 12'),
			   (4, N'MobileNumberLength', 0, N'10', N'Mobile Number length is equal to 10'),
			   (5, N'Year', 0, N'4', N'Year length is equal to 4'),
			   (6, N'Name', 1, N'3', N'Name should have more than 3 letters'),
			   (7, N'IsRequired', 0, N'', N'{0} Field is rquired')
			   

    SET IDENTITY_INSERT [dbo].[UiPageValidationType]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [DataType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[DataType]  ON

    INSERT INTO [dbo].[DataType]
               ([Id]
		       ,[Name]
			   ,[IsDeleted])
         VALUES
               (1, 'int', 0),
		       (2, 'string', 0),
		       (3, 'bit', 0)
			   

    SET IDENTITY_INSERT [dbo].[DataType]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiNavigationCategory] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiNavigationCategory]  ON

    INSERT INTO [dbo].[UiNavigationCategory]
               ([Id]
		       ,[Name]
			   ,[Orders]
			   ,[IsDeleted])
         VALUES
                (1, 'Survey','2', 0),
		       (2, 'Home', '1',0),
		       (1002, 'Settings', '3', 0),
			   (1003,'Profile', '4',0)
			   

    SET IDENTITY_INSERT [dbo].[UiNavigationCategory]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiPageType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageType]  ON

    INSERT INTO [dbo].[UiPageType]
               ([Id]
		       ,[Name]
			   ,[Url]
			   ,[UiNavigationCategoryId]
			   ,[IsDeleted])
         VALUES
                           (1, 'Ui Page Type','/UiPageType/Index/',1002, 0),
		      (2, 'Ui Control Type','/UiControlType/Index/',1002, 0),
			  (3, 'Ui Page Metadata','/UiPageMetadata/Index/',1002, 0),
			  (4, 'Ui Page Validation','/UiPageValidation/Index/',1002, 0),
			(5, 'Home','/',2, 0),
			(6, 'My Activity','/Common/Index/{0}',1003, 0),
                        (7, 'My Account','/Common/Index/{0}',1003, 0)		
			   

    SET IDENTITY_INSERT [dbo].[UiPageType]  OFF
END
GO