


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetBasettsByNobr]
(	
	-- Add the parameters for the function here
	@nobr nvarchar(50), 
	@bdate date
)
RETURNS TABLE 
AS
RETURN 
(
	select top 1 a.* from BASETTS a
	where NOBR =@nobr and @bdate between ADATE and DDATE
)