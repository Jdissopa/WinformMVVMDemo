using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Databases
{
    public class LabDatabaseConnector : IDatabase
    {

        //อิมพลีเมน้ท์การต่อกับฐานข้อมุล Lab เครื่อง HIS

        public bool DeleteSQL(string sql)
        {
            return false;
        }

        public DataTable SelectSQL(string sql)
        {
            return null;
        }

        public bool UpdateSQL(string sql)
        {
            return false;
        }

        public long InsertSQL(string sql)
        {
            return -1l;
        }
    }
}
