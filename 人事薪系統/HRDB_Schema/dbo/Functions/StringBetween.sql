CREATE function [dbo].[StringBetween](@str nvarchar(500),@from nvarchar(500),@to nvarchar(500))
returns bit
as
begin
	declare @dd nvarchar(500)
	declare @d1 nvarchar(500)
	declare @d2 nvarchar(500)
	set @dd=@str
	set @d1=@from
	set @d2=@to
	declare @rtn bit
	if(@dd>=@d1 and @dd<=@d2)
		set @rtn=1
	else set @rtn =0
	return @rtn
end
