using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;

namespace App.Data.DataAccess
{
    public class CustomerDA
    {
        public List<Customer> GetAll(string nombre)
        {
            var result = new List<Customer>();

            using (var db = new DBModel())
            {
                result = db.Customer
                    .Where(item => String.Concat(item.FirstName, " ", item.LastName).Contains(nombre))
                    .OrderByDescending(item => item.LastName).ThenBy(item=>item.FirstName)
                    .ToList();
            }

            return result;
        }

        public Customer Get(int id)
        {
            var result = new Customer();

            using (var db = new DBModel())
            {
                result = db.Customer.Find(id);
            }
            return result;
        }

        public int Insertar(Customer entidad)
        {
            var result = 0;
            using (var db = new DBModel())
            {
                //Agrega la entidad al contexto del EF
                db.Customer.Add(entidad);

                //Se confirma la transacción
                db.SaveChanges();

                result = entidad.CustomerId;
            }

            return result;
        }

        public bool Update(Customer entidad)
        {
            var result = false;
            using (var db = new DBModel())
            {
                //Atachamos la entidad al conexto
                db.Customer.Attach(entidad);

                //cambiar el estado de la entidad
                db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
                //se confirma la transacción
                db.SaveChanges();

                result = true;

            }

            return result;
        }

        public bool Delete(int id)
        {
            var result = false;
            using (var db = new DBModel())
            {
                var entity = new Customer();
                entity.CustomerId = id;

                db.Customer.Attach(entity);
                db.Customer.Remove(entity);

                db.SaveChanges();
                result = true;
            }

            return result;
        }

    }
}
