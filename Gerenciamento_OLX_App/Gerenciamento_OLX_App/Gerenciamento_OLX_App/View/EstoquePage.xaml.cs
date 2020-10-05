using Gerenciamento_OLX_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gerenciamento_OLX_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstoquePage : TabbedPage
    {
        public EstoqueViewModel evm => ((EstoqueViewModel)BindingContext);
        
        public EstoquePage()
        {
            InitializeComponent();
           
            BindingContext  = new EstoqueViewModel(this);
            OptionsVisible.IsVisible = false;
            

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;

            //envia o id do produto para a classe estoque viewModel
            var idProduto = button.ClassId;

            evm.IdProduto = idProduto;

            if (OptionsVisible.IsVisible == false)
            {
                OptionsVisible.IsVisible = true;
        
            }
            else
            {
                OptionsVisible.IsVisible = false;
            }

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {           
            OptionsVisible.IsVisible = false;
        }
    }
}