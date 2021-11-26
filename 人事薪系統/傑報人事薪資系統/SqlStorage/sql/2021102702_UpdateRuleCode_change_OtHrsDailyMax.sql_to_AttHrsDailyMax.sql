update RuleCode
set RuleCode = 'AttHrsDailyMax',RuleName = '單日出勤上限'
where RuleCode = 'OtHrsDailyMax'
GO

update EmployeeRule
set RuleType = 'AttHrsDailyMax'
where RuleType = 'OtHrsDailyMax'
GO