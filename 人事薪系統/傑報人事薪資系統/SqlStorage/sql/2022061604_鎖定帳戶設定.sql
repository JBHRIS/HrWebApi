INSERT [dbo].[sysApiVoid] ([Code], [Name], [RoutePath]) VALUES (N'Token/SetLockEnable', N'鎖定與解鎖帳戶設定', N'Token/SetLockEnable')
GO

INSERT [dbo].[sysApiVoid] ([Code], [Name], [RoutePath]) VALUES (N'Token/GetLoginLimitConfig', N'取得登入錯誤次數上限與解鎖時間設定', N'Token/GetLoginLimitConfig')
GO

INSERT [dbo].[sysApiVoid] ([Code], [Name], [RoutePath]) VALUES (N'Token/UpdateLoginLimitConfig', N'修改登入錯誤次數上限與解鎖時間設定', N'Token/UpdateLoginLimitConfig')
GO
