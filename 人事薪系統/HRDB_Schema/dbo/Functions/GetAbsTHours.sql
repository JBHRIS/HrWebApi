/*  指定日期中所包含有效的特休得假總時數  */
CREATE function [dbo].[GetAbsTHours](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
as
begin
declare @value decimal(16,2)

select 
@value=isnull(sum(tol_hours),0)
 from abs
join HCODE	on abs.H_CODE	=HCODE	.H_CODE	
 where abs.NOBR=@nobr and HCODE	.YEAR_REST	='1'
 and @date between abs.bdate and abs.edate
 group by hcode.unit
 
 return @value
 end
