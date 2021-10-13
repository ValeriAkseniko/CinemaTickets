using CinemaTickets.DataTransferObjects.Hall;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IHallCRUDService
    {
        bool Create(HallCreateDTO hall);

        List<HallViewListDTO> List();

        HallViewDTO Get(Guid id);

        bool Update(HallUpdateDTO hall, Guid id);

        bool Delete(Guid id);

        List<HallViewListDTO> ListPagination(int page, int pageSize);
    }
}
