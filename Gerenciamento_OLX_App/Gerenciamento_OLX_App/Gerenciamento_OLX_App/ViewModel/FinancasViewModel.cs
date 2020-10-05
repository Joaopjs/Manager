using Gerenciamento_OLX_App.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class FinancasViewModel : INotifyPropertyChanged
    {
        public Command GoChatCommand { get; set; }
        public Command GoEstoqueCommand { get; set; }

        public FinancasViewModel()
        {
            GoChatCommand = new Command(GoChat);
            GoEstoqueCommand = new Command(GoEstoque);
        }

        private void GoEstoque(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new EstoquePage());
        }

        private void GoChat(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChatPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }
    }
}
