

/****** Object:  View [dbo].[BASE]    Script Date: 08/03/2012 17:23:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW DEPTA
AS
SELECT     [D_NO]
      ,[D_NAME]
      ,[D_ENAME]
      ,[KEY_DATE]
      ,[KEY_MAN]
      ,[OLD_DEPT]
      ,[DEPT_GROUP]
      ,[DEPT_TREE]
      ,[MANAGER]
      ,[ADATE]
      ,[DDATE]
      ,[DEPT_CATE]
FROM  [Formosahr_t].[dbo].[DEPTA]

GO