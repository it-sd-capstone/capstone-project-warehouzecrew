using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Data
{
    internal class CategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>();

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category? GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public int Add(Category category)
        {
            if (category.Id == 0)
                category.Id = _categories.Count > 0 ? _categories.Max(c => c.Id) + 1 : 1;

            _categories.Add(category);
            return category.Id;
        }

        public void Update(Category category)
        {
            var existing = GetById(category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
            }
        }

        public void Delete(int categoryId)
        {
            var category = GetById(categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}

