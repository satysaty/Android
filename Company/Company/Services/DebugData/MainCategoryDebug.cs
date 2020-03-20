using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;

namespace Company.Services
{
    public class MainCategoryDebug : IMainCategoryData<MainCategory>
    {
        List<MainCategory> items;

        public MainCategoryDebug()
        {
            items = new List<MainCategory>();
            var mockItems = new List<MainCategory>
            {
                new MainCategory { Id = 0, Icon= "main_san.png", Name = "Сантехника", Description="Описание категории" },
                new MainCategory { Id = 1, Icon= "main_el.png", Name = "Элетрика", Description="Описание категории" },
                new MainCategory { Id = 2, Icon= "main_re.png", Name = "Ремонт", Description="Описание категории" },
                new MainCategory { Id = 3, Icon= "main_sw.png", Name = "Душевая", Description="Описание категории" },
                new MainCategory { Id = 4, Icon= "main_ki.png", Name = "Кухня", Description="Описание категории" },
                new MainCategory { Id = 5, Icon= "main_ar.png", Name = "Гостинная", Description="Описание категории" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(MainCategory item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(MainCategory item)
        {
            var oldItem = items.Where((MainCategory arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((MainCategory arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<MainCategory> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<MainCategory>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<MainCategory>> LoadItemsAsync()
        {

            var list = new List<MainCategory>();

            return await Task.FromResult(list);
        }
    }
}