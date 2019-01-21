namespace obrabotka
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
            this.BasicImage = new System.Windows.Forms.PictureBox();
            this.newImage = new System.Windows.Forms.PictureBox();
            this.Upload = new System.Windows.Forms.Button();
            this.Enlightenment = new System.Windows.Forms.Button();
            this.PixelBar = new System.Windows.Forms.TrackBar();
            this.PixelBar_value = new System.Windows.Forms.Label();
            this.Binarization = new System.Windows.Forms.Button();
            this.Coloring = new System.Windows.Forms.Button();
            this.Quantization = new System.Windows.Forms.Button();
            this.Gamma = new System.Windows.Forms.Button();
            this.High_frequency = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Binarization_two = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Continue = new System.Windows.Forms.Button();
            this.axis = new System.Windows.Forms.ComboBox();
            this.Rotation = new System.Windows.Forms.Button();
            this.Scailing = new System.Windows.Forms.Button();
            this.ScailingConst = new System.Windows.Forms.TextBox();
            this.Kirsh = new System.Windows.Forms.Button();
            this.Binar = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.BasicImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // BasicImage
            // 
            this.BasicImage.Location = new System.Drawing.Point(210, 12);
            this.BasicImage.Name = "BasicImage";
            this.BasicImage.Size = new System.Drawing.Size(250, 410);
            this.BasicImage.TabIndex = 0;
            this.BasicImage.TabStop = false;
            this.BasicImage.Paint += new System.Windows.Forms.PaintEventHandler(this.BasicImage_Paint);
            this.BasicImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasicImage_MouseDown);
            this.BasicImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BasicImage_MouseMove);
            this.BasicImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BasicImage_MouseUp);
            // 
            // newImage
            // 
            this.newImage.Location = new System.Drawing.Point(506, 12);
            this.newImage.Name = "newImage";
            this.newImage.Size = new System.Drawing.Size(250, 410);
            this.newImage.TabIndex = 1;
            this.newImage.TabStop = false;
            // 
            // Upload
            // 
            this.Upload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Upload.Location = new System.Drawing.Point(12, 12);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(114, 32);
            this.Upload.TabIndex = 2;
            this.Upload.Text = "Загрузить";
            this.Upload.UseVisualStyleBackColor = false;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // Enlightenment
            // 
            this.Enlightenment.Location = new System.Drawing.Point(12, 57);
            this.Enlightenment.Name = "Enlightenment";
            this.Enlightenment.Size = new System.Drawing.Size(141, 32);
            this.Enlightenment.TabIndex = 3;
            this.Enlightenment.Text = "Просветление";
            this.Enlightenment.UseVisualStyleBackColor = true;
            this.Enlightenment.Click += new System.EventHandler(this.Enlightenment_Click);
            // 
            // PixelBar
            // 
            this.PixelBar.LargeChange = 10;
            this.PixelBar.Location = new System.Drawing.Point(174, 449);
            this.PixelBar.Maximum = 255;
            this.PixelBar.Minimum = -255;
            this.PixelBar.Name = "PixelBar";
            this.PixelBar.Size = new System.Drawing.Size(634, 45);
            this.PixelBar.TabIndex = 4;
            this.PixelBar.Scroll += new System.EventHandler(this.PixelBar_Scroll);
            // 
            // PixelBar_value
            // 
            this.PixelBar_value.AutoSize = true;
            this.PixelBar_value.Location = new System.Drawing.Point(432, 433);
            this.PixelBar_value.Name = "PixelBar_value";
            this.PixelBar_value.Size = new System.Drawing.Size(114, 13);
            this.PixelBar_value.TabIndex = 5;
            this.PixelBar_value.Text = "Текущее значение: 0";
            // 
            // Binarization
            // 
            this.Binarization.Location = new System.Drawing.Point(12, 95);
            this.Binarization.Name = "Binarization";
            this.Binarization.Size = new System.Drawing.Size(141, 32);
            this.Binarization.TabIndex = 7;
            this.Binarization.Text = "Бинаризация";
            this.Binarization.UseVisualStyleBackColor = true;
            this.Binarization.Click += new System.EventHandler(this.Binarization_Click);
            // 
            // Coloring
            // 
            this.Coloring.Location = new System.Drawing.Point(12, 171);
            this.Coloring.Name = "Coloring";
            this.Coloring.Size = new System.Drawing.Size(141, 32);
            this.Coloring.TabIndex = 8;
            this.Coloring.Text = "Псевдораскрашивание";
            this.Coloring.UseVisualStyleBackColor = true;
            this.Coloring.Click += new System.EventHandler(this.Coloring_Click);
            // 
            // Quantization
            // 
            this.Quantization.Location = new System.Drawing.Point(12, 209);
            this.Quantization.Name = "Quantization";
            this.Quantization.Size = new System.Drawing.Size(141, 32);
            this.Quantization.TabIndex = 9;
            this.Quantization.Text = "Квантование";
            this.Quantization.UseVisualStyleBackColor = true;
            this.Quantization.Click += new System.EventHandler(this.Quantization_Click);
            // 
            // Gamma
            // 
            this.Gamma.Location = new System.Drawing.Point(12, 247);
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(141, 32);
            this.Gamma.TabIndex = 10;
            this.Gamma.Text = "Гамма-преобразование";
            this.Gamma.UseVisualStyleBackColor = true;
            this.Gamma.Click += new System.EventHandler(this.Gamma_Click);
            // 
            // High_frequency
            // 
            this.High_frequency.Location = new System.Drawing.Point(12, 285);
            this.High_frequency.Name = "High_frequency";
            this.High_frequency.Size = new System.Drawing.Size(141, 32);
            this.High_frequency.TabIndex = 11;
            this.High_frequency.Text = "Высокочастотный";
            this.High_frequency.UseVisualStyleBackColor = true;
            this.High_frequency.Click += new System.EventHandler(this.High_frequency_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 462);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 12;
            this.button1.Text = "0-0.16";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 13;
            this.button2.Text = "0.17-0.33";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(393, 462);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 32);
            this.button3.TabIndex = 14;
            this.button3.Text = "0.34-0.49";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(506, 462);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 32);
            this.button4.TabIndex = 15;
            this.button4.Text = "0.5-0.66";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(609, 462);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 32);
            this.button5.TabIndex = 16;
            this.button5.Text = "0.67-0.82";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(720, 462);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 32);
            this.button6.TabIndex = 17;
            this.button6.Text = "0.83-1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Binarization_two
            // 
            this.Binarization_two.Location = new System.Drawing.Point(12, 133);
            this.Binarization_two.Name = "Binarization_two";
            this.Binarization_two.Size = new System.Drawing.Size(141, 32);
            this.Binarization_two.TabIndex = 18;
            this.Binarization_two.Text = "Бинаризация[2]";
            this.Binarization_two.UseVisualStyleBackColor = true;
            this.Binarization_two.Click += new System.EventHandler(this.Binarization_two_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Save.Location = new System.Drawing.Point(12, 555);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(114, 32);
            this.Save.TabIndex = 19;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Continue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Continue.Location = new System.Drawing.Point(12, 517);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(114, 32);
            this.Continue.TabIndex = 20;
            this.Continue.Text = "Продолжить";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // axis
            // 
            this.axis.FormattingEnabled = true;
            this.axis.Items.AddRange(new object[] {
            "Центр",
            "Произвольная точка"});
            this.axis.Location = new System.Drawing.Point(263, 500);
            this.axis.Name = "axis";
            this.axis.Size = new System.Drawing.Size(162, 21);
            this.axis.TabIndex = 21;
            // 
            // Rotation
            // 
            this.Rotation.Location = new System.Drawing.Point(12, 349);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(141, 32);
            this.Rotation.TabIndex = 22;
            this.Rotation.Text = "Поворот";
            this.Rotation.UseVisualStyleBackColor = true;
            this.Rotation.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // Scailing
            // 
            this.Scailing.Location = new System.Drawing.Point(12, 390);
            this.Scailing.Name = "Scailing";
            this.Scailing.Size = new System.Drawing.Size(141, 32);
            this.Scailing.TabIndex = 23;
            this.Scailing.Text = "Масштабирование";
            this.Scailing.UseVisualStyleBackColor = true;
            this.Scailing.Click += new System.EventHandler(this.Scaling_Click);
            // 
            // ScailingConst
            // 
            this.ScailingConst.Location = new System.Drawing.Point(271, 436);
            this.ScailingConst.Name = "ScailingConst";
            this.ScailingConst.Size = new System.Drawing.Size(100, 20);
            this.ScailingConst.TabIndex = 24;
            // 
            // Kirsh
            // 
            this.Kirsh.Location = new System.Drawing.Point(12, 428);
            this.Kirsh.Name = "Kirsh";
            this.Kirsh.Size = new System.Drawing.Size(141, 32);
            this.Kirsh.TabIndex = 25;
            this.Kirsh.Text = "Оператор Кирша";
            this.Kirsh.UseVisualStyleBackColor = true;
            this.Kirsh.Click += new System.EventHandler(this.Kirsh_Click);
            // 
            // Binar
            // 
            this.Binar.Location = new System.Drawing.Point(12, 466);
            this.Binar.Name = "Binar";
            this.Binar.Size = new System.Drawing.Size(141, 32);
            this.Binar.TabIndex = 26;
            this.Binar.Text = "Бинаризация";
            this.Binar.UseVisualStyleBackColor = true;
            this.Binar.Click += new System.EventHandler(this.Binar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(340, 488);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 27;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(506, 488);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 599);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Binar);
            this.Controls.Add(this.Kirsh);
            this.Controls.Add(this.ScailingConst);
            this.Controls.Add(this.Scailing);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.axis);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Binarization_two);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.High_frequency);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.Quantization);
            this.Controls.Add(this.Coloring);
            this.Controls.Add(this.Binarization);
            this.Controls.Add(this.PixelBar_value);
            this.Controls.Add(this.PixelBar);
            this.Controls.Add(this.Enlightenment);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.newImage);
            this.Controls.Add(this.BasicImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.BasicImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PixelBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BasicImage;
        private System.Windows.Forms.PictureBox newImage;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button Enlightenment;
        private System.Windows.Forms.TrackBar PixelBar;
        private System.Windows.Forms.Label PixelBar_value;
        private System.Windows.Forms.Button Binarization;
        private System.Windows.Forms.Button Coloring;
        private System.Windows.Forms.Button Quantization;
        private System.Windows.Forms.Button Gamma;
        private System.Windows.Forms.Button High_frequency;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Binarization_two;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.ComboBox axis;
        private System.Windows.Forms.Button Rotation;
        private System.Windows.Forms.Button Scailing;
        private System.Windows.Forms.TextBox ScailingConst;
        private System.Windows.Forms.Button Kirsh;
        private System.Windows.Forms.Button Binar;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
    }
}

