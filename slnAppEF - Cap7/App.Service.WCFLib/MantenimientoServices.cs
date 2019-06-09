using App.Data.Repository;
using App.Entities.Base;
using App.Service.WCFLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib
{
    public class MantenimientoServices : IMantenimientoServices
    {
        

     
        public bool DeleteArtist(Artist entity)
        {
            var result = false;
            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepositorys.Remove(entity);
                uw.Complete();

                result = true;
            }
            return result;
        }

        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            var resultado = new List<Artist>();
            using (var uw = new AppUnitOfWork())
            {
                resultado = uw.ArtistRepositorys.GetAll(
                    item => item.Name.Contains(nombre)
                    );
            }
            return resultado;
        }

        public Artist GetByIdArtist(int id)
        {
            var result = new Artist();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepositorys.GetById(id);
            }
            return result;


        }

       

        public IEnumerable<Customer> GetCustomerAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetEmployeeAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetGenreAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetInvoiceAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceLine> GetInvoiceLineAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MediaType> GetMediaTypeAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Playlist> GetPlaylistAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetTrackAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public int InsertAlbum(Album entity)
        {
            throw new NotImplementedException();
        }

        public int InsertArtist(Artist entity)
        {
            var result = 0;
            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepositorys.Add(entity);
                uw.Complete();

                result = entity.ArtistId;
            }
            return result;
        }

    }
}
