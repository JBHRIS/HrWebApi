--�פJMtcode�X�Ժ�����Ƶ�portal�ϥ�
BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Attend')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Attend', N'�X��', 1, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Card')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Card', N'��d', 2, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Abs')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Abs', N'�а�', 3, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Ot')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Ot', N'�[�Z', 4, 1)
   END
END

BEGIN
   IF NOT EXISTS (select * from MTCODE where CATEGORY = 'Portal_AttendType' and  CODE = 'AttendType_Abnormal')
   BEGIN
       INSERT [dbo].[MTCODE] ([CATEGORY], [CODE], [NAME], [SORT], [DISPLAY]) VALUES (N'Portal_AttendType', N'AttendType_Abnormal', N'���`', 5, 1)
   END
END