/****** Object:  UserDefinedFunction [dbo].[GetFilterByNobr1]    Script Date: 2019/11/18 ¤W¤È 10:50:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE [dbo].[SALBASND]
ADD MIN_COST_LIVING  decimal(16, 2) DEFAULT 0 NOT NULL
GO

DROP VIEW [dbo].[FRM46B]
GO

CREATE VIEW [dbo].[FRM46B]
AS
SELECT          dbo.SALBASND.NOBR, dbo.SALBASND.YYMM_B, dbo.SALBASND.YYMM_E, dbo.SALBASND.SAL_CODE, 
                            dbo.SALBASND.SEQ, dbo.SALBASND.A_DATE, dbo.SALBASND.A_TYPE, dbo.SALBASND.A_PER, 
                            dbo.SALBASND.F_AMT, dbo.SALBASND.P_AMT, dbo.SALBASND.T_AMT, dbo.SALBASND.KEY_MAN, 
                            dbo.SALBASND.KEY_DATE, dbo.SALBASND.MEMO, dbo.SALBASND.DISPATCH, dbo.SALBASND.DE_DEPT, 
                            dbo.SALBASND.DE_MAN, dbo.SALBASND.DE_TEL, dbo.SALBASND.DE_ADD, dbo.SALBASND.LAW_DEPT, 
                            dbo.SALBASND.LAW_MAN, dbo.SALBASND.LAW_TEL, dbo.SALBASND.P_DATE, dbo.SALBASND.F_DATE, 
                            dbo.SALBASND.T_DATE, dbo.SALBASND.C_DATE, dbo.SALBASND.P_PER, dbo.SALBASND.ACNO, dbo.BASE.NAME_C, 
                            ISNULL(dbo.DEPT.D_NAME, N'') AS DEPT_NAME, dbo.DEPT.D_NO, dbo.SALCODE.SAL_NAME, 
                            dbo.SALBASND.MIN_COST_LIVING
FROM              dbo.DEPT INNER JOIN
                            dbo.BASETTS ON dbo.DEPT.D_NO = dbo.BASETTS.DEPT INNER JOIN
                            dbo.SALBASND LEFT OUTER JOIN
                            dbo.BASE ON dbo.SALBASND.NOBR = dbo.BASE.NOBR ON dbo.BASETTS.NOBR = dbo.BASE.NOBR AND GETDATE() 
                            BETWEEN dbo.BASETTS.ADATE AND dbo.BASETTS.DDATE INNER JOIN
                            dbo.SALCODE ON dbo.SALBASND.SAL_CODE = dbo.SALCODE.SAL_CODE
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
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
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 32
               Left = 892
               Bottom = 151
               Right = 1058
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 28
               Left = 672
               Bottom = 147
               Right = 838
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALBASND"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 26
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALCODE"
            Begin Extent = 
               Top = 73
               Left = 272
               Bottom = 192
               Right = 438
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
      Begin ColumnWidths = 31
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 15' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FRM46B'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'00
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FRM46B'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FRM46B'
GO


