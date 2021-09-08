use TicketDB;
select sum(Capacity)
from Places,Rows
where Places.RowId = Rows.Id and Rows.HallId = '1BD4C29B-CD0B-4909-ADAE-CA1B4B461E8C';

use TicketDB;
select sum(Capacity)
from Places
where Places.RowId = 'DAD80150-5083-4BCA-AF78-307CE73C8A40';