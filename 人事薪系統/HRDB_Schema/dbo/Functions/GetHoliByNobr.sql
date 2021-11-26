


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetHoliByNobr]
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
	select a.NOBR, a.HOLI_CODE, b.H_DATE, c.OTHCODE, c.OTHHOLI, c.STDHOLI from BASETTS a
	join HOLI b on b.HOLI_CODE = a.HOLI_CODE
	join OTHCODE c on c.OTHCODE = b.OTHCODE
	where a.NOBR = @nobr and @edate between a.ADATE and a.DDATE
	and b.H_DATE between @bdate and @edate
)