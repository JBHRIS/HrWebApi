

CREATE function [dbo].[GetE_minsCountByNobr](@nobr nvarchar(50),@bdate datetime,@edate datetime)
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	set @value = 0
	select @value = COUNT(a.E_MINS) from ATTEND a
	where NOBR =@nobr and a.ADATE between @bdate and @edate and a.E_MINS >0
	return @value
end