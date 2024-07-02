namespace Dicionario
{
    partial class Form1
    {
        // dtDeclarando variáveis privadas
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxEditor;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        // Método para inicializar os componentes do formulário
        private void InitializeComponent()
        {
            this.textBoxEditor = new System.Windows.Forms.TextBox();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            
            // Configurações do textBox
            this.textBoxEditor.Location = new System.Drawing.Point(12, 12);
            this.textBoxEditor.Multiline = true;
            this.textBoxEditor.Name = "textBoxEditor";
            this.textBoxEditor.Size = new System.Drawing.Size(776, 397);
            this.textBoxEditor.TabIndex = 0;

            // Configurações do botão de carregar
            this.buttonLoadFile.Location = new System.Drawing.Point(12, 415);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFile.Text = "Carregar";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.BackColor = Color.LightPink; // Cor rosa
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);

            // Configurações do botão de salvar
            this.buttonSaveFile.Location = new System.Drawing.Point(93, 415);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFile.Text = "Salvar";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.BackColor = Color.LightPink; // Cor rosa
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);

            // Configurações do botão de validar
            this.buttonValidate.Location = new System.Drawing.Point(174, 415);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(75, 23);
            this.buttonValidate.Text = "Validar";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.BackColor = Color.LightPink; // Cor rosa
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);

            // Configurações da janela principal
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonValidate);
            this.Controls.Add(this.buttonSaveFile);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.textBoxEditor);
            this.Name = "Form1";
            this.Text = "Dicionário AED2";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
