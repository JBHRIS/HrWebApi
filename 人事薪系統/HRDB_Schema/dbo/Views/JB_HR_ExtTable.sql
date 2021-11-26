CREATE VIEW [dbo].[JB_HR_ExtTable]
AS
SELECT     TABLENAME AS sTableName, KEYCOLUMNNAME AS sKeyColumnName, KEYCOLUMNVALUE AS sKeyColumnValue, COLUMNNAME AS sColumnName, 
                      COLUMNVALUE AS sColumnValue, COLUMNDESC AS sColumnDesc
FROM         dbo.EXTTABLE
