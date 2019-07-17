use CS2019_Kraus_1
go

declare @limit int
set @limit = 20

-- WHILE --
while (select COUNT(*) from Fibonacci) < @limit
begin
	declare @newValue bigint
	set @newValue = (
		select sum(Value)
		from (
			select top(2) Value
			from Fibonacci
			order by Id desc) t)

	insert into Fibonacci
	(Value, Sum)
	values
	(@newValue, (select SUM(Value) from Fibonacci) + @newValue)
	continue
end
select * from Fibonacci
