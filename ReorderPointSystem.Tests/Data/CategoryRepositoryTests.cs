using ReorderPointSystem.Models;
using ReorderPointSystem.Data;
using Xunit;

namespace ReorderPointSystem.Tests.Data
{
    public class CategoryRepositoryTests : TestBase
    {
        private readonly CategoryRepository _repository = new CategoryRepository();

        [Fact]
        public void AddCategory()
        {
            var category = new Category { Name = "Hardware" };

            var newId = _repository.Add(category);
            var fetched = _repository.GetById(newId);

            Assert.NotNull(fetched);
            Assert.Equal("Hardware", fetched!.Name);
        }

        [Fact]
        public void GetAllCategories()
        {
            _repository.Add(new Category { Name = "Electronics" });
            _repository.Add(new Category { Name = "Food" });
            _repository.Add(new Category { Name = "Chemical" });
            _repository.Add(new Category { Name = "Household" });
            _repository.Add(new Category { Name = "Apparel" });

            var all = _repository.GetAll();

            Assert.NotEmpty(all);
            Assert.True(all.Count >= 2);
        }

        [Fact]
        public void UpdateCategory()
        {
            var category = new Category { Name = "Electrics" };
            var id = _repository.Add(category);
            category.Id = id;
            category.Name = "Electrical";

            _repository.Update(category);
            var updated = _repository.GetById(id);

            Assert.Equal("Electrical", updated!.Name);
        }

        [Fact]
        public void DeleteCategory()
        {
            var id = _repository.Add(new Category { Name = "Temp" });

            _repository.Delete(id);
            var deleted = _repository.GetById(id);

            Assert.Null(deleted);
        }
    }
}
