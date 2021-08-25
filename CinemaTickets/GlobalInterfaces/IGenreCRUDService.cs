using CinemaTickets.DataTransferObjects.Genre;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IGenreCRUDService
    {
        bool Create(GenreCreateDTO genreCreateDTO);

        GenreViewDTO Get(Guid id);

        List<GenreViewListDTO> List();

        bool Update(GenreUpdateDTO genre, Guid id);

        bool Delete(Guid id);
    }
}
