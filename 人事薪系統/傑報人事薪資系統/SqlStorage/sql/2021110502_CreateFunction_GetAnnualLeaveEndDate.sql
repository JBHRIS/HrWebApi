/****** Object:  UserDefinedFunction [dbo].[GetAnnualLeaveEndDate]    Script Date: 2021/11/5 下午 01:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetAnnualLeaveEndDate](@EmployeeId nvarchar(50),@CheckDate datetime)
returns datetime
as
begin
	declare @InDate datetime = dbo.GetCurrentIndt(@EmployeeId,@CheckDate)
	declare @Intervals int = datepart(year,@CheckDate) - datepart(year,@InDate)
	declare @InDateOfThisYear datetime = dateadd(year,@Intervals,@InDate)
	if(@InDateOfThisYear<@CheckDate)
		set @InDateOfThisYear=dateadd(year,1,@InDateOfThisYear)
	return dateadd(day,-1,@InDateOfThisYear)
end
