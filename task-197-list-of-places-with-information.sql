use TicketDB;
select Places.Id,Places.Number,Rows.Id,Rows.Number,Halls.Id,Halls.Title
from Places,Rows,Halls
where Places.RowId = Rows.Id and Rows.HallId = Halls.Id


use TicketDB;
select Films.AgeRestrictionId,Films.Description,Films.Duration,Films.Title,Genres.Title
from Films
    left join Genres on Films.GenreId = Genres.Id