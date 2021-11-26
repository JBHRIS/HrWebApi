Drop view [dbo].[人事系統_員工基本資料表]
GO

/****** Object:  View [dbo].[人事系統_員工基本資料表]    Script Date: 2019/11/26 上午 11:00:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[人事系統_員工基本資料表]
AS
SELECT  TOP (100) 
               PERCENT (CASE b.ttscode WHEN '1' THEN '在職' WHEN '4' THEN '在職' WHEN '6' THEN '在職' WHEN '3' THEN '留職停薪' WHEN '5' THEN '停離' WHEN '2' THEN
                '離職' END) AS 狀態, a.NOBR AS 工號, a.NAME_C AS 員工姓名, a.NAME_E AS 英文姓名, a.IDNO AS 身分證號, a.BIRDT AS 出生日期, DATEDIFF(d, 
               a.BIRDT, GETDATE()) / 365 AS 年齡, a.SEX AS 性別, a.BLOOD AS 血型, a.MARRY AS 姻婚, a.TAXNO AS 護照號碼, a.MATNO AS 居留證號, 
               a.BASECD AS 身份別, a.COUNTRY AS 國籍, a.GSM AS 行動電話, a.TEL1 AS as通訊電話, a.POSTCODE1 AS 通訊郵遞區號, a.ADDR1 AS 通訊地址, 
               a.TEL2 AS 戶籍電話, a.POSTCODE2 AS 戶籍郵遞區號, a.ADDR2 AS 戶籍地址, b.DI AS 直間接, b.TTSCODE AS 異動狀態, b.INDT AS 到職日期, 
               dbo.GetTotalYears(a.NOBR, GETDATE()) AS 年資, b.OUDT AS 離職日期, b.STDT AS 停薪日期, b.STINDT AS 停復日期, b.AP_DATE AS 試用期滿日, 
               b.DEPT AS 部門代碼, c.D_NAME AS 部門名稱, b.DEPTS AS 成本部門代碼, d.D_NAME AS 成本部門名稱, b.JOB AS 職稱代碼, e.JOB_NAME AS 職稱, 
               b.JOBL AS 職等代碼, f.JOB_NAME AS 職等名稱, b.ROTET AS 班別, b.TAX_DATE AS 居留證起始日, b.TAX_EDATE AS 居留證到期日, 
               a.BANKNO AS 轉帳行號, a.ACCOUNT_NO AS 轉帳帳號, a.TAXCNT AS 扶養人數, b.MENO AS 備註, dbo.COMP.COMPNAME AS 公司名稱, 
               b.JOBS AS 職類代碼, dbo.JOBS.JOB_NAME AS 職類名稱, b.EMPCD AS 員別代碼, dbo.EMPCD.EMPDESCR AS 員別員稱, ISNULL(b.OUTCD, N'') 
               AS 離職原因代碼, ISNULL(dbo.OUTCD.OUTNAME, N'') AS 離職原因, b.TTSCD AS 異動原因代碼, dbo.TTSCD.TTSNAME AS 異動原因, 
               dbo.WORKCD.WORK_ADDR AS 工作地, b.ADATE AS 異動生效日, b.DDATE AS 異動失效日
FROM     dbo.BASE AS a INNER JOIN
               dbo.BASETTS AS b LEFT OUTER JOIN
               dbo.DEPT AS c ON b.DEPT = c.D_NO LEFT OUTER JOIN
               dbo.DEPTS AS d ON b.DEPTS = d.D_NO LEFT OUTER JOIN
               dbo.JOB AS e ON b.JOB = e.JOB LEFT OUTER JOIN
               dbo.JOBL AS f ON b.JOBL = f.JOBL ON a.NOBR = b.NOBR LEFT OUTER JOIN
               dbo.WORKCD ON b.WORKCD = dbo.WORKCD.WORK_CODE LEFT OUTER JOIN
               dbo.TTSCD ON b.TTSCD = dbo.TTSCD.TTSCD LEFT OUTER JOIN
               dbo.OUTCD ON b.OUTCD = dbo.OUTCD.OUTCD LEFT OUTER JOIN
               dbo.EMPCD ON b.EMPCD = dbo.EMPCD.EMPCD LEFT OUTER JOIN
               dbo.COMP ON b.COMP = dbo.COMP.COMP LEFT OUTER JOIN
               dbo.JOBS ON b.JOBS = dbo.JOBS.JOBS
WHERE   (dbo.Today() BETWEEN b.ADATE AND b.DDATE)
ORDER BY 到職日期 DESC
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[27] 2[21] 3) )"
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
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 242
               Bottom = 125
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 125
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "f"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 245
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WORKCD"
            Begin Extent = 
               Top = 246
               Left = 650
               Bottom = 365
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'人事系統_員工基本資料表'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Begin Table = "TTSCD"
            Begin Extent = 
               Top = 126
               Left = 446
               Bottom = 245
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OUTCD"
            Begin Extent = 
               Top = 126
               Left = 650
               Bottom = 245
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EMPCD"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 246
               Left = 242
               Bottom = 365
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBS"
            Begin Extent = 
               Top = 246
               Left = 446
               Bottom = 365
               Right = 612
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
      Begin ColumnWidths = 54
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'人事系統_員工基本資料表'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'人事系統_員工基本資料表'
GO


