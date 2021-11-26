

CREATE VIEW [DBO].[FRM4K]
AS
SELECT          DBO.SALENRICH.AUTOKEY, DBO.SALENRICH.NOBR, DBO.SALENRICH.YYMM, DBO.SALENRICH.SEQ, 
                            DBO.SALENRICH.SAL_CODE, DBO.SALENRICH.AMT, DBO.SALENRICH.KEY_MAN, DBO.SALENRICH.KEY_DATE, 
                            DBO.SALENRICH.MEMO, DBO.SALENRICH.FA_IDNO, DBO.SALENRICH.IMPORT, DBO.BASE.NAME_C, 
                            DBO.SALCODE.SAL_NAME
FROM              DBO.SALENRICH INNER JOIN
                            DBO.SALCODE ON DBO.SALENRICH.SAL_CODE = DBO.SALCODE.SAL_CODE INNER JOIN
                            DBO.BASE ON DBO.SALENRICH.NOBR = DBO.BASE.NOBR
GO
EXECUTE sp_addextendedproperty @name = N'MS_DIAGRAMPANECOUNT', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM4K';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DIAGRAMPANE1', @value = N'[0E232FF0-B466-11CF-A24F-00AA00A3EFFF, 1.00]
BEGIN DESIGNPROPERTIES = 
   BEGIN PANECONFIGURATIONS = 
      BEGIN PANECONFIGURATION = 0
         NUMPANES = 4
         CONFIGURATION = "(H (1[26] 4[35] 2[18] 3) )"
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
         BEGIN TABLE = "SALENRICH"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 38
               BOTTOM = 136
               RIGHT = 203
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "SALCODE"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 241
               BOTTOM = 136
               RIGHT = 433
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "BASE"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 471
               BOTTOM = 136
               RIGHT = 663
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
      BEGIN COLUMNWIDTHS = 9
         WIDTH = 284
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM4K';

