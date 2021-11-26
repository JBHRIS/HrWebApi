CREATE function [dbo].[GetHolidayYears](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	declare @wk_yrs decimal(16,2) 
	select @wk_yrs=wk_yrs from basetts where nobr=@nobr and @date between cindt and ddate
	--if(@count_ma=0)
	--BEGIN	
	--select @date=dateadd(day,1,@date)
	--	select @value=isnull((datepart(year,@date)-datepart(year,indt)),0) from basetts where nobr=@nobr and @date between adate and ddate
	--	END	
	--else 
	select @value=isnull(sum(convert(decimal(16,2),dbo.GetMixDaysByCindt('1900-1-1',@date,adate,ddate,cindt,ttscode))/365),0) from basetts where nobr=@nobr and  TTSCODE IN('1','4','6') and adate<=@date
	return @value+@wk_yrs
end
--returns decimal(16,2)
--as
--begin
--	declare @value decimal(16,2)
--	select @value=dbo.GetTotalYears	(@nobr,@date)
--	return @value
--	--return convert(decimal,@nobr)
--end
