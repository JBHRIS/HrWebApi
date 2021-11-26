UPDATE [dbo].[jqColumn] 
SET Format='DECODE'
WHERE 1=1
and (TableName='View_TW_TAX_ITEM' or TableName='View_TW_TAX_SUMMARY')
and (ColumnName = '給付總額' or ColumnName ='扣繳稅額' or ColumnName = '自提退休金'or ColumnName = '勞退自提') 
--and (Format = '' or Format is null);
GO