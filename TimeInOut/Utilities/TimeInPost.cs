using System;
using System.Data;
using System.Data.SqlClient;
using TimeInOut.ViewModels;

namespace TimeInOut.Utilities
{
    public class TimeInPost : BaseViewModel
    {
        private SqlConnection _conn;
        private SqlCommand _sc;


        public TimeInPost(string _cnxn)
        {
            InitializeData(_cnxn);
        }


        public void InitializeData(string _cn)
        {
            _conn = new SqlConnection(@_cn);

            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }

        }
        public SqlConnection Connection
        {
            get { return _conn; }
            set
            {
                _conn = value;
            }
        }

        public SqlCommand Command
        {
            get { return _sc; }
            set
            {
                _sc = value;
            }
        }

        public int AuthenticateUser(string EmployeeId, string Passkey)
        {
            string query = "SELECT COUNT(1) FROM tb_employees WHERE employee_id=@employee_id AND PassKey=@Passkey";

            SqlCommand sqlCmd = new SqlCommand(query, _conn);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@employee_id", EmployeeId);
            sqlCmd.Parameters.AddWithValue("@passkey", Passkey);
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            return count;

        }
        public int TimeInRecord(string EmployeeId)
        {
            try
            {
                string query = "INSERT INTO tb_records (employee_id, TimeDate, TimeInOut, TimeType) VALUES (@employee_id, GETDATE(),convert(varchar(8), getdate(), 108), 'IN')";

                SqlCommand sqlCmd = new SqlCommand(query, _conn);

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employee_id", EmployeeId);
                sqlCmd.ExecuteScalar();

                return 1;
            }
            catch (SqlException _ex)
            {
                return 0;
            }

        }

        public int TimeOutRecord(string EmployeeId)
        {
            try
            {
                string query = "INSERT INTO tb_records (employee_id, TimeDate, TimeInOut, TimeType) VALUES (@employee_id, GETDATE(),convert(varchar(8), getdate(), 108), 'OUT')";

                SqlCommand sqlCmd = new SqlCommand(query, _conn);

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employee_id", EmployeeId);
                sqlCmd.ExecuteScalar();

                return 1;
            }
            catch (SqlException _ex)
            {
                return 0;
            }
        }
    }
}
