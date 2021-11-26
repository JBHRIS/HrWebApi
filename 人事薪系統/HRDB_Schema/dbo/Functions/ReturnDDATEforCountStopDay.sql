-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ReturnDDATEforCountStopDay](@DDATE datetime,@CINDT datetime)
returns datetime
as
begin

	declare @date datetime
	set @date = @DDATE
	if(@date < GETDATE())
		begin
			if(@date < @CINDT) --若小於集團到職日 DDATE = @CINDT - 1天
			begin
			set @date = (@CINDT - 1)
			end
		end

	else
		begin
		if(@date > GETDATE())
			begin
			set @date = GETDATE()
			end
		end
	return @date
end
