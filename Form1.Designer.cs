namespace course
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.conbtn = new System.Windows.Forms.Button();
            this.serverbtn = new System.Windows.Forms.Button();
            this.routerbtn = new System.Windows.Forms.Button();
            this.btnPC = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.serverbtn);
            this.panel1.Controls.Add(this.routerbtn);
            this.panel1.Controls.Add(this.btnPC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(808, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 488);
            this.panel1.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 29);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.conbtn);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(146, 250);
            this.panel2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(2, 174);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(146, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "№ Элемента";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(2, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 4;
            // 
            // conbtn
            // 
            this.conbtn.Location = new System.Drawing.Point(2, 98);
            this.conbtn.Name = "conbtn";
            this.conbtn.Size = new System.Drawing.Size(146, 23);
            this.conbtn.TabIndex = 3;
            this.conbtn.Text = "Соеденить";
            this.conbtn.UseVisualStyleBackColor = true;
            this.conbtn.Click += new System.EventHandler(this.conbtn_Click);
            // 
            // serverbtn
            // 
            this.serverbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.serverbtn.Image = global::course.Properties.Resources.server;
            this.serverbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverbtn.Location = new System.Drawing.Point(0, 82);
            this.serverbtn.Name = "serverbtn";
            this.serverbtn.Size = new System.Drawing.Size(146, 41);
            this.serverbtn.TabIndex = 2;
            this.serverbtn.Text = "Server";
            this.serverbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.serverbtn.UseVisualStyleBackColor = true;
            this.serverbtn.Click += new System.EventHandler(this.serverbtn_Click);
            // 
            // routerbtn
            // 
            this.routerbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.routerbtn.Image = global::course.Properties.Resources.router;
            this.routerbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.routerbtn.Location = new System.Drawing.Point(0, 41);
            this.routerbtn.Name = "routerbtn";
            this.routerbtn.Size = new System.Drawing.Size(146, 41);
            this.routerbtn.TabIndex = 1;
            this.routerbtn.Text = "Router";
            this.routerbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.routerbtn.UseVisualStyleBackColor = true;
            this.routerbtn.Click += new System.EventHandler(this.routerbtn_Click);
            // 
            // btnPC
            // 
            this.btnPC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPC.Image = global::course.Properties.Resources.pc;
            this.btnPC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPC.Location = new System.Drawing.Point(0, 0);
            this.btnPC.Name = "btnPC";
            this.btnPC.Size = new System.Drawing.Size(146, 41);
            this.btnPC.TabIndex = 0;
            this.btnPC.Text = "PC";
            this.btnPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPC.UseVisualStyleBackColor = true;
            this.btnPC.Click += new System.EventHandler(this.btnPC_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 52);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(3, 75);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 17);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 488);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button serverbtn;
        private System.Windows.Forms.Button routerbtn;
        private System.Windows.Forms.Button btnPC;
        private System.Windows.Forms.Button conbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}

