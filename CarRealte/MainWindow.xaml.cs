using CarRealte.DB;
using CarRealte.ViewModel;
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

namespace CarRealte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainwindowVM();
            _addDataCar();
            _addDataAllUser();
            _addDataEmploee();
            _addDataCustomer();
            _addDataRetail();
        }
        private void _addDataCar()
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var car = db.CarDetails.ToList();
                CarAll.ItemsSource = car;
            }
        }
        private void _addDataAllUser()
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var user = db.ПользователиИИнформацияs.ToList();
                UserAll.ItemsSource = user;
            }
        }
        private void _addDataEmploee()
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var emploees = db.ПользователиИДолжностиs.ToList();
                Emploee.ItemsSource = emploees;
            }
        }
        private void _addDataCustomer()
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var customer = db.Клиентs.ToList();
                Customer.ItemsSource = customer;
            }
        }
        private void _addDataRetail()
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var retail = db.ПредставлениеАрендаs.ToList();
                Retail.ItemsSource = retail;
            }
        }
    }
}