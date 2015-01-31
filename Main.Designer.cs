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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbConnexe = new System.Windows.Forms.CheckBox();
            this.tbSommets = new System.Windows.Forms.NumericUpDown();
            this.tbAretes = new System.Windows.Forms.NumericUpDown();
            this.uC_Graphe = new TheorieDesGraphes.UC_Graphe();
            this.gbGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSommets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAretes)).BeginInit();
            this.SuspendLayout();
            // 
            // btGenerer
            // 
            this.btGenerer.Location = new System.Drawing.Point(216, 25);
            this.btGenerer.Name = "btGenerer";
            this.btGenerer.Size = new System.Drawing.Size(148, 69);
            this.btGenerer.TabIndex = 0;
            this.btGenerer.Text = "Générer";
            this.btGenerer.UseVisualStyleBackColor = true;
            this.btGenerer.Click += new System.EventHandler(this.btGenerer_Click);
            // 
            // gbGeneration
            // 
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
            this.gbGeneration.Size = new System.Drawing.Size(374, 498);
            this.gbGeneration.TabIndex = 1;
            this.gbGeneration.TabStop = false;
            this.gbGeneration.Text = "Graphe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connexe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de sommets :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre d\'arêtes";
            // 
            // cbConnexe
            // 
            this.cbConnexe.AutoSize = true;
            this.cbConnexe.Location = new System.Drawing.Point(161, 25);
            this.cbConnexe.Name = "cbConnexe";
            this.cbConnexe.Size = new System.Drawing.Size(15, 14);
            this.cbConnexe.TabIndex = 4;
            this.cbConnexe.UseVisualStyleBackColor = true;
            // 
            // tbSommets
            // 
            this.tbSommets.Location = new System.Drawing.Point(161, 48);
            this.tbSommets.Name = "tbSommets";
            this.tbSommets.Size = new System.Drawing.Size(37, 20);
            this.tbSommets.TabIndex = 5;
            // 
            // tbAretes
            // 
            this.tbAretes.Location = new System.Drawing.Point(161, 74);
            this.tbAretes.Name = "tbAretes";
            this.tbAretes.Size = new System.Drawing.Size(37, 20);
            this.tbAretes.TabIndex = 6;
            // 
            // uC_Graphe
            // 
            this.uC_Graphe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Graphe.Location = new System.Drawing.Point(10, 106);
            this.uC_Graphe.Name = "uC_Graphe";
            this.uC_Graphe.Size = new System.Drawing.Size(354, 386);
            this.uC_Graphe.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 523);
            this.Controls.Add(this.gbGeneration);
            this.Name = "Main";
            this.Text = "Main";
            this.gbGeneration.ResumeLayout(false);
            this.gbGeneration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSommets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAretes)).EndInit();
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
    }
}