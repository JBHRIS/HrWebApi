create function f_split(@c nvarchar(Max),@split nvarchar(2)) 
returns @t table(col nvarchar(50)) 
as 
    begin 
      while(charindex(@split,@c)<>0) 
        begin 
          insert @t(col) values (substring(@c,1,charindex(@split,@c)-1)) 
          set @c = stuff(@c,1,charindex(@split,@c),'') 
        end 
      insert @t(col) values (@c) 
      return 
    end 
go 