using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlimentationCSV
{
    public class Enseignant
    {
        int id;
        string nom;
        string prenom;

        public Enseignant(int id, string nom, string prenom)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
        }

        public int Id { get { return this.id; } }
        public string Nom { get { return this.nom; } }
        public string Prenom { get { return this.prenom; } }

        public override string ToString()
        {
             return string.Format("{0} , {1}, {2}",this.id, this.nom, this.prenom);
            
        }
    }



}
