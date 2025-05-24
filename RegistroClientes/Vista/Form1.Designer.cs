namespace RegistroClientes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tituloCliente = new Label();
            lblnombreCli = new Label();
            erroresMSJ = new ErrorProvider(components);
            txtNombreCli = new TextBox();
            txtCorreoCli = new TextBox();
            lblCorreoCli = new Label();
            txtContraseCli = new TextBox();
            lblContraseCli = new Label();
            txtTelefonoCli = new TextBox();
            lblTelefonoCli = new Label();
            txtDireccionCli = new TextBox();
            lblDireccionCli = new Label();
            txtFechaNaciCli = new TextBox();
            lblFechaNaciCli = new Label();
            lblSexoCli = new Label();
            btnInsertar = new Button();
            btnActualizar = new Button();
            btnSeleccionar = new Button();
            btnBorrar = new Button();
            btnLimpiar = new Button();
            grupoSexo = new GroupBox();
            radioSexoSin = new RadioButton();
            radioSexoM = new RadioButton();
            radioSexoH = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)erroresMSJ).BeginInit();
            grupoSexo.SuspendLayout();
            SuspendLayout();
            // 
            // tituloCliente
            // 
            tituloCliente.AutoSize = true;
            tituloCliente.Font = new Font("Segoe UI", 15F);
            tituloCliente.Location = new Point(134, 9);
            tituloCliente.Name = "tituloCliente";
            tituloCliente.Size = new Size(157, 28);
            tituloCliente.TabIndex = 0;
            tituloCliente.Text = "Registro Clientes";
            // 
            // lblnombreCli
            // 
            lblnombreCli.AutoSize = true;
            lblnombreCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblnombreCli.Location = new Point(12, 59);
            lblnombreCli.Name = "lblnombreCli";
            lblnombreCli.Size = new Size(69, 20);
            lblnombreCli.TabIndex = 1;
            lblnombreCli.Text = "Nombre:";
            // 
            // erroresMSJ
            // 
            erroresMSJ.ContainerControl = this;
            // 
            // txtNombreCli
            // 
            txtNombreCli.Location = new Point(113, 59);
            txtNombreCli.Name = "txtNombreCli";
            txtNombreCli.Size = new Size(320, 23);
            txtNombreCli.TabIndex = 2;
            // 
            // txtCorreoCli
            // 
            txtCorreoCli.Location = new Point(113, 101);
            txtCorreoCli.Name = "txtCorreoCli";
            txtCorreoCli.Size = new Size(320, 23);
            txtCorreoCli.TabIndex = 4;
            // 
            // lblCorreoCli
            // 
            lblCorreoCli.AutoSize = true;
            lblCorreoCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblCorreoCli.Location = new Point(12, 101);
            lblCorreoCli.Name = "lblCorreoCli";
            lblCorreoCli.Size = new Size(61, 20);
            lblCorreoCli.TabIndex = 3;
            lblCorreoCli.Text = "Correo:";
            // 
            // txtContraseCli
            // 
            txtContraseCli.Location = new Point(113, 146);
            txtContraseCli.Name = "txtContraseCli";
            txtContraseCli.Size = new Size(320, 23);
            txtContraseCli.TabIndex = 6;
            // 
            // lblContraseCli
            // 
            lblContraseCli.AutoSize = true;
            lblContraseCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblContraseCli.Location = new Point(12, 146);
            lblContraseCli.Name = "lblContraseCli";
            lblContraseCli.Size = new Size(96, 20);
            lblContraseCli.TabIndex = 5;
            lblContraseCli.Text = "Contraseña:";
            // 
            // txtTelefonoCli
            // 
            txtTelefonoCli.Location = new Point(113, 191);
            txtTelefonoCli.Name = "txtTelefonoCli";
            txtTelefonoCli.Size = new Size(320, 23);
            txtTelefonoCli.TabIndex = 8;
            // 
            // lblTelefonoCli
            // 
            lblTelefonoCli.AutoSize = true;
            lblTelefonoCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblTelefonoCli.Location = new Point(12, 191);
            lblTelefonoCli.Name = "lblTelefonoCli";
            lblTelefonoCli.Size = new Size(75, 20);
            lblTelefonoCli.TabIndex = 7;
            lblTelefonoCli.Text = "Teléfono:";
            // 
            // txtDireccionCli
            // 
            txtDireccionCli.Location = new Point(113, 233);
            txtDireccionCli.Name = "txtDireccionCli";
            txtDireccionCli.Size = new Size(320, 23);
            txtDireccionCli.TabIndex = 10;
            // 
            // lblDireccionCli
            // 
            lblDireccionCli.AutoSize = true;
            lblDireccionCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblDireccionCli.Location = new Point(12, 233);
            lblDireccionCli.Name = "lblDireccionCli";
            lblDireccionCli.Size = new Size(79, 20);
            lblDireccionCli.TabIndex = 9;
            lblDireccionCli.Text = "Dirección:";
            // 
            // txtFechaNaciCli
            // 
            txtFechaNaciCli.Location = new Point(159, 272);
            txtFechaNaciCli.Name = "txtFechaNaciCli";
            txtFechaNaciCli.Size = new Size(274, 23);
            txtFechaNaciCli.TabIndex = 12;
            // 
            // lblFechaNaciCli
            // 
            lblFechaNaciCli.AutoSize = true;
            lblFechaNaciCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblFechaNaciCli.Location = new Point(12, 272);
            lblFechaNaciCli.Name = "lblFechaNaciCli";
            lblFechaNaciCli.Size = new Size(141, 20);
            lblFechaNaciCli.TabIndex = 11;
            lblFechaNaciCli.Text = "Fecha Nacimiento:";
            // 
            // lblSexoCli
            // 
            lblSexoCli.AutoSize = true;
            lblSexoCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblSexoCli.Location = new Point(12, 324);
            lblSexoCli.Name = "lblSexoCli";
            lblSexoCli.Size = new Size(49, 20);
            lblSexoCli.TabIndex = 13;
            lblSexoCli.Text = "Sexo:";
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(12, 374);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(75, 23);
            btnInsertar.TabIndex = 15;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(98, 374);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 16;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(184, 374);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(75, 23);
            btnSeleccionar.TabIndex = 17;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(270, 374);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 18;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(356, 374);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // grupoSexo
            // 
            grupoSexo.Controls.Add(radioSexoSin);
            grupoSexo.Controls.Add(radioSexoM);
            grupoSexo.Controls.Add(radioSexoH);
            grupoSexo.Location = new Point(102, 307);
            grupoSexo.Name = "grupoSexo";
            grupoSexo.Size = new Size(321, 43);
            grupoSexo.TabIndex = 23;
            grupoSexo.TabStop = false;
            // 
            // radioSexoSin
            // 
            radioSexoSin.AutoSize = true;
            radioSexoSin.Location = new Point(210, 17);
            radioSexoSin.Name = "radioSexoSin";
            radioSexoSin.Size = new Size(100, 19);
            radioSexoSin.TabIndex = 25;
            radioSexoSin.TabStop = true;
            radioSexoSin.Text = "Sin Especificar";
            radioSexoSin.UseVisualStyleBackColor = true;
            // 
            // radioSexoM
            // 
            radioSexoM.AutoSize = true;
            radioSexoM.Location = new Point(115, 17);
            radioSexoM.Name = "radioSexoM";
            radioSexoM.Size = new Size(56, 19);
            radioSexoM.TabIndex = 24;
            radioSexoM.TabStop = true;
            radioSexoM.Text = "Mujer";
            radioSexoM.UseVisualStyleBackColor = true;
            // 
            // radioSexoH
            // 
            radioSexoH.AutoSize = true;
            radioSexoH.Location = new Point(0, 17);
            radioSexoH.Name = "radioSexoH";
            radioSexoH.Size = new Size(69, 19);
            radioSexoH.TabIndex = 23;
            radioSexoH.TabStop = true;
            radioSexoH.Text = "Hombre";
            radioSexoH.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 418);
            Controls.Add(grupoSexo);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBorrar);
            Controls.Add(btnSeleccionar);
            Controls.Add(btnActualizar);
            Controls.Add(btnInsertar);
            Controls.Add(lblSexoCli);
            Controls.Add(txtFechaNaciCli);
            Controls.Add(lblFechaNaciCli);
            Controls.Add(txtDireccionCli);
            Controls.Add(lblDireccionCli);
            Controls.Add(txtTelefonoCli);
            Controls.Add(lblTelefonoCli);
            Controls.Add(txtContraseCli);
            Controls.Add(lblContraseCli);
            Controls.Add(txtCorreoCli);
            Controls.Add(lblCorreoCli);
            Controls.Add(txtNombreCli);
            Controls.Add(lblnombreCli);
            Controls.Add(tituloCliente);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)erroresMSJ).EndInit();
            grupoSexo.ResumeLayout(false);
            grupoSexo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label tituloCliente;
        internal Label lblnombreCli;
        internal ErrorProvider erroresMSJ;
        internal TextBox txtNombreCli;
        internal TextBox txtFechaNaciCli;
        internal Label lblFechaNaciCli;
        internal TextBox txtDireccionCli;
        internal Label lblDireccionCli;
        internal TextBox txtTelefonoCli;
        internal Label lblTelefonoCli;
        internal TextBox txtContraseCli;
        internal Label lblContraseCli;
        internal TextBox txtCorreoCli;
        internal Label lblCorreoCli;
        internal Label lblSexoCli;
        internal Button btnLimpiar;
        internal Button btnBorrar;
        internal Button btnSeleccionar;
        internal Button btnActualizar;
        internal Button btnInsertar;
        internal GroupBox grupoSexo;
        internal RadioButton radioSexoSin;
        internal RadioButton radioSexoM;
        internal RadioButton radioSexoH;
    }
}
