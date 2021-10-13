using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
                Ticket entity = GetEntity(id);
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

        private Ticket GetEntity(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Ticket entity = db.Tickets
                        .Include(x => x.Place)
                        .Include(x => x.Place.Row)
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

        public TicketViewDTO Get(Guid id)
        {
            Ticket entity = GetEntity(id);
            TicketViewDTO ticket = new TicketViewDTO
            {
                Id = entity.Id,
                FilmId = entity.FilmId,
                FilmTitle = entity.Film.Title,
                PlaceId = entity.PlaceId,
                PlaceNumber = entity.Place.Number,
                RowId = entity.Place.RowId,
                RowNumber = entity.Place.Row.Number,
                HallId = entity.Place.Row.HallId,
                HallTitle = entity.Place.Row.Hall.Title,
                StatusId = entity.StatusId,
                StatusTitle = entity.Status.Name,
                CashierId = entity.CashierId,
                CashierName = entity.Cashier.FullName,
                TypeOfCalculation = entity.TypeOfCalculation,
                DateOfSale = entity.DateOfSale,
                Start = entity.Start,
                Price = entity.Price
            };
            return ticket;
        }

        public List<TicketViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<TicketViewListDTO> result = db.Tickets.Select(x => new TicketViewListDTO
                    {
                        Id = x.Id,
                        FilmTitle = x.Film.Title,
                        HallTitle = x.Place.Row.Hall.Title,
                        PlaceNumber = x.Place.Number,
                        RowNumber = x.Place.Row.Number,
                        Price = x.Price,
                        Start = x.Start
                    }).ToList();
                    return result;
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
                Ticket entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.CashierId = ticket.CashierId;
                    entityFromDb.Cashier = null;
                    entityFromDb.DateOfSale = ticket.DateOfSale;
                    entityFromDb.FilmId = ticket.FilmId;
                    entityFromDb.Film = null;
                    entityFromDb.PlaceId = ticket.PlaceId;
                    entityFromDb.Place = null;
                    entityFromDb.Price = ticket.Price;
                    entityFromDb.Start = ticket.Start;
                    entityFromDb.StatusId = ticket.StatusId;
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

        public List<TicketViewListDTO> ListPagination(int page, int pageSize)
        {
            try
            {
                using (TicketContext db =new TicketContext())
                {
                    List<TicketViewListDTO> result = db.Tickets
                        .OrderBy(x => x.Start)
                        .Skip(page * pageSize)
                        .Take(pageSize)
                        .Select(x => new TicketViewListDTO
                        {
                        Id = x.Id,
                        FilmTitle = x.Film.Title,
                        HallTitle = x.Place.Row.Hall.Title,
                        PlaceNumber = x.Place.Number,
                        RowNumber = x.Place.Row.Number,
                        Price = x.Price,
                        Start = x.Start
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
