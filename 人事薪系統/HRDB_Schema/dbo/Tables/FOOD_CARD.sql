CREATE TABLE [dbo].[FOOD_CARD] (
    [CODE]        NVARCHAR (50)   NOT NULL,
    [NOBR]        NVARCHAR (50)   NOT NULL,
    [ADATE]       DATETIME        NOT NULL,
    [ONTIME]      NVARCHAR (50)   NOT NULL,
    [CARDNO]      NVARCHAR (50)   NOT NULL,
    [KEY_DATE]    DATETIME        NOT NULL,
    [KEY_MAN]     NVARCHAR (50)   NOT NULL,
    [NOT_TRAN]    BIT             NOT NULL,
    [DAYS]        DECIMAL (16, 2) NOT NULL,
    [REASON]      NVARCHAR (50)   NOT NULL,
    [LOS]         BIT             NOT NULL,
    [IPADD]       NVARCHAR (50)   NOT NULL,
    [MENO]        NVARCHAR (50)   NOT NULL,
    [SERNO]       NVARCHAR (50)   NOT NULL,
    [FULLTIME]    DATETIME        NOT NULL,
    [temperature] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_FOOD_CARD] PRIMARY KEY CLUSTERED ([NOBR] ASC, [ADATE] ASC, [ONTIME] ASC, [CARDNO] ASC)
);

