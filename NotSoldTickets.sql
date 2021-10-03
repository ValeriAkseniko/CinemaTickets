use TicketDB
go
create view NotSoldTickets as
select  Tickets.Id as TicketsId,
		Films.Title as FilmTitle,
		Tickets.Start as StartSeance,
		Places.Number as PlaceNumber,
		Rows.Number as RowNumber,
		Halls.Title as HallTitel,
		Status.Name as Status,
	    DATEADD(MINUTE,Films.Duration,Tickets.Start) as EndSeance
From Tickets join Films on Tickets.FilmId = Films.Id
			 join Status on Tickets.StatusId = Status.Id
			 join Places on Tickets.PlaceId = Places.Id
			 join Rows on Places.RowId = Rows.Id
			 join Halls on Rows.HallId = Halls.Id
where Tickets.StatusId = 'FEB65CA9-9760-44E7-A65C-52ABB01C35FE'