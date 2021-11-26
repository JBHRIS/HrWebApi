



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetAllAbsByNobr]
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
	select a.* from ABS a
	join HCODE b on b.H_CODE = a.H_CODE
	where NOBR =@nobr and BDATE between @bdate and @edate
	and b.FLAG = '-' and b.MANG = 0
)