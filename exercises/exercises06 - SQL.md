## 1 - TrainStation

Date queste tabelle:

    CREATE TABLE [Companies]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Name] [nvarchar](MAX) NOT NULL,
        [Nationality] [nvarchar](MAX) NOT NULL
    )

    CREATE TABLE [Trains]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Name] [nvarchar](MAX) NOT NULL,
        [Seats] [int] NOT NULL,
        [StepHeight] [float] NOT NULL,
        [CompanyId] [int] NOT NULL
    )

    CREATE TABLE [Departures]
    (
        [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Time] [DateTime] NOT NULL,
        [Rail] [int] NOT NULL,
        [Destination] [nvarchar](MAX) NOT NULL,
        [TrainId] [int] NOT NULL
    )

Scrivi una query che ottenga un elenco di partenze con: orario, nome del treno, nome della compagnia.
Serviranno due join insieme.

Riempi le tabelle con altre partenze, in giorni diversi e orari diversi, e nuovi treni e compagnie, magari straniere.

Scrivi query per ottenere tabelle che mostrino:

- Nome del treno, media delle partenze al giorno
- Nome della compagnia, media delle partenze dei suoi treni al giorno
- per ogni giorno, conto di quante partenze ci sono
- per ogni ora, il conto di quante partenze ci sono (scelto un giorno X)
- la compagnia con più partenze e quella con meno (operatori `max` e `min` su un aggregato fatto col `group by`...)


## 2

Tabella `Persons` con `Id`, `Name`, `BestFriendId`.

`BestFriendId` è nullable, ed è una foreign key verso l'Id della stessa tabella.

Creare la tabella, la foreign key, e riempire con un po' di dati.

Scrivere una query che visualizzi un elenco di persone con: Name, BestFriendName
Andrà fatta una join della tabella su se stessa.


## 3

Tabella `Tenants`, con: `Id`, `Name`, `Surname`, `FlatId`

Tabella `Flats` con `Id`, `Address`, `SquareMeters`, `City`

Creare le tabelle.

Prima delle query bisogna riempire le tabelle con almeno 10 record per tabella, con queste regole:
- duplicare un po' di cognomi e di città
- variare i mq da 50 a 200
- più persone possono stare nello stesso appartamento
- mettere alcune persone con `FlatId` null
- gli `Address` devono essere univoci (aggiungere constraint `unique` sulla colonna)

Scrivere query per ottenere tabelle che mostrino:

- `Name`, `Surname`, `Address`, `City`
- `CompleteName` (concatenati insieme in un'unica colonna), `Address`, `City`
- `CompleteName` (come sopra, ricavando però solo tutti quelli senza appartamento)
- `Address`, `PeopleCount` (indirizzo e quante persone ci stanno dentro)
- `City`, `FlatCount`, (città e quanti appartamenti per città)
- `City`, `PeopleCount` (città, e quante persone hanno un appartamento in quella città)
- `City`, `RichPeopleCount` (città, e quante persone hanno un appartamento sopra i 150 mq)
- `City`, `AverageFlat` (città, e l'estensione media degli appartamenti)
- `City`, `RentedFlats` (città e count degli appartamenti con affittuario)
- `City`, `UnrentedFlats` (città e count degli appartamenti senza affittuario)
- `Surname`, `Count`, `City` (cognome, conto di persone con quel cognome dentro quella città)

Molte di queste query necessitano di `group by` e `join`, combinati in vario modo.
