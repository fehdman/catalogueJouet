using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueJouetDll;
using System.Data.SqlClient;

namespace CatalogueDeJouet
{
    class CategorieDAO : DAO<Categorie>
    {
        //
        public override List<Categorie> findAll()
        {
            throw new NotImplementedException();

        }

        public Dictionary<Categorie, int> findNbJouetCateg()
        {
            // nombre de jouets par catégorie
            Dictionary<Categorie, int> desCategories = new Dictionary<Categorie, int>();
            Categorie uneCategorie;
            SqlDataReader resultat = this.executerSQL("SELECT code, c.libelle as libel ,count(*) as nb FROM categorie c join jouet j on c.code=j.idCategorie join enfant e on e.idJouet=j.numero group by code,c.libelle");
            while (resultat.Read())
            {
                uneCategorie = new Categorie((int)resultat["code"], (string)resultat["libel"]);
                desCategories.Add(uneCategorie, (int)resultat["nb"]);
            }
            resultat.Close();
            return desCategories;
        }

        public override Categorie find(int pId)
        {
            Categorie uneCategorie = null;

            SqlDataReader resultat = executerSQL("Select libelle From categorie where code=" + pId);
            if (resultat.Read())
            {
                // id est valide
                string libelle = (string)resultat["libelle"];
                uneCategorie = new Categorie(pId, libelle);
            }
            resultat.Close();
            return uneCategorie;
        }
        //
    }
}
