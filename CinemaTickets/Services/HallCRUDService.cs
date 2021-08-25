using CinemaTickets.DataTransferObjects.Hall;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaTickets.Services
{
    public class HallCRUDService : IHallCRUDService
    {
        public bool Create(HallCreateDTO hall)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Hall entity = new Hall
                    {
                        Id = hall.Id,
                        Title = hall.Title
                    };
                    db.Halls.Add(entity);
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
                Hall entity = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Halls.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Hall GetEntity(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Hall hall = db.Halls
                        .Include(x => x.Rows)
                        .FirstOrDefault(x => x.Id == id);
                    return hall;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HallViewDTO Get(Guid id)
        {
            Hall entity = GetEntity(id);
            HallViewDTO hall = new HallViewDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                RowsId = entity.Rows.Select(x => x.Id).ToList()
            };
            return hall;
        }

        public List<HallViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<HallViewListDTO> result = db.Halls.Select(x => new HallViewListDTO
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

        public bool Update(HallUpdateDTO hall, Guid id)
        {
            try
            {
                Hall entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.Title = hall.Title;
                    db.Entry(entityFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
