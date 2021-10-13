using CinemaTickets.DataTransferObjects.AgeRestriction;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IAgeRestrictionsCRUDService
    {
        bool Create(AgeRestrictionCreateDTO ageRestriction);

        List<AgeRestrictionViewListDTO> List();

        bool Update(AgeRestrictionUpdateDTO ageRestrictions, Guid id);

        bool Delete(Guid id);

        AgeRestrictionViewDTO Get(Guid id);

        List<AgeRestrictionViewListDTO> ListPagination(int page, int pageSize);
    }
}
