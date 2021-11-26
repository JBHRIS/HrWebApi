/****** Object:  UserDefinedFunction [dbo].[GetAbsRateHrsByNobr]    Script Date: 2020/8/19 下午 01:31:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*  指定日期區間及計薪年月下，員工的用餐扣款總和 */
CREATE function [dbo].[GetMealDeduction](@EmpId nvarchar(50), @YYMM nvarchar(6) ,@DateBegin datetime ,@DateEnd datetime)
returns decimal(16,2)
as
begin
	declare @result decimal(16,2)
	set @result=0
	select @result = isnull(sum(MD.AMT),0)
	from MealDeduction as MD
	where MD.NOBR = @EmpId and MD.YYMM = @YYMM and MD.ADATE >= @DateBegin and MD.ADATE <= @DateEnd
return @result
end
GO

if not exists(select CALCTYPE,SALNAME  from SALBASE where CALCTYPE='SAL' and SALNAME ='用餐扣款總額' )  
Begin
  insert into SALBASE (CALCTYPE, SALNAME, REFFUNCTION)
  values ('SAL','用餐扣款總額','select dbo.GetMealDeduction(''{CalcNobr}'',''{CalcYymm}'',''{CalcSalDateB}'',''{CalcSalDateE}'')')
End
GO

if not exists(select CALCTYPE,ITEM  from SALFUNCTION where CALCTYPE='SAL' and ITEM ='用餐扣款總額' )  
Begin
  insert into SALFUNCTION(CALCTYPE, ITEM, SCRIPT, SORT, CALC, REF)
  values ('SAL','用餐扣款總額','%用餐扣款總額%',(select MAX(sort)+1 from SALFUNCTION), 1,0)
End
GO