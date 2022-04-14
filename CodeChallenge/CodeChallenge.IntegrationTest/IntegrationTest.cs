using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Persistence;
using CodeChallenge.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenge.IntegrationTest
{
    public class IntegrationTest
    {
        private readonly HttpClient TestClient;

        public IntegrationTest()
        {
            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(CodeChallengeDbContext));
                        services.AddDbContext<CodeChallengeDbContext>(opts =>
                        {
                            opts.UseInMemoryDatabase("TestDb");
                        });
                    });
                });

            TestClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllPermissionsApiEndpoint()
        {
            var response = await TestClient.GetAsync("/api/permission/all");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task RequestPermissionsApiEndpoint()
        {
            var postObject = new RequestPermissionCommand
            {
                IdPermissionType = 1,
                EmployeeForename = "Jon",
                EmployeeSurname = "Doe"
            };

            var json = JsonConvert.SerializeObject(postObject);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/permission/request")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await TestClient.SendAsync(httpRequestMessage);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ModifyPermissionsApiEndpoint()
        {
            var postObject = new ModifyPermissionCommand
            {
                Id = 1,
                IdPermissionType = 1,
                EmployeeForename = "Ezequiel",
                EmployeeSurname = "Tosi"
            };

            var json = JsonConvert.SerializeObject(postObject);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, "/api/permission/modify")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await TestClient.SendAsync(httpRequestMessage);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseAsString = await response.Content.ReadAsStringAsync();
            int modifyId = JsonConvert.DeserializeObject<int>(responseAsString);

            modifyId.Should().Be(postObject.Id.Value);
        }
    }
}
