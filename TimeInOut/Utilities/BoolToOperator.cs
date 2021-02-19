using TimeInOut.ViewModels;

namespace TimeInOut.Utilities
{
    public class BoolToOperator: BaseViewModel
    {
        private string _operator;

        public string Operator
        {
            get { return _operator; }
            set
            {
                _operator = value; NotifyOfPropertyChange(() => Operator);
            }
        }
    }
}
