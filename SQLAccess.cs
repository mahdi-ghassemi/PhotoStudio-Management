using System;
using System.Data;
using System.Data.SqlClient;






namespace PhotoStudio
{
    /// <summary>
    /// This class provide a comminucation channel between AC and SQL Server
    /// </summary>
    public class SQLAccess
    {
        #region Fields:

        /// <summary>
        /// Stored Procedure Name
        /// </summary>
        private string _storedProcedureName;
        private string mes = "در بانک اطلاعاتی خطایی پیش آمده.لطفا با پشتیبانی تماس بگیرید";
        private string caption = "خطا";
        //private SqlConnection _sqlConnection;
        //private SqlCommand _sqlCommand;

        #region Enum:

        public enum StoredProcedure
        {
            prcCheckLogin, prcCheckLogin2          
        };
        #endregion

        #endregion

        #region Constructor:

        public SQLAccess()
        {
           // _sqlConnection = new SqlConnection();
           // USBLock usblck = new USBLock();
           // _sqlConnection.ConnectionString = Program.SqlConnectionString;
        }

        #endregion

        #region Properties:

        /// <summary>
        /// Stored Procedure Name
        /// </summary>
        public string StoredProcedureName
        {
            get
            {
                return _storedProcedureName;
            }
            set
            {
                _storedProcedureName = value;
            }
        }

        #endregion

        #region Private Methods:
        #endregion

        #region Public Methods:

        public bool Backup(string FileName)
        {          
            try
            {
                string command = @"BACKUP DATABASE ITC TO DISK='"+ FileName+"'";
                SqlCommand oCommand = null;
                SqlConnection oConnection = null;
                oConnection = new SqlConnection(Program.SqlConnectionString);
                if (oConnection.State != ConnectionState.Open)
                    oConnection.Open();
                oCommand = new SqlCommand(command, oConnection);
                oCommand.ExecuteNonQuery();
                return  true;              
            }
            catch (Exception)
            {
                return false;               
            }         
        }


        /// <summary>
        /// This method execute a stored procedure and return a int type value
        /// </summary>
        /// <param name="SpParams">Parametrs to send in store procedure</param>
        /// <returns>Int type return value</returns>
        public int IntExcuteSP(string[,] SpParams)
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc2 = new SqlConnection();
                _sqlc2.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand2 = new SqlCommand(_storedProcedureName, _sqlc2);
                _sqlCommand2.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand2.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand2.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                _sqlCommand2.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCommand2.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc2.Open();
                _sqlCommand2.ExecuteReader();
                _sqlc2.Close();
                _sqlc2.Dispose();

                _result = Convert.ToInt32(_sqlCommand2.Parameters["@Result"].Value.ToString());

