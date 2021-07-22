using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IRowCRUDService
    {
        bool Create(Row row);

        Row Get(Guid id);

        List<Row> List();

        bool Update(Row row, Guid id);

        bool Delete(Guid id);
    }
}
