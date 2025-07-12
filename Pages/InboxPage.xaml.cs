using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Newtonsoft.Json.Linq;

namespace MemoAI.Pages
{
    public partial class InboxPage : Page
    {
        private GmailService _gmailService;
        private string _currentFilter = "INBOX";
        private string _authCode;
        
        public InboxPage()
        {
            InitializeComponent();
        }

        public async Task LoadEmailsFromAuth(string authCode)
        {
            _authCode = authCode;
            await LoadEmails(authCode);
        }

        private async Task LoadEmails(string authCode)
        {
            try
            {
                // Si ya tenemos un servicio autenticado, lo reutilizamos
                if (_gmailService == null)
                {
                    // Canjear código de autorización por token de acceso
                    var token = await GetAccessToken(authCode);
                    if (token == null)
                    {
                        MessageBox.Show("No se pudo obtener el token de acceso.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var credential = GoogleCredential.FromAccessToken(token.Value<string>("access_token"));
                    _gmailService = new GmailService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "MemoAI",
                    });
                }

                // Obtener lista de correos usando el servicio existente
                
                var request = _gmailService.Users.Messages.List("me");
                request.MaxResults = 100; // Mostrar hasta 100 correos
                request.LabelIds = _currentFilter;
                var response = await request.ExecuteAsync();
                
                await UpdateEmailCounts();

                EmailListPanel.Children.Clear();

                if (response.Messages != null && response.Messages.Count > 0)
                {
                    var emails = new List<Email>();
                    foreach (var messageItem in response.Messages)
                    {
                        var message = await _gmailService.Users.Messages.Get("me", messageItem.Id).ExecuteAsync();
                        var email = new Email(message);
                        emails.Add(email);
                    }
                    
                    // Ordenar por fecha descendente (más reciente primero)
                    var sortedEmails = emails.OrderByDescending(e => e.DateParsed).ToList();
                    
                    foreach (var email in sortedEmails)
                    {
                        EmailListPanel.Children.Add(CreateEmailBorder(email));
                    }
                }
                else
                {
                    var noEmailsText = new TextBlock 
                    { 
                        Text = "No se encontraron correos.", 
                        Margin = new Thickness(24),
                        FontSize = 16,
                        Foreground = (SolidColorBrush)FindResource("TextSecondary"),
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    EmailListPanel.Children.Add(noEmailsText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los correos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task<JObject?> GetAccessToken(string authCode)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("code", authCode),
                    new KeyValuePair<string, string>("client_id", GoogleConfig.ClientId),
                    new KeyValuePair<string, string>("client_secret", GoogleConfig.ClientSecret),
                    new KeyValuePair<string, string>("redirect_uri", GoogleConfig.RedirectUri),
                    new KeyValuePair<string, string>("grant_type", "authorization_code")
                });

                var response = await client.PostAsync("https://oauth2.googleapis.com/token", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JObject.Parse(responseString);
                }

                return null;
            }
        }

        private Border CreateEmailBorder(Email email)
        {
            // Crear la UI para un correo individual
            var border = new Border
            {
                Background = (SolidColorBrush)FindResource("BackgroundColor"),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(24, 20, 24, 20),
                Margin = new Thickness(0, 0, 0, 16),
                Cursor = Cursors.Hand
            };

            // Agregar evento de clic para abrir el correo
            border.MouseLeftButtonDown += (sender, e) => OpenEmail(email);
            
            // Agregar menú contextual para eliminar
            var contextMenu = new ContextMenu();
            var deleteMenuItem = new MenuItem { Header = "🗑️ Eliminar correo" };
            deleteMenuItem.Click += async (sender, e) => await DeleteEmail(email.Id);
            contextMenu.Items.Add(deleteMenuItem);
            border.ContextMenu = contextMenu;

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            // Avatar
            var avatarBorder = new Border
            {
                Background = (SolidColorBrush)FindResource("PrimaryBlue"),
                CornerRadius = new CornerRadius(20),
                Width = 40,
                Height = 40,
                Margin = new Thickness(0, 0, 16, 0)
            };
            avatarBorder.Child = new TextBlock
            {
                Text = email.From.Substring(0, 1).ToUpper(),
                FontSize = 14,
                FontWeight = FontWeights.Medium,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(avatarBorder, 0);

            // Contenido del correo
            var contentPanel = new StackPanel();
            Grid.SetColumn(contentPanel, 1);
            
            // Botón de eliminar
            var deleteButton = new Button
            {
                Content = "🗑️",
                Width = 30,
                Height = 30,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Cursor = Cursors.Hand,
                FontSize = 14,
                Margin = new Thickness(8, 0, 0, 0),
                ToolTip = "Eliminar correo"
            };
            deleteButton.Click += async (sender, e) => 
            {
                e.Handled = true;
                await DeleteEmail(email.Id);
            };
            Grid.SetColumn(deleteButton, 2);

            var headerGrid = new Grid();
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            var fromText = new TextBlock
            {
                Text = email.From,
                FontSize = 16,
                FontWeight = FontWeights.SemiBold,
                Foreground = (SolidColorBrush)FindResource("TextPrimary")
            };
            Grid.SetColumn(fromText, 0);

            var dateText = new TextBlock
            {
                Text = email.Date,
                FontSize = 12,
                Foreground = (SolidColorBrush)FindResource("TextSecondary")
            };
            Grid.SetColumn(dateText, 1);

            headerGrid.Children.Add(fromText);
            headerGrid.Children.Add(dateText);

            var subjectText = new TextBlock
            {
                Text = email.Subject,
                FontSize = 14,
                FontWeight = FontWeights.Medium,
                Foreground = (SolidColorBrush)FindResource("TextPrimary"),
                Margin = new Thickness(0, 8, 0, 4)
            };

            var snippetText = new TextBlock
            {
                Text = email.Snippet,
                FontSize = 13,
                Foreground = (SolidColorBrush)FindResource("TextSecondary"),
                TextTrimming = TextTrimming.CharacterEllipsis,
                MaxWidth = 400
            };

            contentPanel.Children.Add(headerGrid);
            contentPanel.Children.Add(subjectText);
            contentPanel.Children.Add(snippetText);

            grid.Children.Add(avatarBorder);
            grid.Children.Add(contentPanel);
            grid.Children.Add(deleteButton);

            border.Child = grid;
            return border;
        }

        private void OpenEmail(Email email)
        {
            try
            {
                // Crear ventana para mostrar el correo completo
                var emailWindow = new Window
                {
                    Title = $"Correo: {email.Subject}",
                    Width = 800,
                    Height = 600,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = Window.GetWindow(this)
                };

                var scrollViewer = new ScrollViewer
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    Padding = new Thickness(24)
                };

                var contentPanel = new StackPanel();

                // Encabezado del correo
                var headerPanel = new StackPanel { Margin = new Thickness(0, 0, 0, 24) };

                var subjectText = new TextBlock
                {
                    Text = email.Subject,
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 16),
                    TextWrapping = TextWrapping.Wrap
                };

                var fromText = new TextBlock
                {
                    Text = $"De: {email.From}",
                    FontSize = 14,
                    Margin = new Thickness(0, 0, 0, 8),
                    Foreground = new SolidColorBrush(Colors.Gray)
                };

                var dateText = new TextBlock
                {
                    Text = $"Fecha: {email.Date}",
                    FontSize = 14,
                    Margin = new Thickness(0, 0, 0, 16),
                    Foreground = new SolidColorBrush(Colors.Gray)
                };

                var separator = new Border
                {
                    Height = 1,
                    Background = new SolidColorBrush(Colors.LightGray),
                    Margin = new Thickness(0, 0, 0, 24)
                };

                headerPanel.Children.Add(subjectText);
                headerPanel.Children.Add(fromText);
                headerPanel.Children.Add(dateText);
                headerPanel.Children.Add(separator);

                // Contenido del correo
                var bodyText = new TextBlock
                {
                    Text = email.Snippet,
                    FontSize = 14,
                    TextWrapping = TextWrapping.Wrap,
                    LineHeight = 22
                };

                contentPanel.Children.Add(headerPanel);
                contentPanel.Children.Add(bodyText);

                scrollViewer.Content = contentPanel;
                emailWindow.Content = scrollViewer;

                emailWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el correo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private async void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {
            await RefreshEmails();
        }
        
        private async void InboxFilter_Click(object sender, MouseButtonEventArgs e)
        {
            _currentFilter = "INBOX";
            UpdateFilterButtons("INBOX");
            await RefreshEmails();
        }
        
        private async void SentFilter_Click(object sender, MouseButtonEventArgs e)
        {
            _currentFilter = "SENT";
            UpdateFilterButtons("SENT");
            await RefreshEmails();
        }
        
        private async Task RefreshEmails()
        {
            if (_gmailService != null)
            {
                await LoadEmailsWithExistingService();
            }
            else if (!string.IsNullOrEmpty(_authCode))
            {
                await LoadEmails(_authCode);
            }
            else
            {
                MessageBox.Show("No hay sesión activa. Por favor, inicia sesión nuevamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        private async Task LoadEmailsWithExistingService()
        {
            try
            {
                var request = _gmailService.Users.Messages.List("me");
                request.MaxResults = 100;
                request.LabelIds = _currentFilter;
                var response = await request.ExecuteAsync();
                
                await UpdateEmailCounts();

                EmailListPanel.Children.Clear();

                if (response.Messages != null && response.Messages.Count > 0)
                {
                    var emails = new List<Email>();
                    foreach (var messageItem in response.Messages)
                    {
                        var message = await _gmailService.Users.Messages.Get("me", messageItem.Id).ExecuteAsync();
                        var email = new Email(message);
                        emails.Add(email);
                    }
                    
                    // Ordenar por fecha descendente (más reciente primero)
                    var sortedEmails = emails.OrderByDescending(e => e.DateParsed).ToList();
                    
                    foreach (var email in sortedEmails)
                    {
                        EmailListPanel.Children.Add(CreateEmailBorder(email));
                    }
                }
                else
                {
                    var noEmailsText = new TextBlock 
                    { 
                        Text = "No se encontraron correos.", 
                        Margin = new Thickness(24),
                        FontSize = 16,
                        Foreground = (SolidColorBrush)FindResource("TextSecondary"),
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    EmailListPanel.Children.Add(noEmailsText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los correos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void UpdateFilterButtons(string activeFilter)
         {
             // Resetear todos los filtros
             InboxFilter.Background = (SolidColorBrush)FindResource("SurfaceColor");
             SentFilter.Background = (SolidColorBrush)FindResource("SurfaceColor");
             
             // Resetear colores de texto
             var inboxStack = InboxFilter.Child as StackPanel;
             var sentStack = SentFilter.Child as StackPanel;
             
             if (inboxStack != null)
             {
                 foreach (TextBlock tb in inboxStack.Children.OfType<TextBlock>())
                 {
                     tb.Foreground = (SolidColorBrush)FindResource("TextPrimary");
                 }
             }
             
             if (sentStack != null)
             {
                 foreach (TextBlock tb in sentStack.Children.OfType<TextBlock>())
                 {
                     tb.Foreground = (SolidColorBrush)FindResource("TextPrimary");
                 }
             }
             
             // Activar el filtro seleccionado
             if (activeFilter == "INBOX")
             {
                 InboxFilter.Background = (SolidColorBrush)FindResource("PrimaryBlue");
                 if (inboxStack != null)
                 {
                     foreach (TextBlock tb in inboxStack.Children.OfType<TextBlock>())
                     {
                         tb.Foreground = Brushes.White;
                     }
                 }
             }
             else if (activeFilter == "SENT")
             {
                 SentFilter.Background = (SolidColorBrush)FindResource("PrimaryBlue");
                 if (sentStack != null)
                 {
                     foreach (TextBlock tb in sentStack.Children.OfType<TextBlock>())
                     {
                         tb.Foreground = Brushes.White;
                     }
                 }
             }
         }
        
        private async Task UpdateEmailCounts()
        {
            try
            {
                if (_gmailService != null)
                {
                    // Contar correos recibidos
                    var inboxRequest = _gmailService.Users.Messages.List("me");
                    inboxRequest.LabelIds = "INBOX";
                    var inboxResponse = await inboxRequest.ExecuteAsync();
                    int inboxCount = inboxResponse.Messages?.Count ?? 0;
                    
                    // Contar correos enviados
                    var sentRequest = _gmailService.Users.Messages.List("me");
                    sentRequest.LabelIds = "SENT";
                    var sentResponse = await sentRequest.ExecuteAsync();
                    int sentCount = sentResponse.Messages?.Count ?? 0;
                    
                    // Actualizar UI
                    InboxCountText.Text = $"{inboxCount} correos";
                    SentCountText.Text = $"{sentCount} correos";
                }
            }
            catch (Exception ex)
            {
                // Error silencioso para no interrumpir la carga
                System.Diagnostics.Debug.WriteLine($"Error actualizando contadores: {ex.Message}");
            }
        }
        
        private async Task DeleteEmail(string emailId)
        {
            try
            {
                var result = MessageBox.Show("¿Estás seguro de que quieres eliminar este correo?", 
                    "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    
                if (result == MessageBoxResult.Yes && _gmailService != null)
                {
                    // Mover el correo a la papelera
                    await _gmailService.Users.Messages.Trash("me", emailId).ExecuteAsync();
                    
                    // Recargar la lista de correos
                    await RefreshEmails();
                    
                    MessageBox.Show("Correo eliminado correctamente.", "Éxito", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el correo: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Email
    {
        public string Id { get; }
        public string From { get; }
        public string Subject { get; }
        public string Snippet { get; }
        public string Date { get; }
        public DateTime DateParsed { get; }

        public Email(Message message)
        {
            Id = message.Id;
            Snippet = message.Snippet;

            From = message.Payload.Headers.FirstOrDefault(h => h.Name == "From")?.Value ?? "Desconocido";
            Subject = message.Payload.Headers.FirstOrDefault(h => h.Name == "Subject")?.Value ?? "(Sin asunto)";
            string dateStr = message.Payload.Headers.FirstOrDefault(h => h.Name == "Date")?.Value;

            if (DateTime.TryParse(dateStr, out DateTime parsedDate))
            {
                DateParsed = parsedDate;
                Date = parsedDate.ToString("dd MMM");
            }
            else
            {
                DateParsed = DateTime.MinValue;
                Date = "Fecha desconocida";
            }
        }
    }
}
