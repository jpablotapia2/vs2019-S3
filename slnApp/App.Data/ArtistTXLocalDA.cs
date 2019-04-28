using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using App.Entities;

namespace App.Data
{
    public class ArtistTXLocalDA : BaseConnection
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

        /// <summary>
        /// Permite obtener la lista de artistas
        /// </summary>
        /// <returns></returns>
        public List<Artista> GetAll(string filterByName="")
        {
            var result = new List<Artista>();
            var sql = "select * from Artist where Name LIKE @paramFilterByName";

            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);

                cmd.Connection = cn;
                cn.Open();

                filterByName = $"%{filterByName}%";

                cmd.Parameters.Add(new SqlParameter("@paramFilterByName", filterByName));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var artist = new Artista();
                    indice=reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    result.Add(artist);
                }
            }
            return result;
        }


        public Artista Get(int id)
        {
            var result = new Artista();
            var sql = "select * from Artist where ArtistId=@ArtistId";
            using (IDbConnection cn= new SqlConnection(base.GetConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open();

                //Configurando los parametros
                cmd.Parameters.Add(new SqlParameter("@ArtistId", id));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {

                    indice = reader.GetOrdinal("ArtistId");
                    result.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    result.Name = reader.GetString(indice);

                    
                }
            }

            return result;
        }


        public List<Artista> GetAllSP(string filterByName = "")
        {
            var result = new List<Artista>();
            var sql = "usp_GetAll";

            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                IDbCommand cmd = new SqlCommand(sql);
                //Indicar que es un SP

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Connection = cn;
                cn.Open();

                filterByName = $"%{filterByName}%";

                cmd.Parameters.Add(new SqlParameter("@filterByName", filterByName));

                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var artist = new Artista();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    result.Add(artist);
                }
            }
            return result;
        }


        public int InsertArtist(Artista entity)
        {
            var result = 0;
            
            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                cn.Open();

                //Iniciando el bloque de transacción Local
                var transaccion = cn.BeginTransaction();

                try
                {
                    IDbCommand cmd = new SqlCommand("usp_InsertArtist");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", entity.Name));

                    //Asociando la transacción local al objeto command
                    cmd.Transaction = transaccion;

                    result = Convert.ToInt32(cmd.ExecuteScalar());

                    //Generando una excepción
                    //throw new Exception("Error");

                    //Confirmando la transacción
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    //Cancelando la transacción con el método Roll
                    transaccion.Rollback();
                    
                }
            }

            return result;
        }

        public int UpdateArtist(Artista entity)
        {
            var result = 0;


            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                cn.Open();

                var transaction = cn.BeginTransaction();

                try
                {
                    IDbCommand cmd = new SqlCommand("usp_UpdateArtist");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", entity.Name));
                    cmd.Parameters.Add(new SqlParameter("@ArtistId", entity.ArtistId));

                    cmd.Transaction = transaction;

                    result = cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                }

            }

            return result;
        }

        public int DeleteArtist(int id)
        {
            var result = 0;

            using (IDbConnection cn= new SqlConnection(base.GetConnectionString))
            {
                cn.Open();
                var transaction = cn.BeginTransaction();

                try
                {
                    IDbCommand cmd = new SqlCommand("usp_DeleteArtist");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ArtistId", id));

                    cmd.Transaction = transaction;

                    result = cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                }

                
            }
            return result;
        }
    }
}
