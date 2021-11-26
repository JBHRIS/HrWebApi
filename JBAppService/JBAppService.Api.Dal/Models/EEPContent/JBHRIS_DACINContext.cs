using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class JBEEPContext : DbContext
    {
        public JBEEPContext()
        {
        }

        public JBEEPContext(DbContextOptions<JBEEPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppSetting_Configuration> AppSetting_Configuration { get; set; }
        public virtual DbSet<COLDEF> COLDEF { get; set; }
        public virtual DbSet<CardAppDetails> CardAppDetails { get; set; }
        public virtual DbSet<CardAppImages> CardAppImages { get; set; }
        public virtual DbSet<EmpConfiguration> EmpConfiguration { get; set; }
        public virtual DbSet<FencePoints> FencePoints { get; set; }
        public virtual DbSet<GROUPMENUCONTROL> GROUPMENUCONTROL { get; set; }
        public virtual DbSet<GROUPMENUS> GROUPMENUS { get; set; }
        public virtual DbSet<GROUPS> GROUPS { get; set; }
        public virtual DbSet<GROUPS_LOG> GROUPS_LOG { get; set; }
        public virtual DbSet<HRD_BASE_BASE> HRD_BASE_BASE { get; set; }
        public virtual DbSet<HRD_BASE_BASE_LOG> HRD_BASE_BASE_LOG { get; set; }
        public virtual DbSet<HRD_COMPANY> HRD_COMPANY { get; set; }
        public virtual DbSet<HRD_COMPANY_LOG> HRD_COMPANY_LOG { get; set; }
        public virtual DbSet<HRD_FORM> HRD_FORM { get; set; }
        public virtual DbSet<HRD_FORM_BEHAVIOR> HRD_FORM_BEHAVIOR { get; set; }
        public virtual DbSet<HRD_FORM_BEHAVIOR_LOG> HRD_FORM_BEHAVIOR_LOG { get; set; }
        public virtual DbSet<HRD_FORM_FUNCTION> HRD_FORM_FUNCTION { get; set; }
        public virtual DbSet<HRD_FORM_FUNCTION_LOG> HRD_FORM_FUNCTION_LOG { get; set; }
        public virtual DbSet<HRD_FORM_GROUP> HRD_FORM_GROUP { get; set; }
        public virtual DbSet<HRD_FORM_GROUP_EMPLOYEE> HRD_FORM_GROUP_EMPLOYEE { get; set; }
        public virtual DbSet<HRD_FORM_GROUP_EMPLOYEE_LOG> HRD_FORM_GROUP_EMPLOYEE_LOG { get; set; }
        public virtual DbSet<HRD_FORM_GROUP_EVALUATION> HRD_FORM_GROUP_EVALUATION { get; set; }
        public virtual DbSet<HRD_FORM_GROUP_EVALUATION_LOG> HRD_FORM_GROUP_EVALUATION_LOG { get; set; }
        public virtual DbSet<HRD_FORM_GROUP_LOG> HRD_FORM_GROUP_LOG { get; set; }
        public virtual DbSet<HRD_FORM_LOG> HRD_FORM_LOG { get; set; }
        public virtual DbSet<HRD_FORM_OPENENDED> HRD_FORM_OPENENDED { get; set; }
        public virtual DbSet<HRD_FORM_OPENENDED_LOG> HRD_FORM_OPENENDED_LOG { get; set; }
        public virtual DbSet<HRD_FORM_WEIGHT> HRD_FORM_WEIGHT { get; set; }
        public virtual DbSet<HRD_FORM_WEIGHT_LOG> HRD_FORM_WEIGHT_LOG { get; set; }
        public virtual DbSet<HRD_FUNCTION> HRD_FUNCTION { get; set; }
        public virtual DbSet<HRD_FUNCTION_BEHAVIOR> HRD_FUNCTION_BEHAVIOR { get; set; }
        public virtual DbSet<HRD_FUNCTION_BEHAVIOR_LOG> HRD_FUNCTION_BEHAVIOR_LOG { get; set; }
        public virtual DbSet<HRD_FUNCTION_LOG> HRD_FUNCTION_LOG { get; set; }
        public virtual DbSet<HRD_FUNCTION_SUGGEST> HRD_FUNCTION_SUGGEST { get; set; }
        public virtual DbSet<HRD_FUNCTION_SUGGEST_LOG> HRD_FUNCTION_SUGGEST_LOG { get; set; }
        public virtual DbSet<HRD_INDUSTRY> HRD_INDUSTRY { get; set; }
        public virtual DbSet<HRD_INDUSTRY_LOG> HRD_INDUSTRY_LOG { get; set; }
        public virtual DbSet<HRD_PROJECT> HRD_PROJECT { get; set; }
        public virtual DbSet<HRD_PROJECT_LOG> HRD_PROJECT_LOG { get; set; }
        public virtual DbSet<HRD_SCALE> HRD_SCALE { get; set; }
        public virtual DbSet<HRD_SCALE_ITEM> HRD_SCALE_ITEM { get; set; }
        public virtual DbSet<HRD_SCALE_ITEM_LOG> HRD_SCALE_ITEM_LOG { get; set; }
        public virtual DbSet<HRD_SCALE_LOG> HRD_SCALE_LOG { get; set; }
        public virtual DbSet<HRD_SCORE_BEHAVIOR> HRD_SCORE_BEHAVIOR { get; set; }
        public virtual DbSet<HRD_SCORE_BEHAVIOR_LOG> HRD_SCORE_BEHAVIOR_LOG { get; set; }
        public virtual DbSet<HRD_SCORE_FUNCTION> HRD_SCORE_FUNCTION { get; set; }
        public virtual DbSet<HRD_SCORE_FUNCTION_LOG> HRD_SCORE_FUNCTION_LOG { get; set; }
        public virtual DbSet<HRD_SCORE_OPENENDED> HRD_SCORE_OPENENDED { get; set; }
        public virtual DbSet<HRD_SCORE_OPENENDED_LOG> HRD_SCORE_OPENENDED_LOG { get; set; }
        public virtual DbSet<HRD_SHARECODE> HRD_SHARECODE { get; set; }
        public virtual DbSet<HRD_SUGGEST_TYPE> HRD_SUGGEST_TYPE { get; set; }
        public virtual DbSet<HRD_SUGGEST_TYPE_LOG> HRD_SUGGEST_TYPE_LOG { get; set; }
        public virtual DbSet<HRD_WEIGHT> HRD_WEIGHT { get; set; }
        public virtual DbSet<HRD_WEIGHT_LOG> HRD_WEIGHT_LOG { get; set; }
        public virtual DbSet<HRM_ADDRESS> HRM_ADDRESS { get; set; }
        public virtual DbSet<HRM_ALTERATION_CAUSE> HRM_ALTERATION_CAUSE { get; set; }
        public virtual DbSet<HRM_ALTERATION_CAUSE_LOG> HRM_ALTERATION_CAUSE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_CANCEL_FLOW> HRM_ATTEND_ABSENT_CANCEL_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_CANCEL_FLOW_LOG> HRM_ATTEND_ABSENT_CANCEL_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_CANCEL_MINUS> HRM_ATTEND_ABSENT_CANCEL_MINUS { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_CANCEL_MINUS_DETAIL> HRM_ATTEND_ABSENT_CANCEL_MINUS_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_CREATE> HRM_ATTEND_ABSENT_CREATE { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_CREATE_LOG> HRM_ATTEND_ABSENT_CREATE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE> HRM_ATTEND_ABSENT_LEAVE { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_DETAIL> HRM_ATTEND_ABSENT_LEAVE_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_FILE> HRM_ATTEND_ABSENT_LEAVE_FILE { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_FILE_LOG> HRM_ATTEND_ABSENT_LEAVE_FILE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_FLOW> HRM_ATTEND_ABSENT_LEAVE_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_FLOW_DETAIL> HRM_ATTEND_ABSENT_LEAVE_FLOW_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_FLOW_LOG> HRM_ATTEND_ABSENT_LEAVE_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_LEAVE_LOG> HRM_ATTEND_ABSENT_LEAVE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS> HRM_ATTEND_ABSENT_MINUS { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_DETAIL> HRM_ATTEND_ABSENT_MINUS_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_DETAIL_LOG> HRM_ATTEND_ABSENT_MINUS_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_FILE> HRM_ATTEND_ABSENT_MINUS_FILE { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_FILE_LOG> HRM_ATTEND_ABSENT_MINUS_FILE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_FLOW> HRM_ATTEND_ABSENT_MINUS_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_FLOW_DETAIL> HRM_ATTEND_ABSENT_MINUS_FLOW_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_FLOW_LOG> HRM_ATTEND_ABSENT_MINUS_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_MINUS_LOG> HRM_ATTEND_ABSENT_MINUS_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_PLUS> HRM_ATTEND_ABSENT_PLUS { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_PLUS_LOG> HRM_ATTEND_ABSENT_PLUS_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ABSENT_TRANS> HRM_ATTEND_ABSENT_TRANS { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND> HRM_ATTEND_ATTEND { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_CARD> HRM_ATTEND_ATTEND_CARD { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_CARD_HOTA> HRM_ATTEND_ATTEND_CARD_HOTA { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_CARD_LOG> HRM_ATTEND_ATTEND_CARD_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_DETAIL> HRM_ATTEND_ATTEND_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_DETAIL_LOG> HRM_ATTEND_ATTEND_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_HOTA> HRM_ATTEND_ATTEND_HOTA { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_LOG> HRM_ATTEND_ATTEND_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_BASETTS> HRM_ATTEND_BASETTS { get; set; }
        public virtual DbSet<HRM_ATTEND_BASETTS_LOG> HRM_ATTEND_BASETTS_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_BIRTHDAY_HOLIDAY> HRM_ATTEND_BIRTHDAY_HOLIDAY { get; set; }
        public virtual DbSet<HRM_ATTEND_BIRTHDAY_HOLIDAY_LOG> HRM_ATTEND_BIRTHDAY_HOLIDAY_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CALENDAR> HRM_ATTEND_CALENDAR { get; set; }
        public virtual DbSet<HRM_ATTEND_CALENDAR_HOLIDAY> HRM_ATTEND_CALENDAR_HOLIDAY { get; set; }
        public virtual DbSet<HRM_ATTEND_CALENDAR_HOLIDAY_LOG> HRM_ATTEND_CALENDAR_HOLIDAY_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CALENDAR_LOG> HRM_ATTEND_CALENDAR_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_CLOCKIN> HRM_ATTEND_CARD_CLOCKIN { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_COLLECT_DETAIL> HRM_ATTEND_CARD_COLLECT_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_COLLECT_DETAIL_LOG> HRM_ATTEND_CARD_COLLECT_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_COLLECT_MASTER> HRM_ATTEND_CARD_COLLECT_MASTER { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_COLLECT_MASTER_LOG> HRM_ATTEND_CARD_COLLECT_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_COLLECT_RESULT> HRM_ATTEND_CARD_COLLECT_RESULT { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_DATA> HRM_ATTEND_CARD_DATA { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_DATA_FLOW> HRM_ATTEND_CARD_DATA_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_DATA_FLOW_LOG> HRM_ATTEND_CARD_DATA_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_DATA_LOG> HRM_ATTEND_CARD_DATA_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_DATA_TEMP> HRM_ATTEND_CARD_DATA_TEMP { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_MACHINE> HRM_ATTEND_CARD_MACHINE { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_MACHINE_LOG> HRM_ATTEND_CARD_MACHINE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_SOURCE> HRM_ATTEND_CARD_SOURCE { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_SOURCE_LOG> HRM_ATTEND_CARD_SOURCE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_CREATE_CARD_DATA> HRM_ATTEND_CREATE_CARD_DATA { get; set; }
        public virtual DbSet<HRM_ATTEND_DATA_LOCK> HRM_ATTEND_DATA_LOCK { get; set; }
        public virtual DbSet<HRM_ATTEND_DATA_LOCK_LOG> HRM_ATTEND_DATA_LOCK_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_EMPLOYEE_CARD> HRM_ATTEND_EMPLOYEE_CARD { get; set; }
        public virtual DbSet<HRM_ATTEND_EMPLOYEE_CARD_LOG> HRM_ATTEND_EMPLOYEE_CARD_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ESTIMATE_OVERTIME_DATA> HRM_ATTEND_ESTIMATE_OVERTIME_DATA { get; set; }
        public virtual DbSet<HRM_ATTEND_ESTIMATE_OVERTIME_DATA_LOG> HRM_ATTEND_ESTIMATE_OVERTIME_DATA_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_FLOW_LOCK> HRM_ATTEND_FLOW_LOCK { get; set; }
        public virtual DbSet<HRM_ATTEND_FLOW_LOCK_LOG> HRM_ATTEND_FLOW_LOCK_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_FORGET_CARD_CAUSE> HRM_ATTEND_FORGET_CARD_CAUSE { get; set; }
        public virtual DbSet<HRM_ATTEND_FORGET_CARD_CAUSE_LOG> HRM_ATTEND_FORGET_CARD_CAUSE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_GROUP_DETAIL> HRM_ATTEND_GROUP_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_GROUP_DETAIL_LOG> HRM_ATTEND_GROUP_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_GROUP_MASTER> HRM_ATTEND_GROUP_MASTER { get; set; }
        public virtual DbSet<HRM_ATTEND_GROUP_MASTER_LOG> HRM_ATTEND_GROUP_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_GROUP_PARAMETER> HRM_ATTEND_GROUP_PARAMETER { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY> HRM_ATTEND_HOLIDAY { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_KIND> HRM_ATTEND_HOLIDAY_KIND { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_KIND_LOG> HRM_ATTEND_HOLIDAY_KIND_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_LOG> HRM_ATTEND_HOLIDAY_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_OVERTIME_DATA> HRM_ATTEND_HOLIDAY_OVERTIME_DATA { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_OVERTIME_DATA_LOG> HRM_ATTEND_HOLIDAY_OVERTIME_DATA_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_OVERTIME_RATE> HRM_ATTEND_HOLIDAY_OVERTIME_RATE { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_OVERTIME_RATE_LOG> HRM_ATTEND_HOLIDAY_OVERTIME_RATE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_ROTE_CHANGE> HRM_ATTEND_HOLIDAY_ROTE_CHANGE { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL> HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL_LOG> HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_ROTE_CHANGE_LOG> HRM_ATTEND_HOLIDAY_ROTE_CHANGE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_ROTE_FIND> HRM_ATTEND_HOLIDAY_ROTE_FIND { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_ROTE_FIND_LOG> HRM_ATTEND_HOLIDAY_ROTE_FIND_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_SALARY> HRM_ATTEND_HOLIDAY_SALARY { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_SALARY_LOG> HRM_ATTEND_HOLIDAY_SALARY_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_TYPE> HRM_ATTEND_HOLIDAY_TYPE { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIDAY_TYPE_LOG> HRM_ATTEND_HOLIDAY_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIMAPPING_DETAIL> HRM_ATTEND_HOLIMAPPING_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIMAPPING_DETAIL_LOG> HRM_ATTEND_HOLIMAPPING_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIMAPPING_MASTER> HRM_ATTEND_HOLIMAPPING_MASTER { get; set; }
        public virtual DbSet<HRM_ATTEND_HOLIMAPPING_MASTER_LOG> HRM_ATTEND_HOLIMAPPING_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_LEAVE_CANCEL_FLOW> HRM_ATTEND_LEAVE_CANCEL_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_LEAVE_CANCEL_FLOW_LOG> HRM_ATTEND_LEAVE_CANCEL_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_LEAVE_CANCEL_MINUS> HRM_ATTEND_LEAVE_CANCEL_MINUS { get; set; }
        public virtual DbSet<HRM_ATTEND_LEAVE_CANCEL_MINUS_DETAIL> HRM_ATTEND_LEAVE_CANCEL_MINUS_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_MANAGER_PLUS> HRM_ATTEND_MANAGER_PLUS { get; set; }
        public virtual DbSet<HRM_ATTEND_MANAGER_PLUS_LOG> HRM_ATTEND_MANAGER_PLUS_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_MEAL_DATA> HRM_ATTEND_MEAL_DATA { get; set; }
        public virtual DbSet<HRM_ATTEND_MEAL_DATA_LOG> HRM_ATTEND_MEAL_DATA_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CAUSE> HRM_ATTEND_OVERTIME_CAUSE { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CAUSE_LOG> HRM_ATTEND_OVERTIME_CAUSE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CONFIG> HRM_ATTEND_OVERTIME_CONFIG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CONFIG_DEPT> HRM_ATTEND_OVERTIME_CONFIG_DEPT { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CONFIG_DEPT_LOG> HRM_ATTEND_OVERTIME_CONFIG_DEPT_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CONFIG_LOG> HRM_ATTEND_OVERTIME_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CREATE> HRM_ATTEND_OVERTIME_CREATE { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_CREATE_LOG> HRM_ATTEND_OVERTIME_CREATE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_DATA> HRM_ATTEND_OVERTIME_DATA { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_DATA_FLOW> HRM_ATTEND_OVERTIME_DATA_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_DATA_FLOW_LOG> HRM_ATTEND_OVERTIME_DATA_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_DATA_LOG> HRM_ATTEND_OVERTIME_DATA_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_DATA_SET_FLOW> HRM_ATTEND_OVERTIME_DATA_SET_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_RATE> HRM_ATTEND_OVERTIME_RATE { get; set; }
        public virtual DbSet<HRM_ATTEND_OVERTIME_RATE_LOG> HRM_ATTEND_OVERTIME_RATE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_REST_HOLIDAY_MINUS> HRM_ATTEND_REST_HOLIDAY_MINUS { get; set; }
        public virtual DbSet<HRM_ATTEND_REST_HOLIDAY_MINUS_LOG> HRM_ATTEND_REST_HOLIDAY_MINUS_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE> HRM_ATTEND_ROTE { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTEMAPPING_DETAIL> HRM_ATTEND_ROTEMAPPING_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTEMAPPING_DETAIL_LOG> HRM_ATTEND_ROTEMAPPING_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTEMAPPING_HOUR_PATCH> HRM_ATTEND_ROTEMAPPING_HOUR_PATCH { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTEMAPPING_HOUR_PATCH_LOG> HRM_ATTEND_ROTEMAPPING_HOUR_PATCH_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTEMAPPING_MASTER> HRM_ATTEND_ROTEMAPPING_MASTER { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTEMAPPING_MASTER_LOG> HRM_ATTEND_ROTEMAPPING_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_CHANGE> HRM_ATTEND_ROTE_CHANGE { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_CHANGE_DETAIL> HRM_ATTEND_ROTE_CHANGE_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_CHANGE_FLOW> HRM_ATTEND_ROTE_CHANGE_FLOW { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_CHANGE_FLOW_DETAIL> HRM_ATTEND_ROTE_CHANGE_FLOW_DETAIL { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_CHANGE_FLOW_LOG> HRM_ATTEND_ROTE_CHANGE_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_CHANGE_LOG> HRM_ATTEND_ROTE_CHANGE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_HOLIDAY> HRM_ATTEND_ROTE_HOLIDAY { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_HOLIDAY_LOG> HRM_ATTEND_ROTE_HOLIDAY_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_LOG> HRM_ATTEND_ROTE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_REST> HRM_ATTEND_ROTE_REST { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_REST_LOG> HRM_ATTEND_ROTE_REST_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_WORK> HRM_ATTEND_ROTE_WORK { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE_WORK_LOG> HRM_ATTEND_ROTE_WORK_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT> HRM_ATTEND_SHIFT { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_LOG> HRM_ATTEND_SHIFT_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_ROTE> HRM_ATTEND_SHIFT_ROTE { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_ROTE_LOG> HRM_ATTEND_SHIFT_ROTE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_SCHEDULE> HRM_ATTEND_SHIFT_SCHEDULE { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_SCHEDULE_2625> HRM_ATTEND_SHIFT_SCHEDULE_2625 { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_SCHEDULE_2625_LOG> HRM_ATTEND_SHIFT_SCHEDULE_2625_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_SHIFT_SCHEDULE_LOG> HRM_ATTEND_SHIFT_SCHEDULE_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_YEAR_HOLIDAY> HRM_ATTEND_YEAR_HOLIDAY { get; set; }
        public virtual DbSet<HRM_ATTEND_YEAR_HOLIDAY_LOG> HRM_ATTEND_YEAR_HOLIDAY_LOG { get; set; }
        public virtual DbSet<HRM_ATTEND_YEAR_HOLIDAY_MINUS> HRM_ATTEND_YEAR_HOLIDAY_MINUS { get; set; }
        public virtual DbSet<HRM_ATTEND_YEAR_HOLIDAY_MINUS_LOG> HRM_ATTEND_YEAR_HOLIDAY_MINUS_LOG { get; set; }
        public virtual DbSet<HRM_BANK> HRM_BANK { get; set; }
        public virtual DbSet<HRM_BANK_LOG> HRM_BANK_LOG { get; set; }
        public virtual DbSet<HRM_BASE_BASE> HRM_BASE_BASE { get; set; }
        public virtual DbSet<HRM_BASE_BASEIO> HRM_BASE_BASEIO { get; set; }
        public virtual DbSet<HRM_BASE_BASEIO_LOG> HRM_BASE_BASEIO_LOG { get; set; }
        public virtual DbSet<HRM_BASE_BASETTS> HRM_BASE_BASETTS { get; set; }
        public virtual DbSet<HRM_BASE_BASETTS_LOG> HRM_BASE_BASETTS_LOG { get; set; }
        public virtual DbSet<HRM_BASE_BASE_LOG> HRM_BASE_BASE_LOG { get; set; }
        public virtual DbSet<HRM_COMPANY> HRM_COMPANY { get; set; }
        public virtual DbSet<HRM_COMPANY_LOG> HRM_COMPANY_LOG { get; set; }
        public virtual DbSet<HRM_CONTRACT_TYPE> HRM_CONTRACT_TYPE { get; set; }
        public virtual DbSet<HRM_CONTRACT_TYPE_LOG> HRM_CONTRACT_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_COUNTRY> HRM_COUNTRY { get; set; }
        public virtual DbSet<HRM_COUNTRY_LOG> HRM_COUNTRY_LOG { get; set; }
        public virtual DbSet<HRM_COURSE_SETS> HRM_COURSE_SETS { get; set; }
        public virtual DbSet<HRM_COURSE_SETS_LOG> HRM_COURSE_SETS_LOG { get; set; }
        public virtual DbSet<HRM_CURRENCY> HRM_CURRENCY { get; set; }
        public virtual DbSet<HRM_CURRENCY_LOG> HRM_CURRENCY_LOG { get; set; }
        public virtual DbSet<HRM_DEPT> HRM_DEPT { get; set; }
        public virtual DbSet<HRM_DEPTA> HRM_DEPTA { get; set; }
        public virtual DbSet<HRM_DEPTA_LOG> HRM_DEPTA_LOG { get; set; }
        public virtual DbSet<HRM_DEPTC> HRM_DEPTC { get; set; }
        public virtual DbSet<HRM_DEPTC_GROUP> HRM_DEPTC_GROUP { get; set; }
        public virtual DbSet<HRM_DEPTC_LOG> HRM_DEPTC_LOG { get; set; }
        public virtual DbSet<HRM_DEPT_LOG> HRM_DEPT_LOG { get; set; }
        public virtual DbSet<HRM_DOORGUARD> HRM_DOORGUARD { get; set; }
        public virtual DbSet<HRM_DOORGUARD_LOG> HRM_DOORGUARD_LOG { get; set; }
        public virtual DbSet<HRM_EDUCATIONAL> HRM_EDUCATIONAL { get; set; }
        public virtual DbSet<HRM_EDUCATIONAL_LOG> HRM_EDUCATIONAL_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_ACCOUNT> HRM_EMPLOYEE_ACCOUNT { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_ACCOUNT_LOG> HRM_EMPLOYEE_ACCOUNT_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_ADDR> HRM_EMPLOYEE_ADDR { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_ADDR_LOG> HRM_EMPLOYEE_ADDR_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_CONTACT> HRM_EMPLOYEE_CONTACT { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_CONTACT_LOG> HRM_EMPLOYEE_CONTACT_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_CONTRACT> HRM_EMPLOYEE_CONTRACT { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_CONTRACT_LOG> HRM_EMPLOYEE_CONTRACT_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_COST> HRM_EMPLOYEE_COST { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_COST_LOG> HRM_EMPLOYEE_COST_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EDUCATIONAL> HRM_EMPLOYEE_EDUCATIONAL { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EDUCATIONAL_LOG> HRM_EMPLOYEE_EDUCATIONAL_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPAND> HRM_EMPLOYEE_EXPAND { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPAND_LOG> HRM_EMPLOYEE_EXPAND_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPAND_SET> HRM_EMPLOYEE_EXPAND_SET { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPERIENCE> HRM_EMPLOYEE_EXPERIENCE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPERIENCE_FILE> HRM_EMPLOYEE_EXPERIENCE_FILE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPERIENCE_FILE_LOG> HRM_EMPLOYEE_EXPERIENCE_FILE_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_EXPERIENCE_LOG> HRM_EMPLOYEE_EXPERIENCE_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_FAMILY> HRM_EMPLOYEE_FAMILY { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_FAMILY_LOG> HRM_EMPLOYEE_FAMILY_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH> HRM_EMPLOYEE_HEALTH { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_FAMILY> HRM_EMPLOYEE_HEALTH_FAMILY { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_FAMILY_LOG> HRM_EMPLOYEE_HEALTH_FAMILY_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_GROUP> HRM_EMPLOYEE_HEALTH_GROUP { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_GROUP_FAMILY> HRM_EMPLOYEE_HEALTH_GROUP_FAMILY { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_GROUP_FAMILY_LOG> HRM_EMPLOYEE_HEALTH_GROUP_FAMILY_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_GROUP_LOG> HRM_EMPLOYEE_HEALTH_GROUP_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_HEALTH_LOG> HRM_EMPLOYEE_HEALTH_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_IDENTITY> HRM_EMPLOYEE_IDENTITY { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_IDENTITY_LOG> HRM_EMPLOYEE_IDENTITY_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_INSURANCE> HRM_EMPLOYEE_INSURANCE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LABOR> HRM_EMPLOYEE_LABOR { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LABOR_LOG> HRM_EMPLOYEE_LABOR_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LABOR_SCHEDULE> HRM_EMPLOYEE_LABOR_SCHEDULE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LABOR_SCHEDULE_LOG> HRM_EMPLOYEE_LABOR_SCHEDULE_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LICENCE> HRM_EMPLOYEE_LICENCE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LICENCE_FILE> HRM_EMPLOYEE_LICENCE_FILE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LICENCE_FILE_LOG> HRM_EMPLOYEE_LICENCE_FILE_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_LICENCE_LOG> HRM_EMPLOYEE_LICENCE_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_MONTH_MEETING> HRM_EMPLOYEE_MONTH_MEETING { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_MONTH_MEETING_DETAIL> HRM_EMPLOYEE_MONTH_MEETING_DETAIL { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_MONTH_MEETING_DETAIL_LOG> HRM_EMPLOYEE_MONTH_MEETING_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_MONTH_MEETING_LOG> HRM_EMPLOYEE_MONTH_MEETING_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_PARAMETER> HRM_EMPLOYEE_PARAMETER { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_PARAMETER_LOG> HRM_EMPLOYEE_PARAMETER_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_PAYROLL> HRM_EMPLOYEE_PAYROLL { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_PAYROLL_LOG> HRM_EMPLOYEE_PAYROLL_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_RESIDENT> HRM_EMPLOYEE_RESIDENT { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_RESIDENT_LOG> HRM_EMPLOYEE_RESIDENT_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_RETIRE> HRM_EMPLOYEE_RETIRE { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_RETIREMENT> HRM_EMPLOYEE_RETIREMENT { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_RETIREMENT_LOG> HRM_EMPLOYEE_RETIREMENT_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_RETIRE_LOG> HRM_EMPLOYEE_RETIRE_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_REWARD> HRM_EMPLOYEE_REWARD { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_REWARD_LOG> HRM_EMPLOYEE_REWARD_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_SKILL> HRM_EMPLOYEE_SKILL { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_SKILL_LOG> HRM_EMPLOYEE_SKILL_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_TEMPORARY_WORKER> HRM_EMPLOYEE_TEMPORARY_WORKER { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_TEMPORARY_WORKER_LOG> HRM_EMPLOYEE_TEMPORARY_WORKER_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY> HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY_LOG> HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY_LOG { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_UNIFORM> HRM_EMPLOYEE_UNIFORM { get; set; }
        public virtual DbSet<HRM_EMPLOYEE_UNIFORM_LOG> HRM_EMPLOYEE_UNIFORM_LOG { get; set; }
        public virtual DbSet<HRM_EXPENSE> HRM_EXPENSE { get; set; }
        public virtual DbSet<HRM_EXPENSE_LOG> HRM_EXPENSE_LOG { get; set; }
        public virtual DbSet<HRM_FLOW_ABSENT_AGENT> HRM_FLOW_ABSENT_AGENT { get; set; }
        public virtual DbSet<HRM_FLOW_ABSENT_AGENT_LOG> HRM_FLOW_ABSENT_AGENT_LOG { get; set; }
        public virtual DbSet<HRM_FLOW_APPLICATE_AGENT> HRM_FLOW_APPLICATE_AGENT { get; set; }
        public virtual DbSet<HRM_FLOW_APPLICATE_AGENT_LOG> HRM_FLOW_APPLICATE_AGENT_LOG { get; set; }
        public virtual DbSet<HRM_FLOW_EMPLOYEE_ROLE_MAPPING> HRM_FLOW_EMPLOYEE_ROLE_MAPPING { get; set; }
        public virtual DbSet<HRM_FLOW_EMPLOYEE_ROLE_MAPPING_LOG> HRM_FLOW_EMPLOYEE_ROLE_MAPPING_LOG { get; set; }
        public virtual DbSet<HRM_FLOW_PRESELECTION_AGENT> HRM_FLOW_PRESELECTION_AGENT { get; set; }
        public virtual DbSet<HRM_FOREIGN_WORK_TYPE> HRM_FOREIGN_WORK_TYPE { get; set; }
        public virtual DbSet<HRM_FOREIGN_WORK_TYPE_LOG> HRM_FOREIGN_WORK_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_FencePoints> HRM_FencePoints { get; set; }
        public virtual DbSet<HRM_HEALTH_ALLOWANCE> HRM_HEALTH_ALLOWANCE { get; set; }
        public virtual DbSet<HRM_HEALTH_ALLOWANCE_LOG> HRM_HEALTH_ALLOWANCE_LOG { get; set; }
        public virtual DbSet<HRM_HEALTH_LEAVE_CAUSE> HRM_HEALTH_LEAVE_CAUSE { get; set; }
        public virtual DbSet<HRM_HEALTH_LEAVE_CAUSE_LOG> HRM_HEALTH_LEAVE_CAUSE_LOG { get; set; }
        public virtual DbSet<HRM_HEALTH_RELATION> HRM_HEALTH_RELATION { get; set; }
        public virtual DbSet<HRM_HIRE_WAY> HRM_HIRE_WAY { get; set; }
        public virtual DbSet<HRM_HIRE_WAY_LOG> HRM_HIRE_WAY_LOG { get; set; }
        public virtual DbSet<HRM_IDENTITY> HRM_IDENTITY { get; set; }
        public virtual DbSet<HRM_IDENTITY_LOG> HRM_IDENTITY_LOG { get; set; }
        public virtual DbSet<HRM_INSURANCE_COMPANY> HRM_INSURANCE_COMPANY { get; set; }
        public virtual DbSet<HRM_INSURANCE_COMPANY_LOG> HRM_INSURANCE_COMPANY_LOG { get; set; }
        public virtual DbSet<HRM_INSURANCE_LABOR_HELATH> HRM_INSURANCE_LABOR_HELATH { get; set; }
        public virtual DbSet<HRM_INSURANCE_LEVEL> HRM_INSURANCE_LEVEL { get; set; }
        public virtual DbSet<HRM_INSURANCE_LEVEL_LOG> HRM_INSURANCE_LEVEL_LOG { get; set; }
        public virtual DbSet<HRM_INSURANCE_YEAR_SUMMARY> HRM_INSURANCE_YEAR_SUMMARY { get; set; }
        public virtual DbSet<HRM_INSURANCE_YEAR_SUMMARY_LOG> HRM_INSURANCE_YEAR_SUMMARY_LOG { get; set; }
        public virtual DbSet<HRM_INTRODUCE_COMPANY> HRM_INTRODUCE_COMPANY { get; set; }
        public virtual DbSet<HRM_INTRODUCE_COMPANY_LOG> HRM_INTRODUCE_COMPANY_LOG { get; set; }
        public virtual DbSet<HRM_JOB> HRM_JOB { get; set; }
        public virtual DbSet<HRM_JOB_CLASS> HRM_JOB_CLASS { get; set; }
        public virtual DbSet<HRM_JOB_CLASS_LOG> HRM_JOB_CLASS_LOG { get; set; }
        public virtual DbSet<HRM_JOB_CONTENT> HRM_JOB_CONTENT { get; set; }
        public virtual DbSet<HRM_JOB_CONTENT_LOG> HRM_JOB_CONTENT_LOG { get; set; }
        public virtual DbSet<HRM_JOB_FUNCTION> HRM_JOB_FUNCTION { get; set; }
        public virtual DbSet<HRM_JOB_FUNCTION_LOG> HRM_JOB_FUNCTION_LOG { get; set; }
        public virtual DbSet<HRM_JOB_GRADE> HRM_JOB_GRADE { get; set; }
        public virtual DbSet<HRM_JOB_GRADE_LOG> HRM_JOB_GRADE_LOG { get; set; }
        public virtual DbSet<HRM_JOB_LEVEL> HRM_JOB_LEVEL { get; set; }
        public virtual DbSet<HRM_JOB_LEVEL_LOG> HRM_JOB_LEVEL_LOG { get; set; }
        public virtual DbSet<HRM_JOB_LOG> HRM_JOB_LOG { get; set; }
        public virtual DbSet<HRM_JOB_WORK> HRM_JOB_WORK { get; set; }
        public virtual DbSet<HRM_JOB_WORK_LOG> HRM_JOB_WORK_LOG { get; set; }
        public virtual DbSet<HRM_LABOR_ALLOWANCE> HRM_LABOR_ALLOWANCE { get; set; }
        public virtual DbSet<HRM_LABOR_ALLOWANCE_LOG> HRM_LABOR_ALLOWANCE_LOG { get; set; }
        public virtual DbSet<HRM_LEAVE_CAUSE> HRM_LEAVE_CAUSE { get; set; }
        public virtual DbSet<HRM_LEAVE_CAUSE_LOG> HRM_LEAVE_CAUSE_LOG { get; set; }
        public virtual DbSet<HRM_LICENCE> HRM_LICENCE { get; set; }
        public virtual DbSet<HRM_LICENCE_LOG> HRM_LICENCE_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_FORMAT> HRM_MEDIA_TAX_FORMAT { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_FORMAT_LOG> HRM_MEDIA_TAX_FORMAT_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_ID_CODE> HRM_MEDIA_TAX_ID_CODE { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_ID_CODE_LOG> HRM_MEDIA_TAX_ID_CODE_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_INDUSTRIAL> HRM_MEDIA_TAX_INDUSTRIAL { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_INDUSTRIAL_LOG> HRM_MEDIA_TAX_INDUSTRIAL_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_MONTH_FOREIGN> HRM_MEDIA_TAX_MONTH_FOREIGN { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_MONTH_FOREIGN_LOG> HRM_MEDIA_TAX_MONTH_FOREIGN_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_OFFICE> HRM_MEDIA_TAX_OFFICE { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_OFFICE_LOG> HRM_MEDIA_TAX_OFFICE_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_PAYMENT_ITEM> HRM_MEDIA_TAX_PAYMENT_ITEM { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_PAYMENT_ITEM_LOG> HRM_MEDIA_TAX_PAYMENT_ITEM_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_PEOPLE> HRM_MEDIA_TAX_PEOPLE { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_PEOPLE_LOG> HRM_MEDIA_TAX_PEOPLE_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_YEAR_PEOPLE> HRM_MEDIA_TAX_YEAR_PEOPLE { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_YEAR_PEOPLE_LOG> HRM_MEDIA_TAX_YEAR_PEOPLE_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_YEAR_PEOPLE_TAX> HRM_MEDIA_TAX_YEAR_PEOPLE_TAX { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_YEAR_PEOPLE_TAX_LOG> HRM_MEDIA_TAX_YEAR_PEOPLE_TAX_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_YEAR_TAX> HRM_MEDIA_TAX_YEAR_TAX { get; set; }
        public virtual DbSet<HRM_MEDIA_TAX_YEAR_TAX_LOG> HRM_MEDIA_TAX_YEAR_TAX_LOG { get; set; }
        public virtual DbSet<HRM_MEDIA_TRANSFER> HRM_MEDIA_TRANSFER { get; set; }
        public virtual DbSet<HRM_MEDIA_TRANSFER_DETAIL> HRM_MEDIA_TRANSFER_DETAIL { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_DATA> HRM_PERFORMANCE_DATA { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_DATA_LOG> HRM_PERFORMANCE_DATA_LOG { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_ESOT_LEVELMAPPING> HRM_PERFORMANCE_ESOT_LEVELMAPPING { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_ESOT_LEVELMAPPING_LOG> HRM_PERFORMANCE_ESOT_LEVELMAPPING_LOG { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_ESOT_YYMMMAPPING> HRM_PERFORMANCE_ESOT_YYMMMAPPING { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_ESOT_YYMMMAPPING_LOG> HRM_PERFORMANCE_ESOT_YYMMMAPPING_LOG { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_LEVEL> HRM_PERFORMANCE_LEVEL { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_LEVEL_LOG> HRM_PERFORMANCE_LEVEL_LOG { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_TYPE> HRM_PERFORMANCE_TYPE { get; set; }
        public virtual DbSet<HRM_PERFORMANCE_TYPE_LOG> HRM_PERFORMANCE_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_PROVINCE> HRM_PROVINCE { get; set; }
        public virtual DbSet<HRM_PROVINCE_LOG> HRM_PROVINCE_LOG { get; set; }
        public virtual DbSet<HRM_PunchCardRecord> HRM_PunchCardRecord { get; set; }
        public virtual DbSet<HRM_RELATION> HRM_RELATION { get; set; }
        public virtual DbSet<HRM_RELATION_LOG> HRM_RELATION_LOG { get; set; }
        public virtual DbSet<HRM_RETIRE_RATE_TYPE> HRM_RETIRE_RATE_TYPE { get; set; }
        public virtual DbSet<HRM_REWARD> HRM_REWARD { get; set; }
        public virtual DbSet<HRM_REWARD_KIND> HRM_REWARD_KIND { get; set; }
        public virtual DbSet<HRM_REWARD_KIND_LOG> HRM_REWARD_KIND_LOG { get; set; }
        public virtual DbSet<HRM_REWARD_LOG> HRM_REWARD_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ABSENT> HRM_SALARY_ABSENT { get; set; }
        public virtual DbSet<HRM_SALARY_ABSENT_LOG> HRM_SALARY_ABSENT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ACCOUNT> HRM_SALARY_ACCOUNT { get; set; }
        public virtual DbSet<HRM_SALARY_ACCOUNT_DETAIL> HRM_SALARY_ACCOUNT_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_ACCOUNT_DETAIL_LOG> HRM_SALARY_ACCOUNT_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ACCOUNT_LOG> HRM_SALARY_ACCOUNT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ASSESSMENT_PARAMETER> HRM_SALARY_ASSESSMENT_PARAMETER { get; set; }
        public virtual DbSet<HRM_SALARY_ASSESSMENT_PARAMETER_LOG> HRM_SALARY_ASSESSMENT_PARAMETER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ATTEND_DATA> HRM_SALARY_ATTEND_DATA { get; set; }
        public virtual DbSet<HRM_SALARY_ATTEND_DATA_LOG> HRM_SALARY_ATTEND_DATA_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ATTEND_DAY_SET> HRM_SALARY_ATTEND_DAY_SET { get; set; }
        public virtual DbSet<HRM_SALARY_ATTEND_DAY_SET_LOG> HRM_SALARY_ATTEND_DAY_SET_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ATTRIBUTE> HRM_SALARY_ATTRIBUTE { get; set; }
        public virtual DbSet<HRM_SALARY_BANK_TRANSFER> HRM_SALARY_BANK_TRANSFER { get; set; }
        public virtual DbSet<HRM_SALARY_BANK_TRANSFER_CLIENT> HRM_SALARY_BANK_TRANSFER_CLIENT { get; set; }
        public virtual DbSet<HRM_SALARY_BANK_TRANSFER_CLIENT_LOG> HRM_SALARY_BANK_TRANSFER_CLIENT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_BANK_TRANSFER_DETAIL> HRM_SALARY_BANK_TRANSFER_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_BANK_TRANSFER_DETAIL_LOG> HRM_SALARY_BANK_TRANSFER_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_BANK_TRANSFER_LOG> HRM_SALARY_BANK_TRANSFER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_BASESALARY> HRM_SALARY_BASESALARY { get; set; }
        public virtual DbSet<HRM_SALARY_BASESALARY_LOG> HRM_SALARY_BASESALARY_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_BASETTS> HRM_SALARY_BASETTS { get; set; }
        public virtual DbSet<HRM_SALARY_BASETTS_LOG> HRM_SALARY_BASETTS_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_COURT_DEDUCT_DATA> HRM_SALARY_COURT_DEDUCT_DATA { get; set; }
        public virtual DbSet<HRM_SALARY_COURT_DEDUCT_DATA_LOG> HRM_SALARY_COURT_DEDUCT_DATA_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_COURT_DEDUCT_SET> HRM_SALARY_COURT_DEDUCT_SET { get; set; }
        public virtual DbSet<HRM_SALARY_COURT_DEDUCT_SET_LOG> HRM_SALARY_COURT_DEDUCT_SET_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_DUTY_ALLOWANCE> HRM_SALARY_DUTY_ALLOWANCE { get; set; }
        public virtual DbSet<HRM_SALARY_DUTY_ALLOWANCE_FLOW> HRM_SALARY_DUTY_ALLOWANCE_FLOW { get; set; }
        public virtual DbSet<HRM_SALARY_DUTY_ALLOWANCE_FLOW_LOG> HRM_SALARY_DUTY_ALLOWANCE_FLOW_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_DUTY_ALLOWANCE_LOG> HRM_SALARY_DUTY_ALLOWANCE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ENRICH> HRM_SALARY_ENRICH { get; set; }
        public virtual DbSet<HRM_SALARY_ENRICH_LOG> HRM_SALARY_ENRICH_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_EXPRESSION_DETAIL> HRM_SALARY_EXPRESSION_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_EXPRESSION_DETAIL_LOG> HRM_SALARY_EXPRESSION_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_EXPRESSION_MASTER> HRM_SALARY_EXPRESSION_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_EXPRESSION_MASTER_LOG> HRM_SALARY_EXPRESSION_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_EXPRESSION_SYSTEM> HRM_SALARY_EXPRESSION_SYSTEM { get; set; }
        public virtual DbSet<HRM_SALARY_EXPRESSION_SYSTEM_LOG> HRM_SALARY_EXPRESSION_SYSTEM_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_FESTIVAL> HRM_SALARY_FESTIVAL { get; set; }
        public virtual DbSet<HRM_SALARY_FESTIVAL_LOG> HRM_SALARY_FESTIVAL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_FESTIVAL_MONTH> HRM_SALARY_FESTIVAL_MONTH { get; set; }
        public virtual DbSet<HRM_SALARY_FESTIVAL_MONTH_LOG> HRM_SALARY_FESTIVAL_MONTH_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_FIXED_DEDUCT_DATA> HRM_SALARY_FIXED_DEDUCT_DATA { get; set; }
        public virtual DbSet<HRM_SALARY_FIXED_DEDUCT_DATA_LOG> HRM_SALARY_FIXED_DEDUCT_DATA_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_FIX_DEDUCT> HRM_SALARY_FIX_DEDUCT { get; set; }
        public virtual DbSet<HRM_SALARY_FIX_DEDUCT_LOG> HRM_SALARY_FIX_DEDUCT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_FORGET_CARD_CAUSE> HRM_SALARY_FORGET_CARD_CAUSE { get; set; }
        public virtual DbSet<HRM_SALARY_FORGET_CARD_CAUSE_LOG> HRM_SALARY_FORGET_CARD_CAUSE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_FUND_TRANSFER> HRM_SALARY_FUND_TRANSFER { get; set; }
        public virtual DbSet<HRM_SALARY_FUND_TRANSFER_LOG> HRM_SALARY_FUND_TRANSFER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_GRADE_LEVEL> HRM_SALARY_GRADE_LEVEL { get; set; }
        public virtual DbSet<HRM_SALARY_GRADE_LEVEL_LOG> HRM_SALARY_GRADE_LEVEL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_GROUP_DETAIL> HRM_SALARY_GROUP_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_GROUP_DETAIL_LOG> HRM_SALARY_GROUP_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_GROUP_MASTER> HRM_SALARY_GROUP_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_GROUP_MASTER_LOG> HRM_SALARY_GROUP_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_GROUP_PARAMETER> HRM_SALARY_GROUP_PARAMETER { get; set; }
        public virtual DbSet<HRM_SALARY_HOLIDAY_ESTIMATE_EMPLOYEE> HRM_SALARY_HOLIDAY_ESTIMATE_EMPLOYEE { get; set; }
        public virtual DbSet<HRM_SALARY_HOLIDAY_OVERTIME_DATA_DETAIL> HRM_SALARY_HOLIDAY_OVERTIME_DATA_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_HOLIDAY_OVERTIME_DATA_MASTER> HRM_SALARY_HOLIDAY_OVERTIME_DATA_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_INCOMETAX> HRM_SALARY_INCOMETAX { get; set; }
        public virtual DbSet<HRM_SALARY_INCOMETAX_FOREIGNER> HRM_SALARY_INCOMETAX_FOREIGNER { get; set; }
        public virtual DbSet<HRM_SALARY_INSURANCE_SALARY> HRM_SALARY_INSURANCE_SALARY { get; set; }
        public virtual DbSet<HRM_SALARY_INSURANCE_SETTLEMENT> HRM_SALARY_INSURANCE_SETTLEMENT { get; set; }
        public virtual DbSet<HRM_SALARY_INSURANCE_SETTLEMENT_LOG> HRM_SALARY_INSURANCE_SETTLEMENT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_JOB_LEVEL_ALLOWANCE> HRM_SALARY_JOB_LEVEL_ALLOWANCE { get; set; }
        public virtual DbSet<HRM_SALARY_JOB_LEVEL_ALLOWANCE_LOG> HRM_SALARY_JOB_LEVEL_ALLOWANCE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_LABOR_HELATH> HRM_SALARY_LABOR_HELATH { get; set; }
        public virtual DbSet<HRM_SALARY_LABOR_HELATH_LOG> HRM_SALARY_LABOR_HELATH_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_LICENSE_ALLOWANCE_SET> HRM_SALARY_LICENSE_ALLOWANCE_SET { get; set; }
        public virtual DbSet<HRM_SALARY_LICENSE_ALLOWANCE_SET_LOG> HRM_SALARY_LICENSE_ALLOWANCE_SET_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_LICENSE_ALLOWANCE_TYPE> HRM_SALARY_LICENSE_ALLOWANCE_TYPE { get; set; }
        public virtual DbSet<HRM_SALARY_LICENSE_ALLOWANCE_TYPE_LOG> HRM_SALARY_LICENSE_ALLOWANCE_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_MANAGER> HRM_SALARY_MANAGER { get; set; }
        public virtual DbSet<HRM_SALARY_MANAGER_LOG> HRM_SALARY_MANAGER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_MONTHPAY_HISTORY> HRM_SALARY_MONTHPAY_HISTORY { get; set; }
        public virtual DbSet<HRM_SALARY_MONTHPAY_SETTLEMENT> HRM_SALARY_MONTHPAY_SETTLEMENT { get; set; }
        public virtual DbSet<HRM_SALARY_MONTHPAY_SETTLEMENT_LOG> HRM_SALARY_MONTHPAY_SETTLEMENT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_ABSENT> HRM_SALARY_OVERTIME_ABSENT { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_ABSENT_LOG> HRM_SALARY_OVERTIME_ABSENT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_DATA_DETAIL> HRM_SALARY_OVERTIME_DATA_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_DATA_DETAIL_LOG> HRM_SALARY_OVERTIME_DATA_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_DATA_MASTER> HRM_SALARY_OVERTIME_DATA_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_DATA_MASTER_LOG> HRM_SALARY_OVERTIME_DATA_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATEFIXED_DETAIL> HRM_SALARY_OVERTIME_RATEFIXED_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATEFIXED_DETAIL_LOG> HRM_SALARY_OVERTIME_RATEFIXED_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATEFIXED_MASTER> HRM_SALARY_OVERTIME_RATEFIXED_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATEFIXED_MASTER_LOG> HRM_SALARY_OVERTIME_RATEFIXED_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATE_DETAIL> HRM_SALARY_OVERTIME_RATE_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATE_DETAIL_LOG> HRM_SALARY_OVERTIME_RATE_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATE_MASTER> HRM_SALARY_OVERTIME_RATE_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATE_MASTER_LOG> HRM_SALARY_OVERTIME_RATE_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATE_PATCH> HRM_SALARY_OVERTIME_RATE_PATCH { get; set; }
        public virtual DbSet<HRM_SALARY_OVERTIME_RATE_PATCH_LOG> HRM_SALARY_OVERTIME_RATE_PATCH_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_CALCULATOR> HRM_SALARY_PAYROLL_CALCULATOR { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_CALCULATOR_LOG> HRM_SALARY_PAYROLL_CALCULATOR_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_HISTORY> HRM_SALARY_PAYROLL_HISTORY { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT> HRM_SALARY_PAYROLL_SETTLEMENT { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL> HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL_LOG> HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_HISTORY> HRM_SALARY_PAYROLL_SETTLEMENT_HISTORY { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_LOG> HRM_SALARY_PAYROLL_SETTLEMENT_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK> HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_DETAIL> HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_DETAIL_LOG> HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_HISTORY> HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_HISTORY { get; set; }
        public virtual DbSet<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_LOG> HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_PERFORMANCE> HRM_SALARY_PERFORMANCE { get; set; }
        public virtual DbSet<HRM_SALARY_PERFORMANCE_LOG> HRM_SALARY_PERFORMANCE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_REPORT_DEPT> HRM_SALARY_REPORT_DEPT { get; set; }
        public virtual DbSet<HRM_SALARY_REPORT_DEPTC> HRM_SALARY_REPORT_DEPTC { get; set; }
        public virtual DbSet<HRM_SALARY_ROTE_ALLOWANCE_DATA> HRM_SALARY_ROTE_ALLOWANCE_DATA { get; set; }
        public virtual DbSet<HRM_SALARY_ROTE_ALLOWANCE_DATA_LOG> HRM_SALARY_ROTE_ALLOWANCE_DATA_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ROTE_ALLOWANCE_SET> HRM_SALARY_ROTE_ALLOWANCE_SET { get; set; }
        public virtual DbSet<HRM_SALARY_ROTE_ALLOWANCE_SET_COMPANY> HRM_SALARY_ROTE_ALLOWANCE_SET_COMPANY { get; set; }
        public virtual DbSet<HRM_SALARY_ROTE_ALLOWANCE_SET_COMPANY_LOG> HRM_SALARY_ROTE_ALLOWANCE_SET_COMPANY_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_ROTE_ALLOWANCE_SET_LOG> HRM_SALARY_ROTE_ALLOWANCE_SET_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_BASETTS> HRM_SALARY_SALBASE_BASETTS { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_BASETTS_LOG> HRM_SALARY_SALBASE_BASETTS_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_EXPATRIATE_BASETTS> HRM_SALARY_SALBASE_EXPATRIATE_BASETTS { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_EXPATRIATE_BASETTS_LOG> HRM_SALARY_SALBASE_EXPATRIATE_BASETTS_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_MAPPING_DETAIL> HRM_SALARY_SALBASE_MAPPING_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_MAPPING_DETAIL_LOG> HRM_SALARY_SALBASE_MAPPING_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_MAPPING_MASTER> HRM_SALARY_SALBASE_MAPPING_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_SALBASE_MAPPING_MASTER_LOG> HRM_SALARY_SALBASE_MAPPING_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALCODE> HRM_SALARY_SALCODE { get; set; }
        public virtual DbSet<HRM_SALARY_SALCODE_LOG> HRM_SALARY_SALCODE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALCODE_MERGE> HRM_SALARY_SALCODE_MERGE { get; set; }
        public virtual DbSet<HRM_SALARY_SALCODE_MERGE_LOG> HRM_SALARY_SALCODE_MERGE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALMAPPING_DETAIL> HRM_SALARY_SALMAPPING_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_SALMAPPING_DETAIL_LOG> HRM_SALARY_SALMAPPING_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SALMAPPING_MASTER> HRM_SALARY_SALMAPPING_MASTER { get; set; }
        public virtual DbSet<HRM_SALARY_SALMAPPING_MASTER_LOG> HRM_SALARY_SALMAPPING_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SETTLEMENT_SALARY> HRM_SALARY_SETTLEMENT_SALARY { get; set; }
        public virtual DbSet<HRM_SALARY_SETTLEMENT_SALARY_HISTORY> HRM_SALARY_SETTLEMENT_SALARY_HISTORY { get; set; }
        public virtual DbSet<HRM_SALARY_SETTLEMENT_SALARY_LOG> HRM_SALARY_SETTLEMENT_SALARY_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_SETTLEMENT_WAGE> HRM_SALARY_SETTLEMENT_WAGE { get; set; }
        public virtual DbSet<HRM_SALARY_SETTLEMENT_WAGE_HISTORY> HRM_SALARY_SETTLEMENT_WAGE_HISTORY { get; set; }
        public virtual DbSet<HRM_SALARY_SETTLEMENT_WAGE_LOG> HRM_SALARY_SETTLEMENT_WAGE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_STOCK_TRUST> HRM_SALARY_STOCK_TRUST { get; set; }
        public virtual DbSet<HRM_SALARY_SUPPLY> HRM_SALARY_SUPPLY { get; set; }
        public virtual DbSet<HRM_SALARY_SUPPLY_LOG> HRM_SALARY_SUPPLY_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_TAX_LEVEL> HRM_SALARY_TAX_LEVEL { get; set; }
        public virtual DbSet<HRM_SALARY_TAX_LEVEL_LOG> HRM_SALARY_TAX_LEVEL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_TEMPWORK_SALARY> HRM_SALARY_TEMPWORK_SALARY { get; set; }
        public virtual DbSet<HRM_SALARY_TYPE> HRM_SALARY_TYPE { get; set; }
        public virtual DbSet<HRM_SALARY_TYPE_LOG> HRM_SALARY_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_VARIABLEPAY_DATA> HRM_SALARY_VARIABLEPAY_DATA { get; set; }
        public virtual DbSet<HRM_SALARY_VARIABLEPAY_DATA_LOG> HRM_SALARY_VARIABLEPAY_DATA_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_VARIABLEPAY_SOURCE> HRM_SALARY_VARIABLEPAY_SOURCE { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE> HRM_SALARY_WAGE { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE_DETAIL> HRM_SALARY_WAGE_DETAIL { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE_DETAIL_LOG> HRM_SALARY_WAGE_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE_LOCK> HRM_SALARY_WAGE_LOCK { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE_LOCK_LOG> HRM_SALARY_WAGE_LOCK_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE_LOG> HRM_SALARY_WAGE_LOG { get; set; }
        public virtual DbSet<HRM_SALARY_WAGE_SPECIAL_BONUS> HRM_SALARY_WAGE_SPECIAL_BONUS { get; set; }
        public virtual DbSet<HRM_SALARY_WELFARE_DEDUCT_HOTA> HRM_SALARY_WELFARE_DEDUCT_HOTA { get; set; }
        public virtual DbSet<HRM_SALARY_WELFARE_DEDUCT_HOTA_LOG> HRM_SALARY_WELFARE_DEDUCT_HOTA_LOG { get; set; }
        public virtual DbSet<HRM_SCHOOL> HRM_SCHOOL { get; set; }
        public virtual DbSet<HRM_SCHOOL_LOG> HRM_SCHOOL_LOG { get; set; }
        public virtual DbSet<HRM_SHARECODE> HRM_SHARECODE { get; set; }
        public virtual DbSet<HRM_SHARECODE_GROUP> HRM_SHARECODE_GROUP { get; set; }
        public virtual DbSet<HRM_SHARE_REPORT_TYPE> HRM_SHARE_REPORT_TYPE { get; set; }
        public virtual DbSet<HRM_SKILL> HRM_SKILL { get; set; }
        public virtual DbSet<HRM_SKILL_LOG> HRM_SKILL_LOG { get; set; }
        public virtual DbSet<HRM_SUPPLY_IDENTITY> HRM_SUPPLY_IDENTITY { get; set; }
        public virtual DbSet<HRM_SUPPLY_IDENTITY_LOG> HRM_SUPPLY_IDENTITY_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_ATTEND_CONFIG> HRM_SYSTEM_ATTEND_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_ATTEND_CONFIG_LOG> HRM_SYSTEM_ATTEND_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_GROUP_CONFIG> HRM_SYSTEM_GROUP_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_HEALTH_CONFIG> HRM_SYSTEM_HEALTH_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_HEALTH_CONFIG_LOG> HRM_SYSTEM_HEALTH_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_HOLIDAY_CONFIG> HRM_SYSTEM_HOLIDAY_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_HOLIDAY_CONFIG_LOG> HRM_SYSTEM_HOLIDAY_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_LABOR_CONFIG> HRM_SYSTEM_LABOR_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_LABOR_CONFIG_LOG> HRM_SYSTEM_LABOR_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_MAILQUEUE> HRM_SYSTEM_MAILQUEUE { get; set; }
        public virtual DbSet<HRM_SYSTEM_MAILQUEUE_LOG> HRM_SYSTEM_MAILQUEUE_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_MAPPING_DETAIL> HRM_SYSTEM_MAPPING_DETAIL { get; set; }
        public virtual DbSet<HRM_SYSTEM_MAPPING_MASTER> HRM_SYSTEM_MAPPING_MASTER { get; set; }
        public virtual DbSet<HRM_SYSTEM_NOTIFY_MAIN> HRM_SYSTEM_NOTIFY_MAIN { get; set; }
        public virtual DbSet<HRM_SYSTEM_NOTIFY_PARAMETER> HRM_SYSTEM_NOTIFY_PARAMETER { get; set; }
        public virtual DbSet<HRM_SYSTEM_NOTIFY_TAG> HRM_SYSTEM_NOTIFY_TAG { get; set; }
        public virtual DbSet<HRM_SYSTEM_NOTIFY_TARGET> HRM_SYSTEM_NOTIFY_TARGET { get; set; }
        public virtual DbSet<HRM_SYSTEM_OVERTIME_CONFIG> HRM_SYSTEM_OVERTIME_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_OVERTIME_CONFIG_LOG> HRM_SYSTEM_OVERTIME_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_PAGE_MAPPING> HRM_SYSTEM_PAGE_MAPPING { get; set; }
        public virtual DbSet<HRM_SYSTEM_PARAMETER_MAPPING_MASTER> HRM_SYSTEM_PARAMETER_MAPPING_MASTER { get; set; }
        public virtual DbSet<HRM_SYSTEM_PARAMETER_MAPPING_MASTER_LOG> HRM_SYSTEM_PARAMETER_MAPPING_MASTER_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_REPORT_CONFIG> HRM_SYSTEM_REPORT_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_REPORT_MAPPING> HRM_SYSTEM_REPORT_MAPPING { get; set; }
        public virtual DbSet<HRM_SYSTEM_REPORT_MAPPING_LOG> HRM_SYSTEM_REPORT_MAPPING_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_SALARY_CONFIG> HRM_SYSTEM_SALARY_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_SALARY_CONFIG_LOG> HRM_SYSTEM_SALARY_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_SALARY_SETTING> HRM_SYSTEM_SALARY_SETTING { get; set; }
        public virtual DbSet<HRM_SYSTEM_SALARY_SETTING_DETAIL> HRM_SYSTEM_SALARY_SETTING_DETAIL { get; set; }
        public virtual DbSet<HRM_SYSTEM_SALARY_SETTING_DETAIL_LOG> HRM_SYSTEM_SALARY_SETTING_DETAIL_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_SALARY_SETTING_LOG> HRM_SYSTEM_SALARY_SETTING_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_SERVER_PACKAGE_MAPPING> HRM_SYSTEM_SERVER_PACKAGE_MAPPING { get; set; }
        public virtual DbSet<HRM_SYSTEM_SERVER_PACKAGE_MAPPING_LOG> HRM_SYSTEM_SERVER_PACKAGE_MAPPING_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_TAX_CONFIG> HRM_SYSTEM_TAX_CONFIG { get; set; }
        public virtual DbSet<HRM_SYSTEM_TAX_CONFIG_LOG> HRM_SYSTEM_TAX_CONFIG_LOG { get; set; }
        public virtual DbSet<HRM_SYSTEM_YEAR_HOLIDAY> HRM_SYSTEM_YEAR_HOLIDAY { get; set; }
        public virtual DbSet<HRM_SYSTEM_YEAR_HOLIDAY_LOG> HRM_SYSTEM_YEAR_HOLIDAY_LOG { get; set; }
        public virtual DbSet<HRM_TAX_INSTITUTION> HRM_TAX_INSTITUTION { get; set; }
        public virtual DbSet<HRM_TRAINING_COMPANY> HRM_TRAINING_COMPANY { get; set; }
        public virtual DbSet<HRM_TRAINING_COMPANY_LOG> HRM_TRAINING_COMPANY_LOG { get; set; }
        public virtual DbSet<HRM_TRAINING_COURSE_DATA> HRM_TRAINING_COURSE_DATA { get; set; }
        public virtual DbSet<HRM_TRAINING_COURSE_DATA_LOG> HRM_TRAINING_COURSE_DATA_LOG { get; set; }
        public virtual DbSet<HRM_TRAINING_COURSE_EVALUATE> HRM_TRAINING_COURSE_EVALUATE { get; set; }
        public virtual DbSet<HRM_TRAINING_COURSE_EVALUATE_LOG> HRM_TRAINING_COURSE_EVALUATE_LOG { get; set; }
        public virtual DbSet<HRM_TRAINING_COURSE_TYPE> HRM_TRAINING_COURSE_TYPE { get; set; }
        public virtual DbSet<HRM_TRAINING_COURSE_TYPE_LOG> HRM_TRAINING_COURSE_TYPE_LOG { get; set; }
        public virtual DbSet<HRM_WELFARE_ACCOUNT> HRM_WELFARE_ACCOUNT { get; set; }
        public virtual DbSet<HRM_WELFARE_ACCOUNT_LOG> HRM_WELFARE_ACCOUNT_LOG { get; set; }
        public virtual DbSet<HRM_WELFARE_COMMITTEE> HRM_WELFARE_COMMITTEE { get; set; }
        public virtual DbSet<HRM_WELFARE_COMMITTEE_LOG> HRM_WELFARE_COMMITTEE_LOG { get; set; }
        public virtual DbSet<HRM_WELFARE_WAGE> HRM_WELFARE_WAGE { get; set; }
        public virtual DbSet<HRM_WELFARE_WAGE_LOG> HRM_WELFARE_WAGE_LOG { get; set; }
        public virtual DbSet<HRM_WELFARE_WELCODE> HRM_WELFARE_WELCODE { get; set; }
        public virtual DbSet<HRM_WELFARE_WELCODE_LOG> HRM_WELFARE_WELCODE_LOG { get; set; }
        public virtual DbSet<HRM_WELFARE_YEAR_TAX> HRM_WELFARE_YEAR_TAX { get; set; }
        public virtual DbSet<HRM_WELFARE_YEAR_TAX_LOG> HRM_WELFARE_YEAR_TAX_LOG { get; set; }
        public virtual DbSet<HRM_WORKPLACE> HRM_WORKPLACE { get; set; }
        public virtual DbSet<HRM_WORKPLACE_LOG> HRM_WORKPLACE_LOG { get; set; }
        public virtual DbSet<MAIL_PARAMETER> MAIL_PARAMETER { get; set; }
        public virtual DbSet<MAIL_PARAMETER_LOG> MAIL_PARAMETER_LOG { get; set; }
        public virtual DbSet<MENUCHECKLOG> MENUCHECKLOG { get; set; }
        public virtual DbSet<MENUFAVOR> MENUFAVOR { get; set; }
        public virtual DbSet<MENUITEMTYPE> MENUITEMTYPE { get; set; }
        public virtual DbSet<MENUTABLE> MENUTABLE { get; set; }
        public virtual DbSet<MENUTABLECONTROL> MENUTABLECONTROL { get; set; }
        public virtual DbSet<MENUTABLELOG> MENUTABLELOG { get; set; }
        public virtual DbSet<PunchCardType> PunchCardType { get; set; }
        public virtual DbSet<SYSAUTONUM> SYSAUTONUM { get; set; }
        public virtual DbSet<SYSEEPLOG> SYSEEPLOG { get; set; }
        public virtual DbSet<SYSERRLOG> SYSERRLOG { get; set; }
        public virtual DbSet<SYS_ANYQUERY> SYS_ANYQUERY { get; set; }
        public virtual DbSet<SYS_EXTAPPROVE> SYS_EXTAPPROVE { get; set; }
        public virtual DbSet<SYS_FLDEFINITION> SYS_FLDEFINITION { get; set; }
        public virtual DbSet<SYS_FLINSTANCESTATE> SYS_FLINSTANCESTATE { get; set; }
        public virtual DbSet<SYS_LANGUAGE> SYS_LANGUAGE { get; set; }
        public virtual DbSet<SYS_MESSENGER> SYS_MESSENGER { get; set; }
        public virtual DbSet<SYS_ORG> SYS_ORG { get; set; }
        public virtual DbSet<SYS_ORGKIND> SYS_ORGKIND { get; set; }
        public virtual DbSet<SYS_ORGLEVEL> SYS_ORGLEVEL { get; set; }
        public virtual DbSet<SYS_ORGROLES> SYS_ORGROLES { get; set; }
        public virtual DbSet<SYS_PERSONAL> SYS_PERSONAL { get; set; }
        public virtual DbSet<SYS_REFVAL> SYS_REFVAL { get; set; }
        public virtual DbSet<SYS_REFVAL_D1> SYS_REFVAL_D1 { get; set; }
        public virtual DbSet<SYS_REPORT> SYS_REPORT { get; set; }
        public virtual DbSet<SYS_ROLES_AGENT> SYS_ROLES_AGENT { get; set; }
        public virtual DbSet<SYS_SDALIAS> SYS_SDALIAS { get; set; }
        public virtual DbSet<SYS_SDGROUPS> SYS_SDGROUPS { get; set; }
        public virtual DbSet<SYS_SDQUEUE> SYS_SDQUEUE { get; set; }
        public virtual DbSet<SYS_SDQUEUEPAGE> SYS_SDQUEUEPAGE { get; set; }
        public virtual DbSet<SYS_SDSOLUTIONS> SYS_SDSOLUTIONS { get; set; }
        public virtual DbSet<SYS_SDUSERS> SYS_SDUSERS { get; set; }
        public virtual DbSet<SYS_SDUSERS_LOG> SYS_SDUSERS_LOG { get; set; }
        public virtual DbSet<SYS_TODOHIS> SYS_TODOHIS { get; set; }
        public virtual DbSet<SYS_TODOLIST> SYS_TODOLIST { get; set; }
        public virtual DbSet<SYS_WEBPAGES> SYS_WEBPAGES { get; set; }
        public virtual DbSet<SYS_WEBPAGES_LOG> SYS_WEBPAGES_LOG { get; set; }
        public virtual DbSet<SYS_WEBRUNTIME> SYS_WEBRUNTIME { get; set; }
        public virtual DbSet<USERGROUPS> USERGROUPS { get; set; }
        public virtual DbSet<USERGROUPS_LOG> USERGROUPS_LOG { get; set; }
        public virtual DbSet<USERMENUCONTROL> USERMENUCONTROL { get; set; }
        public virtual DbSet<USERMENUS> USERMENUS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<View_BASE_BASEIO> View_BASE_BASEIO { get; set; }
        public virtual DbSet<View_HRD_SCORE_BEHAVIOR_GROUPSUM> View_HRD_SCORE_BEHAVIOR_GROUPSUM { get; set; }
        public virtual DbSet<View_HRD_SCORE_BEHAVIOR_SUM> View_HRD_SCORE_BEHAVIOR_SUM { get; set; }
        public virtual DbSet<View_HRD_SCORE_FUNCTION_GROUPSUM> View_HRD_SCORE_FUNCTION_GROUPSUM { get; set; }
        public virtual DbSet<View_HRD_SCORE_FUNCTION_SUM> View_HRD_SCORE_FUNCTION_SUM { get; set; }
        public virtual DbSet<View_HRM_ATTEND_OVERTIME_DATA> View_HRM_ATTEND_OVERTIME_DATA { get; set; }
        public virtual DbSet<View_HRM_BASE_BASETTS> View_HRM_BASE_BASETTS { get; set; }
        public virtual DbSet<View_HRM_EMPLOYEE_PARAMETER> View_HRM_EMPLOYEE_PARAMETER { get; set; }
        public virtual DbSet<View_HRM_SALARY_ATTEND_DATA> View_HRM_SALARY_ATTEND_DATA { get; set; }
        public virtual DbSet<View_HRM_SALARY_BASESALARY> View_HRM_SALARY_BASESALARY { get; set; }
        public virtual DbSet<View_HRM_SALARY_BASETTS> View_HRM_SALARY_BASETTS { get; set; }
        public virtual DbSet<View_HRM_SALARY_SALBASE_BASETTS> View_HRM_SALARY_SALBASE_BASETTS { get; set; }
        public virtual DbSet<View_SALARY_SALBASE_BASETTS> View_SALARY_SALBASE_BASETTS { get; set; }
        public virtual DbSet<View_WorkFlowItem> View_WorkFlowItem { get; set; }
        public virtual DbSet<_temp> _temp { get; set; }
        public virtual DbSet<輪班津貼檢核表> 輪班津貼檢核表 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.0.90;Initial Catalog=JBHRIS_DACIN_TEST;Persist Security Info=True;User ID=sa;Password=$dc5168;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting_Configuration>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.SettingItem).HasMaxLength(50);

                entity.Property(e => e.SettingValue).HasMaxLength(50);
            });

            modelBuilder.Entity<COLDEF>(entity =>
            {
                entity.HasKey(e => new { e.TABLE_NAME, e.FIELD_NAME });

                entity.Property(e => e.TABLE_NAME).HasMaxLength(50);

                entity.Property(e => e.FIELD_NAME).HasMaxLength(50);

                entity.Property(e => e.CANREPORT).HasMaxLength(1);

                entity.Property(e => e.CAPTION).HasMaxLength(40);

                entity.Property(e => e.CAPTION1).HasMaxLength(40);

                entity.Property(e => e.CAPTION2).HasMaxLength(40);

                entity.Property(e => e.CAPTION3).HasMaxLength(40);

                entity.Property(e => e.CAPTION4).HasMaxLength(40);

                entity.Property(e => e.CAPTION5).HasMaxLength(40);

                entity.Property(e => e.CAPTION6).HasMaxLength(40);

                entity.Property(e => e.CAPTION7).HasMaxLength(40);

                entity.Property(e => e.CAPTION8).HasMaxLength(40);

                entity.Property(e => e.CHECK_NULL).HasMaxLength(1);

                entity.Property(e => e.DD_NAME).HasMaxLength(40);

                entity.Property(e => e.DEFAULT_VALUE).HasMaxLength(100);

                entity.Property(e => e.EDITMASK).HasMaxLength(10);

                entity.Property(e => e.EXT_MENUID).HasMaxLength(20);

                entity.Property(e => e.FIELD_LENGTH).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.FIELD_SCALE).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.FIELD_TYPE).HasMaxLength(20);

                entity.Property(e => e.IS_KEY)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.NEEDBOX).HasMaxLength(13);

                entity.Property(e => e.QUERYMODE).HasMaxLength(20);

                entity.Property(e => e.SEQ).HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<CardAppDetails>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.APP_RegistryKey).HasMaxLength(50);

                entity.Property(e => e.BSSID).HasMaxLength(50);

                entity.Property(e => e.CardProcess).HasColumnType("datetime");

                entity.Property(e => e.CardSend).HasColumnType("datetime");

                entity.Property(e => e.CardStart).HasColumnType("datetime");

                entity.Property(e => e.CardTypeCode).HasMaxLength(50);

                entity.Property(e => e.IP_Address).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.MAC).HasMaxLength(50);

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.SSID).HasMaxLength(50);
            });

            modelBuilder.Entity<CardAppImages>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmpConfiguration>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.SettingItem).HasMaxLength(50);

                entity.Property(e => e.SettingValue).HasMaxLength(50);
            });

            modelBuilder.Entity<FencePoints>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.PointsGroup).IsUnicode(false);
            });

            modelBuilder.Entity<GROUPMENUCONTROL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ALLOWADD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWDELETE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWPRINT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWUPDATE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CONTROLNAME)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ENABLED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VISIBLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GROUPMENUS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GROUPS>(entity =>
            {
                entity.HasKey(e => e.GROUPID);

                entity.Property(e => e.GROUPID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(200);

                entity.Property(e => e.GROUPNAME).HasMaxLength(50);

                entity.Property(e => e.ISROLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MSAD).HasMaxLength(1);
            });

            modelBuilder.Entity<GROUPS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(200);

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GROUPNAME).HasMaxLength(50);

                entity.Property(e => e.ISROLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MSAD).HasMaxLength(1);
            });

            modelBuilder.Entity<HRD_BASE_BASE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ID)
                    .HasName("PK_HRD_BASE_BASETTS");

                entity.Property(e => e.EMPLOYEE_ID).HasComment("Key");

                entity.Property(e => e.COMPANY_MAIL)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司MAIL");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_CNAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工編號");

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.JOB_CNAME).HasMaxLength(50);

                entity.Property(e => e.NAME_C)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工姓名");

                entity.Property(e => e.NAME_E)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("英文名稱");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_BASE_BASE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.COMPANY_MAIL)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司MAIL");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_CNAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工編號");

                entity.Property(e => e.EMPLOYEE_ID).HasComment("Key");

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.JOB_CNAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NAME_C)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工姓名");

                entity.Property(e => e.NAME_E)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("英文名稱");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_COMPANY>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_NAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_COMPANY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.COMPANY_NAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM>(entity =>
            {
                entity.HasKey(e => e.FORM_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FORM_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.FORM_NAME).HasMaxLength(50);

                entity.Property(e => e.GUIDE_BEHAVIOR).HasMaxLength(200);

                entity.Property(e => e.GUIDE_OPENENDED).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_BEHAVIOR>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.FUNCTION_ID, e.BEHAVIOR_ID })
                    .HasName("PK_HRD_FORM_BEHAVIOR_1");

                entity.Property(e => e.BEHAVIOR_CONTENT).HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_BEHAVIOR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.BEHAVIOR_CONTENT).HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_FUNCTION>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.FUNCTION_ID })
                    .HasName("PK_HRD_FORM_FUNCTION_1");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_FUNCTION_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_GROUP>(entity =>
            {
                entity.HasKey(e => e.GROUP_ID)
                    .HasName("PK_HRD_PROJECT_GROUP");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_GROUP_EMPLOYEE>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.EMPLOYEE_ID })
                    .HasName("PK_HRD_FORM_GROUP_EMPLOYEE_1");

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_GROUP_EMPLOYEE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_GROUP_EVALUATION>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.EMPLOYEE_ID, e.EVALUATION_EMPLOYEE_ID })
                    .HasName("PK_HRD_FORM_GROUP_EVALUATION_1");

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_GROUP_EVALUATION_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_GROUP_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRD_PROJECT_GROUP_LOG");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_NAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FORM_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.FORM_NAME).HasMaxLength(50);

                entity.Property(e => e.GUIDE_BEHAVIOR).HasMaxLength(200);

                entity.Property(e => e.GUIDE_OPENENDED).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_OPENENDED>(entity =>
            {
                entity.HasKey(e => e.QUIZ_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_REQUIRED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QUIZ_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.QUIZ_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_OPENENDED_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_REQUIRED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.QUIZ_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.QUIZ_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_WEIGHT>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.RELATION_ID });

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FORM_WEIGHT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FUNCTION>(entity =>
            {
                entity.HasKey(e => e.FUNCTION_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FUNCTION_DEFINE).HasMaxLength(100);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FUNCTION_BEHAVIOR>(entity =>
            {
                entity.HasKey(e => e.BEHAVIOR_ID);

                entity.Property(e => e.BEHAVIOR_CONTENT).HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FUNCTION_BEHAVIOR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.BEHAVIOR_CONTENT).HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FUNCTION_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FUNCTION_DEFINE).HasMaxLength(10);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FUNCTION_SUGGEST>(entity =>
            {
                entity.HasKey(e => e.SUGGEST_ID)
                    .HasName("PK_HRD_SUGGEST");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SUGGEST_CONTENT).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_FUNCTION_SUGGEST_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SUGGEST_CONTENT).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_INDUSTRY>(entity =>
            {
                entity.HasKey(e => e.INDUSTRY_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INDUSTRY_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_INDUSTRY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INDUSTRY_NAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_PROJECT>(entity =>
            {
                entity.HasKey(e => e.PROJECT_ID);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.PROJECT_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.PROJECT_NAME).HasMaxLength(50);

                entity.Property(e => e.PROJECT_STATUS).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_PROJECT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PROJECT_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.PROJECT_NAME).HasMaxLength(50);

                entity.Property(e => e.PROJECT_STATUS).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCALE>(entity =>
            {
                entity.HasKey(e => e.SCALE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SCALE_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.SCALE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCALE_ITEM>(entity =>
            {
                entity.HasKey(e => e.ITEM_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.ITEM_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.ITEM_NAME).HasMaxLength(50);

                entity.Property(e => e.SCALE_ITEM_COMMENT).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCALE_ITEM_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRD_SCALE_LOG");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.ITEM_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.ITEM_NAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SCALE_ITEM_COMMENT).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCALE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRD_SCALE_LOG_1");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SCALE_EXPLAIN).HasMaxLength(100);

                entity.Property(e => e.SCALE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCORE_BEHAVIOR>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.FUNCTION_ID, e.BEHAVIOR_ID, e.EMPLOYEE_ID, e.EVALUATION_EMPLOYEE_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCORE_BEHAVIOR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCORE_FUNCTION>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.FUNCTION_ID, e.EMPLOYEE_ID, e.EVALUATION_EMPLOYEE_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCORE_FUNCTION_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCORE_OPENENDED>(entity =>
            {
                entity.HasKey(e => new { e.FORM_ID, e.QUIZ_ID, e.EMPLOYEE_ID, e.EVALUATION_EMPLOYEE_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SCORE_OPENENDED_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATION_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.QUIZ_ANSWER).HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SHARECODE>(entity =>
            {
                entity.HasKey(e => new { e.FIELDNAME, e.CODE });

                entity.Property(e => e.FIELDNAME).HasMaxLength(50);

                entity.Property(e => e.CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_ACTIVE).HasMaxLength(50);

                entity.Property(e => e.NAME).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SUGGEST_TYPE>(entity =>
            {
                entity.HasKey(e => e.SUGGEST_TYPE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SUGGEST_TYPE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_SUGGEST_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SUGGEST_TYPE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_WEIGHT>(entity =>
            {
                entity.HasKey(e => e.RELATION_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_SELF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RELATION_NAME).HasMaxLength(10);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_WEIGHT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_SELF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RELATION_NAME).HasMaxLength(10);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ADDRESS>(entity =>
            {
                entity.HasIndex(e => new { e.CITY_CODE, e.COUNTRY_CODE })
                    .HasName("IDX_CITY_CODE");

                entity.Property(e => e.CITY)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.COUNTRY)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MAIL_CODE)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ROAD)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<HRM_ALTERATION_CAUSE>(entity =>
            {
                entity.HasKey(e => e.ALTERATION_CAUSE_ID);

                entity.HasIndex(e => e.ALTERATION_CAUSE_CODE)
                    .HasName("IDX_ALTERATION_CAUSE_CODE");

                entity.Property(e => e.ALTERATION_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.ALTERATION_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.ALTERATION_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ALTERATION_CAUSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ALTERATION_CAUSE_ID)
                    .HasName("IDX_ALTERATION_CAUSE_ID");

                entity.Property(e => e.ALTERATION_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.ALTERATION_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.ALTERATION_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_CANCEL_FLOW>(entity =>
            {
                entity.HasKey(e => e.ABSENT_CANCEL_NO);

                entity.Property(e => e.ABSENT_CANCEL_NO).HasMaxLength(50);

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CANCEL_REASON).HasMaxLength(300);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FLOW_MEMO).HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_CANCEL_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ABSENT_CANCEL_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CANCEL_REASON).HasMaxLength(300);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FLOW_MEMO).HasMaxLength(500);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_CANCEL_MINUS>(entity =>
            {
                entity.HasKey(e => e.ABSENT_MINUS_ID);

                entity.Property(e => e.ABSENT_MINUS_ID).ValueGeneratedNever();

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_NO).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_CANCEL_MINUS_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ABSENT_MINUS_ID, e.EMPLOYEE_ID, e.ABSENT_DATE, e.HOLIDAY_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_CREATE>(entity =>
            {
                entity.HasKey(e => e.ABSENT_CREATE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE, e.END_DATE })
                    .HasName("IDX_EMPLOYEEID_BEGIN_END_DATE");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_MINUS_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_CREATE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ABSENT_CREATE_ID)
                    .HasName("IDX_ABSENT_CREATE_ID");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_MINUS_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE>(entity =>
            {
                entity.HasKey(e => e.ABSENT_LEAVE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE })
                    .HasName("IDX_BEGIN_EMPLOYEE_ID");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE, e.END_DATE })
                    .HasName("IDX_EMPLOYEEID_BEGIN_END_DATE");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_NO).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_DETAIL>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ABSENT_LEAVE_ID)
                    .HasName("IDX_ABSENT_LEAVE_ID");

                entity.HasIndex(e => new { e.ABSENT_DATE, e.EMPLOYEE_ID })
                    .HasName("IDX_ABSENT_DATE");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.ABSENT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_FILE>(entity =>
            {
                entity.HasKey(e => e.ABSENT_LEAVE_FILE_ID);

                entity.HasIndex(e => e.ABSENT_LEAVE_ID)
                    .HasName("IDX_ABSENT_LEAVE_ID");

                entity.Property(e => e.ABSENT_LEAVE_FILE).HasMaxLength(200);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_FILE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ABSENT_LEAVE_FILE_ID)
                    .HasName("IDX_ABSENT_LEAVE_FILE_ID");

                entity.Property(e => e.ABSENT_LEAVE_FILE).HasMaxLength(200);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_FLOW>(entity =>
            {
                entity.HasKey(e => e.ABSENT_LEAVE_NO);

                entity.Property(e => e.ABSENT_LEAVE_NO).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AGENT_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.AGENT_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FLOW_MEMO).HasMaxLength(500);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_FLOW_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ABSENT_LEAVE_ID, e.EMPLOYEE_ID, e.ABSENT_DATE, e.HOLIDAY_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_ATTEND_ABSENT_LEAVE_FLOW_LOG_1");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ABSENT_LEAVE_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AGENT_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.AGENT_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_LEAVE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ABSENT_LEAVE_ID)
                    .HasName("IDX_ABSENT_LEAVE_ID");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_NO).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS>(entity =>
            {
                entity.HasKey(e => e.ABSENT_MINUS_ID)
                    .HasName("PK_HRM_ATTEND_ABSENT_DATA");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE, e.END_DATE })
                    .HasName("IDX_EMPLOYEEID_BEGIN_END_DATE");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_NO).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ABSENT_MINUS_ID, e.EMPLOYEE_ID, e.ABSENT_DATE, e.HOLIDAY_ID });

                entity.HasIndex(e => new { e.ABSENT_DATE, e.EMPLOYEE_ID })
                    .HasName("idx_absentdate_employeeid_");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.ABSENT_DATE })
                    .HasName("idx_employeeid_absentdate");

                entity.HasIndex(e => new { e.ABSENT_MINUS_ID, e.EMPLOYEE_ID, e.ABSENT_DATE })
                    .HasName("idx_employeeID");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_DETAIL_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_FILE>(entity =>
            {
                entity.HasKey(e => e.ABSENT_MINUS_FILE_ID);

                entity.HasIndex(e => e.ABSENT_MINUS_ID)
                    .HasName("IDX_ABSENT_MINUS_ID");

                entity.Property(e => e.ABSENT_MINUS_FILE).HasMaxLength(200);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_FILE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ABSENT_MINUS_ID)
                    .HasName("IDX_ABSENT_MINUS_ID");

                entity.Property(e => e.ABSENT_MINUS_FILE).HasMaxLength(200);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_FLOW>(entity =>
            {
                entity.HasKey(e => e.ABSENT_MINUS_NO)
                    .HasName("PK_HRM_ATTEND_ABSENT_MINUS_FLOW_1");

                entity.Property(e => e.ABSENT_MINUS_NO).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AGENT_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.AGENT_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FILE_NAME).HasMaxLength(50);

                entity.Property(e => e.FILE_PATH).HasMaxLength(100);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FLOW_MEMO).HasMaxLength(500);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_FLOW_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ABSENT_MINUS_ID, e.EMPLOYEE_ID, e.ABSENT_DATE, e.HOLIDAY_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ABSENT_MINUS_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AGENT_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.AGENT_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FILE_NAME).HasMaxLength(50);

                entity.Property(e => e.FILE_PATH).HasMaxLength(100);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_MINUS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_ATTEND_ABSENT_DATA_LOG");

                entity.HasIndex(e => e.ABSENT_MINUS_ID)
                    .HasName("IDX_ABSENT_MINUS_ID");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_NO).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_PLUS>(entity =>
            {
                entity.HasKey(e => e.ABSENT_PLUS_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE, e.END_DATE })
                    .HasName("IDX_EMPLOYEEID_BEGIN_END_DATE");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ABSENT_PLUS_NO).HasMaxLength(50);

                entity.Property(e => e.ABSENT_PLUS_TYPE).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_PLUS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ABSENT_PLUS_ID)
                    .HasName("IDX_ABSENT_PLUS_ID");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ABSENT_PLUS_NO).HasMaxLength(50);

                entity.Property(e => e.ABSENT_PLUS_TYPE).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ABSENT_TRANS>(entity =>
            {
                entity.HasKey(e => e.ABSENT_TRANS_ID);

                entity.HasIndex(e => e.ABSENT_MINUS_ID)
                    .HasName("IDX_ABSENT_MINUS_ID");

                entity.HasIndex(e => e.ABSENT_PLUS_ID)
                    .HasName("IDX_ABSENT_PLUS_ID");

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ABSENT_MINUS_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_PLUS_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND>(entity =>
            {
                entity.HasKey(e => e.ATTEND_ID);

                entity.HasIndex(e => new { e.ATTEND_DATE, e.EMPLOYEE_ID })
                    .HasName("idx_attend_date");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.ATTEND_DATE })
                    .HasName("idx_employeeID");

                entity.Property(e => e.ABSENT_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACTUAL_ATTEND_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EARLY_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_ABSENT).HasMaxLength(50);

                entity.Property(e => e.LATE_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_CARD>(entity =>
            {
                entity.HasKey(e => e.ATTEND_CARD_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.CARD_DATE })
                    .HasName("idx_employeeID");

                entity.Property(e => e.CARD_DATE).HasColumnType("date");

                entity.Property(e => e.CARD_DATE_TIME_OFF_1).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_2)
                    .HasColumnType("datetime")
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.CARD_DATE_TIME_OFF_3).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_4).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_5).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_1).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_2)
                    .HasColumnType("datetime")
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.CARD_DATE_TIME_ON_3).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_4).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_5).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_1).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_2)
                    .HasMaxLength(50)
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.OFF_TIME_3).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_4).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_5).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_1).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_2).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_3).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_4).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_5).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_1).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_2)
                    .HasMaxLength(50)
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.ON_TIME_3).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_4).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_5).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_1).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_2).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_3).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_4).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_5).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_CARD_HOTA>(entity =>
            {
                entity.HasKey(e => e.ATTEND_CARD_HOTA_ID);

                entity.HasIndex(e => e.ATTEND_CARD_ID)
                    .HasName("IX_HRM_ATTEND_ATTEND_CARD_HOTA");

                entity.Property(e => e.OFF_TIME_NOT_TEMP_CARD)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N')");

                entity.Property(e => e.ON_TIME_NOT_TEMP_CARD)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'N')");
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_CARD_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ATTEND_CARD_ID)
                    .HasName("IDX_ATTEND_CARD_ID");

                entity.Property(e => e.CARD_DATE).HasColumnType("date");

                entity.Property(e => e.CARD_DATE_TIME_OFF_1).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_2).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_3).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_4).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_5).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_1).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_2).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_3).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_4).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_5).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_1).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_2).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_3).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_4).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_5).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_1).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_2).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_3).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_4).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET_5).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_1).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_2).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_3).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_4).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_5).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_1).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_2).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_3).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_4).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET_5).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_DETAIL>(entity =>
            {
                entity.HasKey(e => e.ATTEND_WORK_ID)
                    .HasName("PK_HRM_ATTEND_ATTEND_DETAIL_DETAIL");

                entity.HasIndex(e => e.ATTEND_ID)
                    .HasName("IDX_ATTEND_ID");

                entity.Property(e => e.ACTUAL_ATTEND_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EARLY_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FORGET_CARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_ABSENT).HasMaxLength(50);

                entity.Property(e => e.LATE_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_ATTEND_ATTEND_DETAIL_DETAIL_LOG");

                entity.HasIndex(e => e.ATTEND_WORK_ID)
                    .HasName("IDX_ATTEND_WORK_ID");

                entity.Property(e => e.ACTUAL_ATTEND_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EARLY_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FORGET_CARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_ABSENT).HasMaxLength(50);

                entity.Property(e => e.LATE_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_HOTA>(entity =>
            {
                entity.HasKey(e => e.ATTEND_HOTA_ID);

                entity.HasIndex(e => e.ATTEND_ID)
                    .HasName("IDX_ATTEND_ID");

                entity.Property(e => e.NOT_TEMP_CARD_CNT).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ATTEND_ID)
                    .HasName("IDX_ATTEND_ID");

                entity.Property(e => e.ABSENT_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACTUAL_ATTEND_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EARLY_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_ABSENT).HasMaxLength(50);

                entity.Property(e => e.LATE_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_BASETTS>(entity =>
            {
                entity.HasKey(e => e.ATTEND_BASETTS_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ATTEND_BASETTS_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_BASETTS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ATTEND_BASETTS_ID)
                    .HasName("IX_ATTEND_BASETTS_ID");

                entity.Property(e => e.ATTEND_BASETTS_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_BIRTHDAY_HOLIDAY>(entity =>
            {
                entity.HasKey(e => e.BIRTHDAY_HOLIDAY_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BIRTHDAY_YEAR, e.BEGIN_DATE, e.END_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BIRTHDAY).HasColumnType("datetime");

                entity.Property(e => e.BIRTHDAY_YEAR).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_BIRTHDAY_HOLIDAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BIRTHDAY_HOLIDAY_ID)
                    .HasName("IDX_BIRTHDAY_HOLIDAY_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BIRTHDAY).HasColumnType("datetime");

                entity.Property(e => e.BIRTHDAY_YEAR).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CALENDAR>(entity =>
            {
                entity.HasKey(e => e.CALENDAR_ID);

                entity.HasIndex(e => e.CALENDAR_CODE)
                    .HasName("IDX_CALENDAR_CODE");

                entity.Property(e => e.CALENDAR_CNAME).HasMaxLength(50);

                entity.Property(e => e.CALENDAR_CODE).HasMaxLength(50);

                entity.Property(e => e.CALENDAR_ENAME).HasMaxLength(50);

                entity.Property(e => e.CHECK_ROTE_TYPE).HasMaxLength(10);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEEKLY_CYCLE_BASE).HasMaxLength(10);
            });

            modelBuilder.Entity<HRM_ATTEND_CALENDAR_HOLIDAY>(entity =>
            {
                entity.HasKey(e => e.CALENDAR_HOLIDAY_ID);

                entity.Property(e => e.CALENDAR_HOLIDAY_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CALENDAR_HOLIDAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CALENDAR_HOLIDAY_ID)
                    .HasName("IDX_CALENDAR_HOLIDAY_ID");

                entity.Property(e => e.CALENDAR_HOLIDAY_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CALENDAR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CALENDAR_ID)
                    .HasName("IDX_CALENDAR_ID");

                entity.Property(e => e.CALENDAR_CNAME).HasMaxLength(50);

                entity.Property(e => e.CALENDAR_CODE).HasMaxLength(50);

                entity.Property(e => e.CALENDAR_ENAME).HasMaxLength(50);

                entity.Property(e => e.CHECK_ROTE_TYPE).HasMaxLength(10);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEEKLY_CYCLE_BASE).HasMaxLength(10);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_CLOCKIN>(entity =>
            {
                entity.HasKey(e => e.CARD_CLOCKIN_ID);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.LATITUDE).HasMaxLength(50);

                entity.Property(e => e.LONGITUDE).HasMaxLength(50);

                entity.Property(e => e.USERID).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_COLLECT_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.CARD_COLLECT_CODE, e.COLLECT_CODE });

                entity.Property(e => e.CARD_COLLECT_CODE).HasMaxLength(50);

                entity.Property(e => e.COLLECT_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FORMAT).HasMaxLength(50);

                entity.Property(e => e.IGNORE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_COLLECT_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.CARD_COLLECT_CODE, e.COLLECT_CODE })
                    .HasName("IDX_CARD_COLLECT_CODE");

                entity.Property(e => e.CARD_COLLECT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COLLECT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FORMAT).HasMaxLength(50);

                entity.Property(e => e.IGNORE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_COLLECT_MASTER>(entity =>
            {
                entity.HasKey(e => e.CARD_COLLECT_CODE)
                    .HasName("PK_HRM_ATTEND_CARD_COLLECT_MASTER_1");

                entity.Property(e => e.CARD_COLLECT_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_TYPE).HasMaxLength(50);

                entity.Property(e => e.SPLIT_SIGNAL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_COLLECT_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CARD_COLLECT_CODE)
                    .HasName("IDX_CARD_COLLECT_CODE");

                entity.Property(e => e.CARD_COLLECT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SPLIT_SIGNAL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_COLLECT_RESULT>(entity =>
            {
                entity.HasKey(e => e.COLLECT_RESULT_ID);

                entity.Property(e => e.CARD_CONTENT).HasMaxLength(200);

                entity.Property(e => e.IMPORT_TYPE).HasMaxLength(200);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_DATA>(entity =>
            {
                entity.HasKey(e => e.CARD_DATA_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.CARD_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).HasMaxLength(50);

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.IS_FORGET_CARD).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_TRAN).HasMaxLength(50);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_DATA_FLOW>(entity =>
            {
                entity.HasKey(e => e.CARD_DATA_ID);

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.CARD_DATA_NO)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).HasMaxLength(50);

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.IS_FORGET_CARD).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_TRAN).HasMaxLength(50);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_DATA_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).HasMaxLength(50);

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.IS_FORGET_CARD).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_TRAN).HasMaxLength(50);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CARD_DATA_ID)
                    .HasName("IDX_CARD_DATA_ID");

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).HasMaxLength(50);

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.IS_FORGET_CARD).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_TRAN).HasMaxLength(50);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_DATA_TEMP>(entity =>
            {
                entity.HasKey(e => e.CARD_DATA_ID);

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).HasMaxLength(50);

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.IS_FORGET_CARD).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_TRAN).HasMaxLength(50);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_MACHINE>(entity =>
            {
                entity.HasKey(e => e.CARD_MACHINE_ID);

                entity.Property(e => e.CARD_DATE_FORMAT).HasMaxLength(50);

                entity.Property(e => e.CARD_MACHINE_NAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IGNORE_SIGNAL).HasMaxLength(50);

                entity.Property(e => e.SEPARATE_SIGNAL).HasMaxLength(50);

                entity.Property(e => e.TEXT_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_MACHINE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CARD_MACHINE_ID)
                    .HasName("IDX_CARD_MACHINE_ID");

                entity.Property(e => e.CARD_DATE_FORMAT).HasMaxLength(50);

                entity.Property(e => e.CARD_MACHINE_NAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IGNORE_SIGNAL).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SEPARATE_SIGNAL).HasMaxLength(50);

                entity.Property(e => e.TEXT_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_SOURCE>(entity =>
            {
                entity.HasKey(e => e.SOURCE_CODE);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SOURCE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_SOURCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SOURCE_CODE)
                    .HasName("IDX_SOURCE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SOURCE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CREATE_CARD_DATA>(entity =>
            {
                entity.HasKey(e => e.CREATE_CARD_DATA_ID);

                entity.Property(e => e.CREATE_CARD_DATA_ID).ValueGeneratedNever();

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ID).HasMaxLength(256);

                entity.Property(e => e.DEPT_TEXT).HasMaxLength(512);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(256);

                entity.Property(e => e.EMPLOYEE_TEXT).HasMaxLength(512);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.ROTE_ID).HasMaxLength(256);

                entity.Property(e => e.ROTE_TEXT).HasMaxLength(512);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_DATA_LOCK>(entity =>
            {
                entity.HasKey(e => e.DATA_LOCK_ID);

                entity.HasIndex(e => e.ATTEND_DATE)
                    .HasName("IDX_ATTEND_DATE");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_DATA_LOCK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.DATA_LOCK_ID)
                    .HasName("IDX_DATA_LOCK_ID");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_EMPLOYEE_CARD>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_CARD_ID);

                entity.HasIndex(e => new { e.CARD_NO, e.EFFECT_DATE })
                    .HasName("IDX_CARD_NO");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_TEMPORARY).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_EMPLOYEE_CARD_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_CARD_ID)
                    .HasName("IDX_EMPLOYEE_CARD_ID");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_TEMPORARY).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ESTIMATE_OVERTIME_DATA>(entity =>
            {
                entity.HasKey(e => e.ESTIMATE_OVERTIME_ID);

                entity.HasIndex(e => e.OVERTIME_DATE)
                    .HasName("IDX_OVERTIME_DATE");

                entity.HasIndex(e => e.SALARY_YYMM)
                    .HasName("IDX_OVERTIME_SALARY_YYMM");

                entity.HasIndex(e => e.UPDATE_DATE)
                    .HasName("IDX_UPDATE_DATE");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.OVERTIME_DATE })
                    .HasName("idx_employeeID");

                entity.Property(e => e.ACTUAL_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.ACTUAL_END_TIME).HasMaxLength(50);

                entity.Property(e => e.ACTUAL_OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACTUAL_REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CHECK_OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CHECK_REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.ERROR_MESSAGE).HasMaxLength(250);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.IS_SUCCESS).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ESTIMATE_OVERTIME_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ESTIMATE_OVERTIME_ID)
                    .HasName("IDX_ESTIMATE_OVERTIME_ID");

                entity.Property(e => e.ACTUAL_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.ACTUAL_END_TIME).HasMaxLength(50);

                entity.Property(e => e.ACTUAL_OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACTUAL_REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CHECK_OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CHECK_REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.ERROR_MESSAGE).HasMaxLength(250);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.IS_SUCCESS).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_FLOW_LOCK>(entity =>
            {
                entity.HasKey(e => e.ATTEND_YYMM)
                    .HasName("PK_HRM_SALARY_FLOW_LOCK");

                entity.Property(e => e.ATTEND_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_FLOW_LOCK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_SALARY_FLOW_LOCK_LOG");

                entity.Property(e => e.ATTEND_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_FORGET_CARD_CAUSE>(entity =>
            {
                entity.HasKey(e => e.FORGET_CARD_CAUSE_ID)
                    .HasName("PK_HRM_ATTEND_FORGET_CARD");

                entity.HasIndex(e => e.FORGET_CARD_CAUSE_CODE)
                    .HasName("IDX_FORGET_CARD_CAUSE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_FULL_ATTEND).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.NOT_TEMP_CARD).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_FORGET_CARD_CAUSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_ATTEND_FORGET_CARD_LOG");

                entity.HasIndex(e => e.FORGET_CARD_CAUSE_ID)
                    .HasName("IDX_FORGET_CARD_CAUSE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_FULL_ATTEND).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOT_TEMP_CARD).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_GROUP_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ATTEND_GROUP_MASTER_ID, e.GROUP_PARAMETER_CODE });

                entity.Property(e => e.GROUP_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_GROUP_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.ATTEND_GROUP_MASTER_ID, e.GROUP_PARAMETER_CODE })
                    .HasName("IDX_ATTEND_GROUP_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_PARAMETER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_GROUP_MASTER>(entity =>
            {
                entity.HasKey(e => e.ATTEND_GROUP_MASTER_ID);

                entity.HasIndex(e => e.GROUP_MASTER_CODE)
                    .HasName("IDX_GROUP_MASTER_CODE");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("date");

                entity.Property(e => e.GROUP_MASTER_CNAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GROUP_MASTER_ENAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_SEQ).HasDefaultValueSql("((0))");

                entity.Property(e => e.IS_GROUP)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_GROUP_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ATTEND_GROUP_MASTER_ID)
                    .HasName("IDX_ATTEND_GROUP_MASTER_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("date");

                entity.Property(e => e.GROUP_MASTER_CNAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GROUP_MASTER_ENAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_SEQ).HasDefaultValueSql("((0))");

                entity.Property(e => e.IS_GROUP)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_GROUP_PARAMETER>(entity =>
            {
                entity.HasKey(e => e.GROUP_PARAMETER_CODE);

                entity.Property(e => e.GROUP_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.DEFAULT_VALUE).HasMaxLength(50);

                entity.Property(e => e.GROUP_PARAMETER_CNAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_PARAMETER_ENAME).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.VALIDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_ID);

                entity.HasIndex(e => e.HOLIDAY_CODE)
                    .HasName("IDX_HOLIDAY_CODE");

                entity.Property(e => e.ABSENT_REASON).HasMaxLength(50);

                entity.Property(e => e.ABSENT_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.AGENT_LIMIT).HasMaxLength(50);

                entity.Property(e => e.ALLOW_CREATE_ABSENT).HasMaxLength(50);

                entity.Property(e => e.ALLOW_MANUAL).HasMaxLength(50);

                entity.Property(e => e.APPLY_LIMIT_TIME).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.APPLY_LIMIT_TYPE).HasMaxLength(50);

                entity.Property(e => e.AUTO_CREATE).HasMaxLength(50);

                entity.Property(e => e.AUTO_DISPATCH).HasMaxLength(50);

                entity.Property(e => e.CALCULATE_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.CHECK_REST_HOUR).HasMaxLength(1);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_FOOD).HasMaxLength(1);

                entity.Property(e => e.EFFECT_FULL_ATTEND).HasMaxLength(50);

                entity.Property(e => e.EFFECT_SHIFT).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_CNAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_CODE).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_ENAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_FLAG).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_UNIT).HasMaxLength(50);

                entity.Property(e => e.INCLUDE_HOLIDAY).HasMaxLength(1);

                entity.Property(e => e.IS_DISPLAY).HasMaxLength(50);

                entity.Property(e => e.IS_DOCUMENT).HasMaxLength(50);

                entity.Property(e => e.MAX_NUM).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.MIN_NUM).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_PRINT).HasMaxLength(50);

                entity.Property(e => e.NOT_SUM).HasMaxLength(1);

                entity.Property(e => e.SEX).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CALCULATE).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_KIND>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_KIND_ID);

                entity.HasIndex(e => e.HOLIDAY_KIND_CODE)
                    .HasName("IDX_HOLIDAY_KIND_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_KIND_CNAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_KIND_CODE).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_KIND_ENAME).HasMaxLength(50);

                entity.Property(e => e.UNIT).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_KIND_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIDAY_KIND_ID)
                    .HasName("IDX_HOLIDAY_KIND_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_KIND_CNAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_KIND_CODE).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_KIND_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UNIT).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIDAY_ID)
                    .HasName("IDX_HOLIDAY_ID");

                entity.Property(e => e.ABSENT_REASON).HasMaxLength(50);

                entity.Property(e => e.ABSENT_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.AGENT_LIMIT).HasMaxLength(50);

                entity.Property(e => e.ALLOW_CREATE_ABSENT).HasMaxLength(50);

                entity.Property(e => e.ALLOW_MANUAL).HasMaxLength(50);

                entity.Property(e => e.APPLY_LIMIT_DAY).HasMaxLength(50);

                entity.Property(e => e.APPLY_LIMIT_TIME).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.APPLY_LIMIT_TYPE).HasMaxLength(50);

                entity.Property(e => e.AUTO_CREATE).HasMaxLength(50);

                entity.Property(e => e.AUTO_DISPATCH).HasMaxLength(50);

                entity.Property(e => e.CALCULATE_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.CHECK_REST_HOUR).HasMaxLength(1);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_FOOD).HasMaxLength(1);

                entity.Property(e => e.EFFECT_FULL_ATTEND).HasMaxLength(50);

                entity.Property(e => e.EFFECT_SHIFT).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_CNAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_CODE).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_ENAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_FLAG).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_UNIT).HasMaxLength(50);

                entity.Property(e => e.INCLUDE_HOLIDAY).HasMaxLength(1);

                entity.Property(e => e.IS_DISPLAY).HasMaxLength(50);

                entity.Property(e => e.IS_DOCUMENT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MAX_NUM).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.MIN_NUM).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_PRINT).HasMaxLength(50);

                entity.Property(e => e.NOT_SUM).HasMaxLength(1);

                entity.Property(e => e.SEX).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CALCULATE).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_OVERTIME_DATA>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_OVERTIME_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.OVERTIME_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_OVERTIME_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIDAY_OVERTIME_ID)
                    .HasName("IDX_HOLIDAY_OVERTIME_ID");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_OVERTIME_RATE>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_OVERTIME_RATE_ID);

                entity.HasIndex(e => new { e.ADATE, e.CALENDAR_ID, e.HOLIDAY_TYPE_ID, e.ROTE_ID, e.OVERTIME_RATE_ID })
                    .HasName("IDX_ADATE");

                entity.Property(e => e.ADATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_OVERTIME_RATE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIDAY_OVERTIME_RATE_ID)
                    .HasName("IDX_HOLIDAY_OVERTIME_RATE_ID");

                entity.Property(e => e.ADATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_ROTE_CHANGE>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_ROTE_CHANGE_ID);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.HOLIDAY_ROTE_DATE });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_ROTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_ROTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_ROTE_CHANGE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_ROTE_FIND>(entity =>
            {
                entity.HasKey(e => e.FIND_TYPE);

                entity.Property(e => e.FIND_TYPE).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FIND_ISUSE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_ROTE_FIND_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FIND_ISUSE)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_SALARY>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_SALARY_ID);

                entity.HasIndex(e => new { e.HOLIDAY_ID, e.SALARY_ID })
                    .HasName("IDX_HOLIDAY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_SALARY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIDAY_SALARY_ID)
                    .HasName("IDX_HOLIDAY_SALARY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_TYPE>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_TYPE_ID);

                entity.HasIndex(e => e.HOLIDAY_TYPE_CODE)
                    .HasName("IDX_HOLIDAY_TYPE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_COLOR).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.NATIONAL_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.NORMAL_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.REST_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.ROTEMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIDAY_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIDAY_TYPE_ID)
                    .HasName("IDX_HOLIDAY_TYPE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_COLOR).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NATIONAL_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.NORMAL_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.REST_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.ROTEMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIMAPPING_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.HOLIMAPPING_CODE, e.HOLIDAY_ID });

                entity.Property(e => e.HOLIMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIMAPPING_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIMAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIMAPPING_MASTER>(entity =>
            {
                entity.HasKey(e => e.HOLIMAPPING_CODE);

                entity.Property(e => e.HOLIMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIMAPPING_TITLE).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_HOLIMAPPING_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HOLIMAPPING_CODE)
                    .HasName("IDX_HOLIMAPPING_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIMAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HOLIMAPPING_TITLE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_LEAVE_CANCEL_FLOW>(entity =>
            {
                entity.HasKey(e => e.LEAVE_CANCEL_NO);

                entity.Property(e => e.LEAVE_CANCEL_NO).HasMaxLength(50);

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CANCEL_REASON).HasMaxLength(300);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FLOW_MEMO).HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_LEAVE_CANCEL_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.APPLICATE_ROLE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.APPLICATE_USER)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CANCEL_REASON).HasMaxLength(300);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.FLOW_MEMO).HasMaxLength(500);

                entity.Property(e => e.LEAVE_CANCEL_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_LEAVE_CANCEL_MINUS>(entity =>
            {
                entity.HasKey(e => e.ABSENT_LEAVE_ID);

                entity.Property(e => e.ABSENT_LEAVE_ID).ValueGeneratedNever();

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_NO).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_LEAVE_CANCEL_MINUS_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ABSENT_LEAVE_ID, e.EMPLOYEE_ID, e.ABSENT_DATE, e.HOLIDAY_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_MANAGER_PLUS>(entity =>
            {
                entity.HasKey(e => e.MANAGER_PLUS_ID);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.PTO_DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PTO_MONTH).HasMaxLength(50);

                entity.Property(e => e.PTO_YEARS).HasMaxLength(50);

                entity.Property(e => e.UNIT).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_MANAGER_PLUS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.PTO_DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PTO_MONTH).HasMaxLength(50);

                entity.Property(e => e.PTO_YEARS).HasMaxLength(50);

                entity.Property(e => e.UNIT).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_MEAL_DATA>(entity =>
            {
                entity.HasKey(e => e.MEAL_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_MEAL_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.MEAL_ID)
                    .HasName("IDX_MEAL_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CAUSE>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_CAUSE_ID);

                entity.HasIndex(e => e.OVERTIME_CAUSE_CODE)
                    .HasName("IDX_OVERTIME_CAUSE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_MEMO).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.NOT_CHECKCARD).HasMaxLength(50);

                entity.Property(e => e.NOT_DISPLAY).HasMaxLength(50);

                entity.Property(e => e.NOT_FOOD).HasMaxLength(50);

                entity.Property(e => e.ONCALL).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CAUSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_CAUSE_ID)
                    .HasName("IDX_OVERTIME_CAUSE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOLIDAY_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_MEMO).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOT_CALCULATE).HasMaxLength(50);

                entity.Property(e => e.NOT_CHECKCARD).HasMaxLength(50);

                entity.Property(e => e.NOT_DISPLAY).HasMaxLength(50);

                entity.Property(e => e.NOT_FOOD).HasMaxLength(50);

                entity.Property(e => e.ONCALL).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.ALLOW_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.ALLOW_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_NORMAL_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_OFFPAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_ATTEND_CARD).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NORMAL_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_OFFPAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_OVERTIME_DEPT).HasMaxLength(10);

                entity.Property(e => e.IS_SHOW_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.MONTH_HOUR_DATE_TYPE).HasMaxLength(10);

                entity.Property(e => e.OVERTIME_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CONFIG_DEPT>(entity =>
            {
                entity.HasKey(e => e.DEPT_ID);

                entity.Property(e => e.DEPT_ID).ValueGeneratedNever();

                entity.Property(e => e.ALLOW_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.ALLOW_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_NORMAL_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_OFFPAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_ATTEND_CARD).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NORMAL_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_OFFPAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_OVERTIME_DEPT).HasMaxLength(10);

                entity.Property(e => e.IS_SHOW_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.MONTH_HOUR_DATE_TYPE).HasMaxLength(10);

                entity.Property(e => e.OVERTIME_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CONFIG_DEPT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.LOG_ID).ValueGeneratedNever();

                entity.Property(e => e.ALLOW_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.ALLOW_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_NORMAL_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_OFFPAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_ATTEND_CARD).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NORMAL_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_OFFPAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_OVERTIME_DEPT).HasMaxLength(10);

                entity.Property(e => e.IS_SHOW_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MONTH_HOUR_DATE_TYPE).HasMaxLength(10);

                entity.Property(e => e.OVERTIME_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.ALLOW_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.ALLOW_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_NORMAL_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ALLOW_OFFPAY_OVERTIME_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_ATTEND_CARD).HasMaxLength(50);

                entity.Property(e => e.IS_CHECK_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NATIONAL_HOLIDAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_NORMAL_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_CHECK_OFFPAY_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.IS_OVERTIME_DEPT).HasMaxLength(10);

                entity.Property(e => e.IS_SHOW_MONTH_OVERTIME_HOUR).HasMaxLength(10);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MONTH_HOUR_DATE_TYPE).HasMaxLength(10);

                entity.Property(e => e.OVERTIME_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CREATE>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_CREATE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.OVERTIME_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_ID).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_CREATE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_CREATE_ID)
                    .HasName("IDX_OVERTIME_CREATE_ID");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_ID).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_DATA>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.OVERTIME_DATE })
                    .HasName("IDX_OVERTIME_DATE");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_DATA_FLOW>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_ID);

                entity.Property(e => e.ACTUAL_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.ACTUAL_END_TIME).HasMaxLength(50);

                entity.Property(e => e.ACTUAL_OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACTUAL_REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CHECK_OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CHECK_REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.ERROR_MESSAGE).HasMaxLength(500);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IS_ATTENDCARD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.IS_SUCCESS).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_DATA_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IS_ATTENDCARD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_ID)
                    .HasName("IDX_OVERTIME_ID");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_DATA_SET_FLOW>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_SET_ID);

                entity.Property(e => e.OVERTIME_SET_ID).ValueGeneratedNever();

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.IS_ATTENDCARD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_RATE>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_RATE_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_CODE)
                    .HasName("IDX_OVERTIME_RATE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FIX_RATE).HasMaxLength(50);

                entity.Property(e => e.MIN_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_RATE_CNAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_CODE).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_ENAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_HTYPE).HasMaxLength(1);

                entity.Property(e => e.OVERTIME_RATE_WTYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_OVERTIME_RATE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_ID)
                    .HasName("IDX_OVERTIME_RATE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FIX_RATE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MIN_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133HTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT133WTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167HTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT167WTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200HTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WAMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WRATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WTIME_B).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OT200WTIME_E).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_RATE_CNAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_CODE).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_ENAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_HTYPE).HasMaxLength(1);

                entity.Property(e => e.OVERTIME_RATE_WTYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_REST_HOLIDAY_MINUS>(entity =>
            {
                entity.HasKey(e => e.REST_HOLIDAY_MINUS_ID);

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.REVERSAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_REST_HOLIDAY_MINUS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.REST_HOLIDAY_MINUS_ID)
                    .HasName("IDX_REST_HOLIDAY_MINUS_ID");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.REVERSAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE>(entity =>
            {
                entity.HasKey(e => e.ROTE_ID);

                entity.HasIndex(e => e.ROTE_CODE)
                    .HasName("IDX_ROTE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.D_WORK_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIX_OVERTIME_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FLEXIBLE_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_CARD).HasMaxLength(50);

                entity.Property(e => e.IS_FIX_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_ROTE_ALLOWANCE).HasMaxLength(50);

                entity.Property(e => e.LATE_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LEAVE_OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.ON_TIME).HasMaxLength(50);

                entity.Property(e => e.OT_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.ROTE_ALLOWANCE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ROTE_ALLOWANCE_SALCODE).HasMaxLength(50);

                entity.Property(e => e.ROTE_CNAME).HasMaxLength(50);

                entity.Property(e => e.ROTE_CODE).HasMaxLength(50);

                entity.Property(e => e.ROTE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.YEAR_REST_HRS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_ROTEMAPPING_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ROTEMAPPING_CODE, e.ROTE_ID });

                entity.Property(e => e.ROTEMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTEMAPPING_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.ROTEMAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTEMAPPING_HOUR_PATCH>(entity =>
            {
                entity.HasKey(e => e.ROTEMAPPING_HOUR_PATCH_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOUR_BEGIN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HOUR_END).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PATCH_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTEMAPPING_HOUR_PATCH_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOUR_BEGIN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HOUR_END).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PATCH_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTEMAPPING_MASTER>(entity =>
            {
                entity.HasKey(e => e.ROTEMAPPING_CODE);

                entity.Property(e => e.ROTEMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.ROTEMAPPING_TITLE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTEMAPPING_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.ROTEMAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ROTEMAPPING_TITLE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_CHANGE>(entity =>
            {
                entity.HasKey(e => e.ROTE_CHANGE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_DATE, e.END_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.IS_CHANGE_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.ROTE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_CHANGE_DETAIL>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.ROTE_CHANGE_ID, e.EMPLOYEE_ID })
                    .HasName("IDX_ROTE_CHANGE_ID");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ROTE_CHANGE_DATE).HasColumnType("datetime");

                entity.Property(e => e.ROTE_ID).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_CHANGE_FLOW>(entity =>
            {
                entity.HasKey(e => e.ROTE_CHANGE_ID);

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.IS_CHANGE_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.ROTE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_CHANGE_FLOW_DETAIL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ROTE_CHANGE_DATE).HasColumnType("datetime");

                entity.Property(e => e.ROTE_ID).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_CHANGE_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_CHANGE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ROTE_CHANGE_ID)
                    .HasName("IDX_ROTE_CHANGE_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.IS_CHANGE_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.ROTE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_HOLIDAY>(entity =>
            {
                entity.HasKey(e => e.ROTE_HOLIDAY_ID);

                entity.HasIndex(e => e.ROTE_ID)
                    .HasName("IDX_ROTE_ID");

                entity.Property(e => e.BEGIN_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.REST_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_HOLIDAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ROTE_HOLIDAY_ID)
                    .HasName("IDX_ROTE_HOLIDAY_ID");

                entity.Property(e => e.BEGIN_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REST_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ROTE_ID)
                    .HasName("IDX_ROTE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.D_WORK_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIX_OVERTIME_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FLEXIBLE_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_CARD)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IS_FIX_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_ROTE_ALLOWANCE).HasMaxLength(50);

                entity.Property(e => e.LATE_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LEAVE_OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.ON_TIME).HasMaxLength(50);

                entity.Property(e => e.OT_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.ROTE_ALLOWANCE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ROTE_ALLOWANCE_SALCODE).HasMaxLength(50);

                entity.Property(e => e.ROTE_CNAME).HasMaxLength(50);

                entity.Property(e => e.ROTE_CODE).HasMaxLength(50);

                entity.Property(e => e.ROTE_ENAME).HasMaxLength(50);

                entity.Property(e => e.SEQ).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.YEAR_REST_HRS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_REST>(entity =>
            {
                entity.HasKey(e => new { e.ROTE_ID, e.REST_SEQ });

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_HOLIDAY_ABSENT).HasMaxLength(50);

                entity.Property(e => e.IS_HOLIDAY_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_NORMAL_ABSENT).HasMaxLength(50);

                entity.Property(e => e.IS_NORMAL_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.REST_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.REST_END_TIME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_REST_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.ROTE_ID, e.REST_SEQ })
                    .HasName("IDX_ROTE_ID_REST_SEQ");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_HOLIDAY_ABSENT).HasMaxLength(50);

                entity.Property(e => e.IS_HOLIDAY_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_NORMAL_ABSENT).HasMaxLength(50);

                entity.Property(e => e.IS_NORMAL_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REST_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.REST_END_TIME).HasMaxLength(50);

                entity.Property(e => e.REST_SEQ).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_WORK>(entity =>
            {
                entity.HasKey(e => e.ROTE_WORK_ID)
                    .HasName("PK_HRM_ATTEND_ROTE_WORK_1");

                entity.HasIndex(e => new { e.ROTE_ID, e.WORK_SEQ })
                    .HasName("IDX_ROTE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.WORK_END_TIME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE_WORK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ROTE_WORK_ID)
                    .HasName("IDX_ROTE_WORK_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.WORK_END_TIME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT>(entity =>
            {
                entity.HasKey(e => e.SHIFT_ID);

                entity.HasIndex(e => e.SHIFT_CODE)
                    .HasName("IDX_SHIFT_CODE");

                entity.Property(e => e.BEGIN_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SHIFT_CNAME).HasMaxLength(50);

                entity.Property(e => e.SHIFT_CODE).HasMaxLength(50);

                entity.Property(e => e.SHIFT_ENAME).HasMaxLength(50);

                entity.Property(e => e.SHIFT_FREQUENCE).HasMaxLength(50);

                entity.Property(e => e.SHIFT_FREQUENCE_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SHIFT_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEEK_START).HasMaxLength(50);

                entity.Property(e => e.YEAR_REST_HRS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SHIFT_ID)
                    .HasName("IDX_SHIFT_ID");

                entity.Property(e => e.BEGIN_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SHIFT_CNAME).HasMaxLength(50);

                entity.Property(e => e.SHIFT_CODE).HasMaxLength(50);

                entity.Property(e => e.SHIFT_ENAME).HasMaxLength(50);

                entity.Property(e => e.SHIFT_FREQUENCE).HasMaxLength(50);

                entity.Property(e => e.SHIFT_FREQUENCE_DAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SHIFT_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEEK_START).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_ROTE>(entity =>
            {
                entity.HasKey(e => new { e.SHIFT_ID, e.SHIFT_SEQ });

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_ROTE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SHIFT_ID, e.SHIFT_SEQ })
                    .HasName("IDX_SHIFT_ID_SHIFT_SEQ");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_SCHEDULE>(entity =>
            {
                entity.HasKey(e => new { e.EFFECT_YEAR, e.EFFECT_MONTH, e.EMPLOYEE_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_SCHEDULE_2625>(entity =>
            {
                entity.HasKey(e => new { e.EFFECT_YEAR, e.EFFECT_MONTH, e.EMPLOYEE_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_SCHEDULE_2625_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_SHIFT_SCHEDULE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_YEAR, e.EFFECT_MONTH })
                    .HasName("IDX_SHIFT_ID_EFFECT_YEAR_EFFECT_MONTH");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_YEAR_HOLIDAY>(entity =>
            {
                entity.HasKey(e => e.YEAR_HOLIDAY_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.PTO_YEARS })
                    .HasName("IDX_EMPLOYEE_ID_PTO_YEARS");

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.PTO_DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PTO_YEARS).HasMaxLength(50);

                entity.Property(e => e.SUSPENSION_YEARS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UNIT).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_YEAR_HOLIDAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.YEAR_HOLIDAY_ID)
                    .HasName("IDX_YEAR_HOLIDAY_ID");

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.PTO_DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PTO_YEARS).HasMaxLength(50);

                entity.Property(e => e.SUSPENSION_YEARS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UNIT).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_YEAR_HOLIDAY_MINUS>(entity =>
            {
                entity.HasKey(e => e.YEAR_HOLIDAY_MINUS_ID);

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.REVERSAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_YEAR_HOLIDAY_MINUS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.YEAR_HOLIDAY_MINUS_ID)
                    .HasName("IDX_YEAR_HOLIDAY_MINUS_ID");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HAVE_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.IS_SYSCREATE).HasMaxLength(50);

                entity.Property(e => e.IS_TRANSFER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.REVERSAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_BANK>(entity =>
            {
                entity.HasKey(e => e.BANK_ID);

                entity.HasIndex(e => e.BANK_CODE)
                    .HasName("IDX_BANK_CODE");

                entity.Property(e => e.BANK_CNAME).HasMaxLength(60);

                entity.Property(e => e.BANK_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BANK_ENAME).HasMaxLength(60);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_BANK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BANK_ID)
                    .HasName("IDX_BANK_ID");

                entity.Property(e => e.BANK_CNAME).HasMaxLength(60);

                entity.Property(e => e.BANK_CODE).HasMaxLength(50);

                entity.Property(e => e.BANK_ENAME).HasMaxLength(60);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_BASE_BASE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ID)
                    .HasName("PK_PK_HRM_BASE");

                entity.HasIndex(e => e.EMPLOYEE_CODE)
                    .HasName("Unique_HRM_BASE_BASE_EMPLOYEE_CODE")
                    .IsUnique();

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.ADMIT_DATE).HasColumnType("date");

                entity.Property(e => e.ALIEN_RESIDENT_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("外籍類別");

                entity.Property(e => e.ARMY)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("兵役狀態-Code表");

                entity.Property(e => e.ARMY_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("兵種");

                entity.Property(e => e.BIRTHDAY)
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.BIRTHPLACE)
                    .HasMaxLength(50)
                    .HasComment("出生地-資料表");

                entity.Property(e => e.BLOOD)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("血型-Code表");

                entity.Property(e => e.COMPANY_MAIL)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司MAIL");

                entity.Property(e => e.CONTACT_COUNTY).HasMaxLength(10);

                entity.Property(e => e.COUNTRY_ID).HasComment("國別-資料表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工編號");

                entity.Property(e => e.EXTERNAL_SENIORITY).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.HEIGHT)
                    .HasColumnType("decimal(5, 2)")
                    .HasComment("身高");

                entity.Property(e => e.IDNO)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("身分證字號");

                entity.Property(e => e.INTRODUCER_CODE).HasMaxLength(50);

                entity.Property(e => e.INTRODUCER_ID).HasMaxLength(50);

                entity.Property(e => e.INTRODUCER_NAME).HasMaxLength(50);

                entity.Property(e => e.MARRIAGE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("婚姻-Code表");

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NAME_C)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工姓名");

                entity.Property(e => e.NAME_E)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("英文名稱");

                entity.Property(e => e.PASSPORT_NAME)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("護照姓名");

                entity.Property(e => e.PASSPORT_NUMBER)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("護照號碼");

                entity.Property(e => e.PHOTO)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("照片");

                entity.Property(e => e.REGISTER_COUNTY).HasMaxLength(10);

                entity.Property(e => e.RESIDENT_CERTIFICATE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("居留證號");

                entity.Property(e => e.SEX)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("性別-Code表");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEIGHT)
                    .HasColumnType("decimal(5, 2)")
                    .HasComment("體重");
            });

            modelBuilder.Entity<HRM_BASE_BASEIO>(entity =>
            {
                entity.HasKey(e => e.BASEIO_ID);

                entity.HasIndex(e => new { e.EFFECT_DATE, e.EMPLOYEE_ID })
                    .HasName("IDX_EFFECT_DATE");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BASEIO_ID).HasComment("Employee-資料表");

                entity.Property(e => e.ACTION_TYPE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("進出類別(1:到職2:離職3:留停)Code表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE)
                    .HasColumnType("date")
                    .HasComment("生效日");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MEMO)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')")
                    .HasComment("備註");

                entity.Property(e => e.REINSTATEMENT_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_BASE_BASEIO_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BASEIO_ID)
                    .HasName("IDX_BASEIO_ID");

                entity.Property(e => e.ACTION_TYPE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("進出類別(1:到職2:離職3:留停)Code表");

                entity.Property(e => e.BASEIO_ID).HasComment("Employee-資料表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE)
                    .HasColumnType("date")
                    .HasComment("生效日");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')")
                    .HasComment("備註");

                entity.Property(e => e.REINSTATEMENT_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_BASE_BASETTS>(entity =>
            {
                entity.HasKey(e => e.BASETTS_ID)
                    .HasName("PK_HRM_BASE_BASETTS_1");

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY");

                entity.HasIndex(e => e.DEPT_ID)
                    .HasName("IDX_DEPT");

                entity.HasIndex(e => new { e.EFFECT_DATE, e.EMPLOYEE_ID })
                    .HasName("IDX_EFFECTDATE_EMPLOYEE");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.DEPT_ID })
                    .HasName("IDX_EMPLOYEEID_DEPTID");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_EMPLOYEEID_EFFECTDATE");

                entity.HasIndex(e => new { e.ATTEND_GROUP_ID, e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_ATTEND_GROUP_ID");

                entity.Property(e => e.ALTERATION_CAUSE_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("原因-資料表");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司別-資料表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTA_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("簽核部門-資料表");

                entity.Property(e => e.DEPTC_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("成本部門-資料表");

                entity.Property(e => e.DEPT_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("編制部門-資料表");

                entity.Property(e => e.DIRECT_INDIRECT)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("直間接-Code表");

                entity.Property(e => e.EFFECT_DATE)
                    .HasColumnType("date")
                    .HasComment("生效日");

                entity.Property(e => e.EMPLOYEE_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("Employee-資料表");

                entity.Property(e => e.GRADE_ID).HasComment("職等-資料表");

                entity.Property(e => e.GROUP_ID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員別-員別資料表");

                entity.Property(e => e.IDENTITY_ID).HasComment("員別-員別資料表");

                entity.Property(e => e.JOB_ID).HasComment("職稱-資料表");

                entity.Property(e => e.LEVEL_ID).HasComment("職級-資料表");

                entity.Property(e => e.MEMO)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')")
                    .HasComment("備註");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_ID).HasComment("工作地點-資料表");
            });

            modelBuilder.Entity<HRM_BASE_BASETTS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BASETTS_ID)
                    .HasName("IDX_BASETTS_ID");

                entity.Property(e => e.ALTERATION_CAUSE_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("原因-資料表");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司別-資料表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTA_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("簽核部門-資料表");

                entity.Property(e => e.DEPTC_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("成本部門-資料表");

                entity.Property(e => e.DEPT_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("編制部門-資料表");

                entity.Property(e => e.DIRECT_INDIRECT)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("直間接-Code表");

                entity.Property(e => e.EFFECT_DATE)
                    .HasColumnType("date")
                    .HasComment("生效日");

                entity.Property(e => e.EMPLOYEE_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("Employee-資料表");

                entity.Property(e => e.GROUP_ID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員別-員別資料表");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')")
                    .HasComment("備註");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_BASE_BASE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ADMIT_DATE).HasColumnType("date");

                entity.Property(e => e.ALIEN_RESIDENT_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("外籍類別");

                entity.Property(e => e.ARMY)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("兵役狀態-Code表");

                entity.Property(e => e.ARMY_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("兵種");

                entity.Property(e => e.BIRTHDAY)
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.BIRTHPLACE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("出生地-資料表");

                entity.Property(e => e.BLOOD)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("血型-Code表");

                entity.Property(e => e.COMPANY_MAIL)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司MAIL");

                entity.Property(e => e.CONTACT_COUNTY).HasMaxLength(10);

                entity.Property(e => e.COUNTRY_ID)
                    .HasDefaultValueSql("('')")
                    .HasComment("國別-資料表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工編號");

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.EXTERNAL_SENIORITY).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.HEIGHT)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("身高");

                entity.Property(e => e.IDNO)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("身分證字號");

                entity.Property(e => e.INTRODUCER_CODE).HasMaxLength(50);

                entity.Property(e => e.INTRODUCER_ID).HasMaxLength(50);

                entity.Property(e => e.INTRODUCER_NAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MARRIAGE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("婚姻-Code表");

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NAME_C)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員工姓名");

                entity.Property(e => e.NAME_E)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("英文名稱");

                entity.Property(e => e.PASSPORT_NAME)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("護照姓名");

                entity.Property(e => e.PASSPORT_NUMBER)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("護照號碼");

                entity.Property(e => e.PHOTO)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("照片");

                entity.Property(e => e.REGISTER_COUNTY).HasMaxLength(10);

                entity.Property(e => e.RESIDENT_CERTIFICATE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("居留證號");

                entity.Property(e => e.SEX)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("性別-Code表");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEIGHT)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("體重");
            });

            modelBuilder.Entity<HRM_COMPANY>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID)
                    .HasName("PK_COMP");

                entity.HasIndex(e => e.COMPANY_CODE)
                    .HasName("IDX_COMPANY_CODE");

                entity.Property(e => e.ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.CHAIRMAN_CNAME).HasMaxLength(50);

                entity.Property(e => e.CHAIRMAN_ENAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ABBR).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ADDRESS_C).HasMaxLength(120);

                entity.Property(e => e.COMPANY_ADDRESS_E).HasMaxLength(120);

                entity.Property(e => e.COMPANY_CNAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COMPANY_EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ENAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_POSTAL).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.F0407).HasMaxLength(50);

                entity.Property(e => e.FAX).HasMaxLength(50);

                entity.Property(e => e.HOUSEID).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORKPLACE_ID).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_COMPANY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.CHAIRMAN_CNAME).HasMaxLength(50);

                entity.Property(e => e.CHAIRMAN_ENAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ABBR).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ADDRESS_C).HasMaxLength(120);

                entity.Property(e => e.COMPANY_ADDRESS_E).HasMaxLength(120);

                entity.Property(e => e.COMPANY_CNAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ENAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_POSTAL).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.F0407).HasMaxLength(50);

                entity.Property(e => e.FAX).HasMaxLength(50);

                entity.Property(e => e.HOUSEID).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORKPLACE_ID).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_CONTRACT_TYPE>(entity =>
            {
                entity.HasKey(e => e.CONTRACT_TYPE_ID);

                entity.HasIndex(e => e.CONTRACT_TYPE_CODE)
                    .HasName("IDX_CONTRACT_TYPE_CODE");

                entity.Property(e => e.CONTRACT_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.CONTRACT_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.CONTRACT_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_CONTRACT_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CONTRACT_TYPE_ID)
                    .HasName("IDX_CONTRACT_TYPE_ID");

                entity.Property(e => e.CONTRACT_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.CONTRACT_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.CONTRACT_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_COUNTRY>(entity =>
            {
                entity.HasKey(e => e.COUNTRY_ID);

                entity.HasIndex(e => e.COUNTRY_CODE)
                    .HasName("IDX_COUNTRY_CODE");

                entity.Property(e => e.COUNTRY_CNAME).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FOREIGNER).HasMaxLength(50);

                entity.Property(e => e.TAX_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_COUNTRY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COUNTRY_ID)
                    .HasName("IDX_COUNTRY_ID");

                entity.Property(e => e.COUNTRY_CNAME).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FOREIGNER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_COURSE_SETS>(entity =>
            {
                entity.HasKey(e => e.COURSE_SETS_ID);

                entity.HasIndex(e => e.COURSE_SETS_CODE)
                    .HasName("IDX_COURSE_SETS_CODE");

                entity.HasIndex(e => e.SCHOOL_ID)
                    .HasName("IDX_SCHOOL_ID");

                entity.Property(e => e.COURSE_SETS_CNAME)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.COURSE_SETS_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COURSE_SETS_ENAME)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_COURSE_SETS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COURSE_SETS_ID)
                    .HasName("IDX_COURSE_SETS_ID");

                entity.Property(e => e.COURSE_SETS_CNAME).HasMaxLength(100);

                entity.Property(e => e.COURSE_SETS_CODE).HasMaxLength(50);

                entity.Property(e => e.COURSE_SETS_ENAME).HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_CURRENCY>(entity =>
            {
                entity.HasKey(e => e.CURRENCY_ID);

                entity.HasIndex(e => e.CURRENCY_CODE)
                    .HasName("IDX_CURRENCY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_CNAME).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_CODE).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_ENAME).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_STATUS).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_CURRENCY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.CURRENCY_ID)
                    .HasName("IDX_CURRENCY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_CNAME).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_CODE).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_ENAME).HasMaxLength(50);

                entity.Property(e => e.CURRENCY_STATUS).HasMaxLength(1);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPT>(entity =>
            {
                entity.HasKey(e => e.DEPT_ID);

                entity.HasIndex(e => e.DEPT_CODE)
                    .HasName("IDX_DEPT_CODE");

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.ALERT_EMAIL_LIST).HasMaxLength(500);

                entity.Property(e => e.ALERT_TO_EMAIL).HasMaxLength(50);

                entity.Property(e => e.ALERT_TO_MANAGER).HasMaxLength(50);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ASSISTANT_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPT_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPT_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPT_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPT_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPT_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPT_TREE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPTA>(entity =>
            {
                entity.HasKey(e => e.DEPTA_ID);

                entity.HasIndex(e => e.DEPTA_CODE)
                    .HasName("IDX_DEPTA_CODE");

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTA_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPTA_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPTA_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPTA_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPTA_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPTA_TREE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPTA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.DEPTA_ID)
                    .HasName("IDX_DEPTA_ID");

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTA_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPTA_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPTA_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPTA_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPTA_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPTA_TREE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPTC>(entity =>
            {
                entity.HasKey(e => e.DEPTC_ID);

                entity.HasIndex(e => e.DEPTC_CODE)
                    .HasName("IDX_DEPTC_CODE");

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTC_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPTC_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPTC_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPTC_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPTC_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPTC_TREE).HasMaxLength(50);

                entity.Property(e => e.DEPTC_TYPE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPTC_GROUP>(entity =>
            {
                entity.HasKey(e => e.DEPTC_GROUP_ID);

                entity.HasIndex(e => e.DEPTC_CODE)
                    .HasName("IDX_DEPTC_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTC_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPTC_CODE).HasMaxLength(50);

                entity.Property(e => e.IS_SUM).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_DEPTC_CNAME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPTC_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.DEPTC_ID)
                    .HasName("IDX_DEPTC_ID");

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTC_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPTC_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPTC_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPTC_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPTC_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPTC_TREE).HasMaxLength(50);

                entity.Property(e => e.DEPTC_TYPE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.DEPT_ID)
                    .HasName("IDX_DEPT_ID");

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.ALERT_EMAIL_LIST).HasMaxLength(500);

                entity.Property(e => e.ALERT_TO_EMAIL).HasMaxLength(50);

                entity.Property(e => e.ALERT_TO_MANAGER).HasMaxLength(50);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ASSISTANT_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPT_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPT_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPT_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPT_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPT_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPT_TREE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DOORGUARD>(entity =>
            {
                entity.HasKey(e => e.DOORGUARD_ID);

                entity.HasIndex(e => e.DOORGUARD_CODE)
                    .HasName("IDX_DOORGUARD_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DOORGUARD_CNAME).HasMaxLength(50);

                entity.Property(e => e.DOORGUARD_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DOORGUARD_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DOORGUARD_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.DOORGUARD_ID)
                    .HasName("IDX_DOORGUARD_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DOORGUARD_CNAME).HasMaxLength(50);

                entity.Property(e => e.DOORGUARD_CODE).HasMaxLength(50);

                entity.Property(e => e.DOORGUARD_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EDUCATIONAL>(entity =>
            {
                entity.HasKey(e => e.EDUCATIONAL_ID);

                entity.HasIndex(e => e.EDUCATIONAL_CODE)
                    .HasName("IDX_EDUCATIONAL_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EDUCATIONAL_CNAME).HasMaxLength(50);

                entity.Property(e => e.EDUCATIONAL_CODE).HasMaxLength(50);

                entity.Property(e => e.EDUCATIONAL_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EDUCATIONAL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EDUCATIONAL_ID)
                    .HasName("IDX_EDUCATIONAL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EDUCATIONAL_CNAME).HasMaxLength(50);

                entity.Property(e => e.EDUCATIONAL_CODE).HasMaxLength(50);

                entity.Property(e => e.EDUCATIONAL_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_ACCOUNT>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ACCOUNT_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ACCOUNT_NO).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACCOUNT_QUOTA).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_ACCOUNT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_ACCOUNT_ID)
                    .HasName("IDX_EMPLOYEE_ACCOUNT_ID");

                entity.Property(e => e.ACCOUNT_NO).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACCOUNT_QUOTA).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_ADDR>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ADDR_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.ADDR_TYPE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ADDR)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ADDR_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.MAIL)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.POSTCODE).HasMaxLength(50);

                entity.Property(e => e.TEL)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_ADDR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_BASE_ADDR_LOG");

                entity.HasIndex(e => e.EMPLOYEE_ADDR_ID)
                    .HasName("IDX_EMPLOYEE_ADDR_ID");

                entity.Property(e => e.ADDR)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ADDR_TYPE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MAIL)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.POSTCODE).HasMaxLength(50);

                entity.Property(e => e.TEL)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_CONTACT>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_CONTACT_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.RELATION_ID })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_CELLPHONE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_NAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_PHONE).HasMaxLength(20);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_CONTACT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_CONTACT_ID)
                    .HasName("IDX_EMPLOYEE_CONTACT_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_CELLPHONE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_NAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_PHONE).HasMaxLength(20);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_CONTRACT>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_CONTRACT_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.CONTRACT_TYPE_ID })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTRACT_CNAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTRACT_ENAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_CONTRACT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_CONTRACT_ID)
                    .HasName("IDX_EMPLOYEE_CONTRACT_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTRACT_CNAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTRACT_ENAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_COST>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_COST_ID)
                    .HasName("PK_HRM_COST");

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.RATIO).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_COST_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_COST_LOG");

                entity.HasIndex(e => e.EMPLOYEE_COST_ID)
                    .HasName("IDX_EMPLOYEE_COST_ID");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPTC_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RATIO).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EDUCATIONAL>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_EDUCATIONAL_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.COURSE_SETS_CNAME).HasMaxLength(80);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ADMISSION_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_EDUCATIONAL_TYPE).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_GRADUATION_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_GRADUATION_TREATISE).HasMaxLength(200);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.SCHOOL_CNAME).HasMaxLength(80);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EDUCATIONAL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_EDUCATIONAL_ID)
                    .HasName("IDX_EMPLOYEE_EDUCATIONAL_ID");

                entity.Property(e => e.COURSE_SETS_CNAME).HasMaxLength(80);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ADMISSION_DATE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EDUCATIONAL_TYPE).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_GRADUATION_DATE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_GRADUATION_TREATISE).HasMaxLength(200);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SCHOOL_CNAME).HasMaxLength(80);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPAND>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_EXPAND_ID)
                    .HasName("PK_HRM_EMPLOYEE_EXPAND_1");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.EXPAND_1).HasMaxLength(50);

                entity.Property(e => e.EXPAND_2).HasMaxLength(50);

                entity.Property(e => e.EXPAND_3).HasMaxLength(50);

                entity.Property(e => e.EXPAND_4).HasMaxLength(50);

                entity.Property(e => e.EXPAND_5).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPAND_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.EXPAND_1).HasMaxLength(50);

                entity.Property(e => e.EXPAND_2).HasMaxLength(50);

                entity.Property(e => e.EXPAND_3).HasMaxLength(50);

                entity.Property(e => e.EXPAND_4).HasMaxLength(50);

                entity.Property(e => e.EXPAND_5).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPAND_SET>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EXAPND_NAME).HasMaxLength(50);

                entity.Property(e => e.EXAPND_NO).HasMaxLength(50);

                entity.Property(e => e.IS_SHOW).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPERIENCE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_EXPERIENCE_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_BOSS).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_COMPANY).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_CONTENT).HasMaxLength(200);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_DEPARTMENT).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_END).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_JOB).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_LEAVE_REASON).HasMaxLength(200);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_SALARY).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_START).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_YEAR).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPERIENCE_FILE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_EXPERIENCE_FILE_ID);

                entity.HasIndex(e => e.EMPLOYEE_EXPERIENCE_ID)
                    .HasName("IDX_EMPLOYEE_EXPERIENCE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_FILE).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPERIENCE_FILE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_EXPERIENCE_FILE_ID)
                    .HasName("IDX_EMPLOYEE_EXPERIENCE_FILE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_FILE).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_EXPERIENCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_EXPERIENCE_ID)
                    .HasName("IDX_EMPLOYEE_EXPERIENCE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_BOSS).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_COMPANY).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_CONTENT).HasMaxLength(200);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_DEPARTMENT).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_END).HasColumnType("smalldatetime");

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_JOB).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_LEAVE_REASON).HasMaxLength(200);

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_SALARY).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_START).HasColumnType("smalldatetime");

                entity.Property(e => e.EMPLOYEE_EXPERIENCE_YEAR).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_FAMILY>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_FAMILY_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_BIRTHDAY).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(20);

                entity.Property(e => e.EMPLOYEE_FAMILY_NAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_SEX).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_SUPPORT).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_FAMILY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_FAMILY_ID)
                    .HasName("IDX_EMPLOYEE_FAMILY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_BIRTHDAY).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(20);

                entity.Property(e => e.EMPLOYEE_FAMILY_NAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_SEX).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_SUPPORT).HasMaxLength(1);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_HEALTH_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.HEALTH_EFFECTIVE_DATE })
                    .HasName("IDX_EMPLOYEE_ID_EFFECTIVE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_FAMILY>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_HEALTH_FAMILY_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EMPLOYEE_FAMILY_ID, e.BEGIN_EFFECTIVE_DATE })
                    .HasName("IDX_EMPLOYEE_FAMILY");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_FAMILY_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_FAMILY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_HEALTH_FAMILY_ID)
                    .HasName("IDX_EMPLOYEE_HEALTH_FAMILY_ID");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_FAMILY_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_GROUP>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_HEALTH_GROUP_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.HEALTH_EFFECTIVE_DATE })
                    .HasName("idx_EMPLOYEE_EFFECTIVE_DATE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HEALTH_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_IDENTITY_TYPE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_GROUP_FAMILY>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_HEALTH_GROUP_FAMILY_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EMPLOYEE_FAMILY_ID, e.BEGIN_EFFECTIVE_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_FAMILY_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_IDENTITY_TYPE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_GROUP_FAMILY_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_FAMILY_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_IDENTITY_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_GROUP_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HEALTH_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_IDENTITY_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_HEALTH_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_HEALTH_ID)
                    .HasName("IDX_EMPLOYEE_HEALTH_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_MEMO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_IDENTITY>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_IDENTITY_ID);

                entity.HasIndex(e => e.EMPLOYEE_IDENTITY_CODE)
                    .HasName("IDX_EMPLOYEE_IDENTITY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_IDENTITY_CNAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_IDENTITY_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_IDENTITY_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_IDENTITY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_IDENTITY_ID)
                    .HasName("IDX_EMPLOYEE_IDENTITY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_IDENTITY_CNAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_IDENTITY_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_IDENTITY_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_INSURANCE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_INSURANCE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.INSURANCE_TYPE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_EFFECTIVE_DATE).HasColumnType("date");

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_MEMO).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_EFFECTIVE_DATE).HasColumnType("date");

                entity.Property(e => e.LABOR_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_LOW_TYPE).HasMaxLength(50);

                entity.Property(e => e.LABOR_MEMO).HasMaxLength(50);

                entity.Property(e => e.LABOR_SPECIAL_TYPE).HasMaxLength(50);

                entity.Property(e => e.RETIREMENT_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.RETIREMENT_RETIRED_TYPE).HasMaxLength(50);

                entity.Property(e => e.RETIRE_COMPANY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.RETIRE_EFFECTIVE_DATE).HasColumnType("date");

                entity.Property(e => e.RETIRE_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.RETIRE_MEMO).HasMaxLength(50);

                entity.Property(e => e.RETIRE_RATE_TYPE_ID).HasMaxLength(50);

                entity.Property(e => e.RETIRE_SELF_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LABOR>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_LABOR_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.LABOR_EFFECTIVE_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_LABOR_MEMO).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LABOR_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_LOW_TYPE).HasMaxLength(50);

                entity.Property(e => e.LABOR_SPECIAL_TYPE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LABOR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_LABOR_ID)
                    .HasName("IDX_EMPLOYEE_LABOR_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_LABOR_MEMO).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LABOR_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_LOW_TYPE).HasMaxLength(50);

                entity.Property(e => e.LABOR_SPECIAL_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LABOR_SCHEDULE>(entity =>
            {
                entity.HasKey(e => new { e.EFFECT_YEAR, e.EFFECT_MONTH, e.EMPLOYEE_ID });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.D1).HasMaxLength(50);

                entity.Property(e => e.D10).HasMaxLength(50);

                entity.Property(e => e.D11).HasMaxLength(50);

                entity.Property(e => e.D12).HasMaxLength(50);

                entity.Property(e => e.D13).HasMaxLength(50);

                entity.Property(e => e.D14).HasMaxLength(50);

                entity.Property(e => e.D15).HasMaxLength(50);

                entity.Property(e => e.D16).HasMaxLength(50);

                entity.Property(e => e.D17).HasMaxLength(50);

                entity.Property(e => e.D18).HasMaxLength(50);

                entity.Property(e => e.D19).HasMaxLength(50);

                entity.Property(e => e.D2).HasMaxLength(50);

                entity.Property(e => e.D20).HasMaxLength(50);

                entity.Property(e => e.D21).HasMaxLength(50);

                entity.Property(e => e.D22).HasMaxLength(50);

                entity.Property(e => e.D23).HasMaxLength(50);

                entity.Property(e => e.D24).HasMaxLength(50);

                entity.Property(e => e.D25).HasMaxLength(50);

                entity.Property(e => e.D26).HasMaxLength(50);

                entity.Property(e => e.D27).HasMaxLength(50);

                entity.Property(e => e.D28).HasMaxLength(50);

                entity.Property(e => e.D29).HasMaxLength(50);

                entity.Property(e => e.D3).HasMaxLength(50);

                entity.Property(e => e.D30).HasMaxLength(50);

                entity.Property(e => e.D31).HasMaxLength(50);

                entity.Property(e => e.D4).HasMaxLength(50);

                entity.Property(e => e.D5).HasMaxLength(50);

                entity.Property(e => e.D6).HasMaxLength(50);

                entity.Property(e => e.D7).HasMaxLength(50);

                entity.Property(e => e.D8).HasMaxLength(50);

                entity.Property(e => e.D9).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LABOR_SCHEDULE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_YEAR, e.EFFECT_MONTH })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.D1).HasMaxLength(50);

                entity.Property(e => e.D10).HasMaxLength(50);

                entity.Property(e => e.D11).HasMaxLength(50);

                entity.Property(e => e.D12).HasMaxLength(50);

                entity.Property(e => e.D13).HasMaxLength(50);

                entity.Property(e => e.D14).HasMaxLength(50);

                entity.Property(e => e.D15).HasMaxLength(50);

                entity.Property(e => e.D16).HasMaxLength(50);

                entity.Property(e => e.D17).HasMaxLength(50);

                entity.Property(e => e.D18).HasMaxLength(50);

                entity.Property(e => e.D19).HasMaxLength(50);

                entity.Property(e => e.D2).HasMaxLength(50);

                entity.Property(e => e.D20).HasMaxLength(50);

                entity.Property(e => e.D21).HasMaxLength(50);

                entity.Property(e => e.D22).HasMaxLength(50);

                entity.Property(e => e.D23).HasMaxLength(50);

                entity.Property(e => e.D24).HasMaxLength(50);

                entity.Property(e => e.D25).HasMaxLength(50);

                entity.Property(e => e.D26).HasMaxLength(50);

                entity.Property(e => e.D27).HasMaxLength(50);

                entity.Property(e => e.D28).HasMaxLength(50);

                entity.Property(e => e.D29).HasMaxLength(50);

                entity.Property(e => e.D3).HasMaxLength(50);

                entity.Property(e => e.D30).HasMaxLength(50);

                entity.Property(e => e.D31).HasMaxLength(50);

                entity.Property(e => e.D4).HasMaxLength(50);

                entity.Property(e => e.D5).HasMaxLength(50);

                entity.Property(e => e.D6).HasMaxLength(50);

                entity.Property(e => e.D7).HasMaxLength(50);

                entity.Property(e => e.D8).HasMaxLength(50);

                entity.Property(e => e.D9).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LICENCE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_LICENCE_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.AUTHENTIC_ORG).HasMaxLength(250);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LICENCE_CONTENT).HasMaxLength(250);

                entity.Property(e => e.LICENCE_COUNTRY).HasMaxLength(1);

                entity.Property(e => e.LICENCE_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LICENCE_MEMO).HasMaxLength(100);

                entity.Property(e => e.LICENCE_NAME).HasMaxLength(200);

                entity.Property(e => e.LICENCE_NO).HasMaxLength(50);

                entity.Property(e => e.LICENCE_OWN).HasMaxLength(50);

                entity.Property(e => e.LICENCE_VALID_DATE).HasColumnType("datetime");

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.SALARY_END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LICENCE_FILE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_LICENCE_FILE_ID);

                entity.HasIndex(e => e.EMPLOYEE_LICENCE_ID)
                    .HasName("IDX_EMPLOYEE_LICENCE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_LICENCE_FILE).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LICENCE_FILE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_LICENCE_FILE_ID)
                    .HasName("IDX_EMPLOYEE_LICENCE_FILE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_LICENCE_FILE).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_LICENCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_LICENCE_ID)
                    .HasName("IDX_EMPLOYEE_LICENCE_ID");

                entity.Property(e => e.AUTHENTIC_ORG).HasMaxLength(250);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LICENCE_CONTENT).HasMaxLength(250);

                entity.Property(e => e.LICENCE_COUNTRY).HasMaxLength(1);

                entity.Property(e => e.LICENCE_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LICENCE_MEMO).HasMaxLength(100);

                entity.Property(e => e.LICENCE_NAME).HasMaxLength(200);

                entity.Property(e => e.LICENCE_NO).HasMaxLength(50);

                entity.Property(e => e.LICENCE_OWN).HasMaxLength(50);

                entity.Property(e => e.LICENCE_VALID_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.SALARY_END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_MONTH_MEETING>(entity =>
            {
                entity.HasKey(e => e.MONTH_MEETING_ID);

                entity.HasIndex(e => e.MONTH_MEETING_ID)
                    .HasName("IDX_MONTH_MEETING_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_APPROVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.MONTH_MEETING_APPROVE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_DATE).HasColumnType("datetime");

                entity.Property(e => e.MONTH_MEETING_GROUP).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_LATE_TIME).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_MEMO).HasMaxLength(250);

                entity.Property(e => e.MONTH_MEETING_NAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_MONTH_MEETING_DETAIL>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.MONTH_MEETING_ID, e.EMPLOYEE_ID })
                    .HasName("IDX_MONTH_MEETING_ID");

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEDUCT_POINT).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_LATE).HasMaxLength(50);

                entity.Property(e => e.IS_SIGN).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.MONTH_MEETING_DATE).HasColumnType("datetime");

                entity.Property(e => e.MONTH_MEETING_LATE_TIME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_MONTH_MEETING_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.MONTH_MEETING_ID, e.EMPLOYEE_ID })
                    .HasName("IDX_MONTH_MEETING_ID");

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEDUCT_POINT).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_LATE).HasMaxLength(50);

                entity.Property(e => e.IS_SIGN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.MONTH_MEETING_DATE).HasColumnType("datetime");

                entity.Property(e => e.MONTH_MEETING_LATE_TIME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_MONTH_MEETING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.MONTH_MEETING_ID)
                    .HasName("IDX_MONTH_MEETING_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_APPROVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.MONTH_MEETING_APPROVE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_DATE).HasColumnType("datetime");

                entity.Property(e => e.MONTH_MEETING_GROUP).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_LATE_TIME).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_MEMO).HasMaxLength(250);

                entity.Property(e => e.MONTH_MEETING_NAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_PARAMETER>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_PARAMETER_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DELAY_MEAL_AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DELAY_MEAL_OVERTIME_INCLUSIVE).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DELAY_MEAL_OVERTIME_OVER).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HIRE_TYPE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.IS_DELAY_MEAL).HasMaxLength(50);

                entity.Property(e => e.IS_HOUSEKEEPING).HasMaxLength(50);

                entity.Property(e => e.IS_NOT_CREATE_YEAR_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.IS_OVERTIME_HOUR).HasMaxLength(50);

                entity.Property(e => e.IS_REST_HOUR).HasMaxLength(50);

                entity.Property(e => e.IS_REST_OVER).HasMaxLength(50);

                entity.Property(e => e.IS_SEND_SHIFT_ALLOWANCE).HasMaxLength(50);

                entity.Property(e => e.IS_TEMPORARY_WORKER).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_GROUP).HasMaxLength(200);

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VD_ACCOUNT).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_PARAMETER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_PARAMETER_ID)
                    .HasName("IDX_EMPLOYEE_PARAMETER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DELAY_MEAL_AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DELAY_MEAL_OVERTIME_INCLUSIVE).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DELAY_MEAL_OVERTIME_OVER).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HIRE_TYPE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.IS_DELAY_MEAL).HasMaxLength(50);

                entity.Property(e => e.IS_HOUSEKEEPING).HasMaxLength(50);

                entity.Property(e => e.IS_NOT_CREATE_YEAR_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.IS_OVERTIME_HOUR).HasMaxLength(50);

                entity.Property(e => e.IS_REST_HOUR).HasMaxLength(50);

                entity.Property(e => e.IS_REST_OVER).HasMaxLength(50);

                entity.Property(e => e.IS_TEMPORARY_WORKER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_GROUP).HasMaxLength(200);

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VD_ACCOUNT).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_PAYROLL>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_PAYROLL_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.MANAGER_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.PASSWORD).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_PAYROLL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_PAYROLL_ID)
                    .HasName("IDX_EMPLOYEE_PAYROLL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MANAGER_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.PASSWORD).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_RESIDENT>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_RESIDENT_ID)
                    .HasName("PK_HRM_BASE_RESIDENT");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.LEAVE_DATE).HasColumnType("date");

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_RESIDENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_BASE_RESIDENT_LOG");

                entity.HasIndex(e => e.EMPLOYEE_RESIDENT_ID)
                    .HasName("IDX_EMPLOYEE_RESIDENT_ID");

                entity.Property(e => e.BEGIN_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.LEAVE_DATE).HasColumnType("date");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_RETIRE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_RETIRE_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_RETIRE_MEMO).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.RETIRE_COMPANY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.RETIRE_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.RETIRE_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.RETIRE_RATE_TYPE_ID).HasMaxLength(50);

                entity.Property(e => e.RETIRE_SELF_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_RETIREMENT>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.RETIRED_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_RETIREMENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RETIRED_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_RETIRE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_RETIRE_ID)
                    .HasName("IDX_EMPLOYEE_RETIRE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_RETIRE_MEMO).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE).HasMaxLength(50);

                entity.Property(e => e.REPORT_DONE_DATE).HasColumnType("datetime");

                entity.Property(e => e.RETIRE_COMPANY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.RETIRE_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.RETIRE_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.RETIRE_RATE_TYPE_ID).HasMaxLength(50);

                entity.Property(e => e.RETIRE_SELF_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_REWARD>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_REWARD_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_REWARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_REWARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_REWARD_DESC).HasMaxLength(300);

                entity.Property(e => e.EMPLOYEE_REWARD_LAYOFF).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_REWARD_LIST).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_REWARD_PROMOTE).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_REWARD_VAL).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.REWARD_KIND_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPLOAD_FILE1).HasMaxLength(200);

                entity.Property(e => e.UPLOAD_FILE2).HasMaxLength(200);

                entity.Property(e => e.UPLOAD_FILE3).HasMaxLength(200);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_REWARD_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_EMPLOYEE_REWARD_LOG_1");

                entity.HasIndex(e => e.EMPLOYEE_REWARD_ID)
                    .HasName("IDX_EMPLOYEE_REWARD_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_REWARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_REWARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_REWARD_DESC).HasMaxLength(100);

                entity.Property(e => e.EMPLOYEE_REWARD_LAYOFF).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_REWARD_LIST).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_REWARD_PROMOTE).HasMaxLength(1);

                entity.Property(e => e.EMPLOYEE_REWARD_VAL).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPLOAD_FILE1).HasMaxLength(200);

                entity.Property(e => e.UPLOAD_FILE2).HasMaxLength(200);

                entity.Property(e => e.UPLOAD_FILE3).HasMaxLength(200);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_SKILL>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_SKILL_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_SKILL_CONTENT).HasMaxLength(250);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_SKILL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_SKILL_ID)
                    .HasName("IDX_EMPLOYEE_SKILL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_SKILL_CONTENT).HasMaxLength(250);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_TEMPORARY_WORKER>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ID)
                    .HasName("PK_HRM_TEMPORARY_WORKER");

                entity.HasIndex(e => e.EMPLOYEE_CODE)
                    .HasName("IDX_EMPLOYEE_CODE");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_NO).HasMaxLength(50);

                entity.Property(e => e.ADDR1).HasMaxLength(200);

                entity.Property(e => e.ADDR2).HasMaxLength(200);

                entity.Property(e => e.ALIEN_RESIDENT_TYPE).HasMaxLength(50);

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BIRTHDAY).HasColumnType("date");

                entity.Property(e => e.BLOOD).HasMaxLength(50);

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_MAIL).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_CELLPHONE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_NAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.GROUP_ID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員別-員別資料表");

                entity.Property(e => e.HEALTH_AMT).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.HIRE_TYPE).HasMaxLength(50);

                entity.Property(e => e.HOURLY_AMT).HasColumnType("decimal(16, 1)");

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_AMT).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.MARRIAGE).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NAME_E).HasMaxLength(50);

                entity.Property(e => e.PASSPORT_NUMBER).HasMaxLength(50);

                entity.Property(e => e.PHOTO).HasMaxLength(50);

                entity.Property(e => e.RESIDENT_CERTIFICATE).HasMaxLength(50);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.RETIRE_SELF_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.SEX).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_TEMPORARY_WORKER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_TEMPORARY_WORKER_LOG");

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ACCOUNT_NO).HasMaxLength(50);

                entity.Property(e => e.ADDR1).HasMaxLength(200);

                entity.Property(e => e.ADDR2).HasMaxLength(200);

                entity.Property(e => e.ALIEN_RESIDENT_TYPE).HasMaxLength(50);

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BIRTHDAY).HasColumnType("date");

                entity.Property(e => e.BLOOD).HasMaxLength(50);

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_MAIL).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_CELLPHONE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CONTACT_NAME).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.GROUP_ID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("員別-員別資料表");

                entity.Property(e => e.HEALTH_AMT).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.HIRE_TYPE).HasMaxLength(50);

                entity.Property(e => e.HOURLY_AMT).HasColumnType("decimal(16, 1)");

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LABOR_AMT).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MARRIAGE).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NAME_E).HasMaxLength(50);

                entity.Property(e => e.PASSPORT_NUMBER).HasMaxLength(50);

                entity.Property(e => e.PHOTO).HasMaxLength(50);

                entity.Property(e => e.RESIDENT_CERTIFICATE).HasMaxLength(50);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.RETIRE_SELF_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.SEX).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY>(entity =>
            {
                entity.HasKey(e => new { e.DEPTC_ID, e.EMPLOYEE_ID, e.WORK_DATE });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.WORK_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOURLY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_HOURS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.DEPTC_ID, e.EMPLOYEE_ID, e.WORK_DATE })
                    .HasName("IDX_DEPTC_ID_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HOURLY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_DATE).HasColumnType("date");

                entity.Property(e => e.WORK_HOURS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_EMPLOYEE_UNIFORM>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_UNIFORM_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UNIFORM_KIND).HasMaxLength(50);

                entity.Property(e => e.UNIFORM_SIZE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EMPLOYEE_UNIFORM_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_UNIFORM_ID)
                    .HasName("IDX_EMPLOYEE_UNIFORM_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UNIFORM_KIND).HasMaxLength(50);

                entity.Property(e => e.UNIFORM_SIZE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EXPENSE>(entity =>
            {
                entity.HasKey(e => e.EXPENSE_ID);

                entity.HasIndex(e => e.EXPENSE_CODE)
                    .HasName("IDX_EXPENSE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_CNAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_EXPENSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EXPENSE_ID)
                    .HasName("IDX_EXPENSE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_CODE).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_ABSENT_AGENT>(entity =>
            {
                entity.HasKey(e => e.ABSENT_AGENT_ID);

                entity.Property(e => e.AGENT_EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATE_FROM).HasColumnType("date");

                entity.Property(e => e.DATE_TO).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_ABSENT_AGENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AGENT_EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATE_FROM).HasColumnType("date");

                entity.Property(e => e.DATE_TO).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_APPLICATE_AGENT>(entity =>
            {
                entity.HasKey(e => e.APPLICATE_AGENT_ID);

                entity.Property(e => e.AGENT_EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATE_FROM).HasColumnType("date");

                entity.Property(e => e.DATE_TO).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FLOW_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_APPLICATE_AGENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AGENT_EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATE_FROM).HasColumnType("date");

                entity.Property(e => e.DATE_TO).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FLOW_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_EMPLOYEE_ROLE_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.FLOW_TYPE });

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FLOW_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.ROLE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_EMPLOYEE_ROLE_MAPPING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FLOW_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.ROLE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FLOW_PRESELECTION_AGENT>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AGENT_EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PRESELECTION_AGENT_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FOREIGN_WORK_TYPE>(entity =>
            {
                entity.HasKey(e => e.FOREIGN_WORK_TYPE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FOREIGN_WORK_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.FOREIGN_WORK_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.FOREIGN_WORK_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FOREIGN_WORK_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FOREIGN_WORK_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.FOREIGN_WORK_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.FOREIGN_WORK_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_FencePoints>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.PointsGroup).IsUnicode(false);
            });

            modelBuilder.Entity<HRM_HEALTH_ALLOWANCE>(entity =>
            {
                entity.HasKey(e => e.HEALTH_ALLOWANCE_CODE);

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIX_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HEALTH_ALLOWANCE_CNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_ALLOWANCE_LIMIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PARTIAL_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALID_DATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<HRM_HEALTH_ALLOWANCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HEALTH_ALLOWANCE_CODE)
                    .HasName("IDX_HEALTH_ALLOWANCE_CODE");

                entity.Property(e => e.COMPANY_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIX_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HEALTH_ALLOWANCE_CNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_ALLOWANCE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HEALTH_ALLOWANCE_LIMIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PARTIAL_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALID_DATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<HRM_HEALTH_LEAVE_CAUSE>(entity =>
            {
                entity.HasKey(e => e.HEALTH_LEAVE_CAUSE_CODE);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_RCODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_RNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_HEALTH_LEAVE_CAUSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HEALTH_LEAVE_CAUSE_CODE)
                    .HasName("IDX_HEALTH_LEAVE_CAUSE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_RCODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_RNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_LEAVE_CAUSE_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_HEALTH_RELATION>(entity =>
            {
                entity.HasKey(e => e.HEALTH_RELATION_ID);

                entity.HasIndex(e => e.HEALTH_RELATION_CODE)
                    .HasName("IDX_HEALTH_RELATION_CODE");

                entity.Property(e => e.HEALTH_RELATION_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_RELATION_CNAME).HasMaxLength(50);

                entity.Property(e => e.HEALTH_RELATION_CODE).HasMaxLength(50);

                entity.Property(e => e.HEALTH_RELATION_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_HIRE_WAY>(entity =>
            {
                entity.HasKey(e => e.HIRE_WAY_ID);

                entity.HasIndex(e => e.HIRE_WAY_CODE)
                    .HasName("IDX_HIRE_WAY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HIRE_WAY_CNAME).HasMaxLength(50);

                entity.Property(e => e.HIRE_WAY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HIRE_WAY_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_HIRE_WAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.HIRE_WAY_ID)
                    .HasName("IDX_HIRE_WAY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HIRE_WAY_CNAME).HasMaxLength(50);

                entity.Property(e => e.HIRE_WAY_CODE).HasMaxLength(50);

                entity.Property(e => e.HIRE_WAY_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_IDENTITY>(entity =>
            {
                entity.HasKey(e => e.IDENTITY_ID);

                entity.HasIndex(e => e.IDENTITY_CODE)
                    .HasName("IDX_IDENTITY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IDENTITY_CNAME).HasMaxLength(50);

                entity.Property(e => e.IDENTITY_CODE).HasMaxLength(50);

                entity.Property(e => e.IDENTITY_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_IDENTITY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.IDENTITY_ID)
                    .HasName("IDX_IDENTITY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IDENTITY_CNAME).HasMaxLength(50);

                entity.Property(e => e.IDENTITY_CODE).HasMaxLength(50);

                entity.Property(e => e.IDENTITY_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_COMPANY>(entity =>
            {
                entity.HasKey(e => e.INSURANCE_COMPANY_ID);

                entity.HasIndex(e => e.INSURANCE_COMPANY_CODE)
                    .HasName("IDX_INSURANCE_COMPANY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_INSTITUTION).HasMaxLength(50);

                entity.Property(e => e.HEALTH_INSURANCE_NO).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_CHAIRMAN).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_NAME).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_TEL).HasMaxLength(50);

                entity.Property(e => e.JOB_ACCIDENT_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LABOR_INSURANCE_CHECK_NO).HasMaxLength(50);

                entity.Property(e => e.LABOR_INSURANCE_NO).HasMaxLength(50);

                entity.Property(e => e.PAY_RATE).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.TAX_NO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_COMPANY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.INSURANCE_COMPANY_ID)
                    .HasName("IDX_INSURANCE_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_INSTITUTION).HasMaxLength(50);

                entity.Property(e => e.HEALTH_INSURANCE_NO).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_CHAIRMAN).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_CODE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_NAME).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_COMPANY_TEL).HasMaxLength(50);

                entity.Property(e => e.JOB_ACCIDENT_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LABOR_INSURANCE_CHECK_NO).HasMaxLength(50);

                entity.Property(e => e.LABOR_INSURANCE_NO).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PAY_RATE).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.TAX_NO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_LABOR_HELATH>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.IDNO, e.EXPENSE_YYMM, e.INSURANCE_EXPENSE_TYPE, e.INSURANCE_COMPANY_ID })
                    .HasName("PK_HRM_INSURANCE_LABOR_HELATH_1");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_YYMM).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_EXPENSE_TYPE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_BURDEN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPENSE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_LEVEL>(entity =>
            {
                entity.HasKey(e => e.INSURANCE_LEVEL_ID);

                entity.HasIndex(e => new { e.INSURANCE_LEVEL_TYPE, e.INSURANCE_LEVEL })
                    .HasName("IDX_INSURANCE_LEVEL_TYPE");

                entity.Property(e => e.BEGIN_VALID_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_VALID_DATE).HasColumnType("datetime");

                entity.Property(e => e.INSURANCE_LEVEL_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_LEVEL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.INSURANCE_LEVEL_ID)
                    .HasName("IDX_INSURANCE_LEVEL_ID");

                entity.Property(e => e.BEGIN_VALID_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_VALID_DATE).HasColumnType("datetime");

                entity.Property(e => e.INSURANCE_LEVEL_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_YEAR_SUMMARY>(entity =>
            {
                entity.HasKey(e => e.YEAR_SUMMARY_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.INSURANCE_YEAR })
                    .HasName("IDX_EMPLOYEE_ID_YEAR");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_GROUP_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_HEALTH_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_LABOR_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_SUPPLY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_YEAR)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INSURANCE_YEAR_SUMMARY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.YEAR_SUMMARY_ID)
                    .HasName("IDX_YEAR_SUMMARY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_GROUP_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_HEALTH_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_LABOR_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_SUPPLY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_YEAR)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INTRODUCE_COMPANY>(entity =>
            {
                entity.HasKey(e => e.INTRODUCE_COMPANY_ID);

                entity.Property(e => e.CHAIRMAN_CNAME).HasMaxLength(50);

                entity.Property(e => e.CHAIRMAN_ENAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ADDRESS_C).HasMaxLength(120);

                entity.Property(e => e.COMPANY_ADDRESS_E).HasMaxLength(120);

                entity.Property(e => e.COMPANY_POSTAL).HasMaxLength(50);

                entity.Property(e => e.CONTACT_NAME1).HasMaxLength(50);

                entity.Property(e => e.CONTACT_NAME2).HasMaxLength(50);

                entity.Property(e => e.CONTACT_TEL1).HasMaxLength(50);

                entity.Property(e => e.CONTACT_TEL2).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FAX).HasMaxLength(50);

                entity.Property(e => e.INTRODUCE_COMPANY_CNAME).HasMaxLength(50);

                entity.Property(e => e.INTRODUCE_COMPANY_ENAME).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_INTRODUCE_COMPANY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.INTRODUCE_COMPANY_ID)
                    .HasName("IDX_INTRODUCE_COMPANY_ID");

                entity.Property(e => e.CHAIRMAN_CNAME).HasMaxLength(50);

                entity.Property(e => e.CHAIRMAN_ENAME).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ADDRESS_C).HasMaxLength(120);

                entity.Property(e => e.COMPANY_ADDRESS_E).HasMaxLength(120);

                entity.Property(e => e.COMPANY_POSTAL).HasMaxLength(50);

                entity.Property(e => e.CONTACT_NAME1).HasMaxLength(50);

                entity.Property(e => e.CONTACT_NAME2).HasMaxLength(50);

                entity.Property(e => e.CONTACT_TEL1).HasMaxLength(50);

                entity.Property(e => e.CONTACT_TEL2).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FAX).HasMaxLength(50);

                entity.Property(e => e.INTRODUCE_COMPANY_CNAME).HasMaxLength(50);

                entity.Property(e => e.INTRODUCE_COMPANY_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB>(entity =>
            {
                entity.HasKey(e => e.JOB_ID)
                    .HasName("PK_JOB");

                entity.HasIndex(e => e.JOB_CODE)
                    .HasName("IDX_JOB_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_CNAME).HasMaxLength(50);

                entity.Property(e => e.JOB_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_CLASS>(entity =>
            {
                entity.HasKey(e => e.JOB_CLASS_ID);

                entity.HasIndex(e => e.JOB_CLASS_CODE)
                    .HasName("IDX_JOB_CLASS_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_CLASS_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_CLASS_NAME).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_CLASS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.JOB_CLASS_ID)
                    .HasName("IDX_JOB_CLASS_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_CLASS_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_CLASS_NAME).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_CONTENT>(entity =>
            {
                entity.HasKey(e => e.JOB_CONTENT_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_CONTENT_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_CONTENT_NAME).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_CONTENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_CONTENT_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_CONTENT_NAME).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_FUNCTION>(entity =>
            {
                entity.HasKey(e => e.JOB_FUNCTION_ID);

                entity.HasIndex(e => e.JOB_FUNCTION_CODE)
                    .HasName("IDX_JOB_FUNCTION_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_FUNCTION_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_FUNCTION_NAME).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_FUNCTION_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.JOB_FUNCTION_ID)
                    .HasName("IDX_FUNCTION_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_FUNCTION_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_FUNCTION_NAME).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_GRADE>(entity =>
            {
                entity.HasKey(e => e.GRADE_ID)
                    .HasName("PK_HRM_GRADE");

                entity.HasIndex(e => e.GRADE_CODE)
                    .HasName("IDX_GRADE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GRADE_CNAME).HasMaxLength(50);

                entity.Property(e => e.GRADE_CODE).HasMaxLength(50);

                entity.Property(e => e.GRADE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_GRADE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_GRADE_LOG");

                entity.HasIndex(e => e.GRADE_ID)
                    .HasName("IDX_GRADE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GRADE_CNAME).HasMaxLength(50);

                entity.Property(e => e.GRADE_CODE).HasMaxLength(50);

                entity.Property(e => e.GRADE_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_LEVEL>(entity =>
            {
                entity.HasKey(e => e.LEVEL_ID)
                    .HasName("PK_HRM_LEVEL");

                entity.HasIndex(e => e.LEVEL_CODE)
                    .HasName("IDX_LEVEL_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LEVEL_CNAME).HasMaxLength(50);

                entity.Property(e => e.LEVEL_CODE).HasMaxLength(50);

                entity.Property(e => e.LEVEL_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_LEVEL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_LEVEL_LOG");

                entity.HasIndex(e => e.LEVEL_ID)
                    .HasName("IDX_LEVEL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LEVEL_CNAME).HasMaxLength(50);

                entity.Property(e => e.LEVEL_CODE).HasMaxLength(50);

                entity.Property(e => e.LEVEL_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.JOB_ID)
                    .HasName("IDX_JOB_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_CNAME).HasMaxLength(50);

                entity.Property(e => e.JOB_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_WORK>(entity =>
            {
                entity.HasKey(e => e.JOB_WORK_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_WORK_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_WORK_NAME).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_JOB_WORK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_WORK_CODE).HasMaxLength(50);

                entity.Property(e => e.JOB_WORK_NAME).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_LABOR_ALLOWANCE>(entity =>
            {
                entity.HasKey(e => e.LABOR_ALLOWANCE_CODE);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.JOBLESS_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.JOB_ACCIDENT).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CNAME).HasMaxLength(50);

                entity.Property(e => e.NORMAL_ACCIDENT_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.PARTIAL_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PAY).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALID_DATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<HRM_LABOR_ALLOWANCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.LABOR_ALLOWANCE_CODE)
                    .HasName("IDX_LABOR_ALLOWANCE_CODE");

                entity.Property(e => e.COMPANY_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.JOBLESS_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.JOB_ACCIDENT).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CNAME).HasMaxLength(50);

                entity.Property(e => e.LABOR_ALLOWANCE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NORMAL_ACCIDENT_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.PARTIAL_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PAY).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALID_DATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<HRM_LEAVE_CAUSE>(entity =>
            {
                entity.HasKey(e => e.LEAVE_CAUSE_ID);

                entity.HasIndex(e => e.LEAVE_CAUSE_CODE)
                    .HasName("IDX_LEAVE_CAUSE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_COUNT_LEAVE_RATE).HasMaxLength(50);

                entity.Property(e => e.LEAVE_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LEAVE_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_LEAVE_CAUSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.LEAVE_CAUSE_ID)
                    .HasName("IDX_LEAVE_CAUSE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_COUNT_LEAVE_RATE).HasMaxLength(50);

                entity.Property(e => e.LEAVE_CAUSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.LEAVE_CAUSE_CODE).HasMaxLength(50);

                entity.Property(e => e.LEAVE_CAUSE_ENAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_LICENCE>(entity =>
            {
                entity.HasKey(e => e.LICENCE_ID);

                entity.HasIndex(e => e.LICENCE_CODE)
                    .HasName("IDX_LICENCE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LICENCE_CNAME).HasMaxLength(100);

                entity.Property(e => e.LICENCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LICENCE_ENAME).HasMaxLength(100);

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_LICENCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.LICENCE_ID)
                    .HasName("IDX_LICENCE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LICENCE_CNAME).HasMaxLength(100);

                entity.Property(e => e.LICENCE_CODE).HasMaxLength(50);

                entity.Property(e => e.LICENCE_ENAME).HasMaxLength(100);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_FORMAT>(entity =>
            {
                entity.HasKey(e => e.TAX_FORMAT_CODE);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FIX_TAX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOME_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MINIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.TAX_FORMAT_CNAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_FORMAT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.TAX_FORMAT_CODE)
                    .HasName("IDX_TAX_FORMAT_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FIX_TAX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOME_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MINIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.TAX_FORMAT_CNAME).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_ID_CODE>(entity =>
            {
                entity.HasKey(e => e.TAX_ID_CODE);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE_DESCRIPTION)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_ID_CODE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.TAX_ID_CODE)
                    .HasName("IDX_TAX_ID_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE_DESCRIPTION)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_INDUSTRIAL>(entity =>
            {
                entity.HasKey(e => e.TAX_INDUSTRIAL_CODE);

                entity.Property(e => e.TAX_INDUSTRIAL_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CNAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_INDUSTRIAL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.TAX_INDUSTRIAL_CODE)
                    .HasName("IDX_TAX_INDUSTRIAL_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CNAME).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_MONTH_FOREIGN>(entity =>
            {
                entity.HasKey(e => new { e.SERIAL_NO, e.YEAR_PAYMENT, e.MONTH_PAYMENT });

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);

                entity.Property(e => e.MONTH_PAYMENT).HasMaxLength(50);

                entity.Property(e => e.BEGIN_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_YYMM).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_YYMM).HasMaxLength(50);

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_MONTH_FOREIGN_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.LOG_ID).ValueGeneratedNever();

                entity.Property(e => e.BEGIN_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.MONTH_PAYMENT).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_OFFICE>(entity =>
            {
                entity.HasKey(e => new { e.TAX_CITY_CODE, e.TAX_OFFICE_CODE });

                entity.Property(e => e.TAX_CITY_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TAX_OFFICE_CNAME)
                    .IsRequired()
                    .HasMaxLength(62);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_OFFICE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX_OFFICE_CNAME)
                    .IsRequired()
                    .HasMaxLength(62);

                entity.Property(e => e.TAX_OFFICE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_PAYMENT_ITEM>(entity =>
            {
                entity.HasKey(e => new { e.TAX_PAYMENT_ITEM_CODE, e.TAX_FORMAT_CODE });

                entity.Property(e => e.TAX_PAYMENT_ITEM_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CNAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_PAYMENT_ITEM_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.TAX_PAYMENT_ITEM_CODE, e.TAX_FORMAT_CODE })
                    .HasName("IDX_TAX_PAYMENT_ITEM_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CNAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_PEOPLE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_CODE)
                    .HasName("PK_HRM_MEDIA_TAX_PEOPLE_1");

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMAIL).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_EMPLOYEE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.POSTCODE).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_PEOPLE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EMPLOYEE_CODE)
                    .HasName("IDX_EMPLOYEE_CODE");

                entity.Property(e => e.CELL_PHONE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMAIL).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_EMPLOYEE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.POSTCODE).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_YEAR_PEOPLE>(entity =>
            {
                entity.HasKey(e => e.MEDIA_TAX_PEOPLE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_EMPLOYEE_CODE_SALARY_YYMM");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUP_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HOUSE_TAX_NUMBER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(120);

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_YEAR_PEOPLE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_EMPLOYEE_CODE_SALARY_YYMM_SALARY_SEQ");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUP_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HOUSE_TAX_NUMBER).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(120);

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_YEAR_PEOPLE_TAX>(entity =>
            {
                entity.HasKey(e => new { e.SERIAL_NO, e.YEAR_PAYMENT });

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);

                entity.Property(e => e.BEGIN_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.END_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_YEAR_PEOPLE_TAX_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SERIAL_NO, e.YEAR_PAYMENT })
                    .HasName("IDX_SERIAL_NO_YEAR_PAYMENT");

                entity.Property(e => e.BEGIN_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.END_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SERIAL_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_INDUSTRIAL_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_PAYMENT_ITEM_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_YEAR_TAX>(entity =>
            {
                entity.HasKey(e => new { e.SERIAL_NO, e.YEAR_PAYMENT })
                    .HasName("PK_HRM_MEDIA_TAX_YEAR_TAX_1");

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);

                entity.Property(e => e.BEGIN_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_YYMM).HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.END_YYMM).HasMaxLength(50);

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TAX_YEAR_TAX_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SERIAL_NO, e.YEAR_PAYMENT })
                    .HasName("IDX_SERIAL_NO_YEAR_PAYMENT");

                entity.Property(e => e.BEGIN_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.RETIRE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TRANSFER>(entity =>
            {
                entity.HasKey(e => e.MEDIA_TRANSFER_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FILE_EXTENSION).HasMaxLength(10);

                entity.Property(e => e.FILE_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MEDIA_TRANSFER_NAME).HasMaxLength(50);

                entity.Property(e => e.SPLIT_TYPE).HasMaxLength(2);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_MEDIA_TRANSFER_DETAIL>(entity =>
            {
                entity.HasKey(e => e.MEDIA_TRANSFER_DETAIL_ID);

                entity.HasIndex(e => e.MEDIA_TRANSFER_ID)
                    .HasName("MEDIA_TRANSFER_ID");

                entity.Property(e => e.CLASSIFY)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATA_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DATE_FORMAT).HasMaxLength(10);

                entity.Property(e => e.NAME).HasMaxLength(50);

                entity.Property(e => e.PAD_CHAR)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PAD_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.USER_DEFINED)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YEAR_TYPE).HasMaxLength(10);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_DATA>(entity =>
            {
                entity.HasKey(e => e.PERFORMANCE_DATA_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_LEVEL_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_SCORE).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PERFORMANCE_TYPE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.PERFORMANCE_DATA_ID)
                    .HasName("IDX_PERFORMANCE_DATA_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_LEVEL_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_SCORE).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PERFORMANCE_TYPE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_ESOT_LEVELMAPPING>(entity =>
            {
                entity.HasKey(e => e.ESOT_LEVELMAPPING_ID);

                entity.HasIndex(e => e.PERFORMANCE_LEVEL_ID)
                    .HasName("IDX_PERFORMANCE_LEVEL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_ESOT_LEVELMAPPING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ESOT_LEVELMAPPING_ID)
                    .HasName("IDX_ESOT_LEVELMAPPING_ID");

                entity.Property(e => e.LOG_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_ESOT_YYMMMAPPING>(entity =>
            {
                entity.HasKey(e => e.ESOT_YYMMMAPPING_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_YYMM).HasMaxLength(10);

                entity.Property(e => e.SALARY_YYMM_E).HasMaxLength(10);

                entity.Property(e => e.SALARY_YYMM_S).HasMaxLength(10);

                entity.Property(e => e.START_YYMM).HasMaxLength(10);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_ESOT_YYMMMAPPING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ESOT_YYMMMAPPING_ID)
                    .HasName("IDX_ESOT_YYMMMAPPING_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_YYMM).HasMaxLength(10);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM_E).HasMaxLength(10);

                entity.Property(e => e.SALARY_YYMM_S).HasMaxLength(10);

                entity.Property(e => e.START_YYMM).HasMaxLength(10);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_LEVEL>(entity =>
            {
                entity.HasKey(e => e.PERFORMANCE_LEVEL_ID);

                entity.HasIndex(e => e.PERFORMANCE_LEVEL_CODE)
                    .HasName("IDX_PERFORMANCE_LEVEL_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MAXMUN_SCORE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MINIMUN_SCORE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PERFORMANCE_LEVEL_CNAME).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_LEVEL_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_LEVEL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.PERFORMANCE_LEVEL_ID)
                    .HasName("IDX_PERFORMANCE_LEVEL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MAXMUN_SCORE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MINIMUN_SCORE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PERFORMANCE_LEVEL_CNAME).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_LEVEL_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_TYPE>(entity =>
            {
                entity.HasKey(e => e.PERFORMANCE_TYPE_ID);

                entity.HasIndex(e => e.PERFORMANCE_TYPE_CODE)
                    .HasName("IDX_PERFORMANCE_TYPE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PERFORMANCE_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.PERFORMANCE_TYPE_ID)
                    .HasName("IDX_PERFORMANCE_TYPE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PROVINCE>(entity =>
            {
                entity.HasKey(e => e.PROVINCE_ID);

                entity.HasIndex(e => e.PROVINCE_CODE)
                    .HasName("IDX_PROVINCE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.PROVINCE_CNAME).HasMaxLength(50);

                entity.Property(e => e.PROVINCE_CODE).HasMaxLength(50);

                entity.Property(e => e.PROVINCE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PROVINCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.PROVINCE_ID)
                    .HasName("IDX_PROVINCE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PROVINCE_CNAME).HasMaxLength(50);

                entity.Property(e => e.PROVINCE_CODE).HasMaxLength(50);

                entity.Property(e => e.PROVINCE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_PunchCardRecord>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.ActionType).HasMaxLength(50);

                entity.Property(e => e.BDate).HasColumnType("datetime");

                entity.Property(e => e.ConnectType).HasMaxLength(50);

                entity.Property(e => e.FullTime).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.LocationGps).HasMaxLength(50);

                entity.Property(e => e.LocationIp).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.PunchType).HasMaxLength(50);

                entity.Property(e => e.TimeB).HasMaxLength(4);
            });

            modelBuilder.Entity<HRM_RELATION>(entity =>
            {
                entity.HasKey(e => e.RELATION_ID);

                entity.HasIndex(e => e.RELATION_CODE)
                    .HasName("IDX_RELATION_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_RELATION_CODE).HasMaxLength(50);

                entity.Property(e => e.RELATION_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RELATION_NAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_RELATION_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.RELATION_ID)
                    .HasName("IDX_RELATION_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_RELATION_CODE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RELATION_CODE).HasMaxLength(50);

                entity.Property(e => e.RELATION_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_RETIRE_RATE_TYPE>(entity =>
            {
                entity.HasKey(e => e.RETIRE_RATE_TYPE_ID);

                entity.Property(e => e.RETIRE_RATE_TYPE_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.RETIRE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.RETIRE_RATE_TYPE_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_REWARD>(entity =>
            {
                entity.HasKey(e => e.REWARD_ID);

                entity.HasIndex(e => e.REWARD_CODE)
                    .HasName("IDX_REWARD_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_SCORE).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.REWARD_CNAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_CODE).HasMaxLength(50);

                entity.Property(e => e.REWARD_ENAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_REWARD_KIND>(entity =>
            {
                entity.HasKey(e => e.REWARD_KIND_ID);

                entity.HasIndex(e => e.REWARD_KIND_CODE)
                    .HasName("IDX_REWARD_KIND_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_CNAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_CODE).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_ENAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_REWARD_KIND_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.REWARD_KIND_ID)
                    .HasName("IDX_REWARD_KIND_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_CNAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_CODE).HasMaxLength(50);

                entity.Property(e => e.REWARD_KIND_ENAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_REWARD_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.REWARD_ID)
                    .HasName("IDX_REWARD_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PERFORMANCE_SCORE).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.REWARD_CNAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_CODE).HasMaxLength(50);

                entity.Property(e => e.REWARD_ENAME).HasMaxLength(50);

                entity.Property(e => e.REWARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ABSENT>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_ID, e.DEDUCT_SALARY_ID, e.ABSENT_MINUS_ID, e.EMPLOYEE_ID, e.ABSENT_DATE, e.HOLIDAY_ID, e.BEGIN_TIME, e.END_TIME })
                    .HasName("PK_HRM_SALARY_ABSENT_1");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_EXPENSE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALBASE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ABSENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_EXPENSE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_TIME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALBASE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ACCOUNT>(entity =>
            {
                entity.HasKey(e => e.ACCOUNT_ID);

                entity.HasIndex(e => e.ACCOUNT_CODE)
                    .HasName("IDX_ACCOUNT_CODE");

                entity.Property(e => e.ACCOUNT_ATTRIBUTE).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_CNAME).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_CODE).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ACCOUNT_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.ACCOUNT_ID, e.EXPENSE_ID });

                entity.Property(e => e.ACCOUNT_CREDIT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_DEBIT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ACCOUNT_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.ACCOUNT_ID, e.EXPENSE_ID })
                    .HasName("IDX_ACCOUNT_ID_EXPENSE");

                entity.Property(e => e.ACCOUNT_CREDIT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_DEBIT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ACCOUNT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ACCOUNT_ID)
                    .HasName("IDX_ACCOUNT_ID");

                entity.Property(e => e.ACCOUNT_ATTRIBUTE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_CNAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_CODE).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_ENAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ASSESSMENT_PARAMETER>(entity =>
            {
                entity.HasKey(e => e.ASSESSMENT_PARAMETER_ID);

                entity.HasIndex(e => new { e.ASSESSMENT_PARAMETER_CODE, e.ASSESSMENT_PARAMETER_TYPE })
                    .HasName("IDX_ASSESSMENT_PARAMETER_CODE");

                entity.Property(e => e.ASSESSMENT_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.ASSESSMENT_PARAMETER_NAME).HasMaxLength(50);

                entity.Property(e => e.ASSESSMENT_PARAMETER_TYPE).HasMaxLength(2);

                entity.Property(e => e.COEFFICIENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ASSESSMENT_PARAMETER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ASSESSMENT_PARAMETER_ID)
                    .HasName("IDX_ASSESSMENT_PARAMETER_ID");

                entity.Property(e => e.ASSESSMENT_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.ASSESSMENT_PARAMETER_NAME).HasMaxLength(50);

                entity.Property(e => e.ASSESSMENT_PARAMETER_TYPE).HasMaxLength(2);

                entity.Property(e => e.COEFFICIENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ATTEND_DATA>(entity =>
            {
                entity.HasKey(e => new { e.EXPENSE_YYMM, e.SALARY_YYMM, e.COMPANY_ID, e.EMPLOYEE_ID, e.SALARY_ID });

                entity.Property(e => e.EXPENSE_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ATTEND_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_SALARY_ATTEND_DATA_LOG_1");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ATTEND_DAY_SET>(entity =>
            {
                entity.HasKey(e => e.ATTEND_DAY_SET_ID);

                entity.Property(e => e.BEGIN_MONTH_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_MONTH_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ATTEND_DAY_SET_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.ATTEND_DAY_SET_ID)
                    .HasName("IDX_ATTEND_DAY_SET_ID");

                entity.Property(e => e.BEGIN_MONTH_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_MONTH_TYPE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ATTRIBUTE>(entity =>
            {
                entity.HasKey(e => e.SALARY_ATTRIBUTE);

                entity.Property(e => e.SALARY_ATTRIBUTE).HasMaxLength(50);

                entity.Property(e => e.ATTRIBUTE_NAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BASIC)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FLAG)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NOT_DISP)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TYPE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BANK_TRANSFER>(entity =>
            {
                entity.HasKey(e => e.BANK_TRANSFER_ID);

                entity.Property(e => e.BANK_TRANSFER_NAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FILE_EXTENSION).HasMaxLength(10);

                entity.Property(e => e.FILE_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IS_SHOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.SPLIT_TYPE).HasMaxLength(2);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BANK_TRANSFER_CLIENT>(entity =>
            {
                entity.HasKey(e => e.TRANSFER_CLIENT_ID);

                entity.Property(e => e.CLIENT_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GIRO_ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_GROUP).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BANK_TRANSFER_CLIENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CLIENT_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COMPANY_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_GROUP).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BANK_TRANSFER_DETAIL>(entity =>
            {
                entity.HasKey(e => e.BANK_TRANSFER_DETAIL_ID)
                    .HasName("PK_HRM_SALARY_BANK_TRANSFER_1");

                entity.HasIndex(e => e.BANK_TRANSFER_ID)
                    .HasName("IDX_BANK_TRANSFER_ID");

                entity.Property(e => e.CLASSIFY)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATA_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DATE_FORMAT).HasMaxLength(10);

                entity.Property(e => e.NAME).HasMaxLength(50);

                entity.Property(e => e.PAD_CHAR)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PAD_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.USER_DEFINED)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YEAR_TYPE).HasMaxLength(10);
            });

            modelBuilder.Entity<HRM_SALARY_BANK_TRANSFER_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BANK_TRANSFER_DETAIL_ID)
                    .HasName("IDX_BANK_TRANSFER_DETAIL_ID");

                entity.Property(e => e.CLASSIFY)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATA_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DATE_FORMAT).HasMaxLength(10);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NAME).HasMaxLength(50);

                entity.Property(e => e.PAD_CHAR)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PAD_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.USER_DEFINED)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YEAR_TYPE).HasMaxLength(10);
            });

            modelBuilder.Entity<HRM_SALARY_BANK_TRANSFER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BANK_TRANSFER_ID)
                    .HasName("IDX_BANK_TRANSFER_ID");

                entity.Property(e => e.BANK_TRANSFER_NAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FILE_EXTENSION).HasMaxLength(10);

                entity.Property(e => e.FILE_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SPLIT_TYPE).HasMaxLength(2);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BASESALARY>(entity =>
            {
                entity.HasKey(e => e.BASESALARY_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BASESALARY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.BASESALARY_ID)
                    .HasName("IDX_BASESALARY_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_BASETTS>(entity =>
            {
                entity.HasKey(e => e.SALARY_BASETTS_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID_EFFECT");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPENDENTS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WITHHOLDING_INCOMETAX).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HRM_SALARY_BASETTS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_BASETTS_ID)
                    .HasName("IDX_SALARY_BASETTS_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPENDENTS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WITHHOLDING_INCOMETAX).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HRM_SALARY_COURT_DEDUCT_DATA>(entity =>
            {
                entity.HasKey(e => new { e.COURT_DEDUCT_ID, e.EMPLOYEE_ID, e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ })
                    .HasName("PK_HRM_SALARY_COURT_DEDUCT_DATA_1");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_COURT_DEDUCT_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.COURT_DEDUCT_ID, e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_HRM_SALARY_COURT_DEDUCT_DATA_LOG");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_COURT_DEDUCT_SET>(entity =>
            {
                entity.HasKey(e => e.COURT_DEDUCT_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.BEGIN_YYMM).HasMaxLength(50);

                entity.Property(e => e.CLOSE_DATE).HasColumnType("date");

                entity.Property(e => e.COMBINE_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURT_DEDUCT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURT_ORGANIZER).HasMaxLength(50);

                entity.Property(e => e.COURT_TEL).HasMaxLength(50);

                entity.Property(e => e.COURT_UNDERTAKER).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEBIT_ACCOUNT_NAME).HasMaxLength(200);

                entity.Property(e => e.DEBIT_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.DEBIT_COMPANY).HasMaxLength(200);

                entity.Property(e => e.DEBIT_TEL).HasMaxLength(50);

                entity.Property(e => e.DECLARE_DATE).HasColumnType("date");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_YYMM).HasMaxLength(50);

                entity.Property(e => e.INSTALLMENT_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ISSUE_DATE).HasColumnType("date");

                entity.Property(e => e.LOW_SPEND).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MEMO).HasMaxLength(120);

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("date");

                entity.Property(e => e.REFERENCE_NO).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_COURT_DEDUCT_SET_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COURT_DEDUCT_ID)
                    .HasName("IDX_COURT_DEDUCT_ID");

                entity.Property(e => e.BEGIN_YYMM).HasMaxLength(50);

                entity.Property(e => e.CLOSE_DATE).HasColumnType("date");

                entity.Property(e => e.COMBINE_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURT_DEDUCT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURT_ORGANIZER).HasMaxLength(50);

                entity.Property(e => e.COURT_TEL).HasMaxLength(50);

                entity.Property(e => e.COURT_UNDERTAKER).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEBIT_ACCOUNT_NAME).HasMaxLength(200);

                entity.Property(e => e.DEBIT_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.DEBIT_COMPANY).HasMaxLength(200);

                entity.Property(e => e.DEBIT_TEL).HasMaxLength(50);

                entity.Property(e => e.DECLARE_DATE).HasColumnType("date");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_YYMM).HasMaxLength(50);

                entity.Property(e => e.INSTALLMENT_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ISSUE_DATE).HasColumnType("date");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.LOW_SPEND).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MEMO).HasMaxLength(120);

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("date");

                entity.Property(e => e.REFERENCE_NO).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_DUTY_ALLOWANCE>(entity =>
            {
                entity.HasKey(e => e.DUTY_ALLOWANCE_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_DUTY_ALLOWANCE_FLOW>(entity =>
            {
                entity.HasKey(e => e.DUTY_ALLOWANCE_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.ATTEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_DUTY_ALLOWANCE_FLOW_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.APPLICATE_ROLE).HasMaxLength(50);

                entity.Property(e => e.APPLICATE_USER).HasMaxLength(50);

                entity.Property(e => e.ATTEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FLOW_CONTENT).HasMaxLength(500);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_DUTY_ALLOWANCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ENRICH>(entity =>
            {
                entity.HasKey(e => e.SALARY_ENRICH_ID);

                entity.HasIndex(e => new { e.COMPANY_ID, e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ, e.SALARY_ID })
                    .HasName("IDX_HRM_SALARY_ENRICH");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ENRICH_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_ENRICH_ID)
                    .HasName("IDX_SALARY_ENRICH_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_EXPRESSION_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.EXPRESSION_CODE, e.PARAMETER_CODE })
                    .HasName("PK_HRM_SALARY_EXPRESSION_DETAIL_1");

                entity.Property(e => e.EXPRESSION_CODE).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_FORMULA).HasMaxLength(200);

                entity.Property(e => e.PARAMETER_MEMO).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_TITLE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CODE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_EXPRESSION_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EXPRESSION_CODE, e.PARAMETER_CODE })
                    .HasName("IDX_EXPRESSION_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PARAMETER_FORMULA)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PARAMETER_MEMO).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_TITLE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CODE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_EXPRESSION_MASTER>(entity =>
            {
                entity.HasKey(e => e.EXPRESSION_CODE);

                entity.Property(e => e.EXPRESSION_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_CNAME).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_ENAME).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_FORMULA).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_EXPRESSION_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.EXPRESSION_CODE)
                    .HasName("IDX_EXPRESSION_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_CNAME).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_ENAME).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_FORMULA).HasMaxLength(200);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_EXPRESSION_SYSTEM>(entity =>
            {
                entity.HasKey(e => new { e.EXPRESSION_CODE, e.SYSTEM_PARAMETER_CODE });

                entity.Property(e => e.EXPRESSION_CODE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_PARAMETER_MEMO).HasMaxLength(100);

                entity.Property(e => e.SYSTEM_PARAMETER_TITLE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_EXPRESSION_SYSTEM_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EXPRESSION_CODE, e.SYSTEM_PARAMETER_CODE })
                    .HasName("IDX_EXPRESSION_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EXPRESSION_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_PARAMETER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SYSTEM_PARAMETER_MEMO).HasMaxLength(100);

                entity.Property(e => e.SYSTEM_PARAMETER_TITLE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FESTIVAL>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.EFFECT_YYMM })
                    .HasName("PK_HRM_SALARY_FESTIVAL_1");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EFFECT_YYMM).HasMaxLength(50);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_SEQ).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FESTIVAL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_YYMM })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_SEQ).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FESTIVAL_MONTH>(entity =>
            {
                entity.HasKey(e => e.FESTIVAL_MONTH)
                    .HasName("PK_HRM_SALARY_FESTIVAL_MONTH_1");

                entity.Property(e => e.FESTIVAL_MONTH).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FESTIVAL_MONTH_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.FESTIVAL_MONTH)
                    .HasName("IDX_FESTIVAL_MONTH");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FIXED_DEDUCT_DATA>(entity =>
            {
                entity.HasKey(e => e.FIXED_DEDUCT_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FIXED_DEDUCT_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FIX_DEDUCT>(entity =>
            {
                entity.HasKey(e => e.FIX_DEDUCT_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.BEGIN_EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FIX_DEDUCT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.FIX_DEDUCT_ID)
                    .HasName("IDX_FIX_DEDUCT_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FORGET_CARD_CAUSE>(entity =>
            {
                entity.HasKey(e => e.FORGET_CARD_CAUSE_ID);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).ValueGeneratedNever();

                entity.Property(e => e.AMT).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FORGET_CARD_CAUSE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.FORGET_CARD_CAUSE_ID)
                    .HasName("IDX_FORGET_CARD_CAUSE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FUND_TRANSFER>(entity =>
            {
                entity.HasKey(e => e.FUND_TRANSFER_ID)
                    .HasName("PK_HRM_SALARY_FUND_TRANSFER_1");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.ACCOUNT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACCOUNT_QUOTA).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.AMT)
                    .HasColumnType("decimal(16, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_BANK_ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_FUND_TRANSFER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.FUND_TRANSFER_ID)
                    .HasName("IDX_FUND_TRANSFER_ID");

                entity.Property(e => e.ACCOUNT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACCOUNT_QUOTA).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.AMT)
                    .HasColumnType("decimal(16, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_BANK_ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GRADE_LEVEL>(entity =>
            {
                entity.HasKey(e => new { e.GRADE_ID, e.LEVEL_ID });

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GRADE_LEVEL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.GRADE_ID, e.LEVEL_ID })
                    .HasName("IDX_GRADE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GROUP_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_GROUP_MASTER_ID, e.GROUP_PARAMETER_CODE });

                entity.Property(e => e.GROUP_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GROUP_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SALARY_GROUP_MASTER_ID, e.GROUP_PARAMETER_CODE })
                    .HasName("IDX_SALARY_GROUP_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_PARAMETER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GROUP_MASTER>(entity =>
            {
                entity.HasKey(e => e.SALARY_GROUP_MASTER_ID);

                entity.HasIndex(e => e.GROUP_MASTER_CODE)
                    .HasName("IDX_GROUP_MASTER_CODE");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("date");

                entity.Property(e => e.GROUP_MASTER_CNAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GROUP_MASTER_ENAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_SEQ).HasDefaultValueSql("((0))");

                entity.Property(e => e.IS_GROUP)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GROUP_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_GROUP_MASTER_ID)
                    .HasName("IDX_SALARY_GROUP_MASTER_ID");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("date");

                entity.Property(e => e.GROUP_MASTER_CNAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GROUP_MASTER_ENAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_MASTER_SEQ).HasDefaultValueSql("((0))");

                entity.Property(e => e.IS_GROUP)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_GROUP_PARAMETER>(entity =>
            {
                entity.HasKey(e => e.GROUP_PARAMETER_CODE);

                entity.Property(e => e.GROUP_PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.DEFAULT_VALUE).HasMaxLength(50);

                entity.Property(e => e.GROUP_PARAMETER_CNAME).HasMaxLength(50);

                entity.Property(e => e.GROUP_PARAMETER_ENAME).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.VALIDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_HOLIDAY_ESTIMATE_EMPLOYEE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ID);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_HOLIDAY_OVERTIME_DATA_DETAIL>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_OVERTIME_DATA_DETAIL_ID);

                entity.HasIndex(e => new { e.HOLIDAY_OVERTIME_DATA_MASTER_ID, e.SEQ })
                    .HasName("IDX_HOLIDAY_OVERTIME_DATA_MASTER_ID");

                entity.Property(e => e.FIXED_AMT).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.HOURS).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.OVERTIME_EXPENSE).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.RATE_NUM).HasColumnType("decimal(12, 6)");
            });

            modelBuilder.Entity<HRM_SALARY_HOLIDAY_OVERTIME_DATA_MASTER>(entity =>
            {
                entity.HasKey(e => e.HOLIDAY_OVERTIME_DATA_MASTER_ID);

                entity.HasIndex(e => new { e.SALARY_YYMM, e.SALARY_SEQ, e.HOLIDAY_OVERTIME_ID, e.EMPLOYEE_ID, e.OVERTIME_DATE })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_HOURS).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.HOURLY_RATE).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("date");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.OVERTIME_YYMM).HasMaxLength(50);

                entity.Property(e => e.RATE_HOURS_BEGIN).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_INCOMETAX>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ, e.EMPLOYEE_ID });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INCOME_AMOUNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.SALARY_AMOUNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_INCOMETAX_FOREIGNER>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ, e.EMPLOYEE_ID });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_INSURANCE_SALARY>(entity =>
            {
                entity.HasKey(e => e.INSURANCE_SALARY_ID);

                entity.Property(e => e.ACTION_LIST).HasMaxLength(200);

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_INSURANCE_SETTLEMENT>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_ID, e.SALARY_YYMM });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_INSURANCE_SETTLEMENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_JOB_LEVEL_ALLOWANCE>(entity =>
            {
                entity.HasKey(e => new { e.LEVEL_ID, e.GRADE_ID })
                    .HasName("PK_HRM_JOB_LEVEL_ALLOWANCE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_LEVEL_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_JOB_LEVEL_ALLOWANCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_JOB_LEVEL_ALLOWANCE_LOG");

                entity.HasIndex(e => new { e.LEVEL_ID, e.GRADE_ID })
                    .HasName("IDX_LEVEL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.JOB_LEVEL_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_LABOR_HELATH>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.EMPLOYEE_ID, e.EMPLOYEE_FAMILY_IDNO, e.EXPENSE_YYMM, e.SALARY_SEQ, e.ALLOWANCE_CODE, e.INSURANCE_EXPENSE_TYPE, e.INSURANCE_COMPANY_ID });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ALLOWANCE_CODE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_EXPENSE_TYPE).HasMaxLength(50);

                entity.Property(e => e.COMPANY_BURDEN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXPENSE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FUND_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.INSURANCE_KIND).HasMaxLength(50);

                entity.Property(e => e.JOB_DISASTER_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_LABOR_HELATH_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ALLOWANCE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COMPANY_BURDEN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DAYS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_FAMILY_IDNO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EXPENSE_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FUND_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.INSURANCE_EXPENSE_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.INSURANCE_KIND).HasMaxLength(50);

                entity.Property(e => e.JOB_DISASTER_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_LICENSE_ALLOWANCE_SET>(entity =>
            {
                entity.HasKey(e => e.LICENSE_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_LICENSE_ALLOWANCE_SET_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.BEGIN_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_LICENSE_ALLOWANCE_TYPE>(entity =>
            {
                entity.HasKey(e => e.LICENSE_TYPE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LICENSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_LICENSE_ALLOWANCE_TYPE_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LICENSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_MANAGER>(entity =>
            {
                entity.HasKey(e => e.SALARY_MANAGER_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATE_FROM).HasColumnType("date");

                entity.Property(e => e.DATE_TO).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_MANAGER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DATE_FROM).HasColumnType("date");

                entity.Property(e => e.DATE_TO).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_MONTHPAY_HISTORY>(entity =>
            {
                entity.HasKey(e => e.MONTHPAY_HISTORY_ID);

                entity.Property(e => e.DATA_CONTENT).HasColumnType("xml");

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN).HasMaxLength(50);

                entity.Property(e => e.MONTHPAY_TYPE)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_MONTHPAY_SETTLEMENT>(entity =>
            {
                entity.HasKey(e => e.SALARY_YYMM);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_MONTHPAY_SETTLEMENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_YYMM)
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_ABSENT>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_ABSENT_ID);

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_ABSENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_ABSENT_ID)
                    .HasName("IDX_OVERTIME_ABSENT_ID");

                entity.Property(e => e.ABSENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_DATA_DETAIL>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_DATA_DETAIL_ID)
                    .HasName("PK_HRM_SALARY_OVERTIME_DATA_DETAIL_1");

                entity.HasIndex(e => e.OVERTIME_DATA_MASTER_ID)
                    .HasName("IDX_OVERTIME_DATA_MASTER_ID");

                entity.Property(e => e.FIXED_AMT).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.HOURS).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.OVERTIME_EXPENSE).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.RATE_NUM).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_DATA_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_DATA_DETAIL_ID)
                    .HasName("IDX_OVERTIME_DATA_DETAIL_ID");

                entity.Property(e => e.FIXED_AMT).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.HOURS).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_EXPENSE).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.RATE_NUM).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_DATA_MASTER>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_DATA_MASTER_ID);

                entity.HasIndex(e => e.OVERTIME_ID)
                    .HasName("IDX_OVERTIME_ID");

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.COMPANY_ID })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DUTYFREE_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DUTYFREE_HOUR).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_HOURS).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.HOURLY_RATE).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("date");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.OVERTIME_YYMM).HasMaxLength(50);

                entity.Property(e => e.RATE_HOURS_BEGIN).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAXABLE_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TAXABLE_HOUR).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_DATA_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_DATA_MASTER_ID)
                    .HasName("IDX_OVERTIME_DATA_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DUTYFREE_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DUTYFREE_HOUR).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EXPENSE_HOURS).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.HOURLY_RATE).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("date");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.OVERTIME_YYMM).HasMaxLength(50);

                entity.Property(e => e.RATE_HOURS_BEGIN).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SALARY_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAXABLE_AMT).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TAXABLE_HOUR).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATEFIXED_DETAIL>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_RATEFIXED_DETAIL_ID);

                entity.HasIndex(e => new { e.OVERTIME_RATEFIXED_MASTER_ID, e.EMPLOYEE_ID })
                    .HasName("IDX_OVERTIME_RATEFIXED_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATEFIXED_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_RATEFIXED_DETAIL_ID)
                    .HasName("IDX_OVERTIME_RATEFIXED_DETAIL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATEFIXED_MASTER>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_RATEFIXED_MASTER_ID)
                    .HasName("PK_HRM_SALARY_OVERTIME_RATEFIXED_MASTER_1");

                entity.HasIndex(e => new { e.EFFECT_DATE, e.COMPANY_ID, e.ROTE_ID, e.CALENDAR_ID, e.OVERTIME_RATE_MASTER_ID })
                    .HasName("IDX_EFFECT_DATE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATEFIXED_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.OVERTIME_RATEFIXED_MASTER_ID, e.EFFECT_DATE, e.OVERTIME_RATE_MASTER_ID, e.COMPANY_ID, e.ROTE_ID, e.CALENDAR_ID })
                    .HasName("IDX_OVERTIME_RATEFIXED_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATE_DETAIL>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_RATE_DETAIL_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_MASTER_ID)
                    .HasName("IDX_OVERTIME_RATE_MASTER_ID");

                entity.Property(e => e.BEGIN_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIXED_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.RATE_NUM).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATE_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.OVERTIME_RATE_DETAIL_ID, e.OVERTIME_RATE_MASTER_ID })
                    .HasName("IDX_OVERTIME_RATE_DETAIL_ID");

                entity.Property(e => e.BEGIN_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.END_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIXED_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RATE_NUM).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATE_MASTER>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_RATE_MASTER_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_CODE)
                    .HasName("IDX_OVERTIME_RATE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LIMIT_MINUTE).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OVERTIME_RATE_CNAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_CODE).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_ENAME).HasMaxLength(50);

                entity.Property(e => e.SPAN_MINUTE).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATE_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_MASTER_ID)
                    .HasName("IDX_OVERTIME_RATE_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LIMIT_MINUTE).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_CNAME).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_CODE).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_RATE_ENAME).HasMaxLength(50);

                entity.Property(e => e.SPAN_MINUTE).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATE_PATCH>(entity =>
            {
                entity.HasKey(e => e.OVERTIME_RATE_PATCH_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_MASTER_ID)
                    .HasName("IDX_OVERTIME_RATE_MASTER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOUR_BEGIN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HOUR_END).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_REST_HOUR).HasMaxLength(50);

                entity.Property(e => e.PATCH_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_OVERTIME_RATE_PATCH_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.OVERTIME_RATE_PATCH_ID)
                    .HasName("IDX_OVERTIME_RATE_PATCH_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HOUR_BEGIN).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HOUR_END).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_REST_HOUR).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PATCH_HOUR).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_CALCULATOR>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_ID, e.USERID });

                entity.Property(e => e.USERID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_CALCULATOR_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_HISTORY>(entity =>
            {
                entity.HasKey(e => e.PAYROLL_HISTORY_ID)
                    .HasName("PK_HRM_SALARY_PAYROLL_HISTORY_1");

                entity.Property(e => e.DATA_CONTENT).HasColumnType("xml");

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN).HasMaxLength(50);

                entity.Property(e => e.PAYROLL_TYPE).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("PK_HRM_SALARY_PAYROLL_SETTLEMENT_1");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_ID, e.SALARY_YYMM, e.SALARY_PAY_TYPE });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_HISTORY>(entity =>
            {
                entity.HasKey(e => e.SETTLEMENT_HISTORY_ID);

                entity.Property(e => e.DATA_CONTENT).HasColumnType("xml");

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXECUTE_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_ID, e.SALARY_YYMM });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_ID, e.SALARY_YYMM, e.SALARY_PAY_TYPE });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_HISTORY>(entity =>
            {
                entity.HasKey(e => e.SETTLEMENT_HISTORY_ID);

                entity.Property(e => e.DATA_CONTENT).HasColumnType("xml");

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXECUTE_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PERFORMANCE>(entity =>
            {
                entity.HasKey(e => e.SALARY_PERFORMANCE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.PAY_DATE).HasColumnType("datetime");

                entity.Property(e => e.PERFORMANCE_AMT).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PERFORMANCE_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_PERFORMANCE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.PAY_DATE).HasColumnType("datetime");

                entity.Property(e => e.PERFORMANCE_AMT).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PERFORMANCE_YYMM).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_REPORT_DEPT>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<HRM_SALARY_REPORT_DEPTC>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<HRM_SALARY_ROTE_ALLOWANCE_DATA>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.EMPLOYEE_ID, e.ATTEND_DATE, e.ROTE_ID, e.SALARY_ID });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ATTEND_DATE).HasColumnType("date");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ROTE_ALLOWANCE_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ROTE_ALLOWANCE_SET>(entity =>
            {
                entity.HasKey(e => new { e.ROTE_ID, e.SALARY_ID });

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ROTE_ALLOWANCE_SET_COMPANY>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ROTE_ALLOWANCE_SET_COMPANY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_ROTE_ALLOWANCE_SET_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.ROTE_ID, e.SALARY_ID })
                    .HasName("IDX_ROTE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_BASETTS>(entity =>
            {
                entity.HasKey(e => e.SALBASE_BASETTS_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.EFFECT_DATE })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_BASETTS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALBASE_BASETTS_ID)
                    .HasName("IDX_SALBASE_BASETTS_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_EXPATRIATE_BASETTS>(entity =>
            {
                entity.HasKey(e => e.SALBASE_EXPATRIATE_BASETTS);

                entity.Property(e => e.AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXCHANGE_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FOREIGN_AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_EXPATRIATE_BASETTS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EXCHANGE_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FOREIGN_AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_MAPPING_DETAIL>(entity =>
            {
                entity.HasKey(e => e.SALBASE_MAPPING_ID);

                entity.HasIndex(e => e.SALBASE_MAPPING_CODE)
                    .HasName("SALBASE_MAPPING_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MAPPING_FIELD_VALUE).HasMaxLength(50);

                entity.Property(e => e.MAPPING_TEXT).HasMaxLength(50);

                entity.Property(e => e.MAPPING_VALUE).HasMaxLength(50);

                entity.Property(e => e.SALBASE_MAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_MAPPING_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALBASE_MAPPING_ID)
                    .HasName("IDX_SALBASE_MAPPING_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MAPPING_FIELD_VALUE).HasMaxLength(50);

                entity.Property(e => e.MAPPING_TEXT).HasMaxLength(50);

                entity.Property(e => e.MAPPING_VALUE).HasMaxLength(50);

                entity.Property(e => e.SALBASE_MAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_MAPPING_MASTER>(entity =>
            {
                entity.HasKey(e => e.SALBASE_MAPPING_CODE);

                entity.Property(e => e.SALBASE_MAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MAPPING_FIELD).HasMaxLength(50);

                entity.Property(e => e.SALBASE_MAPPING_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALBASE_MAPPING_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALBASE_MAPPING_CODE)
                    .HasName("IDX_SALBASE_MAPPING_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MAPPING_FIELD).HasMaxLength(50);

                entity.Property(e => e.SALBASE_MAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALBASE_MAPPING_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALCODE>(entity =>
            {
                entity.HasKey(e => e.SALARY_ID);

                entity.HasIndex(e => e.SALARY_CODE)
                    .HasName("IDX_SALARY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_DEDUCT).HasComment("是否為 代扣項目");

                entity.Property(e => e.IS_DUTY)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("應免稅");

                entity.Property(e => e.MERGE_SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_ENAME).HasMaxLength(60);

                entity.Property(e => e.SIGN)
                    .HasDefaultValueSql("((1))")
                    .HasComment("正負值 +1 -1");

                entity.Property(e => e.TAX_RATE).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALCODE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_ID)
                    .HasName("IDX_SALARY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_DEDUCT)
                    .HasDefaultValueSql("((0))")
                    .HasComment("是否為 代扣項目");

                entity.Property(e => e.IS_DUTY)
                    .HasDefaultValueSql("((1))")
                    .HasComment("應免稅");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MERGE_SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CODE).HasMaxLength(50);

                entity.Property(e => e.SALARY_ENAME).HasMaxLength(60);

                entity.Property(e => e.SIGN)
                    .HasDefaultValueSql("((1))")
                    .HasComment("正負值 +1 -1");

                entity.Property(e => e.TAX_RATE).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALCODE_MERGE>(entity =>
            {
                entity.HasKey(e => e.SALARY_MERGE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALCODE_MERGE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_MERGE_ID)
                    .HasName("IDX_SALARY_MERGE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALMAPPING_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.SALMAPPING_CODE, e.SALARY_ID });

                entity.Property(e => e.SALMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALMAPPING_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SALMAPPING_CODE, e.SALARY_ID })
                    .HasName("IDX_HRM_SALARY_SALMAPPING_DETAIL_LOG");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALMAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALMAPPING_MASTER>(entity =>
            {
                entity.HasKey(e => e.SALMAPPING_CODE);

                entity.Property(e => e.SALMAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.SALMAPPING_TITLE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SALMAPPING_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALMAPPING_CODE)
                    .HasName("IDX_SALMAPPING_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.SALMAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALMAPPING_TITLE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SETTLEMENT_SALARY>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_PAYTYPE })
                    .HasName("PK_HRM_SALARY_PAYROLL_SALARY");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAYTYPE).HasMaxLength(50);

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SETTLEMENT_SALARY_HISTORY>(entity =>
            {
                entity.HasKey(e => e.SALARY_HISTORY_ID)
                    .HasName("PK_HRM_SALARY_PAYROLL_HISTORY");

                entity.Property(e => e.DATA_CONTENT).HasColumnType("xml");

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN).HasMaxLength(50);

                entity.Property(e => e.PAYROLL_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_PAYTYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SETTLEMENT_SALARY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_SALARY_PAYROLL_SALARY_LOG");

                entity.HasIndex(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_PAYTYPE })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.ARRIVE_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PAYTYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SETTLEMENT_WAGE>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.SALARY_SEQ, e.COMPANY_ID, e.SALARY_PAYTYPE })
                    .HasName("PK_HRM_SALARY_PAYROLL_WAGE");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SALARY_PAYTYPE).HasMaxLength(50);

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.TAX_FORMAT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SETTLEMENT_WAGE_HISTORY>(entity =>
            {
                entity.HasKey(e => e.WAGE_HISTORY_ID);

                entity.Property(e => e.DATA_CONTENT).HasColumnType("xml");

                entity.Property(e => e.EXECUTE_DATE).HasColumnType("datetime");

                entity.Property(e => e.EXECUTE_MAN).HasMaxLength(50);

                entity.Property(e => e.PAYROLL_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_PAYTYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SETTLEMENT_WAGE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_SALARY_PAYROLL_WAGE_LOG");

                entity.HasIndex(e => new { e.SALARY_YYMM, e.SALARY_SEQ, e.COMPANY_ID, e.SALARY_PAYTYPE })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAYTYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.TAX_FORMAT_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_STOCK_TRUST>(entity =>
            {
                entity.HasKey(e => e.STOCK_TRUST_ID);

                entity.HasIndex(e => new { e.SALARY_YYMM, e.SALARY_SEQ, e.EMPLOYEE_ID, e.EXPENSE_TYPE, e.SALARY_ID })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SUPPLY>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ, e.SALARY_ID });

                entity.HasIndex(e => new { e.COMPANY_ID, e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ, e.SALARY_ID })
                    .HasName("idx_company_id");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_AMT).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.PAYMENT_AMT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.PAYMENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.SUPPLY_AMT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.TAX_FORMAT).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_SUPPLY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ, e.SALARY_ID })
                    .HasName("IDX_HRM_SALARY_SUPPLY_LOG");

                entity.Property(e => e.BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_HEALTH_AMT).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.END_DATE).HasColumnType("datetime");

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.PAYMENT_AMT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.PAYMENT_DATE).HasColumnType("datetime");

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SUPPLY_AMT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.TAX_FORMAT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_TAX_LEVEL>(entity =>
            {
                entity.HasKey(e => e.TAX_LEVEL_ID);

                entity.HasIndex(e => e.YEAR)
                    .HasName("IDX_YEAR");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOWER_LIMIT_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER0).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER1).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER10).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER11).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER2).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER3).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER4).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER5).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER6).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER7).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER8).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER9).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_LIMIT_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.YEAR)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_TAX_LEVEL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.TAX_LEVEL_ID)
                    .HasName("IDX_TAX_LEVEL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.LOWER_LIMIT_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER0).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER1).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER10).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER11).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER2).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER3).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER4).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER5).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER6).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER7).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER8).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PER9).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_LIMIT_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.YEAR)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_TEMPWORK_SALARY>(entity =>
            {
                entity.HasKey(e => e.TEMPWORK_SALARY_ID);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_DATE).HasColumnType("date");
            });

            modelBuilder.Entity<HRM_SALARY_TYPE>(entity =>
            {
                entity.HasKey(e => e.SALARY_TYPE_CODE);

                entity.Property(e => e.SALARY_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_DEFINE1).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_TYPE_DEFINE2).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_TYPE_DEFINE3).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_TYPE_NAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_PARA1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_PARA2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_PARA3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SALARY_TYPE_CODE)
                    .HasName("IDX_SALARY_TYPE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_DEFINE1).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_TYPE_DEFINE2).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_TYPE_DEFINE3).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_TYPE_NAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_PARA1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_PARA2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_TYPE_PARA3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_VARIABLEPAY_DATA>(entity =>
            {
                entity.HasKey(e => new { e.SOURCE_CODE, e.SALARY_YYMM, e.COMPANY_ID, e.EMPLOYEE_ID, e.SALARY_ID });

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_VARIABLEPAY_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SOURCE_CODE, e.SALARY_YYMM, e.COMPANY_ID, e.EMPLOYEE_ID, e.SALARY_ID })
                    .HasName("IDX_HRM_SALARY_VARIABLEPAY_DATA_LOG");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_VARIABLEPAY_SOURCE>(entity =>
            {
                entity.HasKey(e => e.SOURCE_CODE);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.SOURCE_MEMO).HasMaxLength(200);

                entity.Property(e => e.SOURCE_TITLE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_WAGE>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ, e.EMPLOYEE_ID });

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.CALCULATE_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CALCULATE_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.CASH)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MEMO)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NOT_COUNT_SALARY).HasMaxLength(50);

                entity.Property(e => e.SALARY_FLAG).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TAX_RATE)
                    .HasColumnType("decimal(16, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TRANSFER_BANK_ACCOUNT)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TRANSFER_BANK_ID).HasDefaultValueSql("((0))");

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_DAYS)
                    .HasColumnType("decimal(16, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<HRM_SALARY_WAGE_DETAIL>(entity =>
            {
                entity.HasKey(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ, e.SALARY_ID, e.COMPANY_ID });

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_WAGE_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ, e.SALARY_ID })
                    .HasName("IDX_HRM_SALARY_WAGE_DETAIL_LOG");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_WAGE_LOCK>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ, e.GROUP_ID })
                    .HasName("PK_SALARY_LOCK_WAGE");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_WAGE_LOCK_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_SALARY_LOCK_WAGE_LOG");

                entity.HasIndex(e => new { e.SALARY_YYMM, e.SALARY_SEQ, e.GROUP_ID })
                    .HasName("IDX_HRM_SALARY_WAGE_LOCK_LOG");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_WAGE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SALARY_YYMM, e.SALARY_SEQ, e.EMPLOYEE_ID })
                    .HasName("IDX_SALARY_YYMM");

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.CALCULATE_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CALCULATE_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.CASH).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(500);

                entity.Property(e => e.NOT_COUNT_SALARY).HasMaxLength(50);

                entity.Property(e => e.SALARY_FLAG).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TRANSFER_BANK_ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_DAYS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_SALARY_WAGE_SPECIAL_BONUS>(entity =>
            {
                entity.HasKey(e => new { e.SALARY_YYMM, e.COMPANY_ID, e.SALARY_SEQ, e.EMPLOYEE_ID });

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.CALCULATE_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.CALCULATE_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.CASH).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(500);

                entity.Property(e => e.NOT_COUNT_SALARY).HasMaxLength(50);

                entity.Property(e => e.SALARY_FLAG).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TRANSFER_BANK_ACCOUNT).HasMaxLength(50);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_DAYS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_SALARY_WELFARE_DEDUCT_HOTA>(entity =>
            {
                entity.HasKey(e => e.WELFARE_DEDUCT_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SALARY_WELFARE_DEDUCT_HOTA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.WELFARE_DEDUCT_ID)
                    .HasName("IDX_WELFARE_DEDUCT_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SCHOOL>(entity =>
            {
                entity.HasKey(e => e.SCHOOL_ID);

                entity.HasIndex(e => e.SCHOOL_CODE)
                    .HasName("IDX_SCHOOL_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SCHOOL_CNAME).HasMaxLength(100);

                entity.Property(e => e.SCHOOL_CODE).HasMaxLength(50);

                entity.Property(e => e.SCHOOL_ENAME).HasMaxLength(100);

                entity.Property(e => e.SCHOOL_IS_OVERSEA).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SCHOOL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SCHOOL_ID)
                    .HasName("IDX_SCHOOL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SCHOOL_CNAME).HasMaxLength(100);

                entity.Property(e => e.SCHOOL_CODE).HasMaxLength(50);

                entity.Property(e => e.SCHOOL_ENAME).HasMaxLength(100);

                entity.Property(e => e.SCHOOL_IS_OVERSEA).HasMaxLength(1);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SHARECODE>(entity =>
            {
                entity.HasKey(e => new { e.FIELDNAME, e.CODE });

                entity.Property(e => e.FIELDNAME).HasMaxLength(50);

                entity.Property(e => e.CODE).HasMaxLength(50);

                entity.Property(e => e.NAME)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<HRM_SHARECODE_GROUP>(entity =>
            {
                entity.HasKey(e => e.FIELDNAME);

                entity.Property(e => e.FIELDNAME).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);
            });

            modelBuilder.Entity<HRM_SHARE_REPORT_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.REPORT_TYPE, e.CODE });

                entity.Property(e => e.REPORT_TYPE).HasMaxLength(50);

                entity.Property(e => e.CODE).HasMaxLength(50);

                entity.Property(e => e.DISPLAY)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NAME)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<HRM_SKILL>(entity =>
            {
                entity.HasKey(e => e.SKILL_ID);

                entity.HasIndex(e => e.SKILL_CODE)
                    .HasName("IDX_SKILL_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SKILL_CNAME).HasMaxLength(50);

                entity.Property(e => e.SKILL_CODE).HasMaxLength(50);

                entity.Property(e => e.SKILL_ENAME).HasMaxLength(50);

                entity.Property(e => e.SKILL_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SKILL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SKILL_ID)
                    .HasName("IDX_SKILL_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SKILL_CNAME).HasMaxLength(50);

                entity.Property(e => e.SKILL_CODE).HasMaxLength(50);

                entity.Property(e => e.SKILL_ENAME).HasMaxLength(50);

                entity.Property(e => e.SKILL_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SUPPLY_IDENTITY>(entity =>
            {
                entity.HasKey(e => e.SUPPLY_IDENTITY_ID);

                entity.HasIndex(e => e.SUPPLY_IDENTITY_CODE)
                    .HasName("IDX_SUPPLY_IDENTITY_CODE");

                entity.Property(e => e.SUPPLY_IDENTITY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_CODE).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_ENAME).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_FOREIGNER).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SUPPLY_IDENTITY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.SUPPLY_IDENTITY_ID)
                    .HasName("IDX_SUPPLY_IDENTITY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_CODE).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_ENAME).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_FOREIGNER).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_IDENTITY_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_ATTEND_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_ATTEND_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_GROUP_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_HEALTH_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.COMPANY_PERSON_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HEALTH_COMPANY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_HEALTH_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.COMPANY_PERSON_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_FAMILY_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HEALTH_COMPANY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_HOLIDAY_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_HOLIDAY_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_LABOR_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.NEW_RETIRE_RATE_DL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.NEW_RETIRE_RATE_IDL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.OLD_RETIRE_RATE_DL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.OLD_RETIRE_RATE_IDL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_LABOR_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NEW_RETIRE_RATE_DL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.NEW_RETIRE_RATE_IDL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.OLD_RETIRE_RATE_DL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.OLD_RETIRE_RATE_IDL).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_MAILQUEUE>(entity =>
            {
                entity.HasKey(e => e.MAILQUEUE_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.FREEZE_TIME).HasColumnType("datetime");

                entity.Property(e => e.FROM_MAIL_ADDR).HasMaxLength(50);

                entity.Property(e => e.FROM_NAME).HasMaxLength(50);

                entity.Property(e => e.MESSAGE_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.NOTE).HasMaxLength(50);

                entity.Property(e => e.SUBJECT).HasMaxLength(500);

                entity.Property(e => e.SUCCESS).HasMaxLength(50);

                entity.Property(e => e.SUSPEND).HasMaxLength(50);

                entity.Property(e => e.TO_MAIL_ADDR).HasMaxLength(50);

                entity.Property(e => e.TO_NAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_MAILQUEUE_LOG>(entity =>
            {
                entity.HasKey(e => e.MAILQUEUE_LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.ERROR_CODE).HasMaxLength(50);

                entity.Property(e => e.IS_SUCCESS).HasMaxLength(50);

                entity.Property(e => e.TO_MAIL_ADDR).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_MAPPING_DETAIL>(entity =>
            {
                entity.HasKey(e => e.AUTOKEY);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<HRM_SYSTEM_MAPPING_MASTER>(entity =>
            {
                entity.HasKey(e => e.MAPPING_CODE);

                entity.Property(e => e.MAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.MAPPING_TITLE).HasMaxLength(500);

                entity.Property(e => e.MAPPING_TYPE).HasMaxLength(500);

                entity.Property(e => e.MEMO).HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_NOTIFY_MAIN>(entity =>
            {
                entity.HasKey(e => e.NOTIFY_ID);

                entity.HasIndex(e => e.NOTIFY_CODE)
                    .HasName("IDX_NOTIFY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_SCHEDULE).HasMaxLength(50);

                entity.Property(e => e.IS_STOP).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.NOTIFY_CODE).HasMaxLength(50);

                entity.Property(e => e.NOTIFY_NAME).HasMaxLength(50);

                entity.Property(e => e.SUBJECT).HasMaxLength(200);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_NOTIFY_PARAMETER>(entity =>
            {
                entity.HasKey(e => new { e.NOTIFY_ID, e.PARAMETER_CODE });

                entity.Property(e => e.PARAMETER_CODE).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_NAME).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_NOTIFY_TAG>(entity =>
            {
                entity.HasKey(e => new { e.NOTIFY_ID, e.TAG_CODE });

                entity.Property(e => e.TAG_CODE).HasMaxLength(50);

                entity.Property(e => e.TAG_HTML).HasMaxLength(50);

                entity.Property(e => e.TAG_NAME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_NOTIFY_TARGET>(entity =>
            {
                entity.HasKey(e => e.TARGET_ID);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.MAIL).HasMaxLength(100);

                entity.Property(e => e.MAIL_NAME).HasMaxLength(100);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.NOTIFY_TARGET).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_OVERTIME_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID)
                    .HasName("PK_HRM_ATTEND_PARAMETER_OVERTIME");

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DUTY_FREE_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FEMALE_MAX_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.MALE_MAX_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_SYSTEM_OVERTIME_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_ATTEND_PARAMETER_OVERTIME_LOG");

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DUTY_FREE_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FEMALE_MAX_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MALE_MAX_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_UNIT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPPER_MANAGER_HOUR).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_SYSTEM_PAGE_MAPPING>(entity =>
            {
                entity.HasKey(e => e.PAGE_FROM);

                entity.Property(e => e.PAGE_FROM).HasMaxLength(100);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.PAGE_TO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_PARAMETER_MAPPING_MASTER>(entity =>
            {
                entity.HasKey(e => e.PARAMETER_MAPPING_CODE);

                entity.Property(e => e.PARAMETER_MAPPING_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_ENABLE).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.PARAMETER_MAPPING_NAME).HasMaxLength(50);

                entity.Property(e => e.SEQ).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_PARAMETER_MAPPING_MASTER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.PARAMETER_MAPPING_CODE)
                    .HasName("IDX_PARAMETER_MAPPING_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.IS_ENABLE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.PARAMETER_MAPPING_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PARAMETER_MAPPING_NAME).HasMaxLength(50);

                entity.Property(e => e.SEQ).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_REPORT_CONFIG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IS_DISPLAY_COMPANY).HasMaxLength(50);

                entity.Property(e => e.IS_DISPLAY_DEPT).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_REPORT_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.REPORT_NAME, e.RDLC_FROM });

                entity.Property(e => e.REPORT_NAME).HasMaxLength(150);

                entity.Property(e => e.RDLC_FROM).HasMaxLength(150);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.RDLC_TO)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_REPORT_MAPPING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.REPORT_NAME, e.RDLC_FROM })
                    .HasName("IDX_REPORT_NAME");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.RDLC_FROM).HasMaxLength(150);

                entity.Property(e => e.RDLC_TO).HasMaxLength(150);

                entity.Property(e => e.REPORT_NAME).HasMaxLength(150);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_SALARY_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID)
                    .HasName("PK_HRM_SALARY_CONFIG");

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SHIFT_ALLOWANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 3)");
            });

            modelBuilder.Entity<HRM_SYSTEM_SALARY_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_SALARY_CONFIG_LOG");

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SHIFT_ALLOWANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 3)");
            });

            modelBuilder.Entity<HRM_SYSTEM_SALARY_SETTING>(entity =>
            {
                entity.HasKey(e => e.SALARY_SETTING_ID);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_SETTING_NAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_SALARY_SETTING_DETAIL>(entity =>
            {
                entity.HasKey(e => e.SETTING_DETAIL_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_SALARY_SETTING_DETAIL_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_SALARY_SETTING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ATTEND_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.ATTEND_END_DATE).HasColumnType("date");

                entity.Property(e => e.COURT_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.HEALTH_COMPANY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_FAMILY_COUNT).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.HEALTH_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRYDAY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_OVER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_ENTRY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FIX_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_FOREIGNER_SALARY).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.INCOMETAX_WITHHOLD_TAX).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DUTY_FREE_HOURS).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SALARY_BEGIN_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_END_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_PARAMETER_DATE).HasColumnType("date");

                entity.Property(e => e.SALARY_SETTING_NAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SUPPLY_ANNUAL_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_MAXIMUM).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.SUPPLY_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_RATE).HasColumnType("decimal(16, 4)");

                entity.Property(e => e.WELFARE_SALARY_ITEM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_SERVER_PACKAGE_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.SERVER_PACKAGE_FROM, e.SERVER_METHOD_FROM })
                    .HasName("PK_HRM_SYSTEM_SERVER_PACKAGE_MAPPING_1");

                entity.Property(e => e.SERVER_PACKAGE_FROM).HasMaxLength(150);

                entity.Property(e => e.SERVER_METHOD_FROM).HasMaxLength(75);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.SERVER_METHOD_TO)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.SERVER_PACKAGE_TO)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_SERVER_PACKAGE_MAPPING_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.SERVER_PACKAGE_FROM, e.SERVER_METHOD_FROM })
                    .HasName("IDX_SERVER_PACKAGE_FROM");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SERVER_METHOD_FROM)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.SERVER_METHOD_TO)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.SERVER_PACKAGE_FROM)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SERVER_PACKAGE_TO)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_SYSTEM_TAX_CONFIG>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID);

                entity.Property(e => e.COMPANY_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.ENTRYDAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FOREIGNER_SALARY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FOREIGNER_SALARY_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_OVER_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVER_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_FIX_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WITHHOLD_TAX).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_SYSTEM_TAX_CONFIG_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COMPANY_ID)
                    .HasName("IDX_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.ENTRYDAY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FOREIGNER_SALARY).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FOREIGNER_SALARY_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOT_OVER_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVER_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TAX_FIX_RATE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WITHHOLD_TAX).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_SYSTEM_YEAR_HOLIDAY>(entity =>
            {
                entity.HasKey(e => new { e.MONTH, e.BEGIN_DAY, e.END_DAY })
                    .HasName("PK_HRM_SYSTEM_YEAR_HOLIDAY_1");

                entity.Property(e => e.YEAR_0).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_1).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_10).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_11).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_12).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_13).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_14).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_15).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_16).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_17).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_18).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_19).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_2).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_20).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_21).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_22).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_23).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_24).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_25).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_26).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_3).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_4).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_5).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_6).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_7).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_8).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_9).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<HRM_SYSTEM_YEAR_HOLIDAY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => new { e.MONTH, e.BEGIN_DAY, e.END_DAY })
                    .HasName("IDX_MONTH");

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.YEAR_0).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_1).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_10).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_11).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_12).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_13).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_14).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_15).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_16).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_17).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_18).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_19).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_2).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_20).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_21).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_22).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_23).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_24).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_25).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_26).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_3).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_4).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_5).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_6).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_7).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_8).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.YEAR_9).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<HRM_TAX_INSTITUTION>(entity =>
            {
                entity.HasKey(e => e.TAX_INSTITUTION_ID)
                    .HasName("PK_HRMS_TAX_INSTITUTION");

                entity.HasIndex(e => e.TAX_INSTITUTION_CODE)
                    .HasName("IDX_TAX_INSTITUTION_CODE");

                entity.Property(e => e.TAX_INSTITUTION_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TAX_INSTITUTION_CNAME).HasMaxLength(60);

                entity.Property(e => e.TAX_INSTITUTION_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_INSTITUTION_ENAME).HasMaxLength(60);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COMPANY>(entity =>
            {
                entity.HasKey(e => e.TRAINING_COMPANY_ID);

                entity.HasIndex(e => e.TRAINING_COMPANY_CODE)
                    .HasName("IDX_TRAINING_COMPANY_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_CNAME).HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_ENAME).HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COMPANY_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.TRAINING_COMPANY_ID)
                    .HasName("IDX_TRAINING_COMPANY_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_CNAME).HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_ENAME).HasMaxLength(50);

                entity.Property(e => e.TRAINING_COMPANY_TEL).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COURSE_DATA>(entity =>
            {
                entity.HasKey(e => e.COURSE_DATA_ID);

                entity.HasIndex(e => e.EMPLOYEE_ID)
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.APPLY_NO).HasMaxLength(50);

                entity.Property(e => e.COUNTRY).HasMaxLength(50);

                entity.Property(e => e.COURSE_ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURSE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURSE_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.COURSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.COURSE_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.COURSE_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HANDOUT).HasMaxLength(50);

                entity.Property(e => e.ISO).HasMaxLength(60);

                entity.Property(e => e.IS_ABORAD).HasMaxLength(50);

                entity.Property(e => e.IS_CLOSE).HasMaxLength(50);

                entity.Property(e => e.IS_EVALUATE).HasMaxLength(50);

                entity.Property(e => e.IS_PLAN_IN).HasMaxLength(50);

                entity.Property(e => e.IS_QUESTIONNAIRE).HasMaxLength(50);

                entity.Property(e => e.LICENSE).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.RECEIPT).HasMaxLength(50);

                entity.Property(e => e.TRAINING_STYLE).HasMaxLength(50);

                entity.Property(e => e.TRAINING_TARGET).HasMaxLength(60);

                entity.Property(e => e.TRAINING_TEACHER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COURSE_DATA_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COURSE_DATA_ID)
                    .HasName("IDX_COURSE_DATA_ID");

                entity.Property(e => e.APPLY_NO).HasMaxLength(50);

                entity.Property(e => e.COUNTRY).HasMaxLength(50);

                entity.Property(e => e.COURSE_ABSENT_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURSE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.COURSE_BEGIN_DATE).HasColumnType("datetime");

                entity.Property(e => e.COURSE_CNAME).HasMaxLength(50);

                entity.Property(e => e.COURSE_END_DATE).HasColumnType("datetime");

                entity.Property(e => e.COURSE_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.EVALUATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.HANDOUT).HasMaxLength(50);

                entity.Property(e => e.ISO).HasMaxLength(60);

                entity.Property(e => e.IS_ABORAD).HasMaxLength(50);

                entity.Property(e => e.IS_CLOSE).HasMaxLength(50);

                entity.Property(e => e.IS_EVALUATE).HasMaxLength(50);

                entity.Property(e => e.IS_PLAN_IN).HasMaxLength(50);

                entity.Property(e => e.IS_QUESTIONNAIRE).HasMaxLength(50);

                entity.Property(e => e.LICENSE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(200);

                entity.Property(e => e.RECEIPT).HasMaxLength(50);

                entity.Property(e => e.TRAINING_STYLE).HasMaxLength(50);

                entity.Property(e => e.TRAINING_TARGET).HasMaxLength(60);

                entity.Property(e => e.TRAINING_TEACHER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COURSE_EVALUATE>(entity =>
            {
                entity.HasKey(e => e.COURSE_EVALUATE_ID);

                entity.HasIndex(e => e.COURSE_EVALUATE_CODE)
                    .HasName("IDX_COURSE_EVALUATE_CODE");

                entity.Property(e => e.COURSE_EVALUATE_CNAME).HasMaxLength(50);

                entity.Property(e => e.COURSE_EVALUATE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COURSE_EVALUATE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COURSE_EVALUATE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COURSE_EVALUATE_ID)
                    .HasName("IDX_COURSE_EVALUATE_ID");

                entity.Property(e => e.COURSE_EVALUATE_CNAME).HasMaxLength(50);

                entity.Property(e => e.COURSE_EVALUATE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COURSE_EVALUATE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COURSE_TYPE>(entity =>
            {
                entity.HasKey(e => e.COURSE_TYPE_ID);

                entity.HasIndex(e => e.COURSE_TYPE_CODE)
                    .HasName("IDX_COURSE_TYPE_CODE");

                entity.Property(e => e.COURSE_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.COURSE_TYPE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.COURSE_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_TRAINING_COURSE_TYPE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.COURSE_TYPE_ID)
                    .HasName("IDX_COURSE_TYPE_ID");

                entity.Property(e => e.COURSE_TYPE_CNAME).HasMaxLength(50);

                entity.Property(e => e.COURSE_TYPE_CODE).HasMaxLength(50);

                entity.Property(e => e.COURSE_TYPE_ENAME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_ACCOUNT>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ACCOUNT_ID);

                entity.Property(e => e.ACCOUNT_NO).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACCOUNT_QUOTA).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_ACCOUNT_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.ACCOUNT_NO).HasMaxLength(50);

                entity.Property(e => e.ACCOUNT_PERCENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACCOUNT_QUOTA).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_COMMITTEE>(entity =>
            {
                entity.HasKey(e => e.WELFARE_COMMITTEE_CODE);

                entity.Property(e => e.WELFARE_COMMITTEE_CODE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(60);

                entity.Property(e => e.TAX_ID).HasMaxLength(60);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CNAME).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_ENAME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_COMMITTEE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.WELFARE_COMMITTEE_CODE)
                    .HasName("IDX_WELFARE_COMMITTEE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(60);

                entity.Property(e => e.TAX_ID).HasMaxLength(60);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CNAME).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_ENAME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_WAGE>(entity =>
            {
                entity.HasKey(e => e.WELFARE_WAGE_ID);

                entity.HasIndex(e => new { e.EMPLOYEE_ID, e.SALARY_YYMM, e.SALARY_SEQ })
                    .HasName("IDX_EMPLOYEE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEDUCT_TAX_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CODE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_WAGE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.WELFARE_WAGE_ID)
                    .HasName("WELFARE_WAGE_ID");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEDUCT_TAX_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.SALARY_SEQ).HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CODE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_WELCODE>(entity =>
            {
                entity.HasKey(e => e.WELFARE_ID)
                    .HasName("PK_HRM_WELFARE_WELCODE_1");

                entity.HasIndex(e => e.WELFARE_CODE)
                    .HasName("IDX_WELFARE_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_CNAME).HasMaxLength(50);

                entity.Property(e => e.WELFARE_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WELFARE_ENAME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_WELCODE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.WELFARE_ID)
                    .HasName("IDX_WELFARE_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_CNAME).HasMaxLength(50);

                entity.Property(e => e.WELFARE_CODE).HasMaxLength(50);

                entity.Property(e => e.WELFARE_ENAME).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_YEAR_TAX>(entity =>
            {
                entity.HasKey(e => new { e.SERIAL_NO, e.YEAR_PAYMENT })
                    .HasName("PK_HRM_MEDIA_TAX_WELFARE_TAX");

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);

                entity.Property(e => e.BEGIN_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CODE).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WELFARE_YEAR_TAX_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_HRM_MEDIA_TAX_WELFARE_TAX_LOG");

                entity.HasIndex(e => new { e.SERIAL_NO, e.YEAR_PAYMENT })
                    .HasName("IDX_SERIAL_NO");

                entity.Property(e => e.BEGIN_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.ERROR_MARK).HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.IDNO).HasMaxLength(50);

                entity.Property(e => e.IS_DECLARE).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.MARK).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.NET_PAYMENT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NET_WITHHOLDING_TAX).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.RESIDENCE_ADDRESS).HasMaxLength(60);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.TAX_CITY_OFFICE_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_FORMAT_CODE).HasMaxLength(50);

                entity.Property(e => e.TAX_ID).HasMaxLength(50);

                entity.Property(e => e.TAX_ID_CODE).HasMaxLength(50);

                entity.Property(e => e.TOTAL_AMOUNT_PAID).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WELFARE_COMMITTEE_CODE).HasMaxLength(50);

                entity.Property(e => e.YEAR_PAYMENT).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WORKPLACE>(entity =>
            {
                entity.HasKey(e => e.WORK_ID);

                entity.HasIndex(e => e.WORK_CODE)
                    .HasName("IDX_WORK_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_ADDR)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WORK_CODE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_WORKPLACE_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.WORK_ID)
                    .HasName("IDX_WORK_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_ADDR).HasMaxLength(50);

                entity.Property(e => e.WORK_CODE).HasMaxLength(50);
            });

            modelBuilder.Entity<MAIL_PARAMETER>(entity =>
            {
                entity.HasKey(e => e.MAIL_PARAMETER_ID);

                entity.HasIndex(e => e.PARAMETER_CODE)
                    .HasName("IDX_PARAMETER_CODE");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DISPLAY).HasMaxLength(50);

                entity.Property(e => e.NOTE).HasMaxLength(50);

                entity.Property(e => e.PARAMERTER_NAME).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<MAIL_PARAMETER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.HasIndex(e => e.MAIL_PARAMETER_ID)
                    .HasName("IDX_MAIL_PARAMETER_ID");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DISPLAY).HasMaxLength(50);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.NOTE).HasMaxLength(50);

                entity.Property(e => e.PARAMERTER_NAME).HasMaxLength(50);

                entity.Property(e => e.PARAMETER_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VALUE).HasMaxLength(50);
            });

            modelBuilder.Entity<MENUCHECKLOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FILECONTENT).HasColumnType("image");

                entity.Property(e => e.FILEDATE).HasColumnType("datetime");

                entity.Property(e => e.FILENAME).HasMaxLength(60);

                entity.Property(e => e.FILETYPE).HasMaxLength(10);

                entity.Property(e => e.ITEMTYPE)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PACKAGE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PACKAGEDATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<MENUFAVOR>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CAPTION)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUPNAME).HasMaxLength(20);

                entity.Property(e => e.ITEMTYPE).HasMaxLength(20);

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MENUITEMTYPE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DBALIAS).HasMaxLength(50);

                entity.Property(e => e.ITEMNAME).HasMaxLength(20);

                entity.Property(e => e.ITEMTYPE)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<MENUTABLE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CAPTION)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CAPTION0).HasMaxLength(50);

                entity.Property(e => e.CAPTION1).HasMaxLength(50);

                entity.Property(e => e.CAPTION2).HasMaxLength(50);

                entity.Property(e => e.CAPTION3).HasMaxLength(50);

                entity.Property(e => e.CAPTION4).HasMaxLength(50);

                entity.Property(e => e.CAPTION5).HasMaxLength(50);

                entity.Property(e => e.CAPTION6).HasMaxLength(50);

                entity.Property(e => e.CAPTION7).HasMaxLength(50);

                entity.Property(e => e.CHECKOUT).HasMaxLength(20);

                entity.Property(e => e.CHECKOUTDATE).HasColumnType("datetime");

                entity.Property(e => e.FORM).HasMaxLength(100);

                entity.Property(e => e.IMAGE).HasColumnType("image");

                entity.Property(e => e.IMAGEURL).HasMaxLength(100);

                entity.Property(e => e.ISSERVER).HasMaxLength(1);

                entity.Property(e => e.ISSHOWMODAL).HasMaxLength(1);

                entity.Property(e => e.ITEMPARAM).HasMaxLength(200);

                entity.Property(e => e.ITEMTYPE).HasMaxLength(20);

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MODULETYPE).HasMaxLength(1);

                entity.Property(e => e.OWNER).HasMaxLength(20);

                entity.Property(e => e.PACKAGE).HasMaxLength(60);

                entity.Property(e => e.PACKAGEDATE).HasColumnType("datetime");

                entity.Property(e => e.PARENT).HasMaxLength(100);

                entity.Property(e => e.SEQ_NO).HasMaxLength(4);

                entity.Property(e => e.VERSIONNO).HasMaxLength(20);
            });

            modelBuilder.Entity<MENUTABLECONTROL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CONTROLNAME)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MENUTABLELOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LASTDATE).HasColumnType("datetime");

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.OLDDATE).HasMaxLength(20);

                entity.Property(e => e.OLDVERSION).HasColumnType("image");

                entity.Property(e => e.OWNER).HasMaxLength(20);

                entity.Property(e => e.PACKAGE)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PACKAGEDATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<PunchCardType>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_PunchCardType]");

                entity.Property(e => e.KeyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.KeyMan)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SYSAUTONUM>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AUTOID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CURRNUM).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DESCRIPTION).HasMaxLength(100);

                entity.Property(e => e.FIXED).HasMaxLength(50);
            });

            modelBuilder.Entity<SYSEEPLOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.COMPUTERIP).HasMaxLength(16);

                entity.Property(e => e.COMPUTERNAME).HasMaxLength(64);

                entity.Property(e => e.CONNID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DESCRIPTION).HasColumnType("text");

                entity.Property(e => e.DOMAINID).HasMaxLength(30);

                entity.Property(e => e.LOGDATETIME).HasColumnType("datetime");

                entity.Property(e => e.LOGSTYLE)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LOGTYPE).HasMaxLength(1);

                entity.Property(e => e.TITLE).HasMaxLength(64);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYSERRLOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ERRDATE).HasColumnType("datetime");

                entity.Property(e => e.ERRDESCRIP).HasMaxLength(255);

                entity.Property(e => e.ERRMESSAGE).HasMaxLength(255);

                entity.Property(e => e.ERRSCREEN).HasColumnType("image");

                entity.Property(e => e.ERRSTACK).HasColumnType("text");

                entity.Property(e => e.MODULENAME).HasMaxLength(30);

                entity.Property(e => e.OWNER).HasMaxLength(20);

                entity.Property(e => e.PROCESSDATE).HasColumnType("datetime");

                entity.Property(e => e.PRODESCRIP).HasMaxLength(255);

                entity.Property(e => e.STATUS).HasMaxLength(2);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_ANYQUERY>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CONTENT).HasColumnType("text");

                entity.Property(e => e.LASTDATE).HasColumnType("datetime");

                entity.Property(e => e.QUERYID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TABLENAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TEMPLATEID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_EXTAPPROVE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.APPROVEID).HasMaxLength(50);

                entity.Property(e => e.GROUPID).HasMaxLength(50);

                entity.Property(e => e.MAXIMUM).HasMaxLength(50);

                entity.Property(e => e.MINIMUM).HasMaxLength(50);

                entity.Property(e => e.ROLEID).HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_FLDEFINITION>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FLDEFINITION)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.FLTYPEID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FLTYPENAME)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SYS_FLINSTANCESTATE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FLINSTANCEID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.INFO).HasMaxLength(200);

                entity.Property(e => e.STATE)
                    .IsRequired()
                    .HasColumnType("image");
            });

            modelBuilder.Entity<SYS_LANGUAGE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CHS).HasMaxLength(80);

                entity.Property(e => e.CHT).HasMaxLength(80);

                entity.Property(e => e.EN).HasMaxLength(80);

                entity.Property(e => e.HK).HasMaxLength(80);

                entity.Property(e => e.IDENTIFICATION).HasMaxLength(80);

                entity.Property(e => e.JA).HasMaxLength(80);

                entity.Property(e => e.KEYS).HasMaxLength(80);

                entity.Property(e => e.KO).HasMaxLength(80);

                entity.Property(e => e.LAN1).HasMaxLength(80);

                entity.Property(e => e.LAN2).HasMaxLength(80);
            });

            modelBuilder.Entity<SYS_MESSENGER>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MESSAGE).HasMaxLength(255);

                entity.Property(e => e.PARAS).HasMaxLength(255);

                entity.Property(e => e.RECTIME).HasMaxLength(14);

                entity.Property(e => e.SENDERID).HasMaxLength(20);

                entity.Property(e => e.SENDTIME).HasMaxLength(14);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_ORG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.END_ORG).HasMaxLength(4);

                entity.Property(e => e.LEVEL_NO)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ORG_DESC)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.ORG_FULLNAME).HasMaxLength(254);

                entity.Property(e => e.ORG_KIND)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.ORG_MAN)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ORG_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ORG_TREE).HasMaxLength(40);

                entity.Property(e => e.UPPER_ORG).HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_ORGKIND>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.KIND_DESC)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ORG_KIND)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<SYS_ORGLEVEL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LEVEL_DESC)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LEVEL_NO)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<SYS_ORGROLES>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ORG_KIND).HasMaxLength(4);

                entity.Property(e => e.ORG_NO)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ROLE_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_PERSONAL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.COMPNAME)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CREATEDATE).HasColumnType("datetime");

                entity.Property(e => e.FORMNAME)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.PROPCONTENT).HasColumnType("ntext");

                entity.Property(e => e.REMARK).HasMaxLength(30);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SYS_REFVAL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CAPTION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DISPLAY_MEMBER)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.REFVAL_NO)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SELECT_ALIAS)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SELECT_COMMAND)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TABLE_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VALUE_MEMBER)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_REFVAL_D1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FIELD_NAME)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HEADER_TEXT)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.REFVAL_NO)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_REPORT>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CLIENT_QUERY).HasColumnType("image");

                entity.Property(e => e.DATASOURCES).HasColumnType("image");

                entity.Property(e => e.DATASOURCE_PROVIDER).HasMaxLength(50);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(50);

                entity.Property(e => e.FIELDFONT).HasColumnType("image");

                entity.Property(e => e.FIELDITEMS).HasColumnType("image");

                entity.Property(e => e.FILENAME)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FILEPATH).HasMaxLength(50);

                entity.Property(e => e.FOOTERFONT).HasColumnType("image");

                entity.Property(e => e.FOOTERITEMS).HasColumnType("image");

                entity.Property(e => e.FORMAT).HasColumnType("image");

                entity.Property(e => e.HEADERFONT).HasColumnType("image");

                entity.Property(e => e.HEADERITEMS).HasColumnType("image");

                entity.Property(e => e.HEADERREPEAT).HasMaxLength(5);

                entity.Property(e => e.IMAGES).HasColumnType("image");

                entity.Property(e => e.MAILSETTING).HasColumnType("image");

                entity.Property(e => e.OUTPUTMODE).HasMaxLength(20);

                entity.Property(e => e.PARAMETERS).HasColumnType("image");

                entity.Property(e => e.REPORTID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.REPORTNAME).HasMaxLength(50);

                entity.Property(e => e.REPORT_TYPE).HasMaxLength(1);

                entity.Property(e => e.SETTING).HasColumnType("image");

                entity.Property(e => e.TEMPLATE_DESC).HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_ROLES_AGENT>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.ROLE_ID, e.FLOW_DESC })
                    .HasName("idx_roleid_flow_desc");

                entity.Property(e => e.AGENT)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.END_DATE)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.END_TIME).HasMaxLength(6);

                entity.Property(e => e.FLOW_DESC)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PAR_AGENT)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.REMARK).HasMaxLength(254);

                entity.Property(e => e.ROLE_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.START_DATE)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.START_TIME).HasMaxLength(6);
            });

            modelBuilder.Entity<SYS_SDALIAS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ALIASNAME)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DBNAME)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SYSTEMALIAS)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_SDGROUPS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GROUPNAME)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_SDQUEUE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CREATETIME).HasColumnType("datetime");

                entity.Property(e => e.FILENAME)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FINISHTIME).HasColumnType("datetime");

                entity.Property(e => e.PAGETYPE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PRINTSETTING)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_SDQUEUEPAGE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DOCUMENT).IsRequired();

                entity.Property(e => e.PAGENAME)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_SDSOLUTIONS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ALIASOPTIONS)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BGENDCOLOR)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.BGSTARTCOLOR)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY).HasMaxLength(30);

                entity.Property(e => e.MOUDLEXMLTEXT).IsRequired();

                entity.Property(e => e.SOLUTIONID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SOLUTIONNAME).HasMaxLength(30);

                entity.Property(e => e.THEME)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_SDUSERS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EMAIL).HasMaxLength(50);

                entity.Property(e => e.GROUPID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LASTDATE).HasColumnType("datetime");

                entity.Property(e => e.PASSWORD)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SYSTYPE).HasMaxLength(1);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.USERNAME).HasMaxLength(30);
            });

            modelBuilder.Entity<SYS_SDUSERS_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IPADDRESS)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOGINTIME).HasColumnType("datetime");

                entity.Property(e => e.LOGOUTTIME).HasColumnType("datetime");

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_TODOHIS>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.FORM_PRESENTATION)
                    .HasName("idx_form_presentation");

                entity.HasIndex(e => new { e.LISTID, e.USER_ID })
                    .HasName("idx_listid_userid");

                entity.HasIndex(e => new { e.UPDATE_DATE, e.UPDATE_TIME })
                    .HasName("idx_update_date");

                entity.Property(e => e.ATTACHMENTS).HasMaxLength(500);

                entity.Property(e => e.CREATE_TIME).HasMaxLength(500);

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EXP_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.FLNAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FLOWIMPORTANT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOWURGENT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(500);

                entity.Property(e => e.FLOW_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FORM_KEYS).HasMaxLength(500);

                entity.Property(e => e.FORM_NAME).HasMaxLength(500);

                entity.Property(e => e.FORM_PRESENTATION).HasMaxLength(500);

                entity.Property(e => e.FORM_PRESENT_CT).HasMaxLength(500);

                entity.Property(e => e.FORM_TABLE).HasMaxLength(500);

                entity.Property(e => e.LEVEL_NO).HasMaxLength(500);

                entity.Property(e => e.LISTID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.NAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PARAMETERS).HasMaxLength(500);

                entity.Property(e => e.PROC_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.REMARK).HasMaxLength(500);

                entity.Property(e => e.ROLE_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SENDBACKSTEP).HasMaxLength(500);

                entity.Property(e => e.STATUS).HasMaxLength(500);

                entity.Property(e => e.S_ROLE_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.S_STEP_DESC).HasMaxLength(500);

                entity.Property(e => e.S_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.S_USERNAME).HasMaxLength(500);

                entity.Property(e => e.S_USER_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TIME_UNIT)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(500);

                entity.Property(e => e.UPDATE_TIME).HasMaxLength(500);

                entity.Property(e => e.USERNAME).HasMaxLength(500);

                entity.Property(e => e.USER_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.VDSNAME).HasMaxLength(500);

                entity.Property(e => e.VERSION).HasMaxLength(500);

                entity.Property(e => e.WEBFORM_NAME)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<SYS_TODOLIST>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.FORM_PRESENTATION)
                    .HasName("idx_form_resentation");

                entity.HasIndex(e => e.LISTID)
                    .HasName("idx_listid");

                entity.HasIndex(e => new { e.UPDATE_DATE, e.UPDATE_TIME })
                    .HasName("idx_update_date");

                entity.HasIndex(e => new { e.STATUS, e.SENDTO_KIND, e.SENDTO_ID })
                    .HasName("idx_status_sendtokind");

                entity.Property(e => e.APPLICANT)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ATTACHMENTS).HasMaxLength(500);

                entity.Property(e => e.CREATE_TIME).HasMaxLength(500);

                entity.Property(e => e.D_STEP_DESC).HasMaxLength(500);

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EMAIL_ADD).HasMaxLength(500);

                entity.Property(e => e.EMAIL_STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EXP_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.FLNAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FLOWIMPORTANT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOWPATH)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FLOWURGENT)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(500);

                entity.Property(e => e.FLOW_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FORM_KEYS).HasMaxLength(500);

                entity.Property(e => e.FORM_NAME).HasMaxLength(500);

                entity.Property(e => e.FORM_PRESENTATION).HasMaxLength(500);

                entity.Property(e => e.FORM_PRESENT_CT)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FORM_TABLE).HasMaxLength(500);

                entity.Property(e => e.LEVEL_NO).HasMaxLength(500);

                entity.Property(e => e.LISTID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MULTISTEPRETURN)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PARAMETERS).HasMaxLength(500);

                entity.Property(e => e.PLUSAPPROVE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PLUSROLES)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PROVIDER_NAME).HasMaxLength(500);

                entity.Property(e => e.REMARK).HasMaxLength(500);

                entity.Property(e => e.SENDBACKSTEP).HasMaxLength(500);

                entity.Property(e => e.SENDTO_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SENDTO_KIND)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SENDTO_NAME).HasMaxLength(500);

                entity.Property(e => e.STATUS).HasMaxLength(500);

                entity.Property(e => e.S_STEP_DESC).HasMaxLength(500);

                entity.Property(e => e.S_STEP_ID).HasMaxLength(500);

                entity.Property(e => e.S_USER_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TIME_UNIT)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(500);

                entity.Property(e => e.UPDATE_TIME).HasMaxLength(500);

                entity.Property(e => e.URGENT_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.USERNAME).HasMaxLength(500);

                entity.Property(e => e.VDSNAME).HasMaxLength(500);

                entity.Property(e => e.VERSION).HasMaxLength(500);

                entity.Property(e => e.WEBFORM_NAME)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<SYS_WEBPAGES>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CHECKOUTDATE).HasColumnType("datetime");

                entity.Property(e => e.CHECKOUTUSER)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PAGENAME)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PAGETYPE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SOLUTIONID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_WEBPAGES_LOG>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CHECKINDATE).HasColumnType("datetime");

                entity.Property(e => e.CHECKINDESCRIPTION)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CHECKINUSER)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PAGENAME)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PAGETYPE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SOLUTIONID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_WEBRUNTIME>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PAGENAME)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PAGETYPE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SOLUTIONID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USERGROUPS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USERGROUPS_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID);

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOG_DATE).HasColumnType("datetime");

                entity.Property(e => e.LOG_STATE).HasMaxLength(50);

                entity.Property(e => e.LOG_USER).HasMaxLength(50);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USERMENUCONTROL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ALLOWADD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWDELETE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWPRINT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWUPDATE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CONTROLNAME)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ENABLED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VISIBLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<USERMENUS>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USERS>(entity =>
            {
                entity.HasKey(e => e.USERID);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AGENT).HasMaxLength(20);

                entity.Property(e => e.AUTOLOGIN).HasMaxLength(1);

                entity.Property(e => e.CREATEDATE).HasMaxLength(8);

                entity.Property(e => e.CREATER).HasMaxLength(20);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(100);

                entity.Property(e => e.EMAIL).HasMaxLength(40);

                entity.Property(e => e.LASTDATE).HasMaxLength(8);

                entity.Property(e => e.LASTTIME).HasMaxLength(8);

                entity.Property(e => e.MSAD).HasMaxLength(1);

                entity.Property(e => e.PWD).HasMaxLength(20);

                entity.Property(e => e.SIGNATURE).HasMaxLength(30);

                entity.Property(e => e.USERNAME).HasMaxLength(30);
            });

            modelBuilder.Entity<View_BASE_BASEIO>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_BASE_BASEIO");

                entity.Property(e => e.ACTION_TYPE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EFFECT_EDATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<View_HRD_SCORE_BEHAVIOR_GROUPSUM>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRD_SCORE_BEHAVIOR_GROUPSUM");

                entity.Property(e => e.BEHAVIOR_CONTENT).HasMaxLength(100);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.IS_SELF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RELATION_NAME).HasMaxLength(10);
            });

            modelBuilder.Entity<View_HRD_SCORE_BEHAVIOR_SUM>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRD_SCORE_BEHAVIOR_SUM");

                entity.Property(e => e.BEHAVIOR_CONTENT).HasMaxLength(100);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.IS_SELF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RELATION_NAME).HasMaxLength(10);
            });

            modelBuilder.Entity<View_HRD_SCORE_FUNCTION_GROUPSUM>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRD_SCORE_FUNCTION_GROUPSUM");

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.IS_SELF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RELATION_NAME).HasMaxLength(10);
            });

            modelBuilder.Entity<View_HRD_SCORE_FUNCTION_SUM>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRD_SCORE_FUNCTION_SUM");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FUNCTION_NAME).HasMaxLength(50);

                entity.Property(e => e.IS_SELF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RELATION_NAME).HasMaxLength(10);
            });

            modelBuilder.Entity<View_HRM_ATTEND_OVERTIME_DATA>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_ATTEND_OVERTIME_DATA");

                entity.Property(e => e.BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.END_TIME).HasMaxLength(50);

                entity.Property(e => e.FLOWFLAG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GROUPID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IS_IMPORT).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_ALLOW_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OVERTIME_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_BEGIN).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_DATE_TIME_END).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_EFFECT_DATE).HasColumnType("datetime");

                entity.Property(e => e.OVERTIME_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_NO).HasMaxLength(50);

                entity.Property(e => e.REST_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SALARY_YYMM).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_CREATE).HasMaxLength(50);

                entity.Property(e => e.SYSTEM_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.TOTAL_HOURS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<View_HRM_BASE_BASETTS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_BASE_BASETTS");

                entity.Property(e => e.ATTEND_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.BASETTS_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DIRECT_INDIRECT).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EFFECT_EDATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUP_ID).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(100);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<View_HRM_EMPLOYEE_PARAMETER>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_EMPLOYEE_PARAMETER");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DELAY_MEAL_AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DELAY_MEAL_OVERTIME_INCLUSIVE).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DELAY_MEAL_OVERTIME_OVER).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.HIRE_TYPE).HasMaxLength(50);

                entity.Property(e => e.INSURANCE_TYPE).HasMaxLength(50);

                entity.Property(e => e.IS_DELAY_MEAL).HasMaxLength(50);

                entity.Property(e => e.IS_HOUSEKEEPING).HasMaxLength(50);

                entity.Property(e => e.IS_NOT_CREATE_YEAR_HOLIDAY).HasMaxLength(50);

                entity.Property(e => e.IS_OVERTIME_HOUR).HasMaxLength(50);

                entity.Property(e => e.IS_REST_HOUR).HasMaxLength(50);

                entity.Property(e => e.IS_REST_OVER).HasMaxLength(50);

                entity.Property(e => e.IS_SEND_SHIFT_ALLOWANCE).HasMaxLength(50);

                entity.Property(e => e.IS_TEMPORARY_WORKER).HasMaxLength(50);

                entity.Property(e => e.MONTH_MEETING_GROUP).HasMaxLength(200);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.SALARY_PAY_TYPE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.VD_ACCOUNT).HasMaxLength(50);
            });

            modelBuilder.Entity<View_HRM_SALARY_ATTEND_DATA>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_SALARY_ATTEND_DATA");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EXPENSE_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<View_HRM_SALARY_BASESALARY>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_SALARY_BASESALARY");

                entity.Property(e => e.AMT).HasColumnType("decimal(16, 6)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SALARY_YYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<View_HRM_SALARY_BASETTS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_SALARY_BASETTS");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPENDENTS).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WITHHOLDING_INCOMETAX).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<View_HRM_SALARY_SALBASE_BASETTS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HRM_SALARY_SALBASE_BASETTS");

                entity.Property(e => e.AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EFFECT_EDATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.NAME_C).HasMaxLength(50);

                entity.Property(e => e.SALARY_CNAME).HasMaxLength(50);

                entity.Property(e => e.SALARY_CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<View_SALARY_SALBASE_BASETTS>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_SALARY_SALBASE_BASETTS");

                entity.Property(e => e.AMT).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.EFFECT_EDATE).HasColumnType("date");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<View_WorkFlowItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_WorkFlowItem");

                entity.Property(e => e.APPLICANT)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(500);

                entity.Property(e => e.LISTID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SENDTO_ID)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(500);

                entity.Property(e => e.USERNAME).HasMaxLength(30);
            });

            modelBuilder.Entity<_temp>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.e_code).HasMaxLength(50);

                entity.Property(e => e.e_time).HasMaxLength(50);

                entity.Property(e => e.o_hour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.p_hour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.s_date).HasColumnType("date");

                entity.Property(e => e.s_time).HasMaxLength(50);

                entity.Property(e => e.t_hour).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<輪班津貼檢核表>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("輪班津貼檢核表");

                entity.Property(e => e.公司代碼).HasMaxLength(50);

                entity.Property(e => e.公司名稱).HasMaxLength(50);

                entity.Property(e => e.出勤日期).HasColumnType("date");

                entity.Property(e => e.員工姓名).HasMaxLength(50);

                entity.Property(e => e.員工編號).HasMaxLength(50);

                entity.Property(e => e.實發金額).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.工作時數).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.差額).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.應發金額).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.班別代碼).HasMaxLength(50);

                entity.Property(e => e.班別名稱).HasMaxLength(50);

                entity.Property(e => e.薪資代碼).HasMaxLength(50);

                entity.Property(e => e.薪資名稱).HasMaxLength(50);

                entity.Property(e => e.設定金額).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.請假時數).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.部門代碼).HasMaxLength(50);

                entity.Property(e => e.部門名稱).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
