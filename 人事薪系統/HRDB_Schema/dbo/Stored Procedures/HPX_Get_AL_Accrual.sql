


/* 20200319 CRShi:取得季末暫估未休假代金資料

*/
CREATE Procedure [dbo].[HPX_Get_AL_Accrual](@company_code varchar(10), @date_qe varchar(10))
AS
declare
  @date_ql varchar(20), @date_6m varchar(20), @date_12m varchar(20), @date_cut varchar(20),
  @period  varchar(15), @tp      varchar(200),
  @year_q  varchar(4), @diff_yr decimal(10,2), @diff_yr1 decimal(10,2), @diff_yr2 decimal(10,2), @div1 decimal(10,2), @div2 decimal(10,2),
  @al1     decimal(12,3), @al2 decimal(12,3), @al0 decimal(12,3),  --@hramt decimal(18,6), @amt decimal(10,0),
  @rate1 decimal(10,6), @rate2 decimal(10,6),
  @date_ts1 varchar(20), @date_te1 varchar(20), @date_ts2 varchar(20), @date_te2 varchar(20), 
  @date_t1 varchar(20), @date_t2 varchar(20), @date_td  varchar(20),
  @employee_no varchar(50), @enter_date varchar(20), @out_date varchar(20), @cost_code varchar(10);

  set @period = left(@date_qe, 4)+'-'+substring(@date_qe, 6, 2); -- yyyy-03 yyyy-06 yyyy-09 yyyy-12
  set @date_ql= convert(varchar(10), dateadd(d, -1, dateadd(m,-3,dateadd(d, 1, @date_qe))), 111);   --上季末日期         
  set @year_q = left(@date_qe, 4); -- yyyy

--1.刪除當季舊data
delete from  [dbo].[Hpx_AL_T]
		where [COMPANY_CODE]=@company_code and [PERIOD_NAME] >= @period; 
	
declare curs cursor for  	--季末在職人員
	select 
        a.[EMPLOYEE_NO],
        a.[annualleavedate]    enter_date,  --特休年資日起算日
        isnull( convert(varchar(10), a.[OUT_DATE], 111), '4712/12/31')  out_date,
        isnull( a.[COSTCENTER_CODE], 'NA' ) cost_code
	from 
        [dbo].[HPX_HRIS_EMPLOYEE_INFO_ORG_V] a  
	where  1=1                 
        --and a.enter_date <= @date_qe
        --and a.[annualleavedate] >= '2017/01/01'
        and a.annualleavedate <= @date_qe
        and isnull( convert(varchar(10), a.[OUT_DATE], 111), '4712/12/31') > @date_ql            
        and substring(a.[EMPLOYEE_NO],1,1) not in ('N','S','P')
        --and a.[EMPLOYEE_NO]='A0068'
    order by 1;

