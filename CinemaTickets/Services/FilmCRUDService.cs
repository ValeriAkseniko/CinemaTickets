using CinemaTickets.DataTransferObjects.Film;
using CinemaTickets.GlobalInterfaces;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaTickets.Services
{
    public class FilmCRUDService : IFilmCRUDService
    {
        public bool Create(FilmCreateDTO film)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Film entity = new Film
                    {
                        Id = Guid.NewGuid(),
                        AgeRestrictionId = film.AgeRestrictionId,
                        GenreId = film.GenreId,
                        Description = film.Description,
                        Duration = film.Duration,
                        Title = film.Title
                    };
                    db.Films.Add(entity);
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
                Film entity = GetEntity(id);
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

        private Film GetEntity(Guid id)
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

        public List<FilmViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<FilmViewListDTO> result = db.Films.Select(x => new FilmViewListDTO
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Duration = x.Duration
                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(FilmUpdateDTO film, Guid id)
        {
            try
            {
                Film entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.AgeRestrictionId = film.AgeRestrictionId;
                    entityFromDb.AgeRestriction = null;
                    entityFromDb.GenreId = film.GenreId;
                    entityFromDb.Genre = null;
                    entityFromDb.Description = film.Description;
                    entityFromDb.Duration = film.Duration;
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

        public FilmViewDTO Get(Guid id)
        {
            Film entity = GetEntity(id);
            FilmViewDTO film = new FilmViewDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                AgeRestrictionId = entity.AgeRestrictionId,
                AgeRestrictionTitle = entity.AgeRestriction.Title,
                Description = entity.Description,
                Duration = entity.Duration,
                GenreId = entity.GenreId,
                GenreTitle = entity.Genre.Title
            };
            return film;
        }
    }
}
