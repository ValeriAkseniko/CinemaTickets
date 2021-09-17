use TicketDB;
select Halls.Id,Halls.Title,SUM(Places.Capacity) AS Capacity
from Halls
join Rows on Halls.Id = Rows.HallId
join Places on Places.RowId = Rows.Id
Group by Halls.Title,Halls.id 
