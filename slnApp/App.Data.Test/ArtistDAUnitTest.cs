﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data;
using App.Entities;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistDAUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            var da = new ArtistDA();
            Assert.IsTrue(da.GetCount() > 0);

        }

        [TestMethod]
        public void TestGetAll()
        {

            var da = new ArtistDA();
            var listado = da.GetAll("Aerosmith");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestGet()
        {

            var da = new ArtistDA();
            var entity = da.Get(8);

            Assert.IsTrue(entity.ArtistId > 0);

        }

        [TestMethod]
        public void TestGetAllSP()
        {

            var da = new ArtistDA();
            var listado = da.GetAllSP("Aero");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void TestInsertArtista()
        {
            //var objInsertar = new Artista {
            //    Name = "Lily"
            //};

            //var da = new ArtistDA();
            //var nuevoId = da.InsertArtist(objInsertar);

            //var objBD = da.Get((int)(nuevoId));

            //Assert.AreEqual(objBD.Name, objInsertar.Name);

            var da = new ArtistDA();
            var artist = new Artista();
            artist.Name = "Aero3";

            var id = da.InsertArtist(artist);

            Assert.IsTrue(id > 0,"El nombre del artista ya Existe");
            


        }

        [TestMethod]
        public void TestUpdateArtista()
        {
            var da = new ArtistDA();
            var artist = new Artista
            {
                ArtistId=280,
                Name = "Aero-Copia2"
            };

            var registrosAfectados = da.UpdateArtist(artist);
            Assert.IsTrue(registrosAfectados>0, "El nombre del artista ya EXISTE");

        }

        [TestMethod]
        public void TestDeleteArtista()
        {
            var da = new ArtistDA();

            var regBusqEliminar = da.DeleteArtist(278);
            

            Assert.IsTrue(regBusqEliminar > 0, "No se encontró el ID");

        }


    }


}
