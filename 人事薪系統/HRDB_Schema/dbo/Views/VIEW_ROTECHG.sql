

CREATE VIEW [DBO].[VIEW_ROTECHG]
AS
SELECT  DBO.ROTECHG.NOBR AS 員工編號, DBO.ROTECHG.ADATE AS 調班日期, DBO.ROTECHG.KEY_MAN AS 登錄者, DBO.ROTECHG.KEY_DATE AS 登錄日期, 
               DBO.ROTECHG.AUTOKEY AS 編號, DBO.ROTECHG.CODE, DBO.BASE.NAME_C AS 員工姓名, DBO.ROTE.ROTENAME AS 班別名稱, 
               DBO.ROTE.ROTE_DISP AS 班別代碼
FROM     DBO.ROTECHG INNER JOIN
               DBO.BASE ON DBO.ROTECHG.NOBR = DBO.BASE.NOBR INNER JOIN
               DBO.ROTE ON DBO.ROTECHG.ROTE = DBO.ROTE.ROTE
GO
EXECUTE sp_addextendedproperty @name = N'MS_DIAGRAMPANECOUNT', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIEW_ROTECHG';


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
         BEGIN TABLE = "ROTECHG"
            BEGIN EXTENT = 
               TOP = 9
               LEFT = 57
               BOTTOM = 196
               RIGHT = 276
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 1
         END
         BEGIN TABLE = "BASE"
            BEGIN EXTENT = 
               TOP = 9
               LEFT = 633
               BOTTOM = 196
               RIGHT = 895
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "ROTE"
            BEGIN EXTENT = 
               TOP = 9
               LEFT = 333
               BOTTOM = 196
               RIGHT = 602
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 57
         END
      END
   END
   BEGIN SQLPANE = 
   END
   BEGIN DATAPANE = 
      BEGIN PARAMETERDEFAULTS = ""
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIEW_ROTECHG';

