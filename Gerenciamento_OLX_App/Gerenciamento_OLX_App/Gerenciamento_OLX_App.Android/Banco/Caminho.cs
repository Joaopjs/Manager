using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Gerenciamento_OLX_App.Banco;
using Gerenciamento_OLX_App.Droid.Banco;

[assembly: Xamarin.Forms.Dependency(typeof(Caminho))]
namespace Gerenciamento_OLX_App.Droid.Banco
{
    public class Caminho : IDatabase
    {
        public string GetPathDB(string NomeArquivoBanco)
        {
            string caminhoDaPata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = System.IO.Path.Combine(caminhoDaPata, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}