using CheatGame;
using CheatOffsets;

namespace CheatOutros
{
    public static class Modificador
    {
        private static IntPtr PonteiroBase = Game.MeuJogador.EnderecoBase;  

        //Dicionario usado para ligar a opção selecionada com o endereço de memoria.
        private static Dictionary<string, IntPtr> Enderecos = new Dictionary<string, nint>()
        {

            {"Vida", PonteiroBase + OffsetsPlayer.Vida}, 
            {"Colete", PonteiroBase + OffsetsPlayer.Colete}, 
            {"Munição Pistola", PonteiroBase + OffsetsPlayer.MunicaoPistola}, 
            {"Bolsa Pistola", PonteiroBase + OffsetsPlayer.BolsaPistola}, 
            {"Granada", PonteiroBase + OffsetsPlayer.Granada}
        };


        public static void Modificar(string chave, int valor)
        {
            if (chave == "Munição Arma Primaria")
            {
                ModificarPonteiros(OffsetsPlayer.MunicaoPrimaria, valor);
                return;
            }
            if(chave == "Bolsa Arma Primaria")
            {
                ModificarPonteiros(OffsetsPlayer.BolsaPrimaria, valor);
                return;
            }

            Game.M.EscreverInt(Enderecos[chave], valor);
        }
        private static void ModificarPonteiros(int offset, int valor)
        {
            //Metodo Modifica Todos os ponteiros relacionados a armas primarias e bolsas primarias
            //Pois eles possuiem ao menos 5 enderecos de memoria alternaveis
            IntPtr endereco;
            for(int i = 0; i < 5; i++)
            {
                endereco = PonteiroBase + offset;
                Game.M.EscreverInt(endereco, valor);
                offset += 0x4; //Icrementa os offsets 
            }
        }


    }
}
