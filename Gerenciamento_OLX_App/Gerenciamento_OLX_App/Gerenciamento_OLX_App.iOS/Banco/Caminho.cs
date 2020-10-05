using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Gerenciamento_OLX_App.Banco;
using Gerenciamento_OLX_App.iOS.Banco;
using UIKit;

[assembly:Xamarin.Forms.Dependency(typeof(Caminho))]
namespace Gerenciamento_OLX_App.iOS.Banco
{
    public class Caminho : IDatabase
    {
        public string GetPathDB(string NomeArquivoBanco)
        {
            string caminhoDaPata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string pathBiblioteca = System.IO.Path.Combine(caminhoDaPata, "..", "Library");

            string caminhoBanco = Path.Combine(pathBiblioteca, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}