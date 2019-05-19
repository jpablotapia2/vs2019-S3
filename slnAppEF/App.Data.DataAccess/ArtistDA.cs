using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;
using System.Data.Entity;

namespace App.Data.DataAccess
{
    public class ArtistDA
    {
        public List<Artist> GetAll(string nombre)
        {
            var result = new List<Artist>();

            using (var db = new DBModel())
            {
                result = db.Artist
                    .Where(item => item.Name.Contains(nombre))
                    .OrderBy(item=>item.Name)
                    .ToList();                    
            }

            return result;
        }

        public Artist Get(int id)
        {
            var result = new Artist();

            using (var db=new DBModel())
            {
                //Con Lazy Loading
                //result = db.Artist.Find(id);                  

                //Con INclude (Edger Loading)
                result = db.Artist.Include(item => item.Album)
                        .Where(item => item.ArtistId == id).FirstOrDefault();
                    
            }
            return result;
        }

        public int Insertar(Artist entidad)
        {
            var result = 0;
            using (var db= new DBModel())
            {
                //Agrega la entidad al contexto del EF
                db.Artist.Add(entidad);

                //Se confirma la transacción
                db.SaveChanges();

                result = entidad.ArtistId;
            }

            return result;
        }

        public bool Update(Artist entidad)
        {
            var result = false;
            using (var db= new DBModel())
            {
                //Atachamos la entidad al conexto
                db.Artist.Attach(entidad);

                //cambiar el estado de la entidad
                db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                //se confirma la transacción
                db.SaveChanges();

                result = true;

            }

            return result;
        }

        public bool Delete(int id)
        {
            var result = false;
            using (var db = new DBModel())
            {
                var entity = new Artist();
                entity.ArtistId = id;

                db.Artist.Attach(entity);
                db.Artist.Remove(entity);

                db.SaveChanges();
                result = true;
            }

            return result;
        }
            
    }
}
