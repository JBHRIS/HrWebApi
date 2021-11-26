CREATE TABLE [dbo].[RelayTable](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[ParentKey] [nvarchar](50) NOT NULL,
	[ParentSource] [nvarchar](50) NOT NULL,
	[ChildKey] [nvarchar](50) NOT NULL,
	[ChildBSource] [nvarchar](50) NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_RelayTable] PRIMARY KEY CLUSTERED 
(
	[AK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.ABSC ADD Guid nvarchar(50) NULL 
go

/****** Object:  View [dbo].[View_ABSWriteOff]    Script Date: 2020/3/9 上午 09:28:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_ABSWriteOff]
AS
SELECT  TOP (100) PERCENT ABS.屬性, ABS.NOBR AS 員工編號, dbo.BASE.NAME_C AS 員工姓名, ABS.YYMM AS 計薪年月, dbo.ROTE.ROTE_DISP AS 班別, 
               dbo.ROTE.ROTENAME AS 班別名稱, dbo.HCODE.H_CODE AS 假別代碼, dbo.HCODE.H_CODE_DISP AS 假別, dbo.HCODE.H_NAME AS 假別名稱, 
               ABS.BDATE AS 請假日期, ABS.BTIME AS 請假起, ABS.ETIME AS 請假迄, ABS.TOL_HOURS AS 請假時數, dbo.HCODE.UNIT AS 單位, ABS.Guid AS 編號, 
               ABS.KEY_MAN AS 登錄者, ABS.KEY_DATE AS 登錄日, SUM(SALABS.扣款金額) AS 扣款金額
FROM     (SELECT  '請假' AS 屬性, BDATE, NOBR, YYMM, BTIME, ETIME, TOL_HOURS, Guid, H_CODE, KEY_MAN, KEY_DATE
               FROM      dbo.ABS AS ABS_1
               UNION
               SELECT  '銷假' AS 屬性, BDATE, NOBR, YYMM, BTIME, ETIME, TOL_HOURS, GUID, H_CODE, KEY_MAN, KEY_DATE
               FROM     dbo.ABSC) AS ABS LEFT OUTER JOIN
                   (SELECT  SALABS_1.NOBR, SALABS_1.ADATE, dbo.SALCODE.SAL_CODE, dbo.SALCODE.SAL_NAME AS 扣薪科目, 
                                  SALCODE_1.SAL_NAME AS 扣款科目, dbo.DECODE(SALABS_1.AMT) AS 扣款金額
                   FROM     dbo.SALABS AS SALABS_1 INNER JOIN
                                  dbo.SALCODE ON SALABS_1.SAL_CODE = dbo.SALCODE.SAL_CODE INNER JOIN
                                  dbo.SALCODE AS SALCODE_1 ON SALABS_1.MLSSALCODE = SALCODE_1.SAL_CODE) AS SALABS ON SALABS.NOBR = ABS.NOBR AND 
               SALABS.ADATE = ABS.BDATE INNER JOIN
               dbo.HCODE ON ABS.H_CODE = dbo.HCODE.H_CODE INNER JOIN
               dbo.ATTEND ON ABS.NOBR = dbo.ATTEND.NOBR AND ABS.BDATE = dbo.ATTEND.ADATE INNER JOIN
               dbo.ROTE ON dbo.ATTEND.ROTE = dbo.ROTE.ROTE INNER JOIN
               dbo.BASE ON ABS.NOBR = dbo.BASE.NOBR
WHERE   (dbo.HCODE.FLAG = '-') AND (dbo.HCODE.MANG = '0')
GROUP BY ABS.屬性, ABS.NOBR, dbo.BASE.NAME_C, ABS.YYMM, dbo.ROTE.ROTE_DISP, dbo.ROTE.ROTENAME, dbo.HCODE.H_CODE_DISP, 
               dbo.HCODE.H_NAME, ABS.BDATE, ABS.BTIME, ABS.ETIME, ABS.TOL_HOURS, dbo.HCODE.UNIT, ABS.Guid, ABS.KEY_MAN, ABS.KEY_DATE, 
               dbo.HCODE.H_CODE
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[31] 2[10] 3) )"
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
         Top = -144
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ABS"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALABS"
            Begin Extent = 
               Top = 9
               Left = 349
               Bottom = 196
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HCODE"
            Begin Extent = 
               Top = 9
               Left = 641
               Bottom = 196
               Right = 886
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTEND"
            Begin Extent = 
               Top = 9
               Left = 943
               Bottom = 196
               Right = 1179
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 198
               Left = 57
               Bottom = 385
               Right = 342
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 198
               Left = 399
               Bottom = 385
               Right = 677
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
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ABSWriteOff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Table = 1170
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ABSWriteOff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ABSWriteOff'
GO


