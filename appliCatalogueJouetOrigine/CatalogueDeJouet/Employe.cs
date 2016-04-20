using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueDeJouet
{
    public class Employe
    {
        private int id;
        private string login;
        private string nom;
        private string prenom;
        private string mdp;
        private bool admin;
        private List<Enfant> lesEnfants;
        public Employe(int pId,string pLogin, string pNom, string pPrenom, string pMdp, bool pAdmin)
        {
            id = pId;
            login = pLogin;
            nom = pNom;
            prenom = pPrenom;
            mdp = pMdp;
            admin = pAdmin;
            lesEnfants = new List<Enfant>();
        }

        public string Nom
        {
            get { return nom+" - "+prenom; }
            set { }
        }

        public List<Enfant> LesEnfants
        {
            get { return lesEnfants; }
            set { }
        }
        public string Enfants
        {
            get {
                string aRetourner = "";
                foreach (Enfant unEnfant in lesEnfants)
                {
                    aRetourner += unEnfant.ToString()+"\n";
                }
                return aRetourner;
            }
            set { }
        }

       
    
        public int getId()
        {
            return id;
        }
        public string getLogin()
        {
            return login;
        }
        public string getMdp()
        {
            return mdp;
        }
        public string getNom()
        {
            return nom;
        }
        public string getPrenom()
        {
            return prenom;
        }
        public void setNom(string pNom)
        {
            nom = pNom;
        }
        public void setPrenom(string pPrenom)
        {
            prenom = pPrenom;
        }
        
        public void setLogin(string pLogin)
        {
            login = pLogin;
        }
        public void setMdp(string pMdp)
        {
            mdp = pMdp;
        }
        public bool getAdmin()
        {
            return admin;
        }

        public void setLesEnfants(List<Enfant> desEnfants)
        {
            lesEnfants = desEnfants;
        }

        public List<Enfant> getLesEnfants()
        {
            return lesEnfants;
        }

        public List<Enfant> getLesEnfantsSansJouet()
        {
            List<Enfant> enfantSansJouet = new List<Enfant>();
            foreach (Enfant unEnfant in lesEnfants)
            {
                if (unEnfant.getLeJouet() == null)
                {
                    enfantSansJouet.Add(unEnfant);
                }
            }
            return enfantSansJouet;
        }

        public List<Enfant> getLesEnfantsAvecJouet()
        {
            List<Enfant> enfantAvecJouet = new List<Enfant>();
            foreach (Enfant unEnfant in lesEnfants)
            {
                if (unEnfant.getLeJouet() != null)
                {
                    enfantAvecJouet.Add(unEnfant);
                }
            }
            return enfantAvecJouet;
        }

        public override string ToString()
        {
            return nom + " - " + prenom;
        }
    }
}
