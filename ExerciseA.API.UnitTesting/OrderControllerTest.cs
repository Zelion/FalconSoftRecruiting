using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ExerciseA.API.Controllers.Order.Response;
using ExerciseA.API.Requests;
using ExerciseA.Domain.Entities;
using Newtonsoft.Json;
using Xunit;

namespace ExerciseA.API.UnitTesting
{
    public class OrderControllerTest
    {
        private readonly HttpClient client;

        public OrderControllerTest()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44380")
            };
        }

        #region Get

        [Fact]
        public async void When_GetOrdersWithoutFilters_Expect_NotEmpty()
        {
            // Arrange
            var user = new UserInfo // Change with real email and password from db
            {
                Email = "Cara.Kemmer48@hotmail.com",
                Password = "rPHSr8F5Ug"
            };

            // Act
            await SetJwtToken(user);
            var result = await SendAsync("/api/orders");
            var orders = JsonConvert.DeserializeObject<IEnumerable<OrderResponse>>(await result.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(orders);
            Assert.Equal(10, orders.Count());
        }

        [Fact]
        public async void When_GetOrdersWithFilters_Expect_NotEmpty()
        {
            // Arrange
            var user = new UserInfo // Change with real email and password from db
            {
                Email = "Cara.Kemmer48@hotmail.com",
                Password = "rPHSr8F5Ug"
            };

            // Act
            await SetJwtToken(user);
            var result = await SendAsync("/api/orders?page=1&customerName=Juan&quantity=73"); //Change with real db data
            var order = JsonConvert.DeserializeObject<IEnumerable<OrderResponse>>(await result.Content.ReadAsStringAsync());

            // Assert
            Assert.NotEmpty(order);
        }

        [Fact]
        public async void When_GetWithoutJWT_Expect_Unauthorized()
        {
            // Act
            var result = await SendAsync("/api/orders?orderBy=createdDate");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
        }

        #endregion

        #region Put

        [Fact]
        public async void When_Put_Expect_DbChange()
        {
            // Arrange
            long id = 1;

            var orderDetailRequest = new OrderDetailEditRequest
            {
                Quantity = 10
            };

            var orderDetailRequestJson = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(orderDetailRequest),
                Encoding.UTF8,
                "application/json");

            var user = new UserInfo // Change with real email and password from db
            {
                Email = "Cara.Kemmer48@hotmail.com",
                Password = "rPHSr8F5Ug"
            };

            // Act
            await SetJwtToken(user);
            var httpResponse = await client.PutAsync($"/api/orders/{id}", orderDetailRequestJson);
            httpResponse.EnsureSuccessStatusCode();

            // Assert (check db)
        }

        #endregion


        #region Private Methods

        private async Task SetJwtToken(UserInfo user)
        {
            var userItemJson = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json");

            var httpResponse = await client.PostAsync("/api/token", userItemJson);
            httpResponse.EnsureSuccessStatusCode();

            var token = httpResponse.Content.ReadAsStringAsync().Result;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private async Task<HttpResponseMessage> SendAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();

            return response;
        }

        #endregion


    }
}
