﻿using CinemaTickets.DataTransferObjects.Cashier;
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
                Cashier entity = Get(id);
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

        public Cashier Get(Guid id)
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

        public List<Cashier> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Cashier> cashiers = db.Cashiers.ToList();
                    return cashiers;
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
                Cashier entityFromDb = Get(id);
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
