namespace tp1
{
    partial class Form3
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
            this.btnAceptarForm3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDNIForm3 = new System.Windows.Forms.TextBox();
            this.txtCodigoForm3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptarForm3
            // 
            this.btnAceptarForm3.Location = new System.Drawing.Point(105, 269);
            this.btnAceptarForm3.Name = "btnAceptarForm3";
            this.btnAceptarForm3.Size = new System.Drawing.Size(110, 40);
            this.btnAceptarForm3.TabIndex = 0;
            this.btnAceptarForm3.Text = "Aceptar";
            this.btnAceptarForm3.UseVisualStyleBackColor = true;
            this.btnAceptarForm3.Click += new System.EventHandler(this.btnAceptarForm3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Codigo";
            // 
            // txtDNIForm3
            // 
            this.txtDNIForm3.Location = new System.Drawing.Point(105, 144);
            this.txtDNIForm3.Name = "txtDNIForm3";
            this.txtDNIForm3.Size = new System.Drawing.Size(100, 20);
            this.txtDNIForm3.TabIndex = 3;
            // 
            // txtCodigoForm3
            // 
            this.txtCodigoForm3.Location = new System.Drawing.Point(105, 205);
            this.txtCodigoForm3.Name = "txtCodigoForm3";
            this.txtCodigoForm3.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoForm3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 97);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(114, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "VERIFICACION";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCodigoForm3);
            this.Controls.Add(this.txtDNIForm3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptarForm3);
            this.Name = "Form3";
            this.Text = "Verificar registro";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptarForm3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDNIForm3;
        private System.Windows.Forms.TextBox txtCodigoForm3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}