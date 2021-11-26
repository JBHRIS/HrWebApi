alter table SALATT 
 add 
 BTIME nvarchar(50),
 ETIME nvarchar(50),
 CALC_TYPE nvarchar(50);
GO

--�M��SALATT���¸��
IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	DELETE SALATT
	WHERE CALC_TYPE ='RoteByATT'
END
GO

--��ATTEND��ơA�N�Z�O�z�K�]�w1�����ഫ��SALATT�������
IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	insert into SALATT
	SELECT 'FRM2G' as SOURCE, a.NOBR,a.ADATE, a.ROTE , '' as YYMM , '' as SEQ, b.NIGHTSALCD ,a.NIGAMT
	,GETDATE() as KEY_DATE,'System' as KEY_MAN, N'�¸�Ʋ���' as NOTE ,ac.T1 as BTIME,ac.T2 as ETIME,'RoteByATT' as CALC_TYPE
	FROM ATTEND as a
	JOIN ROTE as b on a.ROTE = b.ROTE
	Left JOIN ATTCARD as ac on a.NOBR = ac.NOBR and a.ADATE = ac.ADATE
	WHERE 1=1
	AND a.NIGAMT > 0
	AND a.ROTE not in ('00','0X','0Y','0Z')
	--AND c.CHECK4 = 1
END
GO

IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	insert into SALATT
	SELECT 'FRM2G' as SOURCE, a.NOBR,a.ADATE, b.ROTE , '' as YYMM , '' as SEQ, b.NIGHTSALCD ,a.NIGAMT
	,GETDATE() as KEY_DATE,'System' as KEY_MAN, N'�¸�Ʋ���' as NOTE ,ac.T1 as BTIME,ac.T2 as ETIME,'RoteByATT' as CALC_TYPE
	FROM ATTEND as a
	JOIN OT as ot on a.NOBR = ot.NOBR and a.ADATE = ot.BDATE
	JOIN ROTE as b on ot.OT_ROTE = b.ROTE
	Left JOIN ATTCARD as ac on a.NOBR = ac.NOBR and a.ADATE = ac.ADATE
	WHERE 1=1
	AND a.NIGAMT > 0
	AND a.ROTE in ('00','0X','0Y','0Z')
	--AND c.CHECK4 = 1
END
GO

--��ATTEND��ơA�N�Z�O�z�K�]�w2�����ഫ��SALATT�������
IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	insert into SALATT
	SELECT 'FRM2G' as SOURCE, a.NOBR,a.ADATE, a.ROTE , '' as YYMM , '' as SEQ, b.FOODSALCD ,a.FOODAMT
	,GETDATE() as KEY_DATE,'System' as KEY_MAN, N'�¸�Ʋ���' as NOTE ,ac.T1 as BTIME,ac.T2 as ETIME,'RoteByATT' as CALC_TYPE
	FROM ATTEND as a
	JOIN ROTE as b on a.ROTE = b.ROTE
	Left JOIN ATTCARD as ac on a.NOBR = ac.NOBR and a.ADATE = ac.ADATE
	WHERE 1=1
	AND a.FOODAMT > 0
	AND a.ROTE not in ('00','0X','0Y','0Z')
	--AND c.CHECK4 = 1
END
GO

IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	insert into SALATT
	SELECT 'FRM2G' as SOURCE, a.NOBR,a.ADATE, b.ROTE , '' as YYMM , '' as SEQ, b.FOODSALCD ,a.FOODAMT
	,GETDATE() as KEY_DATE,'System' as KEY_MAN, N'�¸�Ʋ���' as NOTE ,ac.T1 as BTIME,ac.T2 as ETIME,'RoteByATT' as CALC_TYPE
	FROM ATTEND as a
	JOIN OT as ot on a.NOBR = ot.NOBR and a.ADATE = ot.BDATE
	JOIN ROTE as b on ot.OT_ROTE = b.ROTE
	Left JOIN ATTCARD as ac on a.NOBR = ac.NOBR and a.ADATE = ac.ADATE
	WHERE 1=1
	AND a.FOODAMT > 0
	AND a.ROTE in ('00','0X','0Y','0Z')
	--AND c.CHECK4 = 1
END
GO

--��ATTEND��ơA�N�Z�O�z�K�]�w3�����ഫ��SALATT�������
IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	insert into SALATT
	SELECT 'FRM2G' as SOURCE, a.NOBR,a.ADATE, a.ROTE , '' as YYMM , '' as SEQ, b.SPECSALCD ,a.SPECAMT
	,GETDATE() as KEY_DATE,'System' as KEY_MAN, N'�¸�Ʋ���' as NOTE ,ac.T1 as BTIME,ac.T2 as ETIME,'RoteByATT' as CALC_TYPE
	FROM ATTEND as a
	JOIN ROTE as b on a.ROTE = b.ROTE
	Left JOIN ATTCARD as ac on a.NOBR = ac.NOBR and a.ADATE = ac.ADATE
	WHERE 1=1
	AND a.SPECAMT > 0
	AND a.ROTE not in ('00','0X','0Y','0Z')
	--AND c.CHECK4 = 1
END
GO
IF (SELECT count(*) FROM SALATT where KEY_MAN = 'SYSTEM') = 0
BEGIN
	insert into SALATT
	SELECT 'FRM2G' as SOURCE, a.NOBR,a.ADATE, b.ROTE , '' as YYMM , '' as SEQ, b.SPECSALCD ,a.SPECAMT
	,GETDATE() as KEY_DATE,'System' as KEY_MAN, N'�¸�Ʋ���' as NOTE ,ac.T1 as BTIME,ac.T2 as ETIME,'RoteByATT' as CALC_TYPE
	FROM ATTEND as a
	JOIN OT as ot on a.NOBR = ot.NOBR and a.ADATE = ot.BDATE
	JOIN ROTE as b on ot.OT_ROTE = b.ROTE
	Left JOIN ATTCARD as ac on a.NOBR = ac.NOBR and a.ADATE = ac.ADATE
	WHERE 1=1
	AND a.SPECAMT > 0
	AND a.ROTE in ('00','0X','0Y','0Z')
	--AND c.CHECK4 = 1
END
GO