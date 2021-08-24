﻿using CinemaTickets.DataTransferObjects.Genre;
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
    public class GenreCRUDService : IGenreCRUDService
    {
        public bool Create(GenreCreateDTO genre)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Genre entity = new Genre
                    {
                        Id = Guid.NewGuid(),
                        Title = genre.Title,
                        Description = genre.Description

                    };
                    db.Genres.Add(entity);
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
                Genre entity = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    db.Entry(entity).State = EntityState.Deleted;
                    db.Genres.Remove(entity);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre GetEntity(Guid id)
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    Genre entity = db.Genres.FirstOrDefault(x => x.Id == id);
                    return entity;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<GenreViewListDTO> List()
        {
            try
            {
                using (TicketContext db = new TicketContext())
                {
                    List<GenreViewListDTO> result = db.Genres.Select(x => new GenreViewListDTO 
                    {
                        Id = x.Id,
                        Title = x.Title 
                    }).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(GenreUpdateDTO genre, Guid id)
        {
            try
            {
                Genre entityFromDb = GetEntity(id);
                using (TicketContext db = new TicketContext())
                {
                    entityFromDb.Description = genre.Description;
                    entityFromDb.Title = genre.Title;
                    db.Entry(entityFromDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
