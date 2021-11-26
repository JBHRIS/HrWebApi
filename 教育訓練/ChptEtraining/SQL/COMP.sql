
/****** Object:  View [dbo].[COMP]    Script Date: 2013/3/27 下午 02:29:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[COMP]
AS
SELECT     [COMP]
      ,[COMPNAME]
      ,[CHAIRMAN]
      ,[COMPID]
      ,[TEL]
      ,[FAX]
      ,[ADDR]
      ,[HOUSEID]
      ,[KEY_MAN]
      ,[KEY_DATE]
      ,[F0103]
      ,[F0407]
      ,[WORKCD]
      ,[TAXID]
      ,[ACCOUNT]
      ,[ACCR]
      ,[DEFA]      
      ,[INSCOMP]
FROM         CHPTHR.dbo.COMP


GO

