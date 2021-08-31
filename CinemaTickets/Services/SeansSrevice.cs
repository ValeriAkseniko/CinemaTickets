using CinemaTickets.DataTransferObjects.Hall;
using CinemaTickets.DataTransferObjects.Rows;
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
            throw new NotImplementedException();
        }
    }
}
