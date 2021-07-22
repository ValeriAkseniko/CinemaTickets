using CinemaTickets.Models;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IAgeRestrictionsCRUDService
    {
        bool Create(AgeRestriction ageRestrictions);

        AgeRestriction Get(Guid id);

        List<AgeRestriction> List();

        bool Update(AgeRestriction ageRestrictions, Guid id);

        bool Delete(Guid id);
    }
}
