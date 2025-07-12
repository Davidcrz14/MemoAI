using System.Windows;
using System;
using System.Windows.Input;
using MemoAI.Pages;
using System.Diagnostics;

namespace MemoAI
{
    public partial class MainWindow : Window
    {
        private InboxPage _inboxPage;
        private string _authCode;
        
        public MainWindow()
        {
            InitializeComponent();
            // Verificar autenticación antes de cargar la página principal
            CheckGoogleAuthentication();
        }

        private async void CheckGoogleAuthentication()
        {
            try
            {
                var authUrl = GoogleConfig.GetAuthUrl();

                // Mostrar diálogo para obtener código de autorización
                var authDialog = new GoogleAuthDialog(authUrl);
                var result = authDialog.ShowDialog();

                if (result == true && !string.IsNullOrEmpty(authDialog.AuthorizationCode))
                {
                    _authCode = authDialog.AuthorizationCode;
                    
                    // Crear y cargar la página de bandeja de entrada después de la autenticación
                    _inboxPage = new InboxPage();
                    MainFrame.Navigate(_inboxPage);
                    
                    // Cargar los correos automáticamente
                    await _inboxPage.LoadEmailsFromAuth(_authCode);
                    
                    // Actualizar estado visual del botón
                    UpdateNavigationButtons("Inbox");
                }
                else
                {
                    MessageBox.Show("La autenticación es requerida para usar la aplicación.", "Autenticación requerida", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la autenticación: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void InboxButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (_inboxPage == null)
            {
                _inboxPage = new InboxPage();
                if (!string.IsNullOrEmpty(_authCode))
                {
                    _ = _inboxPage.LoadEmailsFromAuth(_authCode);
                }
            }
            MainFrame.Navigate(_inboxPage);
            UpdateNavigationButtons("Inbox");
        }

        private void TasksButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new TasksPage());
            UpdateNavigationButtons("Tasks");
        }

        private void CalendarButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new CalendarPage());
            UpdateNavigationButtons("Calendar");
        }

        private void SummaryButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new SummaryPage());
            UpdateNavigationButtons("Summary");
        }

        private void AIButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new AIPage());
            UpdateNavigationButtons("AI");
        }
        
        private void UpdateNavigationButtons(string activeButton)
        {
            // Resetear todos los botones
            InboxButton.Background = System.Windows.Media.Brushes.Transparent;
            TasksButton.Background = System.Windows.Media.Brushes.Transparent;
            CalendarButton.Background = System.Windows.Media.Brushes.Transparent;
            SummaryButton.Background = System.Windows.Media.Brushes.Transparent;
            AIButton.Background = System.Windows.Media.Brushes.Transparent;
            
            // Activar el botón seleccionado
            switch (activeButton)
            {
                case "Inbox":
                    InboxButton.Background = (System.Windows.Media.SolidColorBrush)FindResource("PrimaryBlue");
                    break;
                case "Tasks":
                    TasksButton.Background = (System.Windows.Media.SolidColorBrush)FindResource("PrimaryBlue");
                    break;
                case "Calendar":
                    CalendarButton.Background = (System.Windows.Media.SolidColorBrush)FindResource("PrimaryBlue");
                    break;
                case "Summary":
                    SummaryButton.Background = (System.Windows.Media.SolidColorBrush)FindResource("PrimaryBlue");
                    break;
                case "AI":
                    AIButton.Background = (System.Windows.Media.SolidColorBrush)FindResource("PrimaryBlue");
                    break;
            }
        }
    }
}
