using System.Windows;
using System.Windows.Controls;

namespace MemoAI.Pages
{
    public partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar nueva tarea", "Nueva Tarea", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
