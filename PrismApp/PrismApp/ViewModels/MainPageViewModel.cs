using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        private bool _isToggled;
        public bool IsToggled
        {
            get { return _isToggled; }
            set
            {
                SetProperty(ref _isToggled, value);
            }
        }

        public DelegateCommand LoginCommand { get; set; }

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this.LoginCommand = new DelegateCommand(Login, CanExecute)
                                    .ObservesProperty(() => Username)
                                    .ObservesProperty(() => Password)
                                    .ObservesProperty(() => IsToggled)
                ;
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(this.Username) &&
                    !string.IsNullOrWhiteSpace(this.Password) &&
                    this.IsToggled;
        }

        private void Login()
        {
            _navigationService
                .NavigateAsync("/MDPage/Navigation/ViewA");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("product"))
                Title = ((Product)parameters["product"]).Name;
        }
    }
}
