using Gerenciamento_OLX_App.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public Command GoEstoqueCommand { get; set; }
        public Command GoChatCommand { get; set; }

        public WebView WebView { get; set; }

        private HtmlWebViewSource _link;

        public HtmlWebViewSource Link
        {
            get { return _link; }
            set 
            {
                _link = value; 
                OnPropertyChanged("Link");            
            }
        }

        private StackLayout stackLayout;
        public StackLayout StackLayout
        {
            get { return stackLayout; }
            set { stackLayout = value; OnPropertyChanged("StackLayout"); }
        }

      

        public HomeViewModel(WebView web)
        {
            HtmlWebViewSource html = new HtmlWebViewSource();
            HttpClient httpClient = new HttpClient();
            try
            {
                var taskhtml = httpClient.GetAsync("https://sp.olx.com.br/regiao-de-sorocaba");
                var f = taskhtml.Result.Content.ReadAsStringAsync();
                html.Html = f.GetAwaiter().GetResult();
            }
            catch (Exception)
            {

                html.Html = @"<html><body>
                              <center><h1>Voce Não Esta Conectado a Internet</h1>
                              <p>Conecte e tente Novamente.</p></center>
                              </body></html>";
            }
            

            Link = html;

            GoEstoqueCommand = new Command(GoEstoque);
            GoChatCommand = new Command(GoChat);

     
        }

        private void GoChat(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChatPage());
        }

        private void GoEstoque(object obj)
        {
            ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new EstoquePage());
        }

        private void navegado(object sender, WebNavigatedEventArgs e)
        {
            string g = e.Url;
            string h = g;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }

    }
}
