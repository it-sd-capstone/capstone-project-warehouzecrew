using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using System.Data.SQLite;

namespace ReorderPointSystem.Tests.Data
{
    public class ItemRepositoryTests : TestBase
    {
        [Fact]
        public void TestAdd()
        {
            Database.Initialize();

            // must insert category before any items can be inserted
            string addCommand = @"insert into categories (name) values (@name)";
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(addCommand, con);
            command.Prepare();
            command.Parameters.AddWithValue("name", "test");
            int rows = command.ExecuteNonQuery();
            con.Close();

            ItemRepository repo = new ItemRepository();
            Item item = new Item(0, 0, "test item", "this is a test item used for testing purposes", 300, 400, 800);
            repo.Add(item);
            Assert.True(repo.GetById(item.Id).ToString() == item.ToString());
        }
        [Fact]
        public void TestUpdate()
        {
            Database.Initialize();

            // must insert category before any items can be inserted
            string addCommand = @"insert into categories (name) values (@name)";
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(addCommand, con);
            command.Prepare();
            command.Parameters.AddWithValue("name", "test");
            int rows = command.ExecuteNonQuery();
            con.Close();

            ItemRepository repo = new ItemRepository();
            Item item = new Item(0, 0, "test item", "this is a test item used for testing purposes", 300, 400, 800);
            repo.Add(item);
            Assert.True(repo.GetById(item.Id).ToString() == item.ToString());
            item.UpdateStock(200);
            repo.Update(item);
            Assert.True(repo.GetById(item.Id).ToString() == item.ToString());
        }
        [Fact]
        public void TestDelete()
        {
            Database.Initialize();

            // must insert category before any items can be inserted
            string addCommand = @"insert into categories (name) values (@name)";
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(addCommand, con);
            command.Prepare();
            command.Parameters.AddWithValue("name", "test");
            int rows = command.ExecuteNonQuery();
            con.Close();

            ItemRepository repo = new ItemRepository();
            List<Item> items = new List<Item>();
            for (int i = 0; i < 10; i++)
            {
                var newitem = Item.RandomItem(i);
                newitem.CategoryId = 0;
                items.Add(newitem);
            }
            Assert.Equal(10, repo.GetAll().Count);
            repo.Delete(3);
            Assert.Equal(9, repo.GetAll().Count);
            repo.Delete(5);
            Assert.Equal(8, repo.GetAll().Count);
            repo.Delete(9);
            Assert.Equal(7, repo.GetAll().Count);
        }
        [Fact]
        public void TestSearch()
        {
            Database.Initialize();

            // must insert category before any items can be inserted
            string addCommand = @"insert into categories (name) values (@name)";
            SQLiteConnection con = Database.GetConnection();
            using var command0 = new SQLiteCommand(addCommand, con);
            command0.Prepare();
            command0.Parameters.AddWithValue("name", "test");
            command0.ExecuteNonQuery();

            using var command1 = new SQLiteCommand(addCommand, con);
            command1.Prepare();
            command1.Parameters.AddWithValue("name", "test");
            command1.ExecuteNonQuery();

            using var command2 = new SQLiteCommand(addCommand, con);
            command2.Prepare();
            command2.Parameters.AddWithValue("name", "test");
            command2.ExecuteNonQuery();

            using var command3 = new SQLiteCommand(addCommand, con);
            command3.Prepare();
            command3.Parameters.AddWithValue("name", "test");
            command3.ExecuteNonQuery();
            con.Close();

            ItemRepository repo = new ItemRepository();
            List<Item> items = new List<Item>();
            for (int i = 0; i < 10; i++)
            {
                var newitem = Item.RandomItem(i);
                newitem.CategoryId = i % 4;
                items.Add(newitem);
            }
            Assert.Equal(10, repo.GetAll().Count);
            // all randomly generated items have e in their name
            Assert.Equal(10, repo.Search("e").Count);
            // all randomly generated items have their name in their description
            Assert.Equal(10, repo.Search("[@]desc e").Count);
            Assert.Equal(10, repo.Search("[@]name e[@]desc e").Count);
            // the random items category ids have been set to have this pattern during the for loop: 0, 1, 2, 3, 0, 1, 2, 3, 0, 1
            Assert.Equal(3, repo.Search("[@]cat 1").Count);
            Assert.Equal(2, repo.Search("[@]cat 3").Count);
        }
        [Fact]
        public void TestGetAll()
        {
            Database.Initialize();

            // must insert category before any items can be inserted
            string addCommand = @"insert into categories (name) values (@name)";
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(addCommand, con);
            command.Prepare();
            command.Parameters.AddWithValue("name", "test");
            int rows = command.ExecuteNonQuery();
            con.Close();

            ItemRepository repo = new ItemRepository();
            List<Item> items = new List<Item>();
            for (int i = 0; i < 10; i++)
            {
                var newitem = Item.RandomItem(i);
                newitem.CategoryId = 0;
                items.Add(newitem);
            }
            Assert.Equal(10, repo.GetAll().Count);
        }
    }
}
