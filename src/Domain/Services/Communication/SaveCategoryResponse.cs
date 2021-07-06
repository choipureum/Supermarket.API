using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }
        /// <summary>
        /// success response 생성
        /// </summary>
        /// <param name="category"></param>
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category){}

        /// <summary>
        /// error response 생성
        /// </summary>
        /// <param name="message"></param>
        public SaveCategoryResponse(string message) : this(false, message, null) { }
    }
}
