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
    public class ReviewControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public ReviewControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Reviews_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/reviews");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Reviews_ShouldReturnExistingReview()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/reviews");

            var result = await response.Content.ReadAsStringAsync();
            var reviews = JsonConvert.DeserializeObject<List<ReviewDto>>(result);

            var review = reviews.FirstOrDefault(x => x.Id == Guid.Parse("ba2104c7-0106-4e36-bd50-5f44e672e447"));
            ReviewAsserts(review);
        }

        [Fact]
        public async Task Get_Reviews_By_Id_ShouldReturnExistingReview()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/reviews/ba2104c7-0106-4e36-bd50-5f44e672e447");

            var result = await response.Content.ReadAsStringAsync();
            var review = JsonConvert.DeserializeObject<ReviewDto>(result);

            ReviewAsserts(review);
        }

        [Fact]
        public async Task Post_Reviews_ShouldReturnCreatedResponse()
        {
            var review = new ReviewViewModel
            {
                Content = "i liked the game test review",
                Rating = 8,
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                GameId = new Guid("2df905bf-8205-4466-942d-713a689431c1")
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/reviews",
                new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Review_ShouldReturnCreatedReview()
        {
            var newReview = new ReviewViewModel
            {
                Content = "i liked the game test review",
                Rating = 8,
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                GameId = new Guid("2df905bf-8205-4466-942d-713a689431c1")
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/reviews",
                new StringContent(JsonConvert.SerializeObject(newReview), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var review = JsonConvert.DeserializeObject<ReviewDto>(result);

            Assert.Equal(newReview.Content, review.Content);
            Assert.Equal(newReview.Rating, review.Rating);
            Assert.Equal("UserName", review.UserName);
            Assert.Equal("Minecraft", review.Gamename);
        }

        [Fact]
        public async Task Put_Comment_ShouldReturnUpdatedcomment()
        {
            var newReview = new ReviewViewModel 
            {
                Content = "Updated review content test content",
                Rating = 9,
                UserId = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                GameId = new Guid("2df905bf-8205-4466-942d-713a689431c1")
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/reviews/ba2104c7-0106-4e36-bd50-5f44e672e447",
                new StringContent(JsonConvert.SerializeObject(newReview), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var review = JsonConvert.DeserializeObject<ReviewDto>(result);

            Assert.Equal(new Guid("ba2104c7-0106-4e36-bd50-5f44e672e447"), review.Id);
            Assert.Equal(newReview.Content, review.Content);
            Assert.Equal(newReview.Rating, review.Rating);
        }

        [Fact]
        public async Task Delete_Comment_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/reviews/ba2104c7-0106-4e36-bd50-5f44e672e447");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void ReviewAsserts(ReviewDto review)
        {
            Assert.Equal("one of the best game i ever played", review.Content);
            Assert.Equal(10, review.Rating);
            Assert.Equal("UserName", review.UserName);
            Assert.Equal("Minecraft", review.Gamename);
        }
    }
}
