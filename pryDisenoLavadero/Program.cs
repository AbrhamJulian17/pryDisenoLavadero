using pryCalculoLavadero;
using System;
using System.Windows.Forms;

namespace pryCalculoLavadero
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLavados());
        }
    }
}