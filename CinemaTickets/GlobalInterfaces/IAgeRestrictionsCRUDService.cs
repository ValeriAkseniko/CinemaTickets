using CinemaTickets.Models;
using System;
using System.Collections.Generic;

namespace CinemaTickets.GlobalInterfaces
{
    public interface IAgeRestrictionsCRUDService
    {
        bool Create(AgeRestrictions ageRestrictions);

        AgeRestrictions Get(Guid id);

        List<AgeRestrictions> List();

        bool Update(AgeRestrictions ageRestrictions, Guid id);

        bool Delete(Guid id);
    }
}
