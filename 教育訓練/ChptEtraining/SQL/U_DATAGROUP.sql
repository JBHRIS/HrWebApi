
/****** Object:  View [dbo].[U_DATAGROUP]    Script Date: 2013/7/24 下午 05:00:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[U_DATAGROUP]
AS
SELECT    [USER_ID]
      ,[COMPANY]
      ,[DATAGROUP]
      ,[READRULE]
      ,[WRITERULE]
      ,[NOTE]
      ,[KEY_DATE]
      ,[KEY_MAN]
FROM         CHPTHR.dbo.U_DATAGROUP



GO

