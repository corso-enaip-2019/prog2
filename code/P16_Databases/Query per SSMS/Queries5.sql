USE [CS2019_Kraus_1]
GO
/****** Object:  UserDefinedFunction [dbo].[GetMoreProductiveEmployees]    Script Date: 07/05/2019 16:30:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[GetEmployeesAboveProductivity]
(
	@MinProductivity float
)
RETURNS TABLE 
AS
RETURN 
(
	select Id
	from Employees
	where Productivity >= @MinProductivity
)
