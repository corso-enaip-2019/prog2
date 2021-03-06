USE [CS2019_Kraus_1]
GO
/****** Object:  StoredProcedure [dbo].[SP_GiveBonusToMoreProductiveEmployees]    Script Date: 07/05/2019 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_GiveBonusToMoreProductiveEmployeesVar]
	@MinProductivity float,
	@MaxCount int,
	@Bonus int
AS
BEGIN
	SET NOCOUNT ON;

	-- posso dichiarare una variabile scalare:
	declare @count int
	-- e assegnare valori:
	set @count = 1

	-- oppure una variabile di tipo tabella (specificando lo schema):
	declare @aboveProd table (Pippo int)
	-- e inserire valori:
	insert @aboveProd (Pippo)
	(select * from GetEmployeesAboveProductivity(@MinProductivity))

	if (select count(*) from @aboveProd) > @MaxCount
		begin
			update Employees
			set TotalBonus = TotalBonus + @Bonus
			where Id in (select * from GetMoreProductiveEmployees(@MaxCount))
		end
	else
		begin
			update Employees
			set TotalBonus = TotalBonus + @Bonus
			where Id in (select * from @aboveProd)
		end
END


exec [SP_GiveBonusToMoreProductiveEmployeesVar]
	@MinProductivity=0.8,
	@MaxCount=2,
	@Bonus = 3

select * from Employees