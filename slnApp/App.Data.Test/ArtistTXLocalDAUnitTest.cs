using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using App.Entities;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistTXLocalDAUnitTest
    {

        [TestMethod]
        public void TestMethod1()
        {

            var da = new ArtistTXLocalDA();
            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void TestGetAll()
        {

            var da = new ArtistTXLocalDA();
            var listado = da.GetAll("Aerosmith");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestGet()
        {

            var da = new ArtistTXLocalDA();
            var entity = da.Get(8);

            Assert.IsTrue(entity.ArtistId > 0);

        }

        [TestMethod]
        public void TestGetAllSP()
        {

            var da = new ArtistTXLocalDA();
            var listado = da.GetAllSP("Aero");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestInsertArtista()
        {


            var da = new ArtistTXLocalDA();
            var artist = new Artista();
            artist.Name = "AeroxDxDxD";

            var id = da.InsertArtist(artist);

            Assert.IsTrue(id > 0, "El nombre del artista ya Existe");



        }

        [TestMethod]
        public void TestUpdateArtista()
        {
            var da = new ArtistTXLocalDA();
            var artist = new Artista
            {
                ArtistId = 286,
                Name = "Aero-Commit"
            };

            var registrosAfectados = da.UpdateArtist(artist);
            Assert.IsTrue(registrosAfectados > 0, "El nombre del artista ya EXISTE");

        }

        [TestMethod]
        public void TestDeleteArtista()
        {
            var da = new ArtistTXLocalDA();

            var regBusqEliminar = da.DeleteArtist(286);


            Assert.IsTrue(regBusqEliminar > 0, "No se encontró el ID");

        }


        
    }
}
