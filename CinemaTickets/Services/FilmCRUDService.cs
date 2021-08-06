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
    public class FilmCRUDService : IFilmCRUDService
    {
        public bool Create(Film film)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    db.Films.Add(film);
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
                Film entity = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Films.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Film Get(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Film entity = db.Films
                        .Include(x => x.Genre)
                        .Include(x => x.AgeRestriction)
                        .FirstOrDefault(x => x.Id == id);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Film> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<Film> films = db.Films.ToList();
                    return films;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Film film, Guid id)
        {
            try
            {
                Film entityFromDb = Get(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.AgeRestriction = film.AgeRestriction;
                    entityFromDb.Description = film.Description;
                    entityFromDb.Duration = film.Duration;
                    entityFromDb.Genre = film.Genre;
                    entityFromDb.Title = film.Title;
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
