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
        bool Create(Cashier cashier);

        Cashier Get(Guid id);

        List<Cashier> List();

        bool Update(Cashier cashier, Guid id);

        bool Delete(Guid id);

    }
}
