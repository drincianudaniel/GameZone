using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.IntegrationTests
{
    public class ReplyControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public ReplyControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Replies_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/replies");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Replies_ShouldReturnExistingReply()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/replies");

            var result = await response.Content.ReadAsStringAsync();
            var replies = JsonConvert.DeserializeObject<List<ReplyDto>>(result);

            var reply = replies.FirstOrDefault(x => x.Id == Guid.Parse("c41a1c51-a15e-4346-9ad6-cdc2cd017274"));
            ReplyAsserts(reply);
        }

        [Fact]
        public async Task Get_Replies_By_Id_ShouldReturnExistingReply()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/replies/c41a1c51-a15e-4346-9ad6-cdc2cd017274");

            var result = await response.Content.ReadAsStringAsync();
            var reply = JsonConvert.DeserializeObject<ReplyDto>(result);

            ReplyAsserts(reply);
        }

        [Fact]
        public async Task Post_Replies_ShouldReturnCreatedResponse()
        {
            var reply = new ReplyViewModel
            {
                Content = "i liked the game test reply",
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                CommentId = new Guid("94842162-2252-43b2-9c2a-807a86a4393b")
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/replies",
                new StringContent(JsonConvert.SerializeObject(reply), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Reply_ShouldReturnCreatedReply()
        {
            var newReply = new ReplyViewModel
            {
                Content = "i liked the game test reply",
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                CommentId = new Guid("94842162-2252-43b2-9c2a-807a86a4393b")
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/replies",
                new StringContent(JsonConvert.SerializeObject(newReply), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var reply = JsonConvert.DeserializeObject<CommentDto>(result);

            Assert.Equal(newReply.Content, reply.Content);
            Assert.Equal("UserName", reply.Username);
        }

        [Fact]
        public async Task Put_Reply_ShouldReturnUpdatedReply()
        {
            var newReply = new ReplyViewModel
            {
                Content = "i liked the game test reply test content edit",
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                CommentId = new Guid("94842162-2252-43b2-9c2a-807a86a4393b")
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/replies/c41a1c51-a15e-4346-9ad6-cdc2cd017274",
                new StringContent(JsonConvert.SerializeObject(newReply), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var reply = JsonConvert.DeserializeObject<ReplyDto>(result);

            Assert.Equal(new Guid("c41a1c51-a15e-4346-9ad6-cdc2cd017274"), reply.Id);
            Assert.Equal(newReply.Content, reply.Content);
        }

        [Fact]
        public async Task Delete_Reply_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/replies/c41a1c51-a15e-4346-9ad6-cdc2cd017274");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void ReplyAsserts(ReplyDto reply)
        {
            Assert.Equal("reply to comment", reply.Content);
            Assert.Equal("UserName", reply.Username);
        }
    }
}
