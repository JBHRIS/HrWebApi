
create function [dbo].[GetContinuousWorkDay](@nobr nvarchar(50),@date datetime)
returns int
as
begin
    declare @value int
    declare @hol_date datetime
    --declare @rote nvarchar(50)
	declare @count int
    select top 1 @hol_date=adate from attend where nobr=@nobr and adate<=@date and not exists(select 1 from ATTCARD where attend.NOBR=attcard.NOBR and ATTEND.ADATE=ATTCARD.ADATE) order by adate desc
    if(@hol_date is null)
    set @hol_date='1900-1-1'
    select @value=count(*) from attend where nobr=@nobr and adate between @hol_date and @date and exists(select 1 from ATTCARD where attend.NOBR=attcard.NOBR and ATTEND.ADATE=ATTCARD.ADATE) group by nobr
    select @count=count(*) from attend where nobr=@nobr and adate=@date and not exists(select 1 from ATTCARD where attend.NOBR=attcard.NOBR and ATTEND.ADATE=ATTCARD.ADATE)
    if(@count>0)
    set @value=0
    return @value
end

