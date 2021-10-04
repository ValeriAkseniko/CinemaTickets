use TicketDB
go
create view ListOfFilms as
select  Films.Title as Title,
		AgeRestrictions.Title as AgeRestrictions,
		Genres.Title as Genre
from Films join AgeRestrictions on Films.AgeRestrictionId = AgeRestrictions.Id
           join Genres on Films.GenreId = Genres.Id
group by Films.Title,AgeRestrictions.Title,Genres.Title