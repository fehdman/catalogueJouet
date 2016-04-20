using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CatalogueJouetDll;
using System.Data.SqlClient;

namespace CatalogueDeJouet
{
    public class EnfantDAO : DAO<Enfant>
    {
        public override List<Enfant> findAll()
        {
            throw new NotImplementedException();

        }
        public List<Enfant> findLesEnfants(int idEmploye)            //Trouve les enfants d'un employé
        {
            List<Enfant> enfants = new List<Enfant>();
            //string requete = "Select id,nom,prenom,age From Enfant where idParent=" + idEmploye;
            string requete = "Select id,nom,prenom,age,idJouet,libelle,idTrancheAge,ageMin,ageMax";
            requete+=" From enfant e left outer join jouet j on e.idJouet=j.numero";
            requete += " left outer join trancheAge t on j.idTrancheAge=t.code";
            requete+=" where idParent=" + idEmploye;
            SqlDataReader resultat = executerSQL(requete);
            while (resultat.Read())
            {
                int id = (int)resultat["id"];
                string nom = (string)resultat["nom"];
                string prenom = (string)resultat["prenom"];
                int age = (int)resultat["age"];
                if (resultat.IsDBNull(resultat.GetOrdinal("idJouet")))                {
                    enfants.Add(new Enfant(id, nom, prenom, age));
                }
                else
                {
                    int idJouet = (int)resultat["idJouet"];
                    string libelle = (string)resultat["libelle"];
                    enfants.Add(new Enfant(id, nom, prenom, age, new Jouet(idJouet, libelle)));
                }
            }
            resultat.Close();
            return enfants;
        }

        public int updateLeJouet(Enfant unEnfant)
        {
            string laRequete;
            laRequete = "update enfant set idJouet=" + unEnfant.getLeJouet().getNumero() + " where id=" + unEnfant.getId();
            return executerLMD(laRequete);

        }

        public override Enfant find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
