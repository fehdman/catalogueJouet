using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CatalogueDeJouet
{
    /// <summary>
    /// Logique d'interaction pour WAdmin.xaml
    /// </summary>
    public partial class WAdmin : Window
    {
        List<Employe> lesEmployes;
        public WAdmin()
        {

            InitializeComponent();
            
            // initialiser ici le datagrid avec les infos des employés, de leurs enfants et des jouets choisis
            // une collection contenant les employés
            lesEmployes=((new EmployeDAO()).findAll());
            dtAffichage.ItemsSource = lesEmployes;
           
          
        }

        private void btnNbJouets_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("clic bouton");
            dtAffichage.ItemsSource = ((new JouetDAO()).findNbJouet());
            dtAffichage.Items.Refresh();
            dtAffichage.AutoGenerateColumns = false;
            dtAffichage.Columns.Clear();
            dtAffichage.Columns.Add(new DataGridTextColumn
            {
                Header="nom du jouet",
                Binding = new Binding("Key")
            });
            dtAffichage.Columns.Add(new DataGridTextColumn
            {
                Header = "nombre de jouet",
                Binding = new Binding("Value")
            });
        }

        private void btnNbJouetCateg_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("clic bouton");
            dtAffichage.ItemsSource = ((new CategorieDAO()).findNbJouetCateg());
            dtAffichage.Items.Refresh();
            dtAffichage.AutoGenerateColumns = false;
            dtAffichage.Columns.Clear();
            dtAffichage.Columns.Add(new DataGridTextColumn
            {
                Header = "nom de la categorie",
                Binding = new Binding("Key")
            });
            dtAffichage.Columns.Add(new DataGridTextColumn
            {
                Header = "nombre de jouets demandés",
                Binding = new Binding("Value")
            });
        }

        private void btnDeconnecter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow windows = new MainWindow();
            windows.Show();
            this.Close();
        }

       
    }
}

