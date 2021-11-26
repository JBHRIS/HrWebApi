

/****** Object:  UserDefinedFunction [dbo].[Encode]    Script Date: 2018/6/28 �U�� 03:00:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Encode](@VALUE DECIMAL(18,6))
RETURNS DECIMAL(18,6)
AS
BEGIN
	DECLARE @KEY VARCHAR(50)
	DECLARE @VALD DECIMAL(18,6)
	DECLARE @LCFLAG varchar(50)
	DECLARE @VALSTR varchar(50)
	DECLARE @LL varchar(50)
	DECLARE @VALLEN INT
	DECLARE @STARTPOS INT
	DECLARE @I INT
	DECLARE @AA VARCHAR(50)
	DECLARE @ITMP INT
	DECLARE @INDEX INT
	DECLARE @YY INT
	DECLARE @WW INT
	DECLARE @ZZ INT
	DECLARE @RET DECIMAL(18,6)
	
	SET @LL=''
	SET @KEY='3761532470658472653034873'
	
	BEGIN
		IF @VALUE<0 
			SET @LCFLAG='-'
		ELSE
		SET @LCFLAG='+'
		SET @VALD = CONVERT(DECIMAL(18,6),SUBSTRING(convert(varchar,convert(decimal(18,6),@VALUE)),CHARINDEX('.',convert(varchar,convert(decimal(18,6),@VALUE)),1),LEN(convert(decimal(18,6),@VALUE))))
		SET @VALSTR=RTRIM(LTRIM(SUBSTRING(convert(varchar,convert(decimal(18,6),@VALUE)),1,CHARINDEX('.',convert(varchar,convert(decimal(18,6),@VALUE)),1)-1)))
		SET @VALLEN=LEN(@VALSTR)
		
		SET @STARTPOS=0
		IF (@LCFLAG='+')
			SET @VALSTR=SUBSTRING(@VALSTR,1,LEN(@VALSTR))
		ELSE
			SET @VALSTR=SUBSTRING(@VALSTR,2,LEN(@VALSTR))
		SET @VALLEN=LEN(@VALSTR)
		
		SET @I=0		
		WHILE (1=1)
		BEGIN	
			SET @STARTPOS = @STARTPOS + CONVERT(INT,SUBSTRING(@VALSTR,@I+1,1))--
			SET @STARTPOS = @STARTPOS%10
	
			SET @I=@I+1	
			IF (@I>=@VALLEN)
				BREAK
			ELSE
				CONTINUE
		END

		SET @I=0
		WHILE (1=1)
		BEGIN	
			SET @YY=0
			SET @INDEX=@STARTPOS+@I-1
			IF @INDEX>=0
				SET @YY=CONVERT(INT,SUBSTRING(@KEY,@INDEX+1,1))
			SET @WW=CONVERT(INT,SUBSTRING(@VALSTR,@I+1,1))+ @YY
			SET @ITMP=(ABS(@WW))%10	
			SET @LL=@LL+CONVERT(VARCHAR,@ITMP)
			SET @I=@I+1	
			IF (@I>=@VALLEN)
				BREAK
			ELSE
				CONTINUE
		END
		SET @LL=@LL+CONVERT(VARCHAR,@VALLEN)+CONVERT(VARCHAR,@STARTPOS)
		IF LEN(@LL)=0
			SET @LL=0
		SET @LL=@LCFLAG+@LL	
	
		SET @RET = CONVERT(decimal(18,6),@LL)
			IF (@VALD > 0) 
				IF (@LCFLAG = '-')
					SET @ret = @ret + @VALD * -1 
				ELSE
					SET @ret = @ret + @VALD	
	END
	RETURN @RET
END


GO


