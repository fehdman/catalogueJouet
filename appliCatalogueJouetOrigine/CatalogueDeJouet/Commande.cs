using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueDeJouet
{
    class Commande
    {
        private int id = 0;
        private DateTime dateCommande;
        private int idJouet;
        private int idCategorie;
        private int idEmploye;

        public Commande (DateTime pDateCommande , int pIdJouet , int pIdCategorie , int pIdEmploye)
        {
            dateCommande = pDateCommande;
            idJouet = pIdJouet;
            idCategorie = pIdCategorie;
            idEmploye = pIdEmploye;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int pId)
        {
            id = pId;
        }

        public DateTime getDateCommande()
        {
            return dateCommande;
        }

        public void setDateCommande(DateTime pDateCommande)
        {
            dateCommande = pDateCommande;
        }

        public int getIdJouet()
        {
            return idJouet;
        }

        public void setIdJouet(int pIdJouet)
        {
            idJouet = pIdJouet;
        }

        public int getIdCategorie()
        {
            return idCategorie;
        }

        public void setIdCategorie(int pIdCategorie)
        {
            idCategorie = pIdCategorie;
        }

        public int getIdEmploye()
        {
            return idEmploye;
        }
        
        public void setIdEmploye(int pIdEmploye)
        {
            idEmploye = pIdEmploye;
        }
    }
}
