namespace windows
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.pctTablero = new System.Windows.Forms.PictureBox();
            this.rdbEmpiezaJug = new System.Windows.Forms.RadioButton();
            this.rdbEmpiezaOrd = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNumCasillas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctTablero)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Location = new System.Drawing.Point(258, 635);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(75, 23);
            this.btnEmpezar.TabIndex = 0;
            this.btnEmpezar.Text = "Empezar";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // pctTablero
            // 
            this.pctTablero.Location = new System.Drawing.Point(13, 13);
            this.pctTablero.Name = "pctTablero";
            this.pctTablero.Size = new System.Drawing.Size(501, 501);
            this.pctTablero.TabIndex = 1;
            this.pctTablero.TabStop = false;
            this.pctTablero.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
            this.pctTablero.Paint += new System.Windows.Forms.PaintEventHandler(this.pctTablero_Paint);
            // 
            // rdbEmpiezaJug
            // 
            this.rdbEmpiezaJug.AutoSize = true;
            this.rdbEmpiezaJug.Checked = true;
            this.rdbEmpiezaJug.Location = new System.Drawing.Point(91, 561);
            this.rdbEmpiezaJug.Name = "rdbEmpiezaJug";
            this.rdbEmpiezaJug.Size = new System.Drawing.Size(60, 17);
            this.rdbEmpiezaJug.TabIndex = 2;
            this.rdbEmpiezaJug.TabStop = true;
            this.rdbEmpiezaJug.Text = "jugador";
            this.rdbEmpiezaJug.UseVisualStyleBackColor = true;
            // 
            // rdbEmpiezaOrd
            // 
            this.rdbEmpiezaOrd.AutoSize = true;
            this.rdbEmpiezaOrd.Location = new System.Drawing.Point(157, 561);
            this.rdbEmpiezaOrd.Name = "rdbEmpiezaOrd";
            this.rdbEmpiezaOrd.Size = new System.Drawing.Size(73, 17);
            this.rdbEmpiezaOrd.TabIndex = 3;
            this.rdbEmpiezaOrd.TabStop = true;
            this.rdbEmpiezaOrd.Text = "ordenador";
            this.rdbEmpiezaOrd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 563);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "quien empieza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 590);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "turno actual";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(88, 590);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(0, 13);
            this.lblTurno.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 614);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "resultado";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(88, 614);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 533);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "numero de casillas";
            // 
            // cmbNumCasillas
            // 
            this.cmbNumCasillas.FormattingEnabled = true;
            this.cmbNumCasillas.Location = new System.Drawing.Point(110, 530);
            this.cmbNumCasillas.Name = "cmbNumCasillas";
            this.cmbNumCasillas.Size = new System.Drawing.Size(121, 21);
            this.cmbNumCasillas.TabIndex = 10;
            this.cmbNumCasillas.SelectedIndexChanged += new System.EventHandler(this.cmbNumCasillas_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 666);
            this.Controls.Add(this.cmbNumCasillas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbEmpiezaOrd);
            this.Controls.Add(this.rdbEmpiezaJug);
            this.Controls.Add(this.pctTablero);
            this.Controls.Add(this.btnEmpezar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pctTablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.PictureBox pctTablero;
        private System.Windows.Forms.RadioButton rdbEmpiezaJug;
        private System.Windows.Forms.RadioButton rdbEmpiezaOrd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNumCasillas;
    }
}

