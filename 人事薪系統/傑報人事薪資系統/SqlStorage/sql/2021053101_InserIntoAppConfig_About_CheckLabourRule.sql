insert into AppConfig (Category,Code,Comp,NameP,Value,Note,DataType,ControlType,DataSource,Sort,KeyMan,KeyDate)
values ('CheckLabourRule' ,'HcodeOvertimeHours','','�ư��Z�O','JBModule.Data.Repo.HcodeOvertimeHoursLabourCheckRule','�ư��Z�O','JBModule.Data.dll','TextBox','',10,'JB',GETDATE()),
	�@ ('CheckLabourRule' ,'DailyOvertimeHours','','��[�Z�W��','JBModule.Data.Repo.DailyOvertimeHoursLabourCheckRule','�C��[�Z�W��','JBModule.Data.dll','TextBox','',20,'JB',GETDATE()),
       ('CheckLabourRule' ,'MonthlyOvertimeHours','','��[�Z�W��','JBModule.Data.Repo.MonthlyOvertimeHoursLabourCheckRule','�C��[�Z�W��','JBModule.Data.dll','TextBox','',30,'JB',GETDATE())
GO
insert into AppConfig (Category,Code,Comp,NameP,Value,Note,DataType,ControlType,DataSource,Sort,KeyMan,KeyDate)
values ('CheckLabourRuleParams' ,'RemoveRoteList','','�ư����w�Z�O','0Z','�ư����w�Z�O','String','TextBox','',1,'JB',GETDATE()),
       ('CheckLabourRuleParams' ,'HolidayList','','�𰲤�Z�O','00,0Z','�𰲤�Z�O','String','TextBox','',1,'JB',GETDATE()),
	�@ ('CheckLabourRuleParams' ,'HolidayMaxWK_hrs','','�𰲤�u�ɤW��','8','�𰲤�u�ɤW���A�W�L�|�H�����u�ɭp��','String','TextBox','',1,'JB',GETDATE()),
       ('CheckLabourRuleParams' ,'DaylyMaxOT_hrs','','��[�Z�W��','4','����[�Z�W��,�W�L�|�i���Y��','String','TextBox','',1,'JB',GETDATE())
GO