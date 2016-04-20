using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CatalogueDeJouet;

namespace UnitTestCatalogue
{
    [TestClass]
    public class EmployeDAOTest
    {
        [TestMethod]
        public void findByLoginTest()
        {
            Employe unEmploye;
            EmployeDAO uneDAO = new EmployeDAO();
            string login = "a";
            string expected = "a";
            unEmploye = uneDAO.findByLogin(login, expected);
            string actual = unEmploye.getMdp();
            Assert.AreEqual(expected,actual, "erreur dans la récupération de l'employé");
        } 
        
        [TestMethod]
        public void findAllTest()
        {
            List<Employe> desEmploye;
            EmployeDAO uneDAO = new EmployeDAO();
            desEmploye = uneDAO.findAll();
            int actual = desEmploye.Count;
            int expected = 2;
            Assert.AreEqual(expected,actual, "mauvais nombre d'employés");
        }

        [TestMethod]
        public void findTest()
        {
            Employe unEmploye;
            EmployeDAO uneDAO = new EmployeDAO();
            int id = 2;
            int expected = 3;
            unEmploye = uneDAO.find(id);
            int actual = unEmploye.getLesEnfants().Count;
            Assert.AreEqual( expected,actual, "erreur dans le nombre d'enfants de l'employé n°2");
        } 
        
    }
}
