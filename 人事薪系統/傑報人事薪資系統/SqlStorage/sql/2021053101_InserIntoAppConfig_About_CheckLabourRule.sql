insert into AppConfig (Category,Code,Comp,NameP,Value,Note,DataType,ControlType,DataSource,Sort,KeyMan,KeyDate)
values ('CheckLabourRule' ,'HcodeOvertimeHours','','排除班別','JBModule.Data.Repo.HcodeOvertimeHoursLabourCheckRule','排除班別','JBModule.Data.dll','TextBox','',10,'JB',GETDATE()),
	　 ('CheckLabourRule' ,'DailyOvertimeHours','','日加班上限','JBModule.Data.Repo.DailyOvertimeHoursLabourCheckRule','每日加班上限','JBModule.Data.dll','TextBox','',20,'JB',GETDATE()),
       ('CheckLabourRule' ,'MonthlyOvertimeHours','','月加班上限','JBModule.Data.Repo.MonthlyOvertimeHoursLabourCheckRule','每月加班上限','JBModule.Data.dll','TextBox','',30,'JB',GETDATE())
GO
insert into AppConfig (Category,Code,Comp,NameP,Value,Note,DataType,ControlType,DataSource,Sort,KeyMan,KeyDate)
values ('CheckLabourRuleParams' ,'RemoveRoteList','','排除指定班別','0Z','排除指定班別','String','TextBox','',1,'JB',GETDATE()),
       ('CheckLabourRuleParams' ,'HolidayList','','休假日班別','00,0Z','休假日班別','String','TextBox','',1,'JB',GETDATE()),
	　 ('CheckLabourRuleParams' ,'HolidayMaxWK_hrs','','休假日工時上限','8','休假日工時上限，超過會以延長工時計算','String','TextBox','',1,'JB',GETDATE()),
       ('CheckLabourRuleParams' ,'DaylyMaxOT_hrs','','日加班上限','4','平日加班上限,超過會進行縮減','String','TextBox','',1,'JB',GETDATE())
GO