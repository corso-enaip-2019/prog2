--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

-- posso creare una FUNCTION che mi restituisca una tabella di valori:

--CREATE FUNCTION GetMoreProductiveEmployees
--(	
--	@Count int
--)
--RETURNS TABLE 
--AS
--RETURN 
--(
--	select top(@Count) Id
--	from Employees
--	order by Productivity desc
--)
--GO

-- una volta creata una funzione "tabella", posso usarla
-- come qualsiasi altra tabella:
select * from GetMoreProductiveEmployees(2)

-- anche in costrutti più complessi come le join:
select e.Id, e.Name
from Employees e
	join GetMoreProductiveEmployees(2) as p on p.Id = e.Id




-- le store procedure

--ALTER PROCEDURE SP_GiveBonusToMoreProductiveEmployees
--	@Count int,
--	@Bonus int
--AS
--BEGIN
--	SET NOCOUNT ON;

--	update Employees
--	set TotalBonus = TotalBonus + @Bonus
--	where Id in (select * from GetMoreProductiveEmployees(@Count))

--	select * from Employees
--END
--GO

exec SP_GiveBonusToMoreProductiveEmployees @Count=2, @Bonus=100
