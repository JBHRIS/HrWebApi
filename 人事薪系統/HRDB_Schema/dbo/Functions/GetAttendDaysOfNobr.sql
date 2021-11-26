CREATE function [dbo].[GetAttendDaysOfNobr](
	@nobr nvarchar(50), 
	@bdate date,
	@edate date
)
 returns int
 as
begin
declare @result int
set @result=0
select @result=COUNT(*) from dbo.[GetAttendByNobr](@nobr,@bdate,@edate) a where a.ROTE not in (select ROTE from [dbo].[ROTE_RELATION_DETAIL] where RELATION_CODE='Holiday')
return @result
end