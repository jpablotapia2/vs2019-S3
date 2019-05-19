using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using App.Data.DataAccess;

namespace App.UnitTest.Data
{
    [TestClass]
    public class TrackUnitTest
    {
        [TestMethod]
        public void ConsultarTracksTest()
        {
            var da = new TrackDA();
            var listado = da.ConsultarTracks("%VOLTA%");
            Assert.IsTrue(listado.Count()>0);
        }

        //public void ConsultarTracksQTest()
        //{
        //    var da = new TrackDA();
        //    var listado= da.ConsultarTracksQ("%VOLTA%");
        //    Assert.IsTrue(listado.Count()>0)    
        //}
    }
}
