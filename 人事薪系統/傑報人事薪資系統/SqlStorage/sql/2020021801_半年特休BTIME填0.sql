UPDATE ABS 
SET BTIME = '0000', ETIME = '0000'
WHERE NOTE = '半年特休'
GO

ALTER function [dbo].[GetMixDaysByCindt](@lowestDate datetime,@highestDate datetime,@aDate datetime,@dDate datetime,@Cindt datetime,@ttscode nvarchar)
returns decimal
as
begin
	declare @value decimal
	declare @value1 datetime
	declare @value2 datetime

	--if(@lowestDate>@aDate)
	--set @value1=@lowestDate
	--else set @value1=@aDate
	
	--if(@highestDate<@dDate)
	--set @value2=@highestDate
	--else set @value2=@dDate

	if(@ttscode = '1')
	  begin
	  if(@dDate < @Cindt) --如果迄日小於
	    begin
		set @value1 = @Cindt
		set @value2 = @Cindt - 1
		end
	  else if(@Cindt > @highestDate)
	    begin
		set @value1 = @Cindt
		set @value2 = @Cindt - 1
		end
	  else if(@dDate > @highestDate and @Cindt <= @highestDate)
	    begin
		set @value1 = @Cindt
		set @value2 = @highestDate
		end
	  else
	    begin
		set @value1 = @Cindt
		set @value2 = @dDate
		end
	  end
	else
	  begin
	  if(@aDate > @highestDate)
	    begin
		set @value1 = @highestDate
		set @value2 = @highestDate - 1
		end
	  else if(@aDate = @highestDate)
	    begin
		set @value1 = @highestDate
		set @value2 = @highestDate
		end
	  else if(@dDate < @Cindt)
	    begin
	    set @value1 = @Cindt
		set @value2 = @Cindt - 1
	    end
	  else if(@dDate = @Cindt)
	    begin
	    set @value1 = @Cindt
		set @value2 = @Cindt
	    end
	  else if(@aDate < @Cindt and @dDate > @Cindt)
	    begin
		set @value1 = @Cindt
		if(@dDate > @highestDate)
		  begin
		  set @value2 = @highestDate
		  end
		else
		  begin
		  set @value2 = @dDate
		  end
		end
	  else if(@aDate > @Cindt and @dDate > @Cindt)
	    begin
		set @value1 = @aDate
	    if(@dDate > @highestDate)
		  begin
		  set @value2 = @highestDate
		  end
		else
		  begin
		  set @value2 = @dDate
		  end
		end
	  end

	set @value=convert(decimal,@value2-@value1+1)
	return @value
end