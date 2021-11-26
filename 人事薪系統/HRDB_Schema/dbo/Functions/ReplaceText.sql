
create function [dbo].[ReplaceText](@SourceText nvarchar(50),@ReplaceChar nvarchar(1),@Len int)
returns nvarchar(50)
as
begin
	declare @value nvarchar(50)
	set @value=REPLICATE(@ReplaceChar,@Len-LEN(@SourceText))+@SourceText
	return @value
end

