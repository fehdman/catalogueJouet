using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueJouetDll;
using System.Data.SqlClient;

namespace CatalogueDeJouet
{
    class TrancheAgeDAO : DAO<TrancheAge>
    {
        //
        //
        public override List<TrancheAge> findAll()
        {
            throw new NotImplementedException();

        }

        public override TrancheAge find(int pId)
        {
            TrancheAge uneTranche = null;

            SqlDataReader resultat = executerSQL("Select * From trancheAge where code=" + pId);
            if (resultat.Read())
            {
                // id est valide
                int ageMin = (int)resultat["ageMin"];
                int ageMax = (int)resultat["ageMax"];
                uneTranche = new TrancheAge(pId, ageMin,ageMax);
            }
            resultat.Close();
            return uneTranche;
        }
        //
    }
}
