
using System;

namespace TimeInOut.ViewModels
{
    public class MainViewModel: BaseViewModel
    {

        public MainViewModel()
        {
           
         
        }

        public void TimeIn()
        {
          
            TimeInViewModel _timeinviewmodel = new TimeInViewModel();
            Operation = "Time In";
            CurrentDate = DateTime.Now.ToString("HH:mm:ss");
            Greetings = "Welcome";
            _windowManager.ShowDialog(_timeinviewmodel);

        }

        public void TimeOut()
        {

            TimeOutViewModel _timeoutviewmodel = new TimeOutViewModel();
            Operation = "Time Out";
            Greetings = "Thank you";
            CurrentDate = DateTime.Now.ToString("HH:mm:ss");
            _windowManager.ShowDialog(_timeoutviewmodel);

        }
    }
}
