using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoAI.Pages
{
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
        }

        private void AddEvent_Click(object sender, MouseButtonEventArgs e)
        {
            // Aquí se implementaría la funcionalidad para añadir un nuevo evento
            MessageBox.Show("Funcionalidad para añadir evento en desarrollo", "Nuevo Evento", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
