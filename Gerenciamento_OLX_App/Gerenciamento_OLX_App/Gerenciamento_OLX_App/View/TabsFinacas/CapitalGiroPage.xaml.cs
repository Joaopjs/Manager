using Gerenciamento_OLX_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gerenciamento_OLX_App.View.TabsFinacas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapitalGiroPage : ContentPage
    {
        public CapitalGiroPage()
        {
            InitializeComponent();
            BindingContext = new CapitalGiroViewModel();
        }
    }
}