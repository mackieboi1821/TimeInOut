using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeInOut.Views;

namespace TimeInOut.ViewModels
{
    public class MainViewModel: BaseViewModel
    {

        public MainViewModel()
        {
            
           
           
        }


        public void TimeIn()
        {
          
            //_globalVariable = "sample";

            TimeInViewModel _timeinviewmodel = new TimeInViewModel();

            _windowManager.ShowDialog(_timeinviewmodel);
        }

        public void TimeOut()
        {

            TimeOutViewModel _timeoutviewmodel = new TimeOutViewModel();

            _windowManager.ShowDialog(_timeoutviewmodel);
        }




    }
}
