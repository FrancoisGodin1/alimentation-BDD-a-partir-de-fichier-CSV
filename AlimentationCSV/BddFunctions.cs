using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace AlimentationCSV
{
    class BddFunctions
    {
        MySqlConnection cnx = new MySqlConnection("user=root;password=siojjr;server=172.16.0.153;database=rallyeLecture");
        // verifier l'@ IP de la VM car le DHCP peut potentielement changer l'IP 

        public List<Enseignant> SelectEnseignant()
        {
            List<Enseignant> ListeEnseignant = new List<Enseignant>();
            string req = "select id,nom,prenom from enseignant ";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            this.cnx.Open();
            // penser à démarrer  le serveur wamp sur la VM et verifier si l'IP nas pas changer
            

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Enseignant unEnseignant = new Enseignant(Convert.ToInt32(reader["id"]), reader["nom"].ToString(), reader["prenom"].ToString());
                ListeEnseignant.Add(unEnseignant);
            }
            reader.Close();
            this.cnx.Close();
            return ListeEnseignant;
        }

        public List<Classe> SelectClasse(int idEnseignant)
        {
            List<Classe> listeClasse = new List<Classe>();
            string req = "select c.id, niveauScolaire from classe c , niveau n where c.idNiveau=n.id and idEnseignant = @id ";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            MySqlParameter pId = new MySqlParameter("@id", MySqlDbType.Int32);
            pId.Value = idEnseignant;
            cmd.Parameters.Add(pId);

            this.cnx.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Classe uneClasse = new Classe(reader.GetInt32(0), reader.GetString(1));
                listeClasse.Add(uneClasse);
            }
 
            reader.Close();
            this.cnx.Close();
            return listeClasse;
        }

        public int SelectIdUsersByEmail(string email)
        {
            int idUser=0;
            string req = "select id from aauth_users where email='"+email+"'";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            this.cnx.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                idUser = int.Parse(reader["id"].ToString());

            reader.Close();
            this.cnx.Close();
            return idUser;
        }

        //return une liste des id des eleves de la classe selectionnée
        public List<int> SelectIdAuthEleveFromClass(int idClasse)
        {
            List<int> ListeIdAuth = new List<int>();
            string req = "select idAuth from eleve where  idClasse = @id ";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            MySqlParameter pId = new MySqlParameter("@id", MySqlDbType.Int32);
            pId.Value = idClasse;
            cmd.Parameters.Add(pId);

            this.cnx.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListeIdAuth.Add(reader.GetInt32(0));
            }

            reader.Close();
            this.cnx.Close();
            return ListeIdAuth;
        }

        public void SupprimerElevesClasse(int id)
        {
            string req = "delete from eleve where idClasse = @id ";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            MySqlParameter pId = new MySqlParameter("@id", MySqlDbType.Int32);
            pId.Value = id;
            cmd.Parameters.Add(pId);

            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();
        }

        public void SupprimerEleveDuGroupe(int idUser)
        {
            string req = "delete from aauth_user_to_group where user_id = @id and group_id = 4  ";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            MySqlParameter pId = new MySqlParameter("@id", MySqlDbType.Int32);
            pId.Value = idUser;
            cmd.Parameters.Add(pId);

            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();
        }

        public void AjouterEleveAuGroupeEleve(int idUser)
        {
            string req = "insert into aauth_user_to_group values("+idUser+",4)";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();
        }

        public void AjouterEleveAuGroupeDefault(int idUser)
        {
            string req = "insert into aauth_user_to_group values(" + idUser + ",3)";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();
        }

        public void SupprimerEleveDesUsers(int idUser)
        {
            string req = "delete from aauth_users where id = @id ";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);

            MySqlParameter pId = new MySqlParameter("@id", MySqlDbType.Int32);
            pId.Value = idUser;
            cmd.Parameters.Add(pId);

            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();
        }

        public void AjouterEleve(Eleve unEleve,int idClasse) 
        {
            string req = "insert into eleve(idClasse,nom,prenom,login,idAuth) values("+idClasse+",'"+unEleve.Nom+"','"+unEleve.Prenom+"','"+unEleve.Email+"',"+unEleve.IdAuth+");";
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);
            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();

        }

        public void AjouterUser(Eleve unEleve) 
        {
            string mdp = unEleve.Prenom.ToLower().Substring(0,1)+unEleve.Nom.ToLower(); // le mdp des eleves sera => InitialePrenom+Nom
            //dans un 1er temps on hash provisoirement le mdp avec un IdAuth à 0. et ensuite avec l'idAuth généré par lauto increment en sql
            //string idHash = HashMd5("0");
            //string mdpHashé = HashSha256(idHash+mdp);
            DateTime dateJour = DateTime.Now;
            string email = unEleve.Email;

            MySqlCommand cmd = new MySqlCommand("insert into aauth_users(email,pass,date_created) values(@email,@mdpHashé,@dateJour)");

            cmd.Parameters.Add(new MySqlParameter("@dateJour", MySqlDbType.DateTime));
            cmd.Parameters.Add(new MySqlParameter("@email", MySqlDbType.String));
            cmd.Parameters.Add(new MySqlParameter("@mdpHashé", MySqlDbType.String));
            cmd.Parameters["@dateJour"].Value = dateJour;
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@mdpHashé"].Value = "temporary";

            cmd.Connection = cnx;

            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();

            // je recup l'id user apres insertion => recherche dans la table aauth_users avec son email 
            unEleve.IdAuth = SelectIdUsersByEmail(email);
            // on met a jour le mdp hashé avc l'idUser
            UpdateUser(unEleve.IdAuth, mdp); 
        }

        public void UpdateUser(int idAuth,string mdp)
        {
            string idAuthHash = HashMd5(idAuth.ToString());
            string mdpHash = HashSha256(idAuthHash+mdp);
            string req = "update aauth_users set pass ='"+mdpHash+"' where id ="+idAuth;
            MySqlCommand cmd = new MySqlCommand(req, this.cnx);
            this.cnx.Open();
            cmd.ExecuteNonQuery();
            this.cnx.Close();
        }

        public string HashMd5(string value) {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sb = new StringBuilder();
            for(int i = 0;i<data.Length;i++)
                sb.Append(data[i].ToString("x2"));
            return sb.ToString();
        }

        public string HashSha256(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
                hex += String.Format("{0:x2}", x);
            return hex;
        }
    }
}
