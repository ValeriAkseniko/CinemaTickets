using CinemaTickets.DataTransferObjects.Rows;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IRowCRUDService
    {
        bool Create(RowCreateDTO row);

        RowViewDTO Get(Guid id);

        List<RowViewListDTO> List();

        bool Update(RowUpdateDTO row, Guid id);

        bool Delete(Guid id);
    }
}
