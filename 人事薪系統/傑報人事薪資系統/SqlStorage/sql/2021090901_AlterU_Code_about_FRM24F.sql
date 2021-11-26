IF EXISTS (SELECT * FROM u_code WHERE FORMNAME='FRM24F')
begin
	update u_code
	set Q_FIELD = 'FOOD_CARD.' + Q_FIELD
	where FORMNAME = 'FRM24F'
end
ELSE
begin
    INSERT INTO u_code 
	VALUES (1,N'員工編號',N'FOOD_CARD.NOBR',0.00,N'C',1,N'FRM24F',GETDATE(),N'JB',N'JBHR',0,'',''),
		   (2,N'刷卡日期',N'FOOD_CARD.ADATE',0.00,N'D',1,N'FRM24F',GETDATE(),N'JB',N'JBHR',0,'',''),
		   (3,N'刷卡卡號',N'FOOD_CARD.CARDNO',0.00,N'C',1,N'FRM24F',GETDATE(),N'JB',N'JBHR',0,'','')
end
GO	