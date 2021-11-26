

/*  指定日期中所包含有效的特休得假總時數  */
CREATE function [dbo].[GetHcodeRateByHcode](@hcode nvarchar(50), @salcode nvarchar(50), @nobr nvarchar(50), @date datetime)
returns decimal(16,2)
as
begin
declare @rate decimal(16,2)
declare @rate1 decimal(16,2)
declare @tol_years decimal(16,2)
set @rate = 1
set @rate1 = 0
set @tol_years = 0

 select @tol_years = dbo.GetTotalYearsNoExternal(@nobr, @date)
 
 select top 1 @rate = a.RATE from HCODES a 
 where a.H_CODE = @hcode
 
 select top 1 @rate = isnull(a.RATE,0) from HCODESRATE a
 where a.H_CODE =@hcode and a.SAL_CODE = @salcode
 and @tol_years >= a.YEAR_B and @tol_years < a.YEAR_E
 order by a.DAY_B desc
 
 --if (@rate1<>0)
 --begin
 --	set @rate = @rate1
 --end

return @rate
 end