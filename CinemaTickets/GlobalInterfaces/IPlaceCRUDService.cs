using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using CinemaTickets.DataTransferObjects.Place;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IPlaceCRUDService
    {
        bool Create(PlaceCreateDTO place); 
        
        PlaceViewDTO Get(Guid id); 
        
        List<PlaceViewListDTO> List(); 
        
        bool Update(PlaceUpdateDTO place, Guid id); 
        
        bool Delete(Guid id);

    }
}
