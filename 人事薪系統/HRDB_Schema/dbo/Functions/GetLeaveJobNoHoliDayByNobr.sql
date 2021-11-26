

CREATE function [dbo].[GetLeaveJobNoHoliDayByNobr](@nobr nvarchar(50),@bdate datetime,@edate datetime)
returns decimal(16,2)
as
begin
	declare @i decimal(16,2)
	set @i=0
		select @i = (
((select DATEDIFF(day,@bdate,@edate)+1)-
(select COUNT(1) from ATTEND where nobr = @nobr and ADATE between @bdate and @edate))-
((select count(1) from dbo.GetHoliByNobr(@nobr,@bdate,@edate))- 
(select count(1) from dbo.GetOnJobHoliByNobr(@nobr,@bdate,@edate))))
	return @i
end