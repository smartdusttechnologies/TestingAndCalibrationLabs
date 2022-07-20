USE [TestingAndCalibrationLabs]
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] ON 
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (2, 1, 1, 1, N'Name', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (3, 1, 2, 1, N'Password', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (7, 1, 12, 0, N'Adhar card', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1034, 1, 1, 1, N'Company', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1035, 1, 12, 1, N'Mobile Number', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1036, 1, 12, 1, N'year', 0, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1037, 1, 18, 0, N'Search', 1, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1039, 1, 3, 1, N'Clickme', 1, N'string')
GO
INSERT [dbo].[UiPageMetadata] ([Id], [UiPageId], [UiControlTypeId], [IsRequired], [UiControlDisplayName], [IsDeleted], [DataType]) VALUES (1049, 1, 22, 0, N'Date', 1, N'string')
GO
SET IDENTITY_INSERT [dbo].[UiPageMetadata] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageType] ON 
GO
INSERT [dbo].[UiPageType] ([Id], [Name], [IsDeleted]) VALUES (1, N'SamplePage', 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageType] OFF
GO
SET IDENTITY_INSERT [dbo].[Record] ON 
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1008, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1009, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1010, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1011, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1013, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1014, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1015, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1016, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1017, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1020, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1021, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1022, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1023, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1028, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1029, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1030, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1031, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1032, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1033, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1034, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1035, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1036, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1037, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1038, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1039, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1040, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1041, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1042, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1043, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1044, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1045, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1046, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1047, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1048, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1049, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1050, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1051, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1052, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1053, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1054, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1055, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1056, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1057, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1058, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1059, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1060, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1061, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (1062, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2052, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2053, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2054, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2055, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2056, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2057, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2058, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2059, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2060, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2061, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2062, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2063, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2064, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2065, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2066, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2067, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2068, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2069, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2070, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2072, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2073, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2074, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2075, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2076, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2077, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2078, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2079, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2080, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2081, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2082, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2083, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2084, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2085, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2086, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2087, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2088, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2089, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2090, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2091, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2092, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2093, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2094, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2095, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2096, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2097, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2098, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2099, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2100, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2101, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2102, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2103, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2104, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2105, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2106, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2107, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2108, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2109, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2110, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2111, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2112, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2113, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2114, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2115, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2116, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2117, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2118, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2119, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2120, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2121, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2122, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2123, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2124, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2125, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2126, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2127, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2128, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2129, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2130, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2131, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2132, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2133, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2134, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2135, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2136, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2137, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2138, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2139, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2140, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2141, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2142, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2143, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2144, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2145, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2146, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2147, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2148, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2149, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2150, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2151, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2152, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2153, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2154, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2155, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2156, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2157, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2158, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2159, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2160, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2161, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2162, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2163, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2164, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2165, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2166, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2167, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2168, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2169, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2170, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2171, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2172, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2173, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2174, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2175, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2176, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2177, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2178, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2179, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2180, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2181, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2182, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2183, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2184, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2185, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2186, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2187, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2188, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2189, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2190, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2191, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2192, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2193, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2194, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2195, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2196, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2197, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2198, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2199, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2200, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2201, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2202, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2203, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2204, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2205, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2206, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2207, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2208, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2209, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2210, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2211, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2212, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2213, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2214, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2215, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2216, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2217, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2218, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (2219, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3149, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3150, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3151, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3152, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3153, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3154, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3155, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3156, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3157, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3158, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3159, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3160, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3161, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3162, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3163, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3164, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3165, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3166, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3167, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3168, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3169, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3170, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3171, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3172, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3173, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3174, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3175, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3176, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3177, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3178, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3179, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3180, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3181, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3182, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3183, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3184, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3185, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3186, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3187, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3189, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3190, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3191, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3192, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3193, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3194, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3195, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3196, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3197, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3198, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3199, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3200, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3201, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3202, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3203, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3204, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3205, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3206, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3207, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3208, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3209, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3210, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3211, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3212, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3213, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3214, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3215, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3216, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3217, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3218, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3219, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3220, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3221, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3222, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3223, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3224, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3225, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3226, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3227, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3228, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3229, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3230, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3231, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3232, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3233, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3234, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3235, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3236, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3237, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3238, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3239, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3240, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3241, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3242, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3243, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3244, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3245, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3246, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3247, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3248, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3249, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3250, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3251, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3252, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3253, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3254, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3255, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3256, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3257, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3258, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3259, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3260, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3261, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3262, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3263, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3264, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3265, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3266, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3267, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3268, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3269, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3270, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3271, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3272, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3273, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3274, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3275, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3276, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3277, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3278, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3279, 1, 0)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3280, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3281, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3282, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3283, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3284, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3285, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3286, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3287, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3288, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3289, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3290, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3291, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3292, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3293, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3294, 1, 1)
GO
INSERT [dbo].[Record] ([Id], [UiPageId], [IsDeleted]) VALUES (3295, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Record] OFF
GO
SET IDENTITY_INSERT [dbo].[UiPageData] ON 
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4106, 2, N'Sushil Smartdus1', 1, 0, 3271)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4107, 3, N'111111111111111111', 1, 0, 3271)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4108, 7, N'111122223334', 1, 0, 3271)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4109, 1034, N'jbk', 1, 0, 3271)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4110, 1035, N'9480914324', 1, 0, 3271)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4111, 1036, N'1235', 1, 0, 3271)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4112, 2, N'Rishi Kumar', 1, 0, 3272)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4113, 3, N'1234567777', 1, 0, 3272)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4114, 7, N'123456789012', 1, 0, 3272)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4115, 1034, N'Smartdust', 1, 0, 3272)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4116, 1035, N'9480914324', 1, 0, 3272)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4117, 1036, N'1234', 1, 0, 3272)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4118, 2, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4119, 3, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4120, 7, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4121, 1034, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4122, 1035, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4123, 1036, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4124, 1037, N'', 1, 0, 3273)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4125, 2, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4126, 3, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4127, 7, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4128, 1034, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4129, 1035, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4130, 1036, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4131, 1037, N'', 1, 0, 3274)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4132, 2, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4133, 3, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4134, 7, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4135, 1034, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4136, 1035, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4137, 1036, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4138, 1037, N'', 1, 0, 3275)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4139, 2, N'Sushil Smartdust', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4140, 3, N'', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4141, 7, N'', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4142, 1034, N'jbk', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4143, 1035, N'9480914324', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4144, 1036, N'', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4145, 1037, N'', 1, 0, 3276)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4146, 2, N'Sushil Smartdust', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4147, 3, N'12345678', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4148, 7, N'123456789012', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4149, 1034, N'jbk', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4150, 1035, N'9480914324', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4151, 1036, N'1004', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4152, 1037, N'', 1, 0, 3277)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4153, 2, N'Sushil Smartdust', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4154, 3, N'1234567890', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4155, 7, N'123.6456789120', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4156, 1034, N'jbk', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4157, 1035, N'9480914324', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4158, 1036, N'1024', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4159, 1037, N'', 1, 0, 3278)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4160, 2, N'Sushil Smartdust', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4161, 3, N'1234567890', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4162, 7, N'1233456789012', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4163, 1034, N'jbk', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4164, 1035, N'9480914324', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4165, 1036, N'1024', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4166, 1037, N'', 1, 0, 3279)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4167, 2, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4168, 3, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4169, 7, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4170, 1034, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4171, 1035, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4172, 1036, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4173, 1037, N'', 1, 0, 3280)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4174, 2, N'', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4175, 3, N'123456789', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4176, 7, N'123456789012', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4177, 1034, N'jbk', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4178, 1035, N'9480914324', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4179, 1036, N'1024', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4180, 1037, N'', 1, 0, 3281)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4181, 2, N'Sushil Smartdust', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4182, 3, N'1234567890', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4183, 7, N'123456789012', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4184, 1034, N'jbk', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4185, 1035, N'9480914324', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4186, 1036, N'1024', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4187, 1037, N'', 1, 0, 3282)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4188, 2, N'', 1, 0, 3283)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4189, 3, N'123456789', 1, 0, 3283)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4190, 7, N'123456789012', 1, 0, 3283)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4191, 1034, N'jbk', 1, 0, 3283)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4192, 1035, N'9480914324', 1, 0, 3283)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4193, 1036, N'1024', 1, 0, 3283)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4194, 2, N'', 1, 0, 3284)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4195, 3, N'', 1, 0, 3284)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4196, 7, N'', 1, 0, 3284)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4197, 1034, N'', 1, 0, 3284)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4198, 1035, N'', 1, 0, 3284)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4199, 1036, N'', 1, 0, 3284)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4200, 2, N'', 1, 0, 3285)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4201, 3, N'', 1, 0, 3285)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4202, 7, N'', 1, 0, 3285)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4203, 1034, N'', 1, 0, 3285)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4204, 1035, N'', 1, 0, 3285)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4205, 1036, N'', 1, 0, 3285)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4206, 2, N'', 1, 0, 3286)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4207, 3, N'', 1, 0, 3286)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4208, 7, N'', 1, 0, 3286)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4209, 1034, N'', 1, 0, 3286)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4210, 1035, N'', 1, 0, 3286)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4211, 1036, N'', 1, 0, 3286)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4212, 2, N'', 1, 0, 3287)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4213, 3, N'', 1, 0, 3287)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4214, 7, N'', 1, 0, 3287)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4215, 1034, N'', 1, 0, 3287)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4216, 1035, N'', 1, 0, 3287)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4217, 1036, N'', 1, 0, 3287)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4218, 2, N'Sushil Smartdust', 1, 0, 3288)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4219, 3, N'', 1, 0, 3288)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4220, 7, N'', 1, 0, 3288)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4221, 1034, N'jbk', 1, 0, 3288)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4222, 1035, N'9480914324', 1, 0, 3288)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4223, 1036, N'', 1, 0, 3288)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4224, 2, N'Sushil Smartdust', 1, 0, 3289)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4225, 3, N'', 1, 0, 3289)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4226, 7, N'', 1, 0, 3289)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4227, 1034, N'jbk', 1, 0, 3289)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4228, 1035, N'9480914324', 1, 0, 3289)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4229, 1036, N'', 1, 0, 3289)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4230, 2, N'', 1, 0, 3290)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4231, 3, N'', 1, 0, 3290)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4232, 7, N'', 1, 0, 3290)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4233, 1034, N'', 1, 0, 3290)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4234, 1035, N'', 1, 0, 3290)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4235, 1036, N'', 1, 0, 3290)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4236, 2, N'', 1, 0, 3291)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4237, 3, N'', 1, 0, 3291)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4238, 7, N'', 1, 0, 3291)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4239, 1034, N'', 1, 0, 3291)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4240, 1035, N'', 1, 0, 3291)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4241, 1036, N'', 1, 0, 3291)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4242, 2, N'', 1, 0, 3292)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4243, 3, N'', 1, 0, 3292)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4244, 7, N'', 1, 0, 3292)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4245, 1034, N'', 1, 0, 3292)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4246, 1035, N'', 1, 0, 3292)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4247, 1036, N'', 1, 0, 3292)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4248, 2, N'', 1, 0, 3293)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4249, 3, N'', 1, 0, 3293)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4250, 7, N'', 1, 0, 3293)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4251, 1034, N'', 1, 0, 3293)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4252, 1035, N'', 1, 0, 3293)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4253, 1036, N'', 1, 0, 3293)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4254, 2, N'', 1, 0, 3294)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4255, 3, N'', 1, 0, 3294)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4256, 7, N'', 1, 0, 3294)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4257, 1034, N'', 1, 0, 3294)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4258, 1035, N'', 1, 0, 3294)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4259, 1036, N'', 1, 0, 3294)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4260, 2, N'', 1, 0, 3295)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4261, 3, N'12345678', 1, 0, 3295)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4262, 7, N'', 1, 0, 3295)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4263, 1034, N'', 1, 0, 3295)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4264, 1035, N'', 1, 0, 3295)
GO
INSERT [dbo].[UiPageData] ([Id], [UiControlId], [Value], [UiPageId], [IsDeleted], [RecordId]) VALUES (4265, 1036, N'', 1, 0, 3295)
GO
SET IDENTITY_INSERT [dbo].[UiPageData] OFF
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
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (1, 1, 3, 1, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (2, 1, 7, 3, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (3, 1, 1035, 1003, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (4, 1, 1036, 1004, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (5, 1, 2, 1005, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (6, 1, 3, 1006, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (7, 1, 2, 1006, 0)
GO
INSERT [dbo].[UiPageValidation] ([Id], [UiPageId], [UiPageMetadataId], [UiPageValidationTypeId], [IsDeleted]) VALUES (8, 1, 3, 1006, 0)
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] ON 
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (1, N'MinPasswordLength', 0, N'8', N'Minimum Password length  is 8')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (2, N'Email', 0, N'3', N'Email should have a fromat')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (3, N'AdharLength', 0, N'12', N'AdharLength should be equal to 12')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (1003, N'MobileNumberLength', 0, N'10', N'Mobile Number length is equal to 10')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (1004, N'Year', 0, N'4', N'Year length is equal to 4')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (1005, N'Name', 1, N'3', N'Name should have more than 3 letters')
GO
INSERT [dbo].[UiPageValidationType] ([Id], [Name], [IsDeleted], [Value], [Message]) VALUES (1006, N'IsRequired', 0, N'', N'{0} Field is rquired')
GO
SET IDENTITY_INSERT [dbo].[UiPageValidationType] OFF
GO
