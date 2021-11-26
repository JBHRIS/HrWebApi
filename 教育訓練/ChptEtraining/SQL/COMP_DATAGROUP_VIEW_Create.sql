

/****** Object:  View [dbo].[COMP_DATAGROUP]    Script Date: 2013/7/24 下午 05:00:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[COMP_DATAGROUP]
AS
SELECT    [COMP]
      ,[DATAGROUP]
      ,[NOTE]
      ,[KEY_DATE]
      ,[KEY_MAN]
FROM         CHPTHR.dbo.COMP_DATAGROUP



GO

