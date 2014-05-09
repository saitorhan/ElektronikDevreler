namespace Program
{
    partial class Form1
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
            this.btnDiyotlar = new System.Windows.Forms.Button();
            this.btnTransistor_DC = new System.Windows.Forms.Button();
            this.btnOzel_Diyot = new System.Windows.Forms.Button();
            this.btnDiyot_Uygulama = new System.Windows.Forms.Button();
            this.btnTransistor_AC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDiyotlar
            // 
            this.btnDiyotlar.Location = new System.Drawing.Point(12, 12);
            this.btnDiyotlar.Name = "btnDiyotlar";
            this.btnDiyotlar.Size = new System.Drawing.Size(129, 36);
            this.btnDiyotlar.TabIndex = 0;
            this.btnDiyotlar.Text = "Diyotlar";
            this.btnDiyotlar.UseVisualStyleBackColor = true;
            this.btnDiyotlar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTransistor_DC
            // 
            this.btnTransistor_DC.Location = new System.Drawing.Point(146, 54);
            this.btnTransistor_DC.Name = "btnTransistor_DC";
            this.btnTransistor_DC.Size = new System.Drawing.Size(129, 36);
            this.btnTransistor_DC.TabIndex = 1;
            this.btnTransistor_DC.Text = "Transistörlerin DC Analizi";
            this.btnTransistor_DC.UseVisualStyleBackColor = true;
            this.btnTransistor_DC.Click += new System.EventHandler(this.btnTransistor_DC_Click);
            // 
            // btnOzel_Diyot
            // 
            this.btnOzel_Diyot.Location = new System.Drawing.Point(12, 54);
            this.btnOzel_Diyot.Name = "btnOzel_Diyot";
            this.btnOzel_Diyot.Size = new System.Drawing.Size(129, 36);
            this.btnOzel_Diyot.TabIndex = 3;
            this.btnOzel_Diyot.Text = "Özel Diyotlar";
            this.btnOzel_Diyot.UseVisualStyleBackColor = true;
            this.btnOzel_Diyot.Click += new System.EventHandler(this.btnOzel_Diyot_Click);
            // 
            // btnDiyot_Uygulama
            // 
            this.btnDiyot_Uygulama.Location = new System.Drawing.Point(147, 12);
            this.btnDiyot_Uygulama.Name = "btnDiyot_Uygulama";
            this.btnDiyot_Uygulama.Size = new System.Drawing.Size(129, 36);
            this.btnDiyot_Uygulama.TabIndex = 4;
            this.btnDiyot_Uygulama.Text = "Diyot Uygulamaları";
            this.btnDiyot_Uygulama.UseVisualStyleBackColor = true;
            this.btnDiyot_Uygulama.Click += new System.EventHandler(this.btnDiyot_Uygulama_Click);
            // 
            // btnTransistor_AC
            // 
            this.btnTransistor_AC.Location = new System.Drawing.Point(12, 96);
            this.btnTransistor_AC.Name = "btnTransistor_AC";
            this.btnTransistor_AC.Size = new System.Drawing.Size(129, 36);
            this.btnTransistor_AC.TabIndex = 5;
            this.btnTransistor_AC.Text = "Transistörlerin AC Analizi";
            this.btnTransistor_AC.UseVisualStyleBackColor = true;
            this.btnTransistor_AC.Click += new System.EventHandler(this.btnTransistor_AC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 144);
            this.Controls.Add(this.btnTransistor_AC);
            this.Controls.Add(this.btnDiyot_Uygulama);
            this.Controls.Add(this.btnOzel_Diyot);
            this.Controls.Add(this.btnTransistor_DC);
            this.Controls.Add(this.btnDiyotlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elekronik Devreler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDiyotlar;
        private System.Windows.Forms.Button btnTransistor_DC;
        private System.Windows.Forms.Button btnOzel_Diyot;
        private System.Windows.Forms.Button btnDiyot_Uygulama;
        private System.Windows.Forms.Button btnTransistor_AC;
    }
}

