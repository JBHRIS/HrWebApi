

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetAttendByNobr]
(	
	-- Add the parameters for the function here
	@nobr nvarchar(50), 
	@bdate date,
	@edate date
)
RETURNS TABLE 
AS
RETURN 
(
	select * from ATTEND where NOBR =@nobr and ADATE between @bdate and @edate
)