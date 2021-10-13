using CinemaTickets.DataTransferObjects.Genre;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IGenreCRUDService
    {
        bool Create(GenreCreateDTO genreCreateDTO);

        GenreViewDTO Get(Guid id);

        List<GenreViewListDTO> List();

        bool Update(GenreUpdateDTO genre, Guid id);

        bool Delete(Guid id);

        List<GenreViewListDTO> ListPagination(int page, int pageSize);
    }
}
