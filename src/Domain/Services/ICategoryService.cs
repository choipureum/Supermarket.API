using Supermarket.API.Domain.Models;
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
    }
}
