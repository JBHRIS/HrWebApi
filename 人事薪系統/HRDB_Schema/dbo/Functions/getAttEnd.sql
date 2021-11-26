

create function [dbo].[getAttEnd](@Comp nvarchar(50),@checkDate datetime)
returns datetime
 as
begin
	declare @attmonth int=31
	declare @setDate datetime=@checkDate
	declare @result datetime=dbo.today()
	select @attmonth=ATTMONTH from U_SYS2 where Comp=@Comp
	if(datepart(day,@checkDate)>@attmonth)
		set @setDate=DATEADD(month,1,@setDate)
	set @result=CONVERT(datetime, convert(char(4),DATEPART(YEAR,@setDate))+'/'+convert(char(2),DATEPART(MONTH,@setDate))+'/'+convert(char(2),@attmonth))
	return @result
end