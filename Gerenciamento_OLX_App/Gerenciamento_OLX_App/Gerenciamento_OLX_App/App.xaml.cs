using Gerenciamento_OLX_App.Banco.Configuracao;
using Gerenciamento_OLX_App.View;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Gerenciamento_OLX_App
{

    public partial class App : Application
    {
            public static string PaginaIni { get; set; }
            public static string PaginaCha { get; set; }
            public static DateTime DataFecha { get; set; }
            public static string ValorInve { get; set; }

            public App()
            {
                InitializeComponent();

                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.
                    Application.SetWindowSoftInputModeAdjust(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.WindowSoftInputModeAdjust.Resize);

                PaginaIni = "";
                var confg = ConfiguracaoDB.GetAllConfigApp().LastOrDefault();
                if (confg != null)
                {
                    PaginaCha = confg.PaginaChat;
                    PaginaIni = confg.PaginaInicial;
                    DataFecha = confg.DataFechamento;
                    ValorInve = confg.CotaInvestimento;
                }


                MainPage = new MasterPage();
                ((MasterPage)App.Current.MainPage).Detail = new NavigationPage(new HomePage());
                ((MasterPage)App.Current.MainPage).IsPresented = false;
            }


            protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
