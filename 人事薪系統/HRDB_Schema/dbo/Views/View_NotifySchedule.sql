CREATE View [dbo].[View_NotifySchedule]
as
select substring(CONVERT(varchar, DATEADD(MILLISECOND, a.SetTime/CAST(10000 AS BIGINT), '1900-01-01'),8),1,5) 啟動時間
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=0),'') 星期日
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=1),'') 星期一
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=2),'') 星期二
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=3),'') 星期三
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=4),'') 星期四
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=5),'') 星期五
,isnull((select 'v' from NotifyScheduleDetail b where b.Pid=a.Id and b.DayOfWeek=6),'') 星期六
,a.Id,a.NotifyDetailId
from NotifyScheduleMaster a