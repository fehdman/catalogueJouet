using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CatalogueDeJouet
{
    public abstract class DAO<T>
    {
        static SqlConnection laConnection;
        public void seConnecter()
        {
            if (laConnection == null || laConnection.State!=ConnectionState.Open)
            {
                string chaineConnexion = "Data Source=win-921c8fktgae; Database=hopitalPPEHaddadChaibi; User Id=chaibi;Password=chaibi";
                laConnection = new SqlConnection(chaineConnexion);
                laConnection.Open();                      // ouverture de la connection
            }
        }

        public SqlDataReader executerSQL(string pRequete)
        {
            SqlDataReader resultat;
            seConnecter();
            SqlCommand MyCommand = new SqlCommand(pRequete, laConnection);
            resultat = MyCommand.ExecuteReader();
            return resultat;
        }

        public int executerLMD(string pRequete)
        {
            seConnecter();
            SqlCommand MyCommand = new SqlCommand(pRequete, laConnection);
            int resultat = MyCommand.ExecuteNonQuery();
            return resultat;
        }
        public void seDeconnecter()
        {
            laConnection.Close();
        }
        /*public abstract Boolean create(T unObjet);*/

        public abstract T find(int id);
        
        /*public abstract Boolean update(T unObjet);

        public abstract Boolean delete(T unObjet);*/

        public abstract List<T> findAll();
    }
}
