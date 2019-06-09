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
            this.GenreRepositorys = new GenreRepository(_context);
            this.MediaTypeRepositorys = new MediaTypeRepository(_context);
            this.CustomerRepositorys = new CustomerRepository(_context);
            this.EmployeeRepositorys = new EmployeeRepository(_context);
            this.InvoiceRepositorys = new InvoiceRepository(_context);
            this.InvoiceLineRepositorys = new InvoiceLineRepository(_context);
            this.PlayListRepositorys = new PlayListRepository(_context);
        }

        public IArtistRepository ArtistRepositorys { get; set; }
        public IAlbumRepository AlbumRepositorys { get; set; }
        public ITrackRepository TrackRepositorys { get; set; }
        public IGenreRepository GenreRepositorys { get; set; }
        public IMediaTypeRepository MediaTypeRepositorys { get; set; }
        public ICustomerRepository CustomerRepositorys { get; set; }
        public IEmployeeRepository EmployeeRepositorys { get; set; }
        public IInvoiceRepository InvoiceRepositorys { get; set; }
        public IInvoiceLineRepository InvoiceLineRepositorys { get; set; }
        public IPlayListRepository PlayListRepositorys { get; set; }


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
