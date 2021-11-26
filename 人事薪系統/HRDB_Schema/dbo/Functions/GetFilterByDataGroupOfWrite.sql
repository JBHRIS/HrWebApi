CREATE function [dbo].[GetFilterByDataGroupOfWrite](@DATAGROUP nvarchar(50),@userid nvarchar(50),@comp nvarchar(50),@admin bit)
returns bit
as
begin
	declare @i int
	set @i=0
	declare @J int
	set @J=0
	--if(@admin=0)
		select @i=1 from U_DATAGROUP b where b.user_id=@userid and (b.COMPANY=@comp or @comp='JB-TRANSCARD') and b.DATAGROUP=@DATAGROUP and b.WRITERULE=1
		if(@admin=1)
		select @J=1 from COMP_DATAGROUP b where b.DATAGROUP=@DATAGROUP and (COMP=@comp or @comp='JB-TRANSCARD') and @admin=1
		if(@J>0) set @i=1
	--else
		--select @i=@@ROWCOUNT from BASETTS a where a.nobr=@nobr and dbo.GetDateValue()<=DDATE and exists(select * from COMP_DATAGROUP b where b.DATAGROUP=a.SALADR)	
	return @i
end