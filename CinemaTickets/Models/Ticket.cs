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
        public Film Film { get; set; }
        public Place Place { get; set; }
        public decimal Price { get; set; }
        public Cashier Cashier { get; set; }
        public TypeOfCalculation TypeOfCalculation { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime Start { get; set; }
        public Status Status { get; set; }
        public Ticket()
        {

        }
        public Ticket(Film film,Place place,decimal price,Cashier cashier,TypeOfCalculation typeOfCalculation,Status status,DateTime dateOfSale,DateTime start,Guid? id=null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.Film = film;
            this.Place = place;
            this.Price = price;
            this.Cashier = cashier;
            this.TypeOfCalculation = typeOfCalculation;
            this.DateOfSale = dateOfSale;
            this.Status = status;
            this.Start = start;
        }
    }
}
