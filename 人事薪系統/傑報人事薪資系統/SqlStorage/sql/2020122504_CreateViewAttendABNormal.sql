/****** Object:  View [dbo].[View_ATTEND_ABNORMAL]    Script Date: 2020/9/8 下午 02:07:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_ATTEND_ABNORMAL]
AS
SELECT     aa.NOBR AS EmployeeId, bs.NAME_C AS EmployeeName, aa.ADATE AS AttendanceDate, mt.NAME AS State, aa.ERROR_MINS AS ErrorMins, aa.ON_TIME AS OnTime, 
                      aa.OFF_TIME AS OffTime, aa.ON_TIME_ACTUAL AS ActualOnTime, aa.OFF_TIME_ACTUAL AS ActualOffTime, rt.ROTENAME, CONVERT(bit, 
                      CASE WHEN aac.id IS NOT NULL THEN 1 ELSE 0 END) AS IsCheck, aac.REMARK, aac.SERNO, mt1.NAME AS RemarkType, aa.ID
FROM         dbo.ATTEND_ABNORMAL AS aa INNER JOIN
                      dbo.MTCODE AS mt ON mt.CATEGORY = 'ATTEND_ABNORMAL' AND mt.CODE = aa.TYPE INNER JOIN
                      dbo.ATTEND AS att ON att.NOBR = aa.NOBR AND att.ADATE = aa.ADATE INNER JOIN
                      dbo.BASE AS bs ON bs.NOBR = aa.NOBR INNER JOIN
                      dbo.ROTE AS rt ON rt.ROTE = aa.ROTE_CODE INNER JOIN
                      dbo.ReportEMP AS emp ON emp.員工編號 = aa.NOBR LEFT OUTER JOIN
                      dbo.ATTEND_ABNORMAL_CHECK AS aac ON aa.NOBR = aac.NOBR AND aac.ADATE = aa.ADATE AND aac.TYPE = aa.TYPE LEFT OUTER JOIN
                      dbo.MTCODE AS mt1 ON mt1.CATEGORY = 'ATTEND_ABNORMAL_CHECK' AND mt1.CODE = aac.REMARK_TYPE
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
         Begin Table = "aa"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mt"
            Begin Extent = 
               Top = 6
               Left = 281
               Bottom = 114
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "att"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 222
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bs"
            Begin Extent = 
               Top = 114
               Left = 227
               Bottom = 222
               Right = 395
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rt"
            Begin Extent = 
               Top = 222
               Left = 38
               Bottom = 330
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "emp"
            Begin Extent = 
               Top = 222
               Left = 246
               Bottom = 330
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "aac"
            Begin Extent = 
               Top = 330
               Left = 38
               Bottom = 438
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ATTEND_ABNORMAL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    End
         Begin Table = "mt1"
            Begin Extent = 
               Top = 330
               Left = 227
               Bottom = 438
               Right = 378
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ATTEND_ABNORMAL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ATTEND_ABNORMAL'
GO


