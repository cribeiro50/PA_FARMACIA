using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Farmacia
    {
        #region CAMADA_DADOS_GET_FARMACIAS
        public static DataTable GetList(string filter)
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.ConnectionString;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                string comando = $"SELECT * FROM [Farmacia] WHERE [NomeFarmacia] LIKE @Filter";

                cmd.CommandText = comando;
                SqlParameter param = new SqlParameter("Filter", SqlDbType.NVarChar, -1);
                param.Value = "%" + filter + "%";
                cmd.Parameters.Add(param);

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                con.Close();
            }
            catch (Exception e)
            {
            }
            return dataTable;
        }
        
        #endregion


    }
}
