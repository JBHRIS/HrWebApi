Create function [dbo].[GetUserDefineValue](@ParmName nvarchar(50),@Code nvarchar(50),@DefaultValue nvarchar(50))
returns nvarchar(50)
as 
begin
	declare @Value nvarchar(50)
	select @Value = udv.VALUE from USERDEFINEVALUE  udv
	join USERDEFINELAYOUT udl on udv.CONTROLID = udl.CONTROLID
	--join USERDEFINEGROUP udg on udl.USERDEFINEGROUPID = udg.USERDEFINEGROUPID
	--join comp on udg.USERDEFINEGROUPID = udg.USERDEFINEGROUPID
	where udl.TAG like ('%"ParameterName":"' + @ParmName + '"%')
	and udv.CODE = @Code
	return isnull(@Value, @DefaultValue)
end