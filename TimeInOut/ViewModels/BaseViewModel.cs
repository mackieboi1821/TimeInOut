using Caliburn.Micro;
using System;
using System.Data.SqlClient;
using System.Windows.Controls;
using TimeInOut.Utilities;

namespace TimeInOut.ViewModels
{
    public class BaseViewModel : Screen
    {

        protected IWindowManager _windowManager;

        public string _globalVariable;
        
        public SqlDataReader dt;

        private TimeInPost _timeinpost;
        private AuthenticatedTimeOut _authenticatedTimeOut;

        #region Operation
        private string _operation;

        public string Operation
        {
            get { return _operation; }
            set { _operation = value; NotifyOfPropertyChange(() => Operation); }
        }
        #endregion

        #region CurrentTime
        private string _currentDate;

        public string CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; NotifyOfPropertyChange(() => CurrentDate); }
        }
        #endregion

        #region Greeting
        private string _greeting;

        public string Greetings
        {
            get { return _greeting; }
            set { _greeting = value; NotifyOfPropertyChange(() => Greetings); }
        }
        #endregion

        #region Constructor
        public BaseViewModel()
        {
            _windowManager = new WindowManager();
   
        }
        #endregion



        #region EmployeeName
        private string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set
            {
                _EmployeeName = value;
                NotifyOfPropertyChange(() => EmployeeName);
            }
        }
        #endregion

        public int UserAuthenticate(string sql, string user, string pass)
        {

             _timeinpost = new TimeInPost(sql);
            return _timeinpost.AuthenticateUser(user, pass);
          
        }

        public int PostInUser(string sql, string employeeid)
        {

            _timeinpost = new TimeInPost(sql);
            return _timeinpost.TimeInRecord(employeeid);

        }

        public int PostOutUser(string sql, string employeeid)
        {

            _timeinpost = new TimeInPost(sql);
            return _timeinpost.TimeOutRecord(employeeid);

        }

        public int TimeOutUser(string sql, string user, string pass)
        {   

            _authenticatedTimeOut = new AuthenticatedTimeOut(sql);
            return _authenticatedTimeOut.TimeOutUser(user, pass);

        }

        public int GettingName(string sql, string employeeid)
        {

            _timeinpost = new TimeInPost(sql);
            return _timeinpost.GetName(employeeid);

        }

        public void Cancel()
        {       
            TryClose();

        }

    }
}
