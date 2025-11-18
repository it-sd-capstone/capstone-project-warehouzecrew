using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReorderPointSystem.Models;
using ReorderPointSystem.Data;
using Xunit.Abstractions;

namespace ReorderPointSystem.Tests.Data
{
    public class CategoryRepositoryTests : TestBase
    {

        private readonly CategoryRepository _repository;

        //Output to console (for checking accuracy)
        private readonly ITestOutputHelper _output;

        public CategoryRepositoryTests(ITestOutputHelper output)
        {

            _repository = new CategoryRepository();
            _output = output;
        }



        [Fact]
        //Should add new category into the DB
        public void AddCategory()
        {
            //Define
            var category = new Category { Name = "Hardware" };

            //Action
            var newId = _repository.Add(category);
            var fetched = _repository.GetById(newId);

            //Assert
            Assert.NotNull(fetched);
            Assert.Equal("Hardware", fetched!.Name);
        }

        [Fact]
        //Should retrieve all available categories
        public void GetAllCategories()
        {
            //Define
            _repository.Add(new Category { Name = "Electronics" });
            _repository.Add(new Category { Name = "Food" });
            _repository.Add(new Category { Name = "Chemical" });
            _repository.Add(new Category { Name = "Household" });
            _repository.Add(new Category { Name = "Apparel" });

            //Action
            var all = _repository.GetAll();

            //Show all categories as output to console
            foreach (var category in all)
            {
                _output.WriteLine(($"Category ID: {category.Id}, Name: {category.Name}"));
            }

            //Assert
            Assert.NotEmpty(all);
            Assert.True(all.Count >= 2);

        }

        [Fact]
        //Should update the category name
        public void UpdateCategory()
        {
            //Define
            var category = new Category { Name = "Electrics" };
            var id = _repository.Add(category);
            category.Id = id;
            category.Name = "Electrical";

            //Action
            _repository.Update(category);
            var updated = _repository.GetById(id);

            //Assert
            Assert.Equal("Electrical", updated!.Name);
        }

        [Fact]
        //Should delete a category
        public void DeleteCategory()
        {
            //Define
            var id = _repository.Add(new Category { Name = "Temp" });

            //Action
            _repository.Delete(id);
            var deleted = _repository.GetById(id);

            //Assert
            Assert.Null(deleted);

        }
    }
}