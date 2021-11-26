EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'jb';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'jbclient';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'jbsa';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'jbexcel';

