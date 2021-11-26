create function [dbo].[GetDateFormat](@date Datetime)
returns datetime
as
begin
	declare @d1 datetime
	set @d1=convert(datetime,convert(varchar,@date,102))
	return @d1
end
