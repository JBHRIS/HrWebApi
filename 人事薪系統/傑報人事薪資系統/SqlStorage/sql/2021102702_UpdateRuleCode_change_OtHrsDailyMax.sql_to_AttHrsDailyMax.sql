update RuleCode
set RuleCode = 'AttHrsDailyMax',RuleName = '���X�ԤW��'
where RuleCode = 'OtHrsDailyMax'
GO

update EmployeeRule
set RuleType = 'AttHrsDailyMax'
where RuleType = 'OtHrsDailyMax'
GO