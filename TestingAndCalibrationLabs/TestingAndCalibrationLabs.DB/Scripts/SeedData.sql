IF NOT EXISTS (SELECT 1 FROM [Application] WHERE ID IN (1))
BEGIN
    SET IDENTITY_INSERT [dbo].[Application]  ON

    INSERT INTO [dbo].[Application]
               ([Id], [Name], [Description], [IsDeleted])
         VALUES
               (1, N'Laboratory Management Application', N'Laboratory Management Application', 0)

    SET IDENTITY_INSERT [dbo].[Application]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Module] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Module]  ON

    INSERT INTO [dbo].[Module]
               ([Id], [Name], [ApplicationId], [IsDeleted])
         VALUES
               (0, N'none', 1, 0),
			   
			   (1, N'Cube Testing', 1, 0),
			   
			   (2, N'Water Testing', 1, 0),
			   
			   (3, N'Customer', 1, 0),
			   (4, N'Ui Page Type', 1, 0),
			   (5, N'Ui Control Type', 1, 0),
			   (6, N'Ui Page Metadata', 1, 0),
			   (7, N'Ui Page Validation',1,0),
			   (8, N'PasswordPolicy',1,0)

    SET IDENTITY_INSERT [dbo].[Module]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Organization] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Organization]  ON

    INSERT INTO [dbo].[Organization]
               ([Id], [OrgCode], [OrgName], [IsDeleted])
         VALUES
               (0, N'SYSORG', N'SYSORG', 0)
    SET IDENTITY_INSERT [dbo].[Organization]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [User] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[User]  ON

    INSERT INTO [dbo].[User]
               ([Id], [UserName], [FirstName], [LastName], [Email], [Mobile], [Country], [ISDCode], [TwoFactor], [Locked], [IsActive], [EmailValidationStatus], [MobileValidationStatus], [OrgId], [AdminLevel], [IsDeleted])
         VALUES
              (0, N'sysadmin', N'sysadmin', N'sysadmin', N'sysadmin@gmail.com', N'1234567899', N'INDIA', N'91', 0, 0, 1, 0, 0, 0, 0, 0)
    SET IDENTITY_INSERT [dbo].[User]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Role] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Role]  ON

    INSERT INTO [dbo].[Role]
              ([Id], [Name], [Level], [IsDeleted])
         VALUES
               (0, N'Sysadmin', 0, 0),
			   (1, N'Admin', 1, 0),
			   (2, N'ApplicationAdmin', 2, 0),
			   (3, N'Manager', 3, 0),
			   (4, N'GeneralUser', 6, 0)

    SET IDENTITY_INSERT [dbo].[Role]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [DataType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[DataType]  ON

    INSERT INTO [dbo].[DataType]
               ([Id], [Name], [IsDeleted])
			   VALUES
              (1, N'int', 0),
			  (2, N'string', 0),
			  (3, N'bit', 0)
    SET IDENTITY_INSERT [dbo].[DataType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [LookupCategory] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[LookupCategory]  ON

    INSERT INTO [dbo].[LookupCategory]
               ([Id], [Name], [IsDeleted])
			   VALUES
              (4, N'UIControlCategory', 0),
			  (1004, N'Null', 0),
			  (1005, N'Country', 0),
			  (1006, N'ActitvityMetadataType', 0),
			  (1007, N'TestReport', 0),
			  (1008, N'Payment', 0)
    SET IDENTITY_INSERT [dbo].[LookupCategory]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Lookup] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Lookup]  ON

    INSERT INTO [dbo].[Lookup]
                ([Id], [Name], [LookupCategoryId], [IsDeleted])
			   VALUES
             (8, N'DataControl', 4, 0),
			 (9, N'NonDataControl', 4, 0),
			 (10, N'SubLevel1Control', 4, 0),
			 (1008, N'Indea', 1005, 0),
			 (1009, N'Pakistan', 1005, 0),
			 (1010, N'England', 1005, 0),
			 (1011, N'USA', 1005, 0),
			 (1012, N'Bangladesh', 1005, 0),
			 (1013, N'New Zealand', 1005, 0),
			 (1014, N'Paris', 1005, 0),
			 (1015, N'Static', 1006, 0),
			 (1016, N'Dynamic', 1006, 0),
			 (1020, N'_testReport.html', 1007, 0),
			 (1021, N'_payment.html', 1008, 0)
    SET IDENTITY_INSERT [dbo].[Lookup]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiControlType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiControlType]  ON

    INSERT INTO [dbo].[UiControlType]
                ([id], [Name], [DisplayName], [IsDeleted], [ControlCategoryId])
			   VALUES
           (1, N'text', N'User Name', 0, 8),
		   (2, N'password', N'Password', 0, 8),
		   (3, N'checkbox', N'Checkbox', 0, 8),
		   (4, N'radio', N'Radio', 0, 8),
		   (5, N'file', N'File', 0, 8),
		   (6, N'submit', N'Submit', 0, 9),
		   (7, N'button', N'Button', 0, 8),
		   (8, N'textarea', N'Textarea', 0, 8),
		   (9, N'date', N'Date', 0, 8),
		   (10, N'email', N'Email', 0, 8),
		   (11, N'image', N'Image', 0, 8),
		   (12, N'number', N'Number', 0, 8),
		   (13, N'tel', N'Telephone', 0, 8),
		   (14, N'time', N'Time', 0, 8),
		   (15, N'url', N'Url', 0, 8),
		   (16, N'reset', N'Reset', 0, 9),
		   (17, N'week', N'Week', 0, 8),
		   (18, N'search', N'Search', 0, 8),
		   (19, N'range', N'Range', 0, 8),
		   (20, N'month', N'Month', 0, 8),
		   (21, N'hidden', N'Hidden', 0, 8),
		   (22, N'datetime-local', N'Datetime-local', 0, 8),
		   (23, N'color', N'Color', 0, 8),
		   (24, N'card', N'Card', 0, 9),
		   (25, N'processStatus', N'Default Process Status', 0, 9),
		   (26, N'subLevel1ProcessStatus', N'Sub Leve 1 Process status', 0, 10),
		   (28, N'tabs', N'Default Tabs', 0, 9),
		   (29, N'subLevel1Tabs', N'Sub Level 1 Tabs', 0, 10),
		   (30, N'collapsableSection', N'Default Collapsable Section', 0, 9),
		   (31, N'subLevel1CollapsableSection', N'Sub Level 1 Collapsable Section', 0, 10),
		   (32, N'dropdown', N'Dropdown', 0, 8),
		   (33, N'grid', N'Grid', 0, 9),
		   (34, N'pincode', N'Pincode', 0, 8),
		   (35, N'year', N'Year', 0, 8),
		   (36, N'question', N'Question - Checkbox', 0, 9),
		   (37, N'workflowStage', N'Workflow Stage', 0, 8),
		   (38, N'Download', N'ReportTemplate', 0, 9)
    SET IDENTITY_INSERT [dbo].[UiControlType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiControlCategoryType] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiControlCategoryType]  ON

    INSERT INTO [dbo].[UiControlCategoryType]
              ([Id], [Name], [Template], [IsDeleted], [UiControlTypeId])
			   VALUES
              (1, N'Grid', N'~/Views/Common/Components/Grid/_gridTemplate1.cshtml', 0, 33),
			  (2, N'Grid Classic', N'~/Views/Common/Components/Grid/_gridTemplate2.cshtml', 0, 33),
			  (3, N'Text', N'~/Views/Common/Components/Text/_text.cshtml', 0, 1),
			  (5, N'Text Large', N'~/Views/Common/Components/Text/_text1.cshtml', 0, 1),
			  (1003, N'Checkbox', N'~/Views/Common/Components/Checkbox/_checkbox.cshtml', 0, 3),
			  (1004, N'Radio', N'~/Views/Common/Components/Radio/_radio.cshtml', 0, 4),
			  (1005, N'Submit', N'~/Views/Common/Components/Submit/_submit.cshtml', 0, 6),
			  (1006, N'Email', N'~/Views/Common/Components/Email/_email.cshtml', 0, 10),
			  (1007, N'Mobile Number', N'~/Views/Common/Components/Mobile/_mobileNumber.cshtml', 0, 12),
			  (1009, N'Time', N'~/Views/Common/Components/Date/_time.cshtml', 0, 14),
			  (1010, N'URL', N'~/Views/Common/Components/Url/_url.cshtml', 0, 15),
			  (1011, N'Date Time', N'~/Views/Common/Components/DateTime/_datetime-local.cshtml', 0, 22),
			  (1012, N'Progress Bar', N'~/Views/Common/Components/ProgressStatus/_progressStatusWithWorklofw.cshtml', 0, 25),
			  (1013, N'Tabs', N'~/Views/Common/Components/Tabs/_tabs.cshtml', 0, 28),
			  (1014, N'Collapsable Section', N'~/Views/Common/Components/CollapsableSection/_collapsableSection.cshtml', 0, 30),
			  (1015, N'Dropdown', N'~/Views/Common/Components/Dropdown/_dropdown.cshtml', 0, 32),
			  (1016, N'Pincode', N'~/Views/Common/Components/Pincode/_pincode.cshtml', 0, 34),
			  (1017, N'Null', N'Null', 0, 29),
			  (1020, N'Textarea', N'~/Views/Common/Components/Textarea/_textarea.cshtml', 0, 8),
			  (2004, N'File', N'~/Views/Common/Components/File/_file.cshtml', 0, 5),
			  (2006, N'Year', N'~/Views/Common/Components/DateTime/_year.cshtml', 0, 35),
			  (2007, N'Checkbox', N'~/Views/Common/Components/Question/_checkbox.cshtml', 0, 36),
			  (2008, N'WorkflowStage', N'~/Views/Common/Components/WorkflowStage/_workflowStage.cshtml', 0, 37),
			  (2010, N'Download', N'~/Views/Common/Components/Download/_download.cshtml', 0, 38),
			  (2011, N'MultiControlGrid', N'~/Views/Common/Components/Grid/_gridMultiControl.cshtml', 0, 33)
    SET IDENTITY_INSERT [dbo].[UiControlCategoryType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageMetadata] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageMetadata]  ON

    INSERT INTO [dbo].[UiPageMetadata]
              ([Id], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataTypeId], [UiControlCategoryTypeId], [Name])
			   VALUES
            (3, 25, 0, N'ProgressStatus', 0, 1, 1012, N'progress1'),
			(4, 29, 0, N'Sample Recieving', 0, 1, 1017, N'lab1'),
			(5, 29, 0, N'Test Plan', 0, 1, 1017, N'disc1'),
			(6, 29, 0, N'Lab Analysis', 0, 1, 1017, N'disc2'),
			(7, 29, 0, N'Test Report', 0, 1, 1017, N'org1'),
			(8, 29, 0, N'Billing & Payment', 0, 1, 1017, N'equi1'),
			(9, 29, 0, N'Reference Materials', 0, 1, 1017, N'refer1'),
			(10, 29, 0, N'Quality Control Activities', 0, 1, 1017, N'qcont1'),
			(11, 29, 0, N'Enclosure List', 0, 1, 1017, N'enc1'),
			(12, 1, 0, N'Name Of The Laboratory', 0, 2, 3, N'nothe1'),
			(13, 1, 0, N'GSTIN', 0, 2, 3, N'gstin1'),
			(14, 1, 0, N'Contry', 0, 2, 3, N'cont2'),
			(15, 1, 0, N'State/Provider', 0, 2, 3, N'sttt3'),
			(16, 1, 0, N'City', 0, 2, 3, N'ct3'),
			(17, 1, 0, N'Address', 0, 2, 3, N'adgag4'),
			(18, 1, 0, N'District', 0, 2, 3, N'discr4'),
			(19, 1032, 0, N'Pincode', 0, 2, 1016, N'pincd5'),
			(20, 12, 0, N'Mobile Number', 0, 2, 1007, N'mobi34'),
			(21, 10, 0, N'Email', 0, 2, 1006, N'emuil34'),
			(22, 1, 0, N'Discipline Of Testing', 0, 2, 3, N'discip6'),
			(23, 1, 0, N'Group', 0, 2, 3, N'grty5'),
			(24, 1, 0, N'Location', 0, 2, 3, N'dsg'),
			(25, 1, 0, N'Discipline', 0, 2, 3, N'etr'),
			(26, 1, 0, N'Group', 0, 2, 3, N'ttyr'),
			(27, 1, 0, N'Sub-Group', 0, 2, 3, N'rteag'),
			(28, 8, 0, N'Products/Materials of Test', 0, 2, 1020, N'dgsdsert'),
			(29, 8, 0, N'Specific tests or types of tests perofmed', 0, 2, 1020, N'vstyers'),
			(30, 30, 0, N'Collapsable', 0, 1, 1014, N'dasterdsd'),
			(31, 29, 0, N'Organization Structure', 0, 1, 1017, N'hyer'),
			(32, 29, 0, N'New Employee Details', 0, 1, 1017, N'gdfy'),
			(33, 1, 0, N'Organization Chart of Laboratory Link', 0, 2, 3, N'dfgd'),
			(34, 1, 0, N'organization chart', 0, 2, 3, N'rtyery'),
			(35, 1, 0, N'Subject', 0, 2, 3, N'hrty'),
			(36, 1, 0, N'HtmlMsg', 0, 2, 3, N'wsrt'),
			(1004, 5, 0, N'Image Input', 0, 1, 2004, N'sg'),
			(1005, 1, 0, N'Location', 0, 2, 3, N'sergs'),
			(1006, 1, 0, N'Discipline', 0, 2, 3, N'tr5'),
			(1007, 1, 0, N'Group', 0, 2, 3, N'sgsret'),
			(1008, 1, 0, N'Type Of Test', 0, 2, 3, N'regs'),
			(1009, 1, 0, N'UID of Equipment', 0, 2, 3, N'trse'),
			(1010, 1, 0, N'Name Of Equipment', 0, 2, 3, N'gsdg'),
			(1011, 1, 0, N'Model', 0, 2, 3, N'uys'),
			(1012, 1, 0, N'Serial No', 0, 2, 3, N'bew'),
			(1013, 1, 0, N'Name Of Manufracturer', 0, 2, 3, N'ma'),
			(1014, 2032, 0, N'Year Of Make', 0, 2, 2006, N'v'),
			(1015, 1, 0, N'Range and Accurecy', 0, 2, 3, N'rtsd'),
			(1017, 22, 0, N'Last Calibration Date', 0, 2, 1011, N'uym'),
			(1018, 22, 0, N'Calibration Due on', 0, 2, 1011, N'du v'),
			(1019, 32, 0, N'Location', 0, 2, 1015, N'aser'),
			(1023, 1, 0, N'Discipline', 0, 2, 3, N'bys'),
			(1024, 1, 0, N'Group', 0, 2, 3, N'um'),
			(1025, 1, 0, N'Name of Reference Material/Strain/Culture', 0, 2, 3, N'gbgsn '),
			(1026, 1, 0, N'Source', 0, 2, 3, N'shb sdfy'),
			(1027, 22, 0, N'Date Of Expiry', 0, 2, 1011, N'dbsghv'),
			(1028, 1, 0, N'Tracability', 0, 2, 3, N'vbs'),
			(1029, 1, 0, N'Location', 0, 2, 3, N'gvtsn s'),
			(1030, 1, 0, N'Type Of Partipatation', 0, 2, 3, N'm,s ij'),
			(1031, 1, 0, N'Discipline', 0, 2, 3, N'v '),
			(1032, 1, 0, N'Group', 0, 2, 3, N'zym r'),
			(1033, 1, 0, N'Product/Material', 0, 2, 3, N'mn'),
			(1034, 1, 0, N'Details of Test', 0, 2, 3, N'burtm,'),
			(1035, 22, 0, N'Date Of Testing', 0, 2, 1011, N'io'),
			(1036, 1, 0, N'Nodal Laboratory/PT Provider (Accredification Body/Country)', 0, 2, 3, N'rb'),
			(1037, 1, 0, N'Performance in Term of Z Score / Any Other Criteria', 0, 2, 3, N'ta'),
			(1038, 1, 0, N'Corrective Action Taken (if any)', 0, 2, 3, N'byim'),
			(1039, 5, 0, N'Upload Quality Manual', 0, 2, 2004, N'ng'),
			(1040, 4, 0, N'Calibrated By', 0, 1, 1004, N'svbtyio'),
			(1042, 29, 0, N'Inhouse', 0, 1, 1003, N'eryrt'),
			(1043, 29, 0, N'External', 0, 1, 1003, N'ryrtuty'),
			(1044, 3, 0, N'Checkbox-check', 0, 1, 1003, N'esbum'),
			(1045, 29, 0, N'Patna', 1, 1, 1017, N'iduyaer'),
			(1046, 29, 0, N'Lacknow', 1, 1, 1017, N'sgfdsgd'),
			(1047, 29, 0, N'Bareliy', 1, 1, 1017, N'sdgsdfg'),
			(1048, 29, 0, N'Karnataka', 1, 1, 1017, N'fgd'),
			(2002, 33, 0, N'Grid', 0, 1, 2, N'lfy'),
			(2008, 1, 0, N'adfsafds', 0, 2, 3, N'afsdfa'),
			(3006, 1, 0, N'Name', 0, 2, 3, N'UserName'),
			(3007, 1, 0, N'fghfgh', 0, 2, 1010, N'hfhgh'),
			(3008, 37, 1, N'Workflow', 0, 1, 2008, N'wrkff'),
			(3009, 1, 0, N'User Table', 0, 2, 3, N'Raj'),
			(3010, 1, 1, N'TableName', 0, 2, 3, N'uyhfg'),
			(3011, 1, 0, N'ThirdPageName', 0, 3, 3, N'jh'),
			(3012, 1, 0, N'Customer Name', 0, 2, 3, N'cu'),
			(3013, 1, 0, N'Contant Person', 0, 2, 3, N'cP'),
			(3014, 1, 0, N'Name', 0, 2, 3, N'name'),
			(3016, 1, 1, N'Job Serial No', 0, 2, 3, N'jsn'),
			(3017, 1, 1, N'Department Name', 0, 2, 3, N'rd'),
			(3018, 1, 1, N'Issue To', 0, 2, 3, N'df'),
			(3019, 22, 1, N'Recived On', 0, 3, 1011, N'jklg'),
			(3020, 1, 1, N'Job Order No / Ref No', 0, 2, 3, N'sdg'),
			(3021, 1, 0, N'Contact Person Name', 0, 2, 3, N'ds'),
			(3024, 22, 0, N'TestReport Release Date', 0, 3, 1011, N'datee'),
			(3025, 1, 0, N'Any Other Specific Requirment', 0, 2, 3, N'sdsf'),
			(3026, 5, 0, N'Attachments', 0, 3, 2004, N'sfsd'),
			(3027, 1, 0, N'Sample Type', 0, 3, 3, N'dfgf'),
			(3028, 1, 0, N'Sample Details', 0, 2, 3, N'0'),
			(3029, 22, 0, N'Date of TP', 0, 2, 1011, N'0'),
			(3030, 1, 0, N'Job Code No', 0, 2, 3, N'0'),
			(3031, 1, 0, N'Sample ID', 0, 2, 3, N'0'),
			(3032, 1, 0, N'Number Of Samples/Quantity', 0, 2, 3, N'0'),
			(3034, 1, 0, N'Test Name ', 0, 2, 3, N'0'),
			(3035, 1, 0, N'Test Method', 0, 2, 3, N'0'),
			(3036, 1, 0, N'Person Authorized', 0, 2, 3, N'0'),
			(3037, 22, 0, N'Targeted On', 0, 2, 1011, N'0'),
			(3038, 22, 0, N'Completed on', 0, 2, 1011, N'0'),
			(3039, 1, 0, N'Remarks', 0, 2, 3, N'0'),
			(3040, 22, 0, N'Date Of Report', 0, 3, 1011, N'0'),
			(3041, 1, 0, N'Report No', 0, 2, 3, N'0'),
			(3043, 1, 0, N'ULR No', 0, 2, 3, N'0'),
			(3044, 22, 0, N'Date Of Casting', 0, 2, 1011, N'0'),
			(3045, 1, 0, N'Age Of Specimens', 0, 2, 3, N'0'),
			(3046, 1, 0, N'Length', 0, 2, 3, N'0'),
			(3047, 1, 0, N'Width', 0, 2, 3, N'0'),
			(3048, 1, 0, N'Height', 0, 2, 3, N'0'),
			(3049, 1, 1, N'mm²', 0, 2, 3, N'0'),
			(3050, 1, 1, N'cm³', 0, 2, 3, N'0'),
			(3051, 1, 0, N'gm', 0, 2, 3, N'0'),
			(3053, 1, 0, N'gm/cm³', 0, 2, 3, N'0'),
			(3054, 1, 0, N'Load, KN', 0, 2, 3, N'0'),
			(3056, 1, 1, N'Compressive Strength, N/mm²', 0, 2, 3, N'0'),
			(3057, 1, 0, N'Average', 0, 2, 3, N'0'),
			(3058, 38, 0, N'TestReport', 0, 2, 2010, N'0'),
			(3059, 1, 0, N'Price', 0, 2, 3, N'0'),
			(3060, 1, 0, N'Tax', 0, 2, 3, N'0'),
			(3061, 1, 0, N'Total', 0, 2, 3, N'0'),
			(3062, 38, 0, N'Payment', 0, 2, 2010, N'0'),
			(3063, 33, 0, N'MultiControlGrid', 0, 2, 2011, N'0')
    SET IDENTITY_INSERT [dbo].[UiPageMetadata]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageMetadataCharacteristics] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics]  ON

    INSERT INTO [dbo].[UiPageMetadataCharacteristics]
              ([Id], [UiPageMetadataId], [LookupCategoryId], [IsDeleted])
			   VALUES
              (1, 1019, 1005, 0),
			  (3, 3058, 1007, 0),
			  (4, 3062, 1008, 0)
    SET IDENTITY_INSERT [dbo].[UiPageMetadataCharacteristics]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiNavigationCategory] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiNavigationCategory]  ON

    INSERT INTO [dbo].[UiNavigationCategory]
               ([Id], [Name], [Orders], [IsDeleted])
			   VALUES
              (1, N'Testing', 2, 0),
			  (2, N'Home', 1, 0),
			  (1002, N'Settings', 3, 0),
			  (1003, N'Profile', 4, 0),
			  (1004, N'Notifications', 5, 0)
    SET IDENTITY_INSERT [dbo].[UiNavigationCategory]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageNavigation] WHERE Id IN (0,1,2,3,4,5,6,7,8,9,10))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageNavigation]  ON

    INSERT INTO [dbo].[UiPageNavigation]
               ([Id], [Url], [ModuleId], [UiNavigationCategoryId], [IsDeleted])
			   VALUES
              (1, N'/Common/Index/{0}', 1, 1, 0),
			  (2, N'/Common/Index/{0}', 2, 1, 0),
			  (4, N'/', 0, 1003, 0),
			  (5, N'/', 0, 1004, 0),
			  (6, N'/', 0, 2, 0),
			  (7, N'/UiPageType/Index/', 4, 1002, 0),
			  (8, N'/UiControlType/Index/', 5, 1002, 0),
			  (9, N'/UiPageMetadata/Index/', 6, 1002, 0),
			  (10, N'/UiPageValidation/Index/', 7, 1002, 0),
			  (11,N'/PasswordPolicy/Index/',8,1002,0)
    SET IDENTITY_INSERT [dbo].[UiPageNavigation]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [PasswordPolicy] WHERE Id IN (0))
