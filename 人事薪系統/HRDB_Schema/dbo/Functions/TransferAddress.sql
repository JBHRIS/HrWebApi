CREATE FUNCtion dbo.TransferAddress(@Address nvarchar(100))
returns nvarchar(100)
as
begin
--桃園市		桃園區
--中壢市		中壢區
--平鎮市		平鎮區
--八德市		八德區
--楊梅鎮		楊梅區
--龜山鄉		龜山區
--蘆竹鄉		蘆竹區
--龍潭鄉		龍潭區
--大溪鎮		大溪區
--大園鄉		大園區
--觀音鄉		觀音區
--新屋鄉		新屋區
--復興鄉		復興區
--桃園縣		桃園市

	declare @result nvarchar(100)
	set @result=@Address
	declare @Set bit
	set @Set=0--檢查是否已執行
	if (@result like '%桃園區%')
		set @Set=1
	if (@result like '%中壢區%')
		set @Set=1
	if (@result like '%平鎮區%')
		set @Set=1
	if (@result like '%八德區%')
		set @Set=1
	if (@result like '%楊梅區%')
		set @Set=1
	if (@result like '%楊梅區%')
		set @Set=1
	if (@result like '%龜山區%')
		set @Set=1
	if (@result like '%蘆竹區%')
		set @Set=1
	if (@result like '%龍潭區%')
		set @Set=1
	if (@result like '%大溪區%')
		set @Set=1
	if (@result like '%大園區%')
		set @Set=1
	if (@result like '%觀音區%')
		set @Set=1
	if (@result like '%新屋區%')
		set @Set=1
	if (@result like '%復興區%')
		set @Set=1

		declare @Set1 bit
	set @Set1=0--檢查是是否包含區
	--if (@result like '%桃園%')
	--	set @Set1=1
	if (@result like '%中壢%')
		set @Set1=1
	if (@result like '%平鎮%')
		set @Set1=1
	if (@result like '%八德%')
		set @Set1=1
	if (@result like '%楊梅%')
		set @Set1=1
	if (@result like '%楊梅%')
		set @Set1=1
	if (@result like '%龜山%')
		set @Set1=1
	if (@result like '%蘆竹%')
		set @Set1=1
	if (@result like '%龍潭%')
		set @Set1=1
	if (@result like '%大溪%')
		set @Set1=1
	if (@result like '%大園%')
		set @Set1=1
	if (@result like '%觀音%')
		set @Set1=1
	if (@result like '%新屋%')
		set @Set1=1
	if (@result like '%復興%')
		set @Set1=1

	set @result=replace(@result,'中壢市','中壢區')
	set @result=replace(@result,'平鎮市','平鎮區')
	set @result=replace(@result,'八德市','八德區')
	set @result=replace(@result,'楊梅市','楊梅區')
	set @result=replace(@result,'楊梅鎮','楊梅區')
	set @result=replace(@result,'龜山鄉','龜山區')
	set @result=replace(@result,'蘆竹鄉','蘆竹區')
	set @result=replace(@result,'龍潭鄉','龍潭區')
	set @result=replace(@result,'大溪鎮','大溪區')
	set @result=replace(@result,'大園鄉','大園區')
	set @result=replace(@result,'觀音鄉','觀音區')
	set @result=replace(@result,'新屋鄉','新屋區')
	set @result=replace(@result,'復興鄉','復興區')


	if(@Set=0 and @Set1=0)
		set @result=replace(@result,'桃園市','桃園區')	
	set @result=replace(@result,'桃園縣','桃園市')
	if(@result!=@Address)
		set @result=replace(@result,'村','里')
	
	--if(@Set2=1 and @result not like '%桃園市%' )--有區但是沒有桃園市
	--Set @result='桃園市'+@result
	

	return @result
end