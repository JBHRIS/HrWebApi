

create function [dbo].[GetDateValue]()
returns datetime
as
begin
	declare @val datetime
	set @val=CONVERT(datetime,CONVERT(nvarchar(50),getdate(),101))
	return @val
end

