


CREATE VIEW [dbo].[人事系統_員工請假資料表]
/*
Cr:
2020/02/10 : 新增, 員工請假資料, 部門、狀態...取員工最近資訊秀出
*/
AS
SELECT A.SERNO id , B.NAME_C AS '員工姓名', B.NOBR  AS '員工編號', COMP.COMP AS '公司代碼', COMP.COMPNAME AS '公司名稱', D.D_NAME AS '部門名稱', 
            D.D_NO_DISP AS '部門編號',HC.H_NAME AS '假別名稱', HC.H_CODE_DISP AS '假別代碼',
		CASE WHEN A.BTIME>='2400' THEN 
			convert(datetime,convert(char(11),A.BDATE+1,120)+SUBSTRING(convert(char(5),convert(smallint,A.BTIME)-2400+10000),2,2)+ ':'+ 
			SUBSTRING(convert(char(5),convert(smallint,A.BTIME)-2400+10000),4,2)+':00', 120) 
			ELSE convert(datetime,convert(char(11),A.BDATE,120)+SUBSTRING(A.BTIME,1,2)+ ':'+ SUBSTRING(A.BTIME,3,2)+':00', 120)			
			END AS '開始日期時間', 
		CASE WHEN A.ETIME>='2400' THEN 
			convert(datetime,convert(char(11),A.EDATE+1,120)+SUBSTRING(convert(char(5),convert(smallint,A.ETIME)-2400+10000),2,2)+ ':'+ 
			SUBSTRING(convert(char(5),convert(smallint,A.ETIME)-2400+10000),4,2)+':00', 120) 
			ELSE convert(datetime,convert(char(11),A.EDATE,120)+SUBSTRING(A.ETIME,1,2)+ ':'+ SUBSTRING(A.ETIME,3,2)+':00', 120)
			END  AS '結束日期時間',
		A.TOL_HOURS  AS '請假時數', --'Approved' AS '核准狀況', 
        a.YYMM AS '薪資期別',  --'員工出勤組別',
		R.ROTE_DISP AS '班別碼', R.ROTENAME AS '班別資料', a.NOTE AS '備註說明', EMPCD.EMPDESCR AS '雇用類別', 
        CASE WHEN BS.DI = 'D' THEN '直接' WHEN BS.DI = 'I' THEN '間接' ELSE NULL END AS '直間接',
		WORKCD.WORK_ADDR AS '工作地點', E.JOB_NAME AS '職稱', ET.templetName AS '職務', 
		(CASE BS.TTSCODE WHEN '1' THEN '在職' WHEN '4' THEN '在職' WHEN '6' THEN '在職' WHEN '3' THEN '留職停薪' WHEN '5' THEN '停離' WHEN '2' THEN
		'離職' END) AS '在職狀況',
		/* BD.NAME_C AS '職務代理人姓名', U.NVARCHAR6 AS '職務代理人工號', a.KEY_DATE AS '申請日期', 
		'審核通過日期' ,  '審核處理人員'*/
        A.Guid AS gid, A.BDATE, BTIME
FROM  ROTE R
  INNER JOIN ATTEND ATT
    ON R.ROTE = ATT.ROTE
  INNER JOIN ABS A
    ON ATT.NOBR = A.NOBR 
	AND ATT.ADATE = A.BDATE
  JOIN HCODE HC
    ON HC.H_CODE = A.H_CODE
	--AND HC.H_CODE_DISP NOT LIKE 'W%'
	AND HC.FLAG = '-' and HC.MANG = 0
  JOIN BASE B
	ON A.NOBR = B.NOBR
  LEFT JOIN dbo.BASETTS BS 
   ON BS.NOBR = b.NOBR
  --AND (CONVERT(varchar, GETDATE(), 102) BETWEEN BS.ADATE AND BS.DDATE)  
    AND  (A.BDATE BETWEEN BS.ADATE AND BS.DDATE)
  LEFT JOIN dbo.COMP 
    ON dbo.COMP.COMP = BS.COMP  
  LEFT JOIN DEPT D
    ON D.D_NO = BS.DEPT
  LEFT OUTER JOIN DBO.EMPCD
    ON BS.EMPCD = DBO.EMPCD.EMPCD 
  LEFT OUTER JOIN WORKCD
    ON BS.WORKCD = DBO.WORKCD.WORK_CODE
  LEFT OUTER JOIN JOB AS E
	ON BS.JOB = E.JOB 		   
  LEFT JOIN DBO.UserDefine U
    ON B.NOBR = U.NOBR  
  LEFT JOIN DBO.EFFS_TEMPLET ET ON
   U.NVARCHAR4 = ET.templetID
  /*LEFT JOIN BASE BD
   ON BD.NOBR = U.NVARCHAR6*/    
;