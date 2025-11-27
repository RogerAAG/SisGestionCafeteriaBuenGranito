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

            // --- TEST DE CONEXIÓN ---
            try
            {
                using (var con = ConexionDB.ObtenerConexion())
                {
                    MessageBox.Show("¡Conexión Exitosa con SQL Server!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLÓ LA CONEXIÓN:\n" + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Si falla, no arranca la app
            }
            // ------------------------

            Application.Run(new FrmLogin()); // O FrmLogin cuando lo tengas
        }
    }
}