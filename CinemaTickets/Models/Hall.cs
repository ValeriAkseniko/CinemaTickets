using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    class Hall
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Row> Rows { get; set; }
        public Hall()
        {
            this.Rows = new List<Row>();
        }
        public Hall(string titel,List<Row> Rows,Guid? id =null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid();
            }
            else
            {
                this.Id = id.Value;
            }
            this.Title = titel;
            this.Rows = Rows;
        }
    }
}
