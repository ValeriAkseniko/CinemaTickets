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
                Row entity = Get(id);
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

        public Row Get(Guid id)
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

        public List<Row> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Row> rows = db.Rows
                        .Include(x=>x.Hall)
                        .ToList();
                    return rows;
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
                Row entityFromDb = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    Row entity = new Row
                    {
                        Number = row.Number,
                        HallId = row.HallId
                    };
                    entityFromDb.Number = entity.Number;
                    entityFromDb.HallId = entity.HallId;
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
    }
}
