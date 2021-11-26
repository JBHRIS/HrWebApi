

CREATE function [dbo].[GetMinMonthAmtByNobr](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	set @value = 0
	select top 1 @value = b.Month_Salary from BASETTS a
	join WORKADR_SALARY b on a.WORKCD = b.WORK_CODE
	where NOBR =@nobr and @date between a.ADATE and a.DDATE
	and @date between b.ADATE and b.DDATE
	return @value
end