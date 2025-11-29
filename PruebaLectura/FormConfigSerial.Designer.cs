namespace PruebaLectura
{
    partial class FormConfigSerial
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
            this.cmdDetectar = new System.Windows.Forms.Button();
            this.lstResultados = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdGuardarConfig = new System.Windows.Forms.Button();
            this.txtReadTimeout = new System.Windows.Forms.TextBox();
            this.txtNewLine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEncoding = new System.Windows.Forms.TextBox();
            this.txtHandshake = new System.Windows.Forms.TextBox();
            this.txtStopBits = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTara = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPesoTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstLectura = new System.Windows.Forms.ListBox();
            this.cmdConfigGuardada = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDetectar
            // 
            this.cmdDetectar.Location = new System.Drawing.Point(15, 99);
            this.cmdDetectar.Name = "cmdDetectar";
            this.cmdDetectar.Size = new System.Drawing.Size(171, 30);
            this.cmdDetectar.TabIndex = 2;
            this.cmdDetectar.Text = "Detectar Config.";
            this.cmdDetectar.UseVisualStyleBackColor = true;
            this.cmdDetectar.Click += new System.EventHandler(this.cmdDetectar_Click);
            // 
            // lstResultados
            // 
            this.lstResultados.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResultados.FormattingEnabled = true;
            this.lstResultados.ItemHeight = 16;
            this.lstResultados.Location = new System.Drawing.Point(205, 54);
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.Size = new System.Drawing.Size(571, 388);
            this.lstResultados.TabIndex = 3;
            this.lstResultados.SelectedIndexChanged += new System.EventHandler(this.lstResultados_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resultados";
            // 
            // cmbPuertos
            // 
            this.cmbPuertos.FormattingEnabled = true;
            this.cmbPuertos.Location = new System.Drawing.Point(106, 26);
            this.cmbPuertos.Name = "cmbPuertos";
            this.cmbPuertos.Size = new System.Drawing.Size(80, 29);
            this.cmbPuertos.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdConfigGuardada);
            this.groupBox1.Controls.Add(this.cmdGuardarConfig);
            this.groupBox1.Controls.Add(this.txtReadTimeout);
            this.groupBox1.Controls.Add(this.cmbPuertos);
            this.groupBox1.Controls.Add(this.txtNewLine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lstResultados);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmdDetectar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtEncoding);
            this.groupBox1.Controls.Add(this.txtHandshake);
            this.groupBox1.Controls.Add(this.txtStopBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtParity);
            this.groupBox1.Controls.Add(this.txtDataBits);
            this.groupBox1.Controls.Add(this.txtBaudRate);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 448);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puerto Configuracion";
            // 
            // cmdGuardarConfig
            // 
            this.cmdGuardarConfig.Location = new System.Drawing.Point(14, 394);
            this.cmdGuardarConfig.Name = "cmdGuardarConfig";
            this.cmdGuardarConfig.Size = new System.Drawing.Size(171, 40);
            this.cmdGuardarConfig.TabIndex = 27;
            this.cmdGuardarConfig.Text = "Guardar Config.";
            this.cmdGuardarConfig.UseVisualStyleBackColor = true;
            this.cmdGuardarConfig.Click += new System.EventHandler(this.cmdGuardarConfig_Click);
            // 
            // txtReadTimeout
            // 
            this.txtReadTimeout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtReadTimeout.Location = new System.Drawing.Point(105, 363);
            this.txtReadTimeout.MaxLength = 1;
            this.txtReadTimeout.Name = "txtReadTimeout";
            this.txtReadTimeout.Size = new System.Drawing.Size(80, 25);
            this.txtReadTimeout.TabIndex = 26;
            this.txtReadTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewLine
            // 
            this.txtNewLine.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNewLine.Location = new System.Drawing.Point(105, 331);
            this.txtNewLine.MaxLength = 6;
            this.txtNewLine.Name = "txtNewLine";
            this.txtNewLine.Size = new System.Drawing.Size(80, 25);
            this.txtNewLine.TabIndex = 25;
            this.txtNewLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(11, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "ReadTimeout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(11, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "txtNewLine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(12, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Encoding";
            // 
            // txtEncoding
            // 
            this.txtEncoding.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtEncoding.Location = new System.Drawing.Point(105, 300);
            this.txtEncoding.MaxLength = 6;
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(80, 25);
            this.txtEncoding.TabIndex = 21;
            this.txtEncoding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHandshake
            // 
            this.txtHandshake.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtHandshake.Location = new System.Drawing.Point(105, 269);
            this.txtHandshake.MaxLength = 1;
            this.txtHandshake.Name = "txtHandshake";
            this.txtHandshake.Size = new System.Drawing.Size(80, 25);
            this.txtHandshake.TabIndex = 20;
            this.txtHandshake.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStopBits
            // 
            this.txtStopBits.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStopBits.Location = new System.Drawing.Point(105, 237);
            this.txtStopBits.MaxLength = 6;
            this.txtStopBits.Name = "txtStopBits";
            this.txtStopBits.Size = new System.Drawing.Size(80, 25);
            this.txtStopBits.TabIndex = 19;
            this.txtStopBits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(11, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Handshake";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "StopBits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(11, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Parity";
            // 
            // txtParity
            // 
            this.txtParity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtParity.Location = new System.Drawing.Point(105, 206);
            this.txtParity.MaxLength = 6;
            this.txtParity.Name = "txtParity";
            this.txtParity.Size = new System.Drawing.Size(80, 25);
            this.txtParity.TabIndex = 15;
            this.txtParity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDataBits
            // 
            this.txtDataBits.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDataBits.Location = new System.Drawing.Point(105, 175);
            this.txtDataBits.MaxLength = 1;
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Size = new System.Drawing.Size(80, 25);
            this.txtDataBits.TabIndex = 14;
            this.txtDataBits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBaudRate.Location = new System.Drawing.Point(105, 143);
            this.txtBaudRate.MaxLength = 6;
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(80, 25);
            this.txtBaudRate.TabIndex = 13;
            this.txtBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(11, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "DataBits";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(11, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "BaudRate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(12, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "PortName";
            // 
            // txtTara
            // 
            this.txtTara.Enabled = false;
            this.txtTara.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTara.Location = new System.Drawing.Point(93, 118);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(69, 25);
            this.txtTara.TabIndex = 45;
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(108, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 17);
            this.label11.TabIndex = 44;
            this.label11.Text = "Tara";
            // 
            // txtPesoTotal
            // 
            this.txtPesoTotal.Enabled = false;
            this.txtPesoTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPesoTotal.Location = new System.Drawing.Point(178, 118);
            this.txtPesoTotal.Name = "txtPesoTotal";
            this.txtPesoTotal.Size = new System.Drawing.Size(69, 25);
            this.txtPesoTotal.TabIndex = 43;
            this.txtPesoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(175, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Peso Total";
            // 
            // txtPeso
            // 
            this.txtPeso.Enabled = false;
            this.txtPeso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPeso.Location = new System.Drawing.Point(15, 118);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(69, 25);
            this.txtPeso.TabIndex = 41;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(31, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "Peso";
            // 
            // cmdStart
            // 
            this.cmdStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(84)))), ((int)(((byte)(148)))));
            this.cmdStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(37)))));
            this.cmdStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(158)))), ((int)(((byte)(81)))));
            this.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cmdStart.ForeColor = System.Drawing.Color.White;
            this.cmdStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdStart.Location = new System.Drawing.Point(16, 28);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(99, 65);
            this.cmdStart.TabIndex = 39;
            this.cmdStart.Text = "Inicia Lectura Balanza";
            this.cmdStart.UseVisualStyleBackColor = false;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(84)))), ((int)(((byte)(148)))));
            this.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdStop.Enabled = false;
            this.cmdStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(37)))));
            this.cmdStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(158)))), ((int)(((byte)(81)))));
            this.cmdStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cmdStop.ForeColor = System.Drawing.Color.White;
            this.cmdStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdStop.Location = new System.Drawing.Point(157, 28);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(99, 65);
            this.cmdStop.TabIndex = 38;
            this.cmdStop.Text = "Finaliza Lectura Balanza";
            this.cmdStop.UseVisualStyleBackColor = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstLectura);
            this.groupBox2.Controls.Add(this.cmdStart);
            this.groupBox2.Controls.Add(this.txtTara);
            this.groupBox2.Controls.Add(this.cmdStop);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPesoTotal);
            this.groupBox2.Controls.Add(this.txtPeso);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Location = new System.Drawing.Point(811, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 439);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Lesctura";
            // 
            // lstLectura
            // 
            this.lstLectura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLectura.FormattingEnabled = true;
            this.lstLectura.ItemHeight = 16;
            this.lstLectura.Location = new System.Drawing.Point(13, 149);
            this.lstLectura.Name = "lstLectura";
            this.lstLectura.Size = new System.Drawing.Size(243, 276);
            this.lstLectura.TabIndex = 46;
            // 
            // cmdConfigGuardada
            // 
            this.cmdConfigGuardada.Location = new System.Drawing.Point(15, 61);
            this.cmdConfigGuardada.Name = "cmdConfigGuardada";
            this.cmdConfigGuardada.Size = new System.Drawing.Size(171, 30);
            this.cmdConfigGuardada.TabIndex = 28;
            this.cmdConfigGuardada.Tag = "";
            this.cmdConfigGuardada.Text = "Config. Guardada";
            this.cmdConfigGuardada.UseVisualStyleBackColor = true;
            this.cmdConfigGuardada.Click += new System.EventHandler(this.cmdConfigGuardada_Click);
            // 
            // FormConfigSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 472);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormConfigSerial";
            this.Text = "Puerto Serie";
            this.Load += new System.EventHandler(this.FormConfigSerial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdDetectar;
        private System.Windows.Forms.ListBox lstResultados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPuertos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtReadTimeout;
        private System.Windows.Forms.TextBox txtNewLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEncoding;
        private System.Windows.Forms.TextBox txtHandshake;
        private System.Windows.Forms.TextBox txtStopBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.Button cmdGuardarConfig;
        private System.Windows.Forms.TextBox txtTara;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPesoTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstLectura;
        private System.Windows.Forms.Button cmdConfigGuardada;
    }
}