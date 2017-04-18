namespace AlimentationCSV
{
    partial class fIntegration
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLancer = new System.Windows.Forms.Button();
            this.lbClasse = new System.Windows.Forms.ListBox();
            this.cbSuppression = new System.Windows.Forms.CheckBox();
            this.lbEnseignant = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "fichier csv à integrer :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "classe :";
            // 
            // btnLancer
            // 
            this.btnLancer.Location = new System.Drawing.Point(110, 310);
            this.btnLancer.Name = "btnLancer";
            this.btnLancer.Size = new System.Drawing.Size(130, 23);
            this.btnLancer.TabIndex = 4;
            this.btnLancer.Text = "lancer l\'intégration";
            this.btnLancer.UseVisualStyleBackColor = true;
            // 
            // lbClasse
            // 
            this.lbClasse.FormattingEnabled = true;
            this.lbClasse.Location = new System.Drawing.Point(155, 191);
            this.lbClasse.Name = "lbClasse";
            this.lbClasse.Size = new System.Drawing.Size(170, 43);
            this.lbClasse.TabIndex = 6;
            // 
            // cbSuppression
            // 
            this.cbSuppression.AutoSize = true;
            this.cbSuppression.Location = new System.Drawing.Point(12, 266);
            this.cbSuppression.Name = "cbSuppression";
            this.cbSuppression.Size = new System.Drawing.Size(313, 17);
            this.cbSuppression.TabIndex = 7;
            this.cbSuppression.Text = "Suppression de tous les élèves de la classe avant intégration";
            this.cbSuppression.UseVisualStyleBackColor = true;
            // 
            // lbEnseignant
            // 
            this.lbEnseignant.FormattingEnabled = true;
            this.lbEnseignant.Location = new System.Drawing.Point(155, 124);
            this.lbEnseignant.Name = "lbEnseignant";
            this.lbEnseignant.Size = new System.Drawing.Size(170, 43);
            this.lbEnseignant.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "choix enseignant";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = " ";
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(177, 78);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(127, 25);
            this.btnParcourir.TabIndex = 11;
            this.btnParcourir.Text = "Parcourir";
            this.btnParcourir.UseVisualStyleBackColor = true;
            // 
            // fIntegration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 392);
            this.Controls.Add(this.btnParcourir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbEnseignant);
            this.Controls.Add(this.cbSuppression);
            this.Controls.Add(this.lbClasse);
            this.Controls.Add(this.btnLancer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "fIntegration";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.fIntegration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLancer;
        private System.Windows.Forms.ListBox lbClasse;
        private System.Windows.Forms.CheckBox cbSuppression;
        private System.Windows.Forms.ListBox lbEnseignant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnParcourir;
    }
}

