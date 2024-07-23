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

        public int Store(Product product)
        {
            //TODO: อิมพลรเม้นท์ sql และติดต่อฐานข้อมูล
            string sql = $"some sql";

            return _database.InsertSQL(sql);
        }

        public bool Delete(Product product)
        {
            //TODO: อิมพลรเม้นท์ sql และติดต่อฐานข้อมูล
            string sql = $"some sql";

            return _database.DeleteSQL(sql);
        }
    }
}