BEGIN
    SET IDENTITY_INSERT [dbo].[PasswordPolicy]  ON

    INSERT INTO [dbo].[PasswordPolicy]
              ([Id], [MinCaps], [MinSmallChars], [MinSpecialChars], [MinNumber], [MinLength], [AllowUserName], [DisAllPastPassword], [DisAllowedChars], [ChangeIntervalDays], [OrgId], [IsDeleted])
			  VALUES 
			  (0, 1, 1, 1, 1, 8, 1, 0, NULL, 30, 0, 0)
    SET IDENTITY_INSERT [dbo].[PasswordPolicy]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Activity] WHERE Id IN (1))
BEGIN
    SET IDENTITY_INSERT [dbo].[Activity]  ON

    INSERT INTO [dbo].[Activity]
               ([Id], [Name], [IsDeleted])
			   VALUES 
			   (1, N'EmailServices', 0)
    SET IDENTITY_INSERT [dbo].[Activity]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageType] WHERE Id IN (0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageType]  ON

    INSERT INTO [dbo].[UiPageType]
               ([Id], [Name], [IsDeleted])
			   VALUES
              (1, N'Ui Page Type', 0),
			  (2, N'Ui Control Type', 0),
			  (3, N'Ui Page Metadata', 0),
			  (4, N'Ui Page Validation', 0),
			  (5, N'Home', 0),
			  (6, N'My Activity', 0),
			  (8, N'Nabl', 0),
			  (10, N'Sample Recieving', 0),
			  (11, N'Test Plan', 0),
			  (12, N'Page1', 0),
			  (13, N'Page2', 0),
			  (14, N'Customer', 0),
			  (15, N'Sample Recieving ', 0),
			  (16, N'Test Plan', 0),
			  (17, N'Lab Analysis', 0),
			  (18, N'Test Reports', 0),
			  (19, N'Bill & Payment', 0)
    SET IDENTITY_INSERT [dbo].[UiPageType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Workflow] WHERE Id IN (1,2,3))
