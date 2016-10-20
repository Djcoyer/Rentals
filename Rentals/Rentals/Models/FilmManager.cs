using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rentals.DTOs;
using System.Data.Entity;

namespace Rentals.Models
{
    public class FilmManager
    {
        private static FilmsContext db = new FilmsContext();

        public static List<FilmDto> GetAvailableFilms()
        {
            var films = new List<FilmDto>();
            var db = new FilmsContext().Films;

            foreach (var film in db.Where(p => p.Rented == false))
            {
                var filmDto  = new FilmDto();
                filmDto.Details = film.Details;
                filmDto.FilmId = film.FilmId;
                filmDto.Genre = film.Genre;
                filmDto.Name = film.Name;
                filmDto.NumberofSeries = film.NumberofSeries;
                filmDto.Year = film.Year;
                filmDto.Series = film.Series;
                filmDto.Rented = film.Rented;
                filmDto.Renter = film.Renter;
                films.Add(filmDto);
            }

            return films;
        }

        public static List<FilmDto> GetAllFilms()
        {
            var films = new List<FilmDto>();
            var db = new FilmsContext().Films;

            foreach (var film in db)
            {
                var _film = new FilmDto();
                _film.Details = film.Details;
                _film.FilmId = film.FilmId;
                _film.Genre = film.Genre;
                _film.Name = film.Name;
                _film.NumberofSeries = film.NumberofSeries;
                _film.Year = film.Year;
                _film.Series = film.Series;
                _film.Rented = film.Rented;
                _film.Renter = film.Renter;
                films.Add(_film);
            }

            return films;
        }

        public static void UpdateDbEntry(FilmDto filmDto)
        {
            var entityFilm = db.Films.FirstOrDefault(p => p.FilmId == filmDto.FilmId);
            entityFilm = updateDetails(entityFilm, filmDto);

            try
            {
                db.Entry(entityFilm).State = EntityState.Modified;
                db.SaveChanges();
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private static Film updateDetails(Film entityFilm, FilmDto filmDto)
        {
            entityFilm.Rented= filmDto.Rented;
            entityFilm.Details = filmDto.Details;
            entityFilm.Name = filmDto.Name;
            entityFilm.NumberofSeries = filmDto.NumberofSeries;
            entityFilm.Year = filmDto.Year;
            entityFilm.Genre = filmDto.Genre;
            entityFilm.Series = filmDto.Series;
            entityFilm.Renter = filmDto.Renter;

            return entityFilm;
        }

        public static void CreateDbEntry(FilmDto filmDto)
        {
            var entityFilm = convertToEntity(filmDto);

            try
            {
                db.Films.Add(entityFilm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        private static Film convertToEntity(FilmDto filmDto)
        {
            var entityFilm = new Film();
            entityFilm.Details = filmDto.Details;
            entityFilm.FilmId = filmDto.FilmId;
            entityFilm.Genre = filmDto.Genre;
            entityFilm.Name = filmDto.Name;
            entityFilm.NumberofSeries = filmDto.NumberofSeries;
            entityFilm.Year = filmDto.Year;
            entityFilm.Series = filmDto.Series;
            entityFilm.Rented = filmDto.Rented;
            entityFilm.Renter = filmDto.Renter;

            return entityFilm;
        }

        /*   public static void saveFilms(List<Film> films)
           {
               var db = new FilmsEntities();
               foreach (var film in films)
               {
                   var entityFilm = new Film();
                   entityFilm.FilmId = film.FilmId;
                   entityFilm.Genre = film.Genre;
                   entityFilm.Name = film.Name;
                   entityFilm.Series = film.Series;
                   entityFilm.Year = film.Year;
                   entityFilm.Details = film.Details;
                   db.Films.Add(entityFilm);
               }
               db.SaveChanges();

           }
           */
    }
}



