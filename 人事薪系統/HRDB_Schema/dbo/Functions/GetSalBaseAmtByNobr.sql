


CREATE function [dbo].[GetSalBaseAmtByNobr](@salcode nvarchar(50),@nobr nvarchar(50),@date date)
returns decimal(16,2)
as
begin
	declare @i decimal(16,2)
	set @i=0
		select top 1 @i = CAST(dbo.DECODE(AMT) as nvarchar(16)) from SALBASD where NOBR = @nobr and @date between ADATE and DDATE and SAL_CODE = @salcode
	return @i
end