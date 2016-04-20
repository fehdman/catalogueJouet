using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueJouetDll
{
    public class Jouet
    {
         private int numero;
        private string libelle;
        private Categorie laCategorie;
        private TrancheAge laTranche;

        public Jouet(int pCode, string pLibelle)
        {
            numero = pCode;
            libelle = pLibelle;
            laCategorie = null;
            laTranche = null;

        }

        public Jouet(int pCode, string pLibelle,Categorie uneCategorie, TrancheAge uneTranche)
        {
            numero = pCode;
            libelle = pLibelle;
            laCategorie = uneCategorie;
            laTranche = uneTranche;

        }

        public int getNumero()
        {
            return numero;
        }
        public string getLibelle()
        {
            return libelle;
        }

        public Categorie getLaCategorie()
        {
            return laCategorie;
        }

        public TrancheAge getLaTranche()
        {
            return laTranche;
        }

        public override string ToString()
        {
            string aRetourner = numero + " - " + libelle + " - ";
            if (laTranche!=null)
                aRetourner+=laTranche.ToString();
            return aRetourner;
        }
    }
}
