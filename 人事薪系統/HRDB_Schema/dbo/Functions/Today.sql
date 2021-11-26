create function [dbo].[Today]()
returns datetime
as
begin
	declare @d1 datetime
	set @d1=dbo.getdateformat(getdate())
	return @d1
end
