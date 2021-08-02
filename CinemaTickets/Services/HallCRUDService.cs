﻿using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Services
{
    public class HallCRUDService : IHallCRUDService
    {
        public bool Create(Hall hall)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    db.Halls.Add(hall);
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
                Hall entity = Get(id);
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

        public Hall Get(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Hall hall = db.Halls.FirstOrDefault(x => x.Id == id);
                    db.SaveChanges();
                    return hall;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Hall> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Hall> halls = db.Halls.ToList();
                    return halls;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Hall hall, Guid id)
        {
            try
            {
                Hall entityFromDb = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.Title = hall.Title;
                    entityFromDb.Rows = hall.Rows;
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