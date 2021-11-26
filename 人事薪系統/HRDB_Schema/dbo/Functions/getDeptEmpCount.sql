-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getDeptEmpCount] (@dept nvarchar(50), @adate datetime)
RETURNS int
AS
BEGIN
	 
	 
	 declare @value int;
	 select  @value = count(nobr) from basetts
	 where @adate between adate and ddate and ttscode in('6','4','1') and dept =@dept  AND EMPCD='01' 


	-- Return the result of the function
	RETURN @value

END