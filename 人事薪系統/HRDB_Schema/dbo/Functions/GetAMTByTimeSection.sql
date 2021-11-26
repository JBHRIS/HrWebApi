Create function [dbo].[GetAMTByTimeSection](@BTime varchar(50),@ETime varchar(50),@LimtBegin varchar(50),@LimtEnd varchar(50),@AMT decimal(16,2),@MaxHrs int ,@proportion bit)
returns decimal(16,2)
as
begin
declare @Length int
declare @Result decimal(16,2)
set @Length = 0
set @Result = 0.00
if (@proportion = 1)
	set @Length = 5
if (@ETime >= @LimtBegin)
  begin
  if(@BTime <= @LimtEnd and @ETime >= @LimtBegin)
    Begin
     if (@BTime < @LimtBegin) Set @BTime = @LimtBegin
	 if (@ETime > @LimtEnd) Set @ETime = @LimtEnd
    end  
  set @Result =  Round((dbo.GetTimeDiff(@LimtEnd,@BTime)-dbo.GetTimeDiff(@LimtEnd,@ETime)) /@MaxHrs, @length, 1) * @AMT
  end
return @Result 
end