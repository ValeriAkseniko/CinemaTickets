using CinemaTickets.DataTransferObjects.Hall;
using CinemaTickets.DataTransferObjects.Rows;
using CinemaTickets.DataTransferObjects.Ticket;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Services
{
    public class SeansSrevice : ISeansService
    {
        public void CreateTicket(Guid filmId, Guid hallId, decimal price, DateTime start)
        {
            throw new NotImplementedException();
        }

        public void CreateSeance(Guid filmId, Guid hallId, decimal price, DateTime start)
        {
            FilmCRUDService filmCRUDService = new FilmCRUDService();
            var film = filmCRUDService.Get(filmId);
            HallCRUDService hallCRUDService = new HallCRUDService();
            var hall = hallCRUDService.Get(hallId);
            RowCRUDService rowCRUDService = new RowCRUDService();
            var rows = rowCRUDService.List();
            rows = rows.Where(x => x.HallId == hall.Id).ToList();

            var placeIds = new List<Guid>();
            foreach (var row in rows)
            {
                placeIds.AddRange(row.PlaceIds);
            }

            //var tickets = placeIds.Select(x => new TicketCreateDTO
            //{
            //Id = Guid.NewGuid(),
            //CashierId = null,
            //})
            //    .ToList();

            throw new NotImplementedException();
        }
    }
}
