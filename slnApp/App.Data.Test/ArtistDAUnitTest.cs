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
    }
}
