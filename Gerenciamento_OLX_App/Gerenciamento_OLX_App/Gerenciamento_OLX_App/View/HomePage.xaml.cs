using Gerenciamento_OLX_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gerenciamento_OLX_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public List<string> history = new List<string>();
        public string CurrentUrl { get; set; }

        public HomePage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.
                Application.SetWindowSoftInputModeAdjust(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.WindowSoftInputModeAdjust.Resize);
            
            BindingContext = new HomeViewModel(Navegador);

           
        }

        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            
            if (!Navegador.CanGoBack)
            {
                Navegador.GoBack();
            }
            else
            {
                if (Navegador.CanGoBack)
                {
                    Navegador.GoBack();
                }
                else
                {
                    return base.OnBackButtonPressed();
                }
               
            }        

            return true;
        }

    }
}