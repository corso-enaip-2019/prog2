-- SQL mi permette non solo di manipolare i dati dentro le tabelle,
-- ma anche di creare le strutture relazionali del server
-- (i database, le tabelle, le chiavi, ...)

USE [CS2019_Kraus_1]
GO

/****** Object:  Table [dbo].[People3]    Script Date: 30/04/2019 12:50:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- CREATE di una tabella
CREATE TABLE [dbo].[People3](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
 CONSTRAINT [PK_People3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK_People] PRIMARY KEY ( [Id] ASC )
)
GO

CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[Number] [int] NOT NULL,
	[City] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY ( [Id] ASC )
)
GO

select *
from People

select *
from Addresses

-- provo a combinare le due tabelle in un unico risultato:
select
	(p.Name + ' ' + p.Surname) as FullName,
	(a.Street) + ' ' + cast(a.Number as nvarchar) as Address
from People as p, Addresses as a

-- con i where non ci riesco bene.
-- Tra l'altro, provare cosa succede se una persona ha AddressId null.

-- per combinare insieme due tabelle, si usano le JOIN.
-- approfondire a casa le JOIN!
