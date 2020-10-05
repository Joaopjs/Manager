using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gerenciamento_OLX_App.ViewModel.Behaviors_Estoque
{
    public class EstadoEstoqueBehavior : Behavior<Label>
    {
        protected override void OnAttachedTo(Label bindable)
        {
            base.OnAttachedTo(bindable);
            
        }

        protected override void OnDetachingFrom(Label bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
