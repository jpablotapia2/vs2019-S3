using App.Entities.Base;
using App.Entities.Queris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface ITrackRepository:IGenericRepository<Track>
    {
        IEnumerable<TrackQuery> ReporteTrack(string trackName);
    }
}
