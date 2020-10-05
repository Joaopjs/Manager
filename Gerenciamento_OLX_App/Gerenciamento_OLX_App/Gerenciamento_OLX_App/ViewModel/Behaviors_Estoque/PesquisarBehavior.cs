using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel.Behaviors_Estoque
{
    public class PesquisarBehavior : Behavior<SearchBar>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BehaviorsActionCommand), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(SearchBar search)
        {
            base.OnAttachedTo(search);

            this.BindingContext = search.BindingContext;

            search.TextChanged += Search_TextChanged;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = sender as SearchBar;
            var bt = searchBar?.BindingContext as EstoqueViewModel;

            var sd = e.NewTextValue.ToString();

            bt.PesquisarCommand.Execute(e.NewTextValue.ToString());


        }

        protected override void OnDetachingFrom(SearchBar search)
        {
            base.OnDetachingFrom(search);
            search.TextChanged -= Search_TextChanged;
        }

    }
}
