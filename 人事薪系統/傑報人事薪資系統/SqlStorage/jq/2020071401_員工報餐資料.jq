{
  "MySetting": {
    "ID": 33,
    "QuerySetting": "View_MealApplyRecord",
    "QueryName": "員工報餐紀錄",
    "SourceType": "SQL",
    "ConnectString": "View_MealApplyRecord",
    "Memo": "",
    "CreateMan": "",
    "CreateDate": "2020-07-16T10:56:01.943",
    "Sort": 1,
    "PageSize": 1000,
    "CustomerWhere": "  dbo.GetFilterByNobr(View_MealApplyRecord.員工編號,@UserId,@Company,@Admin)=1"
  },
  "MyColumns": [
    {
      "ID": 1523,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "員工編號",
      "DisplayName": "員工編號",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1524,
      "SettingID": 33,
      "Sort": 2,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "員工姓名",
      "DisplayName": "員工姓名",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1525,
      "SettingID": 33,
      "Sort": 3,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "報餐日期",
      "DisplayName": "報餐日期",
      "Display": true,
      "DataType": "datetime",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1526,
      "SettingID": 33,
      "Sort": 4,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐種類代碼",
      "DisplayName": "用餐種類代碼",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1527,
      "SettingID": 33,
      "Sort": 5,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐種類名稱",
      "DisplayName": "用餐種類名稱",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1528,
      "SettingID": 33,
      "Sort": 6,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "起始時間",
      "DisplayName": "起始時間",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1529,
      "SettingID": 33,
      "Sort": 7,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "結束時間",
      "DisplayName": "結束時間",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1530,
      "SettingID": 33,
      "Sort": 8,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐群組代碼",
      "DisplayName": "用餐群組代碼",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1531,
      "SettingID": 33,
      "Sort": 9,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐群組名稱",
      "DisplayName": "用餐群組名稱",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1532,
      "SettingID": 33,
      "Sort": 10,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "部門代碼",
      "DisplayName": "部門代碼",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1533,
      "SettingID": 33,
      "Sort": 11,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "部門名稱",
      "DisplayName": "部門名稱",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1534,
      "SettingID": 33,
      "Sort": 12,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "備註",
      "DisplayName": "備註",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1535,
      "SettingID": 33,
      "Sort": 13,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "序號",
      "DisplayName": "序號",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1536,
      "SettingID": 33,
      "Sort": 14,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "登錄者",
      "DisplayName": "登錄者",
      "Display": true,
      "DataType": "nvarchar",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1537,
      "SettingID": 33,
      "Sort": 15,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "登錄日期",
      "DisplayName": "登錄日期",
      "Display": true,
      "DataType": "datetime",
      "PrimaryKey": false,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    },
    {
      "ID": 1538,
      "SettingID": 33,
      "Sort": 16,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "AutoKey",
      "DisplayName": "AutoKey",
      "Display": false,
      "DataType": "int",
      "PrimaryKey": true,
      "Format": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:59:36.697"
    }
  ],
  "MyForeignKey": [],
  "MyPreCondition": [],
  "MyQueryField": [
    {
      "ID": 93,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "員工編號",
      "DisplayName": "員工編號",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:21.187"
    },
    {
      "ID": 94,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "員工姓名",
      "DisplayName": "員工姓名",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:24.49"
    },
    {
      "ID": 95,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "報餐日期",
      "DisplayName": "報餐日期",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:27.683"
    },
    {
      "ID": 96,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐種類代碼",
      "DisplayName": "用餐種類代碼",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:31.237"
    },
    {
      "ID": 97,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐種類名稱",
      "DisplayName": "用餐種類名稱",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:34.57"
    },
    {
      "ID": 98,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "起始時間",
      "DisplayName": "起始時間",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:37.023"
    },
    {
      "ID": 99,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "結束時間",
      "DisplayName": "結束時間",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:40.087"
    },
    {
      "ID": 100,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐群組代碼",
      "DisplayName": "用餐群組代碼",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:43.177"
    },
    {
      "ID": 101,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "用餐群組名稱",
      "DisplayName": "用餐群組名稱",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:46.337"
    },
    {
      "ID": 102,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "部門代碼",
      "DisplayName": "部門代碼",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:49.68"
    },
    {
      "ID": 103,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "部門名稱",
      "DisplayName": "部門名稱",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:52.71"
    },
    {
      "ID": 104,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "備註",
      "DisplayName": "備註",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:56.543"
    },
    {
      "ID": 105,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "序號",
      "DisplayName": "序號",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:59.553"
    },
    {
      "ID": 106,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "登錄者",
      "DisplayName": "登錄者",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:57:02.21"
    },
    {
      "ID": 107,
      "SettingID": 33,
      "Sort": 1,
      "TableName": "View_MealApplyRecord",
      "ColumnName": "登錄日期",
      "DisplayName": "登錄日期",
      "Display": true,
      "QueryType": "",
      "CustomQuery": "",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:57:04.223"
    }
  ],
  "MyTable": [
    {
      "ID": 46,
      "SettingID": 33,
      "TableName": "View_MealApplyRecord",
      "DisplayName": "View_MealApplyRecord",
      "Memo": "",
      "CreateMan": "",
      "CreateDate": "2020-07-16T10:56:01.953"
    }
  ]
}