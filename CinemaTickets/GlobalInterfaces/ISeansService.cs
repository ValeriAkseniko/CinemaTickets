using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface ISeansService
    {
        void CreateTicket(Guid filmId, Guid hallId, decimal price, DateTime start);

        void CreateSeance(Guid filmId, Guid hallId, decimal price, DateTime start);
    }
}
