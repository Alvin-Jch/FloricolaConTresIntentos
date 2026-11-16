namespace Floricola.Vistas.EstadoCivil
{
    partial class FrmEditarEsatdoCivil
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
            label2 = new Label();
            txtEditar = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(14, 12);
            label2.Name = "label2";
            label2.Size = new Size(203, 32);
            label2.TabIndex = 7;
            label2.Text = "Editar Estado Civil";
            // 
            // txtEditar
            // 
            txtEditar.Location = new Point(14, 72);
            txtEditar.Margin = new Padding(3, 4, 3, 4);
            txtEditar.Name = "txtEditar";
            txtEditar.Size = new Size(167, 27);
            txtEditar.TabIndex = 1;
            txtEditar.TextChanged += txtEditar_TextChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(25, 148);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 31);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmEditarEsatdoCivil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(225, 205);
            Controls.Add(label2);
            Controls.Add(txtEditar);
            Controls.Add(btnGuardar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmEditarEsatdoCivil";
            Text = "FrmEditarEsatdoCivil";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtEditar;
        private Button btnGuardar;
    }
}