create function [dbo].[DateBetween](@date datetime,@from datetime,@to datetime)
returns bit
as
begin
	declare @dd datetime
	declare @d1 datetime
	declare @d2 datetime
	set @dd=dbo.getdateformat(@date)
	set @d1=dbo.getdateformat(@from)
	set @d2=dbo.getdateformat(@to)
	declare @rtn bit
	if(@dd>=@d1 and @dd<=@d2)
		set @rtn=1
	else set @rtn =0
	return @rtn
end
