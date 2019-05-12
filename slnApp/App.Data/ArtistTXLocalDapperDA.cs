using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using App.Entities;
using Dapper;

namespace App.Data
{
    public class ArtistTXLocalDapperDA : BaseConnection
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
                result=cn.ExecuteScalar<int>(sql);
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
                //devuelve un conjunto de registros
                result=cn.Query<Artista>(sql, new {paramFilterByName=filterByName}).ToList();

            }
            return result;
        }


        public Artista Get(int id)
        {
            var result = new Artista();
            var sql = "select * from Artist where ArtistId=@ArtistId";
            using (IDbConnection cn= new SqlConnection(base.GetConnectionString))
            {
                //devuelve 1 registro 
                result = cn.QueryFirstOrDefault<Artista>(sql, new { ArtistId = id });
            }

            return result;
        }


        public List<Artista> GetAllSP(string filterByName = "")
        {
            var result = new List<Artista>();
            var sql = "usp_GetAll";

            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                result=cn.Query<Artista>(sql, new { filterByName = filterByName}, commandType:CommandType.StoredProcedure).ToList();
            }
            return result;
        }


        public int InsertArtist(Artista entity)
        {
            var result = 0;
            
            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                result = cn.ExecuteScalar<int>("usp_InsertArtist", new { Name = entity.Name }, commandType:CommandType.StoredProcedure);

            }

            return result;
        }

        public bool UpdateArtist(Artista entity)
        {
            var result = false;


            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                result = cn.Execute("usp_UpdateArtist", new { Name = entity.Name, ArtistId = entity.ArtistId }, commandType: CommandType.StoredProcedure)>0;

            }

            return result;
        }

        public bool DeleteArtist(int id)
        {
            var result = false;

            using (IDbConnection cn= new SqlConnection(base.GetConnectionString))
            {
                result = cn.Execute("usp_DeleteArtist", new { ArtistId = id }, commandType: CommandType.StoredProcedure)>0;

            }
            return result;
        }


        public int InsertTXArtist(Artista entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                //Abriendo la conexiòn antes de iniciar la TX
                cn.Open();

                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.ExecuteScalar<int>("usp_InsertArtist", 
                        new { Name = entity.Name }, commandType: CommandType.StoredProcedure,
                        transaction:tx);

                    //Confirmando la TX
                    tx.Commit();

                }
                catch (Exception ex)
                {
                    //Deshacer los cambios
                    result = 0;
                    tx.Rollback();
                }

              
            }

            return result;
        }

        public bool UpdateTXArtist(Artista entity)
        {
            var result = false;
            

            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                cn.Open();
                var tx=cn.BeginTransaction();

                try
                {
                    result = cn.Execute("usp_UpdateArtist",
                    new { Name = entity.Name, ArtistId = entity.ArtistId },
                    commandType: CommandType.StoredProcedure,
                    transaction: tx) > 0;

                    tx.Commit();
                }
                catch (Exception)
                {
                    result = false;
                    tx.Rollback();
                }
                
            }

            return result;
        }

        public bool DeleteTXArtist(int id)
        {
            var result = false;

            using (IDbConnection cn = new SqlConnection(base.GetConnectionString))
            {
                cn.Open();
                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.Execute("usp_DeleteArtist",
                    new { ArtistId = id }, commandType: CommandType.StoredProcedure,
                    transaction: tx) > 0;

                    tx.Commit();
                }
                catch (Exception)
                {
                    result = false;
                    tx.Rollback();

                }
                
            }
            return result;
        }
    }
}
