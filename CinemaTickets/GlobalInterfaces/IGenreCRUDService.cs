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
        bool Create(Genre genre);

        Genre Get(Guid id);

        List<Genre> List();

        bool Update(Genre genre, Guid id);

        bool Delete(Guid id);
    }
}
