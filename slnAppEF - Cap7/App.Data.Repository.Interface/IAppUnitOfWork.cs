using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitOfWork:IDisposable
    {
        IArtistRepository ArtistRepositorys { get; set; }
        IAlbumRepository AlbumRepositorys { get; set; }
        ITrackRepository TrackRepositorys { get; set; }
        IGenreRepository GenreRepositorys { get; set; }
        IMediaTypeRepository MediaTypeRepositorys { get; set; }

        ICustomerRepository CustomerRepositorys { get; set; }
        IEmployeeRepository EmployeeRepositorys { get; set; }
        IInvoiceRepository InvoiceRepositorys { get; set; }
        IInvoiceLineRepository InvoiceLineRepositorys { get; set; }
        IPlayListRepository PlayListRepositorys { get; set; }



        int Complete();
    }
}
