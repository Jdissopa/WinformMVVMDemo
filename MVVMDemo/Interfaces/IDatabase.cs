using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Interfaces
{
    public interface IDatabase<U>
    {
        int Insert(U data);
        int[] InsertList(List<U> data);
        int InsertSQL(string sql);
        bool Update(U data);
        bool UpdateList(List<U> data);
        bool UpdateSQL(string sql);
        bool Delete(U data);
        bool DeleteList(List<U> data);
        bool DeleteSQL(string sql);
        object Find(int id);
        object FindAll();
        object SelectRaw(string sql);
    }
}
