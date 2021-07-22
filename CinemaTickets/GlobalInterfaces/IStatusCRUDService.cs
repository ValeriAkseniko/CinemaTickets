using System;
using CinemaTickets.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IStatusCRUDService
    {
        bool Create(Status status);

        Status Get(Guid id);

        List<Status> List();

        bool Update(Status status, Guid id);

        bool Delete(Guid id);
    }
}
