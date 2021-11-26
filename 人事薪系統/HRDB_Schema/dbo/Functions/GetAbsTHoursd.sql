/*  指定時間所包含之特休得假區間內所有申請之特休假總時數  */
CREATE function [dbo].[GetAbsTHoursd](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
as
begin

declare @value decimal(16,2)


select @value=isnull(sum(tol_hours),0) from ABS c
join HCODE d on c.H_CODE=d.H_CODE
where exists(
select * from ABS a
join HCODE b on a.H_CODE = b.H_CODE
where a.NOBR=@nobr and @dATE between a.BDATE and a.EDATE
and b.YEAR_REST=1 
and c.NOBR=a.NOBR and c.BDATE between a.BDATE and a.EDATE)
and d.YEAR_REST=2

return @value
end
