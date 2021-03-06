use CS2019_Kraus_1
go

--create table Employees
--(
--	[Id] [int] identity(1,1) primary key NOT NULL,
--	[Name] [nvarchar](max) NOT NULL,
--	[Productivity] [float] NOT NULL,
--	[TotalBonus] [int] NOT NULL,
--)
--create table HistoryEmployees
--(
--	[Id] int identity(1, 1) primary key not null,
--	[EmployeeId] int,
--	[Name] nvarchar(max),
--	[Productivity] float,
--	[Date] Date
--)

declare c cursor for
select [Id], [Name], [Productivity] from Employees

open c

declare
	@EmployeeId int,
	@EmployeeName nvarchar(max),
	@EmployeeProductivity float

fetch next from c into @EmployeeId, @EmployeeName, @EmployeeProductivity

while @@FETCH_STATUS = 0
begin
	insert HistoryEmployees 
	([EmployeeId], [Name], [Productivity], [Date])
	values
	(@EmployeeId, @EmployeeName, @EmployeeProductivity, GETDATE())

	fetch next from c into @EmployeeId, @EmployeeName, @EmployeeProductivity
end

close c
deallocate c

select * from HistoryEmployees