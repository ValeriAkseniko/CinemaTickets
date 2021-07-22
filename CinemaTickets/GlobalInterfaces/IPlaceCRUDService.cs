using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IPlaceCRUDService
    {
        bool Create(Place place); 
        
        Place Get(Guid id); 
        
        List<Place> List(); 
        
        bool Update(Place place, Guid id); 
        
        bool Delete(Guid id);

    }
}
