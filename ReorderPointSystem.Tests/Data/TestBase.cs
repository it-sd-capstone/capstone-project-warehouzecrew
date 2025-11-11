using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReorderPointSystem.Data;

public abstract class TestBase
{
    protected const string TestDbFilePath = "test_rps.db";

    protected TestBase()
    {
        // Ensure a clean test database
        if (File.Exists(TestDbFilePath))
        {
            File.Delete(TestDbFilePath);
        }

        Database.SetTestDatabase(TestDbFilePath);
        Database.Initialize();
    }
}