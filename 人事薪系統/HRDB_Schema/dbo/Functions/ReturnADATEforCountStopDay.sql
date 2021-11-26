-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ReturnADATEforCountStopDay](@ADATE datetime,@CINDT datetime)
returns datetime
as
begin

	declare @date datetime
	set @date = @ADATE

	if(@ADATE <  @CINDT) 
	    begin
		set @date = @CINDT
		if(@date > GETDATE())
			begin
			set @date = (GETDATE() + 1)
			end
		end

	else
		begin
		if(@date > GETDATE())
			begin
			set @date = (GETDATE() + 1)
			end
		end
	return @date
end
