ALTER TABLE HcodeType ADD ExtendCode nvarchar(50);
GO
ALTER TABLE HcodeType ADD ExpireCode nvarchar(50);
GO

/****** Object:  View [dbo].[ReportEntitleExtend]    Script Date: 2020/1/6 下午 05:03:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ReportEntitleExtend]
AS
SELECT A.NOBR 員工編號,C.NAME_C 員工姓名,CASE WHEN B.HTYPE='1' THEN '特休' ELSE '補休' END 假別種類,B.H_CODE_DISP 假別代碼,B.H_NAME 假別名稱,A.BDATE 生效日期,A.EDATE 失效日期,A.TOL_HOURS 得假,A.LeaveHours 已請,A.Balance 剩餘,B.UNIT 單位,A.NOTE 備註,A.KEY_DATE 登錄日期,A.KEY_MAN 登錄者,A.Guid 編號 FROM ABS A
JOIN HCODE B ON A.H_CODE=B.H_CODE
JOIN BASE C ON A.NOBR=C.NOBR
WHERE B.HTYPE IN ('1','2') and B.FLAG='+'
GO

