

CREATE VIEW [DBO].[VIEW_TW_TAX_SUMMARY]
AS
SELECT          DBO.TW_TAX_SUMMARY.AUTO AS 編號, DBO.TW_TAX_SUMMARY.NOBR AS 員工編號, 
                            DBO.TW_TAX_SUMMARY.AMT AS 給付總額, DBO.TW_TAX_SUMMARY.D_AMT AS 扣繳稅額, 
                            DBO.TW_TAX_SUMMARY.FORMAT AS 所得格式, DBO.TW_TAX_SUMMARY.MEMO AS 備註, 
                            DBO.TW_TAX_SUMMARY.KEY_MAN AS 登錄者, DBO.TW_TAX_SUMMARY.KEY_DATE AS 登錄日期, 
                            DBO.TW_TAX_SUMMARY.TAXNO AS 稅籍編號, DBO.TW_TAX_SUMMARY.COMP AS 公司別代碼, 
                            DBO.TW_TAX_SUMMARY.IMPORT AS 匯入, DBO.TW_TAX_SUMMARY.RET_AMT AS 勞退自提, 
                            DBO.TW_TAX_SUMMARY.IS_FILE AS 已申報, DBO.TW_TAX_SUMMARY.POST2 AS 郵遞區號, 
                            DBO.TW_TAX_SUMMARY.ADDR2 AS 戶籍地址, DBO.TW_TAX_SUMMARY.NAME_C AS 員工姓名, 
                            DBO.TW_TAX_SUMMARY.ID AS 身分證號, DBO.TW_TAX_SUMMARY.SERIES AS 流水號, 
                            DBO.TW_TAX_SUMMARY.IDCODE AS 證號別, DBO.TW_TAX_SUMMARY.ID1 AS 公司統編, 
                            DBO.TW_TAX_SUMMARY.F0103 AS 機關別, DBO.TW_TAX_SUMMARY.F0407 AS 媒體代號, 
                            DBO.TW_TAX_SUMMARY.ERROR AS 錯誤註記, DBO.COMP.COMPNAME AS 公司名稱, 
                            DBO.TW_TAX_SUBCODE.M_FORSUB AS 所得註記, DBO.TW_TAX_SUMMARY.PID
FROM              DBO.TW_TAX_SUMMARY INNER JOIN
                            DBO.COMP ON DBO.TW_TAX_SUMMARY.COMP = DBO.COMP.COMP LEFT OUTER JOIN
                            DBO.TW_TAX_SUBCODE ON DBO.TW_TAX_SUMMARY.SUBCODE = DBO.TW_TAX_SUBCODE.AUTO
GO
EXECUTE sp_addextendedproperty @name = N'MS_DIAGRAMPANECOUNT', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIEW_TW_TAX_SUMMARY';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DIAGRAMPANE1', @value = N'[0E232FF0-B466-11CF-A24F-00AA00A3EFFF, 1.00]
BEGIN DESIGNPROPERTIES = 
   BEGIN PANECONFIGURATIONS = 
      BEGIN PANECONFIGURATION = 0
         NUMPANES = 4
         CONFIGURATION = "(H (1[40] 4[20] 2[20] 3) )"
      END
      BEGIN PANECONFIGURATION = 1
         NUMPANES = 3
         CONFIGURATION = "(H (1 [50] 4 [25] 3))"
      END
      BEGIN PANECONFIGURATION = 2
         NUMPANES = 3
         CONFIGURATION = "(H (1 [50] 2 [25] 3))"
      END
      BEGIN PANECONFIGURATION = 3
         NUMPANES = 3
         CONFIGURATION = "(H (4 [30] 2 [40] 3))"
      END
      BEGIN PANECONFIGURATION = 4
         NUMPANES = 2
         CONFIGURATION = "(H (1 [56] 3))"
      END
      BEGIN PANECONFIGURATION = 5
         NUMPANES = 2
         CONFIGURATION = "(H (2 [66] 3))"
      END
      BEGIN PANECONFIGURATION = 6
         NUMPANES = 2
         CONFIGURATION = "(H (4 [50] 3))"
      END
      BEGIN PANECONFIGURATION = 7
         NUMPANES = 1
         CONFIGURATION = "(V (3))"
      END
      BEGIN PANECONFIGURATION = 8
         NUMPANES = 3
         CONFIGURATION = "(H (1[56] 4[18] 2) )"
      END
      BEGIN PANECONFIGURATION = 9
         NUMPANES = 2
         CONFIGURATION = "(H (1 [75] 4))"
      END
      BEGIN PANECONFIGURATION = 10
         NUMPANES = 2
         CONFIGURATION = "(H (1[66] 2) )"
      END
      BEGIN PANECONFIGURATION = 11
         NUMPANES = 2
         CONFIGURATION = "(H (4 [60] 2))"
      END
      BEGIN PANECONFIGURATION = 12
         NUMPANES = 1
         CONFIGURATION = "(H (1) )"
      END
      BEGIN PANECONFIGURATION = 13
         NUMPANES = 1
         CONFIGURATION = "(V (4))"
      END
      BEGIN PANECONFIGURATION = 14
         NUMPANES = 1
         CONFIGURATION = "(V (2))"
      END
      ACTIVEPANECONFIG = 0
   END
   BEGIN DIAGRAMPANE = 
      BEGIN ORIGIN = 
         TOP = 0
         LEFT = 0
      END
      BEGIN TABLES = 
         BEGIN TABLE = "TW_TAX_SUMMARY"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 38
               BOTTOM = 136
               RIGHT = 203
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "COMP"
            BEGIN EXTENT = 
               TOP = 229
               LEFT = 443
               BOTTOM = 359
               RIGHT = 618
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "TW_TAX_SUBCODE"
            BEGIN EXTENT = 
               TOP = 82
               LEFT = 950
               BOTTOM = 212
               RIGHT = 1121
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
      END
   END
   BEGIN SQLPANE = 
   END
   BEGIN DATAPANE = 
      BEGIN PARAMETERDEFAULTS = ""
      END
      BEGIN COLUMNWIDTHS = 10
         WIDTH = 284
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
      END
   END
   BEGIN CRITERIAPANE = 
      BEGIN COLUMNWIDTHS = 11
         COLUMN = 1440
         ALIAS = 900
         TABLE = 1170
         OUTPUT = 720
         APPEND = 1400
         NEWVALUE = 1170
         SORTTYPE = 1350
         SORTORDER = 1410
         GROUPBY = 1350
         FILTER = 1350
         OR = 1350
         OR = 1350
         OR = 1350
      END
   END
END
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIEW_TW_TAX_SUMMARY';

