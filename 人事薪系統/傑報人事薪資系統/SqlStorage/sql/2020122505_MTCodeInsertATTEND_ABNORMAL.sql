if not exists(select CATEGORY  from MTCODE where CATEGORY='ATTEND_ABNORMAL')  
Begin
INSERT INTO [dbo].[MTCODE]([CATEGORY],[CODE],[NAME],[SORT],[DISPLAY])
VALUES ('ATTEND_ABNORMAL','ComeEarly','早來',1,1),
	   ('ATTEND_ABNORMAL','GoLate','晚走',1,1)
End
GO

if not exists(select CATEGORY  from MTCODE where CATEGORY='ATTEND_ABNORMAL_CHECK')  
Begin
INSERT INTO [dbo].[MTCODE]([CATEGORY],[CODE],[NAME],[SORT],[DISPLAY])
VALUES ('ATTEND_ABNORMAL_CHECK','A','未處理公務，因個人私事致提早簽到及延後簽退。',1,1)
End
GO