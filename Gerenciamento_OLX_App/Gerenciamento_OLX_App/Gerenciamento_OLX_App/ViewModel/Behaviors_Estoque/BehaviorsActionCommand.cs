using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel.Behaviors_Estoque
{
    public class BehaviorsActionCommand : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BehaviorsActionCommand), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(ListView imagebutton)
        {
            base.OnAttachedTo(imagebutton);

            this.BindingContext = imagebutton.BindingContext;

            imagebutton.ItemSelected += ActionMethod;
         }

        private void ActionMethod(object sender, EventArgs e)
        {
            ImageButton imageButton = sender as ImageButton;
            var bt = imageButton?.BindingContext as EstoqueViewModel;

            bt.EditarCommand.Execute(null);
        }

        protected override void OnDetachingFrom(ListView imagebutton)
        {
            base.OnDetachingFrom(imagebutton);
            imagebutton.ItemSelected += ActionMethod;
        }
    }
}
