update AppConfig
set DataSource = 'select HTYPE,HTYPE_DISP +''-''+ TYPE_NAME from HcodeType where dbo.getcodefilter(''HcodeType'',HTYPE,@userid,@comp,@admin)=1'
where code = 'AnnualLeaveTypeCode' and Category = 'FRM4O'
GO

update AppConfig
set DataSource = 'select HTYPE,HTYPE_DISP +''-''+ TYPE_NAME from HcodeType where dbo.getcodefilter(''HcodeType'',HTYPE,@userid,@comp,@admin)=1'
where code = 'AdvanceLeaveHcodeType' and Category = 'FRM4ADV'
GO

update AppConfig
set ControlType = 'ComboBox',
DataSource = 'select HTYPE,HTYPE_DISP +''-''+ TYPE_NAME from HcodeType where dbo.getcodefilter(''HcodeType'',HTYPE,@userid,@comp,@admin)=1'
where code = 'Remain_AnnualType' and Category = 'ZZ42'
GO

update AppConfig
set ControlType = 'ComboBox',
DataSource = 'select HTYPE,HTYPE_DISP +''-''+ TYPE_NAME from HcodeType where dbo.getcodefilter(''HcodeType'',HTYPE,@userid,@comp,@admin)=1'
where code = 'Remain_RestType' and Category = 'ZZ42'
GO