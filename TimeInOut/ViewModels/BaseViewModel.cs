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

        private ToRecordTimeIn _torecordtimein;
        private TimeInPost _timeinpost;
        private AuthenticatedTimeOut _authenticatedTimeOut;

        DateTime now = DateTime.Now;      

        #region Constructor
        public BaseViewModel()
        {
            _windowManager = new WindowManager();
            
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
        public void Cancel()
        {       
            TryClose();

        }    

       
    }
}
