

CREATE function [dbo].[CheckFaInsgrf](@Nobr nvarchar(50),@Fa_Idno nvarchar(50),@date datetime)
returns bit
as
begin
	declare @return bit
	set @return=0
	select @return=1 from insgrf where nobr=@Nobr and FA_IDNO=@Fa_Idno and @date between IN_DATE and OUT_DATE and FA_IDNO!=''
	return @return
end

