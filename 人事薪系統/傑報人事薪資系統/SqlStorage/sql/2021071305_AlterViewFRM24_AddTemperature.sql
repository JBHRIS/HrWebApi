/****** Object:  View [dbo].[FRM24]    Script Date: 2021/7/13 ¤U¤È 01:19:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[FRM24]
AS
SELECT      dbo.CARD.CODE, dbo.CARD.NOBR, dbo.CARD.ADATE, dbo.CARD.ONTIME, dbo.CARD.CARDNO, dbo.CARD.KEY_DATE, dbo.CARD.KEY_MAN, 
                   dbo.CARD.NOT_TRAN, dbo.CARD.DAYS, dbo.CARD.REASON, dbo.CARD.LOS, dbo.CARD.IPADD, dbo.CARD.MENO, dbo.CARD.SERNO, 
                   dbo.BASE.NAME_C, dbo.CARDLOSD.DESCR, dbo.CARD.temperature
FROM         dbo.CARD LEFT OUTER JOIN
                   dbo.CARDLOSD ON dbo.CARD.REASON = dbo.CARDLOSD.CODE LEFT OUTER JOIN
                   dbo.BASE ON dbo.CARD.NOBR = dbo.BASE.NOBR
GO


