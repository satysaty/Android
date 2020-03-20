using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface IMasterData<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();

        Task<IEnumerable<T>> GetItemsAsync(int workId);
    }
}
