using CinemaTickets.DataTransferObjects.Film;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IFilmCRUDService
    {
        bool Create(FilmCreateDTO film);

        FilmViewDTO Get(Guid id);

        List<FilmViewListDTO> List();

        bool Update(FilmUpdateDTO film, Guid id);

        bool Delete(Guid id);
    }
}
