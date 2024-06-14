using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;

        public CustomerRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            
        }
    }
}