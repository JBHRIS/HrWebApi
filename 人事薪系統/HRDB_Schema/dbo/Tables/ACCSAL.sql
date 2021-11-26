CREATE TABLE [dbo].[ACCSAL] (
    [D_NO]     NVARCHAR (50) NOT NULL,
    [ACCCD]    NVARCHAR (50) NOT NULL,
    [CODE_D]   NVARCHAR (50) NULL,
    [CODE_C]   NVARCHAR (50) NULL,
    [KEY_DATE] DATETIME      NULL,
    [KEY_MAN]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([D_NO] ASC, [ACCCD] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '費用代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ACCSAL', @level2type = N'COLUMN', @level2name = N'D_NO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '科目代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ACCSAL', @level2type = N'COLUMN', @level2name = N'ACCCD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '借方科目', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ACCSAL', @level2type = N'COLUMN', @level2name = N'CODE_D';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '貸方科目', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ACCSAL', @level2type = N'COLUMN', @level2name = N'CODE_C';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '建檔日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ACCSAL', @level2type = N'COLUMN', @level2name = N'KEY_DATE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '建檔人員', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ACCSAL', @level2type = N'COLUMN', @level2name = N'KEY_MAN';

