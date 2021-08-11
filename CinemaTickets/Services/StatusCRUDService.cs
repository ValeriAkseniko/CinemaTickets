using CinemaTickets.DataTransferObjects.Status;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Status entity = Get(id);
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

        public Status Get(Guid id)
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

        public List<Status> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Status> statuses = db.Statuses.ToList();
                    return statuses;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Status status, Guid id)
        {
            try
            {
                Status entityFromDb = Get(id);
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
