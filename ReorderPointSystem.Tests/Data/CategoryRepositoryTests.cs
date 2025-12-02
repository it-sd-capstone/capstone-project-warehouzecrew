using ReorderPointSystem.Models;
using ReorderPointSystem.Data;

namespace ReorderPointSystem.Tests.Data
{
    public class CategoryRepositoryTests : TestBase
    {
        private Category CreateTestCategory(string name = "TestCategory")
        {
            return new Category { Name = name };
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            var repo = new CategoryRepository();

            // Act
            List<Category> results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GetAll_ShouldReturnCategoryList_WhenCategoriesExist()
        {
            // Arrange
            var repo = new CategoryRepository();
            repo.Add(CreateTestCategory("Electronics"));
            repo.Add(CreateTestCategory("Food"));

            // Act
            List<Category> results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void GetAll_ShouldReturnCategoriesOrderedByName()
        {
            // Arrange
            var repo = new CategoryRepository();
            repo.Add(CreateTestCategory("Zebra"));
            repo.Add(CreateTestCategory("Apple"));
            repo.Add(CreateTestCategory("Mango"));

            // Act
            List<Category> results = repo.GetAll();

            // Assert
            Assert.Equal("Apple", results[0].Name);
            Assert.Equal("Mango", results[1].Name);
            Assert.Equal("Zebra", results[2].Name);
        }

        [Fact]
        public void GetAll_ShouldReturnCategoriesWithAllProperties()
        {
            // Arrange
            var repo = new CategoryRepository();
            repo.Add(CreateTestCategory("Hardware"));

            // Act
            List<Category> results = repo.GetAll();

            // Assert
            Category category = results.First();
            Assert.True(category.Id > 0);
            Assert.Equal("Hardware", category.Name);
        }

        [Fact]
        public void GetById_ShouldReturnCategory_WhenCategoryDoesExist()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category addedCategory = repo.Add(CreateTestCategory("Electronics"));

            // Act
            Category? result = repo.GetById(addedCategory.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedCategory.Id, result.Id);
            Assert.Equal("Electronics", result.Name);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            var repo = new CategoryRepository();

            // Act
            Category? result = repo.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_ShouldReturnNewCategory()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = CreateTestCategory("Hardware");

            // Act
            Category result = repo.Add(category);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            Assert.Equal("Hardware", result.Name);
        }

        [Fact]
        public void Add_ShouldAllowCategoryToBeRetrieved()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = CreateTestCategory("Apparel");

            // Act
            Category addedCategory = repo.Add(category);
            Category? retrievedCategory = repo.GetById(addedCategory.Id);

            // Assert
            Assert.NotNull(retrievedCategory);
            Assert.Equal(addedCategory.Id, retrievedCategory.Id);
            Assert.Equal("Apparel", retrievedCategory.Name);
        }

        [Fact]
        public void Add_ShouldGenerateUniqueIds_ForMultipleCategories()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category1 = CreateTestCategory("Category1");
            Category category2 = CreateTestCategory("Category2");

            // Act
            Category result1 = repo.Add(category1);
            Category result2 = repo.Add(category2);

            // Assert
            Assert.NotEqual(result1.Id, result2.Id);
        }

        [Fact]
        public void Add_ShouldPreserveCategoryName()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = CreateTestCategory("Chemical");

            // Act
            Category result = repo.Add(category);

            // Assert
            Assert.Equal(category.Name, result.Name);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenCategoryDoesExist()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = repo.Add(CreateTestCategory("Electrics"));
            category.Name = "Electrical";

            // Act
            bool result = repo.Update(category);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenCategoryDoesNotExist()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = CreateTestCategory("NonExistent");
            category.Id = 999;

            // Act
            bool result = repo.Update(category);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Update_ShouldUpdateCategoryName()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = repo.Add(CreateTestCategory("OldName"));
            int originalId = category.Id;
            category.Name = "NewName";

            // Act
            repo.Update(category);
            Category? updatedCategory = repo.GetById(originalId);

            // Assert
            Assert.NotNull(updatedCategory);
            Assert.Equal("NewName", updatedCategory.Name);
        }

        [Fact]
        public void Update_ShouldNotChangeId()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = repo.Add(CreateTestCategory("TestName"));
            int originalId = category.Id;
            category.Name = "UpdatedName";

            // Act
            repo.Update(category);
            Category? updatedCategory = repo.GetById(originalId);

            // Assert
            Assert.NotNull(updatedCategory);
            Assert.Equal(originalId, updatedCategory.Id);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenCategoryDoesExist()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = repo.Add(CreateTestCategory("Temp"));

            // Act
            bool result = repo.Delete(category.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenCategoryDoesNotExist()
        {
            // Arrange
            var repo = new CategoryRepository();

            // Act
            bool result = repo.Delete(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_ShouldRemoveCategoryFromDatabase()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category = repo.Add(CreateTestCategory("ToDelete"));

            // Act
            repo.Delete(category.Id);
            Category? deletedCategory = repo.GetById(category.Id);

            // Assert
            Assert.Null(deletedCategory);
        }

        [Fact]
        public void Delete_ShouldNotAffectOtherCategories()
        {
            // Arrange
            var repo = new CategoryRepository();
            Category category1 = repo.Add(CreateTestCategory("Category1"));
            Category category2 = repo.Add(CreateTestCategory("Category2"));

            // Act
            repo.Delete(category1.Id);
            Category? remainingCategory = repo.GetById(category2.Id);

            // Assert
            Assert.NotNull(remainingCategory);
            Assert.Equal("Category2", remainingCategory.Name);
        }
    }
}