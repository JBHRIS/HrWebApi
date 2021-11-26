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