BEGIN
    SET IDENTITY_INSERT [dbo].[Workflow]  ON

    INSERT INTO [dbo].[Workflow]
              ([Id], [Name], [ModuleId], [IsDeleted])
			   VALUES
              (1, N'Cube Testing Flow', 1, 0),
			  (2, N'Water Testing Flow', 2, 0),
			  (3, N'Customer', 3, 0)
    SET IDENTITY_INSERT [dbo].[Workflow]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [WorkflowStage] WHERE Id IN (2,3,4,5,9,10))
BEGIN
    SET IDENTITY_INSERT [dbo].[WorkflowStage]  ON

    INSERT INTO [dbo].[WorkflowStage]
               ([Id], [Name], [IsDeleted], [WorkflowId], [UiPageTypeId], [Orders])
			   VALUES
             (2, N'Sample Receiving', 0, 1, 15, 0),
			 (3, N'Test Plan', 0, 1, 16, 1),
			 (4, N'Lab Analysis', 0, 1, 17, 2),
			 (5, N'Test Report', 0, 1, 18, 3),
			 (9, N'Billing & Payments', 0, 1, 19, 4),
			 (10, N'Customer', 0, 3, 14, 0)
    SET IDENTITY_INSERT [dbo].[WorkflowStage]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [ActivityMetadata] WHERE Id IN (1,2,3,4,5,7,9,12))
