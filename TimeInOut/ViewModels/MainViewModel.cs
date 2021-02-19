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
         
            _windowManager.ShowDialog(_timeinviewmodel);
        }

        public void TimeOut()
        {

            TimeOutViewModel _timeoutviewmodel = new TimeOutViewModel();
        
            _windowManager.ShowDialog(_timeoutviewmodel);
        }
    }
}
