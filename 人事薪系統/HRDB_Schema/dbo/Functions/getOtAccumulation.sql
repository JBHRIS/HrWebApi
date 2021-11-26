



create function [dbo].[getOtAccumulation](@EmpId nvarchar(50),@DateBegin datetime,@DateEnd datetime)
returns decimal(16,2)
as
begin
declare @result decimal(16,2)
set @result=0
 select @result=sum(case when r.ROTE='00' then (case when x.TOT_HOURS>8 then x.TOT_HOURS-8 else x.TOT_HOURS end) else x.TOT_HOURS end) from OT x
 join ATTEND a on a.NOBR=x.NOBR and a.ADATE=x.BDATE
 join ROTE r on a.ROTE=r.ROTE
 where x.NOBR=@EmpId and x.BDATE between @DateBegin and @DateEnd
 return @result
end