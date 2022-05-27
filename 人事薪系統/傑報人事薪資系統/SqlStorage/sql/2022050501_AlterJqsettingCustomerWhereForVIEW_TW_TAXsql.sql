update jqSetting
set CustomerWhere = '(' + CustomerWhere + ') and View_TW_TAX.作業種類 = ''Med'''
where  QuerySetting = 'TW_TAX'
GO