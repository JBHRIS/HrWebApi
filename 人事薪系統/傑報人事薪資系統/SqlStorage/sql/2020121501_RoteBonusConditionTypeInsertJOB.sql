IF NOT EXISTS (SELECT 1 FROM MTCODE WHERE CATEGORY = 'RoteBonusConditionType' and CODE = 'JOB')
BEGIN
    INSERT [dbo].[MTCODE] ( [Category], [Code], [NAME], [Sort],[DISPLAY]) 
	VALUES ( N'RoteBonusConditionType', N'JOB', N'Â¾ºÙ', 1, 1)
END