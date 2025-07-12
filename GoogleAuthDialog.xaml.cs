using System;
using System.Diagnostics;
using System.Windows;

namespace MemoAI
{
    public partial class GoogleAuthDialog : Window
    {
        private string _authUrl;
        public string? AuthorizationCode { get; private set; }

        public GoogleAuthDialog(string authUrl)
        {
            InitializeComponent();
            _authUrl = authUrl;

            // Enfocar el campo de texto al cargar
            Loaded += (s, e) =>
            {
                AuthCodeTextBox.Focus();
                AuthCodeTextBox.SelectAll();
            };

            // Agregar eventos para manejar teclas y pegado
            AuthCodeTextBox.KeyDown += AuthCodeTextBox_KeyDown;
            AuthCodeTextBox.PreviewKeyDown += AuthCodeTextBox_PreviewKeyDown;
        }

        private void OpenBrowserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Abrir la URL de autorización en el navegador predeterminado
                Process.Start(new ProcessStartInfo
                {
                    FileName = _authUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el navegador: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AuthCodeTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Habilitar el botón de confirmar solo si hay texto en el campo
            ConfirmButton.IsEnabled = !string.IsNullOrWhiteSpace(AuthCodeTextBox.Text);
        }

        private void AuthCodeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Permitir confirmar con Enter si hay texto
            if (e.Key == System.Windows.Input.Key.Enter && !string.IsNullOrWhiteSpace(AuthCodeTextBox.Text))
            {
                ConfirmButton_Click(sender, new RoutedEventArgs());
            }
        }

        private void AuthCodeTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Asegurar que Ctrl+V funcione correctamente
            if (e.Key == System.Windows.Input.Key.V && (System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Control) == System.Windows.Input.ModifierKeys.Control)
            {
                e.Handled = false; // Permitir el pegado
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AuthCodeTextBox.Text))
            {
                AuthorizationCode = AuthCodeTextBox.Text.Trim();
                DialogResult = true;
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
