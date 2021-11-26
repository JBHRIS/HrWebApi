/* 該日期所包含的得假區間內所有請指定假別代碼的請假總時數 */
CREATE function [dbo].[GetAbsTHoursByHcode](@nobr nvarchar(50),@date datetime,@hcode nvarchar(50))
returns decimal(16,2)
as
begin
declare @value decimal(16,2)

select 
@value=isnull(sum(tol_hours),0)
 from abs
join HCODE	on abs.H_CODE	=HCODE	.H_CODE	
 where abs.NOBR=@nobr and HCODE	.H_CODE=@hcode
 and @date between abs.bdate and abs.edate
 
 return @value
 end
