using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using App.Entities;
using System.Transactions;
using Dapper;

namespace App.Data
{
    public class ArtistTXDistribuidaDapperDA : BaseConnection
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


        public int InsertArtistTXDist(Artista entity)
        {
            var result = 0;

            using (var tx = new TransactionScope())
            {

                using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
                {
                    try
                    {
                        result = cn.ExecuteScalar<int>("usp_InsertArtist", new { Name = entity.Name },
                            commandType: CommandType.StoredProcedure);
                           
                        //Confirma la transacción
                        tx.Complete();
                    }
                    catch (Exception)
                    {
                        result = 0;
                    }

                }

            }
            return result;
        }


        public bool UpdateArtistTXDist(Artista entity)
        {
            var result = false;

            using (var trx= new TransactionScope())
            {
                using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
                {
                    try
                    {
                        result = cn.ExecuteScalar<int>("usp_UpdateArtist", new { Name = entity.Name },
                            commandType: CommandType.StoredProcedure)>0;

                        //Confirma la transacción
                        trx.Complete();
                    }
                    catch (Exception)
                    {
                        result = false;
                    }

                }

            }

            return result;
        }

        public bool DeleteArtistTXDist(int id)
        {
            var result = false;

            using (var trx = new TransactionScope())
            {
                using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
                {
                    try
                    {
                        result = cn.ExecuteScalar<int>("usp_DeleteArtist", new { ArtistId = id},
                            commandType: CommandType.StoredProcedure)>0;

                        //Confirma la transacción
                        trx.Complete();
                    }
                    catch (Exception)
                    {
                        result = false;
                    }

                }
            }         
            return result;
        }
    }
}
