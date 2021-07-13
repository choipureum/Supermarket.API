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
    public class ProductsTests
    {
        #region Get Products Test
        [Fact]
        public async Task Test_Get_Categories_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/Products");
                response.EnsureSuccessStatusCode();
                var tmp = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<List<ProductResource>>(tmp);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        #endregion

        #region Post Products Test
        [Fact]
        public async Task Test_Post_Products_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Insert Category
                var response_category = await client.PostAsync("/api/Categories"
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveCategoryResource()
                        {
                            Name = "testCategory"
                        }),
                        Encoding.UTF8,
                        "application/json"));

                //Insert Product mapping testCategory
                var response = await client.PostAsync("/api/Products"
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveProductResource()
                        {
                            Name = "test9999",
                            QuantityInPackage = 99,
                            UnitOfMeasurement = 3,
                            CategoryId =1
                        }),
                        Encoding.UTF8,
                        "application/json"));

                response.EnsureSuccessStatusCode();
                var tmp = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductResource>(tmp);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                Assert.Equal("test9999",product.Name);
                Assert.Equal(99, product.QuantityInPackage);
                Assert.Equal("G", product.UnitOfMeasurement);
                Assert.Equal("testCategory", product.Category.Name);
            }
        }
        #endregion

        #region Put Products Test
        [Fact]
        public async Task Test_Put_Products_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Insert Category
                var response_category = await client.PostAsync("/api/Categories"
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveCategoryResource()
                        {
                            Name = "testCategory"
                        }),
                        Encoding.UTF8,
                        "application/json"));

                response_category.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response_category.StatusCode);

                //Insert Product mapping testCategory
                var response = await client.PostAsync("/api/Products"
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveProductResource()
                        {
                            Name = "test9999",
                            QuantityInPackage = 99,
                            UnitOfMeasurement = 3,
                            CategoryId = 1
                        }),
                        Encoding.UTF8,
                        "application/json"));

                response.EnsureSuccessStatusCode();
                var tmp = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductResource>(tmp);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                //Insert Product mapping testCategory
                var response_put = await client.PutAsync("/api/Products/"+product.Id.ToString()
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveProductResource()
                        {
                            Name = "test8888",
                            QuantityInPackage = 88,
                            UnitOfMeasurement = 2,
                            CategoryId = 1
                        }),
                        Encoding.UTF8,
                        "application/json"));

                response_put.EnsureSuccessStatusCode();
                var tmp_put = await response_put.Content.ReadAsStringAsync();
                var product_put = JsonConvert.DeserializeObject<ProductResource>(tmp_put);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                Assert.Equal("test8888", product_put.Name);
                Assert.Equal(88, product_put.QuantityInPackage);
                Assert.Equal("MG", product_put.UnitOfMeasurement);
                Assert.Equal("testCategory", product_put.Category.Name);
            }
        }
        #endregion

        #region Delete Products Test
        [Fact]
        public async Task Test_Delete_Products_Async()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Insert Category
                var response_category = await client.PostAsync("/api/Categories"
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveCategoryResource()
                        {
                            Name = "testCategory"
                        }),
                        Encoding.UTF8,
                        "application/json"));

                response_category.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response_category.StatusCode);

                //Insert Product mapping testCategory
                var response = await client.PostAsync("/api/Products"
                        , new StringContent(
                        JsonConvert.SerializeObject(new SaveProductResource()
                        {
                            Name = "test9999",
                            QuantityInPackage = 99,
                            UnitOfMeasurement = 3,
                            CategoryId = 1
                        }),
                        Encoding.UTF8,
                        "application/json"));

                response.EnsureSuccessStatusCode();
                var tmp = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductResource>(tmp);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var response_delete = await client.DeleteAsync("/api/Products/" + product.Id.ToString());
                response_delete.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response_delete.StatusCode);

                //Check : 삭제확인
                //get By Id Check(입력후 ID로 조회 후 입력 NoContent 확인)
                var getValueResponse = await client.GetAsync("/api/Products/" + product.Id.ToString());
                getValueResponse.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.NoContent, getValueResponse.StatusCode);
            }
        }
        #endregion

    }
}
