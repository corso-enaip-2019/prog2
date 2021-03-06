-- PANORAMICA QUERY CRUD

-- con il linguaggio SQL posso manipolare i dati delle tabelle
-- di un database relazionale.

-- SELECT
-- select <colonna1>, <colonna2>, ...
-- from <nome tabella>
-- where <condizione1>, <condizione2>, ...

select ([Nome Variabile] + ' ' + Cognome) as NomeCompleto
from People1
where Cognome = 'Rossi' and
	Nome <> 'Mario' and
	Indirizzo is null

-- "uguale" e "diverso" in SQL si esprimono con "=" e "<>"
-- nel caso di comparazione con il valore NULL, devo usare "is" o "is not!"
-- "and" e "or" si esprimono proprio con "and" e "or"

select Cognome, Nome
from People1
order by
	Cognome asc,
	Nome desc

-- INSERT

-- insert into <nome tabella>
-- (<colonna1>, <colonna2>, ...)
-- values
-- (<value1>, <value2>, ...)

insert into People1
(Nome, Cognome, Indirizzo)
values
('Stefano', 'Violetti', 'via del Coroneo 12')

-- UPDATE

-- update <nome tabella>
-- set <campo1> = <valore1>, <campo2> = <valore2>, ...
-- where ...

update People1
set [Nome Variabile] = 'Filippo'
where Nome = 'Filippo'
-- NB: senza condizione "where", TUTTE le righe vengono modificate!

-- DELETE

-- delete from <nome tabella>
-- where ...

delete from People1
where Nome = 'Filippo'
-- NB: senza condizione "where", TUTTE le righe vengono modificate!

-----

select *
from People2
where Id = 2

update People2
set City = 'Trieste'
where Id = 1


-- People2 ha chiave primaria (PK) Id, ma non è autoincrementale,
-- quindi devo calcolare io a mano il nuovo Id:
select max(Id) from People2
-- il risultato è '3', quindi posso scrivere l'insert così:
insert into People2
(Id, Name, Surname)
values
(3, 'Gianfranco', 'Gialli')

-- In People3 invece Id è anche IDENTITY, quindi auto-incrementale
-- gestita in automatico dal database.
insert into People3
(Name, Surname)
values
('Zeus', 'Fulminoso')
