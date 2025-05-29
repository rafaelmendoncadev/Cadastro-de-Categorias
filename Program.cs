using System;
using System.Windows.Forms;
using Cadastro_de_Categorias.Interface;

namespace Cadastro_de_Categorias
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}