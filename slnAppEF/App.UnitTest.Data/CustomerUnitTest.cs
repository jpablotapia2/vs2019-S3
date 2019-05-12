using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data.DataAccess;
using App.Entities.Base;

namespace App.UnitTest.Data
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void GetAllCustomer()
        {
            var da = new CustomerDA();
            var lista = da.GetAll("Pedro Ruiz");
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void GetCustomer()
        {
            var da = new CustomerDA();
            var entity = da.Get(60);
            Assert.IsTrue(entity.CustomerId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new CustomerDA();
            var entity = new Customer
            {
                FirstName = "Oscar",
                LastName = "Taya",
                Company = "Reprodata",
                Address = "Av. Simon 123",
                City = "Lima",
                State = "Lima",
                Country = "Perú",
                PostalCode = "1245",
                Phone = "4563214",
                Fax = "46512321",
                Email = "jdks@gmail.com",
                SupportRepId = null
               
            };

            var id = da.Insertar(entity);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void Update()
        {
            var da = new CustomerDA();

            var entity = new Customer
            {
                CustomerId=62,
                FirstName = "Oscar2",
                LastName = "Taya2",
                Company = "Reprodata",
                Address = "Av. Simon 123",
                City = "Lima",
                State = "Lima",
                Country = "Perú",
                PostalCode = "1245",
                Phone = "4563214",
                Fax = "46512321",
                Email = "jdks@gmail.com",
                SupportRepId = null
            };

            var result = da.Update(entity);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var da = new CustomerDA();

            //Agregando un registro
            var entity = new Customer
            {
                FirstName = "Goku",
                LastName = "Saiyayin",
                Company = "Reprodata",
                Address = "Av. Simon 123",
                City = "Lima",
                State = "Lima",
                Country = "Perú",
                PostalCode = "1245",
                Phone = "4563214",
                Fax = "46512321",
                Email = "jdks@gmail.com",
                SupportRepId = null
            };

            //entity.Name = "Artist Test";
            var id = da.Insertar(entity);

            //Eliminando registro
            var result = da.Delete(id);
            Assert.IsTrue(result);
        }
    }
}
