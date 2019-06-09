using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib.Interfaces
{
    [ServiceContract]
    public interface IMantenimientoServices
    {
        #region Artista
        [OperationContract]
        IEnumerable<Artist> GetArtistAll(string nombre);

        [OperationContract]
        int InsertArtist(Artist entity);

        [OperationContract]
        bool UpdateArtist(Artist entity);

        [OperationContract]
        bool DeleteArtist(Artist entity);

        [OperationContract]
        Artist GetByIdArtist(int id);
        #endregion

        #region Album
        [OperationContract]
        IEnumerable<Album> GetAlbumAll(string nombre);

        [OperationContract]
        int InsertAlbum(Album entity);

        [OperationContract]
        bool UpdateAlbum(Album entity);

        [OperationContract]
        bool DeleteAlbum(Album entity);

        [OperationContract]
        Album GetByIdAlbum(int id);
        #endregion
        


        //#region Customer
        //[OperationContract]
        //IEnumerable<Customer> GetCustomerAll(string nombre);

        //[OperationContract]
        //int InsertCustomer(Customer entity);

        //[OperationContract]
        //bool UpdateCustomer(Customer entity);

        //[OperationContract]
        //bool DeleteCustomer(Customer entity);

        //[OperationContract]
        //Customer GetByIdCustomer(int id);
        //#endregion

        //#region Employee
        //[OperationContract]
        //IEnumerable<Customer> GetEmployeeAll(string nombre);

        //[OperationContract]
        //int InsertEmployee(Employee entity);

        //[OperationContract]
        //bool UpdateEmployee(Employee entity);

        //[OperationContract]
        //bool DeleteEmployee(Employee entity);

        //[OperationContract]
        //Employee GetByIdEmployee(int id);
        //#endregion

        //#region Genre
        //[OperationContract]
        //IEnumerable<Genre> GetGenreAll(string nombre);

        //[OperationContract]
        //int InsertGenre(Genre entity);

        //[OperationContract]
        //bool UpdateGenre(Genre entity);

        //[OperationContract]
        //bool DeleteGenre(Genre entity);

        //[OperationContract]
        //Genre GetByIdGenre(int id);
        //#endregion

        //#region Invoice
        //[OperationContract]
        //IEnumerable<Invoice> GetInvoiceAll(string nombre);

        //[OperationContract]
        //int InsertInvoice(Invoice entity);

        //[OperationContract]
        //bool UpdateInvoice(Invoice entity);

        //[OperationContract]
        //bool DeleteInvoice(Invoice entity);

        //[OperationContract]
        //Invoice GetByIdInvoice(int id);
        //#endregion

        //#region InvoiceLine
        //[OperationContract]
        //IEnumerable<InvoiceLine> GetInvoiceLineAll(string nombre);

        //[OperationContract]
        //int InsertInvoiceLine(InvoiceLine entity);

        //[OperationContract]
        //bool UpdateInvoiceLine(InvoiceLine entity);

        //[OperationContract]
        //bool DeleteInvoiceLine(InvoiceLine entity);

        //[OperationContract]
        //InvoiceLine GetByIdInvoiceLine(int id);
        //#endregion

        //#region MediaType
        //[OperationContract]
        //IEnumerable<MediaType> GetMediaTypeAll(string nombre);

        //[OperationContract]
        //int InsertMediaType(MediaType entity);

        //[OperationContract]
        //bool UpdateMediaType(MediaType entity);

        //[OperationContract]
        //bool DeleteMediaType(MediaType entity);

        //[OperationContract]
        //MediaType GetByIdMediaType(int id);
        //#endregion

        //#region Playlist
        //[OperationContract]
        //IEnumerable<Playlist> GetPlaylistAll(string nombre);

        //[OperationContract]
        //int InsertPlaylist(Playlist entity);

        //[OperationContract]
        //bool UpdatePlaylist(Playlist entity);

        //[OperationContract]
        //bool DeletePlaylist(Playlist entity);

        //[OperationContract]
        //Playlist GetByIdPlaylist(int id);
        //#endregion

        //#region Track
        //[OperationContract]
        //IEnumerable<Track> GetTrackAll(string nombre);

        //[OperationContract]
        //int InsertTrack(Track entity);

        //[OperationContract]
        //bool UpdateTrack(Track entity);

        //[OperationContract]
        //bool DeleteTrack(Track entity);

        //[OperationContract]
        //Track GetByIdTrack(int id);
        //#endregion


    }
}
