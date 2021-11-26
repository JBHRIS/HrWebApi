CREATE VIEW [dbo].[ReportEMP]
AS
SELECT          DBO.BASE.NOBR AS 員工編號, DBO.BASE.NAME_C AS 員工姓名, DBO.BASE.NAME_E AS 英文姓名, 
                            CASE WHEN DBO.BASETTS.TTSCODE IN ('1', '4', '6') 
                            THEN '在職' ELSE (CASE WHEN DBO.BASETTS.TTSCODE = '3' THEN '留停' ELSE '離職' END) END AS 狀態, 
                            DBO.BASE.NAME_P AS 護照姓名, DBO.BASE.SEX AS 性別, DBO.BASE.BIRDT AS 出生日期, 
                            DBO.BASE.ADDR1 AS 通訊地址, DBO.BASE.ADDR2 AS 戶籍地址, DBO.BASE.TEL1 AS 通訊電話, 
                            DBO.BASE.TEL2 AS 戶籍電話, DBO.BASE.EMAIL AS 電子郵件, DBO.BASE.GSM AS 行動電話, 
                            DBO.BASE.IDNO AS 身分證號, DBO.BASE.CONT_MAN AS 連絡人1姓名, DBO.BASE.CONT_TEL AS 連絡人1電話, 
                            DBO.BASE.CONT_GSM AS 連絡人1行動電話, DBO.BASE.CONT_MAN2 AS 連絡人2姓名, 
                            DBO.BASE.CONT_TEL2 AS 連絡人2電話, DBO.BASE.CONT_GSM2 AS 連絡人2行動電話, DBO.BASE.BLOOD AS 血型, 
                            DBO.BASE.PASSWORD AS 密碼, DBO.BASE.POSTCODE1 AS 通訊郵遞區號, DBO.BASE.POSTCODE2 AS 戶籍郵遞區號, 
                            DBO.BASE.BANK_CODE AS 轉帳銀行, DBO.BASE.ACCOUNT_NO AS 轉帳帳號, DBO.BASE.MARRY AS 婚姻, 
                            DBO.BASE.COUNTRY AS 國籍, DBO.BASE.COUNT_MA AS 外籍員工, DBO.BASE.ARMY AS 兵役, 
                            DBO.BASE.PRO_MAN1 AS 保證人1姓名, DBO.BASE.PRO_ADDR1 AS 保證人1住址, 
                            DBO.BASE.PRO_ID1 AS 保證人1身分證號, DBO.BASE.PRO_TEL1 AS 保證人1電話, 
                            DBO.BASE.PRO_MAN2 AS 保證人2姓名, DBO.BASE.PRO_ADDR2 AS 保證人2住址, 
                            DBO.BASE.PRO_ID2 AS 保證人2身分證號, DBO.BASE.PRO_TEL2 AS 保證人2電話, DBO.BASE.NOBR_B AS 介紹人, 
                            DBO.BASE.PROVINCE AS 出生地, DBO.BASE.TAXCNT AS 扶養人數, DBO.BASE.TAXNO AS 護照號碼, 
                            DBO.BASE.PRETAX AS 所得稅預扣金額, DBO.BASE.CONT_REL1 AS 連絡人1關係, 
                            DBO.BASE.CONT_REL2 AS 連絡人2關係, DBO.BASE.ACCOUNT_MA AS 外勞帳號, DBO.BASE.MATNO AS 居留證號, 
                            DBO.BASE.SUBTEL AS 分機, DBO.BASE.BASECD AS 身分別, DBO.BASE.NAME_AD AS AD帳號, 
                            DBO.BASE.ADDITIONNO AS 增補單號, DBO.BASE.INTRODUCTOR, DBO.BASETTS.ADATE AS 異動生效日, 
                            DBO.BASETTS.TTSCODE AS 異動狀態, DBO.BASETTS.DDATE AS 異動失效日, DBO.BASETTS.INDT AS 公司到職日, 
                            DBO.BASETTS.CINDT AS 集團到職日, DBO.BASETTS.OUDT AS 離職日, DBO.BASETTS.OUTCD AS 離職原因代碼, 
                            DBO.OUTCD.OUTNAME AS 離職原因名稱, DBO.BASETTS.STDT AS 停薪日期, DBO.BASETTS.STINDT AS 停復日期, 
                            DBO.BASETTS.STOUDT AS 停離日期, DBO.BASETTS.COMP AS 公司別, DBO.BASETTS.CARD AS 刷卡, 
                            DBO.BASETTS.DI AS 直間接, DBO.BASETTS.MANG AS 部門主管, DBO.BASETTS.WK_YRS AS 外部年資, 
                            DBO.BASETTS.SALTP AS 薪別代碼, DBO.SALTYCD.SALTYNAME AS 薪別名稱, DBO.BASETTS.CALABS AS 不計算請假, 
                            DBO.BASETTS.FULATT AS 不計算工作獎金, DBO.BASETTS.NOTER AS 不判斷遲到早退, 
                            DBO.BASETTS.NOWEL AS 不計算福利金, DBO.BASETTS.NORET AS 不計算退休金新制, 
                            DBO.BASETTS.NOOT AS 不產生加班, DBO.BASETTS.NOSPEC AS 不計算特休代金, 
                            DBO.BASETTS.NOCARD AS 不計算所得稅, DBO.BASETTS.NOEAT AS 可申請補休, DBO.BASETTS.MENO AS 異動備註, 
                            DBO.BASETTS.SALADR AS 資料群組代碼, DBO.DATAGROUP.GROUPNAME AS 資料群組名稱, 
                            DBO.BASETTS.NOWAGE AS 不發薪, DBO.BASETTS.MANGE AS 可知網頁人事資料, 
                            DBO.BASETTS.RETRATE AS 員工勞退提撥比率, DBO.BASETTS.RETDATE AS 勞退新制日期, 
                            DBO.BASETTS.RETCHOO AS 退休金制度, DBO.BASETTS.RETDATE1 AS 勞退新制提撥日, 
                            DBO.BASETTS.ONLYONTIME AS 只刷上班卡, DBO.BASETTS.COUNT_PASS AS 可線上刷卡, 
                            DBO.BASETTS.MANG1 AS 可代申請表單, DBO.BASETTS.AP_DATE AS 試用期滿日, 
                            DBO.BASETTS.TAX_DATE AS 居留証起始日, DBO.BASETTS.TAX_EDATE AS 居留証到期日, 
                            DBO.BASETTS.NOSPAMT AS 不計算三節獎金, DBO.BASETTS.FIXRATE AS 所得稅固定稅率扣繳, 
                            DBO.BASETTS.NOOLDRET AS 不計算退休金舊制, DBO.BASETTS.REINSTATEDATE AS 預計復職日, 
                            DBO.BASETTS.PASS_TYPE AS 評核狀態, DBO.BASETTS.AUDITDATE AS 評核日期, 
                            DBO.DEPT.D_NO_DISP AS 編制部門代碼, DBO.DEPT.D_NAME AS 編制部門名稱, 
                            DBO.DEPTA.D_NO_DISP AS 簽核部門代碼, DBO.DEPTA.D_NAME AS 簽核部門名稱, 
                            DBO.DEPTS.D_NO_DISP AS 成本部門代碼, DBO.DEPTS.D_NAME AS 成本部門名稱, DBO.JOB.JOB_DISP AS 職稱代碼, 
                            DBO.JOB.JOB_NAME AS 職稱名稱, DBO.JOBL.JOBL_DISP AS 職等代碼, DBO.JOBL.JOB_NAME AS 職等名稱, 
                            DBO.BASETTS.WORKCD AS 工作地代碼, DBO.WORKCD.WORK_ADDR AS 工作地名稱, 
                            DBO.JOBS.JOBS_DISP AS 職類代碼, DBO.JOBS.JOB_NAME AS 職類名稱, DBO.JOBO.JOBO AS 職級代碼, 
                            DBO.JOBO.JOB_NAME AS 職級名稱, DBO.TTSCD.TTSCD_DISP AS 異動原因代碼, 
                            DBO.TTSCD.TTSNAME AS 異動原因名稱, DBO.ROTET.ROTET_DISP AS 輪班別代碼, 
                            DBO.ROTET.ROTETNAME AS 輪班別名稱, DBO.HOLICD.HOLI_CODE_DISP AS 行事曆代碼, 
                            DBO.HOLICD.HOLI_NAME AS 行事曆名稱, DBO.BASETTS.EMPCD AS 員別代碼, DBO.EMPCD.EMPDESCR AS 員別名稱, 
                            DBO.BASETTS.CALOT AS 加班比率代碼, DBO.OTRATECD.OTRATE_NAME AS 加班比率名稱, 
                            DBO.BASETTS.CARDID AS 識別證號
