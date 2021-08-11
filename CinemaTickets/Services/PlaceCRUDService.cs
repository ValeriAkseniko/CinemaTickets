using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataTransferObjects.Place;

namespace CinemaTickets.Services
{
    public class PlaceCRUDService : IPlaceCRUDService
    {
        public bool Create(PlaceCreateDTO place)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Place entity = new Place
                    {
                        Id = Guid.NewGuid(),
                        Capacity = place.Capacity,
                        Number = place.Number,
                        RowId = place.RowId
                    };
                    db.Places.Add(entity);
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
                Place place = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(place).State = EntityState.Deleted;
                    db.Places.Remove(place);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Place Get(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Place place = db.Places
                        .Include(x => x.Row)
                        .Include(x => x.Row.Hall)
                        .FirstOrDefault(x => x.Id == id);
                    return place;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Place> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Place> places = db.Places
                        .Include(x => x.Row)
                        .Include(x => x.Row.Hall)
                        .ToList();
                    return places;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Place place, Guid id)
        {
            try
            {
                Place entityFromDB = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDB.Capacity = place.Capacity;
                    entityFromDB.Number = place.Number;
                    entityFromDB.RowId = place.RowId;
                    entityFromDB.Row = null;
                    db.Entry(entityFromDB).State = EntityState.Modified;
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
