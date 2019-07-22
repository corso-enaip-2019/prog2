use master
go

create database PublishingHouse
go

use PublishingHouse
go

create table Authors (
    Id int identity primary key,
    Name nvarchar(max)
)

create table Books (
    Id int identity primary key,
    Title nvarchar(max)
)

create table BooksAuthors (
    AuthorId int,
    BookId int,
    foreign key (AuthorId) references Authors (Id) on delete cascade on update cascade,
    foreign key (BookId) references Books (Id) on delete cascade on update cascade,
    constraint PK_BooksAuthors primary key (AuthorId, BookId)
)

insert into Authors (Name)
values
('Erri De Luca'),
('Alessandro Baricco'),
('Van Roy'),
('Haridi')

insert into Books(Title)
values
('Oceano Mare'),
('Monte Di Dio'),
('Iliade'),
('Computer Programming')

insert into BooksAuthors
(AuthorId, BookId)
values
(1, 2),
(2, 1),
(2, 3),
(3, 4),
(4, 4)
go

select
    a.Name,
    b.Title
from BooksAuthors ba
    join Books b on b.Id = ba.BookId
    join Authors a on a.Id = ba.AuthorId
;