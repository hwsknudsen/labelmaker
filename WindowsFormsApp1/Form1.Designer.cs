namespace WindowsFormsApp1
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
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelScaleWeight = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownPrintQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonRePrint = new System.Windows.Forms.Button();
            this.textBoxOld = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrintQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMain
            // 
            this.textBoxMain.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMain.Location = new System.Drawing.Point(206, 15);
            this.textBoxMain.MaxLength = 8;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(302, 53);
            this.textBoxMain.TabIndex = 0;
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(547, 15);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(146, 56);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(87, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 344);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(109, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 383);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Reading For Print";
            // 
            // labelScaleWeight
            // 
            this.labelScaleWeight.AutoSize = true;
            this.labelScaleWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScaleWeight.Location = new System.Drawing.Point(340, 188);
            this.labelScaleWeight.Name = "labelScaleWeight";
            this.labelScaleWeight.Size = new System.Drawing.Size(87, 31);
            this.labelScaleWeight.TabIndex = 6;
            this.labelScaleWeight.Text = "99.90";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWeight.Location = new System.Drawing.Point(824, 174);
            this.textBoxWeight.MaxLength = 5;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(112, 53);
            this.textBoxWeight.TabIndex = 4;
            this.textBoxWeight.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Viking Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Print Quantity";
            // 
            // numericUpDownPrintQuantity
            // 
            this.numericUpDownPrintQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrintQuantity.Location = new System.Drawing.Point(206, 133);
            this.numericUpDownPrintQuantity.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownPrintQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrintQuantity.Name = "numericUpDownPrintQuantity";
            this.numericUpDownPrintQuantity.Size = new System.Drawing.Size(61, 38);
            this.numericUpDownPrintQuantity.TabIndex = 3;
            this.numericUpDownPrintQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(510, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 31);
            this.label4.TabIndex = 15;
            this.label4.Text = "Custom Weight Overide";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "Last Code";
            // 
            // buttonRePrint
            // 
            this.buttonRePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRePrint.Location = new System.Drawing.Point(547, 74);
            this.buttonRePrint.Name = "buttonRePrint";
            this.buttonRePrint.Size = new System.Drawing.Size(209, 56);
            this.buttonRePrint.TabIndex = 2;
            this.buttonRePrint.Text = "RePrint";
            this.buttonRePrint.UseVisualStyleBackColor = true;
            this.buttonRePrint.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBoxOld
            // 
            this.textBoxOld.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOld.Location = new System.Drawing.Point(206, 74);
            this.textBoxOld.MaxLength = 8;
            this.textBoxOld.Name = "textBoxOld";
            this.textBoxOld.ReadOnly = true;
            this.textBoxOld.Size = new System.Drawing.Size(302, 53);
            this.textBoxOld.TabIndex = 16;
            this.textBoxOld.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 633);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonRePrint);
            this.Controls.Add(this.textBoxOld);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownPrintQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.labelScaleWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrintQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelScaleWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownPrintQuantity;
        private System.Windows.Forms.Label label4;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonRePrint;
        private System.Windows.Forms.TextBox textBoxOld;
    }
}

