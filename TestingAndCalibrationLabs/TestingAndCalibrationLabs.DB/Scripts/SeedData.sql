
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

IF NOT EXISTS (SELECT 1 FROM [Role] WHERE Id IN (0,1,2,3,4))
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

IF NOT EXISTS (SELECT 1 FROM [UiControlType] WHERE Id IN (0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiControlType]  ON

    INSERT INTO [dbo].[UiControlType]
               ([Id]
		       ,[Name]
               ,[DisplayName]
               ,[IsDeleted])
         VALUES
               (0, N'None', N'None', 0),
               (1, N'text', N'User Name', 0),
			   (2, N'password', N'Password', 0),
			   (3, N'checkbox', N'Checkbox', 0),
			   (4, N'radio', N'Radio', 0),
			   (5, N'file', N'File', 0),
			   (6, N'submit', N'Submit', 0),
			   (7, N'button', N'Button', 0),
			   (8, N'textarea', N'Textarea', 0),
			   (9, N'date', N'Date', 0),
			   (10, N'email', N'Email', 0),
			   (11, N'image', N'Image', 0),
			   (12, N'number', N'Number', 0),
			   (13, N'tel', N'Telephone', 0),
			   (14, N'time', N'Time', 0),
			   (15, N'url', N'Url', 0),
			   (16, N'reset', N'Reset', 0),
			   (17, N'week', N'Week', 0),
			   (18, N'search', N'Search', 0),
			   (19, N'range', N'Range', 0),
			   (20, N'month', N'Month', 0),
			   (21, N'hidden', N'Hidden', 0),
			   (22, N'datetime-local', N'Datetime-local', 0),
			   (23, N'color', N'Color', 0),
			   (24, N'card', N'Card', 0)

    SET IDENTITY_INSERT [dbo].[UiControlType]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiPageValidationType] WHERE Id IN (0,1,2,3,4,5,6,7))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageValidationType]  ON

    INSERT INTO [dbo].[UiPageValidationType]
                ([Id], 
				[Name], 
				[IsDeleted],
				[Value], 
				[Message])
         VALUES
               (0, N'None', 0, N'None', N'None'),
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

IF NOT EXISTS (SELECT 1 FROM [DataType] WHERE Id IN (0,1,2,3))
BEGIN
    SET IDENTITY_INSERT [dbo].[DataType]  ON

    INSERT INTO [dbo].[DataType]
               ([Id]
		       ,[Name]
			   ,[IsDeleted])
         VALUES
               (0, 'None', 0),
               (1, 'int', 0),
		       (2, 'string', 0),
		       (3, 'bit', 0)
			   

    SET IDENTITY_INSERT [dbo].[DataType]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiNavigationCategory] WHERE Id IN (0,1,2,3,4,5))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiNavigationCategory]  ON

    INSERT INTO [dbo].[UiNavigationCategory]
               ([Id]
		       ,[Name],
				[Orders]
			   ,[IsDeleted])
         VALUES
               (0, 'None',0, 0),
               (1, 'Survey',2, 0),
		       (2, 'Home',1, 0),
		       (3, 'Settings',3, 0),
			   (4,'Profile',4,0),
			   (5,'Notifications',5,0)
			   
    SET IDENTITY_INSERT [dbo].[UiNavigationCategory]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiPageType] WHERE Id IN (0,1,2,3,4,5,6,7))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageType]  ON

    INSERT INTO [dbo].[UiPageType]
               ([Id]
		       ,[Name]
			   ,[IsDeleted])
         VALUES
              (0, 'None', 0),
              (1, 'Ui Page Type', 0),
		      (2, 'Ui Control Type', 0),
			  (3, 'Ui Page Metadata', 0),
			  (4, 'Ui Page Validation', 0),
			  (5, 'Home', 0),
			  (6, 'My Activity', 0),
              (7, 'My Account', 0)
						
    SET IDENTITY_INSERT [dbo].[UiPageType]  OFF
END
GO

IF NOT EXISTS (SELECT 1 FROM [UiPageNavigation] WHERE Id IN (0,1,2,3,4,5,6,7,8,9))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageNavigation]  ON

    INSERT INTO [dbo].[UiPageNavigation]
               ([Id],
			   [Url],
			   [UiPageTypeId],
			   [UiNavigationCategoryId],
			   [IsDeleted])
         VALUES
              (0, N'/UiPageType/Index/', 0, 0, 0),
              (1, N'/UiPageType/Index/', 1, 2, 0),
		      (2, N'/UiControlType/Index/', 2, 2, 0),
			  (3, N'/UiPageMetadata/Index/', 3, 2, 0),
			  (4, N'/UiPageValidation/Index/', 4, 2, 0),
			  (5, N'/', 5, 2, 0),
			  (6, N'/Common/Create/{0}', 6, 3, 0),
              (7, N'/Common/Create/{0}', 7, 3, 0),
			    (8, N'/', 0, 5, 0),
			   (9, N'/', 0, 4, 0)
    SET IDENTITY_INSERT [dbo].[UiPageNavigation]  OFF
END
GO