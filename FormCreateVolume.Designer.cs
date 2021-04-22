namespace LTIOpenstackProject
{
    partial class FormCreateVolume
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxVolType = new System.Windows.Forms.ComboBox();
            this.radioButtonEmpty = new System.Windows.Forms.RadioButton();
            this.radioButtonISO = new System.Windows.Forms.RadioButton();
            this.radioButtonVolume = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxISO = new System.Windows.Forms.ComboBox();
            this.comboBoxVolume = new System.Windows.Forms.ComboBox();
            this.buttonCreateVolume = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 22);
            this.textBox1.TabIndex = 0;
            // 
            // comboBoxVolType
            // 
            this.comboBoxVolType.FormattingEnabled = true;
            this.comboBoxVolType.Location = new System.Drawing.Point(234, 94);
            this.comboBoxVolType.Name = "comboBoxVolType";
            this.comboBoxVolType.Size = new System.Drawing.Size(208, 24);
            this.comboBoxVolType.TabIndex = 1;
            // 
            // radioButtonEmpty
            // 
            this.radioButtonEmpty.AutoSize = true;
            this.radioButtonEmpty.Location = new System.Drawing.Point(137, 160);
            this.radioButtonEmpty.Name = "radioButtonEmpty";
            this.radioButtonEmpty.Size = new System.Drawing.Size(115, 21);
            this.radioButtonEmpty.TabIndex = 2;
            this.radioButtonEmpty.TabStop = true;
            this.radioButtonEmpty.Text = "Volume Vazio";
            this.radioButtonEmpty.UseVisualStyleBackColor = true;
            this.radioButtonEmpty.CheckedChanged += new System.EventHandler(this.radioButtonEmpty_CheckedChanged);
            // 
            // radioButtonISO
            // 
            this.radioButtonISO.AutoSize = true;
            this.radioButtonISO.Location = new System.Drawing.Point(319, 160);
            this.radioButtonISO.Name = "radioButtonISO";
            this.radioButtonISO.Size = new System.Drawing.Size(78, 21);
            this.radioButtonISO.TabIndex = 3;
            this.radioButtonISO.TabStop = true;
            this.radioButtonISO.Text = "Imagem";
            this.radioButtonISO.UseVisualStyleBackColor = true;
            this.radioButtonISO.CheckedChanged += new System.EventHandler(this.radioButtonISO_CheckedChanged);
            // 
            // radioButtonVolume
            // 
            this.radioButtonVolume.AutoSize = true;
            this.radioButtonVolume.Location = new System.Drawing.Point(522, 160);
            this.radioButtonVolume.Name = "radioButtonVolume";
            this.radioButtonVolume.Size = new System.Drawing.Size(76, 21);
            this.radioButtonVolume.TabIndex = 4;
            this.radioButtonVolume.TabStop = true;
            this.radioButtonVolume.Text = "Volume";
            this.radioButtonVolume.UseVisualStyleBackColor = true;
            this.radioButtonVolume.CheckedChanged += new System.EventHandler(this.radioButtonVolume_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome do Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Origem";
            // 
            // comboBoxISO
            // 
            this.comboBoxISO.FormattingEnabled = true;
            this.comboBoxISO.Location = new System.Drawing.Point(105, 225);
            this.comboBoxISO.Name = "comboBoxISO";
            this.comboBoxISO.Size = new System.Drawing.Size(208, 24);
            this.comboBoxISO.TabIndex = 8;
            // 
            // comboBoxVolume
            // 
            this.comboBoxVolume.FormattingEnabled = true;
            this.comboBoxVolume.Location = new System.Drawing.Point(409, 225);
            this.comboBoxVolume.Name = "comboBoxVolume";
            this.comboBoxVolume.Size = new System.Drawing.Size(208, 24);
            this.comboBoxVolume.TabIndex = 9;
            this.comboBoxVolume.SelectedIndexChanged += new System.EventHandler(this.comboBoxVolume_SelectedIndexChanged);
            // 
            // buttonCreateVolume
            // 
            this.buttonCreateVolume.Location = new System.Drawing.Point(288, 358);
            this.buttonCreateVolume.Name = "buttonCreateVolume";
            this.buttonCreateVolume.Size = new System.Drawing.Size(128, 29);
            this.buttonCreateVolume.TabIndex = 10;
            this.buttonCreateVolume.Text = "Criar Volume";
            this.buttonCreateVolume.UseVisualStyleBackColor = true;
            this.buttonCreateVolume.Click += new System.EventHandler(this.buttonCreateVolume_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tamanho";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(288, 308);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(208, 22);
            this.textBoxSize.TabIndex = 12;
            // 
            // FormCreateVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCreateVolume);
            this.Controls.Add(this.comboBoxVolume);
            this.Controls.Add(this.comboBoxISO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonVolume);
            this.Controls.Add(this.radioButtonISO);
            this.Controls.Add(this.radioButtonEmpty);
            this.Controls.Add(this.comboBoxVolType);
            this.Controls.Add(this.textBox1);
            this.Name = "FormCreateVolume";
            this.Text = "FormCreateVolume";
            this.Load += new System.EventHandler(this.FormCreateVolume_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxVolType;
        private System.Windows.Forms.RadioButton radioButtonEmpty;
        private System.Windows.Forms.RadioButton radioButtonISO;
        private System.Windows.Forms.RadioButton radioButtonVolume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxISO;
        private System.Windows.Forms.ComboBox comboBoxVolume;
        private System.Windows.Forms.Button buttonCreateVolume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSize;
    }
}