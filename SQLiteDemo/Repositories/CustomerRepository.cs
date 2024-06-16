using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);

            connection.CreateTable<Customer>();
        }

        public void AddOrUpdate(Customer customer)
        {
            int result = 0;

            try
            {
                if (customer.ID != 0)
                {
                    result = connection.Update(customer);
                    StatusMessage = $"{result} record(s) updated";
                }
                else
                {
                    result = connection.Insert(customer);
                    StatusMessage = $"{result} record(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add customer. Error: {ex.Message}";
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public Customer GetById(int id)
        {
            try
            {
                return connection.Table<Customer>().FirstOrDefault(c => c.ID == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public List<Customer> GetAll2()
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. Error: {ex.Message}";
            }

            return null;
        }

        public void Delete(int customerId)
        {
            try
            {
                var customer = GetById(customerId);
                int result = connection.Delete<Customer>(customer);
                StatusMessage = $"{result} record(s) deleted";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to delete record. Error: {ex.Message}";
            }
        }
    }
}