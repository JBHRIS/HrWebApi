



CREATE function [dbo].[GetUnWorkDayByNobr](@nobr nvarchar(50),@bdate datetime,@edate datetime)
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	set @value = 0
	select @value = COUNT(1) from ATTEND a
	where NOBR =@nobr and a.ADATE between @bdate and @edate and a.ABS = 1
	return @value
end