

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetCalendarByNobr]
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
	select a.* from HOLI a
	join BASETTS b on a.HOLI_CODE=b.HOLI_CODE
	 where b.NOBR =@nobr and a.H_DATE between b.ADATE and b.DDATE
	 and a.H_DATE between @bdate and @edate
)