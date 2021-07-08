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
        /// 상세조회 : async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryResponse> DetailAsync(int id);
        /// <summary>
        /// category 등록
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<CategoryResponse> SaveAsync(Category category);
        /// <summary>
        /// category 수정
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        /// <summary>
        /// category 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryResponse> DeleteAsync(int id);
    }
}
