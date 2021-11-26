CREATE VIEW [dbo].[JB_HR_Ot]
AS
SELECT     RTRIM(NOBR) AS sNobr, BDATE AS dDateB, RTRIM(BTIME) AS sTimeB, RTRIM(ETIME) AS sTimeE, TOT_HOURS AS iTotHours, 
                      OT_HRS AS iOtHrs, REST_HRS AS iRestHrs, NOTE AS sNote, YYMM AS sYYMM, '' AS sSerNo, RTRIM(OT_CAR) AS iOtCar, RTRIM(OT_DEPT) AS sOtDept, 
                      RTRIM(OTRCD) AS sOtrcd, RTRIM(OT_ROTE) AS sOtRote
FROM         dbo.OT
