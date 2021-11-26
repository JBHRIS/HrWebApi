


CREATE FUNCTION [dbo].[ReadRuleTable](@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns @Table Table(
NOBR nvarchar(50),
DATAGROUP nvarchar(50)
)
as
begin	
	INSERT INTO @Table 	
	SELECT NOBR,SALADR FROM BASETTS WHERE DBO.GetFilterByDataGroupOfRead(SALADR,@userid,@comp,@admin)=1 AND DBO.GetDateValue() BETWEEN ADATE AND DDATE	
	INSERT INTO @Table 	
	SELECT NOBR,SALADR FROM BASETTS WHERE dbo.GetFilterByDataGroupOfRead(SALADR,@userid,@comp,@admin)=1 AND not exists(select 1 from BASETTS a where dbo.GetDateValue() between ADATE and DDATE and a.NOBR=BASETTS.NOBR) and ADATE=(select MAX(adate) from BASETTS b where b.NOBR=BASETTS.NOBR)
	RETURN
end





