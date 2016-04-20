using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CatalogueDeJouet;

namespace UnitTestCatalogue
{
    [TestClass]
    public class EnfantDAOTest
    {
        [TestMethod]
        // List<Enfant> findLesEnfants(int idEmploye)  
        public void findLesEnfantsTest()
        {
            List<Enfant> desEnfants;
            EnfantDAO uneDAO = new EnfantDAO();
            int id = 1;
            desEnfants = uneDAO.findLesEnfants(id);
            int actual =desEnfants.Count ;
            int expected = 0;
            Assert.AreEqual(expected, actual, "erreur dans le nb d'enfants de l'employé 1");
            id = 2;
            desEnfants = uneDAO.findLesEnfants(id);
            actual = desEnfants.Count;
            expected = 3;
            Assert.AreEqual(expected, actual, "erreur dans le nb d'enfants de l'employé 2");
        }
    }
}
