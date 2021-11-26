
/*  指定日期中所包含有效的特休得假總時數  */
CREATE function [dbo].[GetAbsRateHrsByNobr](@salcode nvarchar(50), @nobr nvarchar(50),@yymm nvarchar(50))
returns decimal(16,2)
as
begin
declare @value decimal(16,2)
declare @value1 decimal(16,2)
set @value = 0
set @value1 = 0

select @value = isnull(SUM(a.TOL_HOURS * 8 * [dbo].[GetHcodeRateByHcode](c.H_CODE,c.SAL_CODE, a.NOBR,a.BDATE)),0) from ABS a 
join HCODE b on a.H_CODE = b.H_CODE
join HCODES c on a.H_CODE = c.H_CODE
where a.NOBR = @nobr and a.YYMM = @yymm
and b.FLAG ='-' and c.MLSSALCODE = @salcode and b.UNIT = '天'

select @value1 = isnull(SUM(a.TOL_HOURS * [dbo].[GetHcodeRateByHcode](c.H_CODE,c.SAL_CODE, a.NOBR,a.BDATE)),0) from ABS a 
join HCODE b on a.H_CODE = b.H_CODE
join HCODES c on a.H_CODE = c.H_CODE
where a.NOBR = @nobr and a.YYMM = @yymm
and b.FLAG ='-' and c.MLSSALCODE = @salcode and b.UNIT <> '天'


return (@value + @value1)
 end