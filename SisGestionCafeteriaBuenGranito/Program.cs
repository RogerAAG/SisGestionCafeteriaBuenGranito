using System;
using System.Windows.Forms;
// Ya no necesitamos 'using GranitoPOS;' porque todo está en 'SisGestionCafeteriaBuenGranito'

namespace SisGestionCafeteriaBuenGranito
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}