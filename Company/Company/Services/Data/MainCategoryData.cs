using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;

namespace Company.Services
{
    public class MainCategoryData : IMainCategoryData<MainCategory>
    {
        List<MainCategory> items;

        public MainCategoryData()
        {
            items = new List<MainCategory>();
            var mockItems = new List<MainCategory>
            {
                new MainCategory { Id = 1, CityId=0, Icon= "santehnika2.png", Name = "Сантехника", Description="Описание категории" },
                new MainCategory { Id = 2, CityId=0, Icon= "elektrika.png", Name = "Элетрика", Description="Описание категории" },
                new MainCategory { Id = 3, CityId=0, Icon= "otoplenie.png", Name = "Отопление", Description="Описание категории" },
                new MainCategory { Id = 4, CityId=0, Icon= "canalization.png", Name = "Канализация", Description="Описание категории" },
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