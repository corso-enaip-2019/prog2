use CS2019_Kraus_1

-- il '%' rappresenta N caratteri "jolly":
select *
from Products
where Name like 'Cesoi%'

-- il '_' rappresenta un singolo carattere "jolly":
select *
from Products
where Name like 'Cesoi_'

-- HAVING mi permette di filtrare sui gruppi invece che sui singoli record:
select
	SUM(Price) as TotalSold,
	Date
from Products
--where Price < 100
group by Date
having SUM(Price) < 100 ;

-- senza lo HAVING, dovrei fare una query annidata:
select TotalSold, Date
from 
	(select
		SUM(Price) as TotalSold,
		Date
	from Products
	group by Date) t
where TotalSold < 100