--匯入Mtcode出勤種類資料給portal使用
BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Attend')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Attend', N'出勤', 1, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Card')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Card', N'刷卡', 2, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Abs')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Abs', N'請假', 3, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Ot')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Ot', N'加班', 4, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Abnormal')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Abnormal', N'異常', 5, 1)
   END
END