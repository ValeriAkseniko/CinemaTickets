using CinemaTickets.DataTransferObjects;
using CinemaTickets.DataTransferObjects.Ticket;
using CinemaTickets.GlobalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTickets.Services
{
    public class SeansService : ISeansService
    {
        private readonly IFilmCRUDService filmCRUDService;
        private readonly IHallCRUDService hallCRUDService;
        private readonly IRowCRUDService rowCRUDService;
        private readonly ITicketCRUDService ticketCRUDService;

        public SeansService()
        {
            filmCRUDService = new FilmCRUDService();
            hallCRUDService = new HallCRUDService();
            rowCRUDService = new RowCRUDService();
            ticketCRUDService = new TicketCRUDService();
        }

        public void CreateSeanse(Guid filmId, Guid hallId, decimal price, DateTime start)
        {         
            var film = filmCRUDService.Get(filmId);
            var hall = hallCRUDService.Get(hallId);
            var rows = rowCRUDService.List();
            rows = rows.Where(x => x.HallId == hall.Id).ToList();

            var placeIds = new List<Guid>();
            foreach (var row in rows)
            {
                placeIds.AddRange(row.PlaceIds);
            }

            var tickets = placeIds.Select(x => new TicketCreateDTO
            {
                CashierId = null,
                DateOfSale = null,
                FilmId = film.Id,
                PlaceId = x,
                Price = price,
                Start = start,
                StatusId = Constants.NotSoldId
            })
                .ToList();
            foreach (var ticket in tickets)
            {
                ticketCRUDService.Create(ticket);
            }

        }
    }
}
