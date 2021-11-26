CREATE VIEW [dbo].[FRM46B]
AS
SELECT          DBO.SALBASND.NOBR, DBO.SALBASND.YYMM_B, DBO.SALBASND.YYMM_E, DBO.SALBASND.SAL_CODE, 
                            DBO.SALBASND.SEQ, DBO.SALBASND.A_DATE, DBO.SALBASND.A_TYPE, DBO.SALBASND.A_PER, 
                            DBO.SALBASND.F_AMT, DBO.SALBASND.P_AMT, DBO.SALBASND.T_AMT, DBO.SALBASND.KEY_MAN, 
                            DBO.SALBASND.KEY_DATE, DBO.SALBASND.MEMO, DBO.SALBASND.DISPATCH, DBO.SALBASND.DE_DEPT, 
                            DBO.SALBASND.DE_MAN, DBO.SALBASND.DE_TEL, DBO.SALBASND.DE_ADD, DBO.SALBASND.LAW_DEPT, 
                            DBO.SALBASND.LAW_MAN, DBO.SALBASND.LAW_TEL, DBO.SALBASND.P_DATE, DBO.SALBASND.F_DATE, 
                            DBO.SALBASND.T_DATE, DBO.SALBASND.C_DATE, DBO.SALBASND.P_PER, DBO.SALBASND.ACNO, DBO.BASE.NAME_C, 
                            ISNULL(DBO.DEPT.D_NAME, N'') AS DEPT_NAME, DBO.DEPT.D_NO, DBO.SALCODE.SAL_NAME, 
                            DBO.SALBASND.MIN_COST_LIVING
FROM              DBO.DEPT INNER JOIN
                            DBO.BASETTS ON DBO.DEPT.D_NO = DBO.BASETTS.DEPT INNER JOIN
                            DBO.SALBASND LEFT OUTER JOIN
                            DBO.BASE ON DBO.SALBASND.NOBR = DBO.BASE.NOBR ON DBO.BASETTS.NOBR = DBO.BASE.NOBR AND CONVERT (nvarchar(50), GETDATE(), 111) 
                            BETWEEN DBO.BASETTS.ADATE AND DBO.BASETTS.DDATE INNER JOIN
                            DBO.SALCODE ON DBO.SALBASND.SAL_CODE = DBO.SALCODE.SAL_CODE

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
         BEGIN TABLE = "DEPT"
            BEGIN EXTENT = 
               TOP = 32
               LEFT = 892
               BOTTOM = 151
               RIGHT = 1058
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "BASETTS"
            BEGIN EXTENT = 
               TOP = 28
               LEFT = 672
               BOTTOM = 147
               RIGHT = 838
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "SALBASND"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 38
               BOTTOM = 125
               RIGHT = 204
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 26
         END
         BEGIN TABLE = "BASE"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 446
               BOTTOM = 125
               RIGHT = 612
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "SALCODE"
            BEGIN EXTENT = 
               TOP = 73
               LEFT = 272
               BOTTOM = 192
               RIGHT = 438
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
      BEGIN COLUMNWIDTHS = 31
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
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 15', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM46B';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DIAGRAMPANE2', @value = N'00
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
         WIDTH = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM46B';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM46B';

