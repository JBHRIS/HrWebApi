﻿CREATE VIEW [dbo].[VIEW_TW_TAX_ITEM]
AS
SELECT  dbo.TW_TAX_ITEM.AUTO AS 編號, dbo.TW_TAX_ITEM.PID,  dbo.TW_TAX_ITEM.COMP AS 公司, 
               dbo.COMP.COMPNAME AS 公司名稱, dbo.TW_TAX_ITEM.NOBR AS 員工編號, dbo.TBASE.NAME_C AS 員工姓名, dbo.TW_TAX_ITEM.YYMM AS 所得年月, dbo.TW_TAX_ITEM.SEQ AS 期別, 
               dbo.TW_TAX_ITEM.SAL_CODE AS 來源, dbo.TW_TAX_ITEM.AMT AS 給付總額, dbo.TW_TAX_ITEM.D_AMT AS 扣繳稅額, 
               dbo.TW_TAX_ITEM.SUP_AMT AS 補充保費, dbo.TW_TAX_ITEM.RET_AMT AS 自提退休金, dbo.TW_TAX_ITEM.FORMAT AS 所得格式, 
               dbo.TW_TAX_SUBCODE.M_FORSUB AS 所得註記, dbo.TW_TAX_ITEM.TAXNO AS 稅籍編號, dbo.TW_TAX_ITEM.MEMO AS 備註, 
               dbo.TW_TAX_ITEM.IS_FILE AS 已申報, dbo.TW_TAX_ITEM.KEY_MAN AS 登錄者, dbo.TW_TAX_ITEM.KEY_DATE AS 登錄日期, 
               dbo.TW_TAX_ITEM.IMPORT AS 匯入
FROM     dbo.TW_TAX_ITEM INNER JOIN
               dbo.COMP ON dbo.TW_TAX_ITEM.COMP = dbo.COMP.COMP INNER JOIN
               dbo.TBASE ON dbo.TW_TAX_ITEM.NOBR = dbo.TBASE.NOBR LEFT OUTER JOIN
               dbo.TW_TAX_SUBCODE ON dbo.TW_TAX_ITEM.SUBCODE = dbo.TW_TAX_SUBCODE.AUTO
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIEW_TW_TAX_ITEM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TW_TAX_ITEM"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 9
               Left = 333
               Bottom = 196
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBASE"
            Begin Extent = 
               Top = 9
               Left = 685
               Bottom = 196
               Right = 904
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TW_TAX_SUBCODE"
            Begin Extent = 
               Top = 9
               Left = 961
               Bottom = 196
               Right = 1186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIEW_TW_TAX_ITEM';

