use TicketDB;
select sum(Capacity)
from Places,Rows,Halls
where Places.RowId = Rows.Id and Rows.HallId = Halls.Id
--Hall.id = id звлв

use TicketDB;
select sum(Capacity)
from Places,Rows
where Places.RowId = Rows.Id
--Row.id = id ряда