open curs
fetch next from curs into @employee_no,@enter_date,@out_date,@cost_code
while @@fetch_status=0
begin 
	--2.重估當季可休時數 	    
        ---取得估列
        set @div1 = 4; set @div2 = 4; set @diff_yr2 = 0; set @rate1 = 1; set @rate2 = 0; set @tp = '1'; set @al0 = 0;
        set @date_cut = @year_q + right(@enter_date, 6);
        set @date_6m  = convert(varchar(10), dateadd(d, -1, dateadd(m, 6, dateadd(d, 1, @enter_date))), 111);
        set @date_12m = convert(varchar(10), dateadd(YY, 1, @enter_date), 111);
        set @diff_yr =  convert(int, @year_q) - convert(int,left(@enter_date,4)) + 1;
        --set @hramt =  [dbo].Hpx_Get_AL_Hr_Amt( @company_code, @employee_no );
        if ( @date_ql < @out_date   and  @out_date <= @date_qe )   -- 當季離職不估
			begin
            set @rate1 =0                  
            end 
        else if ( @date_ql < @enter_date   and  @enter_date <= @date_qe )    -- 當季新進 
			begin
			set @rate1 = round(( datediff( day, @enter_date, @date_qe) + 1.00000) / datediff( day, @date_ql, @date_qe ), 6)
            set @diff_yr1 =  0.5 
            set @div1 = 2
            set @date_t1 = @date_6m      
            end           
        else if ( @enter_date <= @date_ql  and  @date_qe < @date_6m )     -- 新進第2季  
			begin
            set @diff_yr1 =  0.5 
            set @div1 = 2  
            set @date_t1 = @date_6m   
            end     
        else if ( @date_ql < @date_6m   and  convert(varchar(10), dateadd( d, -1, @date_6m ), 111) <= @date_qe )  -- 新進0.5~1  
			begin
            set @rate2 = round(( datediff( day, @date_6m, @date_qe ) + 1.00000) /  datediff( day, @date_ql, @date_qe ), 6)
            set @rate1 = 1 - @rate2          
            set @diff_yr1 = 0.5
            set @diff_yr2 = 1
            set @div1 = 2
            set @div2 = 2  
            set @date_t1 = @date_6m
            set @date_t2 = @date_12m
            end 
        else if ( convert(varchar(10), dateadd( d, -1, @date_6m ), 111) <= @date_ql and  @date_12m > @date_qe )     -- 新進第4季 
			begin
            set @diff_yr1 =  1 
            set @div1 = 2            
            set @date_t1 = @date_12m
            end 
        else if ( convert(varchar(10), dateadd( d, -1, @date_12m ), 111) > @date_ql
			 and  convert(varchar(10), dateadd( d, -1, @date_12m ), 111) <= @date_qe )  -- 新進最後  
			begin
            set @rate2 = round(( datediff( day, @date_12m, @date_qe ) + 1.00000) / datediff( day, @date_ql, @date_qe ), 6)
            set @rate1 = 1 - @rate2          
            set @diff_yr1 = 1
            set @diff_yr2 = 2
            set @div1 = 2    
            set @date_t1 = @date_12m
            set @date_t2 = convert(varchar(10), dateadd(YY, 1 ,@date_12m), 111)
            end 
        else if ( convert(varchar(10), dateadd( d, -1, @date_cut ), 111) > @date_ql 
             and  convert(varchar(10), dateadd( d, -1, @date_cut ), 111) <= @date_qe )  -- 正常中 
			begin			
            set @rate2 = round(( datediff( day, @date_cut, @date_qe) + 1.00000) / datediff( day, @date_ql, @date_qe ), 6)
            set @rate1 = 1 - @rate2          
            set @diff_yr1 = @diff_yr - 1
            set @diff_yr2 = @diff_yr
            set @date_t1 = @date_cut
            set @date_t2 = convert(varchar(10), dateadd(YY, 1, @date_cut), 111)  
            end             
        else if  ( convert(varchar(10), dateadd( d, -1, @date_cut ), 111) <= @date_ql )   --正常cut後     
			begin
            set @diff_yr1 = @diff_yr 
            set @date_t1 = convert(varchar(10), dateadd(YY, 1, @date_cut), 111)
            end 
        else   --正常cut前
			begin
            set @diff_yr1 = @diff_yr - 1             
            set @date_t1 = @date_cut 
            end
        ;
    
        --計算估列hr                 
        if   @rate1 > 0
            set @al1 = round( [dbo].[Hpx_Get_AL_Hrs]( convert( int, @year_q ) + 1.00, @diff_yr1 ) / @div1 * @rate1, 2 );
           
        if   @rate2 > 0
            set @al2 = round( [dbo].[Hpx_Get_AL_Hrs]( convert( int, @year_q ) + 1.00, @diff_yr2 ) / @div2 * @rate2, 2 );                
        
        if  ( @employee_no in ('A1208','A1209','A1211','A1212','A1213','A1214','A1217')  and  @period ='2017-03' )   --2016q1新進, 2017q1補足56hr
			begin
				select @al0= isnull ( sum( isnull(al_hr,0) ), 0)
					from [dbo].[HPX_AL_T]  
					where company_code = @company_code and employee_no =  @employee_no and  period_name < @period
				set @al1 = 56 - @al0                
			end
		;
        
        if ( @employee_no in ('A1218','A1219','A1220','A1221','A1223','A1224','F0081')  and  @period ='2017-06' )  --2016q2新進, 2017q2補足56hr
			begin
				select @al0= isnull ( sum( isnull(al_hr,0) ), 0)
					from [dbo].[HPX_AL_T]  
					where company_code = @company_code and employee_no =  @employee_no and  period_name < @period
				set @al1 = 56 - @al0
			end
		;			
                    
        /*if ( @employee_no in ('A1227','A1228','A1229','A1230','A1231','A1232','A1233','A1234','A1235','A1236','F0079','F0083') and @period ='2017-03' and left(@date_t1,7)<='2017/06' )   --2016q3新進, 2017補立6月24hr
            set @al1 = 24 ;                 
        
        if ( @employee_no in ('F0084','F0085') and @period ='2017-06' and left(@date_t1,7)<= '2017/06' )   --2016q4新進, 2017補立6月24hr
            set @al1 = 12 ;*/
                    
        
        ---insert 估列
        if ( @rate1 <> 0 and @al1 <> 0 )
			begin
				--set @amt = round( @al1 * @hramt, 0)
				insert into  [dbo].[HPX_AL_T]
                    /*( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO,  DATE_T,   AL_HR,  AL_AMT, COST_CODE )  values
                    ( @company_code, @period,    @employee_no,  @date_t1, @al1 ,  @amt ,  @cost_code )*/    
					 ( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO,  DATE_T,   AL_HR,  COST_CODE )  values
                    ( @company_code, @period,    @employee_no,  @date_t1, @al1 ,  @cost_code )                     
			end
		;
			
        if ( @rate2 <> 0 and @al2 <> 0 )
			begin       
				--set @amt = round( @al2 * @hramt, 0)                
				insert into  [dbo].[HPX_AL_T]
                    /*( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO,  DATE_T,   AL_HR,  AL_AMT, COST_CODE )  values
                    ( @company_code, @period,    @employee_no,  @date_t2, @al2 ,  @amt ,  @cost_code )*/
					( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO,  DATE_T,   AL_HR,  COST_CODE )  values
                    ( @company_code, @period,    @employee_no,  @date_t2, @al2 ,  @cost_code )
			end 
		;		        
                
    --3.重算當季已休時數        
        ---取得當季已休時段、種類
        if (  @out_date > @date_ql and  @out_date <= @date_qe )     -- 當季離職, 後一次轉完
			begin
				set @tp = '0'
				select @date_td = max(date_t) from  [dbo].[HPX_AL_T]  
					where company_code = @company_code and employee_no =  @employee_no
			end
        else if (  @enter_date > @date_ql and  @enter_date <= @date_qe )     -- 當季新進        
            set @tp = '0'
        else if (  @enter_date <= @date_ql and  @date_6m > @date_qe )     -- 新進第2季  
            set @tp = '0'           
        else if  (  @date_6m > @date_ql and  convert(varchar(10), dateadd( d, -1, @date_6m), 111) <= @date_qe )     -- 新進0.5~1
			begin 
				set @date_ts1 = @date_6m  
				set @date_te1 = convert(varchar(10), dateadd( d, 1, @date_qe ), 111)
				set @date_t1 = @date_6m 
			end
        else if (  convert(varchar(10), dateadd( d, -1, @date_6m ), 111) <= @date_ql and  @date_12m > @date_qe )     -- 新進第4季    
			begin
				set @date_ts1 = convert(varchar(10), dateadd( d, 1, @date_ql ), 111)
				set @date_te1 = convert(varchar(10), dateadd( d, 1, @date_qe ), 111)
				set @date_t1 = @date_6m 
			end
       -- else if  (  @date_12m > @date_ql and  @date_12m-1 <= @date_qe )  -- 新進最後            
        else if ( convert(varchar(10), dateadd( d, -1, @date_cut ), 111) > @date_ql
			 and  convert(varchar(10), dateadd( d, -1, @date_cut ), 111) <= @date_qe )   -- 正常中 
			begin
				set @tp = '2'         
				set @date_ts1 = convert(varchar(10), dateadd( d, 1, @date_ql ), 111)
				set @date_te1 = convert(varchar(10), dateadd( d, 1, @date_cut ), 111)
				set @date_ts2 = @date_cut 
				set @date_te2 = convert(varchar(10), dateadd( d, 1,@date_qe ), 111)
				set @date_t2 = @date_cut  
				if  ( convert(varchar(10), dateadd( d, -1, @date_12m ), 111)  > @date_ql
				  and convert(varchar(10), dateadd( d, -1, @date_12m ), 111) <= @date_qe )  -- 新進最後
					begin
						set @date_t1 = @date_6m  
						set @date_td = @date_6m 
					end
				else             
					begin   					
						set @date_t1 =  convert(varchar(10), dateadd(YY, -1, @date_cut), 111)
						set @date_td =  convert(varchar(10), dateadd(YY, -1, @date_cut), 111)
					end                
            end    
        else if (  convert(varchar(10), dateadd( d, -1, @date_cut), 111) <= @date_ql )   --正常cut後   
			begin
				set @date_ts1 = convert(varchar(10), dateadd( d, 1, @date_ql ), 111)
                set @date_te1 = convert(varchar(10), dateadd( d, 1, @date_qe ), 111)
	            set @date_t1 = @date_cut
            end
        else  --正常cut前
			begin
				set @date_ts1 = convert(varchar(10), dateadd( d, 1, @date_ql ), 111)
				set @date_te1 = convert(varchar(10), dateadd( d, 1, @date_qe ), 111)
				set @date_t1  = convert(varchar(10), dateadd( YY, -1, @date_cut), 111) 
			end
		; 
 
     -- get 實際請特休總時數       
        if @tp <> '0'
			begin
             select @al0 = isnull(sum( isnull(USE_HR,0) ), 0)  ---前季已休Hrs
                from [dbo].[HPX_AL_T]
                where 1=1
					and [COMPANY_CODE] = @company_code   
                    and [EMPLOYEE_NO]  = @employee_no 
                    and [DATE_T] = @date_t1  
                    
			 /*select @al1 = isnull(sum( leave_hours ), 0)
                from [dbo].[HPX_EMPLOYEE_LEAVE_HISTORY_V] 
                where 1=1
                    and [COMPANY_CODE] = @company_code   
                    and [EMPLOYEE_NO]  = @employee_no 
                    and [LEAVE_CODE] in ('10', '10-1')     
                    --and [END_TIME]    >= @date_ts1     
                    and [END_TIME]    >= @date_t1 
                    and [END_TIME]     < @date_te1 */

				select @al1 = isnull(sum( [請假時數] ), 0)
                from [dbo].[人事系統_員工請假資料表] 
                where 1=1
                    and [公司代碼] = @company_code   
                    and [員工編號]  = @employee_no 
                    and [假別代碼] ='10'     
                    and [BDATE]    >= @date_t1 
                    and [BDATE]    < @date_te1
			
				set @al1 = @al1 - @al0    ---累計已休 - 前季已休Hrs
                    
				if @al1 <> 0           
					begin
						--set @amt = round( @al1 * @hramt, 0)
						insert into  [dbo].[HPX_AL_T]
							/*( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO, DATE_T,   USE_HR, USE_AMT, COST_CODE )  values
							( @company_code, @period,    @employee_no, @date_t1, @al1 ,  @amt ,   @cost_code )*/
							
							( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO, DATE_T,   USE_HR, COST_CODE )  values
							( @company_code, @period,    @employee_no, @date_t1, @al1 ,  @cost_code )
					end
            end 
        ;     
                                                                          
        if @tp = '2' --分2段, 第二段      
			begin
             /*select @al2 = isnull(sum( leave_hours ), 0) 
                from [dbo].[HPX_EMPLOYEE_LEAVE_HISTORY_V] 
                where 1=1
                    and [COMPANY_CODE] = @company_code   
                    and [EMPLOYEE_NO]  = @employee_no 
                    and [LEAVE_CODE] in ('10', '10-1')   
                    and [END_TIME]    >= @date_ts2 
                    and [END_TIME]     < @date_te2 */
			 select @al2 = isnull(sum( [請假時數] ), 0)
                from [dbo].[人事系統_員工請假資料表] 
                where 1=1
                    and [公司代碼] = @company_code   
                    and [員工編號]  = @employee_no 
                    and [假別代碼] ='10'     
                    and [BDATE]    >= @date_ts2 
                    and [BDATE]    < @date_te2

                if @al2 <> 0           
					begin 
					--set @amt = round( @al2 * @hramt, 0)                                                
		            insert into  [dbo].[HPX_AL_T]
			            /*( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO,  DATE_T,   USE_HR, USE_AMT, COST_CODE )  values
				        ( @company_code, @period,    @employee_no,  @date_t2, @al2 ,  @amt ,   @cost_code )*/
						( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO,  DATE_T,   USE_HR, COST_CODE )  values
				        ( @company_code, @period,    @employee_no,  @date_t2, @al2 ,  @cost_code )
					end 
	        end
		;	    
	        
    --3.本季到期或離職全部已休--前期估列歸零--全數已休
        if  (  @out_date > @date_ql and  @out_date <= @date_qe )   --當季離職, 已估未休全轉            
			begin
				select @al1 = isnull( sum( isnull(al_hr,0) ) - sum( isnull(use_hr,0) ), 0 ) /*,
				  	   @amt = isnull( sum( isnull(al_amt,0) ) - sum( isnull(use_amt,0) ), 0 )*/
				  from [dbo].[HPX_AL_T]  
					where company_code = @company_code and employee_no = @employee_no and  period_name <= @period   
				update  [dbo].[HPX_AL_T] 
					set STATUS = 'F'   --沖完
					where company_code = @company_code and employee_no = @employee_no and  period_name <= @period  
				set @tp = 'Q'          
			end
        else if (  (  convert(varchar(10), dateadd( d, -1, @date_12m), 111) > @date_ql 
						and  convert(varchar(10), dateadd( d, -1, @date_12m ), 111) <= @date_qe )   ---- 新進最後 
               or  (  convert(varchar(10), dateadd( d, -1, @date_cut ), 111) > @date_ql 
						and  convert(varchar(10), dateadd( d, -1, @date_cut ), 111) <= @date_qe ) )  --本季到期                
			begin
				select @al1 = isnull( sum( isnull(al_hr,0) ) - sum( isnull(use_hr,0) ), 0 ) /*,
				  	   @amt = isnull( sum( isnull(al_amt,0) ) - sum( isnull(use_amt,0) ), 0 )*/
				  from [dbo].[HPX_AL_T]  
					where company_code = @company_code and employee_no = @employee_no and period_name <= @period and date_t <= @date_td   
				update  [dbo].[HPX_AL_T] 
					set STATUS = 'F'   --沖完
					where company_code = @company_code and employee_no = @employee_no and period_name <= @period and date_t <= @date_td    
				set @tp = 'D'
			end
        
        if (@tp in ( 'Q', 'D' ) and  @al1 <> 0)
			begin
                insert into  [dbo].[HPX_AL_T]
                    /*( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO, DATE_T,   USE_HR, USE_AMT, MEMO, STATUS, COST_CODE )  values
                    ( @company_code, @period,    @employee_no, @date_td, @al1  , @amt,	  @tp,   'F'  , @cost_code )*/
					( COMPANY_CODE,  PERIOD_NAME, EMPLOYEE_NO, DATE_T,   USE_HR, MEMO, STATUS, COST_CODE )  values
                    ( @company_code, @period,    @employee_no, @date_td, @al1  , @tp,   'F'  , @cost_code )
			end
		;			

	fetch next from curs into @employee_no,@enter_date,@out_date,@cost_code	;
end
close curs
deallocate curs