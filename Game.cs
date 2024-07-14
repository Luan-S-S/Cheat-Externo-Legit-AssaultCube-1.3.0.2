using System.Diagnostics;
using MetodosMemoria;
using CheatOffsets;
using CheatPlayer;

namespace CheatGame
{
    public static class Game
    {
        public static void VerificarProcesso()
        {
            try
            {
                // Verificando se o jogo esta aberto
                Processo = Process.GetProcessesByName("ac_client")[0];
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Processo do jogo não encontrado\nPrograma finalizado");
                Application.Exit(); // se não estiver aberto o aplicativo é finalizado
            }
            catch (Exception e) 
            { 
                MessageBox.Show($"Erro inesperado\n {e.Message}");
                Application.Exit();
            }
            if(Processo != null)
            {
                HandleProcesso = Processo.Handle;
                EnderecoBase = Processo.MainModule.BaseAddress; // Sempre 0x40000 em hexdecimal e 4.194.304 em decimal
                M = new Memoria(HandleProcesso);
                MeuJogador = new Player(OffsetsEstaticos.LocalPlayer); //Instanciando o meu Player
            }


        }
        // Propriedades de Processo do jogo
        private static Process Processo;
        private static IntPtr HandleProcesso, EnderecoBase, PonteiroListaPlayers;
        public static Player MeuJogador;
        public static Memoria M;
        private static object LockThreads = new object();
        public static float[] ViewMatrix { get => M.LerMatrix(OffsetsEstaticos.ViewMatrix);  }
        
        public static int? MeuTime()
        {
            //Recupera o time do meu Player de acordo com os modos de jogo
            int modoJogo = ModoDeJogo(); 

            if(modoJogo == 7 || modoJogo == 20 || modoJogo == 21) { return MeuJogador.Time; }
            return null;
        }
        public static void AtualizarListaJogadores(List<Player> lista)
        {
            lock(LockThreads)
            {
                AlimentarListaJogadores(lista); 
            }
        }
        private static int QuantJogadores() { return M.LerInt(OffsetsEstaticos.QuanPlayers); }  //Retorna a quantidade de jogadores
        private static int ModoDeJogo() { return M.LerInt(OffsetsEstaticos.ModoJogo); } //Retorna o modo de jogo 7,20,21 == Team 
        private static IntPtr ObterPonteiroListaJogadores() { return M.LerPonteiro(OffsetsEstaticos.EntityList); }
        private static void GerenciarListaJogadores(List<Player> lista)
        {
            //Gerencia a mudança no Ponteiro do EntityList
            if(PonteiroListaPlayers != ObterPonteiroListaJogadores())
            {
                lista.Clear();
                PonteiroListaPlayers = ObterPonteiroListaJogadores();
            }
        }
        private static void AlimentarListaJogadores(List<Player> lista)
        {
            //Alimenta a lista passada como parametro de acordo com a quantidaded e jogadores na partida

            int quantJogadoresAtual = QuantJogadores();

            if(quantJogadoresAtual > 0)
            {
                GerenciarListaJogadores(lista);

                int tamLista = lista.Count;

                if (quantJogadoresAtual > tamLista)
                {
                    for (int i = tamLista; lista.Count < quantJogadoresAtual; i++) { lista.Add(new Player(PonteiroListaPlayers + (i * 0x4))); }
                }
                else
                {
                    for (int i = tamLista; lista.Count > quantJogadoresAtual; i--) { lista.RemoveAt(i - 1); }
                }
            }
            
        }
    }
}
