UPDATE AppConfig
SET DataSource = 'select HTYPE,HTYPE_DISP +''-''+ TYPE_NAME from HcodeType where dbo.getcodefilter(''HcodeType'',HTYPE,@userid,@comp,@admin)=1'
WHERE Category = 'FRM4P'
and code = 'LeaveTypeCode'
GO