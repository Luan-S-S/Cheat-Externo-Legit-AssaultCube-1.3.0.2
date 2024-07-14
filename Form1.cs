using CheatGame;
using CheatESP_AIMBOT;
using CheatOutros;

namespace CheatFormsReformulado
{
    public partial class Form1 : Form
    {

        ESP esp;
        Aimbot aimbot;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            esp = new ESP();
            aimbot = new Aimbot();
            Game.VerificarProcesso();

            // Desabilitando EspLinha e ReajustarEsp
            AbilitarCheckboxESP(false);

            // Colocando texto de ajuda no combobox
            MostrarTextoSelecionarItem();

        }
//ESP

        private void AbilitarCheckboxESP(bool valor)
        {
            this.checkBoxDesenhar_Linha.Enabled = valor;
            this.buttonReajustar_Esp.Enabled = valor;
        }
        private void CheckBoxESP_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxESP.Checked)
            {
                esp.Ativar();
                AbilitarCheckboxESP(true);
                return;
            }
            esp.Desativar();
            this.checkBoxDesenhar_Linha.Checked = false;
            AbilitarCheckboxESP(false);
        }

        private void checkBoxDesenharLinha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDesenhar_Linha.Checked)
            {
                esp.DesenharLinha = true;
                return;
            }
            esp.DesenharLinha = false;
        }

        private void buttonReajustarEsp_Click(object sender, EventArgs e)
        {
            esp.ReajustarEsp();
        }

//AIMBOT
        private void checkBoxAimbot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAimbot.Checked)
            {
                aimbot.Ativar();
                return;
            }
            aimbot.Desativar();
        }

//SELECIONAR VALORES COMBOBOX

        private void MostrarTextoSelecionarItem()
        {
            comboBoxSelecaoValor.Items.Add("Selecione um Item");
            comboBoxSelecaoValor.SelectedIndex = 7;
        }

        private void RemoverTextoDeAjudaComboBox()
        {
            if (comboBoxSelecaoValor.Items.Count > 7) comboBoxSelecaoValor.Items.RemoveAt(7);
        }

        private void comboBoxSelecaoValor_DropDown(object sender, EventArgs e)
        {
            RemoverTextoDeAjudaComboBox();
        }

        private void comboBoxSelecaoValor_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxSelecaoValor.SelectedIndex == -1) MostrarTextoSelecionarItem();
        }

//TEXTBOX DIGITAR VALOR
        private void textBoxValorItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }

//BOTAO APLICAR
        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            string item = comboBoxSelecaoValor.SelectedItem.ToString();
            if (item != "Selecione um Item" && Int32.TryParse(textBoxValorItem.Text, out int valor))
            {
                Modificador.Modificar(item, valor);
            }
            textBoxValorItem.Text = String.Empty;
            RemoverTextoDeAjudaComboBox(); // Para que "Selecione um Item" não fique aparecendo na lista"
            MostrarTextoSelecionarItem();

        }
//ENCERRAR PROGRAMA
        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            esp.Desativar();
            aimbot.Desativar();
            MessageBox.Show("Form fechado");
        }

        
    }
}