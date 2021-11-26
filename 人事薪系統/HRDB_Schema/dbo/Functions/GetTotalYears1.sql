CREATE function [dbo].[GetTotalYears1](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
--returns datetime
as
begin
        declare @value decimal(16,2)
    declare @wk_yrs decimal(16,2)
    select @wk_yrs=wk_yrs from basetts where nobr=@nobr and @date between cindt and ddate
   
    select @value=isnull(dbo.getmixdays('1950-01-01','9999-12-31',dbo.GetCurrentIndt(@nobr,@date),@date),0)/365.24
    return @value+@wk_yrs
end
