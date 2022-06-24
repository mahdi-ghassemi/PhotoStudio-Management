using System.Data;
using System.Data.SQLite;


namespace PhotoStudio
{
    public static class SQLiteAceess
    {       
        public static DataTable ExecuteQuery()
        {
            DataTable dtLite = new DataTable();
            try {
                string Query = "SELECT * FROM Setting WHERE Id = 1";
                SQLiteConnection conn = new SQLiteConnection("Data Source = " + Program.StartupPath + @"\RHS.DLL;Version = 3;Password = " + PAPC.Info.DbEncryptPassword + ";");
                conn.Open();              
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dtLite);
                conn.Close();
                return dtLite;
            }
            catch (SQLiteException e)
            {
                string m = e.Message;
                return dtLite;
            }
        }

        public static string ExecuteQuery(string ColumnName)
        {
            try
            {
                string result = "";
                string Query = "SELECT * FROM Setting WHERE Id = 1";
                DataTable dtLite = new DataTable();
                SQLiteConnection conn = new SQLiteConnection("Data Source = " + Program.StartupPath + @"\RHS.DLL;Version = 3;Password = " + PAPC.Info.DbEncryptPassword + ";");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dtLite);
                conn.Close();
                if (dtLite.Rows.Count > 0)
                    result = dtLite.Rows[0][ColumnName].ToString();
                return result;
            }
            catch (SQLiteException)
            {
                return "";
            }
        }

        public static int Execute(string Query)
        {
            try {
                SQLiteConnection conn = new SQLiteConnection("Data Source = " + Program.StartupPath + @"\RHS.DLL;Version = 3;Password = " + PAPC.Info.DbEncryptPassword + ";");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Query;
                return cmd.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
                return -1;
            }         
        }

        

    }
}
