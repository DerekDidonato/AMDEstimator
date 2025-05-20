
using System;
using System.Windows.Input;

namespace AMDEstimator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand ShowTakeoffViewCommand { get; }
        public ICommand ShowJobManagerViewCommand { get; }
        public ICommand ShowEstimatingViewCommand { get; }
        public ICommand ShowReportingViewCommand { get; }

        private readonly TakeoffViewModel _takeoffViewModel;
        private readonly JobManagerViewModel _jobManagerViewModel;
        private readonly EstimatingViewModel _estimatingViewModel;
        private readonly ReportingViewModel _reportingViewModel;

        public MainViewModel()
        {
            _takeoffViewModel = new TakeoffViewModel();
            _jobManagerViewModel = new JobManagerViewModel();
            _estimatingViewModel = new EstimatingViewModel();
            _reportingViewModel = new ReportingViewModel();

            ShowTakeoffViewCommand = new RelayCommand(o => ShowTakeoffView());
            ShowJobManagerViewCommand = new RelayCommand(o => ShowJobManagerView());
            ShowEstimatingViewCommand = new RelayCommand(o => ShowEstimatingView());
            ShowReportingViewCommand = new RelayCommand(o => ShowReportingView());

            // Default view
            CurrentView = _takeoffViewModel;
        }

        private void ShowTakeoffView()
        {
            CurrentView = _takeoffViewModel;
        }

        private void ShowJobManagerView()
        {
            CurrentView = _jobManagerViewModel;
        }

        private void ShowEstimatingView()
        {
            CurrentView = _estimatingViewModel;
        }

        private void ShowReportingView()
        {
            CurrentView = _reportingViewModel;
        }
    }
}
