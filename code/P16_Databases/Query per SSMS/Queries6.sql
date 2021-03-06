USE [CS2019_Kraus_1]
GO
/****** Object:  StoredProcedure [dbo].[SP_GiveBonusToMoreProductiveEmployees]    Script Date: 07/05/2019 16:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_GiveBonusToMoreProductiveEmployees]
	@MinProductivity float,
	@MaxCount int,
	@Bonus int
AS
BEGIN
	SET NOCOUNT ON;

	-- OPERAZIONI DA FARE, SCRITTE IN PSEUDO-CODICE:
	-- if count(GetEmployeesAboveProductivity) > @MaxCount
		-- TotalBonus += @Bonus
		-- where Id in GetMoreProductiveEmployees(@MaxCount)
	-- else
	    -- TotalBonus += @Bonus
		-- where Id in GetEmployeesAboveProductivity(@MinProductivity)

	if (select count(*) from GetEmployeesAboveProductivity(@MinProductivity)) > @MaxCount
		begin
			update Employees
			set TotalBonus = TotalBonus + @Bonus
			where Id in (select * from GetMoreProductiveEmployees(@MaxCount))
		end
	else
		begin
			update Employees
			set TotalBonus = TotalBonus + @Bonus
			where Id in (select * from GetEmployeesAboveProductivity(@MinProductivity))
		end
END
