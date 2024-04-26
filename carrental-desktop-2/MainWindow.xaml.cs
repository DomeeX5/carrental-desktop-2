using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace carrental_desktop_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseHandler handler;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                handler = new DatabaseHandler();
                cars.ItemsSource = handler.ReadData();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Nem sikerült kapcsolódni az adatbázishoz, a program leáll");
                this.Close();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Car selected = cars.SelectedItem as Car;
            if (selected == null)
            {
                MessageBox.Show("Törléshez vcálasszon ki egy elemet!");
                return;
            } 
            else
            {
                MessageBoxResult result = MessageBox.Show("Biztos szeretné törölni a kiválasztott autót?", "Törlés", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (handler.DeleteById(selected.Id))
                    {
                        MessageBox.Show("Sikeres törlés", "Törlés", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Hiba történt törlés során!");
                    }
                }
                cars.ItemsSource = handler.ReadData();
            }
        }

        
    }
}