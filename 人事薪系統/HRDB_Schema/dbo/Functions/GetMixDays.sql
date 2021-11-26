CREATE function [dbo].[GetMixDays](@d11 datetime,@d12 datetime,@d21 datetime,@d22 datetime)
returns decimal
as
begin
	declare @value decimal
	declare @value1 datetime
	declare @value2 datetime
	if(@d11>@d21)
	set @value1=@d11
	else set @value1=@d21
	
	if(@d12<@d22)
	set @value2=@d12
	else set @value2=@d22
	
	set @value=convert(decimal,@value2-@value1+1)
	return @value
end
