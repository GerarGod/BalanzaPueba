namespace PruebaLectura
{
    partial class FormBalanza
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTara = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPesoTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHandshake = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerialPortBitsStopBits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSerialPortParity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBitsDatos = new System.Windows.Forms.TextBox();
            this.txtBaudios = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPuertoSerie = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTara
            // 
            this.txtTara.Enabled = false;
            this.txtTara.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTara.Location = new System.Drawing.Point(206, 61);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(69, 25);
            this.txtTara.TabIndex = 35;
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(221, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Tara";
            // 
            // txtPesoTotal
            // 
            this.txtPesoTotal.Enabled = false;
            this.txtPesoTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPesoTotal.Location = new System.Drawing.Point(291, 61);
            this.txtPesoTotal.Name = "txtPesoTotal";
            this.txtPesoTotal.Size = new System.Drawing.Size(69, 25);
            this.txtPesoTotal.TabIndex = 33;
            this.txtPesoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(288, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Peso Total";
            // 
            // txtPeso
            // 
            this.txtPeso.Enabled = false;
            this.txtPeso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPeso.Location = new System.Drawing.Point(128, 61);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(69, 25);
            this.txtPeso.TabIndex = 31;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(144, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Peso";
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
            this.cmdStart.Location = new System.Drawing.Point(12, 12);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(99, 90);
            this.cmdStart.TabIndex = 29;
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
            this.cmdStop.Location = new System.Drawing.Point(396, 12);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(99, 90);
            this.cmdStop.TabIndex = 28;
            this.cmdStop.Text = "Finaliza Lectura Balanza";
            this.cmdStop.UseVisualStyleBackColor = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHandshake);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSerialPortBitsStopBits);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSerialPortParity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBitsDatos);
            this.groupBox1.Controls.Add(this.txtBaudios);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtPuertoSerie);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(501, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 231);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puerto";
            // 
            // txtHandshake
            // 
            this.txtHandshake.Location = new System.Drawing.Point(230, 198);
            this.txtHandshake.Name = "txtHandshake";
            this.txtHandshake.Size = new System.Drawing.Size(139, 29);
            this.txtHandshake.TabIndex = 20;
            this.txtHandshake.Text = "0";
            this.txtHandshake.TextChanged += new System.EventHandler(this.txtHandshake_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Handshake";
            // 
            // txtSerialPortBitsStopBits
            // 
            this.txtSerialPortBitsStopBits.Location = new System.Drawing.Point(230, 163);
            this.txtSerialPortBitsStopBits.Name = "txtSerialPortBitsStopBits";
            this.txtSerialPortBitsStopBits.Size = new System.Drawing.Size(102, 29);
            this.txtSerialPortBitsStopBits.TabIndex = 18;
            this.txtSerialPortBitsStopBits.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "serialPortBitsStopBits";
            // 
            // txtSerialPortParity
            // 
            this.txtSerialPortParity.Location = new System.Drawing.Point(230, 129);
            this.txtSerialPortParity.Name = "txtSerialPortParity";
            this.txtSerialPortParity.Size = new System.Drawing.Size(63, 29);
            this.txtSerialPortParity.TabIndex = 16;
            this.txtSerialPortParity.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "serialPortParity";
            // 
            // txtBitsDatos
            // 
            this.txtBitsDatos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBitsDatos.Location = new System.Drawing.Point(93, 91);
            this.txtBitsDatos.MaxLength = 1;
            this.txtBitsDatos.Name = "txtBitsDatos";
            this.txtBitsDatos.Size = new System.Drawing.Size(78, 25);
            this.txtBitsDatos.TabIndex = 14;
            this.txtBitsDatos.Text = "8";
            this.txtBitsDatos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBaudios
            // 
            this.txtBaudios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBaudios.Location = new System.Drawing.Point(93, 59);
            this.txtBaudios.MaxLength = 6;
            this.txtBaudios.Name = "txtBaudios";
            this.txtBaudios.Size = new System.Drawing.Size(78, 25);
            this.txtBaudios.TabIndex = 13;
            this.txtBaudios.Text = "9600";
            this.txtBaudios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(11, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "Bits";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(11, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Baudios";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(11, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "Nro Puerto:";
            // 
            // txtPuertoSerie
            // 
            this.txtPuertoSerie.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPuertoSerie.Location = new System.Drawing.Point(93, 28);
            this.txtPuertoSerie.MaxLength = 6;
            this.txtPuertoSerie.Name = "txtPuertoSerie";
            this.txtPuertoSerie.Size = new System.Drawing.Size(78, 25);
            this.txtPuertoSerie.TabIndex = 4;
            this.txtPuertoSerie.Text = "COM2";
            this.txtPuertoSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormBalanza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPesoTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.cmdStop);
            this.Name = "FormBalanza";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormBalanza_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTara;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPesoTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBitsDatos;
        private System.Windows.Forms.TextBox txtBaudios;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPuertoSerie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerialPortParity;
        private System.Windows.Forms.TextBox txtSerialPortBitsStopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHandshake;
        private System.Windows.Forms.Label label6;
    }
}

