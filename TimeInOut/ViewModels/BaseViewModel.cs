using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeInOut.ViewModels
{
    public class BaseViewModel : Screen
    {
        protected IWindowManager _windowManager;

        public string _globalVariable;

        public SqlConnection _cn;

        public BaseViewModel()
        {
            _windowManager = new WindowManager();
            _cn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TimeinoutDB;Integrated Security=True");

        }

        public void Cancel()
        {
            TryClose();
        }

    }
}
