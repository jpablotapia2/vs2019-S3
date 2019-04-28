using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using App.Entities;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistTXLocalDapperDAUnitTest
    {

        [TestMethod]
        public void TestMethod1()
        {

            var da = new ArtistTXLocalDapperDA();
            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void TestGetAll()
        {

            var da = new ArtistTXLocalDapperDA();
            var listado = da.GetAll("%Aero%");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestGet()
        {

            var da = new ArtistTXLocalDapperDA();
            var entity = da.Get(8);

            Assert.IsTrue(entity.ArtistId > 0);

        }

        [TestMethod]
        public void TestGetAllSP()
        {

            var da = new ArtistTXLocalDapperDA();
            var listado = da.GetAllSP("%Aero%");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestInsertArtista()
        {


            var da = new ArtistTXLocalDapperDA();
            var artist = new Artista();
            artist.Name = "AeroDapper";

            var id = da.InsertArtist(artist);

            Assert.IsTrue(id > 0, "El nombre del artista ya Existe");



        }

        [TestMethod]
        public void TestUpdateArtista()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artista
            {
                ArtistId = 285,
                Name = "Aero-DapperUpdate"
            };

            var registrosAfectados = da.UpdateArtist(artist);
            Assert.IsTrue(registrosAfectados > 0, "El nombre del artista ya EXISTE");

        }

        [TestMethod]
        public void TestDeleteArtista()
        {
            var da = new ArtistTXLocalDapperDA();

            var regBusqEliminar = da.DeleteArtist(277);


            Assert.IsTrue(regBusqEliminar > 0, "No se encontró el ID");

        }


        
    }
}
