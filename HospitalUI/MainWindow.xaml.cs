using HospitalModel;
using System.Windows;
using System.Windows.Input;

namespace HospitalUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var win = new EditWindow();
            win.ShowDialog();
            vm.LoadData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            vm.Delete();
        }

        private void Edit_Click(object sender, MouseButtonEventArgs e)
        {
            if (vm.SelectedAppointment != null)
            {
                var win = new EditWindow(vm.SelectedAppointment);
                win.ShowDialog();
                vm.LoadData();
            }
        }
    }
}