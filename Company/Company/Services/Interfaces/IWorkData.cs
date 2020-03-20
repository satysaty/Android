using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface IWorkData<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(int categoryId, bool forceRefresh = false);
    }
}
