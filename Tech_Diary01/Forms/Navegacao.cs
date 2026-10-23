using System;
using System.Windows.Forms;

namespace Tech_Diary01.Forms
{
    public static class Navegacao
    {
        public static void Abrir(Form origem, Form destino)
        {
            destino.FormClosed += delegate { origem.Show(); };
            origem.Hide();
            destino.Show();
        }
    }
}
