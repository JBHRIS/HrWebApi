CREATE TABLE [dbo].[EXP_DEPT] (
    [D_NO]      NVARCHAR (50) NOT NULL,
    [D_NO_DISP] NVARCHAR (50) NULL,
    [D_NAME]    NVARCHAR (50) NULL,
    [D_SUM]     BIT           NULL,
    [KEY_DATE]  DATETIME      NULL,
    [KEY_MAN]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([D_NO] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '費用代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EXP_DEPT', @level2type = N'COLUMN', @level2name = N'D_NO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '費用代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EXP_DEPT', @level2type = N'COLUMN', @level2name = N'D_NO_DISP';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '費用名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EXP_DEPT', @level2type = N'COLUMN', @level2name = N'D_NAME';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '加總欄位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EXP_DEPT', @level2type = N'COLUMN', @level2name = N'D_SUM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '建檔日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EXP_DEPT', @level2type = N'COLUMN', @level2name = N'KEY_DATE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '建檔人員', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EXP_DEPT', @level2type = N'COLUMN', @level2name = N'KEY_MAN';

