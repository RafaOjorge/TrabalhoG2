using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AluguelQuadrasDAO
{
    public class Conexao
    {
        private static MySqlConnection conn = new MySqlConnection();
        private static MySqlCommand cmd = new MySqlCommand();
        private static MySqlDataReader dr;

        private static string strConn = "Server=localhost" +
                                        ";Port=3306" +
                                        ";Database=aluguelquadrasdb" +
                                        ";Uid=root" +
                                        ";Pwd=root";
        public static bool Connect()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.ConnectionString = strConn;
                conn.Open();
            }
            else
            {
                dr.Close();
            }
            return true;
        }

        public static bool Close()
        {
            conn.Close();
            return true;
        }

        public static bool CommandPersist(MySqlCommand pCmd)
        {
            Connect();
            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();

            return true;
        }

        public static MySqlDataReader Get(string pSql)
        {
            Connect();

            if (dr != null && !dr.IsClosed)
                dr.Close();

            cmd = new MySqlCommand(pSql, conn);

            dr = cmd.ExecuteReader();

            return dr;
        }



    }
}
