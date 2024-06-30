using System.Net.Http;
using System.Text;


namespace FastFiles.Services
{
    public class MailerSendRepository : IMailerSendRepository
    {
        private readonly HttpClient _httpClient;
        public MailerSendRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SendMail(string to, string user)
        {
            try
            {
                var smtp = "MS_XPsRZo@trial-yzkq340ooe34d796.mlsender.net";

                var urlApí = "https://api.mailersend.com/v1/email";

                var token = "mlsn.924a9c77f2e5b6177149eaea357e7172cd89d0b0514385e0fdf0d3e70371e17b";

                var requestBody = new
                {
                    from = new
                    {
                        email = smtp
                    },
                    to = new[]
                    {
                        new {
                            email = to
                        }
                    },
                    subject = "Bienvenid@ a FastFiles!",
                    variables = new[]{
                        new {
                            email = to,
                            substitutions = new []{
                                new {
                                    var = "name",
                                    value =  user
                                }
                            }
                        }
                    },
                    template_id = "x2p0347xnj9gzdrn"
                };

                var body = System.Text.Json.JsonSerializer.Serialize(requestBody);

                var request = new HttpRequestMessage(HttpMethod.Post, urlApí)
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Authorization", $"Bearer {token}");
                HttpResponseMessage response = _httpClient.Send(request);
                Console.WriteLine(response);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}