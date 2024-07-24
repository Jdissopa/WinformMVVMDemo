using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Databases
{
    public class ProductDatabase
    {
        private IDatabase _database;

        public ProductDatabase(IDatabase database)
        {
            _database = database;
        }

        public long Store(Product product)
        {
            //อิมพลรเม้นท์ sql และติดต่อฐานข้อมูล
            string sql = $@"INSERT INTO products (name, price) VALUES('{product.Name}',{product.Price.ToString()});";

            return _database.InsertSQL(sql);
        }

        public bool Delete(Product product)
        {
            //อิมพลรเม้นท์ sql และติดต่อฐานข้อมูล
            string sql = $"DELETE FROM products WHERE id = {product.Id.ToString()};";

            return _database.DeleteSQL(sql);
        }
    }
}
