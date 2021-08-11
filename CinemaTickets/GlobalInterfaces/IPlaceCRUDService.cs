using CinemaTickets.Models;
using System;
using System.Collections.Generic;
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
