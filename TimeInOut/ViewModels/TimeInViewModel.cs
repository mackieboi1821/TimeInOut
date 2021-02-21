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

        #region TimeIn
        private string _TimeInHour;

        public string TimeInHour
        {
            get { return _TimeInHour; }
            set 
            {
                _TimeInHour = value;
                NotifyOfPropertyChange(() => TimeInHour);
            }
        }
        private string _TimeInDate;

        public string TimeInDate
        {
            get { return _TimeInDate; }
            set
            {
                _TimeInDate = value;
                NotifyOfPropertyChange(() => TimeInDate);
            }
        }



        #endregion

        public void TimeInEnter()
        {
            try
            {
                if (UserAuthenticate(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TimeinoutDB;Integrated Security=True", _UserName, _Passkey) > 0 )
                {

                    if (PostInUser(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TimeinoutDB;Integrated Security=True",_UserName) > 0)
                    {
                        MessageBox.Show("Time in successful!");
                        Cancel();
                    }else
                    {
                        MessageBox.Show("Invalid Error writing in database");
                        Cancel();
                    }


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
