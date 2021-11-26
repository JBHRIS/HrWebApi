

CREATE function [dbo].[GetForgetByNobr](@nobr nvarchar(50),@bdate datetime,@edate datetime)
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	set @value = 0
	select @value = SUM(a.FORGET) from ATTEND a
	where NOBR =@nobr and a.ADATE between @bdate and @edate
	return @value
end