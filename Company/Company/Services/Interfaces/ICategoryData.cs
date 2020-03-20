using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface ICategoryData<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(int mainCategoryId, bool forceRefresh = false);
    }
}
