using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class CommandBehaviors : Behavior<ImageButton>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                "Command",
                typeof(ICommand),
                typeof(CommandBehaviors));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }        

        protected override void OnAttachedTo(ImageButton bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.Clicked += BindableOnClickedItem;
        }       

        protected override void OnDetachingFrom(ImageButton bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Clicked -= BindableOnClickedItem;
        }
 
        public void BindableOnClickedItem(object sender, EventArgs e)
        {
            Command?.Execute(null);
        }
    }
}
