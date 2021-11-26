

CREATE function [dbo].[GetCountryByNobr](@nobr nvarchar(50))
returns nvarchar(50)
as
begin
	declare @value nvarchar(50)
	set @value = ''
	select @value = a.COUNTRY from BASE a
	where NOBR =@nobr
	return @value
end