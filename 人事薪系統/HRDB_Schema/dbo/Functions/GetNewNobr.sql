CREATE FUNCTION [dbo].[GetNewNobr](@count_ma bit)
returns nvarchar(50)
as
begin
	declare @max_nobr int
	declare @Header nvarchar(50)
	declare @nobr nvarchar(50)
	
	--set @max_nobr=0
	if(@count_ma=0)--本勞
	begin
		set @Header='C'+substring(convert(nvarchar(50),datepart(year,getdate())),3,2)
		select @max_nobr=max(convert(int,substring(nobr,4,3))) from base where nobr like @Header+'%'
		if(@max_nobr is null) set @max_nobr=0
		SET @max_nobr=@max_nobr+1
		SET @NOBR=@HEADER+right('0000'+cast(@max_nobr as varchar),3)
	end
	else
	begin
		set @Header='W'
		select @max_nobr=max(convert(int,substring(nobr,3,5))) from base where nobr like @Header+'%'
		if(@max_nobr is null) set @max_nobr=0
		SET @max_nobr=@max_nobr+1
		SET @NOBR=@HEADER+right('000000'+cast(@max_nobr as varchar),5)
	end
	
	return @NOBR
end
