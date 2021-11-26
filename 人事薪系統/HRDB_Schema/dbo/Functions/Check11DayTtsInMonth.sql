
CREATE FUNCTION [dbo].[Check11DayTtsInMonth](@Nobr nvarchar(50),@Bdate DateTime,@Edate DateTime)
RETURNS int
AS
BEGIN
	DECLARE @Value int
	DECLARE @Count int
	Set @Value = 0 
	Set @Count = 0
	select @Count += COUNT(*) from basetts a
	where a.NOBR = @Nobr and a.TTSCODE in ('1')
	and a.ADATE between @Bdate and @Edate
	and day(a.ADATE)<=11
	select @Count += COUNT(*) from basetts a
	where a.NOBR = @Nobr and a.TTSCODE in ('2','3','5')
	and a.ADATE between @Bdate and @Edate
	and day(a.ADATE)>=11

	if (@Count >0) Set @Value = 1

	RETURN @Value
END