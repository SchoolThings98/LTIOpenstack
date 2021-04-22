namespace LTIOpenstackProject
{
    partial class FormProjects
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonVolumes = new System.Windows.Forms.Button();
            this.buttonCreateInstance = new System.Windows.Forms.Button();
            this.buttonAccessInstance = new System.Windows.Forms.Button();
            this.buttonRemoveInstance = new System.Windows.Forms.Button();
            this.buttonImages = new System.Windows.Forms.Button();
            this.buttonNetwork = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDNS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 22);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(362, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de projetos";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(483, 20);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(92, 22);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Selecionar";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 88);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(252, 147);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Instancias:";
            // 
            // buttonVolumes
            // 
            this.buttonVolumes.Location = new System.Drawing.Point(12, 298);
            this.buttonVolumes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonVolumes.Name = "buttonVolumes";
            this.buttonVolumes.Size = new System.Drawing.Size(66, 27);
            this.buttonVolumes.TabIndex = 5;
            this.buttonVolumes.Text = "Volumes";
            this.buttonVolumes.UseVisualStyleBackColor = true;
            this.buttonVolumes.Click += new System.EventHandler(this.buttonVolumes_Click);
            // 
            // buttonCreateInstance
            // 
            this.buttonCreateInstance.Location = new System.Drawing.Point(285, 88);
            this.buttonCreateInstance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCreateInstance.Name = "buttonCreateInstance";
            this.buttonCreateInstance.Size = new System.Drawing.Size(99, 24);
            this.buttonCreateInstance.TabIndex = 6;
            this.buttonCreateInstance.Text = "Criar Instancia";
            this.buttonCreateInstance.UseVisualStyleBackColor = true;
            this.buttonCreateInstance.Click += new System.EventHandler(this.buttonCreateInstance_Click);
            // 
            // buttonAccessInstance
            // 
            this.buttonAccessInstance.Location = new System.Drawing.Point(285, 163);
            this.buttonAccessInstance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAccessInstance.Name = "buttonAccessInstance";
            this.buttonAccessInstance.Size = new System.Drawing.Size(99, 24);
            this.buttonAccessInstance.TabIndex = 7;
            this.buttonAccessInstance.Text = "Aceder à instacia";
            this.buttonAccessInstance.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveInstance
            // 
            this.buttonRemoveInstance.Location = new System.Drawing.Point(285, 210);
            this.buttonRemoveInstance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRemoveInstance.Name = "buttonRemoveInstance";
            this.buttonRemoveInstance.Size = new System.Drawing.Size(99, 24);
            this.buttonRemoveInstance.TabIndex = 8;
            this.buttonRemoveInstance.Text = "Remover Instance";
            this.buttonRemoveInstance.UseVisualStyleBackColor = true;
            this.buttonRemoveInstance.Click += new System.EventHandler(this.buttonRemoveInstance_Click);
            // 
            // buttonImages
            // 
            this.buttonImages.Location = new System.Drawing.Point(98, 298);
            this.buttonImages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonImages.Name = "buttonImages";
            this.buttonImages.Size = new System.Drawing.Size(70, 27);
            this.buttonImages.TabIndex = 9;
            this.buttonImages.Text = "Imagens";
            this.buttonImages.UseVisualStyleBackColor = true;
            this.buttonImages.Click += new System.EventHandler(this.buttonImages_Click);
            // 
            // buttonNetwork
            // 
            this.buttonNetwork.Location = new System.Drawing.Point(195, 297);
            this.buttonNetwork.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNetwork.Name = "buttonNetwork";
            this.buttonNetwork.Size = new System.Drawing.Size(68, 27);
            this.buttonNetwork.TabIndex = 10;
            this.buttonNetwork.Text = "Redes";
            this.buttonNetwork.UseVisualStyleBackColor = true;
            this.buttonNetwork.Click += new System.EventHandler(this.buttonNetwork_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(443, 94);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(132, 231);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Informação sobre a Instancia:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(285, 124);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(94, 27);
            this.buttonEdit.TabIndex = 13;
            this.buttonEdit.Text = "Editar Instancia";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDNS
            // 
            this.buttonDNS.Location = new System.Drawing.Point(285, 297);
            this.buttonDNS.Name = "buttonDNS";
            this.buttonDNS.Size = new System.Drawing.Size(94, 28);
            this.buttonDNS.TabIndex = 14;
            this.buttonDNS.Text = "Serviço DNS";
            this.buttonDNS.UseVisualStyleBackColor = true;
            this.buttonDNS.Click += new System.EventHandler(this.buttonDNS_Click);
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonDNS);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonNetwork);
            this.Controls.Add(this.buttonImages);
            this.Controls.Add(this.buttonRemoveInstance);
            this.Controls.Add(this.buttonAccessInstance);
            this.Controls.Add(this.buttonCreateInstance);
            this.Controls.Add(this.buttonVolumes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormProjects";
            this.Text = "FormProjects";
            this.Load += new System.EventHandler(this.FormProjects_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonVolumes;
        private System.Windows.Forms.Button buttonCreateInstance;
        private System.Windows.Forms.Button buttonAccessInstance;
        private System.Windows.Forms.Button buttonRemoveInstance;
        private System.Windows.Forms.Button buttonImages;
        private System.Windows.Forms.Button buttonNetwork;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDNS;
    }
}