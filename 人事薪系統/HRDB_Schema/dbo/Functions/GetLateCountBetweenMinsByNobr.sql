


CREATE function [dbo].[GetLateCountBetweenMinsByNobr](@nobr nvarchar(50),@bdate datetime,@edate datetime, @bMins decimal(8,2), @eMins decimal(8,2))
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	set @value = 0
	select @value = COUNT(a.LATE_MINS) from ATTEND a
	where NOBR =@nobr and a.ADATE between @bdate and @edate and a.LATE_MINS between @bMins and @eMins and a.LATE_MINS>0
	return @value
end