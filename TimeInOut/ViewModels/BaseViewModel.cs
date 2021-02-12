using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TimeInOut.ViewModels
{
    public class BaseViewModel : Screen
    {
        protected IWindowManager _windowManager;

        public string _globalVariable;

        public SqlConnection _conn;


        private string _passkey;
        private string _employeeId;
  
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

        public void Cancel()
        {
            TryClose();
        }

       
    }
}
