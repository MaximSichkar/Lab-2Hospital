using Hospital;
using HospitalModel.VM;
using System.Windows;

namespace HospitalUI
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private EditViewModel vm;

        public EditWindow(Appointment appointment = null)
        {
            InitializeComponent();
            vm = new EditViewModel(appointment);
            DataContext = vm;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.Save();
                Close();
            }
            catch
            {
                MessageBox.Show("Помилка в опрацюванні запиту");
            }
        }
    }
}
