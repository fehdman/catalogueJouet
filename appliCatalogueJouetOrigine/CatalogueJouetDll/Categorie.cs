using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueJouetDll
{
    public class Categorie
    {
        private int code;
        private string libelle;
        private List<Jouet> lesJouets;

        public Categorie(int pCode, string pLibelle)
        {
            code = pCode;
            libelle = pLibelle;
            lesJouets = new List<Jouet>();
        }

        public int getCode()
        {
            return code;
        }
        public string getLibelle()
        {
            return libelle;
        }

        public override string ToString()
        {
            return code + " - " + libelle;
        }
    }
}
