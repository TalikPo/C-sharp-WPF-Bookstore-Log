using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALInterfaces
{
    interface IMethodsDAL<T>
    {
        void add(T element);
        void remove(T element);
        void update(T element);
        IEnumerable<T> getAll();
        void save();
    }
}
