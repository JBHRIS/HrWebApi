ALTER TABLE HcodeType ADD ExtendCode nvarchar(50);
GO
ALTER TABLE HcodeType ADD ExpireCode nvarchar(50);
GO

/****** Object:  View [dbo].[ReportEntitleExtend]    Script Date: 2020/1/6 �U�� 05:03:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ReportEntitleExtend]
AS
SELECT A.NOBR ���u�s��,C.NAME_C ���u�m�W,CASE WHEN B.HTYPE='1' THEN '�S��' ELSE '�ɥ�' END ���O����,B.H_CODE_DISP ���O�N�X,B.H_NAME ���O�W��,A.BDATE �ͮĤ��,A.EDATE ���Ĥ��,A.TOL_HOURS �o��,A.LeaveHours �w��,A.Balance �Ѿl,B.UNIT ���,A.NOTE �Ƶ�,A.KEY_DATE �n�����,A.KEY_MAN �n����,A.Guid �s�� FROM ABS A
JOIN HCODE B ON A.H_CODE=B.H_CODE
JOIN BASE C ON A.NOBR=C.NOBR
WHERE B.HTYPE IN ('1','2') and B.FLAG='+'
GO

