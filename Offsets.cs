
namespace CheatOffsets
{

    //Aqui ficam os offsets de memoria, enderecos estaticos do jogo
    public static class OffsetsEstaticos
    {
        //Enderecos estaticos 
        public static int
             ViewMatrix = 0x0057DFD0,
             LocalPlayer = 0x0058AC00,
             EntityList = 0x00591FCC, 
             ModoJogo = 0x0058ABF8, // 7,20,21 == Time 
             QuanPlayers = 0x00591FD4;
    }

    public static class OffsetsPlayer
    {
        //Offsets do player
        public static int
            Cabeca = 0x4,
            Pes = 0x28,
            Angulos = 0x34,
            Vida = 0xEC,
            Dead = 0xB4,
            Nome = 0x205,
            Time = 0x30C,
            MunicaoPrimaria = 0x130,
            MunicaoPistola = 0x12C,
            BolsaPrimaria = 0x10C,
            BolsaPistola = 0x108,
            Granada = 0x144,
            Colete = 0xF0;
    }
}
