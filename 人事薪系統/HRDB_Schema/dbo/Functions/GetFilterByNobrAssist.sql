

CREATE function [dbo].[GetFilterByNobrAssist](@nobr nvarchar(50),@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns bit
as
begin
	declare @i int
	set @i=0
		select @i=@@ROWCOUNT from BASETTS a 
		where a.nobr=@nobr and dbo.GetDateValue()<=DDATE
		and (exists(select * from U_DATAID b where b.user_id=@userid and a.dept=b.dept ) 
		or  @admin=1)
		or (@comp='JB-TRANSCARD')	
	return @i
end

