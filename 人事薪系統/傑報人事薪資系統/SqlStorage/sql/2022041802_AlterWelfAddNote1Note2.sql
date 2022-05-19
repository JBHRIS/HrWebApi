alter table [WELF] 
add 
Note1 nvarchar(50) null,
Note2 nvarchar(50) null
GO

IF EXISTS (SELECT 1 FROM WELF WHERE AMT = 0.00 or D_AMT = 0.00)
BEGIN
    update WELF
	set AMT = dbo.Encode(AMT), D_AMT = dbo.Encode(D_AMT)
END
GO
