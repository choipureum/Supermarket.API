using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Controllers;
using Supermarket.API.Resources;
using Xunit;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Supermarket.API.Integration.Tests
{
    public class CategoryTests 
    {
        // Integration Test : Category
        #region Get Catetories Test
        [Fact]
        public async Task Test_Get_Categories_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Categories");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        #endregion

        #region Post Categories Test 
        [Fact]
        public async Task Test_Post_Categories_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/Categories"
                                , new StringContent(
                                JsonConvert.SerializeObject(new SaveCategoryResource()
                                {
                                    Name="test9999"
                                }),
                            Encoding.UTF8,
                            "application/json"));

                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                var tmp = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryResource>(tmp);
                Assert.Equal("test9999", category.Name);

                //get By Id Check(입력후 ID로 조회 후 입력 확인)
                var getValueResponse = await client.GetAsync("/api/Categories/"+category.Id.ToString());
                getValueResponse.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, getValueResponse.StatusCode);

                var value = await getValueResponse.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<CategoryResource>(value);
                Assert.Equal(item.Name, category.Name);
            }
        }
        #endregion

        #region Put Categories Test
        [Fact]
        public async Task Test_Put_Categories_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Input value
                var response = await client.PostAsync("/api/Categories"
                    , new StringContent(
                        JsonConvert.SerializeObject(new SaveCategoryResource()
                        {
                            Name = "test9999"
                        }),
                        Encoding.UTF8,
                        "application/json"));
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                var tmp = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryResource>(tmp);
                Assert.Equal("test9999", category.Name);


                //Patch value
                var response_put = await client.PutAsync("/api/Categories/"+ category.Id.ToString()
                    , new StringContent(
                        JsonConvert.SerializeObject(new SaveCategoryResource()
                        {
                            Name = "test8888"
                        }),
                        Encoding.UTF8,
                        "application/json"));
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                //Check
                //get By Id Check(입력후 ID로 조회 후 입력 확인)
                var getValueResponse = await client.GetAsync("/api/Categories/" + category.Id.ToString());
                getValueResponse.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, getValueResponse.StatusCode);

                var value = await getValueResponse.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<CategoryResource>(value);
                Assert.Equal("test8888", item.Name);
            }
        }
        #endregion

        #region Delete Categories Test
        [Fact]
        public async Task Test_Delete_Categories_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Input value
                var response = await client.PostAsync("/api/Categories"
                    , new StringContent(
                        JsonConvert.SerializeObject(new SaveCategoryResource()
                        {
                            Name = "test9999"
                        }),
                        Encoding.UTF8,
                        "application/json"));
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                var tmp = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryResource>(tmp);
                Assert.Equal("test9999", category.Name);


                //Patch value
                var response_delete = await client.DeleteAsync("/api/Categories/" + category.Id.ToString());
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                //Check
                //get By Id Check(입력후 ID로 조회 후 입력 NoContent 확인)
                var getValueResponse = await client.GetAsync("/api/Categories/" + category.Id.ToString());
                getValueResponse.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.NoContent, getValueResponse.StatusCode);
            }
        }
        #endregion
    }
}
