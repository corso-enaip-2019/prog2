SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- come inserire la select in una stored procedure.
-- in questo caso abbiamo aggiunto anche il parametro 'country'
-- per selezionare solo le spedizioni problematiche da un certo paese.

CREATE PROCEDURE SP_GetProblematicShipments
	@country nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

    select
		s.Id,
		pStart.Name as StartPort,
		pEnd.Name as EndPort
	from Shipments s
		join Ports pStart on s.StartPortId = pStart.Id
		join Ports pEnd on s.EndPortId = pEnd.Id
	where ((s.State = 'Persa')
		or (s.State = 'Spedita' and s.EndDate is not null and s.EndDate < GETDATE()))
		and (pStart.Country = @country)
END
GO
