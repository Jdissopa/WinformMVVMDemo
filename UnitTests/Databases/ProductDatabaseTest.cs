using System;
using System.Data;
using System.Data.SQLite;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMDemo.Databases;
using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using UnitTests.Utils;

namespace UnitTests.Databases
{
    [TestClass]
    public class ProductDatabaseTest
    {
        private SQLDatabaseConnector _database;
        private ProductDatabase _pdb;
        [TestInitialize]
        public void Setup()
        {
            _database = new SQLDatabaseConnector();
            _pdb = new ProductDatabase(_database);
        }

        [TestMethod]
        public void Test_Insert_Product()
        {
            Product product = new Product { Name = "ทดสอบ", Price = 25.02m };
            int result = (int)_pdb.Store(product);
            product.Id = result;
            Assert.AreNotEqual(0, product.Id);
            DataTable dt = _database.SelectSQL("SELECT * FROM products;");
            Assert.AreEqual(1, dt.Rows.Count);

            Product product2 = new Product { Name = "ทดสอบ2", Price = 239.05m };
            result = (int)_pdb.Store(product);
            product2.Id = result;
            Assert.AreNotEqual(0, product2.Id);
            dt = _database.SelectSQL("SELECT * FROM products;");
            Assert.AreEqual(2, dt.Rows.Count);
        }

        [TestMethod]
        public void Test_Delete_Product()
        {
            Product product = new Product { Name = "ทดสอบ", Price = 25.02m };
            int result = (int)_pdb.Store(product);
            product.Id = result;

            Product product2 = new Product { Name = "ทดสอบ2", Price = 239.05m };
            result = (int)_pdb.Store(product);
            product2.Id = result;

            //DELETE product 1
            bool resultBool = _pdb.Delete(product);
            Assert.IsTrue(resultBool);
            Assert.AreEqual(0, _database.SelectSQL($@"SELECT * FROM products WHERE id = {product.Id};").Rows.Count);

            resultBool = _pdb.Delete(new Product { Id = 3, Name = "ทดสอบ2", Price = 239.05m });
            Assert.IsFalse(resultBool);
        }
    }

    public class SQLDatabaseConnector : IDatabase
    {
        private SQLiteConnection _cn;
        public SQLDatabaseConnector()
        {
            _cn = new SQLiteConnection("Data Source=:memory:");
            _cn.Open();

            // Create a sample table and insert data
            string createTableQuery = @"
                CREATE TABLE products (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT,
                    price DECIMAL,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP 
                );";
            //INSERT INTO MyTable (Name) VALUES ('John Doe'), ('Jane Doe');";

            _cn.Execute(createTableQuery);
        }

        public bool DeleteSQL(string sql)
        {
            return _cn.Execute(sql) > 0;
        }

        public DataTable SelectSQL(string sql)
        {
            var selected = _cn.Query(sql);
            DataTable result = DatabaseUtils.ToDataTable(selected);

            return result;
        }

        public bool UpdateSQL(string sql)
        {
            return _cn.Execute(sql) > 0;
        }

        public long InsertSQL(string sql)
        {
            _cn.Execute(sql);

            // Retrieve the new inserted row ID
            string selectLastInsertIdQuery = "SELECT last_insert_rowid();";
            long newId = _cn.ExecuteScalar<long>(selectLastInsertIdQuery);
            return newId;
        }
    }
}
