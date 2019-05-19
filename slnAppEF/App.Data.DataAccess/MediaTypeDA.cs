using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;

namespace App.Data.DataAccess
{
    public class MediaTypeDA
    {
        public IEnumerable<MediaType> GetAll()
        {
            var result = new List<MediaType>();
            using (var db= new DBModel())
            {
                result = db.MediaType.ToList();
            }
            return result;
        }
    }
}
