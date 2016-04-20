using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace CatalogueDeJouet
{
    public class EmployeDAO : DAO<Employe>
    {

        public Employe findByLogin(string pUserName, string pPassword)
        {
            Employe unEmploye = null;

            SqlDataReader resultat = executerSQL("Select * From employe where login='" + pUserName + "' and mdp='" + pPassword + "'");
            if (resultat.Read())
            {
                // login et mdp sont valides
                int id = (int)resultat["id"];
                string nom = (string)resultat["nom"];
                string prenom = (string)resultat["prenom"];
                bool admin = (bool)resultat["admin"];
                unEmploye = new Employe(id,pUserName, nom, prenom, pPassword, admin);
            }
            unEmploye.setLesEnfants((new EnfantDAO()).findLesEnfants(unEmploye.getId()));
            resultat.Close();
            return unEmploye;
        }

        public override List<Employe> findAll()
        {
            List<Employe> desEmployes = new List<Employe>();
            // Attention à modifier
            desEmployes.Add(find(1));
            desEmployes.Add(find(2));
            return desEmployes;
        }
        public override Employe find(int pId)
        {
            Employe unEmploye = null;

            SqlDataReader resultat = executerSQL("Select * From employe where id=" + pId);
            if (resultat.Read())
            {
                // id est valide
                string login = (string)resultat["login"];
                string nom = (string)resultat["nom"];
                string prenom = (string)resultat["prenom"];
                string mdp = (string)resultat["mdp"];
                bool admin = (bool)resultat["admin"];
                unEmploye = new Employe(pId,login, nom, prenom, mdp, admin);
            }
            unEmploye.setLesEnfants((new EnfantDAO()).findLesEnfants(unEmploye.getId()));
            resultat.Close();
            return unEmploye;
        }
    }
}
