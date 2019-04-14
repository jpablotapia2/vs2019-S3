using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseConnection
    {
        public string GetConnectionString
        {
            get {
                string cnx = @"Server=MI607-ST\SQL2016PIVOT;
                            Database=dbChinook;
                            User Id=chinook; 
                            Password=P@$$w0rd";
                return cnx;
            }
        }
    }
}
