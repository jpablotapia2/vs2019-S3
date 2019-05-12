using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data.DataAccess;
using App.Entities.Base;


namespace App.UnitTest.Data
{
    [TestClass]
    public class ArtistUnitTest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();
            var lista = da.GetAll("");
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void GetArtist()
        {
            var da = new ArtistDA();
            var entity = da.Get(1);
            Assert.IsTrue(entity.ArtistId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistDA();
            var entity = new Artist
            {
                Name="Manolo"
                
            };

            var id = da.Insertar(entity);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void Update()
        {
            var da = new ArtistDA();

            var entity = new Artist
            {
                ArtistId = 1,
                Name="Manolo2"

            };

            var result = da.Update(entity);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var da = new ArtistDA();

            //Agregando un registro
            var entity = new Artist();
            entity.Name = "Artist Test";
            var id = da.Insertar(entity);

            //Eliminando registro
            var result = da.Delete(id);
            Assert.IsTrue(result);
        }
    }
}
