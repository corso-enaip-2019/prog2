use CS2019_Kraus_1
go

-- pseudo C#:
-- Employees.Updated += LogBonusesWithDiff

create trigger LogBonusesWithDiff
on Employees
after update
as
begin
	insert into Logs
	(Date, Text)
	(
		select
			getdate() as date,
			('Employee ' +
				cast(combined.Id as nvarchar(max)) + ' - ' +
				Name +
				' updated with TotalBonus of ' +
				cast(combined.NextBonus as nvarchar(max))) +
				' from a previous value of ' +
				cast (combined.PreviusBonus as nvarchar(max))
		from (
			select d.Id,
				d.Name,
				d.TotalBonus as PreviusBonus,
				i.TotalBonus as NextBonus
			from Deleted as d
				join Inserted as i on i.Id = d.Id) combined
	)
end

-- PER PROVARE CHE IL TRIGGER FUNZIONI:
--exec SP_GiveBonusToMoreProductiveEmployees
--	@MinProductivity = 0.8,
--	@MaxCount = 2,
--	@Bonus = 50
