using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel.Behaviors_Estoque
{
    public class EstadoBehaviors : Behavior<Entry>
    {
        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EstadoBehaviors), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            this.BindingContext = entry.BindingContext;
            entry.TextChanged += Entry_TextChanged;
        }

        /// <summary>
        /// Responsavel por mostrar o estado do produto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddEstoqueViewModel viewModel = new AddEstoqueViewModel();
            Entry label = sender as Entry;

            viewModel = label?.BindingContext as AddEstoqueViewModel;

            var sd = e.NewTextValue.ToString();

            AddEstoqueViewModel.EstadoItem = sd;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= Entry_TextChanged;
        }
    }
}
