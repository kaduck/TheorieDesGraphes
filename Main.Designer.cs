namespace TheorieDesGraphes
{
    partial class Main
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
            this.btGenerer = new System.Windows.Forms.Button();
            this.gbGeneration = new System.Windows.Forms.GroupBox();
            this.lbInstruction = new System.Windows.Forms.Label();
            this.dgvMatrice = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbAretes = new System.Windows.Forms.NumericUpDown();
            this.tbSommets = new System.Windows.Forms.NumericUpDown();
            this.cbConnexe = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btConnex = new System.Windows.Forms.Button();
            this.uC_Graphe = new TheorieDesGraphes.UC_Graphe();
            this.tbSommetArticulation = new System.Windows.Forms.Button();
            this.gbGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAretes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSommets)).BeginInit();
            this.SuspendLayout();
            // 
            // btGenerer
            // 
            this.btGenerer.Location = new System.Drawing.Point(216, 14);
            this.btGenerer.Name = "btGenerer";
            this.btGenerer.Size = new System.Drawing.Size(148, 30);
            this.btGenerer.TabIndex = 0;
            this.btGenerer.Text = "Générer";
            this.btGenerer.UseVisualStyleBackColor = true;
            this.btGenerer.Click += new System.EventHandler(this.btGenerer_Click);
            // 
            // gbGeneration
            // 
            this.gbGeneration.Controls.Add(this.tbSommetArticulation);
            this.gbGeneration.Controls.Add(this.btConnex);
            this.gbGeneration.Controls.Add(this.lbInstruction);
            this.gbGeneration.Controls.Add(this.dgvMatrice);
            this.gbGeneration.Controls.Add(this.uC_Graphe);
            this.gbGeneration.Controls.Add(this.tbAretes);
            this.gbGeneration.Controls.Add(this.tbSommets);
            this.gbGeneration.Controls.Add(this.cbConnexe);
            this.gbGeneration.Controls.Add(this.label3);
            this.gbGeneration.Controls.Add(this.label2);
            this.gbGeneration.Controls.Add(this.label1);
            this.gbGeneration.Controls.Add(this.btGenerer);
            this.gbGeneration.Location = new System.Drawing.Point(13, 13);
            this.gbGeneration.Name = "gbGeneration";
            this.gbGeneration.Size = new System.Drawing.Size(777, 498);
            this.gbGeneration.TabIndex = 1;
            this.gbGeneration.TabStop = false;
            this.gbGeneration.Text = "Graphe";
            // 
            // lbInstruction
            // 
            this.lbInstruction.AutoSize = true;
            this.lbInstruction.Location = new System.Drawing.Point(13, 477);
            this.lbInstruction.Name = "lbInstruction";
            this.lbInstruction.Size = new System.Drawing.Size(113, 13);
            this.lbInstruction.TabIndex = 9;
            this.lbInstruction.Text = "Choisissez un point A :";
            // 
            // dgvMatrice
            // 
            this.dgvMatrice.AllowUserToAddRows = false;
            this.dgvMatrice.AllowUserToDeleteRows = false;
            this.dgvMatrice.AllowUserToResizeColumns = false;
            this.dgvMatrice.AllowUserToResizeRows = false;
            this.dgvMatrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatrice.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMatrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatrice.ColumnHeadersHeight = 25;
            this.dgvMatrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMatrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A});
            this.dgvMatrice.Location = new System.Drawing.Point(10, 51);
            this.dgvMatrice.MultiSelect = false;
            this.dgvMatrice.Name = "dgvMatrice";
            this.dgvMatrice.ReadOnly = true;
            this.dgvMatrice.RowHeadersWidth = 25;
            this.dgvMatrice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMatrice.Size = new System.Drawing.Size(354, 168);
            this.dgvMatrice.TabIndex = 8;
            this.dgvMatrice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatrice_CellClick);
            // 
            // A
            // 
            this.A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.A.HeaderText = "A";
            this.A.MinimumWidth = 25;
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.A.Width = 25;
            // 
            // tbAretes
            // 
            this.tbAretes.Location = new System.Drawing.Point(161, 74);
            this.tbAretes.Name = "tbAretes";
            this.tbAretes.Size = new System.Drawing.Size(37, 20);
            this.tbAretes.TabIndex = 6;
            this.tbAretes.Visible = false;
            // 
            // tbSommets
            // 
            this.tbSommets.Location = new System.Drawing.Point(148, 23);
            this.tbSommets.Name = "tbSommets";
            this.tbSommets.Size = new System.Drawing.Size(37, 20);
            this.tbSommets.TabIndex = 5;
            this.tbSommets.ValueChanged += new System.EventHandler(this.tbSommets_ValueChanged);
            // 
            // cbConnexe
            // 
            this.cbConnexe.AutoSize = true;
            this.cbConnexe.Enabled = false;
            this.cbConnexe.Location = new System.Drawing.Point(161, 25);
            this.cbConnexe.Name = "cbConnexe";
            this.cbConnexe.Size = new System.Drawing.Size(15, 14);
            this.cbConnexe.TabIndex = 4;
            this.cbConnexe.UseVisualStyleBackColor = true;
            this.cbConnexe.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre d\'arêtes";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de sommets :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connexe :";
            this.label1.Visible = false;
            // 
            // btConnex
            // 
            this.btConnex.Location = new System.Drawing.Point(382, 14);
            this.btConnex.Name = "btConnex";
            this.btConnex.Size = new System.Drawing.Size(172, 31);
            this.btConnex.TabIndex = 10;
            this.btConnex.Text = "Connexe ?";
            this.btConnex.UseVisualStyleBackColor = true;
            this.btConnex.Click += new System.EventHandler(this.btConnex_Click);
            // 
            // uC_Graphe
            // 
            this.uC_Graphe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Graphe.Location = new System.Drawing.Point(10, 225);
            this.uC_Graphe.Name = "uC_Graphe";
            this.uC_Graphe.Size = new System.Drawing.Size(354, 267);
            this.uC_Graphe.TabIndex = 7;
            this.uC_Graphe.Click += new System.EventHandler(this.uC_Graphe_Click);
            // 
            // tbSommetArticulation
            // 
            this.tbSommetArticulation.Location = new System.Drawing.Point(382, 63);
            this.tbSommetArticulation.Name = "tbSommetArticulation";
            this.tbSommetArticulation.Size = new System.Drawing.Size(172, 31);
            this.tbSommetArticulation.TabIndex = 11;
            this.tbSommetArticulation.Text = "Sommet articulation";
            this.tbSommetArticulation.UseVisualStyleBackColor = true;
            this.tbSommetArticulation.Click += new System.EventHandler(this.tbSommetArticulation_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 523);
            this.Controls.Add(this.gbGeneration);
            this.Name = "Main";
            this.Text = "Main";
            this.gbGeneration.ResumeLayout(false);
            this.gbGeneration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAretes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSommets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGenerer;
        private System.Windows.Forms.GroupBox gbGeneration;
        private System.Windows.Forms.NumericUpDown tbAretes;
        private System.Windows.Forms.NumericUpDown tbSommets;
        private System.Windows.Forms.CheckBox cbConnexe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UC_Graphe uC_Graphe;
        private System.Windows.Forms.DataGridView dgvMatrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn A;
        private System.Windows.Forms.Label lbInstruction;
        private System.Windows.Forms.Button btConnex;
        private System.Windows.Forms.Button tbSommetArticulation;
    }
}