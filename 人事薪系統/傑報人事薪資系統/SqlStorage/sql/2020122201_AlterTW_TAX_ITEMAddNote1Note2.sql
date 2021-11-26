alter table TW_TAX_ITEM 
add 
Note1 nvarchar(50) null,
Note2 nvarchar(50) null
GO

if not exists(select CATEGORY  from MTCODE where CATEGORY='ValidType')  
Begin
  insert into MTCODE (CATEGORY, CODE, NAME,SORT,DISPLAY)
  values ('ValidType','String','��r',0,0),
         ('ValidType','DateTime','���+�ɶ�',1,0),
         ('ValidType','Date','���',2,0),
         ('ValidType','Time','�ɶ�',3,0),
		 ('ValidType','Integer','���',4,0),
		 ('ValidType','Decimal','�Q�i��B�I��',5,0),
		 ('ValidType','Boolean','���L',6,0);
End
GO