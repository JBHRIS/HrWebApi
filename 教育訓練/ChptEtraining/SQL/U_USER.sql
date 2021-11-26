
/****** Object:  View [dbo].[U_USER]    Script Date: 2013/7/24 下午 05:00:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[U_USER]
AS
SELECT     [USER_ID]
      ,[PASSWORD]
      ,[SUPER]
      ,[NAME]
      ,[SYSTEM]
      ,[KEY_DATE]
      ,[KEY_MAN]
      ,[PROCSUPER]
      ,[WORKADR]
      ,[MANGSUPER]
      ,[E_MAIL]
      ,[ADMIN]
      ,[NOBR]
FROM         CHPTHR.dbo.U_USER



GO

