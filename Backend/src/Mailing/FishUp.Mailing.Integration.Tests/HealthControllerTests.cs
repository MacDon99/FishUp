using FishUp.Common.DTO;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace FishUp.Mailing.Integration.Tests
{
    public class HealthControllerTests : MailingIntegrationTestBase
    {
        [Fact]
        public async Task Check_Should_Return_SuccessStatusCode()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "mailing/health/check");
            var res = await HttpClient.SendAsync(message);

            res.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CheckJWT_Should_Return_UnauthorizedStatusCode_When_NotLoggedIn()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "mailing/health/checkJwt");
            var res = await HttpClient.SendAsync(message);

            res.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
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
            var message = new HttpRequestMessage(HttpMethod.Get, "mailing/health/checkJwt");
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var res = await HttpClient.SendAsync(message);
            res.EnsureSuccessStatusCode();
        }
    }
}
