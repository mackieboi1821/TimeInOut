using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TimeInOut.Views;

namespace TimeInOut.ViewModels
{
    public class TimeInViewModel: BaseViewModel
    {
        public TimeInViewModel()
        {

        }
        

        public void TimeInEnter()
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
                if(count == 1)
                {
                  
                    MessageBox.Show("Time in successful!");

                    ShowInfo();
                
                    Cancel();
               
                }
                else
                {
                    MessageBox.Show("Invalid User");
            
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
