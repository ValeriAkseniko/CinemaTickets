﻿using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataTransferObjects.AgeRestriction;

namespace CinemaTickets.Services
{
    public class AgeRestrictionCRUDService : IAgeRestrictionsCRUDService
    {
        public bool Create(AgeRestrictionCreateDTO ageRestriction)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    AgeRestriction entity = new AgeRestriction
                    {
                        Id = Guid.NewGuid(),
                        Title = ageRestriction.Title,
                        Description = ageRestriction.Description,
                        MinAge = ageRestriction.MinAge
                    };
                    db.AgeRestrictions.Add(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                AgeRestriction entity = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.AgeRestrictions.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AgeRestriction Get(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    AgeRestriction entity = db.AgeRestrictions.FirstOrDefault(x => x.Id == id);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AgeRestriction> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<AgeRestriction> ageRestrictions = db.AgeRestrictions.ToList();
                    return ageRestrictions;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(AgeRestrictionUpdateDTO ageRestrictions, Guid id)
        {
            try
            {
                AgeRestriction entityFromDb = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    AgeRestriction entity = new AgeRestriction
                    {
                        Title = ageRestrictions.Title,
                        MinAge = ageRestrictions.MinAge,
                        Description = ageRestrictions.Description
                    };
                    entityFromDb.Title = entity.Title;
                    entityFromDb.MinAge = entity.MinAge;
                    entityFromDb.Description = entity.Description;
                    db.Entry(entityFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