BEGIN
    SET IDENTITY_INSERT [dbo].[ActivityMetadata]  ON

    INSERT INTO [dbo].[ActivityMetadata]
               ([Id], [Name], [ActivityId], [UiPageMetadataId], [IsDeleted], [Value], [ActivityMetadataTypeId], [WorkflowStageId])
			   VALUES
              (1, N'**Email**', 1, 21, 0, NULL, 1016, 2),
			  (2, N'**Subject**', 1, 35, 0, N'Sample Recived Successfully ??', 1015, 2),
			  (3, N'HtmlMsg', 1, 36, 0, N'emailformat/SampleRecived.txt', 1015, 2),
			  (4, N'Name', 1, 3021, 0, NULL, 1016, 2),
			  (5, N'Email', 1, 21, 0, NULL, 1015, 4),
			  (7, N'HtmlMsg', 1, 36, 0, N'emailformat/LabAnalysis.txt', 1015, 4),
			  (9, N'Subject', 1, 35, 0, N'Report Is Ready For Your Review', 1015, 4),
			  (12, N'**name**', 1, 3021, 0, N'Rishi Kumar', 1015, 4)
    SET IDENTITY_INSERT [dbo].[ActivityMetadata]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UserRole] WHERE Id IN (0))
BEGIN
    SET IDENTITY_INSERT [dbo].[UserRole]  ON

    INSERT INTO [dbo].[UserRole]
              ([Id], [UserId], [RoleId], [IsDeleted])
			   VALUES
              (0, 0, 0, 0)
    SET IDENTITY_INSERT [dbo].[UserRole]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageMetadataModuleBridge] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageMetadataModuleBridge]  ON

    INSERT INTO [dbo].[UiPageMetadataModuleBridge]
               ([Id], [UiPageMetadataId], [UiPageTypeId], [IsDeleted], [ModuleId], [ParentId], [Orders], [UiControlDisplayName], [MultiValueControl])
			   VALUES
            (3011, 3012, 14, 0, 3, 0, 0, NULL, 0),
			(3012, 3013, 14, 0, 3, 0, 0, NULL, 0),
			(3013, 3014, 14, 0, 3, 0, 0, NULL, 0),
			(3014, 21, 14, 0, 3, 0, 0, NULL, 0),
			(3015, 20, 14, 0, 3, 0, 0, NULL, 0),
			(3016, 17, 14, 0, 3, 0, 0, NULL, 0),
			(3017, 3016, 15, 0, 1, 4, 0, NULL, 0),
			(3018, 3017, 15, 0, 1, 4, 0, NULL, 0),
			(3019, 3018, 15, 0, 1, 4, 0, NULL, 0),
			(3020, 3019, 15, 0, 1, 4, 0, NULL, 0),
			(3021, 3020, 15, 0, 1, 4, 0, NULL, 0),
			(3022, 3021, 15, 0, 1, 4, 0, NULL, 0),
			(3023, 21, 15, 0, 1, 4, 0, NULL, 0),
			(3024, 20, 15, 0, 1, 4, 0, NULL, 0),
			(3025, 3024, 15, 0, 1, 4, 0, NULL, 0),
			(3026, 3025, 15, 0, 1, 4, 0, NULL, 0),
			(3029, 3026, 15, 0, 1, 4, 0, NULL, 0),
			(3030, 3027, 16, 0, 1, 5, 0, NULL, 0),
			(3031, 3028, 16, 0, 1, 5, 0, NULL, 0),
			(3032, 3029, 16, 0, 1, 5, 0, NULL, 0),
			(3033, 3030, 16, 0, 1, 5, 0, NULL, 0),
			(3034, 3031, 16, 0, 1, 5, 0, NULL, 0),
			(3035, 3032, 16, 0, 1, 5, 0, NULL, 0),
			(3037, 3034, 16, 0, 1, 5, 0, NULL, 0),
			(3038, 3035, 16, 0, 1, 5, 0, NULL, 0),
			(3039, 3036, 16, 0, 1, 5, 0, NULL, 0),
			(3040, 3019, 16, 0, 1, 5, 0, NULL, 0),
			(3041, 3037, 16, 0, 1, 5, 0, NULL, 0),
			(3042, 3038, 16, 0, 1, 5, 0, NULL, 0),
			(3043, 3039, 16, 0, 1, 5, 0, NULL, 0),
			(3044, 3008, 15, 0, 1, 4, 1, NULL, 0),
			(3045, 3008, 16, 0, 1, 5, 2, NULL, 0),
			(3047, 3, 15, 0, 1, 0, 0, NULL, 0),
			(3048, 4, 15, 0, 1, 3, 0, NULL, 0),
			(3049, 5, 15, 0, 1, 3, 0, NULL, 0),
			(3050, 6, 15, 0, 1, 3, 0, NULL, 0),
			(3051, 7, 15, 0, 1, 3, 0, NULL, 0),
			(3052, 8, 15, 0, 1, 3, 0, NULL, 0),
			(3053, 3, 16, 0, 1, 0, 0, NULL, 0),
			(3054, 4, 16, 0, 1, 3, 0, NULL, 0),
			(3055, 5, 16, 0, 1, 3, 0, NULL, 0),
			(3056, 6, 16, 0, 1, 3, 0, NULL, 0),
			(3057, 7, 16, 0, 1, 3, 0, NULL, 0),
			(3058, 8, 16, 0, 1, 3, 0, NULL, 0),
			(3059, 3, 17, 0, 1, 0, 0, NULL, 0),
			(3060, 4, 17, 0, 1, 3, 0, NULL, 0),
			(3061, 5, 17, 0, 1, 3, 0, NULL, 0),
			(3062, 6, 17, 0, 1, 3, 0, NULL, 0),
			(3063, 7, 17, 0, 1, 3, 0, NULL, 0),
			(3064, 8, 17, 0, 1, 3, 0, NULL, 0),
			(3065, 3040, 17, 0, 1, 6, 0, NULL, 0),
			(3066, 3041, 17, 0, 1, 6, 0, NULL, 0),
			(3067, 3043, 17, 0, 1, 6, 0, NULL, 0),
			(3068, 3044, 17, 0, 1, 6, 0, NULL, 0),
			(3069, 3045, 17, 1, 1, 6, 0, NULL, 0),
			(3070, 3046, 17, 1, 1, 6, 0, NULL, 0),
			(3071, 3047, 17, 0, 1, 6, 0, NULL, 0),
			(3072, 3048, 17, 0, 1, 6, 0, NULL, 0),
			(3073, 3049, 18, 0, 1, 6, 0, NULL, 1),
			(3074, 3050, 18, 0, 1, 6, 0, NULL, 1),
			(3075, 3051, 18, 0, 1, 6, 0, NULL, 1),
			(3077, 3053, 18, 0, 1, 6, 0, NULL, 1),
			(3078, 3054, 18, 0, 1, 6, 0, NULL, 1),
			(3080, 3056, 18, 0, 1, 6, 0, NULL, 1),
			(3081, 3057, 18, 0, 1, 6, 0, NULL, 1),
			(3082, 3008, 17, 0, 1, 6, 1, NULL, 0),
			(3083, 3, 18, 0, 1, 0, 0, NULL, 0),
			(3084, 4, 18, 0, 1, 3, 0, N'Sample Reciving', 0),
			(3085, 5, 18, 0, 1, 3, 0, N'Test Plan', 0),
			(3086, 6, 18, 0, 1, 3, 0, N'Lab Analysis', 0),
			(3087, 7, 18, 0, 1, 3, 0, N'Test Report', 0),
			(3088, 8, 18, 0, 1, 3, 0, N'Payment & Billing', 0),
			(3089, 3058, 18, 0, 1, 7, 19, N'Download', 0),
			(3090, 3016, 18, 0, 1, 7, 1, NULL, 0),
			(3091, 3017, 18, 0, 1, 7, 2, NULL, 0),
			(3092, 3018, 18, 0, 1, 7, 3, NULL, 0),
			(3093, 3019, 18, 0, 1, 7, 4, NULL, 0),
			(3094, 3020, 18, 0, 1, 7, 5, NULL, 0),
			(3095, 3021, 18, 0, 1, 7, 6, NULL, 0),
			(3096, 21, 18, 0, 1, 7, 7, NULL, 0),
			(3097, 20, 18, 0, 1, 7, 8, NULL, 0),
			(3098, 3024, 18, 0, 1, 7, 9, NULL, 0),
			(3099, 3025, 18, 0, 1, 7, 0, NULL, 0),
			(3100, 3, 19, 0, 1, 0, 0, NULL, 0),
			(3101, 4, 19, 0, 1, 3, 0, NULL, 0),
			(3102, 5, 19, 0, 1, 3, 0, NULL, 0),
			(3103, 6, 19, 0, 1, 3, 0, NULL, 0),
			(3104, 7, 19, 0, 1, 3, 0, NULL, 0),
			(3105, 8, 19, 0, 1, 3, 0, NULL, 0),
			(3106, 3059, 19, 0, 1, 8, 0, NULL, 0),
			(3107, 3060, 19, 0, 1, 8, 1, NULL, 0),
			(3108, 3061, 19, 0, 1, 8, 2, NULL, 0),
			(3110, 3062, 19, 0, 1, 8, 3, N'Download Report', 0),
			(3111, 3008, 19, 0, 1, 8, 3, NULL, 0),
			(3112, 3008, 18, 0, 1, 7, 16, NULL, 0),
			(3113, 3040, 18, 0, 1, 7, 10, NULL, 0),
			(3114, 3041, 18, 0, 1, 7, 11, NULL, 0),
			(3116, 3043, 18, 0, 1, 7, 12, NULL, 0),
			(3117, 3044, 18, 0, 1, 7, 13, NULL, 0),
			(3118, 3045, 18, 0, 1, 7, 14, NULL, 0),
			(3119, 3046, 18, 0, 1, 7, 15, NULL, 0),
			(3120, 3063, 18, 0, 1, 7, 17, NULL, 0),
			(3121, 3049, 17, 0, 1, 6, 0, NULL, 1),
			(3122, 3050, 17, 0, 1, 6, 0, NULL, 1),
			(3123, 3051, 17, 0, 1, 6, 0, NULL, 1),
			(3124, 3053, 17, 0, 1, 6, 0, NULL, 1),
			(3126, 3054, 17, 0, 1, 6, 0, NULL, 1),
			(3127, 3056, 17, 0, 1, 6, 0, NULL, 1),
			(3129, 3057, 17, 0, 1, 6, 0, NULL, 1),
			(3130, 3063, 17, 0, 1, 6, 20, NULL, 0)
    SET IDENTITY_INSERT [dbo].[UiPageMetadataModuleBridge]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageValidationType] WHERE Id IN (1,2,3,4,5,6,7))
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageValidationType]  ON

    INSERT INTO [dbo].[UiPageValidationType]
              ([Id], [Name], [Message], [Value], [IsDeleted])
			   VALUES
             (1, N'MinPasswordLength', N'Minimum Password length  is 8', N'8', 0),
			 (2, N'Email', N'Email should have a fromat', N'3', 0),
			 (3, N'AdharLength', N'AdharLength should be equal to 12', N'12', 0),
			 (4, N'MobileNumberLength', N'Mobile Number length is equal to 10', N'10', 0),
			 (5, N'Year', N'Year length is equal to 4', N'4', 0),
			 (6, N'Name', N'Name should have more than 3 letters', N'3', 1),
			 (7, N'IsRequired', N'{0} Field is rquired', N'', 0)
    SET IDENTITY_INSERT [dbo].[UiPageValidationType]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageValidation] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageValidation]  ON

    INSERT INTO [dbo].[UiPageValidation]
             ([Id], [UiPageTypeId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted])
			   VALUES
             (2, 8, 12, 4, 1),
			 (3, 10, 3008, 7, 1),
			 (4, 10, 3008, 7, 0),
			 (5, 10, 3010, 7, 0),
			 (6, 15, 3016, 7, 0),
			 (7, 15, 3017, 7, 0),
			 (8, 15, 3018, 7, 0),
			 (9, 15, 3019, 7, 0),
			 (10, 15, 3020, 7, 0),
			 (11, 18, 3049, 7, 0),
			 (12, 18, 3050, 7, 0),
			 (13, 18, 3056, 7, 0),
			 (14, 17, 3049, 7, 0),
			 (15, 17, 3050, 7, 0),
			 (16, 17, 3056, 7, 0)
    SET IDENTITY_INSERT [dbo].[UiPageValidation]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [PasswordLogin] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[PasswordLogin]  ON

    INSERT INTO [dbo].[PasswordLogin]
              ([Id], [PasswordHash], [PasswordSalt], [UserId], [ChangeDate])
			  VALUES 
			  (0, N'qnVDMZYlsGjs4chNs1/qPidI70eDUZ1fzUF5EdCqdl0=', N'NDlzcm0GY1GqMgn+urXX9Q==', 0, CAST(N'2022-11-12T14:25:35.763' AS DateTime))
    SET IDENTITY_INSERT [dbo].[PasswordLogin]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [TestReport] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[TestReport]  ON

    INSERT INTO [dbo].[TestReport]
              ([Id], [Client], [Filepath], [Email], [JobId], [Name], [DateTime], [IsDeleted])
			  VALUES 
			  (1, N'dfg', N'1VkPUk0WjPRj6rCulYq_9xU9FeCGFm1oa', N'jg@gh.hvbv', N'dgdfg', N'dfg', CAST(N'2022-11-14T00:00:00.000' AS DateTime), 0)
    SET IDENTITY_INSERT [dbo].[TestReport]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [WorkflowActivity] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[WorkflowActivity]  ON

    INSERT INTO [dbo].[WorkflowActivity]
              ([Id], [Name], [WorkflowStageId], [IsDeleted], [ActivityId])
			  VALUES 
			  (1, N'EmailAc', 2, 0, 1),
			  (2, N'EmailFirst', 4, 0, 1)
    SET IDENTITY_INSERT [dbo].[WorkflowActivity]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [Record] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[Record]  ON

    INSERT INTO [dbo].[Record]
              ([Id], [IsDeleted], [ModuleId], [WorkflowStageId], [UpdatedDate])
			  VALUES 
			  (12063, 0, 1, 4, CAST(N'2023-02-18T00:07:18.197' AS DateTime))
    SET IDENTITY_INSERT [dbo].[Record]  OFF
