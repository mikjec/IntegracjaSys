using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JWTClient
{
    public partial class Form1 : Form
    {
        // Inicjalizujemy klienta HTTP do komunikacji z API
        private static readonly HttpClient _client = new HttpClient();
        private string _token = string.Empty;

        public Form1()
        {
            InitializeComponent();

            // Ustawiamy bazowy adres API (upewnij się, że port to 8080)
            _client.BaseAddress = new Uri("http://localhost:8080/");
        }

        // ======================================================================
        // GŁÓWNA LOGIKA APLIKACJI
        // ======================================================================

        // Metoda do logowania (podpięta pod btnLogin)
        private async void button1_Click(object sender, EventArgs e)
        {
            var loginData = new
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            try
            {
                var response = await _client.PostAsJsonAsync("api/users/authenticate", loginData);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();

                    using (JsonDocument doc = JsonDocument.Parse(jsonResult))
                    {
                        _token = doc.RootElement.GetProperty("token").GetString();
                    }

                    txtToken.Text = _token;
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                    txtResult.Text = "Zalogowano pomyślnie!";
                }
                else
                {
                    txtResult.Text = "Błąd logowania: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia: " + ex.Message);
            }
        }

        // Pobieranie LICZBY użytkowników (podpięte pod btnGetCount w designerze)
        private async void button1_Click_1(object sender, EventArgs e)
        {
            await SendSecuredRequest("api/users/count");
        }

        // Pobieranie MAGICZNEJ LICZBY pierwszej (podpięte pod btnGetPrime w designerze)
        private async void button1_Click_2(object sender, EventArgs e)
        {
            await SendSecuredRequest("api/numbers");
        }

        // Pobieranie WSZYSTKICH użytkowników (podpięte pod btnGetUsers w designerze)
        private async void btnGethuj_Click(object sender, EventArgs e)
        {
            await SendSecuredRequest("api/users");
        }

        // Uniwersalna metoda do wysyłania uderzeń na zasoby zabezpieczone tokenem
        private async Task SendSecuredRequest(string endpoint)
        {
            if (string.IsNullOrEmpty(_token))
            {
                MessageBox.Show("Najpierw musisz się zalogować i pobrać token!");
                return;
            }

            try
            {
                var response = await _client.GetAsync(endpoint);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    txtResult.Text = $"Sukces!\r\nOdpowiedź:\r\n{content}";
                }
                else
                {
                    txtResult.Text = $"Odmowa dostępu lub błąd ({response.StatusCode}).\r\nSzczegóły: {content}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        // ======================================================================
        // PUSTE METODY WYMAGANE PRZEZ DESIGNER
        // (Muszą zostać, inaczej Form1.Designer.cs wyrzuci błąd kompilacji)
        // ======================================================================

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
    }
}