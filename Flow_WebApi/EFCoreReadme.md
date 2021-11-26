安裝 Entity Framework Core

1.Install-Package  Microsoft.EntityFrameworkCore -Version 5.0.2
2.Install-Package  Microsoft.EntityFrameworkCore.Tools -Version 5.0.2
3.Install-Package  Microsoft.EntityFrameworkCore.Design -Version 5.0.2
4.Install-Package  Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.2
  
安裝教學 : https://docs.microsoft.com/zh-tw/ef/core/get-started/overview/install
  
  
命令列參考
Scaffold-DbContext -Connection "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -context BloggingContext -Project FirstWeb --use-database-names
範例 : Scaffold-DbContext "Data Source =192.168.1.12;Initial Catalog =ezFlow; User ID = jb;Password =^Hsx9bu5t@;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity/ezFlow -verbose -usedatabasenames -f
	   Scaffold-DbContext "Data Source =192.168.1.12;Initial Catalog =Share; User ID = jb;Password =^Hsx9bu5t@;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity/Share -verbose -usedatabasenames -f
注意:
1. 「-Connection」，可以省略。
2. 「-OutputDir Models」，可以修改Model要產生在哪一個資料夾。
3. 「-context BloggingContext」，使用預設，可以省略，context命名名稱。
4. 「-Project FirstWeb」，只有一個專案，可以省略。
5. 「-Verbose」，顯示詳細資訊輸出。 
6. 「-use-database-names」/「-usedatabasenames」，參照資料庫大小寫名稱/依照不同版本指定有所不同。
7. 「-Force」，若資料庫有更新(全部)覆寫現有檔案，則後面可以加上 。
8. 「-Tables Blog」，只更新某一個資料表，如 Blog，可以加上-Tables Blog。

指令參考 : https://docs.microsoft.com/zh-tw/ef/core/cli/powershell



EntityFrameworkCore