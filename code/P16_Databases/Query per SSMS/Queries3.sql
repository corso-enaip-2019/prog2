use CS2019_Kraus_1

-- orario, nome del treno, nome della compagnia
select
	d.Time,
	t.Name as TrainName,
	c.Name as CompanyName
from Departures d
	join Trains t on d.TrainId = t.Id
	join Companies c on t.CompanyId = c.Id
order by
	c.Name,
	t.Name,
	d.Time

-- Nome del treno, data, numero di partenze
select
	t.Name,
	cast(d.Time as date) as Date,
	count(*) as Departures
from Trains t
	join Departures d on d.TrainId = t.Id
group by
	cast(d.Time as date),
	t.Name
order by
	t.Name,
	cast(d.Time as date)


-- Nome del treno, media delle partenze al giorno
select
	Name,
	avg(cast(Departures as float)) as AverageDepartures
from (
	select
		t.Name,
		cast(d.Time as date) as Date,
		count(*) as Departures
	from Trains t
		join Departures d on d.TrainId = t.Id
	group by
		cast(d.Time as date),
		t.Name
) as d
group by Name
order by Name



-- Amico e nome del migliore amico
select
	[main].[Name] as [Name],
	[f].[Name] as [Best Friend]
from Friends main
	full outer join Friends f on main.BestFriendId = f.Id

-- una tabella con auto-reference non può impostare foreign-key
-- che abbiano azioni di CASCADE o SET NULL.
-- Quindi per gestire DELETE e UPDATE, devo fare a mano:

--update Friends
--set BestFriendId = NULL where BestFriendId = 9;

--delete from Friends where Id = 9;
