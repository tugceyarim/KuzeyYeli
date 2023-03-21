using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUZEYYELİ.ORM
{
    internal class Tools
    {
        private static SqlConnection baglanti = new SqlConnection
       (ConfigurationManager.ConnectionStrings["KuzeyYeli"].ConnectionString);
        public static SqlConnection Baglanti
        {
            get { return baglanti; }
            set { baglanti = value; }
        }
        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                return komut.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Closed)
                    komut.Connection.Close() ;
            }
        }
        public static DataTable Listele(string procedureName)
        {
            SqlDataAdapter adaptor = new SqlDataAdapter
                (procedureName,Tools.Baglanti);
            adaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            return dt;
        }
    }
}
