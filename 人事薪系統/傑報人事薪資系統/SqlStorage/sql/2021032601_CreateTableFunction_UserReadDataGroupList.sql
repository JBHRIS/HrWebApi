CREATE FUNCTION [dbo].UserReadDataGroupList(@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns @Table Table(
DATAGROUP nvarchar(50)
)
as
begin   
    INSERT INTO @Table  
    select b.DATAGROUP from U_DATAGROUP b where b.user_id=@userid and b.COMPANY=@comp and b.READRULE=1
    INSERT INTO @Table  
    select b.DATAGROUP from COMP_DATAGROUP b where COMP=@comp and @admin=1
        
    RETURN
end
GO