                return _result;
            }
            catch (Exception e)
            {
                string mess = e.Message;                             
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return 0;
            }
        }

        public int IntExcuteSP(string[,] SpParams, byte[] ImageData)
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc = new SqlConnection();
                _sqlc.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCom = new SqlCommand(_storedProcedureName, _sqlc);
                _sqlCom.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCom.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCom.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                if (ImageData != null)
                {
                    _sqlCom.Parameters.AddWithValue("@Image", (object)ImageData);
                    _sqlCom.Parameters["@Image"].Direction = ParameterDirection.Input;
                }

                _sqlCom.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCom.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc.Open();
                _sqlCom.ExecuteReader();
                _sqlc.Close();
                _sqlc.Dispose();

                _result = Convert.ToInt32(_sqlCom.Parameters["@Result"].Value.ToString());

                return _result;
            }
            catch (Exception)
            {       
                
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return 0;
            }
        }

        public void InsertPersonnelInfo(string[,] SpParams,byte[] ImageData)
        {
            try
            {
                SqlConnection _sqlc3 = new SqlConnection();
                _sqlc3.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand3 = new SqlCommand(_storedProcedureName, _sqlc3);
                _sqlCommand3.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand3.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand3.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                _sqlCommand3.Parameters.AddWithValue("@UserImage", (object)ImageData);
                _sqlCommand3.Parameters["@UserImage"].Direction = ParameterDirection.Input;



                _sqlc3.Open();
                _sqlCommand3.ExecuteNonQuery();
                _sqlc3.Close();
                _sqlc3.Dispose();
               
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, caption);
                fm.ShowDialog();
                Environment.Exit(0);
                
            }
        }

        public void DeletePersonnelInfo(string AgentID)
        {
            try
            {
                SqlConnection _sqlc4 = new SqlConnection();
                _sqlc4.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand4 = new SqlCommand(_storedProcedureName, _sqlc4);
                _sqlCommand4.CommandType = CommandType.StoredProcedure;

                _sqlCommand4.Parameters.AddWithValue("@AgentID", AgentID);
                _sqlCommand4.Parameters["@AgentID"].Direction = ParameterDirection.Input;

                _sqlc4.Open();
                _sqlCommand4.ExecuteNonQuery();
                _sqlc4.Close();
                _sqlc4.Dispose();

            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, caption);
                fm.ShowDialog();
                Environment.Exit(0);

            }
        }

        public int UpdatePersonnelInfo(string[,] SpParams, byte[] ImageData)
        {
            try
            {
                SqlConnection _sqlc5 = new SqlConnection();
                _sqlc5.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand5 = new SqlCommand(_storedProcedureName, _sqlc5);
                _sqlCommand5.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand5.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand5.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                if (ImageData != null)
                {
                    _sqlCommand5.Parameters.AddWithValue("@KarbarImage", (object)ImageData);
                    _sqlCommand5.Parameters["@KarbarImage"].Direction = ParameterDirection.Input;
                }
                _sqlCommand5.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCommand5.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc5.Open();
                _sqlCommand5.ExecuteNonQuery();
                _sqlc5.Close();
                _sqlc5.Dispose();

               return  Convert.ToInt32(_sqlCommand5.Parameters["@Result"].Value.ToString());                

            }
            catch (Exception e)
            {
                string m = e.Message;
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                return 0;

            }
        }


        /// <summary>
        ///This method execute a stored procedure and return a int type value 
        /// </summary>
        /// <returns>Int type return value</returns>
        public int IntExcuteSP()
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc6 = new SqlConnection();
                _sqlc6.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand6 = new SqlCommand(_storedProcedureName, _sqlc6);
                _sqlCommand6.CommandType = CommandType.StoredProcedure;

                _sqlCommand6.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCommand6.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc6.Open();
                _sqlCommand6.ExecuteReader();
                _sqlc6.Close();
                _sqlc6.Dispose();
                

                _result = Convert.ToInt32(_sqlCommand6.Parameters["@Result"].Value.ToString());

                return _result;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return 0;
            }

        }

        public int CheckLogin(string Username, string Password)
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc7 = new SqlConnection();
                _sqlc7.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand7 = new SqlCommand(_storedProcedureName, _sqlc7);
                _sqlCommand7.CommandType = CommandType.StoredProcedure;

                _sqlCommand7.Parameters.Add("@Result", SqlDbType.Int); //this is userid
                _sqlCommand7.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlCommand7.Parameters.Add("@KarbarName", SqlDbType.NVarChar, 50);
                _sqlCommand7.Parameters["@KarbarName"].Direction = ParameterDirection.Output;               

                _sqlCommand7.Parameters.AddWithValue("@Username", Username.Trim());
                _sqlCommand7.Parameters["@Username"].Direction = ParameterDirection.Input;

                _sqlCommand7.Parameters.AddWithValue("@Password", Password.Trim());
                _sqlCommand7.Parameters["@Password"].Direction = ParameterDirection.Input;

                _sqlc7.Open();
                _sqlCommand7.ExecuteReader();
                _sqlc7.Close();
                _sqlc7.Dispose();

                _result = Convert.ToInt32(_sqlCommand7.Parameters["@Result"].Value.ToString());

                if (_result != 0)
                {
                    Program.UserId = _result;
                    Program.UserFullName = _sqlCommand7.Parameters["@KarbarName"].Value.ToString();
                    User.UserLastName = Program.UserFullName;                   
                }

                return _result;
            }
            catch (Exception e)
            {
                string m = e.Message;                              
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return 0;
            }

        }

        public DataTable ExcecuteQueryToDataTable()
        {           
            try
            {
                SqlConnection _sqlc8 = new SqlConnection();
                _sqlc8.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand8 = new SqlCommand(_storedProcedureName, _sqlc8);
                _sqlCommand8.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(_sqlCommand8);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                sda.Dispose();
                _sqlCommand8.Dispose();
                _sqlc8.Close();
                _sqlc8.Dispose();
                return dt;
            }
           catch (Exception e)
           {
             
               frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
               fm.ShowDialog();
               Environment.Exit(0);
               return null;
           }
        }

        public DataTable ExcecuteSelectQueryToDataTable(string Query)
        {
            try
            {
                SqlConnection _msqlc = new SqlConnection();
                _msqlc.ConnectionString = Program.SqlConnectionString;
                SqlCommand _msqlCommand = new SqlCommand(Query,_msqlc);
              
                SqlDataAdapter msda = new SqlDataAdapter(_msqlCommand);
                DataSet mds = new DataSet();
                msda.Fill(mds, "mTable");
                DataTable mdt = mds.Tables["mTable"];
                msda.Dispose();
                _msqlCommand.Dispose();
                _msqlc.Close();
                _msqlc.Dispose();
                return mdt;
            }
            catch (Exception e)
            {
                string m = e.Message;
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }

        public DataTable GetNoneShowEventList(string StorePName)
        {
            try
            {
                SqlConnection sqlConnection4 = new SqlConnection();
                SqlCommand sqlCommand4 = new SqlCommand(StorePName, sqlConnection4);
                sqlConnection4.ConnectionString = Program.SqlConnectionString;
                sqlCommand4.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sdab4 = new SqlDataAdapter(sqlCommand4);
                DataSet das4 = new DataSet();
                sdab4.Fill(das4, "EventTable4");
                DataTable dat4 = das4.Tables["EventTable4"];
                sdab4.Dispose();
                sqlCommand4.Dispose();
                sqlConnection4.Close();
                sqlConnection4.Dispose();
                return dat4;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }

        public DataTable GetAgentNoneShowEventList(string[,] SpParams)
        {
            try
            {
                SqlConnection sqlConnection2 = new SqlConnection();
                SqlCommand sqlCommand2 = new SqlCommand(_storedProcedureName, sqlConnection2);
                sqlConnection2.ConnectionString = Program.SqlConnectionString;

                sqlCommand2 = new SqlCommand(_storedProcedureName, sqlConnection2);
                sqlCommand2.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    sqlCommand2.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    sqlCommand2.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                SqlDataAdapter sda2 = new SqlDataAdapter(sqlCommand2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2, "Table2");
                DataTable dt2 = ds2.Tables["Table2"];
                sda2.Dispose();
                sqlCommand2.Dispose();
                sqlConnection2.Close();
                sqlConnection2.Dispose();
                return dt2;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }

        public DataTable GetAgentNoneShowEventList(string AgentID)
        {
            try
            {
                SqlConnection sqlConnection3 = new SqlConnection();
                SqlCommand sqlCommand3 = new SqlCommand(_storedProcedureName, sqlConnection3);
                sqlConnection3.ConnectionString = Program.SqlConnectionString;

                sqlCommand3.CommandType = CommandType.StoredProcedure;
                sqlCommand3.Parameters.AddWithValue("@AgentID", AgentID.Trim());
                sqlCommand3.Parameters["@AgentID"].Direction = ParameterDirection.Input;

                SqlDataAdapter sda3 = new SqlDataAdapter(sqlCommand3);
                DataSet ds3 = new DataSet();
                sda3.Fill(ds3, "Table3");
                DataTable dt3 = ds3.Tables["Table3"];
                sda3.Dispose();
                sqlCommand3.Dispose();
                sqlConnection3.Close();
                sqlConnection3.Dispose();
                return dt3;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }



        public DataTable ExcecuteQueryToDataTable(string AgentID)
        {
            try
            {
                SqlConnection _sqlc9 = new SqlConnection();
                _sqlc9.ConnectionString = Program.SqlConnectionString;
                SqlCommand _sqlCommand9 = new SqlCommand(_storedProcedureName, _sqlc9);
                _sqlCommand9.CommandType = CommandType.StoredProcedure;
                _sqlCommand9.Parameters.AddWithValue("@AgentID", AgentID.Trim());
                _sqlCommand9.Parameters["@AgentID"].Direction = ParameterDirection.Input;

                SqlDataAdapter sda = new SqlDataAdapter(_sqlCommand9);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                sda.Dispose();
                _sqlCommand9.Dispose();
                _sqlc9.Close();
                _sqlc9.Dispose();
                return dt;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }

        public DataTable ExcecuteQueryToDataTable(string[,] SpParams)
        {
            try
            {
                SqlConnection _sqlConnectionN = new SqlConnection();
                _sqlConnectionN.ConnectionString = Program.SqlConnectionString;
                 SqlCommand _sqlCommandN;
                _sqlCommandN = new SqlCommand(_storedProcedureName, _sqlConnectionN);
                _sqlCommandN.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommandN.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommandN.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                SqlDataAdapter sda = new SqlDataAdapter(_sqlCommandN);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                sda.Dispose();
                _sqlCommandN.Dispose();
                _sqlConnectionN.Close();
                _sqlConnectionN.Dispose();
                return dt;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }

        public DataTable GetAlertId(string[,] SpParams)
        {
            try
            {
                SqlConnection _sqlc10 = new SqlConnection();
                _sqlc10.ConnectionString = Program.SqlConnectionString;
               
               
                SqlCommand _sqlCommand10 = new SqlCommand(_storedProcedureName, _sqlc10);
                _sqlCommand10.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {
                    _sqlCommand10.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand10.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;
                }

                SqlDataAdapter sdaid = new SqlDataAdapter(_sqlCommand10);
                DataSet dsid = new DataSet();
             
                sdaid.Fill(dsid, "TableAlert");
                DataTable dt = dsid.Tables["TableAlert"];
                sdaid.Dispose();
                _sqlCommand10.Dispose();
                _sqlc10.Close();
                _sqlc10.Dispose();
                return dt;
            }
            catch (Exception)
            {
               
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,caption);
                fm.ShowDialog();
                Environment.Exit(0);
                return null;
            }
        }


        #endregion
    }
}

    


