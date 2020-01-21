using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Chambers.BlackJack.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Chambers.BlackJack.IntegrationTests
{
    public class IntegrationTestForGameController 
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTestForGameController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Start_Successfully()
        {
            var client = _factory.CreateClient();
            var response = await StartTheGame(client);
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        private static async Task<HttpResponseMessage> StartTheGame(HttpClient client)
        {
            return await client.PostAsync("game/start", new StringContent(string.Empty));
        }

        [Fact]
        public async Task Hit_Successfully()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("game/hit");
            response.EnsureSuccessStatusCode();
        }
        
        
        [Fact]
        public async Task Stick_Successfully()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("game/stick");
            response.EnsureSuccessStatusCode();
            var result = DeSerialize<ResultModel>(await response.Content.ReadAsStringAsync());
            result.GameStatus.Should().Be(GameStatus.Completed);
        }        
        
        [Fact]
        public async Task After_The_Stick_Next_Hit_Should_Return_Same()
        {
            var client = _factory.CreateClient();
            await StartTheGame(client);
            var response =  await client.GetAsync("game/stick");
            var result = DeSerialize<ResultModel>(await response.Content.ReadAsStringAsync());
            
            result.GameStatus.Should().Be(GameStatus.Completed);
            
            response = await client.GetAsync("game/hit");
            var resultAfterHit = DeSerialize<ResultModel>(await response.Content.ReadAsStringAsync());
            resultAfterHit.GameStatus.Should().Be(GameStatus.Completed);
        }

        private static T DeSerialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}