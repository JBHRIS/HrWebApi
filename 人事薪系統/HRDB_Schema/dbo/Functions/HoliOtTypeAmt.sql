CREATE FUNCTION [dbo].[HoliOtTypeAmt](@yymm nvarchar(50),@nobr nvarchar(50),@Type nvarchar(50))
returns decimal(16,2)
as
BEGIN
	declare @value decimal(16,2)
	set @value=0
	BEGIN	
		select @value=round(isnull(SUM(OT.TOT_HOURS*OT.NOP_H_200*dbo.DECODE(ot.SALARY)/240),0),0) from OT
		left join ATTEND on OT.NOBR=ATTEND.NOBR and OT.BDATE	=ATTEND.ADATE	
		left join OTRCD on OT.OTRCD=OTRCD.OTRCD
		left join HOL_DAY	on OT.BDATE	=HOL_DAY.ADATE	AND OT.OT_ROTE=HOL_DAY.ROTE	
		where ot.YYMM=@yymm and ot.NOBR=@nobr AND dbo.HOLI_TYPE(ot.OTRCD,ot.SYS_OT,otrcd.SYS_OT,ATTEND.ROTE)=@Type
	END	
	
	RETURN @value
end
