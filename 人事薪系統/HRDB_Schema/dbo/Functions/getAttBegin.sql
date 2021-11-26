

CREATE function [dbo].[getAttBegin](@Comp nvarchar(50),@checkDate datetime)
returns datetime
 as
begin
	return dateadd(month,-1,dateadd(day,1,dbo.getAttEnd(@Comp,@checkDate)))
end