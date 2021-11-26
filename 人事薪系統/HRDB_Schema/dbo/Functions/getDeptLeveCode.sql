


CREATE FUNCTION [dbo].[getDeptLeveCode](@dept nvarchar(50),@leve INT) 

RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @RESULT NVARCHAR(50);

	 with myview (DEPT_GROUP,D_NO,DEPT_TREE ) as
  (select DEPT_GROUP,D_NO,DEPT_TREE
   from dbo.DEPT where D_NO = @dept
   union all
   select a.DEPT_GROUP,a.D_NO ,a.DEPT_TREE
   from dbo.DEPT a,myview b
   where a.D_NO=b.DEPT_GROUP)
     
    select @RESULT= D_NO
  from myview
  where  CONVERT(int, DEPT_TREE) =  @leve 

  -- Return the result of the function
	RETURN @RESULT

END