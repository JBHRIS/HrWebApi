CREATE VIEW [dbo].[人事系統_加班資料表]
AS
SELECT     dbo.人事系統_員工基本資料表_需加異動日.狀態, dbo.人事系統_員工基本資料表_需加異動日.工號, dbo.人事系統_員工基本資料表_需加異動日.員工姓名, 
                      dbo.人事系統_員工基本資料表_需加異動日.英文姓名, dbo.人事系統_員工基本資料表_需加異動日.性別, dbo.人事系統_員工基本資料表_需加異動日.身份別, 
                      dbo.人事系統_員工基本資料表_需加異動日.直間接, dbo.人事系統_員工基本資料表_需加異動日.到職日期, dbo.人事系統_員工基本資料表_需加異動日.年資, 
                      dbo.人事系統_員工基本資料表_需加異動日.離職日期, dbo.人事系統_員工基本資料表_需加異動日.部門代碼, dbo.人事系統_員工基本資料表_需加異動日.部門名稱, 
                      dbo.人事系統_員工基本資料表_需加異動日.成本部門代碼, dbo.人事系統_員工基本資料表_需加異動日.成本部門名稱, 
                      dbo.人事系統_員工基本資料表_需加異動日.職稱代碼, dbo.人事系統_員工基本資料表_需加異動日.職稱, dbo.人事系統_員工基本資料表_需加異動日.職等代碼, 
                      dbo.人事系統_員工基本資料表_需加異動日.職等名稱, dbo.人事系統_員工基本資料表_需加異動日.班別, dbo.人事系統_員工基本資料表_需加異動日.職類代碼, 
                      dbo.人事系統_員工基本資料表_需加異動日.職類名稱, dbo.人事系統_員工基本資料表_需加異動日.員別代碼, dbo.人事系統_員工基本資料表_需加異動日.員別員稱, 
                      dbo.OT.BDATE AS 加班日期, dbo.OT.BTIME AS 加班起時間, dbo.OT.ETIME AS 加班迄時間, dbo.OT.TOT_HOURS AS 加班總時數, dbo.OT.OT_HRS AS 加班時數, 
                      dbo.OT.REST_HRS AS 補休時數, dbo.OT.OT_DEPT AS 成本代碼, dbo.DEPTS.D_NAME AS 成本中心, dbo.OT.NOTE AS 備註, dbo.OT.YYMM AS 計薪年月, 
                      dbo.DECODE(dbo.OT.SALARY) AS 基本薪資, dbo.OT.OT_ROTE AS 加班班別, ROTE_1.ROTENAME AS 加班班別名稱, dbo.ATTEND.ROTE AS 出勤班別, 
                      dbo.ROTE.ROTENAME AS 出勤班別名稱, dbo.ATTCARD.T1 AS 上班卡, dbo.ATTCARD.T2 AS 下班卡, dbo.DECODE(dbo.OT.NOT_EXP) AS 加班費, 
                      dbo.OTRCD.OTRNAME AS 加班原因
FROM         dbo.OTRCD RIGHT OUTER JOIN
                      dbo.OT ON dbo.OTRCD.OTRCD = dbo.OT.OTRCD LEFT OUTER JOIN
                      dbo.ROTE INNER JOIN
                      dbo.ATTEND ON dbo.ROTE.ROTE = dbo.ATTEND.ROTE ON dbo.OT.NOBR = dbo.ATTEND.NOBR AND dbo.OT.BDATE = dbo.ATTEND.ADATE LEFT OUTER JOIN
                      dbo.ATTCARD ON dbo.OT.BDATE = dbo.ATTCARD.ADATE AND dbo.OT.NOBR = dbo.ATTCARD.NOBR LEFT OUTER JOIN
                      dbo.ROTE AS ROTE_1 ON dbo.OT.OTNO = ROTE_1.ROTE LEFT OUTER JOIN
                      dbo.人事系統_員工基本資料表_需加異動日 ON dbo.OT.NOBR = dbo.人事系統_員工基本資料表_需加異動日.工號 LEFT OUTER JOIN
                      dbo.DEPTS ON dbo.OT.OT_DEPT = dbo.DEPTS.D_NO
WHERE     (dbo.OT.BDATE BETWEEN dbo.人事系統_員工基本資料表_需加異動日.ADATE AND dbo.人事系統_員工基本資料表_需加異動日.DDATE)

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
         Begin Table = "OTRCD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OT"
            Begin Extent = 
               Top = 6
               Left = 242
               Bottom = 125
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTEND"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 125
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTCARD"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE_1"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 245
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "人事系統_員工基本資料表_需加異動日"
            Begin Extent = 
               Top = 126
               Left = 446
               Bottom = 245
               Right = 612
            End
            DisplayFlags = 280
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_加班資料表';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 126
               Left = 650
               Bottom = 245
               Right = 816
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
      Begin ColumnWidths = 11
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_加班資料表';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_加班資料表';

