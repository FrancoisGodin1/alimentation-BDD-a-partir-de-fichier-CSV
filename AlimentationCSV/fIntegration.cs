using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Dynamic;

namespace AlimentationCSV
{
    public partial class fIntegration : Form
    {
        BddFunctions bdd = new BddFunctions();
        List<Enseignant> listeEnseignants;
        List<Classe> listeClasses;
        string nomFichier = "";

        public fIntegration()
        {
            InitializeComponent();
            this.listeEnseignants = bdd.SelectEnseignant();
            this.listeClasses = new List<Classe>();
            this.btnLancer.Click += new EventHandler(btnLancer_Click);
            this.lbEnseignant.SelectedValueChanged += new EventHandler(lbEnseignant_SelectedValueChanged);
            this.btnParcourir.Click += new EventHandler(btnParcourir_Click);
          
        }

        void btnParcourir_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            int length = openFileDialog1.FileName.Length;
            string result = openFileDialog1.FileName.Substring(length - 3, 3);
            if (result != "csv")
            {
                MessageBox.Show("Erreur: Le fichier sélectionné n'est pas du type CSV !");
                nomFichier = "";
            }
            else
            {
                this.nomFichier = openFileDialog1.FileName;
            }
        }

        private void fIntegration_Load(object sender, EventArgs e)
        {

            List<Enseignant> listeEnseignants = bdd.SelectEnseignant();

            foreach (Enseignant egt in listeEnseignants)
            {
                lbEnseignant.Items.Add(egt.ToString());
            }
        }

        // le fait de sélectionner un enseignant dans la listbox lance cet événement qui va instancier dans une list les classe affilié a cet
        //enseignant. -> les classe de la list son ensuite affiché dans la listbox classes.  
        void lbEnseignant_SelectedValueChanged(object sender, EventArgs e)
        {
            this.listeClasses.Clear();
            this.lbClasse.Items.Clear();

            int i = lbEnseignant.SelectedIndex;
            this.listeClasses = bdd.SelectClasse(listeEnseignants[i].Id);

            foreach (Classe c in listeClasses)
            {
                lbClasse.Items.Add(c.ToString());
            }
        }

        void btnLancer_Click(object sender, EventArgs e)
        {

            if (this.nomFichier == "")
                MessageBox.Show("aucun fichier n'as été sélectionné ! ");
            else
            {
                try
                {
                    //StreamReader sr = new StreamReader(this.nomFichier);
                    if (cbSuppression.Checked == true)
                    {
                        List<int> l = bdd.SelectIdAuthEleveFromClass(this.listeClasses[lbClasse.SelectedIndex].Id);
                        bdd.SupprimerElevesClasse(this.listeClasses[lbClasse.SelectedIndex].Id);
                        foreach (int i in l)
                        {
                            bdd.SupprimerEleveDuGroupe(i);
                            bdd.SupprimerEleveDesUsers(i);
                        }
                    }

                    foreach (string line in File.ReadLines(nomFichier))
                    {
                        Eleve unEleve;
                        bool ok = true;
                        string[] parts = line.Split(';'); // separateur
                        string nom = parts[1];
                        string prenom = parts[2];
                        string email = parts[3];

                        if (nom == "Nom") // pour ne pas prendre en compte la 1ere ligne du csv
                            ok = false;
                        if (parts[1] == "") // pour controler si c'est la fin
                            break;

                        if (ok != false) //  on recup les data de la ligne
                        {
                            unEleve = new Eleve(nom, prenom, email);
                            bdd.AjouterUser(unEleve);
                            bdd.AjouterEleveAuGroupeDefault(unEleve.IdAuth);
                            bdd.AjouterEleveAuGroupeEleve(unEleve.IdAuth);
                            bdd.AjouterEleve(unEleve, this.listeClasses[lbClasse.SelectedIndex].Id);
                        }
                    }
                    MessageBox.Show("Les élèves ont été ajouté");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erreur : " + ex.ToString());
                }
            }
        }

    }
}
