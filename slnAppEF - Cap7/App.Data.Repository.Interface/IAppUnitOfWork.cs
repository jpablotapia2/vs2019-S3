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

        int Complete();
    }
}
