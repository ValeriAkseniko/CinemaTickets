using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataTransferObjects.Ticket;

namespace CinemaTickets.Services
{
    public class TicketCRUDService : ITicketCRUDService
    {
        public bool Create(TicketCreateDTO ticket)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Ticket entity = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        CashierId = ticket.CashierId,
                        DateOfSale = ticket.DateOfSale,
                        FilmId = ticket.FilmId,
                        PlaceId = ticket.PlaceId,
                        Price = ticket.Price,
                        Start = ticket.Start,
                        StatusId = ticket.StatusId
                    };
                    db.Tickets.Add(entity);
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
                Ticket entity = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Tickets.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Ticket Get(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Ticket entity = db.Tickets
                        .Include(x => x.Place)
                        .Include(x =>x.Place.Row)
                        .Include(x => x.Status)
                        .Include(x => x.Cashier)
                        .Include(x => x.Film)
                        .Include(x => x.Film.AgeRestriction)
                        .Include(x => x.Film.Genre)
                        .FirstOrDefault(x => x.Id == id);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Ticket> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Ticket> tickets = db.Tickets.ToList();
                    return tickets;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(TicketUpdateDTO ticket, Guid id)
        {
            try
            {
                Ticket entityFromDb = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    Ticket entity = new Ticket
                    {
                        CashierId = ticket.CashierId,
                        DateOfSale = ticket.DateOfSale,
                        FilmId = ticket.FilmId,
                        PlaceId = ticket.PlaceId,
                        Price = ticket.Price,
                        Start = ticket.Start,
                        StatusId = ticket.StatusId
                    };
                    entityFromDb.CashierId = entity.CashierId;
                    entityFromDb.Cashier = null;
                    entityFromDb.DateOfSale = entity.DateOfSale;
                    entityFromDb.FilmId = entity.FilmId;
                    entityFromDb.Film = null;
                    entityFromDb.PlaceId = entity.PlaceId;
                    entityFromDb.Place = null;
                    entityFromDb.Price = entity.Price;
                    entityFromDb.Start = entity.Start;
                    entityFromDb.StatusId = entity.StatusId;
                    entityFromDb.Status = null;
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