END
GO
IF NOT EXISTS (SELECT 1 FROM [UiPageData] WHERE Id = 0)
BEGIN
    SET IDENTITY_INSERT [dbo].[UiPageData]  ON

    INSERT INTO [dbo].[UiPageData]
              ([Id],
			  [UiPageMetadataId],
			  [Value],
			  [IsDeleted],
			  [RecordId],
			  [UiPageTypeId],
			  [SubRecordId])
			  VALUES 
			  (13187, 3016, N'124', 0, 12063, 15, NULL),
			  (13188, 3017, N'Software', 0, 12063, 15, NULL),
			  (13189, 3018, N'Rishi Rao', 0, 12063, 15, NULL),
			  (13190, 3019, N'2023-02-17', 0, 12063, 15, NULL),
			  (13191, 3020, N'14', 0, 12063, 15, NULL),
			  (13192, 3021, N'Himanshu Jaiswal', 0, 12063, 15, NULL),
			  (13193, 21, N'rajkumar00999.rk@gmail.com', 0, 12063, 15, NULL),
			  (13194, 20, N'9308337299', 0, 12063, 15, NULL),
			  (13195, 3024, N'2023-02-22', 0, 12063, 15, NULL),
			  (13196, 3025, N'Want Mobile Support', 0, 12063, 15, NULL),
			  (13197, 3026, N'', 0, 12063, 15, NULL),
			  (13198, 3008, N'4', 0, 12063, 19, NULL),
			  (13199, 3027, N'Website', 0, 12063, 16, NULL),
			  (13200, 3028, N'RajguptaH.Github.io', 0, 12063, 16, NULL),
			  (13201, 3029, N'2023-02-27', 0, 12063, 16, NULL),
			  (13202, 3030, N'124', 0, 12063, 16, NULL),
			  (13203, 3031, N'45', 0, 12063, 16, NULL),
			  (13204, 3032, N'5', 0, 12063, 16, NULL),
			  (13205, 3034, N'Website Testing With Mobility', 0, 12063, 16, NULL),
			  (13206, 3035, N'Dot Net', 0, 12063, 16, NULL),
			  (13207, 3036, N'Ritesh Kumar', 0, 12063, 16, NULL),
			  (13208, 3037, N'2023-02-28', 0, 12063, 16, NULL),
			  (13209, 3038, N'2023-03-09', 0, 12063, 16, NULL),
			  (13210, 3039, N'This Needs To Done Within Five Days', 0, 12063, 16, NULL),
			  (13211, 3040, N'2023-02-22', 0, 12063, 18, NULL),
			  (13212, 3041, N'124', 0, 12063, 17, NULL),
			  (13213, 3043, N'85', 0, 12063, 17, NULL),
			  (13214, 3044, N'2023-02-21', 0, 12063, 17, NULL),
			  (13215, 3047, N'512', 0, 12063, 17, NULL),
			  (13216, 3048, N'512', 0, 12063, 17, NULL),
			  (13217, 3045, N'25years', 0, 12063, 18, NULL),
			  (13218, 3046, N'5cm', 0, 12063, 18, NULL),
			  (13219, 3049, N'12', 0, 12063, 18, 1),
			  (13220, 3050, N'95', 0, 12063, 18, 1),
			  (13221, 3051, N'22', 0, 12063, 18, 1),
			  (13222, 3053, N'45', 0, 12063, 18, 1),
			  (13223, 3054, N'2456', 0, 12063, 18, 1),
			  (13224, 3056, N'1324', 0, 12063, 18, 1),
			  (13225, 3057, N'2.2', 0, 12063, 18, 1),
			  (13226, 3049, N'58', 0, 12063, 18, 2),
			  (13227, 3050, N'654', 0, 12063, 18, 2),
			  (13228, 3051, N'45', 0, 12063, 18, 2),
			  (13229, 3053, N'68', 0, 12063, 18, 2),
			  (13230, 3054, N'498', 0, 12063, 18, 2),
			  (13231, 3056, N'34546', 0, 12063, 18, 2),
			  (13232, 3057, N'3.12', 0, 12063, 18, 2),
			  (13233, 3049, N'4', 0, 12063, 18, 3),
			  (13234, 3050, N'56.00', 0, 12063, 18, 3),
			  (13235, 3051, N'46', 0, 12063, 18, 3),
			  (13236, 3053, N'8.00', 0, 12063, 18, 3),
			  (13237, 3054, N'42.00', 0, 12063, 18, 3),
			  (13238, 3056, N'676', 0, 12063, 18, 3),
			  (13239, 3057, N'465741', 0, 12063, 18, 3),
			  (13240, 3049, N'54', 0, 12063, 18, 4),
			  (13241, 3050, N'4', 0, 12063, 18, 4),
			  (13242, 3051, N'4', 0, 12063, 18, 4),
			  (13243, 3053, N'6', 0, 12063, 18, 4),
			  (13244, 3054, N'87', 0, 12063, 18, 4),
			  (13245, 3056, N'6465', 0, 12063, 18, 4),
			  (13246, 3057, N'46', 0, 12063, 18, 4),
			  (13247, 3049, N'45', 1, 12063, 18, 5),
			  (13248, 3050, N'12', 1, 12063, 18, 5),
			  (13249, 3051, N'54', 1, 12063, 18, 5),
			  (13250, 3053, N'867', 1, 12063, 18, 5),
			  (13251, 3054, N'4', 1, 12063, 18, 5),
			  (13252, 3056, N'654', 1, 12063, 18, 5),
			  (13253, 3057, N'76', 1, 12063, 18, 5),
			  (13254, 3049, N'4', 0, 12063, 18, 6),
			  (13255, 3050, N'3', 0, 12063, 18, 6),
			  (13256, 3051, N'43', 0, 12063, 18, 6),
			  (13257, 3053, N'534', 0, 12063, 18, 6),
			  (13258, 3054, N'345', 0, 12063, 18, 6),
			  (13259, 3056, N'345', 0, 12063, 18, 6),
			  (13260, 3057, N'345', 0, 12063, 18, 6),
			  (13261, 3049, N'43', 0, 12063, 18, 7),
			  (13262, 3050, N'465', 0, 12063, 18, 7),
			  (13263, 3051, N'312', 0, 12063, 18, 7),
			  (13264, 3053, N'5', 0, 12063, 18, 7),
			  (13265, 3054, N'31', 0, 12063, 18, 7),
			  (13266, 3056, N'65', 0, 12063, 18, 7),
			  (13267, 3057, N'132', 0, 12063, 18, 7),
			  (13268, 3059, N'500.00', 0, 12063, 19, NULL),
			  (13269, 3060, N'250.00', 0, 12063, 19, NULL),
			  (13270, 3061, N'750.00', 0, 12063, 19, NULL)
    SET IDENTITY_INSERT [dbo].[UiPageData]  OFF
END
GO