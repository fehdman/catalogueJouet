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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatalogueDeJouet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username=TBUser.Text;
            string password=TBPassword.Text;
            EmployeDAO DaoEmploye = new EmployeDAO();
            Employe unEmploye = DaoEmploye.findByLogin(username, password);
            bool admin=unEmploye.getAdmin();
            try
            {
                if (unEmploye != null)
                {
                    if (admin == true)
                    {
                        WAdmin windows=new WAdmin();
                        windows.Show();
                    }
                    else
                    {
                        WChoixJouet windows = new WChoixJouet(unEmploye);
                        windows.Show();
                    }
                    this.Close();
                }
                else
                {
                    lEtat.Content = "Nom d'utilisateur ou mot de passe incorrecte";
                    TBPassword.Text = "";
                }
            }
            catch (Exception except)
            {
                MessageBox.Show("Exception " + except.StackTrace);
                //lEtat.Content = "Connexion impossible";
            }
        }

        private void bQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TBUser_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TBPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        
    }
}
