/****** Object:  View [dbo].[REPORTEMP]    Script Date: 2021/7/27 �U�� 05:02:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[REPORTEMP]
AS
SELECT          DBO.BASE.NOBR AS ���u�s��, DBO.BASE.NAME_C AS ���u�m�W, DBO.BASE.NAME_E AS �^��m�W, 
                            CASE WHEN DBO.BASETTS.TTSCODE IN ('1', '4', '6') 
                            THEN '�b¾' ELSE (CASE WHEN DBO.BASETTS.TTSCODE = '3' THEN '�d��' ELSE '��¾' END) END AS ���A, 
                            DBO.BASE.NAME_P AS �@�өm�W, DBO.BASE.SEX AS �ʧO, DBO.BASE.BIRDT AS �X�ͤ��, 
                            DBO.BASE.ADDR1 AS �q�T�a�}, DBO.BASE.ADDR2 AS ���y�a�}, DBO.BASE.TEL1 AS �q�T�q��, 
                            DBO.BASE.TEL2 AS ���y�q��, DBO.BASE.EMAIL AS �q�l�l��, DBO.BASE.GSM AS ��ʹq��, 
                            DBO.BASE.IDNO AS �����Ҹ�, DBO.BASE.CONT_MAN AS �s���H1�m�W, DBO.BASE.CONT_TEL AS �s���H1�q��, 
                            DBO.BASE.CONT_GSM AS �s���H1��ʹq��, DBO.BASE.CONT_MAN2 AS �s���H2�m�W, 
                            DBO.BASE.CONT_TEL2 AS �s���H2�q��, DBO.BASE.CONT_GSM2 AS �s���H2��ʹq��, DBO.BASE.BLOOD AS �嫬, 
                            DBO.BASE.PASSWORD AS �K�X, DBO.BASE.POSTCODE1 AS �q�T�l���ϸ�, DBO.BASE.POSTCODE2 AS ���y�l���ϸ�, 
                            DBO.BASE.BANK_CODE AS ��b�Ȧ�, DBO.BASE.ACCOUNT_NO AS ��b�b��, DBO.BASE.MARRY AS �B��, 
                            DBO.BASE.COUNTRY AS ���y, DBO.BASE.COUNT_MA AS �~�y���u, DBO.BASE.ARMY AS �L��, 
                            DBO.BASE.PRO_MAN1 AS �O�ҤH1�m�W, DBO.BASE.PRO_ADDR1 AS �O�ҤH1��}, 
                            DBO.BASE.PRO_ID1 AS �O�ҤH1�����Ҹ�, DBO.BASE.PRO_TEL1 AS �O�ҤH1�q��, 
                            DBO.BASE.PRO_MAN2 AS �O�ҤH2�m�W, DBO.BASE.PRO_ADDR2 AS �O�ҤH2��}, 
                            DBO.BASE.PRO_ID2 AS �O�ҤH2�����Ҹ�, DBO.BASE.PRO_TEL2 AS �O�ҤH2�q��, DBO.BASE.NOBR_B AS ���ФH, 
                            DBO.BASE.PROVINCE AS �X�ͦa, DBO.BASE.TAXCNT AS �߾i�H��, DBO.BASE.TAXNO AS �@�Ӹ��X, 
                            DBO.BASE.PRETAX AS �ұo�|�w�����B, DBO.BASE.CONT_REL1 AS �s���H1���Y, 
                            DBO.BASE.CONT_REL2 AS �s���H2���Y, DBO.BASE.ACCOUNT_MA AS �~�ұb��, DBO.BASE.MATNO AS �~�d�Ҹ�, 
                            DBO.BASE.SUBTEL AS ����, DBO.BASE.BASECD AS �����O, DBO.BASE.NAME_AD AS AD�b��, 
                            DBO.BASE.ADDITIONNO AS �W�ɳ渹, DBO.BASE.INTRODUCTOR, DBO.BASETTS.ADATE AS ���ʥͮĤ�, 
                            DBO.BASETTS.TTSCODE AS ���ʪ��A, DBO.BASETTS.DDATE AS ���ʥ��Ĥ�, DBO.BASETTS.INDT AS ���q��¾��, 
                            DBO.BASETTS.CINDT AS ���Ψ�¾��, DBO.BASETTS.OUDT AS ��¾��, DBO.BASETTS.OUTCD AS ��¾��]�N�X, 
                            DBO.OUTCD.OUTNAME AS ��¾��]�W��, DBO.BASETTS.STDT AS ���~���, DBO.BASETTS.STINDT AS ���_���, 
                            DBO.BASETTS.STOUDT AS �������, DBO.BASETTS.COMP AS ���q�O, DBO.BASETTS.CARD AS ��d, 
                            DBO.BASETTS.DI AS ������, DBO.BASETTS.MANG AS �����D��, DBO.BASETTS.WK_YRS AS �~���~��, 
                            DBO.BASETTS.SALTP AS �~�O�N�X, DBO.SALTYCD.SALTYNAME AS �~�O�W��, DBO.BASETTS.CALABS AS ���p��а�, 
                            DBO.BASETTS.FULATT AS ���p��u�@����, DBO.BASETTS.NOTER AS ���P�_��즭�h, 
                            DBO.BASETTS.NOWEL AS ���p��֧Q��, DBO.BASETTS.NORET AS ���p��h����s��, 
                            DBO.BASETTS.NOOT AS �����ͥ[�Z, DBO.BASETTS.NOSPEC AS ���p��S��N��, 
                            DBO.BASETTS.NOCARD AS ���p��ұo�|, DBO.BASETTS.NOEAT AS �i�ӽиɥ�, DBO.BASETTS.MENO AS ���ʳƵ�, 
                            DBO.BASETTS.SALADR AS ��Ƹs�եN�X, DBO.DATAGROUP.GROUPNAME AS ��Ƹs�զW��, 
                            DBO.BASETTS.NOWAGE AS ���o�~, DBO.BASETTS.MANGE AS �i�������H�Ƹ��, 
                            DBO.BASETTS.RETRATE AS ���u�Ұh������v, DBO.BASETTS.RETDATE AS �Ұh�s����, 
                            DBO.BASETTS.RETCHOO AS �h������, DBO.BASETTS.RETDATE1 AS �Ұh�s�����, 
                            DBO.BASETTS.ONLYONTIME AS �u��W�Z�d, DBO.BASETTS.COUNT_PASS AS �i�u�W��d, 
                            DBO.BASETTS.MANG1 AS �i�N�ӽЪ��, DBO.BASETTS.AP_DATE AS �եδ�����, 
                            DBO.BASETTS.TAX_DATE AS �~�d���_�l��, DBO.BASETTS.TAX_EDATE AS �~�d�������, 
                            DBO.BASETTS.NOSPAMT AS ���p��T�`����, DBO.BASETTS.FIXRATE AS �ұo�|�T�w�|�v��ú, 
                            DBO.BASETTS.NOOLDRET AS ���p��h����¨�, DBO.BASETTS.REINSTATEDATE AS �w�p�_¾��, 
                            DBO.BASETTS.PASS_TYPE AS ���֪��A, DBO.BASETTS.AUDITDATE AS ���֤��, 
                            DBO.DEPT.D_NO_DISP AS �s����N�X, DBO.DEPT.D_NAME AS �s����W��, 
                            DBO.DEPTA.D_NO_DISP AS ñ�ֳ����N�X, DBO.DEPTA.D_NAME AS ñ�ֳ����W��, 
                            DBO.DEPTS.D_NO_DISP AS ���������N�X, DBO.DEPTS.D_NAME AS ���������W��, DBO.JOB.JOB_DISP AS ¾�٥N�X, 
                            DBO.JOB.JOB_NAME AS ¾�٦W��, DBO.JOBL.JOBL_DISP AS ¾���N�X, DBO.JOBL.JOB_NAME AS ¾���W��, 
                            DBO.BASETTS.WORKCD AS �u�@�a�N�X, DBO.WORKCD.WORK_ADDR AS �u�@�a�W��, 
                            DBO.JOBS.JOBS_DISP AS ¾���N�X, DBO.JOBS.JOB_NAME AS ¾���W��, DBO.JOBO.JOBO AS ¾�ťN�X, 
                            DBO.JOBO.JOB_NAME AS ¾�ŦW��, DBO.TTSCD.TTSCD_DISP AS ���ʭ�]�N�X, 
                            DBO.TTSCD.TTSNAME AS ���ʭ�]�W��, DBO.ROTET.ROTET_DISP AS ���Z�O�N�X, 
                            DBO.ROTET.ROTETNAME AS ���Z�O�W��, DBO.HOLICD.HOLI_CODE_DISP AS ��ƾ�N�X, 
                            DBO.HOLICD.HOLI_NAME AS ��ƾ�W��, DBO.BASETTS.EMPCD AS ���O�N�X, DBO.EMPCD.EMPDESCR AS ���O�W��, 
                            DBO.BASETTS.CALOT AS �[�Z��v�N�X, DBO.OTRATECD.OTRATE_NAME AS �[�Z��v�W��, 
                            DBO.BASETTS.CARDID AS �ѧO�Ҹ�
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


