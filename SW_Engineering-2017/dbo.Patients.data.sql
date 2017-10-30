SET IDENTITY_INSERT [dbo].[Patients] ON
INSERT INTO [dbo].[Patients] ([Patient_ID], [Firstname], [Surname], [DOB], [Address line 1], [Town/City], [County], [Postcode]) VALUES (1, N'David', N'Davidson', N'1954-11-07', N'1 walk road', N'Norwich', N'Norfolk', N'NR127SW')
INSERT INTO [dbo].[Patients] ([Patient_ID], [Firstname], [Surname], [DOB], [Address line 1], [Town/City], [County], [Postcode]) VALUES (2, N'Sarah', N'Eppingworth', N'2012-10-20', N'43 snake lane', N'London', N'RedBridge', N'LN23DNG')
SET IDENTITY_INSERT [dbo].[Patients] OFF
