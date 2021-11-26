{"MySetting":{"ID":29,"QuerySetting":"NotifyService","QueryName":"通知服務","SourceType":"SQL","ConnectString":"NotifyDetail","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:38:07.18","Sort":1,"PageSize":1000,"CustomerWhere":"Comp=@Company"},"MyColumns":[{"ID":1119,"SettingID":29,"Sort":1,"TableName":"NotifyDetail","ColumnName":"Id","DisplayName":"編號","Display":true,"DataType":"int","PrimaryKey":true,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1120,"SettingID":29,"Sort":10,"TableName":"NotifyDetail","ColumnName":"Pid","DisplayName":"主檔編號","Display":true,"DataType":"int","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1121,"SettingID":29,"Sort":0,"TableName":"NotifyDetail","ColumnName":"Comp","DisplayName":"公司別","Display":true,"DataType":"char","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:39:28.64"},{"ID":1122,"SettingID":29,"Sort":4,"TableName":"NotifyDetail","ColumnName":"Subject","DisplayName":"標題","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1123,"SettingID":29,"Sort":5,"TableName":"NotifyDetail","ColumnName":"Body","DisplayName":"內容","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1124,"SettingID":29,"Sort":6,"TableName":"NotifyDetail","ColumnName":"Status","DisplayName":"狀態","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1125,"SettingID":29,"Sort":7,"TableName":"NotifyDetail","ColumnName":"Remark","DisplayName":"備註","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1126,"SettingID":29,"Sort":8,"TableName":"NotifyDetail","ColumnName":"CreateTime","DisplayName":"建立時間","Display":true,"DataType":"datetime","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1127,"SettingID":29,"Sort":9,"TableName":"NotifyDetail","ColumnName":"CreateMan","DisplayName":"建立者","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1128,"SettingID":29,"Sort":0,"TableName":"NotifyMaster","ColumnName":"Id","DisplayName":"Id","Display":false,"DataType":"int","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:40:32.93"},{"ID":1129,"SettingID":29,"Sort":2,"TableName":"NotifyMaster","ColumnName":"NotifyCode","DisplayName":"通知代號","Display":true,"DataType":"char","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1130,"SettingID":29,"Sort":3,"TableName":"NotifyMaster","ColumnName":"NotifyName","DisplayName":"通知名稱","Display":true,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-31T17:00:05.677"},{"ID":1131,"SettingID":29,"Sort":0,"TableName":"NotifyMaster","ColumnName":"QueryScript","DisplayName":"QueryScript","Display":false,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:40:32.93"},{"ID":1132,"SettingID":29,"Sort":0,"TableName":"NotifyMaster","ColumnName":"CreateTime","DisplayName":"CreateTime","Display":false,"DataType":"datetime","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:40:32.93"},{"ID":1133,"SettingID":29,"Sort":0,"TableName":"NotifyMaster","ColumnName":"CreateMan","DisplayName":"CreateMan","Display":false,"DataType":"nvarchar","PrimaryKey":false,"Format":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:40:32.93"}],"MyForeignKey":[{"ID":6,"SettingID":29,"ParentID":1128,"ParentTable":"NotifyMaster","ParentColumn":"Id","ChildID":1120,"ChildTable":"NotifyDetail","ChildColumn":"Pid","CreateMan":"","CreateDate":"2021-03-29T23:40:44.933"}],"MyPreCondition":[],"MyQueryField":[{"ID":122,"SettingID":29,"Sort":1,"TableName":"NotifyMaster","ColumnName":"NotifyCode","DisplayName":"通知代號","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:42:00.3"},{"ID":123,"SettingID":29,"Sort":1,"TableName":"NotifyMaster","ColumnName":"NotifyName","DisplayName":"通知名稱","Display":true,"QueryType":"","CustomQuery":"","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:42:02.793"}],"MyTable":[{"ID":36,"SettingID":29,"TableName":"NotifyDetail","DisplayName":"NotifyDetail","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:38:07.19"},{"ID":37,"SettingID":29,"TableName":"NotifyMaster","DisplayName":"NotifyMaster","Memo":"","CreateMan":"","CreateDate":"2021-03-29T23:40:32.873"}]}