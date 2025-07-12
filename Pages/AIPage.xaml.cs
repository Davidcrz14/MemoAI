using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoAI.Pages
{
    public partial class AIPage : Page
    {
        private string placeholderText = "Escribe tu mensaje aquí...";

        public AIPage()
        {
            InitializeComponent();
        }

        private void NewChat_Click(object sender, MouseButtonEventArgs e)
        {
            // Aquí se implementaría la funcionalidad para iniciar una nueva conversación
            MessageBox.Show("Funcionalidad para nueva conversación en desarrollo", "Nueva Conversación", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private void MessageTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Limpiar el placeholder cuando el usuario hace clic en el TextBox
            if (MessageTextBox.Text == placeholderText)
            {
                MessageTextBox.Text = "";
                MessageTextBox.Foreground = (System.Windows.Media.Brush)FindResource("TextPrimary");
            }
        }

        private void MessageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Restaurar el placeholder si el TextBox está vacío
            if (string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                MessageTextBox.Text = placeholderText;
                MessageTextBox.Foreground = (System.Windows.Media.Brush)FindResource("TextTertiary");
            }
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Enviar mensaje al presionar Enter
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage_Click(object sender, MouseButtonEventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            // Aquí se implementaría la funcionalidad para enviar el mensaje a la IA
            if (!string.IsNullOrWhiteSpace(MessageTextBox.Text) && MessageTextBox.Text != placeholderText)
            {
                string message = MessageTextBox.Text;
                MessageBox.Show($"Mensaje enviado: {message}\n\nFuncionalidad de IA en desarrollo", "Mensaje Enviado", MessageBoxButton.OK, MessageBoxImage.Information);

                // Limpiar el TextBox después de enviar
                MessageTextBox.Text = placeholderText;
                MessageTextBox.Foreground = (System.Windows.Media.Brush)FindResource("TextTertiary");
            }
        }
    }
}
