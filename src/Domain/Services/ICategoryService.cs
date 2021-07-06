using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// 모든 List get : async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> ListAsync();

        /// <summary>
        /// response message
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}
