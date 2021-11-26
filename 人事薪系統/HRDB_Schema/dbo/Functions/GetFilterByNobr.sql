CREATE function [dbo].[GetFilterByNobr](@nobr nvarchar(50),@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns bit
as
begin
	declare @i int
	set @i=0
		select @i=@@ROWCOUNT from BASETTS a 
		where a.nobr=@nobr and dbo.GetDateValue() BETWEEN ADATE AND DDATE
		and (exists(select * from U_DATAGROUP b where b.user_id=@userid and (b.COMPANY=@comp or @comp='JB-TRANSCARD') and b.DATAGROUP=a.SALADR and b.READRULE=1) 
		or exists(select * from COMP_DATAGROUP b where b.DATAGROUP=a.SALADR and (COMP=@comp or @comp='JB-TRANSCARD') and @admin=1)
		)	
	return @i
end
