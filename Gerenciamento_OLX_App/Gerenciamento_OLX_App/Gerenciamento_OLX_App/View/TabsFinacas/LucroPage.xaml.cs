using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gerenciamento_OLX_App.ViewModel.TabsFinacas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LucroPage : ContentPage
    {
        public LucroPage()
        {
            InitializeComponent();
            BindingContext = new LucroViewModel();
        }
    }
}