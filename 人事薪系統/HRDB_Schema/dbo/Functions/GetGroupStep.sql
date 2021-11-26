


CREATE Function [dbo].[GetGroupStep](@Value decimal(16,2),@Step decimal(16,2),@Title nvarchar(50))
returns nvarchar(50)
as
begin
	declare @div int
	set @div=convert(int,@value/@step)*convert(int,@step)
	return @title+convert(nvarchar(50), @div)
end