﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HowItShouldBeDone.Models;

namespace HowItShouldBeDone.Repositories
{
    public class AlbumRepository
    {
        private readonly ApplicationDbContext _context;

        public AlbumRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums;
        }

        public IEnumerable<Album> GetAllWithArtist()
        {
            var albums = _context.Albums.Include(a => a.Artist);
            return albums; 
        }
        public Album GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Albums.SingleOrDefault(a => a.ID == id);
        }

        public Album GetByIdWithArtist(int? id)
        {   if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Albums.Include(a => a.Artist).SingleOrDefault(a => a.ID == id);
        }
        
        public void Create(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void Update(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
            _context.SaveChanges();

        }
        public void Delete(int? id)
        {   if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var album = GetById(id);
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}