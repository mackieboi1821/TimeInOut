using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeInOut.ViewModels;

namespace TimeInOut.Utilities
{
    public class ToRecordTimeIn: BaseViewModel
    {
        private SqlConnection _conn;
        private SqlCommand _sc;

        public ToRecordTimeIn(string _conn)
        {
            InitializeData(_conn);
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
        public int TimeInRecord(string EmployeeId)
        {
            string query = "INSERT INTO tb_records (employee_id, TimeDate, TimeInOut, TimeType) VALUES (@employee_id, GETDATE(),convert(varchar(8), getdate(), 108), 'IN')";

            SqlCommand sqlCmd = new SqlCommand(query, _conn);

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@employee_id", EmployeeId);
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            return count;

        }

        public int TimeOutRecord(string EmployeeId)
        {
            string query = "INSERT INTO tb_records (employee_id, TimeDate, TimeInOut, TimeType) VALUES (@employee_id, GETDATE(),convert(varchar(8), getdate(), 108), 'OUT')";

            SqlCommand sqlCmd = new SqlCommand(query, _conn);

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@employee_id", EmployeeId);
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            return count;

        }
    }
}