FROM              DBO.BASE INNER JOIN
                            DBO.BASETTS ON DBO.BASE.NOBR = DBO.BASETTS.NOBR LEFT OUTER JOIN
                            DBO.DEPT ON DBO.BASETTS.DEPT = DBO.DEPT.D_NO LEFT OUTER JOIN
                            DBO.DEPTA ON DBO.BASETTS.DEPTM = DBO.DEPTA.D_NO LEFT OUTER JOIN
                            DBO.DEPTS ON DBO.BASETTS.DEPTS = DBO.DEPTS.D_NO LEFT OUTER JOIN
                            DBO.JOB ON DBO.BASETTS.JOB = DBO.JOB.JOB LEFT OUTER JOIN
                            DBO.JOBO ON DBO.BASETTS.JOBO = DBO.JOB.JOB LEFT OUTER JOIN
                            DBO.JOBL ON DBO.BASETTS.JOBL = DBO.JOBL.JOBL LEFT OUTER JOIN
                            DBO.JOBS ON DBO.BASETTS.JOBS = DBO.JOBS.JOBS LEFT OUTER JOIN
                            DBO.WORKCD ON DBO.BASETTS.WORKCD = DBO.WORKCD.WORK_CODE LEFT OUTER JOIN
                            DBO.TTSCD ON DBO.BASETTS.TTSCD = DBO.TTSCD.TTSCD LEFT OUTER JOIN
                            DBO.ROTET ON DBO.BASETTS.ROTET = DBO.ROTET.ROTET LEFT OUTER JOIN
                            DBO.EMPCD ON DBO.BASETTS.EMPCD = DBO.EMPCD.EMPCD LEFT OUTER JOIN
                            DBO.OUTCD ON DBO.BASETTS.OUTCD = DBO.OUTCD.OUTCD LEFT OUTER JOIN
                            DBO.HOLICD ON DBO.BASETTS.HOLI_CODE = DBO.HOLICD.HOLI_CODE LEFT OUTER JOIN
                            DBO.OTRATECD ON DBO.BASETTS.CALOT = DBO.OTRATECD.OTRATE_CODE LEFT OUTER JOIN
                            DBO.DATAGROUP ON DBO.BASETTS.SALADR = DBO.DATAGROUP.DATAGROUP LEFT OUTER JOIN
                            DBO.SALTYCD ON DBO.BASETTS.SALTP = DBO.SALTYCD.SALTYCD LEFT OUTER JOIN
                            DBO.COSTTYPE ON DBO.BASETTS.OILSUBSIDY = DBO.COSTTYPE.COSTTYPECODE
WHERE          (CONVERT (nvarchar(50), GETDATE(), 111) BETWEEN DBO.BASETTS.ADATE AND DBO.BASETTS.DDATE)
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 3, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportEMP';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane3', @value = N'ortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportEMP';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lumn = 0
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
         S', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportEMP';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
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
            TopCo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportEMP';

