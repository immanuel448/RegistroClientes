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
            btnBuscar = new Button();
            btnBorrar = new Button();
            btnLimpiar = new Button();
            grupoSexo = new GroupBox();
            radioSexoSin = new RadioButton();
            radioSexoM = new RadioButton();
            radioSexoH = new RadioButton();
            lblID = new Label();
            txtID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)erroresMSJ).BeginInit();
            grupoSexo.SuspendLayout();
            SuspendLayout();
            // 
            // tituloCliente
            // 
            tituloCliente.AutoSize = true;
            tituloCliente.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tituloCliente.Location = new Point(24, 9);
            tituloCliente.Name = "tituloCliente";
            tituloCliente.Size = new Size(227, 32);
            tituloCliente.TabIndex = 0;
            tituloCliente.Text = "REGISTRO CLIENTES";
            // 
            // lblnombreCli
            // 
            lblnombreCli.AutoSize = true;
            lblnombreCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblnombreCli.Location = new Point(24, 76);
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
            txtNombreCli.Location = new Point(125, 76);
            txtNombreCli.Name = "txtNombreCli";
            txtNombreCli.Size = new Size(320, 23);
            txtNombreCli.TabIndex = 2;
            // 
            // txtCorreoCli
            // 
            txtCorreoCli.Location = new Point(125, 118);
            txtCorreoCli.Name = "txtCorreoCli";
            txtCorreoCli.Size = new Size(320, 23);
            txtCorreoCli.TabIndex = 4;
            // 
            // lblCorreoCli
            // 
            lblCorreoCli.AutoSize = true;
            lblCorreoCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblCorreoCli.Location = new Point(24, 118);
            lblCorreoCli.Name = "lblCorreoCli";
            lblCorreoCli.Size = new Size(61, 20);
            lblCorreoCli.TabIndex = 3;
            lblCorreoCli.Text = "Correo:";
            // 
            // txtContraseCli
            // 
            txtContraseCli.Location = new Point(125, 163);
            txtContraseCli.Name = "txtContraseCli";
            txtContraseCli.Size = new Size(320, 23);
            txtContraseCli.TabIndex = 6;
            // 
            // lblContraseCli
            // 
            lblContraseCli.AutoSize = true;
            lblContraseCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblContraseCli.Location = new Point(24, 163);
            lblContraseCli.Name = "lblContraseCli";
            lblContraseCli.Size = new Size(96, 20);
            lblContraseCli.TabIndex = 5;
            lblContraseCli.Text = "Contraseña:";
            // 
            // txtTelefonoCli
            // 
            txtTelefonoCli.Location = new Point(125, 208);
            txtTelefonoCli.Name = "txtTelefonoCli";
            txtTelefonoCli.Size = new Size(320, 23);
            txtTelefonoCli.TabIndex = 8;
            // 
            // lblTelefonoCli
            // 
            lblTelefonoCli.AutoSize = true;
            lblTelefonoCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblTelefonoCli.Location = new Point(24, 208);
            lblTelefonoCli.Name = "lblTelefonoCli";
            lblTelefonoCli.Size = new Size(75, 20);
            lblTelefonoCli.TabIndex = 7;
            lblTelefonoCli.Text = "Teléfono:";
            // 
            // txtDireccionCli
            // 
            txtDireccionCli.Location = new Point(125, 250);
            txtDireccionCli.Name = "txtDireccionCli";
            txtDireccionCli.Size = new Size(320, 23);
            txtDireccionCli.TabIndex = 10;
            // 
            // lblDireccionCli
            // 
            lblDireccionCli.AutoSize = true;
            lblDireccionCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblDireccionCli.Location = new Point(24, 250);
            lblDireccionCli.Name = "lblDireccionCli";
            lblDireccionCli.Size = new Size(79, 20);
            lblDireccionCli.TabIndex = 9;
            lblDireccionCli.Text = "Dirección:";
            // 
            // txtFechaNaciCli
            // 
            txtFechaNaciCli.Location = new Point(171, 289);
            txtFechaNaciCli.Name = "txtFechaNaciCli";
            txtFechaNaciCli.Size = new Size(274, 23);
            txtFechaNaciCli.TabIndex = 12;
            // 
            // lblFechaNaciCli
            // 
            lblFechaNaciCli.AutoSize = true;
            lblFechaNaciCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblFechaNaciCli.Location = new Point(24, 289);
            lblFechaNaciCli.Name = "lblFechaNaciCli";
            lblFechaNaciCli.Size = new Size(141, 20);
            lblFechaNaciCli.TabIndex = 11;
            lblFechaNaciCli.Text = "Fecha Nacimiento:";
            // 
            // lblSexoCli
            // 
            lblSexoCli.AutoSize = true;
            lblSexoCli.Font = new Font("Microsoft Sans Serif", 12F);
            lblSexoCli.Location = new Point(24, 341);
            lblSexoCli.Name = "lblSexoCli";
            lblSexoCli.Size = new Size(49, 20);
            lblSexoCli.TabIndex = 13;
            lblSexoCli.Text = "Sexo:";
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(24, 391);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(75, 23);
            btnInsertar.TabIndex = 15;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(138, 391);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 16;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(385, 36);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(60, 23);
            btnBuscar.TabIndex = 17;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(252, 391);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 18;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(366, 391);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // grupoSexo
            // 
            grupoSexo.Controls.Add(radioSexoSin);
            grupoSexo.Controls.Add(radioSexoM);
            grupoSexo.Controls.Add(radioSexoH);
            grupoSexo.Location = new Point(114, 324);
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
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 12F);
            lblID.Location = new Point(267, 39);
            lblID.Name = "lblID";
            lblID.Size = new Size(42, 20);
            lblID.TabIndex = 24;
            lblID.Text = "I. D.:";
            // 
            // txtID
            // 
            txtID.Location = new Point(315, 36);
            txtID.Name = "txtID";
            txtID.Size = new Size(63, 23);
            txtID.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(467, 437);
            Controls.Add(txtID);
            Controls.Add(lblID);
            Controls.Add(grupoSexo);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBorrar);
            Controls.Add(btnBuscar);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro Clientes";
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
        internal Button btnBuscar;
        internal Button btnActualizar;
        internal Button btnInsertar;
        internal GroupBox grupoSexo;
        internal RadioButton radioSexoSin;
        internal RadioButton radioSexoM;
        internal RadioButton radioSexoH;
        internal TextBox txtID;
        internal Label lblID;
    }
}
