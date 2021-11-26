-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetTotalLeaveWithoutPay](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
--returns datetime
as
begin
	declare @value decimal(16,2)
	declare @value1 decimal(16,2)
	declare @value2 decimal(16,2)
	declare @cindt datetime
	select @value1=wk_yrs,@cindt=CINDT from basetts where @date between adate and ddate AND NOBR=@nobr	
	select @value=sum(dbo.getmixdays(dbo.ReturnADATEforCountStopDay(adate,cindt),dbo.ReturnDDATEforCountStopDay(ddate,cindt),@cindt,@date)) from basetts where nobr=@nobr  and ttscode in ('2','3','5')
	--RETURN @cindt

	set @value2 = ((CONVERT(DECIMAL(16,2),@value)/CONVERT(DECIMAL(16,2),365.24))+@value1)

	
	set @value2 = isnull(@value2,0)

	return @value2
	--RETURN @valuec
end

