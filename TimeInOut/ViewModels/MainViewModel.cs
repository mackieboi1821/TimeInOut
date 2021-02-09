using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
         
            
            _globalVariable = "sample";

            TimeInViewModel _timeinviewmodel = new TimeInViewModel();

            _windowManager.ShowDialog(_timeinviewmodel);

        }


    }
}
