using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Ticket
    {
        public Guid Id { get; set; }
        public Film film { get; set; }
        public Hall hall { get; set; }
        public Row row { get; set; }
        public Place place { get; set; }
        public decimal Price { get; set; }
        public Cashier cashier { get; set; }
        public string TypeOfCalculation { get; set; }
        public DateTime DateOfSale { get; set; }
        public Status status { get; set; }
        public Ticket()
        {

        }
        public Ticket(Film film,Hall hall,Row row,Place place,decimal price,Cashier cashir,string typeOfCalculation,Status status)
        {
            this.film = film;
            this.hall = hall;
            this.row = row;
            this.place = place;
            this.Price = price;
            this.cashier = cashier;
            this.TypeOfCalculation = typeOfCalculation;
            this.DateOfSale = DateTime.Now;
            this.status = status;
        }
    }
}
