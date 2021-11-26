IF NOT EXISTS (SELECT 1 FROM AppConfig where Category = 'Appconfig' and Code = 'ApplicationName')
BEGIN
    INSERT [dbo].[AppConfig] ( [Category], [Code], [Comp], [NameP], [Value], [Note], [DataType], [ControlType], [DataSource], [Sort],[KeyDate],[KeyMan]) VALUES ( N'Appconfig', N'ApplicationName', N'', N'執行程式名稱', N'JBHR2', N'', N'String', N'TextBox', N'', 0,GETDATE(),'JB')
END

