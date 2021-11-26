





CREATE FUNCTION [dbo].[WriteRuleTableAssist](@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns @Table Table(
NOBR nvarchar(50),
DATAGROUP nvarchar(50)
)
as
begin	
	INSERT INTO @Table 	
	SELECT NOBR,SALADR FROM BASETTS WHERE (exists(select 1 from U_DATAID  where (U_DATAID.USER_ID=@userid and U_DATAID.DEPT=BASETTS.DEPT)) or @admin=1) and BASETTS.COMP=@comp AND DBO.GetDateValue() BETWEEN ADATE AND DDATE	
	--INSERT INTO @Table 	
	--SELECT NOBR,SALADR FROM BASETTS WHERE (exists(select 1 from U_DATAID  where (U_DATAID.USER_ID=@userid and U_DATAID.DEPT=BASETTS.DEPT)) or @admin=1) and BASETTS.COMP=@comp AND not exists(select 1 from BASETTS a where dbo.GetDateValue() between ADATE and DDATE and a.NOBR=BASETTS.NOBR) and ADATE=(select MAX(adate) from BASETTS b where b.NOBR=BASETTS.NOBR)
	RETURN
end





