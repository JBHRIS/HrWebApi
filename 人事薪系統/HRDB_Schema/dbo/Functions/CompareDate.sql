-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[CompareDate](@date1 datetime,@date2 datetime)
RETURNS datetime
AS
BEGIN
	-- Declare the return variable here
	declare @value datetime


	if(@date1 >= @date2)	
	
	SET @value = @date1
	
	else 

	SET @value = @date2

	RETURN @value

END
