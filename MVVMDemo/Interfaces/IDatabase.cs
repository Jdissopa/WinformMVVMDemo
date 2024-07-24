using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Interfaces
{
    public interface IDatabase
    {
        long InsertSQL(string sql);
        bool UpdateSQL(string sql);
        bool DeleteSQL(string sql);
        DataTable SelectSQL(string sql);
    }
}
