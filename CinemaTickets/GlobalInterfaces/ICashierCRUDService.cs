using CinemaTickets.DataTransferObjects.Cashier;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ICashierCRUDService
    {
        bool Create(CashierCreateDTO cashier);

        Cashier GetEntity(Guid id);

        List<CashierViewListDTO> List();

        bool Update(CashierUpdateDTO cashier, Guid id);

        bool Delete(Guid id);

    }
}
