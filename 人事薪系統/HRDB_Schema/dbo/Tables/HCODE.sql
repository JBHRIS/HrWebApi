CREATE TABLE [dbo].[HCODE] (
    [H_CODE]      NVARCHAR (50)   NOT NULL,
    [H_NAME]      NVARCHAR (50)   NOT NULL,
    [UNIT]        NVARCHAR (50)   NOT NULL,
    [MIN_NUM]     DECIMAL (16, 2) NOT NULL,
    [IN_HOLI]     BIT             NOT NULL,
    [KEY_DATE]    DATETIME        NOT NULL,
    [KEY_MAN]     NVARCHAR (50)   NOT NULL,
    [NOT_DEL]     BIT             NOT NULL,
    [YEAR_REST]   NVARCHAR (50)   NOT NULL,
    [NOAWARD]     BIT             NOT NULL,
    [CALOT]       BIT             NOT NULL,
    [MANG]        BIT             NOT NULL,
    [EF_NIGHT]    BIT             NOT NULL,
    [ATT]         BIT             NOT NULL,
    [DIS_APP]     DECIMAL (16, 2) CONSTRAINT [DF_HCODE_DIS_APP] DEFAULT ((0)) NOT NULL,
    [MAX_NUM]     DECIMAL (16, 2) CONSTRAINT [DF_HCODE_MAX_NUM] DEFAULT ((0)) NOT NULL,
    [CHE]         BIT             CONSTRAINT [DF_HCODE_CHE] DEFAULT ((0)) NOT NULL,
    [DCODE]       NVARCHAR (50)   CONSTRAINT [DF_HCODE_DCODE] DEFAULT ('') NOT NULL,
    [NOT_SUM]     BIT             CONSTRAINT [DF_HCODE_NOT_SUM] DEFAULT ((0)) NOT NULL,
    [EFF_FOOD]    BIT             CONSTRAINT [DF_HCODE_EFF_FOOD] DEFAULT ((0)) NOT NULL,
    [SEX]         NVARCHAR (50)   CONSTRAINT [DF_HCODE_SEX] DEFAULT ('') NOT NULL,
    [DISCONTENT]  BIT             CONSTRAINT [DF_HCODE_DISCONTENT] DEFAULT ((0)) NOT NULL,
    [DISPLAYFORM] BIT             CONSTRAINT [DF_HCODE_DISPLAYFORM] DEFAULT ((0)) NOT NULL,
    [DATEMIN]     DECIMAL (16, 2) CONSTRAINT [DF_HCODE_DATEMIN] DEFAULT ((0)) NOT NULL,
    [DATEUNIT]    NVARCHAR (50)   CONSTRAINT [DF_HCODE_DATEUNIT] DEFAULT ('') NOT NULL,
    [ABSUNIT]     DECIMAL (16, 2) CONSTRAINT [DF_HCODE_ABSUNIT] DEFAULT ((0)) NOT NULL,
    [H_ENAME]     NVARCHAR (50)   CONSTRAINT [DF_HCODE_H_ENAME] DEFAULT ('') NOT NULL,
    [SORT]        INT             CONSTRAINT [DF_HCODE_SORT] DEFAULT ((0)) NOT NULL,
    [H_CODE_DISP] NVARCHAR (50)   NULL,
    [STATION]     BIT             CONSTRAINT [DF_HCODE_STATION] DEFAULT ((0)) NULL,
    [FLOW_GO]     NVARCHAR (50)   CONSTRAINT [DF_HCODE_FLOW_GO] DEFAULT ('0') NULL,
    [FLOW_FINAL]  NVARCHAR (50)   NULL,
    [GROUP_CODE]  NVARCHAR (50)   NULL,
    [FLAG]        NVARCHAR (50)   NULL,
    [HTYPE]       NVARCHAR (50)   NULL,
    CONSTRAINT [PK_HCODE] PRIMARY KEY CLUSTERED ([H_CODE] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'假別代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'HCODE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'假別代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'HCODE', @level2type = N'COLUMN', @level2name = N'H_CODE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'假別名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'HCODE', @level2type = N'COLUMN', @level2name = N'H_NAME';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'單位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'HCODE', @level2type = N'COLUMN', @level2name = N'UNIT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最小單位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'HCODE', @level2type = N'COLUMN', @level2name = N'MIN_NUM';

