using System;
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

    }


}
