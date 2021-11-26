
CREATE FUNCTION [dbo].[GetCodeFilter](@source nvarchar(50),@Code nvarchar(50),@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns BIT
as
begin
	declare @i int
	select @i=1 from CODE_FILTER where CODE_FILTER.SOURCE=@source AND CODE_FILTER.CODE=@Code and (EXISTS(SELECT * FROM U_DATAGROUP WHERE U_DATAGROUP.USER_ID=@userid and U_DATAGROUP.COMPANY=@comp and READRULE=1 and U_DATAGROUP.DATAGROUP=CODE_FILTER.CODEGROUP)
 or EXISTS(SELECT * FROM COMP_DATAGROUP WHERE COMP=@comp AND CODE_FILTER.CODEGROUP=COMP_DATAGROUP.DATAGROUP and @admin=1))
	return @i
end
