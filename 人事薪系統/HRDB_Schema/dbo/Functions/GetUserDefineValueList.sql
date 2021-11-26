Create FUNCTION [dbo].[GetUserDefineValueList](@ParmName nvarchar(50))
RETURNS @TABLE TABLE (Code nvarchar(50),Value varchar(50))
AS
BEGIN  
	INSERT INTO @TABLE (Code,Value)
	select udv.CODE, udv.VALUE from USERDEFINEVALUE  udv
	join USERDEFINELAYOUT udl on udv.CONTROLID = udl.CONTROLID
	where udl.TAG like ('%"ParameterName":"' + @ParmName + '"%')
RETURN
END