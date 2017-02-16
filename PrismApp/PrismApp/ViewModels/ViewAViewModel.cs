using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PrismApp.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }

            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand AddCommand { get; set; } 
        private void Add()
        {
            Items.Add(new Product { Name = Text, IsActive = true });
            Text = string.Empty;
        }

        public ObservableCollection<Product> Items { get; set; }

        public ViewAViewModel()
        {
            AddCommand = new DelegateCommand(Add, CanExecute)
                .ObservesProperty(() => Text)
                ;

            Items = new ObservableCollection<Product>();
            Items.Add(new Product { Name = "A", IsActive = true });
            Items.Add(new Product { Name = "B", IsActive = false });
            Items.Add(new Product { Name = "C", IsActive = true });
        }

        private bool CanExecute() => !string.IsNullOrWhiteSpace(Text);

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //Items.Add((string)parameters["id"]);
        }
    }
}
