using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlimentationCSV
{
    class Eleve
    {
        string nom;
        string prenom;
        string email;
        int idAuth;

        public Eleve(string nom, string prenom, string email)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
        }

        public int IdAuth { get { return idAuth; } set { idAuth = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string Prenom { get { return prenom; } set { prenom = value; } }

        public string Nom { get { return nom; } set { nom = value; } }
    }
}
