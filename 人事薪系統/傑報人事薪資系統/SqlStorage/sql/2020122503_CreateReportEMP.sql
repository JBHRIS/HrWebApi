/****** Object:  View [dbo].[ReportEMP]    Script Date: 2020/9/8 下午 02:48:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[ReportEMP]
AS
SELECT          dbo.BASE.NOBR AS 員工編號, dbo.BASE.NAME_C AS 員工姓名, dbo.BASE.NAME_E AS 英文姓名, 
                            dbo.BASE.NAME_P AS 護照姓名, dbo.BASE.SEX AS 性別, dbo.BASE.BIRDT AS 出生日期, 
                            dbo.BASE.ADDR1 AS 通訊地址, dbo.BASE.ADDR2 AS 戶籍地址, dbo.BASE.TEL1 AS 通訊電話, 
                            dbo.BASE.TEL2 AS 戶籍電話, dbo.BASE.EMAIL AS 電子郵件, dbo.BASE.GSM AS 行動電話, 
                            dbo.BASE.IDNO AS 身分證號, dbo.BASE.CONT_MAN AS 連絡人1姓名, dbo.BASE.CONT_TEL AS 連絡人1電話, 
                            dbo.BASE.CONT_GSM AS 連絡人1行動電話, dbo.BASE.CONT_MAN2 AS 連絡人2姓名, 
                            dbo.BASE.CONT_TEL2 AS 連絡人2電話, dbo.BASE.CONT_GSM2 AS 連絡人2行動電話, dbo.BASE.BLOOD AS 血型, 
                            dbo.BASE.PASSWORD AS 密碼, dbo.BASE.POSTCODE1 AS 通訊郵遞區號, dbo.BASE.POSTCODE2 AS 戶籍郵遞區號, 
                            dbo.BASE.BANK_CODE AS 轉帳銀行, dbo.BASE.ACCOUNT_NO AS 轉帳帳號, dbo.BASE.MARRY AS 婚姻, 
                            dbo.BASE.COUNTRY AS 國籍, dbo.BASE.COUNT_MA AS 外籍員工, dbo.BASE.ARMY AS 兵役, 
                            dbo.BASE.PRO_MAN1 AS 保證人1姓名, dbo.BASE.PRO_ADDR1 AS 保證人1住址, 
                            dbo.BASE.PRO_ID1 AS 保證人1身分證號, dbo.BASE.PRO_TEL1 AS 保證人1電話, 
                            dbo.BASE.PRO_MAN2 AS 保證人2姓名, dbo.BASE.PRO_ADDR2 AS 保證人2住址, 
                            dbo.BASE.PRO_ID2 AS 保證人2身分證號, dbo.BASE.PRO_TEL2 AS 保證人2電話, dbo.BASE.NOBR_B AS 介紹人, 
                            dbo.BASE.PROVINCE AS 出生地, dbo.BASE.TAXCNT AS 扶養人數, dbo.BASE.TAXNO AS 護照號碼, 
                            dbo.BASE.PRETAX AS 所得稅預扣金額, dbo.BASE.CONT_REL1 AS 連絡人1關係, 
                            dbo.BASE.CONT_REL2 AS 連絡人2關係, dbo.BASE.ACCOUNT_MA AS 外勞帳號, dbo.BASE.MATNO AS 居留證號, 
                            dbo.BASE.SUBTEL AS 分機, dbo.BASE.BASECD AS 身分別, dbo.BASE.NAME_AD AS AD帳號, 
                            dbo.BASE.AdditionNO AS 增補單號, dbo.BASE.Introductor, dbo.BASETTS.ADATE AS 異動生效日, 
                            dbo.BASETTS.TTSCODE AS 異動狀態, dbo.BASETTS.DDATE AS 異動失效日, dbo.BASETTS.INDT AS 公司到職日, 
                            dbo.BASETTS.CINDT AS 集團到職日, dbo.BASETTS.OUDT AS 離職日, dbo.BASETTS.OUTCD AS 離職原因代碼, 
                            dbo.OUTCD.OUTNAME AS 離職原因名稱, dbo.BASETTS.STDT AS 停薪日期, dbo.BASETTS.STINDT AS 停復日期, 
                            dbo.BASETTS.STOUDT AS 停離日期, dbo.BASETTS.COMP AS 公司別, dbo.BASETTS.CARD AS 刷卡, 
                            dbo.BASETTS.DI AS 直間接, dbo.BASETTS.MANG AS 部門主管, dbo.BASETTS.WK_YRS AS 外部年資, 
                            dbo.BASETTS.SALTP AS 薪別代碼, dbo.SALTYCD.SALTYNAME AS 薪別名稱, dbo.BASETTS.CALABS AS 不計算請假, 
                            dbo.BASETTS.FULATT AS 不計算工作獎金, dbo.BASETTS.NOTER AS 不判斷遲到早退, 
                            dbo.BASETTS.NOWEL AS 不計算福利金, dbo.BASETTS.NORET AS 不計算退休金新制, 
                            dbo.BASETTS.NOOT AS 不產生加班, dbo.BASETTS.NOSPEC AS 不計算特休代金, 
                            dbo.BASETTS.NOCARD AS 不計算所得稅, dbo.BASETTS.NOEAT AS 可申請補休, dbo.BASETTS.MENO AS 異動備註, 
                            dbo.BASETTS.SALADR AS 資料群組代碼, dbo.DATAGROUP.GROUPNAME AS 資料群組名稱, 
                            dbo.BASETTS.NOWAGE AS 不發薪, dbo.BASETTS.MANGE AS 可知網頁人事資料, 
                            dbo.BASETTS.RETRATE AS 員工勞退提撥比率, dbo.BASETTS.RETDATE AS 勞退新制日期, 
                            dbo.BASETTS.RETCHOO AS 退休金制度, dbo.BASETTS.RETDATE1 AS 勞退新制提撥日, 
                            dbo.BASETTS.ONLYONTIME AS 只刷上班卡, dbo.BASETTS.COUNT_PASS AS 可線上刷卡, 
                            dbo.BASETTS.MANG1 AS 可代申請表單, dbo.BASETTS.AP_DATE AS 試用期滿日, 
                            dbo.BASETTS.TAX_DATE AS 居留証起始日, dbo.BASETTS.TAX_EDATE AS 居留証到期日, 
                            dbo.BASETTS.NOSPAMT AS 不計算三節獎金, dbo.BASETTS.FIXRATE AS 所得稅固定稅率扣繳, 
                            dbo.DEPT.D_NO_DISP AS 編制部門代碼, dbo.DEPT.D_NAME AS 編制部門名稱, 
                            dbo.DEPTA.D_NO_DISP AS 簽核部門代碼, dbo.DEPTA.D_NAME AS 簽核部門名稱, 
                            dbo.DEPTS.D_NO_DISP AS 成本部門代碼, dbo.DEPTS.D_NAME AS 成本部門名稱, dbo.JOB.JOB_DISP AS 職稱代碼, 
                            dbo.JOB.JOB_NAME AS 職稱名稱, dbo.JOBL.JOBL_DISP AS 職等代碼, dbo.JOBL.JOB_NAME AS 職等名稱, 
                            dbo.BASETTS.WORKCD AS 工作地代碼, dbo.WORKCD.WORK_ADDR AS 工作地名稱, 
                            dbo.JOBS.JOBS_DISP AS 職類代碼, dbo.JOBS.JOB_NAME AS 職類名稱, dbo.JOBO.JOBO AS 職級代碼, 
                            dbo.JOBO.JOB_NAME AS 職級名稱, dbo.TTSCD.TTSCD_DISP AS 異動原因代碼, 
                            dbo.TTSCD.TTSNAME AS 異動原因名稱, dbo.ROTET.ROTET_DISP AS 輪班別代碼, 
                            dbo.ROTET.ROTETNAME AS 輪班別名稱, dbo.HOLICD.HOLI_CODE_DISP AS 行事曆代碼, 
                            dbo.HOLICD.HOLI_NAME AS 行事曆名稱, dbo.BASETTS.EMPCD AS 員別代碼, dbo.EMPCD.EMPDESCR AS 員別名稱, 
                            dbo.BASETTS.CALOT AS 加班比率代碼, dbo.OTRATECD.OTRATE_NAME AS 加班比率名稱
FROM              dbo.BASE INNER JOIN
                            dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR LEFT OUTER JOIN
                            dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO LEFT OUTER JOIN
                            dbo.DEPTA ON dbo.BASETTS.DEPTM = dbo.DEPTA.D_NO LEFT OUTER JOIN
                            dbo.DEPTS ON dbo.BASETTS.DEPTS = dbo.DEPTS.D_NO LEFT OUTER JOIN
                            dbo.JOB ON dbo.BASETTS.JOB = dbo.JOB.JOB LEFT OUTER JOIN
                            dbo.JOBO ON dbo.BASETTS.JOBO = dbo.JOB.JOB LEFT OUTER JOIN
                            dbo.JOBL ON dbo.BASETTS.JOBL = dbo.JOBL.JOBL LEFT OUTER JOIN
                            dbo.JOBS ON dbo.BASETTS.JOBS = dbo.JOBS.JOBS LEFT OUTER JOIN
                            dbo.WORKCD ON dbo.BASETTS.WORKCD = dbo.WORKCD.WORK_CODE LEFT OUTER JOIN
                            dbo.TTSCD ON dbo.BASETTS.TTSCD = dbo.TTSCD.TTSCD LEFT OUTER JOIN
                            dbo.ROTET ON dbo.BASETTS.ROTET = dbo.ROTET.ROTET LEFT OUTER JOIN
                            dbo.EMPCD ON dbo.BASETTS.EMPCD = dbo.EMPCD.EMPCD LEFT OUTER JOIN
                            dbo.OUTCD ON dbo.BASETTS.OUTCD = dbo.OUTCD.OUTCD LEFT OUTER JOIN
                            dbo.HOLICD ON dbo.BASETTS.HOLI_CODE = dbo.HOLICD.HOLI_CODE LEFT OUTER JOIN
                            dbo.OTRATECD ON dbo.BASETTS.CALOT = dbo.OTRATECD.OTRATE_CODE LEFT OUTER JOIN
                            dbo.DATAGROUP ON dbo.BASETTS.SALADR = dbo.DATAGROUP.DATAGROUP LEFT OUTER JOIN
                            dbo.SALTYCD ON dbo.BASETTS.SALTP = dbo.SALTYCD.SALTYCD
WHERE          (dbo.today() BETWEEN dbo.BASETTS.ADATE AND dbo.BASETTS.DDATE)


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[14] 2[27] 3) )"
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
         Top = -125
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 6
               Left = 492
               Bottom = 136
               Right = 659
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTA"
            Begin Extent = 
               Top = 6
               Left = 697
               Bottom = 136
               Right = 864
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOB"
            Begin Extent = 
               Top = 138
               Left = 241
               Bottom = 268
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBO"
            Begin Extent = 
               Top = 269
               Left = 38
               Bottom = 399
               Right = 203
            End
            DisplayFlags = 280
            TopCo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'lumn = 0
         End
         Begin Table = "JOBL"
            Begin Extent = 
               Top = 138
               Left = 444
               Bottom = 268
               Right = 609
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBS"
            Begin Extent = 
               Top = 138
               Left = 647
               Bottom = 268
               Right = 812
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WORKCD"
            Begin Extent = 
               Top = 138
               Left = 850
               Bottom = 268
               Right = 1015
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TTSCD"
            Begin Extent = 
               Top = 269
               Left = 241
               Bottom = 399
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTET"
            Begin Extent = 
               Top = 269
               Left = 444
               Bottom = 399
               Right = 626
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EMPCD"
            Begin Extent = 
               Top = 269
               Left = 664
               Bottom = 399
               Right = 829
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HOLICD"
            Begin Extent = 
               Top = 269
               Left = 867
               Bottom = 399
               Right = 1054
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OTRATECD"
            Begin Extent = 
               Top = 401
               Left = 38
               Bottom = 531
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DATAGROUP"
            Begin Extent = 
               Top = 401
               Left = 281
               Bottom = 531
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALTYCD"
            Begin Extent = 
               Top = 401
               Left = 488
               Bottom = 531
               Right = 653
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CostType"
            Begin Extent = 
               Top = 401
               Left = 691
               Bottom = 531
               Right = 868
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OUTCD"
            Begin Extent = 
               Top = 533
               Left = 38
               Bottom = 663
               Right = 203
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
      Begin ColumnWidths = 9
         Width = 284
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
         S' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane3', @value=N'ortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=3 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO


