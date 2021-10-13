using CinemaTickets.DataTransferObjects.Cashier;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ICashierCRUDService
    {
        bool Create(CashierCreateDTO cashier);

        CashierViewDTO Get(Guid id);

        List<CashierViewListDTO> List();

        bool Update(CashierUpdateDTO cashier, Guid id);

        bool Delete(Guid id);

        List<CashierViewListDTO> ListPagination(int page, int pageSize);

    }
}
