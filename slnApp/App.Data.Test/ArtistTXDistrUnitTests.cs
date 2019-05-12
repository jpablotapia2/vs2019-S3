using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using App.Entities;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistTXDistrUnitTests
    {
        
        [TestMethod]
        public void TestMethod1()
        {

            var da = new ArtistTXDistribuidaDA();
            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void TestGetAll()
        {

            var da = new ArtistTXDistribuidaDA();
            var listado = da.GetAll("Aerosmith");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestGet()
        {

            var da = new ArtistTXDistribuidaDA();
            var entity = da.Get(8);

            Assert.IsTrue(entity.ArtistId > 0);

        }

        [TestMethod]
        public void TestGetAllSP()
        {

            var da = new ArtistTXDistribuidaDA();
            var listado = da.GetAllSP("Aero");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestInsertArtista()
        {


            var da = new ArtistTXDistribuidaDA();
            var artist = new Artista();
            artist.Name = "AeroxDxDxDxD";

            var id = da.InsertArtist(artist);

            Assert.IsTrue(id > 0, "El nombre del artista ya Existe");



        }

        [TestMethod]
        public void TestUpdateArtista()
        {
            var da = new ArtistTXDistribuidaDA();
            var artist = new Artista
            {
                ArtistId = 289,
                Name = "Aero-Upd"
            };

            var registrosAfectados = da.UpdateArtist(artist);
            Assert.IsTrue(registrosAfectados, "El nombre del artista ya EXISTE");

        }

        [TestMethod]
        public void TestDeleteArtista()
        {
            var da = new ArtistTXDistribuidaDA();

            var regBusqEliminar = da.DeleteArtist(289);


            Assert.IsTrue(regBusqEliminar, "No se encontró el ID");

        }


        
    }
}
