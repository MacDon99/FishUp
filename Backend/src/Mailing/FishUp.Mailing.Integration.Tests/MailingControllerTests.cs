using FishUp.Common.DTO;
using FishUp.Mailing.Messages.Commands;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FishUp.Mailing.Integration.Tests
{
    public class MailingControllerTests : MailingIntegrationTestBase
    {
        public MailingControllerTests()
        {
        }

        [Fact]
        public async Task CheckJWT_Should_Return_SuccessStatusCode_When_LoggedIn()
        {
            var accessToken = GetAccessToken(new UserDTO()
            {
                Id = "TestID",
                Role = "TestRole",
                UserName = "TestUser"
            });
            var email = new SendMessageCommand()
            { 
                From = "donczyk.maciej@gmail.com",
                To = "maciej.donczyk@primaris.eu",
                Subject = "Temat",
                Content = "Treść emaila"
            };
            var message = new HttpRequestMessage(HttpMethod.Post, "mailing/mail");
            message.Content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var res = await HttpClient.SendAsync(message);
            res.EnsureSuccessStatusCode();
        }
    }
}
