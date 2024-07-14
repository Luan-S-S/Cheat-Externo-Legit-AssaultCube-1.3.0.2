using CheatGame;
using CheatOffsets;
using CheatPlayer;
using MetodosSobreposicao;
using System.Numerics;
using System.Runtime.InteropServices;

namespace CheatESP_AIMBOT
{
    public class ESP
    {
        public bool DesenharLinha;
        private Form FormularioSobreposto;
        private Thread ThreadESP;
        private bool EspAtivado;
        private const string JanelaJogo = "AssaultCube";
        private List<Player> ListaPlayers = new List<Player>();
        private Sobreposicao sobreposto;
        private Graphics g;
        private Point PosicaoLinha, posPesTela, posCabecaTela;
        private Rectangle Retangulo;
        private Pen 
            CorRetangulo = new Pen(Color.LightBlue),
            CorLinha = new Pen(Color.Purple);
        public void Ativar()
        {
            if(FormularioSobreposto == null && ThreadESP == null)
            {
                
                FormularioSobreposto = new Form();
                ThreadESP = new Thread(MetodoEsp) { IsBackground = true };
                sobreposto = new Sobreposicao(JanelaJogo, FormularioSobreposto);
                sobreposto.Sobrepor();
                FormularioSobreposto.Paint += DesenhoESP;
                PosicaoLinha = new Point(FormularioSobreposto.Width/2, FormularioSobreposto.Height);
                EspAtivado = true;
                ThreadESP.Start();
            }
        }
        public void Desativar()
        {
            if(FormularioSobreposto != null && ThreadESP != null)
            {
                EspAtivado = false;
                ThreadESP.Join(); 
                LiberarThread(); 
                LiberarForm(); 
            }
        }

        private void DesenhoESP(object? sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (Player p in ListaPlayers)
            {
                if (p.EstaVivo && p.Time != Game.MeuTime() && WorldToScreem(p.PosicaoPes,ref posPesTela) && WorldToScreem(p.PosicaoCabeca,ref posCabecaTela)) // Calculo dando errado ao inves de || colocar &&
                {
                    AjustarRetangulo(ref Retangulo, posPesTela, posCabecaTela); // Ajusta as dimenssoes do retangulo 
                    g.DrawRectangle(CorRetangulo, Retangulo); // Desenha reatangulo
                    if (this.DesenharLinha) g.DrawLine(CorLinha, PosicaoLinha, posPesTela); // Desenha Linha
                }
            }
        }

        public void ReajustarEsp()
        {
            if(FormularioSobreposto != null) sobreposto.AjustarSobreposicao();
            PosicaoLinha.X = FormularioSobreposto.Width / 2; // Reajustando a posição da linha
            PosicaoLinha.Y = FormularioSobreposto.Height;
        }

        private void MetodoEsp()
        {
            
            while(EspAtivado)
            {
                Game.AtualizarListaJogadores(ListaPlayers);
                FormularioSobreposto.Refresh();
                Thread.Sleep(10);
            }
        }

        private void AjustarRetangulo(ref Rectangle rect, Point pes, Point cabeca)
        {

            int alturaY = pes.Y - cabeca.Y;

            rect.X = cabeca.X - alturaY / 4;
            rect.Y = cabeca.Y;

            rect.Width = alturaY / 2;
            rect.Height = alturaY;
        }

        private void LiberarThread() { ThreadESP = null; }
        private void LiberarForm()
        {
            FormularioSobreposto.Paint -= DesenhoESP;
            FormularioSobreposto.Dispose();
            FormularioSobreposto.Close();
            FormularioSobreposto = null;
        }

        private bool WorldToScreem(Vector3 PosPlayer,ref Point result)
        {
            var vmtx = Game.ViewMatrix;

            float screenW = (vmtx[3] * PosPlayer.X) + (vmtx[7] * PosPlayer.Y) + (vmtx[11] * PosPlayer.Z) + vmtx[15];

            if (screenW > 0.001f)
            {
                float screenX = (vmtx[0] * PosPlayer.X) + (vmtx[4] * PosPlayer.Y) + (vmtx[8] * PosPlayer.Z) + vmtx[12];
                float screenY = (vmtx[1] * PosPlayer.X) + (vmtx[5] * PosPlayer.Y) + (vmtx[9] * PosPlayer.Z) + vmtx[13];

                float camX = FormularioSobreposto.Width / 2f;
                float camY = FormularioSobreposto.Height / 2f;

                float x = camX + (camX * screenX / screenW);
                float y = camY - (camY * screenY / screenW);

                result.X = (int)x;
                result.Y = (int)y;

                return true;
            }
            return false;

        }

    }

    public class Aimbot
    {

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int botao);

        private List<Player> ListaPlayers = new List<Player>();
        private bool AimbotAtivado;
        private Thread ThreadAimbot;
        private int Botao = 02;
        private Player MeuPlayer;
        private bool TeclaPressionada { get { return GetAsyncKeyState(Botao) < 0; } }
        public void Ativar()
        {
            if(ThreadAimbot == null)
            {
                ThreadAimbot = new Thread(MetodoAimbot) { IsBackground = true};   
                AimbotAtivado = true;
                ThreadAimbot.Start();
            }
        }

        public void Desativar()
        {
            if(ThreadAimbot != null)
            {
                AimbotAtivado = false;
                ThreadAimbot.Join();
                ThreadAimbot = null;
            }
        }

        
        private void MetodoAimbot()
        {
            MeuPlayer = Game.MeuJogador;
            while (AimbotAtivado)
            {
                if (TeclaPressionada)
                {
                    Game.AtualizarListaJogadores(ListaPlayers);

                    Player player = ListaPlayers.Where(p => p.EstaVivo && p.Time != Game.MeuTime()).OrderBy(p => MeuPlayer.Distancia(p)).FirstOrDefault();

                    while (player != null && player.EstaVivo && TeclaPressionada)
                    {
                        Vector2 angulo = CalcularAngulo(player);
                        Mirar(angulo.X, angulo.Y);
                        Thread.Sleep(25);
                    }
                }
                Thread.Sleep(25);
            }
        }

        private Vector2 CalcularAngulo(Player inimigo)
        {
                
            // Implementação do github: https://github.com/0XDE57/AssaultCubeHack/blob/master/AssaultCubeHack/AssaultHack.cs

            Player meuPlayer = Game.MeuJogador;

            float x, y;

            var deltaX = inimigo.PosicaoPes.X - meuPlayer.PosicaoPes.X;
            var deltaY = inimigo.PosicaoPes.Y - meuPlayer.PosicaoPes.Y;

            x = (float)(Math.Atan2(deltaY, deltaX) * 180 / Math.PI) + 90;

            float deltaZ = inimigo.PosicaoPes.Z - meuPlayer.PosicaoPes.Z;
            float dist = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

            y = (float)(Math.Atan2(deltaZ, dist) * 180 / Math.PI);
            return new Vector2(x, y);
        }

        private void Mirar(float x, float y)
        {
            IntPtr posMeuMouse = Game.MeuJogador.EnderecoBase+OffsetsPlayer.Angulos;
            Game.M.EscreverFloat(posMeuMouse, x);
            Game.M.EscreverFloat(posMeuMouse+0x4, y);
        }

    }
}
