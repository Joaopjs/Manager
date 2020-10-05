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
    public partial class AddEstoquePage : ContentPage
    {
        public AddEstoquePage(Model.Produtos item = null, EstoqueViewModel estoqueViewModel = null)
        {
            InitializeComponent();
            BindingContext = new AddEstoqueViewModel(item, estoqueViewModel);         
            
        }
    }
}