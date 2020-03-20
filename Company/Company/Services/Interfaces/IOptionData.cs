using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Services
{
    public interface IOptionData<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(int workId);
    }
}
