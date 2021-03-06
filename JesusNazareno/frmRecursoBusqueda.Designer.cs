﻿using System.Windows.Forms;

namespace JesusNazareno
{
    partial class frmRecursoBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecursoBusqueda));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtparametro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbobuscar = new System.Windows.Forms.ComboBox();
            this.dgvrecurso = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrecurso)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtparametro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbobuscar);
            this.groupBox1.Location = new System.Drawing.Point(129, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros de Busqueda";
            // 
            // txtparametro
            // 
            this.txtparametro.Location = new System.Drawing.Point(279, 22);
            this.txtparametro.Name = "txtparametro";
            this.txtparametro.Size = new System.Drawing.Size(145, 20);
            this.txtparametro.TabIndex = 1;
            this.txtparametro.TextChanged += new System.EventHandler(this.txtparametro_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parametro: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por: ";
            // 
            // cbobuscar
            // 
            this.cbobuscar.FormattingEnabled = true;
            this.cbobuscar.Items.AddRange(new object[] {
            "NOMBRE",
            "MARCA",
            "SERIE",
            "TIPO"});
            this.cbobuscar.Location = new System.Drawing.Point(85, 22);
            this.cbobuscar.Name = "cbobuscar";
            this.cbobuscar.Size = new System.Drawing.Size(121, 21);
            this.cbobuscar.TabIndex = 1;
            // 
            // dgvrecurso
            // 
            this.dgvrecurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvrecurso.Location = new System.Drawing.Point(12, 73);
            this.dgvrecurso.Name = "dgvrecurso";
            this.dgvrecurso.Size = new System.Drawing.Size(667, 194);
            this.dgvrecurso.TabIndex = 3;
            this.dgvrecurso.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvrecurso_CellDoubleClick);
            // 
            // frmRecursoBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 279);
            this.Controls.Add(this.dgvrecurso);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecursoBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Recursos";
            this.Load += new System.EventHandler(this.frmRecursoBusqueda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrecurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtparametro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbobuscar;
        private DataGridView dgvrecurso;

        public DataGridViewCellEventHandler dtgvRecursos_CellContentClick { get; private set; }
    }
}