using System;
using System.Linq;
using App.Data.DataAccess;
using App.Data.Repository;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.RepositoryTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            int totalRows = 0;
            int totalAlbunRows = 0;
            

            using (var repository = new AppUnitOfWork())
            {
                totalRows = repository.ArtistRepositorys.GetAll().Count();
                totalAlbunRows = repository.AlbumRepositorys.GetAll().Count;

                Assert.IsTrue(totalRows>0);
            }

        }

        [TestMethod]
        public void InsertAtist()
        {
            var result = false;

            using (var uw = new AppUnitOfWork())
            {
                var newArtist = new Artist()
                {
                    Name = "Artist Nuevo"
                };
                uw.ArtistRepositorys.Add(newArtist);

                result = uw.Complete() > 0;
            }

            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    public void InsertAlbum()
    {
        var result = false;

        using (var uw = new AppUnitOfWork())
        {
            var newArtist = new Artist()
            {
                Name = "Artist Nuevo"
            };

            var newAlbum= new Album()
            {
                Title = "Album Nuevo",
                Artist= newArtist
            };

            uw.AlbumRepositorys.Add(newAlbum);

            result = uw.Complete() > 0;
        }

        Assert.IsTrue(result);
    }
}

