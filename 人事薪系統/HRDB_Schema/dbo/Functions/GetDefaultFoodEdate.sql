
CREATE FUNCTION [dbo].[GetDefaultFoodEdate](@NOBR varchar(50))
RETURNS datetime
AS                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
BEGIN
	RETURN (CASE WHEN
				(SELECT     TOP 1 TTSCODE
					FROM          BASETTS b
					WHERE      b.NOBR = @NOBR AND GETDATE() BETWEEN b.ADATE AND b.DDATE) IN ('1', '4', '6') 
			THEN CONVERT(datetime, '99990101') 
			ELSE
				(SELECT     TOP 1 ADATE
					FROM          BASETTS b
					WHERE      b.NOBR = @NOBR AND GETDATE() BETWEEN b.ADATE AND b.DDATE) 
			END)
END