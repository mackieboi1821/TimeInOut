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

namespace TimeInOut.ViewModels
{
    public class BaseViewModel : Screen
    {

        protected IWindowManager _windowManager;

        public string _globalVariable;
        
        public SqlConnection _conn;
        public SqlCommand sc;
        public SqlDataReader dt;

        private string _passkey;
        private string _employeeId;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }




        public void OnPasswordChanged(PasswordBox source)
        {
            _passkey = source.Password;
        }
        public string EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }
        public string Passkey
        {
            get { return _passkey; }
            set { _passkey = value; }
        }

        public BaseViewModel()
        {
            _windowManager = new WindowManager();
            _conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TimeinoutDB;Integrated Security=True");

        }
        public void ShowInfo()
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }
                String query = "SELECT * FROM tb_employees WHERE employee_id='" + EmployeeId + "'";
                sc = new SqlCommand(query, _conn);
                dt = sc.ExecuteReader();
                while (dt.Read())
                {
                    _name = dt.GetValue(2).ToString();
                }
                sc.Dispose();
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void Cancel()
        {
        
            TryClose();
         
        }

        //public void inputOperation()
        //{
        //    if(Operation == "timein")
        //    {

        //    }
        //}
        //public void SqlInDate()
        //{
        //  DateTime time = DateTime.Now;
        //  string format = "yyyy-MM-dd";
        //  SqlCommand cmd = new SqlCommand ("INSERT INTO tb_records  ([TimeInHour]) VALUES ('"+ time.ToString(format) + "') WHERE employee_id = '"+EmployeeId+"'",_conn);
        //  cmd.ExecuteNonQuery();
        //}

    }
}
