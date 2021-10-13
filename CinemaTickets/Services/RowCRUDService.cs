using CinemaTickets.DataTransferObjects.Rows;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaTickets.Services
{
    public class RowCRUDService : IRowCRUDService
    {
        public bool Create(RowCreateDTO row)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Row entity = new Row
                    {
                        Id = Guid.NewGuid(),
                        Number = row.Number,
                        HallId = row.HallId
                    };
                    db.Rows.Add(entity);
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
                Row entity = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Rows.Remove(entity);
                    db.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private Row GetEntity(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Row entity = db.Rows
                        .Include(x => x.Hall)
                        .FirstOrDefault(x => x.Id == id);

                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RowViewDTO Get(Guid id)
        {
            Row entity = GetEntity(id);
            RowViewDTO row = new RowViewDTO
            {
                Id = entity.Id,
                Number = entity.Number,
                HallId = entity.HallId,
                HallTitle = entity.Hall.Title,
                PlacesIds = entity.Places.Select(x => x.Id).ToList()
            };
            return row;
        }

        public List<RowViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<RowViewListDTO> result = db.Rows
                        .Include(x => x.Places)
                        .Select(x => new RowViewListDTO
                        {
                            Id = x.Id,
                            Number = x.Number,
                            HallId = x.HallId,
                            PlaceIds = x.Places.Select(p => p.Id).ToList()
                        }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(RowUpdateDTO row, Guid id)
        {
            try
            {
                Row entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.Number = row.Number;
                    entityFromDb.HallId = row.HallId;
                    entityFromDb.Hall = null;
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

        public List<RowViewListDTO> ListPagination(int page, int pageSize)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<RowViewListDTO> result = db.Rows
                        .OrderBy(x => x.Number)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Places)
                        .Select(x => new RowViewListDTO
                        {
                            Id = x.Id,
                            Number = x.Number,
                            HallId = x.HallId,
                            PlaceIds = x.Places.Select(p => p.Id).ToList()
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
