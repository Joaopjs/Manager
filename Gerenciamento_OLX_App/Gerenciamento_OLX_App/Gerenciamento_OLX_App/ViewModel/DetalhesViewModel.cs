using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gerenciamento_OLX_App.ViewModel
{
    public class DetalhesViewModel : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string texto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(texto));
        }
    }
}
