use CS2019_MockTest_3
go

--create table Shipments (
--	Id int identity(1,1) primary key not null,
--	StartPortId int not null,
--	EndPortId int not null,
--	StartDate date null,
--	EndDate date null,
--	Kg int,
--	Kind nvarchar(max),
--	State nvarchar(max)
--)
--go

--create table Ports(
--	Id int identity(1,1) primary key not null,
--	Name nvarchar(max),
--	City nvarchar(max),
--	Country nvarchar(max)
--)

--ALTER TABLE Shipments
--ADD CONSTRAINT FK_Shipments_Ports_1 FOREIGN KEY (StartPortId)
--    REFERENCES Ports (Id)
--    ON DELETE CASCADE
--    ON UPDATE CASCADE
--go

--ALTER TABLE Shipments
--ADD CONSTRAINT FK_Shipments_Ports_2 FOREIGN KEY (EndPortId)
--    REFERENCES Ports (Id)
--    ON DELETE CASCADE
--    ON UPDATE CASCADE
--go


-- Id, porto di partenza e porto di arrivo delle spedizioni
-- in stato "Persa",
-- oppure in stato "Spedita" e la cui EndDate sia passata
-- rispetto alla data odierna.

select
	s.Id,
	pStart.Name as StartPort,
	pEnd.Name as EndPort
from Shipments s
	join Ports pStart on s.StartPortId = pStart.Id
	join Ports pEnd on s.EndPortId = pEnd.Id
where (s.State = 'Persa')
	or (s.State = 'Spedita' and s.EndDate is not null and s.EndDate < GETDATE())

-- Nome del porto di partenza, nome del porto di arrivo,
-- numero di giorni del viaggio,
-- ma solo per le spedizioni da o verso l'Italia.

select
	s.Id,
	pStart.[Name] as StartPort,
	pEnd.[Name] as EndPort,
	datediff(day, s.StartDate, s.EndDate) as [Days]
from Shipments s
	join [Ports] pStart on s.StartPortId = pStart.Id
	join [Ports] pEnd on s.EndPortId = pEnd.Id
where (pStart.Country = 'Italia' or pEnd.Country = 'Italia')

-- Nome del paese
-- e peso totale delle spedizioni (Kg) da quel paese,
-- solo per il 2019

select
	pStart.[Country] as StartPortCountry,
	sum(s.Kg) as Kg
from Shipments s
	join [Ports] pStart on s.StartPortId = pStart.Id
where year(s.StartDate) = 2019
group by pStart.[Country]

-- Nome città, massimo peso tra tutte le spedizioni in arrivo,
-- ma solo tra quelle di tipo "Alimentari" o "Alimentari da congelare".

select
	pStart.[Name] + ' - ' + pStart.Country as StartPort,
	max(s.Kg) as Kg
from Shipments s
	join [Ports] pStart on s.StartPortId = pStart.Id
where s.Kind = 'Alimentari' or Kind = 'Alimentari da congelare'
group by pStart.[Name], pStart.[Country]
