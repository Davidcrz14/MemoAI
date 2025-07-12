using System.Windows;
using System.Windows.Input;

using System.Windows.Controls;

namespace MemoAI.Pages
{
    public partial class SummaryPage : Page
    {
        public SummaryPage()
        {
            InitializeComponent();
        }

        private void GenerateSummary_Click(object sender, MouseButtonEventArgs e)
        {
            // Aquí se implementaría la funcionalidad para generar un nuevo resumen
            MessageBox.Show("Funcionalidad para generar resumen en desarrollo", "Generar Resumen", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
