using CinemaTickets.DataTransferObjects.Film;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
