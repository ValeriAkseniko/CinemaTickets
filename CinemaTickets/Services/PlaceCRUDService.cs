using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
                Place place = GetEntity(id);
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

        private Place GetEntity(Guid id)
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

        public PlaceViewDTO Get(Guid id)
        {
            Place entity = GetEntity(id);
            PlaceViewDTO place = new PlaceViewDTO
            {
                Id = entity.Id,
                Capacity = entity.Capacity,
                Number = entity.Number,
                RowId = entity.RowId,
                RowNumber = entity.Row.Number,
                HallId = entity.Row.HallId,
                HallTitle = entity.Row.Hall.Title
            };
            return place;
        }

        public List<PlaceViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<PlaceViewListDTO> result = db.Places.Select(x => new PlaceViewListDTO
                    {
                        Id = x.Id,
                        Capacity = x.Capacity,
                        Number = x.Number,
                        RowId = x.RowId
                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(PlaceUpdateDTO place, Guid id)
        {
            try
            {
                Place entityFromDB = GetEntity(id);
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

        public List<PlaceViewListDTO> ListPagination(int page, int pageSize)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<PlaceViewListDTO> result = db.Places
                        .OrderBy(x => x.Number)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .Select(x => new PlaceViewListDTO
                        {
                        Id = x.Id,
                        Capacity = x.Capacity,
                        Number = x.Number,
                        RowId = x.RowId
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
