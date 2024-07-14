using CheatGame;
using CheatOffsets;
using System.Numerics;

namespace CheatPlayer
{
    public class Player
    {
        //Criando a estrutura de um Player
        public Player(nint ponteiroBase) {  this.PonteiroBase = ponteiroBase;}

        private IntPtr PonteiroBase;

        public IntPtr EnderecoBase { get { return Game.M.LerPonteiro(PonteiroBase); } }

        public int Vida { get { return Game.M.LerInt(EnderecoBase + OffsetsPlayer.Vida); } }

        public Vector3 PosicaoPes { get { return Game.M.LerVector3(EnderecoBase + OffsetsPlayer.Pes); } }

        public Vector3 PosicaoCabeca { get { return Game.M.LerVector3(EnderecoBase + OffsetsPlayer.Cabeca); } }

        public Vector2 PosicaoMouse { get { return Game.M.LerVector2(EnderecoBase + OffsetsPlayer.Angulos); } }

        public string Nome { get { return Game.M.LerString(EnderecoBase + OffsetsPlayer.Nome); } }

        public int Time { get { return Game.M.LerInt(EnderecoBase + OffsetsPlayer.Time); } }

        public bool EstaVivo { get { return this.Vida > 0 && this.Vida <= 100; } }

        public float Distancia(Player player)
        {
            float distPes = Vector3.DistanceSquared(this.PosicaoPes, player.PosicaoPes);
            float distCabeca = Vector3.DistanceSquared(this.PosicaoCabeca, player.PosicaoCabeca);
            return distPes * distCabeca;
        }
    }
}
