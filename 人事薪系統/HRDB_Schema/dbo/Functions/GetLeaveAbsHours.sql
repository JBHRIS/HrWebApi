/*  目前特休剩餘時數  */
CREATE function [dbo].[GetLeaveAbsHours](@nobr nvarchar(50),@date datetime)
returns decimal(16,2)
as
begin
	declare @valueAdd decimal(16,2)
	declare @valueSub decimal(16,2)
	select @valueAdd=dbo.GetAbsTHours(@nobr,@date)
	select @valueSub=dbo.GetAbsTHoursd(@nobr,@date)
	return @valueAdd-@valueSub
end
