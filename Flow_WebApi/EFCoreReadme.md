�w�� Entity Framework Core

1.Install-Package  Microsoft.EntityFrameworkCore -Version 5.0.2
2.Install-Package  Microsoft.EntityFrameworkCore.Tools -Version 5.0.2
3.Install-Package  Microsoft.EntityFrameworkCore.Design -Version 5.0.2
4.Install-Package  Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.2
  
�w�˱о� : https://docs.microsoft.com/zh-tw/ef/core/get-started/overview/install
  
  
�R�O�C�Ѧ�
Scaffold-DbContext -Connection "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -context BloggingContext -Project FirstWeb --use-database-names
�d�� : Scaffold-DbContext "Data Source =192.168.1.12;Initial Catalog =ezFlow; User ID = jb;Password =^Hsx9bu5t@;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity/ezFlow -verbose -usedatabasenames -f
	   Scaffold-DbContext "Data Source =192.168.1.12;Initial Catalog =Share; User ID = jb;Password =^Hsx9bu5t@;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity/Share -verbose -usedatabasenames -f
�`�N:
1. �u-Connection�v�A�i�H�ٲ��C
2. �u-OutputDir Models�v�A�i�H�ק�Model�n���ͦb���@�Ӹ�Ƨ��C
3. �u-context BloggingContext�v�A�ϥιw�]�A�i�H�ٲ��Acontext�R�W�W�١C
4. �u-Project FirstWeb�v�A�u���@�ӱM�סA�i�H�ٲ��C
5. �u-Verbose�v�A��ܸԲӸ�T��X�C 
6. �u-use-database-names�v/�u-usedatabasenames�v�A�ѷӸ�Ʈw�j�p�g�W��/�̷Ӥ��P�������w���Ҥ��P�C
7. �u-Force�v�A�Y��Ʈw����s(����)�мg�{���ɮסA�h�᭱�i�H�[�W �C
8. �u-Tables Blog�v�A�u��s�Y�@�Ӹ�ƪ�A�p Blog�A�i�H�[�W-Tables Blog�C

���O�Ѧ� : https://docs.microsoft.com/zh-tw/ef/core/cli/powershell



EntityFrameworkCore