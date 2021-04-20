
namespace LTIOpenstackProject
{
    partial class Instance
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelISO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelVolume = new System.Windows.Forms.Label();
            this.comboBoxImages = new System.Windows.Forms.ComboBox();
            this.comboBoxVolume = new System.Windows.Forms.ComboBox();
            this.comboBoxFlavor = new System.Windows.Forms.ComboBox();
            this.comboBoxNetwork = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonVolume = new System.Windows.Forms.RadioButton();
            this.textBoxTemplateName = new System.Windows.Forms.TextBox();
            this.buttonCreateTemplate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSelectTemplate = new System.Windows.Forms.Button();
            this.buttonRemoveTemplate = new System.Windows.Forms.Button();
            this.openFileDialogTemplate = new System.Windows.Forms.OpenFileDialog();
            this.radioButtonISO = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome da Instância";
            // 
            // labelISO
            // 
            this.labelISO.AutoSize = true;
            this.labelISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelISO.Location = new System.Drawing.Point(17, 218);
            this.labelISO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelISO.Name = "labelISO";
            this.labelISO.Size = new System.Drawing.Size(192, 25);
            this.labelISO.TabIndex = 1;
            this.labelISO.Text = "Imagem da Instância";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 302);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Flavor da Instância";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 364);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Network da Instância";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(239, 34);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(248, 22);
            this.textBoxName.TabIndex = 4;
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVolume.Location = new System.Drawing.Point(16, 256);
            this.labelVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(189, 25);
            this.labelVolume.TabIndex = 5;
            this.labelVolume.Text = "Volume da Instância";
            // 
            // comboBoxImages
            // 
            this.comboBoxImages.FormattingEnabled = true;
            this.comboBoxImages.Location = new System.Drawing.Point(239, 222);
            this.comboBoxImages.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxImages.Name = "comboBoxImages";
            this.comboBoxImages.Size = new System.Drawing.Size(248, 24);
            this.comboBoxImages.TabIndex = 6;
            // 
            // comboBoxVolume
            // 
            this.comboBoxVolume.FormattingEnabled = true;
            this.comboBoxVolume.Location = new System.Drawing.Point(239, 256);
            this.comboBoxVolume.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxVolume.Name = "comboBoxVolume";
            this.comboBoxVolume.Size = new System.Drawing.Size(248, 24);
            this.comboBoxVolume.TabIndex = 7;
            // 
            // comboBoxFlavor
            // 
            this.comboBoxFlavor.FormattingEnabled = true;
            this.comboBoxFlavor.Location = new System.Drawing.Point(239, 302);
            this.comboBoxFlavor.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFlavor.Name = "comboBoxFlavor";
            this.comboBoxFlavor.Size = new System.Drawing.Size(248, 24);
            this.comboBoxFlavor.TabIndex = 8;
            // 
            // comboBoxNetwork
            // 
            this.comboBoxNetwork.FormattingEnabled = true;
            this.comboBoxNetwork.Location = new System.Drawing.Point(239, 362);
            this.comboBoxNetwork.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNetwork.Name = "comboBoxNetwork";
            this.comboBoxNetwork.Size = new System.Drawing.Size(248, 24);
            this.comboBoxNetwork.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(151, 449);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "Criar Instância";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Numero de Instâncias";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(239, 96);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(248, 22);
            this.textBoxCount.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(597, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Templates";
            // 
            // radioButtonVolume
            // 
            this.radioButtonVolume.AutoSize = true;
            this.radioButtonVolume.Location = new System.Drawing.Point(310, 178);
            this.radioButtonVolume.Name = "radioButtonVolume";
            this.radioButtonVolume.Size = new System.Drawing.Size(76, 21);
            this.radioButtonVolume.TabIndex = 15;
            this.radioButtonVolume.TabStop = true;
            this.radioButtonVolume.Text = "Volume";
            this.radioButtonVolume.UseVisualStyleBackColor = true;
            this.radioButtonVolume.CheckedChanged += new System.EventHandler(this.radioButtonVolume_CheckedChanged);
            // 
            // textBoxTemplateName
            // 
            this.textBoxTemplateName.Location = new System.Drawing.Point(650, 67);
            this.textBoxTemplateName.Name = "textBoxTemplateName";
            this.textBoxTemplateName.Size = new System.Drawing.Size(208, 22);
            this.textBoxTemplateName.TabIndex = 16;
            // 
            // buttonCreateTemplate
            // 
            this.buttonCreateTemplate.Location = new System.Drawing.Point(887, 57);
            this.buttonCreateTemplate.Name = "buttonCreateTemplate";
            this.buttonCreateTemplate.Size = new System.Drawing.Size(110, 32);
            this.buttonCreateTemplate.TabIndex = 17;
            this.buttonCreateTemplate.Text = "Criar Template";
            this.buttonCreateTemplate.UseVisualStyleBackColor = true;
            this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(599, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Name";
            // 
            // buttonSelectTemplate
            // 
            this.buttonSelectTemplate.Location = new System.Drawing.Point(650, 132);
            this.buttonSelectTemplate.Name = "buttonSelectTemplate";
            this.buttonSelectTemplate.Size = new System.Drawing.Size(165, 32);
            this.buttonSelectTemplate.TabIndex = 19;
            this.buttonSelectTemplate.Text = "Selecionar Template";
            this.buttonSelectTemplate.UseVisualStyleBackColor = true;
            this.buttonSelectTemplate.Click += new System.EventHandler(this.buttonSelectTemplate_Click);
            // 
            // buttonRemoveTemplate
            // 
            this.buttonRemoveTemplate.Location = new System.Drawing.Point(821, 132);
            this.buttonRemoveTemplate.Name = "buttonRemoveTemplate";
            this.buttonRemoveTemplate.Size = new System.Drawing.Size(176, 32);
            this.buttonRemoveTemplate.TabIndex = 20;
            this.buttonRemoveTemplate.Text = "Remover Template";
            this.buttonRemoveTemplate.UseVisualStyleBackColor = true;
            // 
            // openFileDialogTemplate
            // 
            this.openFileDialogTemplate.FileName = "openFileDialogTemplate";
            // 
            // radioButtonISO
            // 
            this.radioButtonISO.AutoSize = true;
            this.radioButtonISO.Location = new System.Drawing.Point(35, 178);
            this.radioButtonISO.Name = "radioButtonISO";
            this.radioButtonISO.Size = new System.Drawing.Size(52, 21);
            this.radioButtonISO.TabIndex = 21;
            this.radioButtonISO.TabStop = true;
            this.radioButtonISO.Text = "ISO";
            this.radioButtonISO.UseVisualStyleBackColor = true;
            this.radioButtonISO.CheckedChanged += new System.EventHandler(this.radioButtonISO_CheckedChanged);
            // 
            // Instance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.radioButtonISO);
            this.Controls.Add(this.buttonRemoveTemplate);
            this.Controls.Add(this.buttonSelectTemplate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonCreateTemplate);
            this.Controls.Add(this.textBoxTemplateName);
            this.Controls.Add(this.radioButtonVolume);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxNetwork);
            this.Controls.Add(this.comboBoxFlavor);
            this.Controls.Add(this.comboBoxVolume);
            this.Controls.Add(this.comboBoxImages);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelISO);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Instance";
            this.Text = "Instance";
            this.Load += new System.EventHandler(this.Instance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelISO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.ComboBox comboBoxImages;
        private System.Windows.Forms.ComboBox comboBoxVolume;
        private System.Windows.Forms.ComboBox comboBoxFlavor;
        private System.Windows.Forms.ComboBox comboBoxNetwork;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonVolume;
        private System.Windows.Forms.TextBox textBoxTemplateName;
        private System.Windows.Forms.Button buttonCreateTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSelectTemplate;
        private System.Windows.Forms.Button buttonRemoveTemplate;
        private System.Windows.Forms.OpenFileDialog openFileDialogTemplate;
        private System.Windows.Forms.RadioButton radioButtonISO;
    }
}