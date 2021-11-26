update  EXPLAB set SALADR=(select top 1 saladr from wage where wage.nobr=explab.nobr and wage.yymm=explab.yymm) where  exists(select * from wage where wage.nobr=explab.nobr and wage.yymm=explab.yymm)
go
update explab set saladr= (select saladr from basetts where basetts.nobr=explab.nobr and dateadd(day,-1,dateadd(month,1,explab.adate)) between  basetts.adate and basetts.ddate)  where   exists(select * from basetts where basetts.nobr=explab.nobr and dateadd(day,-1,dateadd(month,1,explab.adate)) between  basetts.adate and basetts.ddate)  and explab.saladr is null
go
update yrinsur set rel_sup=0
go



update  EXPSUP set SALADR=(select top 1 saladr from wage where wage.nobr=EXPSUP.nobr and wage.yymm=EXPSUP.yymm) where  exists(select * from wage where wage.nobr=EXPSUP.nobr and wage.yymm=EXPSUP.yymm)
go
update EXPSUP set saladr= (select saladr from basetts where basetts.nobr=EXPSUP.nobr and dateadd(day,-1,dateadd(month,1,EXPSUP.adate)) between  basetts.adate and basetts.ddate)  where   exists(select * from basetts where basetts.nobr=EXPSUP.nobr and dateadd(day,-1,dateadd(month,1,EXPSUP.adate)) between  basetts.adate and basetts.ddate)  and (EXPSUP.saladr is null or expsup.saladr='')
go
update yrinsur set rel_sup=0
go

