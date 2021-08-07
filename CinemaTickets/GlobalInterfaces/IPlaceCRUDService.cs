using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataTransferObjects.Place;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IPlaceCRUDService
    {
        bool Create(PlaceCreateDTO place); 
        
        Place Get(Guid id); 
        
        List<Place> List(); 
        
        bool Update(Place place, Guid id); 
        
        bool Delete(Guid id);

    }
}
