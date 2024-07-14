using System.Runtime.InteropServices;

namespace MetodosSobreposicao
{
    public class Sobreposicao
    {
        public Sobreposicao(string nomeJanelaProcesso, Form formulario)
        {
            this.NomeJanelaProcesso = nomeJanelaProcesso;
            this.Formulario = formulario;
            this.HandleJanelaProcesso = FindWindow(null, NomeJanelaProcesso); // Pegando identificador handle da janela do jogo
        } 

        private IntPtr HandleJanelaProcesso;
        private string NomeJanelaProcesso;
        private Form Formulario;
        private RECT rect; // guarda as dimenssoes da janela do jogo

        // User32

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT IpRect);

        private struct RECT { public int left, top, right, bottom;}

        private void ObterRect() { GetWindowRect(HandleJanelaProcesso, out rect); }
        private void FicarInvisivel() // Deixando o formulario sobreposto invisivel
        {
            Formulario.ShowInTaskbar = false; 
            Formulario.BackColor = Color.Wheat;
            Formulario.TransparencyKey = Color.Wheat;
            Formulario.TopMost = true;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            InvalidarClique();
        }
        private void InvalidarClique() // Invalidando o evento de clique do formulario sobreposto
        {
            IntPtr handleFormulario = Formulario.Handle;

            int initialStyle = GetWindowLong(handleFormulario, -20);
            SetWindowLong(handleFormulario, -20, initialStyle | 0x8000 | 0x20);
        }

        private Size CalcSize() {return new Size(rect.right - rect.left, rect.bottom - rect.top);}

        private void AjustarRect() //Ajustado precisamente o formulario com a janela do jogo
        {
            rect.bottom -= 8;
            rect.top += 32;
            rect.left += 8;
            rect.right -= 8;
        }
        public void Sobrepor() // Sobrepoe o formulario na janela do jogo
        {
            FicarInvisivel();
            AjustarSobreposicao();
            Formulario.Show();
        }

        public void AjustarSobreposicao()
        {
            ObterRect();
            AjustarRect();
            Formulario.Size = CalcSize();
            Formulario.Left = rect.left;
            Formulario.Top = rect.top;;
        }


    }
    
}
