using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogueJouetDll;

namespace CatalogueDeJouet
{
    public class Enfant
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private Jouet leJouet;

        public Enfant(int pid,string pNom, string pPrenom, int pAge)
        {
            id = pid;
            nom = pNom;
            prenom = pPrenom;
            age = pAge;
            leJouet = null;
        }

        public Enfant(int pid, string pNom, string pPrenom, int pAge,Jouet unJouet)
        {
            id = pid;
            nom = pNom;
            prenom = pPrenom;
            age = pAge;
            leJouet = unJouet;
        }
        public int getId()
        {
            return id;
        }
        
        public string getPrenom()
        {
            return prenom;
        }

        public int getAge()
        {
            return age;
        }

        public override string ToString()
        {
            string aRetourner= prenom+" - "+age;
            if (leJouet != null)
            {
                aRetourner += leJouet.ToString();
            }
            return aRetourner;
        }

        public void setLeJouet(Jouet unJouet)
        {
            leJouet = unJouet;
        }

        public Jouet getLeJouet()
        {
            return leJouet;
        }
    }
}
