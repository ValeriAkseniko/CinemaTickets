use TicketDB
go
create view ListOfHalls as
select  Halls.Id,
		Halls.Title, 
		sum(dbo.Places.Capacity) as CapacityHall,
           (select count(*) AS Expr1
            from Rows
            where (HallId = Halls.Id)) AS CountRow,
            (select count(*) AS Expr1
            from Places join Rows ON Places.RowId = Rows.Id
            where (Rows.HallId = Halls.Id)) AS CountPlace
from Halls join Rows on Rows.HallId = Halls.Id
           join Places on Places.RowId = Rows.Id
group by Halls.Id, Halls.Title