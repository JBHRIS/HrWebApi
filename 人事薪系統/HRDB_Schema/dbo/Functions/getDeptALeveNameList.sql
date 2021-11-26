




CREATE FUNCTION [dbo].[getDeptALeveNameList](@dept nvarchar(50),@leve INT) 

RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @RESULT NVARCHAR(50);

	 with myview (DEPT_GROUP,D_NO,DEPT_TREE,D_NAME ) as
  (select DEPT_GROUP,D_NO,DEPT_TREE,CONVERT(nvarchar(200),D_NAME) as D_NAME
   from dbo.DEPTA where D_NO = @dept
   union all
   select a.DEPT_GROUP,a.D_NO ,a.DEPT_TREE,CONVERT(nvarchar(200), a.D_NAME+'->' +b.D_NAME ) as D_NAME
   from dbo.DEPTA a,myview b
   where a.D_NO=b.DEPT_GROUP)
     
    select @RESULT= D_NAME
  from myview
  where  CONVERT(int, DEPT_TREE) =  @leve 

  -- Return the result of the function
	RETURN @RESULT

END