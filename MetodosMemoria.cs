using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace MetodosMemoria
{
    public class Memoria
    {
        public Memoria(IntPtr hp) { HandleProcesso = hp; }

        private IntPtr HandleProcesso;

        // Kernel32 

        [DllImport("Kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hP, IntPtr endereco, byte[] buffer, int tamBuffer, out int quantBytesLidos);

        [DllImport("Kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hP, IntPtr endereco, byte[] buffer, int tamBuffer, out int quantBytesEscritos);

        private byte[] PivoLer(IntPtr endereco, int tamBuffer = 4)
        {
            //Pivo usado para encapsuar ReadProcessMemory
            byte[] buffer = new byte[tamBuffer];

            bool sucess = ReadProcessMemory(HandleProcesso, endereco, buffer, tamBuffer, out int quantBytesLidos);


            if(!sucess)
            {
                MessageBox.Show($"Leitura deu Errado\n{endereco.ToString("X")}");
                return Array.Empty<byte>();
            }
            return buffer;

        }

        private void PivoEscrever(IntPtr endereco, object valor)
        {
            //Pivo usado para encapsuar WriteProcessMemory
            byte[] buffer;

            if(valor is float f) buffer = BitConverter.GetBytes(f);
            else if(valor is int i) buffer = BitConverter.GetBytes(i);
            else { MessageBox.Show("Tipo errado");  return; }

            bool sucess = WriteProcessMemory(HandleProcesso, endereco, buffer, buffer.Length, out int quanBytesEscritos);

            if(!sucess) { MessageBox.Show("Erro ao Escrever no endereco"); }
        }

        //Metodos de Ler Memoria
        public int LerInt(IntPtr endereco) { return BitConverter.ToInt32(PivoLer(endereco)); }
        public float LerFloat(IntPtr endereco) { return BitConverter.ToSingle(PivoLer(endereco)); }
        public IntPtr LerPonteiro(IntPtr endereco) { return new IntPtr(LerInt(endereco)); }
        public string LerString(IntPtr endereco) { return Encoding.UTF8.GetString(PivoLer(endereco, 10)); }
        public Vector2 LerVector2(IntPtr endereco)
        {
            Vector2 vector2 = new Vector2();

            vector2.X = LerFloat(endereco);
            vector2.Y = LerFloat(endereco + 0x4);

            return vector2;
        }

        public Vector3 LerVector3(IntPtr endereco)
        {
            Vector3 vector3 = new Vector3();

            vector3.X = LerFloat(endereco);
            vector3.Y = LerFloat(endereco + 0x4);
            vector3.Z = LerFloat(endereco + 0x8);

            return vector3;
        }

        public float[] LerMatrix(IntPtr endereco)
        {
            float[] matrix = new float[16];
            int y = 0;
            for(int i = 0; i < 16; i++)
            {
                matrix[i] = LerFloat(endereco + 0x0+y);
                y += 4;
            }
            return matrix;
        }

        //Metodos de Escrever Memoria
        public void EscreverInt(IntPtr endereco, int valor) { PivoEscrever(endereco, valor); }
        public void EscreverFloat(IntPtr endereco, float valor) { PivoEscrever(endereco, valor); }

    }

    
}
