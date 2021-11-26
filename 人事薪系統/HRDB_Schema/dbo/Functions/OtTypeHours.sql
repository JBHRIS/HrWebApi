CREATE FUNCTION [dbo].[OtTypeHours](@yymm nvarchar(50),@nobr nvarchar(50),@STEP NVARCHAR(50))
returns decimal(16,2)
as
BEGIN
	declare @value decimal(16,2)
	declare @Type nvarchar(50)
	set @value=0
	set @Type='平日加班'
	IF(@step=1)
	BEGIN	
		select @value=isnull(SUM(OT.WOT_133	),0) from OT
		left join ATTEND on OT.NOBR=ATTEND.NOBR and OT.BDATE	=ATTEND.ADATE	
		left join OTRCD on OT.OTRCD=OTRCD.OTRCD
		left join HOL_DAY	on OT.BDATE	=HOL_DAY.ADATE	AND OT.OT_ROTE=HOL_DAY.ROTE	
		where ot.YYMM=@yymm and ot.NOBR=@nobr AND dbo.HOLI_TYPE(ot.OTRCD,ot.SYS_OT,otrcd.SYS_OT,ATTEND.ROTE)=@Type
	END	
	else if(@step=2)
	BEGIN	
		select @value=isnull(SUM(OT.WOT_166),0) from OT
		left join ATTEND on OT.NOBR=ATTEND.NOBR and OT.BDATE	=ATTEND.ADATE	
		left join OTRCD on OT.OTRCD=OTRCD.OTRCD
		left join HOL_DAY	on OT.BDATE	=HOL_DAY.ADATE	AND OT.OT_ROTE=HOL_DAY.ROTE	
		where ot.YYMM=@yymm and ot.NOBR=@nobr AND dbo.HOLI_TYPE(ot.OTRCD,ot.SYS_OT,otrcd.SYS_OT,ATTEND.ROTE)=@Type
	end	
	RETURN @value
end	

--select * from OTRCD
