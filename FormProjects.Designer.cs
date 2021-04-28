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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 63);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(481, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de projetos";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(660, 63);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(123, 27);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Selecionar";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(15, 140);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(384, 228);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Instancias:";
            // 
            // buttonVolumes
            // 
            this.buttonVolumes.Location = new System.Drawing.Point(37, 416);
            this.buttonVolumes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVolumes.Name = "buttonVolumes";
            this.buttonVolumes.Size = new System.Drawing.Size(88, 33);
            this.buttonVolumes.TabIndex = 5;
            this.buttonVolumes.Text = "Volumes";
            this.buttonVolumes.UseVisualStyleBackColor = true;
            this.buttonVolumes.Click += new System.EventHandler(this.buttonVolumes_Click);
            // 
            // buttonCreateInstance
            // 
            this.buttonCreateInstance.Location = new System.Drawing.Point(418, 146);
            this.buttonCreateInstance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateInstance.Name = "buttonCreateInstance";
            this.buttonCreateInstance.Size = new System.Drawing.Size(132, 30);
            this.buttonCreateInstance.TabIndex = 6;
            this.buttonCreateInstance.Text = "Criar Instancia";
            this.buttonCreateInstance.UseVisualStyleBackColor = true;
            this.buttonCreateInstance.Click += new System.EventHandler(this.buttonCreateInstance_Click);
            // 
            // buttonAccessInstance
            // 
            this.buttonAccessInstance.Location = new System.Drawing.Point(418, 217);
            this.buttonAccessInstance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAccessInstance.Name = "buttonAccessInstance";
            this.buttonAccessInstance.Size = new System.Drawing.Size(132, 30);
            this.buttonAccessInstance.TabIndex = 7;
            this.buttonAccessInstance.Text = "Aceder à instacia";
            this.buttonAccessInstance.UseVisualStyleBackColor = true;
            this.buttonAccessInstance.Click += new System.EventHandler(this.buttonAccessInstance_Click);
            // 
            // buttonRemoveInstance
            // 
            this.buttonRemoveInstance.Location = new System.Drawing.Point(418, 251);
            this.buttonRemoveInstance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveInstance.Name = "buttonRemoveInstance";
            this.buttonRemoveInstance.Size = new System.Drawing.Size(132, 30);
            this.buttonRemoveInstance.TabIndex = 8;
            this.buttonRemoveInstance.Text = "Remover Instance";
            this.buttonRemoveInstance.UseVisualStyleBackColor = true;
            this.buttonRemoveInstance.Click += new System.EventHandler(this.buttonRemoveInstance_Click);
            // 
            // buttonImages
            // 
            this.buttonImages.Location = new System.Drawing.Point(172, 416);
            this.buttonImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImages.Name = "buttonImages";
            this.buttonImages.Size = new System.Drawing.Size(93, 33);
            this.buttonImages.TabIndex = 9;
            this.buttonImages.Text = "Imagens";
            this.buttonImages.UseVisualStyleBackColor = true;
            this.buttonImages.Click += new System.EventHandler(this.buttonImages_Click);
            // 
            // buttonNetwork
            // 
            this.buttonNetwork.Location = new System.Drawing.Point(308, 416);
            this.buttonNetwork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNetwork.Name = "buttonNetwork";
            this.buttonNetwork.Size = new System.Drawing.Size(91, 33);
            this.buttonNetwork.TabIndex = 10;
            this.buttonNetwork.Text = "Redes";
            this.buttonNetwork.UseVisualStyleBackColor = true;
            this.buttonNetwork.Click += new System.EventHandler(this.buttonNetwork_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(626, 140);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(175, 310);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Informação sobre a Instancia:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(418, 180);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(132, 33);
            this.buttonEdit.TabIndex = 13;
            this.buttonEdit.Text = "Editar Instancia";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDNS
            // 
            this.buttonDNS.Location = new System.Drawing.Point(464, 416);
            this.buttonDNS.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDNS.Name = "buttonDNS";
            this.buttonDNS.Size = new System.Drawing.Size(125, 34);
            this.buttonDNS.TabIndex = 14;
            this.buttonDNS.Text = "Serviço DNS";
            this.buttonDNS.UseVisualStyleBackColor = true;
            this.buttonDNS.Click += new System.EventHandler(this.buttonDNS_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(362, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(132, 32);
            this.buttonLogout.TabIndex = 15;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(418, 286);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(132, 31);
            this.buttonStart.TabIndex = 16;
            this.buttonStart.Text = "Ligar Vm";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(418, 323);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(132, 28);
            this.buttonStop.TabIndex = 17;
            this.buttonStop.Text = "Desligar VM";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 510);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonLogout);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
    }
}