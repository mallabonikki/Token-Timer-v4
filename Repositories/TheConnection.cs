using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace TokenTimerV4
{
    internal class TheConnection
    {
        private OleDbConnection connection;
        private OleDbCommand command;
        //public bool passworddubplicate;

        public TheConnection()
        {
            string strPcName = System.Environment.MachineName;
            string strPath = @"\\PC-99\e$\TokenData\" + strPcName + @"\TokenTimer.accdb";
            if (!File.Exists(strPath)) {myToolClass.ErrorLogToText(" Database FILE does not exist or have not enough permission! ","Database file error");}
            string strConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + strPath;

            connection = new OleDbConnection(strConString);
        }

        public TheConnection(string strConString)
        {
            connection = new OleDbConnection(strConString);
        }
        public void InsertTime(Time t)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "InsertTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Time", t.fTime);
                command.Parameters.AddWithValue("Token", t.fToken);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" InsertTime(Time t) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public int SelectpDateTotalToken(Time t)
        {
            int i = 0;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SelectpDateTotalToken";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Date", t.fInDate.ToShortDateString());
                connection.Open();
                i = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (System.InvalidCastException)
            {
                return 0;
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" SelectpDateTotalToken(Time t) ", exp.ToString());
            }
            finally
            {  
                connection.Close();
            }
            return i;
        }

        public int SelectLastRowTime() 
        {
            int i = 0;
            try
            {
                connection.Close();
                command = connection.CreateCommand();
                command.CommandText = "SelectLastRowTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                i = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception exp)
            {
                i = -1;                
                myToolClass.ErrorLogToText(" SelectLastRowTime() ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
            return i;
        }

        public void UpdateLastRowTimeOutDate(Time t)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "UpdateLastRowTimeOutDate";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Time", t.fTime);
                command.Parameters.AddWithValue("OutDate", t.fOutDate.ToString());
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" UpdateLastRowTimeOutDate(Time t) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertSaveTime(SaveTime t)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "InsertSaveTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Time", t.StTime );
                command.Parameters.AddWithValue("Password", t.StPassword);
                connection.Open();
                command.ExecuteNonQuery();
            }
            //catch (OleDbException)
            //{
            //    System.Windows.Forms.MessageBox.Show("Password Already Exist... Please Choose Another...","Check Password Duplicate");
            //    passworddubplicate = true;
            //}
            catch(Exception exp)
            {
                myToolClass.ErrorLogToText(" InsertSaveTime(SaveTime t) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public  int SelectpPasswordSaveTime(SaveTime st)
        {
            int i = 0;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SelectpPasswordSaveTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Password", st.StPassword);
                connection.Open();
                //OleDbDataReader datareader = command.ExecuteReader();
                //while (datareader.Read())
                //{
                //    st.StSaveDate = Convert.ToDateTime(datareader[2]);
                //}
                //datareader.Close();

                i = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" SelectpPasswordSaveTime(SaveTime st) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
            return i;
        }

        public int SelectpPasswordSaveTimeID(SaveTime st)
        {
            int i = 0;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SelectpPasswordSaveTimeID";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Password", st.StPassword);
                connection.Open();
                i = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" SelectpPasswordSaveTimeID(SaveTime st) ", exp.ToString());
                //System.Windows.Forms.MessageBox.Show("SelectpPasswordSaveTimeID : " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }
            return i;
        }

        public void UpdatepPasswordSaveTime(SaveTime st)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "UpadatepPasswordSaveTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Time", st.StTime);
                command.Parameters.AddWithValue("UseDate", st.StUseDate.ToString());
                command.Parameters.AddWithValue("Password",st.StPassword);
                command.Parameters.AddWithValue("UsePassword", st.StUsePassword);
                command.Parameters.AddWithValue("Passwordw", st.StPasswordw);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" UpdatepPasswordSaveTime(SaveTime st) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteSaveTime(SaveTime t)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "DeleteSaveTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" DeleteSaveTime(SaveTime t) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteTime(Time t)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "DeleteTime";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                myToolClass.ErrorLogToText(" DeleteTime(Time t) ", exp.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
