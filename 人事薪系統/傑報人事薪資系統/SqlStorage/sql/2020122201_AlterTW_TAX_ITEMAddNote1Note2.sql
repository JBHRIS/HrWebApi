alter table TW_TAX_ITEM 
add 
Note1 nvarchar(50) null,
Note2 nvarchar(50) null
GO

if not exists(select CATEGORY  from MTCODE where CATEGORY='ValidType')  
Begin
  insert into MTCODE (CATEGORY, CODE, NAME,SORT,DISPLAY)
  values ('ValidType','String','文字',0,0),
         ('ValidType','DateTime','日期+時間',1,0),
         ('ValidType','Date','日期',2,0),
         ('ValidType','Time','時間',3,0),
		 ('ValidType','Integer','整數',4,0),
		 ('ValidType','Decimal','十進位浮點數',5,0),
		 ('ValidType','Boolean','布林',6,0);
End
GO