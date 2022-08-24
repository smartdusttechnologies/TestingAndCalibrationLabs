
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
               ,[IsDeleted])
         VALUES
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

    SET IDENTITY_INSERT [dbo].[UiPageValidationType]  OFF
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

