UPDATE abs
set Balance = TOL_HOURS ,LeaveHours = 0, Guid = NEWID()
WHERE H_CODE = 'W' and Balance is null
GO