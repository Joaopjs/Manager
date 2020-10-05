using Gerenciamento_OLX_App.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged	
    {
		
		private HtmlWebViewSource _link;

		public HtmlWebViewSource LinkChat
		{
			get { return _link; }
			set { _link = value; OnPropertyChanged("Link"); }
		}

		public ChatViewModel(WebView web)
		{
			HtmlWebViewSource html = new HtmlWebViewSource();
			HttpClient httpClient = new HttpClient();

			try
			{
				var taskhtml = httpClient.GetAsync("https://sp.olx.com.br/regiao-de-sorocaba");
				var f = taskhtml.Result.Content.ReadAsStringAsync();
				html.Html =  f.GetAwaiter().GetResult();
			}
			catch (Exception)
			{

				html.Html = @"<html><body>
                              <center><h1>Voce Não Esta Conectado a Internet</h1>
                              <p>Conecte e tente Novamente.</p></center>
                              </body></html>";
			}

			

			LinkChat = html;
			
		}


		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string texto)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
		}
	}
}
