/****** Object:  UserDefinedFunction [dbo].[GetTimeDiff]    Script Date: 2020/11/9 ¤W¤È 08:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[GetTimeDiff](@Time1 varchar(50),@Time2 varchar(50))
returns decimal(16,2)
as
begin

	declare @DTime1 decimal(16,2)
	declare @DTime2 decimal(16,2)

	set @DTime1 = CONVERT(decimal(16,2),@Time1)
	set @DTime2 = CONVERT(decimal(16,2),@Time2)

	set @DTime1 = round(@DTime1 / 100.0,0) * 60  + @DTime1 % 100
	set @DTime2 = round(@DTime2 / 100.0,0) * 60  + @DTime2 % 100

	if(@DTime1 < @DTime2)
		BEGIN
		set @DTime1 = 0.00
		set @DTime2 = 0.00
		END

	declare @result decimal(16,2)

	set @result = (@DTime1 - @DTime2) / 60.0
	return @result
end
