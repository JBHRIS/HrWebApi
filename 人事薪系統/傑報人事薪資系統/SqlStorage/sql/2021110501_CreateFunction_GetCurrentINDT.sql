/****** Object:  UserDefinedFunction [dbo].[GetCurrentINDT]    Script Date: 2021/11/5 下午 01:37:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[GetCurrentINDT](@date datetime,@nobr nvarchar(50))
returns datetime
as
begin
	declare @indt datetime
	select @indt=CINDT from basetts where @date between adate and ddate and NOBR = @nobr
	declare @stop_days decimal(16,2)
	set @stop_days=0;
	select @stop_days=isnull( Sum(dbo.GetMixDays(adate,ddate,@indt,@date)),0) from basetts where NOBR = @nobr and TTSCODE in ('2','3','5') and ADATE<@date
	return dateadd(day,@stop_days,@indt)
end

