using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlimentationCSV
{
    public class Classe
    {

        int id;
        
        string niveauClasse;

        public Classe(int id, string niveauClasse)
        {
            this.id = id;
            
            this.niveauClasse = niveauClasse;
        }

        public int Id { get { return this.id; } }
        
        public string NiveauClasse { get { return this.niveauClasse; } }

        public override string ToString()
        {
            return string.Format("classe n°{0} : {1}", this.id, this.niveauClasse);
            
        }
    }
}
