using System;
using System.Windows;

namespace TimeInOut.ViewModels
{
    public class TimeOutViewModel : BaseViewModel
    {
        public TimeOutViewModel()
        {

        }
   

        #region Username
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }
        #endregion

        #region Passkey
        private string _Passkey;
        public string Passkey
        {
            get { return _Passkey; }
            set
            {
                _Passkey = value;
                NotifyOfPropertyChange(() => Passkey);
            }
        }
        #endregion

        public void TimeOutEnter()
        {
            try
            {
                if (TimeOutUser(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TimeinoutDB;Integrated Security=True", _UserName, _Passkey) > 0)
                {

                    MessageBox.Show("Time out successful!");                  
                    Cancel();
                }
                else
                    MessageBox.Show("Invalid User");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                    
            }
        }
    }
}
