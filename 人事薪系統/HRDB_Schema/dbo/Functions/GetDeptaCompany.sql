CREATE Function [dbo].[GetDeptaCompany](@DEPT nvarchar(50))
returns nvarchar(50)
begin
declare @result nvarchar(50)
select  @result=(select top 1 a.COMP from comp_datagroup a
join comp b on a.comp=b.comp
where b.DEFA=1 and exists(select * from code_filter c where c.SOURCE='DEPTA' AND c.CODE=DEPTA.D_NO and a.datagroup=c.codegroup)
) from DEPTA where D_NO=@DEPT
return @result
end