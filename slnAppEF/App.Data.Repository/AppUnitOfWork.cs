using App.Data.DataAccess;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new DBModel();
            this.ArtistRepositorys = new ArtistRepository(_context);
            this.AlbumRepositorys = new AlbumRepository(_context);
            this.TrackRepositorys = new TrackRepository(_context);
        }

        public IArtistRepository ArtistRepositorys { get; set; }
        public IAlbumRepository AlbumRepositorys { get; set; }
        public ITrackRepository TrackRepositorys { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
