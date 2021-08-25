using CinemaTickets.DataTransferObjects.Status;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaTickets.Services
{
    public class StatusCRUDService : IStatusCRUDService
    {
        public bool Create(StatusCreateDTO status)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Status entity = new Status
                    {
                        Id = Guid.NewGuid(),
                        Name = status.Name
                    };
                    db.Statuses.Add(entity);
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
                Status entity = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Statuses.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Status GetEntity(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Status status = db.Statuses.FirstOrDefault(x => x.Id == id);
                    return status;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public StatusViewDTO Get(Guid id)
        {
            Status entity = GetEntity(id);
            StatusViewDTO status = new StatusViewDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return status;
        }

        public List<StatusViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<StatusViewListDTO> result = db.Statuses.Select(x => new StatusViewListDTO
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(StatusUpdateDTO status, Guid id)
        {
            try
            {
                Status entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.Name = status.Name;
                    db.Entry(entityFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
