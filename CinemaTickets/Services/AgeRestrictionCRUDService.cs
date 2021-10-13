using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                AgeRestriction entity = GetEntity(id);
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

        private AgeRestriction GetEntity(Guid id)
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

        public List<AgeRestrictionViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<AgeRestrictionViewListDTO> result = db.AgeRestrictions.Select(x => new AgeRestrictionViewListDTO
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToList();

                    return result;
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
                AgeRestriction entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.Title = ageRestrictions.Title;
                    entityFromDb.MinAge = ageRestrictions.MinAge;
                    entityFromDb.Description = ageRestrictions.Description;
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

        public AgeRestrictionViewDTO Get(Guid id)
        {
            AgeRestriction entity = GetEntity(id);
            AgeRestrictionViewDTO ageRestriction = new AgeRestrictionViewDTO
            {
                Id = entity.Id,
                MinAge = entity.MinAge,
                Description = entity.Description,
                Title = entity.Title
            };
            return ageRestriction;
        }

        public List<AgeRestrictionViewListDTO> ListPagination(int page, int pageSize)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<AgeRestrictionViewListDTO> result = db.AgeRestrictions
                        .OrderBy(x => x.Title)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .Select(x => new AgeRestrictionViewListDTO
                        {
                            Id = x.Id,
                            Title = x.Title
                        }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
