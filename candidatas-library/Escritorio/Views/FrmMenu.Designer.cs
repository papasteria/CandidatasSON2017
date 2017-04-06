namespace Escritorio.Views
{
    partial class FrmMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMunicipio = new System.Windows.Forms.Button();
            this.btnCandidatas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMunicipio);
            this.groupBox1.Controls.Add(this.btnCandidatas);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 228);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elige la Categoría:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(511, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reportes";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MistyRose;
            this.button3.BackgroundImage = global::Escritorio.Properties.Resources.header3;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(473, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 141);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(314, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Municipio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Candidata";
            // 
            // btnMunicipio
            // 
            this.btnMunicipio.BackColor = System.Drawing.Color.MistyRose;
            this.btnMunicipio.BackgroundImage = global::Escritorio.Properties.Resources.mapason;
            this.btnMunicipio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMunicipio.Location = new System.Drawing.Point(278, 32);
            this.btnMunicipio.Name = "btnMunicipio";
            this.btnMunicipio.Size = new System.Drawing.Size(149, 141);
            this.btnMunicipio.TabIndex = 1;
            this.btnMunicipio.UseVisualStyleBackColor = false;
            this.btnMunicipio.Click += new System.EventHandler(this.btnMunicipio_Click);
            // 
            // btnCandidatas
            // 
            this.btnCandidatas.BackColor = System.Drawing.Color.MistyRose;
            this.btnCandidatas.BackgroundImage = global::Escritorio.Properties.Resources.Queenpersonavatar_reina_person_2828;
            this.btnCandidatas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCandidatas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCandidatas.Location = new System.Drawing.Point(85, 32);
            this.btnCandidatas.Name = "btnCandidatas";
            this.btnCandidatas.Size = new System.Drawing.Size(149, 141);
            this.btnCandidatas.TabIndex = 0;
            this.btnCandidatas.UseVisualStyleBackColor = false;
            this.btnCandidatas.Click += new System.EventHandler(this.btnCandidatas_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(731, 274);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMenu";
            this.Text = "Menu de Categorías";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMunicipio;
        private System.Windows.Forms.Button btnCandidatas;
    }
}