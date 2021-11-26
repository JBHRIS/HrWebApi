
CREATE function [dbo].[GetTotalYearsWithoutExternal](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
as
begin
	declare @value decimal(16,2)
	declare @wk_yrs decimal(16,2) 
	select @wk_yrs=wk_yrs from basetts where nobr=@nobr and @date between adate and ddate
	--if(@count_ma=0)
	--BEGIN	
	--select @date=dateadd(day,1,@date)
	--	select @value=isnull((datepart(year,@date)-datepart(year,indt)),0) from basetts where nobr=@nobr and @date between adate and ddate
	--	END	
	--else 
	select @value=floor(isnull(sum(convert(decimal(16,2),dbo.GetMixDays('1900-1-1',@date,adate,ddate))),0)*100/365.24)/100 from basetts where nobr=@nobr and  TTSCODE IN('1','4','6') and adate<=@date
	return @value
end