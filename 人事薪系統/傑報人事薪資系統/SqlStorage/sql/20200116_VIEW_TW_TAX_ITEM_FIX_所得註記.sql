/****** Object:  View [dbo].[VIEW_TW_TAX_ITEM]    Script Date: 2020/1/16 �W�� 11:16:27 ******/
DROP View [dbo].[VIEW_TW_TAX_ITEM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VIEW_TW_TAX_ITEM]
AS
SELECT          DBO.TW_TAX_ITEM.AUTO AS �s��, DBO.TW_TAX_ITEM.PID, DBO.TW_TAX_ITEM.NOBR AS ���u�s��, 
                            DBO.TW_TAX_ITEM.YYMM AS �ұo�~��, DBO.TW_TAX_ITEM.SEQ AS ���O, DBO.TW_TAX_ITEM.SAL_CODE AS �ӷ�, 
                            DBO.TW_TAX_ITEM.AMT AS ���I�`�B, DBO.TW_TAX_ITEM.D_AMT AS ��ú�|�B, 
                            DBO.TW_TAX_ITEM.FORMAT AS �ұo�榡, DBO.TW_TAX_ITEM.MEMO AS �Ƶ�, 
                            DBO.TW_TAX_ITEM.KEY_MAN AS �n����, DBO.TW_TAX_ITEM.KEY_DATE AS �n�����, 
                            DBO.TW_TAX_ITEM.TAXNO AS �|�y�s��, DBO.TW_TAX_ITEM.IMPORT AS �פJ, DBO.TW_TAX_ITEM.COMP AS ���q, 
                            DBO.COMP.COMPNAME AS ���q�W��, DBO.BASE.NAME_C AS ���u�m�W, 
                            DBO.TW_TAX_ITEM.RET_AMT AS �۴��h���, DBO.TW_TAX_ITEM.IS_FILE AS �w�ӳ�, 
                            DBO.TW_TAX_SUBCODE.M_FORSUB AS �ұo���O
FROM              DBO.TW_TAX_ITEM INNER JOIN
                            DBO.COMP ON DBO.TW_TAX_ITEM.COMP = DBO.COMP.COMP INNER JOIN
                            DBO.BASE ON DBO.TW_TAX_ITEM.NOBR = DBO.BASE.NOBR LEFT OUTER JOIN
                            DBO.TW_TAX_SUBCODE ON DBO.TW_TAX_ITEM.SUBCODE = DBO.TW_TAX_SUBCODE.AUTO
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DIAGRAMPANE1', @value=N'[0E232FF0-B466-11CF-A24F-00AA00A3EFFF, 1.00]
BEGIN DESIGNPROPERTIES = 
   BEGIN PANECONFIGURATIONS = 
      BEGIN PANECONFIGURATION = 0
         NUMPANES = 4
         CONFIGURATION = "(H (1[35] 4[26] 2[20] 3) )"
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
         BEGIN TABLE = "COMP"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 241
               BOTTOM = 136
               RIGHT = 416
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "BASE"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 454
               BOTTOM = 136
               RIGHT = 667
            END
            DISPLAYFLAGS = 280
            TOPCOLUMN = 0
         END
         BEGIN TABLE = "TW_TAX_ITEM"
            BEGIN EXTENT = 
               TOP = 6
               LEFT = 38
               BOTTOM = 136
               RIGHT = 203
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
      BEGIN COLUMNWIDTHS = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_TW_TAX_ITEM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DIAGRAMPANECOUNT', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_TW_TAX_ITEM'
GO


