using Gerenciamento_OLX_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gerenciamento_OLX_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel(Navegador);
        }

        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();

            if (Navegador.CanGoBack)
            {
                Navegador.GoBack();
            }
            else
            {
              
                    return base.OnBackButtonPressed();
        

            }

            return true;
        }
    }
}