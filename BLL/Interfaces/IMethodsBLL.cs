using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IMethodsBLL<T>
    {
        void add(T element);
        void remove(T element);
        void update(T element);
        List<T> returnAll();
        void getAllfromDB();
        void saveChanges();
    }
}
