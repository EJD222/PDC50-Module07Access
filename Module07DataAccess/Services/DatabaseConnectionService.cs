using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07DataAccess.Services
{
    public class DatabaseConnectionService
    {
        private readonly string _databaseConnectionString;

        public DatabaseConnectionService()
        {
            _databaseConnectionString = "Server=localhost; Database=testdb; User ID=testuser; Password=testuser";
        }
        public string GetConnectionString()
        {
            return _databaseConnectionString;
        }
    }
}
