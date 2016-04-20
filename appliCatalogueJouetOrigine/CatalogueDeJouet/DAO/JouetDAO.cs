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
    class JouetDAO : DAO<Jouet>
    {
        /// <summary>
        /// Recupère tout les jouets présent dans la base de données
        /// </summary>
        /// <returns></returns>
        public override List<Jouet> findAll()
        {
            List<Jouet> jouets = new List<Jouet>();
            Categorie laCategorie;
            TrancheAge laTranche;
            Jouet unJouet;
            int i = 0;
            SqlDataReader resultat = this.executerSQL("SELECT c.libelle as catLib,j.libelle as jouetLib,t.ageMin as ageMin,t.ageMax as ageMax FROM jouet j join Categorie c on c.idCategorie=j.idCategorie join TrancheAge t on j.idTrancheAge=t.idTrancheAge ORDER BY j.libelle");
            while (resultat.Read())
            {
                    laCategorie = new Categorie(i, ((string)resultat["catLib"]));
                    laTranche = new TrancheAge(i,((int)resultat["ageMin"]),((int)resultat["ageMax"]));
                    unJouet = new Jouet(i, ((string)resultat["jouetLib"]), laCategorie, laTranche);
                    jouets.Add(unJouet);
                    i++;
            }
            resultat.Close();
            return jouets;
        }

        public  Dictionary<Jouet,int> findNbJouet()
        {
            Dictionary<Jouet, int> desJouets = new Dictionary<Jouet, int>();
            Jouet unJouet;
            SqlDataReader resultat = this.executerSQL("SELECT numero, libelle ,count(*) as nb FROM jouet j join enfant e on e.idJouet=j.numero group by j.numero,libelle");
            while (resultat.Read())
            {
                unJouet = new Jouet((int)resultat["numero"],(string)resultat["libelle"]);
                desJouets.Add(unJouet, (int)resultat["nb"]);
            }
            resultat.Close();
            return desJouets;
        }
        public override Jouet find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jouet> findByAge(int pAge)
        {
            List<Jouet> desJouets = new List<Jouet>();
           
            SqlDataReader resultat = executerSQL("Select numero,libelle,idCategorie,idTrancheAge From jouet join trancheAge on jouet.idTrancheAge=trancheAge.code where ageMin<=" + pAge+" and ageMax>="+pAge);
            while (resultat.Read())
            {
                int numero = (int)resultat["numero"];
                string libelle = (string)resultat["libelle"];
                int idCategorie = (int)resultat["idCategorie"];
                int idTrancheAge = (int)resultat["idTrancheAge"];
                Categorie uneCategorie = (new CategorieDAO()).find(idCategorie);
                TrancheAge uneTranche = (new TrancheAgeDAO()).find(idTrancheAge);
                desJouets.Add(new Jouet(numero, libelle, uneCategorie, uneTranche));
                
            }
            resultat.Close();
        
            return desJouets;

        }

        //CRUD
    }
}
