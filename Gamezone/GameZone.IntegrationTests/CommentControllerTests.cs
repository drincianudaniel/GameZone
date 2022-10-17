using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.IntegrationTests
{
    public class CommentControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public CommentControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Comments_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/comments");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Comments_ShouldReturnExistingComment()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/comments");

            var result = await response.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<CommentDto>>(result);

            var comment = comments.FirstOrDefault(x => x.Id == Guid.Parse("94842162-2252-43b2-9c2a-807a86a4393b"));
            CommentAsserts(comment);
        }

        [Fact]
        public async Task Get_Comments_By_Id_ShouldReturnExistingComment()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/comments/94842162-2252-43b2-9c2a-807a86a4393b");

            var result = await response.Content.ReadAsStringAsync();
            var comment = JsonConvert.DeserializeObject<CommentDto>(result);

            CommentAsserts(comment);
        }

        [Fact]
        public async Task Post_Comments_ShouldReturnCreatedResponse()
        {
            dynamic data = new ExpandoObject();
            data.Id = "f535d0fc-020c-4549-8dce-6496ceedcd22";
            data.UserName = "bryan778";
            data.Roles = new[] { "Admin", "User" };

            var comment = new CommentViewModel
            {
                Content = "i liked the game test comment",
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                GameId = new Guid("2df905bf-8205-4466-942d-713a689431c1")
            };

            var client = _factory.CreateClient();
            client.SetFakeBearerToken((object)data);

            var response = await client.PostAsync("/api/comments",
                new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Comment_ShouldReturnCreatedComment()
        {
            var newComment = new CommentViewModel
            {
                Content = "i liked the game test comment",
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                GameId = new Guid("2df905bf-8205-4466-942d-713a689431c1")
            };

            var client = _factory.CreateClient();

            var response = await client.PostAsync("/api/comments",
                new StringContent(JsonConvert.SerializeObject(newComment), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var comment = JsonConvert.DeserializeObject<CommentDto>(result);

            Assert.Equal(newComment.Content, comment.Content);
            Assert.Equal("UserName", comment.UserName);
            Assert.Equal("Minecraft", comment.Gamename);
        }

        [Fact]
        public async Task Put_Comment_ShouldReturnUpdatedcomment()
        {
            var newComment = new CommentViewModel
            {
                Content = "Updated comment content test content",
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                GameId = new Guid("2df905bf-8205-4466-942d-713a689431c1")
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/comments/94842162-2252-43b2-9c2a-807a86a4393b",
                new StringContent(JsonConvert.SerializeObject(newComment), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var comment = JsonConvert.DeserializeObject<CommentDto>(result);

            Assert.Equal(new Guid("94842162-2252-43b2-9c2a-807a86a4393b"), comment.Id);
            Assert.Equal(newComment.Content, comment.Content);
        }

        [Fact]
        public async Task Delete_Comment_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/comments/94842162-2252-43b2-9c2a-807a86a4393b");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void CommentAsserts(CommentDto comment)
        {
            Assert.Equal("very good game", comment.Content);
            Assert.Equal("UserName", comment.UserName);
            Assert.Equal("Minecraft", comment.Gamename);
        }
    }
}
