using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace App.Data
{
    public class ArtistDA:BaseConnection
    {
        /// <summary>
        /// Método que permite obtener la cantidad de registros que existen en artistas
        /// </summary>
        /// <returns>Retona un nùmero de registros</returns>
        public int GetCount()
        {
            var result = 0;
            var sql = "select count(1) from Artist";

            //1. Creando la instancia del objeto connection
            using (IDbConnection cn= new SqlConnection(base.GetConnectionString))
            {
                //2. Creando el objeto command
                IDbCommand cmd = new SqlCommand(sql);

                //Relacionar el command a la conexion
                cmd.Connection = cn;

                //Abriendo la conexion a la BDD
                cn.Open();

                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }
    }
}
