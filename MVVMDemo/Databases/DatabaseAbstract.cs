using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Databases
{
    public abstract class DatabaseAbstract<U> : IDatabase<U>
    {
        public bool Delete(U data)
        {
            return false;
        }
        public bool DeleteList(List<U> data)
        {
            return false;
        }

        public bool DeleteSQL(string sql)
        {
            return false;
        }

        public object Find(int id)
        {
            return null;
        }

        public object FindAll()
        {
            return null;
        }

        public int Insert(U data)
        {
            return -1;
        }

        public int[] InsertList(List<U> data)
        {
            return new int[0];
        }

        public int InsertSQL(string sql)
        {
            return -1;
        }

        public object SelectRaw(string sql)
        {
            return null;
        }

        public bool Update(U data)
        {
            return false;
        }

        public bool UpdateList(List<U> data)
        {
            return false;
        }

        public bool UpdateSQL(string sql)
        {
            return false;
        }
    }
}
