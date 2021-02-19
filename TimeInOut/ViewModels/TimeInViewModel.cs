using System;
using System.Windows;

namespace TimeInOut.ViewModels
{
    public class TimeInViewModel: BaseViewModel
    {
        public TimeInViewModel()
        {

        }

        #region Username
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value;
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


        public void TimeInEnter()
        {
            try
            {
                if (TimeInUser(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TimeinoutDB;Integrated Security=True", _UserName, _Passkey) > 0)
                {
                    MessageBox.Show("Time in successful!");

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
