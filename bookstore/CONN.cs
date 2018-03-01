using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace bookstore
{
    class CONN
    {
        public static SqlConnection Myconn()
        {
            return new SqlConnection("Data Source = (local); Initial Catalog = BOOKSTORE; Integrated Security = True; User ID = sa; Password = 123456");
        }
    }
}
