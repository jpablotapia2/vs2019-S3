using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queris;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TrackQuery> ReporteTrack(string trackName)
        {
            return _context.Database.SqlQuery<TrackQuery>(
                "usp_Get_Tracks @trackName",
                new SqlParameter("@trackName", trackName)).ToList();
        }
    }
}
