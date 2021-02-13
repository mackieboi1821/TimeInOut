using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimeInOut.ViewModels
{
    public class TimeOutViewModel : BaseViewModel
    {
        public TimeOutViewModel()
        {

        }
        public void TimeOutEnter()
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }

                String query = "SELECT COUNT(1) FROM tb_employees WHERE employee_id=@employee_id AND PassKey=@Passkey";
                SqlCommand sqlCmd = new SqlCommand(query, _conn);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employee_id", EmployeeId);
                sqlCmd.Parameters.AddWithValue("@passkey", Passkey);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Cancel();
                    MessageBox.Show("Time out successful!");
                    //ShowInfo();
                }
                else
                {
                    MessageBox.Show("Error");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
