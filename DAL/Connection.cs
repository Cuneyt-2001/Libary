using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public static class Connection
        {
            public static SqlConnection connection = new SqlConnection(@"Server = mssqlstud.fhict.local; Database = dbi485604_libary; User Id = 	dbi485604_libary;  MultipleActiveResultSets=True; Password = emir20015454.;");
        }
}
