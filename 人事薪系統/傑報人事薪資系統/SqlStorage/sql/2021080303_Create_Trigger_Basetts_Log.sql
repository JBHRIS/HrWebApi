create trigger [dbo].[BASETTS_Log_Trigger] 
on [dbo].[BASETTS]
after insert,update,delete
as
begin try
declare @Source nvarchar(50)
set @Source='BASETTS'
declare @InsertedXml xml
declare @DeletedXml xml
if(exists(select 1 from inserted))--Add
set @InsertedXml=(select * from inserted for xml raw)
if(exists(select 1 from deleted))--Add
set @DeletedXml=(select * from deleted for xml raw)
insert into TraceLog select @Source,@InsertedXml,@DeletedXml,GETDATE()
end try
begin catch
print(ERROR_MESSAGE() )
end catch
GO
