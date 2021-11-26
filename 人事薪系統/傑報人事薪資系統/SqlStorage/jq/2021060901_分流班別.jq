{"MySetting":{"ID":41,"QuerySetting":"FRM2_DiversionGroup","QueryName":"分流組別","SourceType":"SQL","ConnectString":"View_DiversionGroup","Memo":"","CreateMan":"","CreateDate":"2021-06-15T17:20:04.177","Sort":1,"PageSize":1000,"CustomerWhere":"View_DiversionGroup.資料群組 in (select DATAGROUP from dbo.UserReadDataGroupList(@UserId,@Company,@Admin)) ORDER BY 員工編號"},"MyColumns":[{"ID":1379,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"員工編號","DisplayName":"員工編號","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1380,"SettingID":41,"Sort":2,"TableName":"View_DiversionGroup","ColumnName":"員工姓名","DisplayName":"員工姓名","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1381,"SettingID":41,"Sort":3,"TableName":"View_DiversionGroup","ColumnName":"生效日期","DisplayName":"生效日期","Display":true,"DataType":"datetime","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1382,"SettingID":41,"Sort":4,"TableName":"View_DiversionGroup","ColumnName":"失效日期","DisplayName":"失效日期","Display":true,"DataType":"datetime","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1383,"SettingID":41,"Sort":5,"TableName":"View_DiversionGroup","ColumnName":"分流班別名稱","DisplayName":"分流班別名稱","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1384,"SettingID":41,"Sort":6,"TableName":"View_DiversionGroup","ColumnName":"工作地","DisplayName":"工作地","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1385,"SettingID":41,"Sort":7,"TableName":"View_DiversionGroup","ColumnName":"部門代碼","DisplayName":"部門代碼","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1386,"SettingID":41,"Sort":8,"TableName":"View_DiversionGroup","ColumnName":"部門名稱","DisplayName":"部門名稱","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1387,"SettingID":41,"Sort":9,"TableName":"View_DiversionGroup","ColumnName":"資料群組","DisplayName":"資料群組","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1388,"SettingID":41,"Sort":10,"TableName":"View_DiversionGroup","ColumnName":"登錄日期","DisplayName":"登錄日期","Display":true,"DataType":"datetime","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1389,"SettingID":41,"Sort":11,"TableName":"View_DiversionGroup","ColumnName":"登錄者","DisplayName":"登錄者","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1390,"SettingID":41,"Sort":12,"TableName":"View_DiversionGroup","ColumnName":"AK","DisplayName":"AK","Display":false,"DataType":"int","PrimaryKey":true,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"},{"ID":1391,"SettingID":41,"Sort":13,"TableName":"View_DiversionGroup","ColumnName":"編號","DisplayName":"編號","Display":false,"DataType":"uniqueidentifier","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:44.663"}],"MyForeignKey":[],"MyPreCondition":[],"MyQueryField":[{"ID":265,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"員工編號","DisplayName":"員工編號","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:17.537"},{"ID":266,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"員工姓名","DisplayName":"員工姓名","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:20.647"},{"ID":267,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"生效日期","DisplayName":"生效日期","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:23.217"},{"ID":268,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"失效日期","DisplayName":"失效日期","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:25.897"},{"ID":269,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"分流班別名稱","DisplayName":"分流班別名稱","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:28.183"},{"ID":270,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"工作地","DisplayName":"工作地","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:30.53"},{"ID":271,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"部門代碼","DisplayName":"部門代碼","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:33.19"},{"ID":272,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"部門名稱","DisplayName":"部門名稱","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:35.957"},{"ID":273,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"資料群組","DisplayName":"資料群組","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:38.413"},{"ID":274,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"登錄日期","DisplayName":"登錄日期","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:40.887"},{"ID":275,"SettingID":41,"Sort":1,"TableName":"View_DiversionGroup","ColumnName":"登錄者","DisplayName":"登錄者","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:43.017"}],"MyTable":[{"ID":51,"SettingID":41,"TableName":"View_DiversionGroup","DisplayName":"View_DiversionGroup","Memo":"","CreateMan":"","CreateDate":"2021-06-08T17:19:02.67"}]}