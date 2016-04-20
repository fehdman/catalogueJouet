using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using CatalogueJouetDll;

namespace CatalogueDeJouet
{

    /// <summary>
    /// Logique d'interaction pour WChoixJouet.xaml
    /// </summary>
    public partial class WChoixJouet : Window
    {
        private Employe lEmploye;
        private Enfant enfantSelectionne;
        public WChoixJouet(Employe unEmploye)
        {
            InitializeComponent();
            lEmploye = unEmploye;

            LSubTitle.Content += " M. ou Mme " + lEmploye.getNom();
            rafraichirListes();
        }

        private void CBChoixJouet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bValider_Click(object sender, RoutedEventArgs e)
        {
            // on affecte le jouet à l'enfant
            Enfant lEnfant = (Enfant)cbEnfant.SelectedItem;
            lEnfant.setLeJouet((Jouet)CBChoixJouet.SelectedItem);

            rafraichirListes();
            /*
            // mise à jour de la liste des enfants ayant déjà choisi
            lesEnfantsAyantChoisi.Add(lEnfant);
            lstEnfantChoisi.ItemsSource = lesEnfantsAyantChoisi;
            lstEnfantChoisi.Items.Refresh();

            // on enlève l'enfant de la liste des enfants à choisir
            List<Enfant> desEnfants=lEmploye.getLesEnfants();
            desEnfants.Remove(lEnfant);
            cbEnfant.ItemsSource = desEnfants;
            cbEnfant.Items.Refresh();*/
        }

        private void rafraichirListes()
        {
            // rafraichissement des listes
            // initialisation de la liste déroulante des enfants pour lesquels le jouet n'a pas encore été choisi
            cbEnfant.ItemsSource = lEmploye.getLesEnfantsSansJouet();
            cbEnfant.Items.Refresh();
            // initialisation de la liste déroulante des jouets convenant à l'enfant sélectionné
            if (cbEnfant.Items.Count != 0)
            {
                if (enfantSelectionne == null)
                    cbEnfant.SelectedIndex = 0;
                enfantSelectionne = (Enfant)cbEnfant.SelectedItem;
                CBChoixJouet.ItemsSource = (new JouetDAO()).findByAge(enfantSelectionne.getAge());
            }
            else
                CBChoixJouet.ItemsSource = null;
            CBChoixJouet.Items.Refresh();
            // initialisation de la liste des enfants pour lesquels le jouet a déjà été sélectionné
            lstEnfantChoisi.ItemsSource = lEmploye.getLesEnfantsAvecJouet();
            lstEnfantChoisi.Items.Refresh();
        }

        private void cbEnfant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // mise à jour de la liste des jouets correspondant à l'age de l'enfant
            enfantSelectionne = (Enfant)cbEnfant.SelectedItem;
            if (enfantSelectionne != null)
            {
                CBChoixJouet.ItemsSource = (new JouetDAO()).findByAge(enfantSelectionne.getAge());
            }
        }

        private void btnEnlever_Click(object sender, RoutedEventArgs e)
        {
            if (lstEnfantChoisi.SelectedItem != null)
            {
                // enlever le jouet affecté à cet enfant
                Enfant unEnfant = (Enfant)lstEnfantChoisi.SelectedItem;
                unEnfant.setLeJouet(null);
                rafraichirListes();
            }
        }

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            // ici l'enregistrement dans la bdd soit maj des jouets pour chacun des enfants
            // de la liste lesEnfantsAyantChoisi
            EnfantDAO uneDAO = new EnfantDAO();
            foreach (Enfant unEnfant in lstEnfantChoisi.ItemsSource)
            {
                uneDAO.updateLeJouet(unEnfant);
            }

        }

        private void lstEnfantChoisi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstEnfantChoisi.SelectedItem != null)
            {
                // enlever le jouet affecté à cet enfant
                Enfant unEnfant = (Enfant)lstEnfantChoisi.SelectedItem;
                unEnfant.setLeJouet(null);
                rafraichirListes();
            }
        }

        private void btnDeconnecter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windows = new MainWindow();
            windows.Show();
            this.Close();
        }




    }
}
