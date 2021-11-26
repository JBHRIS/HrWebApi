create trigger [dbo].[BASE_Log_Trigger] 
on [dbo].[BASE]
after insert,update,delete
as
begin try
declare @Source nvarchar(50)
set @Source='BASE'
declare @InsertedXml xml
declare @DeletedXml xml
if(exists(select 1 from inserted))--Add
set @InsertedXml=(select NOBR,NAME_C,NAME_E,NAME_P,SEX,BIRDT,ADDR1,ADDR2,TEL1,TEL2,BBCALL,EMAIL,GSM,IDNO,CONT_MAN,
CONT_TEL,CONT_GSM,CONT_MAN2,CONT_TEL2,CONT_GSM2,BLOOD,PASSWORD,POSTCODE1,POSTCODE2,BANK_CODE,BANKNO,ACCOUNT_NO,
ACCOUNT_NA,MARRY,COUNTRY,COUNT_MA,ARMY,PRO_MAN1,PRO_ADDR1,PRO_ID1,PRO_TEL1,PRO_MAN2,PRO_ADDR2,PRO_ID2,PRO_TEL2,
ARMY_TYPE,N_NOBR,NOBR_B,PROVINCE,BORN_ADDR,TAXCNT,KEY_MAN,KEY_DATE,ID_TYPE,TAXNO,PRETAX,CONT_REL1,CONT_REL2,ACCOUNT_MA,
MATNO,SUBTEL,up1_name,up2_name,up3_name,up4_name,up5_name,BASECD,NAME_AD,CandidateWays,AdditionDate,AdditionNO,AdmitDate,
IntroductionBonus,Introductor,Aboriginal,Disability,Gift
from inserted for xml raw)
if(exists(select 1 from deleted))--Add
set @DeletedXml=(select NOBR,NAME_C,NAME_E,NAME_P,SEX,BIRDT,ADDR1,ADDR2,TEL1,TEL2,BBCALL,EMAIL,GSM,IDNO,CONT_MAN,
CONT_TEL,CONT_GSM,CONT_MAN2,CONT_TEL2,CONT_GSM2,BLOOD,PASSWORD,POSTCODE1,POSTCODE2,BANK_CODE,BANKNO,ACCOUNT_NO,
ACCOUNT_NA,MARRY,COUNTRY,COUNT_MA,ARMY,PRO_MAN1,PRO_ADDR1,PRO_ID1,PRO_TEL1,PRO_MAN2,PRO_ADDR2,PRO_ID2,PRO_TEL2,
ARMY_TYPE,N_NOBR,NOBR_B,PROVINCE,BORN_ADDR,TAXCNT,KEY_MAN,KEY_DATE,ID_TYPE,TAXNO,PRETAX,CONT_REL1,CONT_REL2,ACCOUNT_MA,
MATNO,SUBTEL,up1_name,up2_name,up3_name,up4_name,up5_name,BASECD,NAME_AD,CandidateWays,AdditionDate,AdditionNO,AdmitDate,
IntroductionBonus,Introductor,Aboriginal,Disability,Gift from deleted for xml raw)
insert into TraceLog select @Source,@InsertedXml,@DeletedXml,GETDATE()
end try
begin catch
print(ERROR_MESSAGE() )
end catch
GO
