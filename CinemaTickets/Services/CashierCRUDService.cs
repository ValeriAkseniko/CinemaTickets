using CinemaTickets.DataTransferObjects.Cashier;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaTickets.Services
{
    public class CashierCRUDService : ICashierCRUDService
    {
        public bool Create(CashierCreateDTO cashier)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Cashier entity = new Cashier
                    {
                        Id = Guid.NewGuid(),
                        FullName = cashier.FullName
                    };
                    db.Cashiers.Add(entity);
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
                Cashier entity = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Cashiers.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Cashier GetEntity(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Cashier entity = db.Cashiers.FirstOrDefault(x => x.Id == id);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CashierViewDTO Get (Guid id)
        {
            Cashier entity = GetEntity(id);
            CashierViewDTO cashier = new CashierViewDTO
            {
                Id = entity.Id,
                FullName = entity.FullName
            };
            return cashier;
        }

        public List<CashierViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<CashierViewListDTO> result = db.Cashiers.Select(x => new CashierViewListDTO
                    {
                        Id = x.Id,
                        FullName = x.FullName
                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(CashierUpdateDTO cashier, Guid id)
        {
            try
            {
                Cashier entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.FullName = cashier.FullName;
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
