namespace LTIOpenstackProject
{
    partial class FormDNS
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnCreateZone = new System.Windows.Forms.Button();
            this.btnUpdateZone = new System.Windows.Forms.Button();
            this.btnDeleteZone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista das Zonas";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 173);
            this.listBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Informação da Zona";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(357, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(167, 173);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnCreateZone
            // 
            this.btnCreateZone.Location = new System.Drawing.Point(223, 49);
            this.btnCreateZone.Name = "btnCreateZone";
            this.btnCreateZone.Size = new System.Drawing.Size(107, 23);
            this.btnCreateZone.TabIndex = 4;
            this.btnCreateZone.Text = "Criar Zona";
            this.btnCreateZone.UseVisualStyleBackColor = true;
            this.btnCreateZone.Click += new System.EventHandler(this.btnCreateZone_Click);
            // 
            // btnUpdateZone
            // 
            this.btnUpdateZone.Location = new System.Drawing.Point(223, 127);
            this.btnUpdateZone.Name = "btnUpdateZone";
            this.btnUpdateZone.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateZone.TabIndex = 5;
            this.btnUpdateZone.Text = "Editar Zona";
            this.btnUpdateZone.UseVisualStyleBackColor = true;
            this.btnUpdateZone.Click += new System.EventHandler(this.btnUpdateZone_Click);
            // 
            // btnDeleteZone
            // 
            this.btnDeleteZone.Location = new System.Drawing.Point(223, 199);
            this.btnDeleteZone.Name = "btnDeleteZone";
            this.btnDeleteZone.Size = new System.Drawing.Size(107, 23);
            this.btnDeleteZone.TabIndex = 6;
            this.btnDeleteZone.Text = "Apagar Zona";
            this.btnDeleteZone.UseVisualStyleBackColor = true;
            this.btnDeleteZone.Click += new System.EventHandler(this.btnDeleteZone_Click);
            // 
            // FormDNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 379);
            this.Controls.Add(this.btnDeleteZone);
            this.Controls.Add(this.btnUpdateZone);
            this.Controls.Add(this.btnCreateZone);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormDNS";
            this.Text = "FormDNS";
            this.Load += new System.EventHandler(this.FormDNS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnCreateZone;
        private System.Windows.Forms.Button btnUpdateZone;
        private System.Windows.Forms.Button btnDeleteZone;
    }
}