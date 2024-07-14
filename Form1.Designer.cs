namespace CheatFormsReformulado
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBoxESP = new GroupBox();
            buttonReajustar_Esp = new Button();
            checkBoxDesenhar_Linha = new CheckBox();
            CheckBoxESP = new CheckBox();
            groupBoxAimbot = new GroupBox();
            checkBoxAimbot = new CheckBox();
            groupBoxModificarValores = new GroupBox();
            buttonAplicar = new Button();
            textBoxValorItem = new TextBox();
            comboBoxSelecaoValor = new ComboBox();
            toolTip1 = new ToolTip(components);
            groupBoxESP.SuspendLayout();
            groupBoxAimbot.SuspendLayout();
            groupBoxModificarValores.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxESP
            // 
            groupBoxESP.Controls.Add(buttonReajustar_Esp);
            groupBoxESP.Controls.Add(checkBoxDesenhar_Linha);
            groupBoxESP.Controls.Add(CheckBoxESP);
            groupBoxESP.Location = new Point(11, 12);
            groupBoxESP.Name = "groupBoxESP";
            groupBoxESP.Size = new Size(195, 139);
            groupBoxESP.TabIndex = 0;
            groupBoxESP.TabStop = false;
            groupBoxESP.Text = "Percepção Extra-Sensorial";
            // 
            // buttonReajustar_Esp
            // 
            buttonReajustar_Esp.Location = new Point(16, 97);
            buttonReajustar_Esp.Name = "buttonReajustar_Esp";
            buttonReajustar_Esp.Size = new Size(173, 29);
            buttonReajustar_Esp.TabIndex = 2;
            buttonReajustar_Esp.Text = "Reajustar ESP";
            buttonReajustar_Esp.UseVisualStyleBackColor = true;
            buttonReajustar_Esp.Click += buttonReajustarEsp_Click;
            // 
            // checkBoxDesenhar_Linha
            // 
            checkBoxDesenhar_Linha.AutoSize = true;
            checkBoxDesenhar_Linha.Location = new Point(16, 67);
            checkBoxDesenhar_Linha.Name = "checkBoxDesenhar_Linha";
            checkBoxDesenhar_Linha.Size = new Size(132, 24);
            checkBoxDesenhar_Linha.TabIndex = 1;
            checkBoxDesenhar_Linha.Text = "Desenhar Linha";
            checkBoxDesenhar_Linha.UseVisualStyleBackColor = true;
            checkBoxDesenhar_Linha.CheckedChanged += checkBoxDesenharLinha_CheckedChanged;
            // 
            // CheckBoxESP
            // 
            CheckBoxESP.AutoSize = true;
            CheckBoxESP.Location = new Point(16, 37);
            CheckBoxESP.Name = "CheckBoxESP";
            CheckBoxESP.Size = new Size(55, 24);
            CheckBoxESP.TabIndex = 0;
            CheckBoxESP.Text = "ESP";
            CheckBoxESP.UseVisualStyleBackColor = true;
            CheckBoxESP.CheckedChanged += CheckBoxESP_CheckedChanged;
            // 
            // groupBoxAimbot
            // 
            groupBoxAimbot.Controls.Add(checkBoxAimbot);
            groupBoxAimbot.Location = new Point(213, 12);
            groupBoxAimbot.Name = "groupBoxAimbot";
            groupBoxAimbot.Size = new Size(197, 139);
            groupBoxAimbot.TabIndex = 1;
            groupBoxAimbot.TabStop = false;
            groupBoxAimbot.Text = "Mira Automatica";
            // 
            // checkBoxAimbot
            // 
            checkBoxAimbot.AutoSize = true;
            checkBoxAimbot.Location = new Point(49, 57);
            checkBoxAimbot.Name = "checkBoxAimbot";
            checkBoxAimbot.Size = new Size(81, 24);
            checkBoxAimbot.TabIndex = 0;
            checkBoxAimbot.Text = "Aimbot";
            checkBoxAimbot.UseVisualStyleBackColor = true;
            checkBoxAimbot.CheckedChanged += checkBoxAimbot_CheckedChanged;
            // 
            // groupBoxModificarValores
            // 
            groupBoxModificarValores.Controls.Add(buttonAplicar);
            groupBoxModificarValores.Controls.Add(textBoxValorItem);
            groupBoxModificarValores.Controls.Add(comboBoxSelecaoValor);
            groupBoxModificarValores.Location = new Point(11, 157);
            groupBoxModificarValores.Margin = new Padding(3, 4, 3, 4);
            groupBoxModificarValores.Name = "groupBoxModificarValores";
            groupBoxModificarValores.Padding = new Padding(3, 4, 3, 4);
            groupBoxModificarValores.Size = new Size(398, 80);
            groupBoxModificarValores.TabIndex = 2;
            groupBoxModificarValores.TabStop = false;
            groupBoxModificarValores.Text = "Modificar Valores";
            // 
            // buttonAplicar
            // 
            buttonAplicar.Location = new Point(326, 29);
            buttonAplicar.Margin = new Padding(3, 4, 3, 4);
            buttonAplicar.Name = "buttonAplicar";
            buttonAplicar.Size = new Size(65, 31);
            buttonAplicar.TabIndex = 2;
            buttonAplicar.Text = "Aplicar";
            buttonAplicar.UseVisualStyleBackColor = true;
            buttonAplicar.Click += buttonAplicar_Click;
            // 
            // textBoxValorItem
            // 
            textBoxValorItem.Location = new Point(168, 30);
            textBoxValorItem.Margin = new Padding(3, 4, 3, 4);
            textBoxValorItem.Name = "textBoxValorItem";
            textBoxValorItem.Size = new Size(153, 27);
            textBoxValorItem.TabIndex = 1;
            textBoxValorItem.Tag = "";
            toolTip1.SetToolTip(textBoxValorItem, "Digite um Valor\r\nPara o Item Selecionado");
            textBoxValorItem.KeyPress += textBoxValorItem_KeyPress;
            // 
            // comboBoxSelecaoValor
            // 
            comboBoxSelecaoValor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelecaoValor.FormattingEnabled = true;
            comboBoxSelecaoValor.Items.AddRange(new object[] { "Vida", "Colete", "Munição Arma Primaria", "Munição Pistola", "Bolsa Arma Primaria", "Bolsa Pistola", "Granada" });
            comboBoxSelecaoValor.Location = new Point(7, 29);
            comboBoxSelecaoValor.Margin = new Padding(3, 4, 3, 4);
            comboBoxSelecaoValor.Name = "comboBoxSelecaoValor";
            comboBoxSelecaoValor.Size = new Size(155, 28);
            comboBoxSelecaoValor.TabIndex = 0;
            comboBoxSelecaoValor.Tag = "";
            comboBoxSelecaoValor.DropDown += comboBoxSelecaoValor_DropDown;
            comboBoxSelecaoValor.DropDownClosed += comboBoxSelecaoValor_DropDownClosed;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 10;
            toolTip1.AutoPopDelay = 100000;
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 412);
            Controls.Add(groupBoxModificarValores);
            Controls.Add(groupBoxAimbot);
            Controls.Add(groupBoxESP);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBoxESP.ResumeLayout(false);
            groupBoxESP.PerformLayout();
            groupBoxAimbot.ResumeLayout(false);
            groupBoxAimbot.PerformLayout();
            groupBoxModificarValores.ResumeLayout(false);
            groupBoxModificarValores.PerformLayout();
            ResumeLayout(false);
        }

        private void TextBoxValorItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GroupBox groupBoxESP;
        private CheckBox CheckBoxESP;
        private CheckBox checkBoxDesenhar_Linha;
        private Button buttonReajustar_Esp;
        private GroupBox groupBoxAimbot;
        private CheckBox checkBoxAimbot;
        private GroupBox groupBoxModificarValores;
        private ComboBox comboBoxSelecaoValor;
        private TextBox textBoxValorItem;
        private Button buttonAplicar;
        private ToolTip toolTip1;
    }
}